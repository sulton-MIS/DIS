using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.DISA200001Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISA200001Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA200001Repository R = new DISA200001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "History Perubahan Asset";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult MoveFile()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                saveFile = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset", Request.Form["Name"] + ".PNG");
                file.SaveAs(Server.MapPath(resultFilePath));
            }
            var MSG = "Nice";
            return Json(new { MSG });
        }


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, string MEREK, string SUPPLIER)
        {
            //Buat Paging//
            PagingModel_DISA200001 pg = new PagingModel_DISA200001(R.getCountDISA200001(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER), start, display);

            //Munculin Data ke Grid//
            List<DISA200001Master> List = R.getDataDISA200001(pg.StartData, pg.EndData, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER).ToList();
            ViewData["DataDISA200001"] = List;
            ViewData["PagingDISA200001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW(
            string DATA_ID, 
            string NO_URUT, 
            string NAMA_ASSET,
            string NAMA_FOTO,
            //string SOURCE_FOTO, 
            string MEREK,
            string TIPE,
            string SUPPLIER,
            string TAHUN,
            string QTY,
            string HARGA_SATUAN,
            //string TOTAL,
            string JENIS_ASSET,
            string KATEGORI_ASSET,
            string PIC_BELI,
            string DEPT_USER,
            string NAMA_USER,
            string KD_LOKASI, string HALTE, string JENIS_DOC, string NO_BC,
            string TGL_BC, string TGL_REGIST
            , string STATUS, string FLG_LABEL_ASSET
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA200001Repository.Create(DATA_ID, NO_URUT, NAMA_ASSET, NAMA_FOTO, MEREK, TIPE, SUPPLIER, TAHUN, QTY, HARGA_SATUAN, JENIS_ASSET, KATEGORI_ASSET, PIC_BELI, DEPT_USER, NAMA_USER, KD_LOKASI, HALTE, JENIS_DOC, NO_BC, TGL_BC, TGL_REGIST, STATUS, FLG_LABEL_ASSET /*, SOURCE_FOTO,  TOTAL, */);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Asset", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Asset", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult GenerateMessage(string MSG_ID, string p_PARAM1, string p_PARAM2, string p_PARAM3, string p_PARAM4)
        {
            try
            {
                M.MSG_ID = MSG_ID;
                M.p_PARAM1 = p_PARAM1;
                M.p_PARAM2 = p_PARAM2;
                M.p_PARAM3 = p_PARAM3;
                M.p_PARAM4 = p_PARAM4;
                var res = M.getMessageTextWithFunctionSQL(M);
                MESSAGE_TXT = res[0].MSG_TEXT;
                MESSAGE_TYPE = res[0].MSG_TYPE;
            }
            catch (Exception M)
            {
                MESSAGE_TXT = M.Message.ToString();
                MESSAGE_TYPE = "Err";
            }
            return Json(new { MESSAGE_TXT, MESSAGE_TYPE }, JsonRequestBehavior.AllowGet);
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                //ViewData["COMPANY"] = R.getCompany();
                //ViewData["no_urut"] = "TESTING";
                ViewData["no_urut"] = R.getNo_Urutan();
                ViewData["nama_lokasi"] = R.getLokasi();
                ViewData["EXECUTOR"] = R.getExecutor();
                //ViewData["IDENTITY"] = R.getIdentity();
                //ViewData["SECTION"] = R.getSection("TMMIN");
                //ViewData["PIC"] = R.getPIC();
                //ViewData["Division"] = R.getDivision();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Update Data
        public ActionResult Update_Data(string DATA)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string NO_ASSET = Datas[1];
                string NAMA_ASSET = Datas[2];
                string NAMA_FOTO = Datas[3];
                //string NM_FOTO = Datas[3];
                string MEREK = Datas[4];
                string TIPE = Datas[5];
                string SUPPLIER = Datas[6];
                string TAHUN = Datas[7];
                string QTY = Datas[8];
                string HARGA_SATUAN = Datas[9];
                //string TOTAL = Datas[9];
                string JENIS_ASSET = Datas[10];
                string KATEGORI_ASSET = Datas[11];
                string PIC_BELI = Datas[12];
                string DEPT_USER = Datas[13];
                string NAMA_USER = Datas[14];
                string KD_LOKASI = Datas[15];
                string HALTE = Datas[16];
                string JENIS_DOC = Datas[17];
                string NO_BC = Datas[18];
                string TGL_BC = Datas[19];
                string TGL_REGIST = Datas[20];
                string STATUS = Datas[21];
                string FLG_LABEL_ASSET = Datas[22];

                var EXEC = R.Update_Data(ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, /*SOURCE_FOTO,*/ MEREK, TIPE, SUPPLIER, TAHUN, QTY, HARGA_SATUAN, /*TOTAL,*/ JENIS_ASSET, KATEGORI_ASSET, PIC_BELI, DEPT_USER, NAMA_USER, KD_LOKASI, HALTE, JENIS_DOC, NO_BC, TGL_BC, TGL_REGIST, STATUS, FLG_LABEL_ASSET);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Asset", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R.Delete_Data(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Asset", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}