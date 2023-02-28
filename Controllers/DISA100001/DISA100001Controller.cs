﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Database;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.DISA100001Master;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Windows.Media.Imaging;
using NPOI.OpenXmlFormats.Drawing;
using NPOI.OpenXmlFormats.Spreadsheet;
using OfficeOpenXml.Drawing;
using System.Net;
using System.Net.Mime;
//using Syncfusion.XlsIO;

namespace AI070.Controllers
{
    public class DISA100001Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA100001Repository R = new DISA100001Repository();
        User U = new User();
        string username;
        String reg_no;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;
        int NOMOR_URUT;
        string sts;
        string message;

        //Identitas User
        string NIK;
        string NAMA_USER;
        string NAMA_USER_ALIAS;
        string KODE_SECTION;
        string NAMA_SECTION;
        string NAMA_SECTION_ALIAS;
        string KODE_DEPT;
        string NAMA_DEPT;
        string NAMA_DEPT_ALIAS;

        //string username2 = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

        #region Controller Utama

        #region Startup
        protected override void Startup()
        {
            try
            {
                Settings.Title = "Manajemen Asset";
                ViewData["Title"] = Settings.Title;

                GetDataHeader();

            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }
        #endregion

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);

                reg_no = Lookup.Get<Toyota.Common.Credential.User>().RegistrationNumber.ToString();
                ViewData["User"] = username;
                ViewData["RegNo"] = reg_no;

                GetIdentitasUser(username);

                if (reg_no != "PIC_ASSET")
                {
                    NAMA_DEPT_ALIAS = "";
                }

                ViewData["no_asset"] = R.getListAsset(NAMA_DEPT_ALIAS);

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion
        
        #region User Identity
        public void GetIdentitasUser(string username)
        {
            string USERNAME = username;
            try
            {
                //ViewData["NIK"] = R.getUserIdentity(USERNAME);

                List<IdentitasUser_Model> getUserIdentity = R.getUserIdentity(USERNAME);
                if (getUserIdentity.Count > 0)
                {
                    ViewData["NIK"] = getUserIdentity.FirstOrDefault().NIK.ToString();
                    ViewData["NAMA_USER"] = getUserIdentity.FirstOrDefault().NAMA_USER.ToString();
                    ViewData["NAMA_USER_ALIAS"] = getUserIdentity.FirstOrDefault().NAMA_USER_ALIAS.ToString();
                    ViewData["KODE_SECTION"] = getUserIdentity.FirstOrDefault().KODE_SECTION.ToString();
                    ViewData["NAMA_SECTION"] = getUserIdentity.FirstOrDefault().NAMA_SECTION.ToString();
                    ViewData["NAMA_SECTION_ALIAS"] = getUserIdentity.FirstOrDefault().NAMA_SECTION_ALIAS.ToString();
                    ViewData["KODE_DEPT"] = getUserIdentity.FirstOrDefault().KODE_DEPT.ToString();
                    ViewData["NAMA_DEPT"] = getUserIdentity.FirstOrDefault().NAMA_DEPT.ToString();
                    ViewData["NAMA_DEPT_ALIAS"] = getUserIdentity.FirstOrDefault().NAMA_DEPT_ALIAS.ToString();

                    NIK = ViewData["NIK"].ToString();
                    NAMA_USER = ViewData["NAMA_USER"].ToString();
                    NAMA_USER_ALIAS = ViewData["NAMA_USER_ALIAS"].ToString();
                    KODE_SECTION = ViewData["KODE_SECTION"].ToString();
                    NAMA_SECTION = ViewData["NAMA_SECTION"].ToString();
                    NAMA_SECTION_ALIAS = ViewData["NAMA_SECTION_ALIAS"].ToString();
                    KODE_DEPT = ViewData["KODE_DEPT"].ToString();
                    NAMA_DEPT = ViewData["NAMA_DEPT"].ToString();
                    NAMA_DEPT_ALIAS = ViewData["NAMA_DEPT_ALIAS"].ToString();
                }
                

            }
            catch (Exception M)
            {
                message = "Please completed identity user !";
                M.Message.ToString();
            }
        }
        #endregion

        #region 
        public ActionResult validasiOpenForm(string formMenu)
        {
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string USERNAME = username;

            string sts = null;
            string message = null;

            try
            {
                //Check User Validasi
                List<DISA10001_LIST_CHECK_USER> getValidasiForm = R.getcheck_User(USERNAME, formMenu);


                if (getValidasiForm.Count > 0)
                {
                    //View Data
                    if (getValidasiForm.FirstOrDefault().view is null || getValidasiForm.FirstOrDefault().view.ToString() == "" || 
                        getValidasiForm.FirstOrDefault().view.ToString() == "False")
                    {
                        sts= "FALSE";
                        message = "Not Success!";
                    }
                    else
                    {
                        sts = "TRUE";
                        message = "Success!";
                    }

                }
                else
                {
                    sts = "FALSE";
                    message = "Not Success!";
                }
            }
            catch (Exception M)
            {
                sts = "FALSE";
                message = M.Message.ToString();
            }

            return Json(new { sts, message}, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Data Validasi User
        public void GetDataValidasiUser(string USERNAME, string NAMA_FORM)
        {
            try
            {
                //Check User Validasi
                List<DISA10001_LIST_CHECK_USER> getValidasiUser = R.getcheck_User(USERNAME, NAMA_FORM);

                if (getValidasiUser.Count > 0)
                {
                    //Save Data
                    if (getValidasiUser.FirstOrDefault().save is null || getValidasiUser.FirstOrDefault().save.ToString() == "")
                    {
                        ViewData["save"] = "Nothing";
                    }
                    else
                    {
                        ViewData["save"] = getValidasiUser.FirstOrDefault().save.ToString();
                    }
                    
                    //Add Data
                    if (getValidasiUser.FirstOrDefault().add is null || getValidasiUser.FirstOrDefault().add.ToString() == "")
                    {
                        ViewData["add"] = "Nothing";
                    }
                    else
                    {
                        ViewData["add"] = getValidasiUser.FirstOrDefault().add.ToString();
                    }

                    //Edit Data
                    if (getValidasiUser.FirstOrDefault().edit is null || getValidasiUser.FirstOrDefault().edit.ToString() == "")
                    {
                        ViewData["edit"] = "Nothing";
                    }
                    else
                    {
                        ViewData["edit"] = getValidasiUser.FirstOrDefault().edit.ToString();
                    }
                    
                    //Edit Keterangan
                    if (getValidasiUser.FirstOrDefault().edit_keterangan is null || getValidasiUser.FirstOrDefault().edit_keterangan.ToString() == "")
                    {
                        ViewData["edit_keterangan"] = "Nothing";
                    }
                    else
                    {
                        ViewData["edit_keterangan"] = getValidasiUser.FirstOrDefault().edit_keterangan.ToString();
                    }

                    //Edit Image
                    if (getValidasiUser.FirstOrDefault().edit_image is null || getValidasiUser.FirstOrDefault().edit_image.ToString() == "")
                    {
                        ViewData["edit_image"] = "Nothing";
                    }
                    else
                    {
                        ViewData["edit_image"] = getValidasiUser.FirstOrDefault().edit_image.ToString();
                    }

                    //Delete Data
                    if (getValidasiUser.FirstOrDefault().delete is null || getValidasiUser.FirstOrDefault().delete.ToString() == "")
                    {
                        ViewData["delete"] = "Nothing";
                    }
                    else
                    {
                        ViewData["delete"] = getValidasiUser.FirstOrDefault().delete.ToString();
                    }

                    //Register Data
                    if (getValidasiUser.FirstOrDefault().register is null || getValidasiUser.FirstOrDefault().register.ToString() == "")
                    {
                        ViewData["register"] = "Nothing";
                    }
                    else
                    {
                        ViewData["register"] = getValidasiUser.FirstOrDefault().register.ToString();
                    }

                    //View Data
                    if (getValidasiUser.FirstOrDefault().view is null || getValidasiUser.FirstOrDefault().view.ToString() == "")
                    {
                        ViewData["view"] = "Nothing";
                    }
                    else
                    {
                        ViewData["view"] = getValidasiUser.FirstOrDefault().view.ToString();
                    }
                    
                    //Download Data
                    if (getValidasiUser.FirstOrDefault().download is null || getValidasiUser.FirstOrDefault().download.ToString() == "")
                    {
                        ViewData["download"] = "Nothing";
                    }
                    else
                    {
                        ViewData["download"] = getValidasiUser.FirstOrDefault().download.ToString();
                    }
                    
                    //Upload Data
                    if (getValidasiUser.FirstOrDefault().upload is null || getValidasiUser.FirstOrDefault().upload.ToString() == "")
                    {
                        ViewData["upload"] = "Nothing";
                    }
                    else
                    {
                        ViewData["upload"] = getValidasiUser.FirstOrDefault().upload.ToString();
                    }
                    
                    //Print Data
                    if (getValidasiUser.FirstOrDefault().print is null || getValidasiUser.FirstOrDefault().print.ToString() == "")
                    {
                        ViewData["print"] = "Nothing";
                    }
                    else
                    {
                        ViewData["print"] = getValidasiUser.FirstOrDefault().print.ToString();
                    }
                    
                    //Approve 1
                    if (getValidasiUser.FirstOrDefault().approve1 is null || getValidasiUser.FirstOrDefault().approve1.ToString() == "")
                    {
                        ViewData["approve1"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve1"] = getValidasiUser.FirstOrDefault().approve1.ToString();
                    }
                    
                    //Approve 2
                    if (getValidasiUser.FirstOrDefault().approve2 is null || getValidasiUser.FirstOrDefault().approve2.ToString() == "")
                    {
                        ViewData["approve2"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve2"] = getValidasiUser.FirstOrDefault().approve2.ToString();
                    }
                    
                    //Approve 3
                    if (getValidasiUser.FirstOrDefault().approve3 is null || getValidasiUser.FirstOrDefault().approve3.ToString() == "")
                    {
                        ViewData["approve3"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve3"] = getValidasiUser.FirstOrDefault().approve3.ToString();
                    }
                    
                    //Approve 4
                    if (getValidasiUser.FirstOrDefault().approve4 is null || getValidasiUser.FirstOrDefault().approve4.ToString() == "")
                    {
                        ViewData["approve4"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve4"] = getValidasiUser.FirstOrDefault().approve4.ToString();
                    }
                    
                    //Acknowledge
                    if (getValidasiUser.FirstOrDefault().acknowledge is null || getValidasiUser.FirstOrDefault().acknowledge.ToString() == "")
                    {
                        ViewData["acknowledge"] = "Nothing";
                    }
                    else
                    {
                        ViewData["acknowledge"] = getValidasiUser.FirstOrDefault().acknowledge.ToString();
                    }

                    //Enable Data
                    if (getValidasiUser.FirstOrDefault().enable is null || getValidasiUser.FirstOrDefault().enable.ToString() == "")
                    {
                        ViewData["enable"] = "Nothing";
                    }
                    else
                    {
                        ViewData["enable"] = getValidasiUser.FirstOrDefault().enable.ToString();
                    }
                    
                    //Visible Data
                    if (getValidasiUser.FirstOrDefault().visible is null || getValidasiUser.FirstOrDefault().visible.ToString() == "")
                    {
                        ViewData["visible"] = "Nothing";
                    }
                    else
                    {
                        ViewData["visible"] = getValidasiUser.FirstOrDefault().visible.ToString();
                    }
                }
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Generate Message
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

        #endregion

        #endregion //END Controller Utama

        #region Move File Foto
        public ActionResult MoveFileFoto() //Move Foto
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                var nama_file = Request.Form["Name"];
                var fitur_menu = Request.Form["Fitur"];

                if (fitur_menu == "PENGADAAN")
                {
                    resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Pengadaan_Asset/", nama_file /*+ ".PNG"*/);
                }
                else if (fitur_menu == "LAPOR")
                {
                    resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Lapor_Asset/", nama_file /*+ ".PNG"*/);
                }
                else if (fitur_menu == "DISPOSE")
                {
                    resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Dispose_Asset/", nama_file /*+ ".PNG"*/);
                }
                else if (fitur_menu == "AUDIT")
                {
                    resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Audit_Asset/", nama_file /*+ ".PNG"*/);
                }

                System.IO.File.Delete(Server.MapPath(resultFilePath));

                file.SaveAs(Server.MapPath(resultFilePath));

            }
            var MSG = "Nice";
            return Json(new { MSG });
        }
        #endregion

        #region Delete File Foto
        public ActionResult DeleteFileFoto(string NAMA_FOTO, string FITUR) //Delete Foto
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            var file = "";
            //var nama_file = NAMA_FOTO + ".PNG";
            var nama_file = NAMA_FOTO;
            var fitur_menu = FITUR;

            //Get ID Image
            string IMAGE_NAME = "";
            if (NAMA_FOTO == "" || NAMA_FOTO is null)
            {
                IMAGE_NAME = "Nothing";
            }
            else
            {
                IMAGE_NAME = R.getImageName(NAMA_FOTO, FITUR);

            }

            //var file = Request.Files[i];
            //var filename = Path.GetExtension(file.FileName);

            //var file = Request.Form["ImagePath"];
            //var nama_file = Request.Form["Name"];
            //var fitur_menu = Request.Form["Fitur"];

            if (IMAGE_NAME != "Nothing")
            {
                try
                {
                    if (fitur_menu == "PENGADAAN")
                    {
                        resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Pengadaan_Asset/", IMAGE_NAME /*+ ".PNG"*/);
                    }
                    else if (fitur_menu == "LAPOR")
                    {
                        resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Lapor_Asset/", IMAGE_NAME /*+ ".PNG"*/);
                    }
                    else if (fitur_menu == "DISPOSE")
                    {
                        //resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Dispose_Asset/", nama_file /*+ ".PNG"*/);
                        resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Dispose_Asset/", IMAGE_NAME);
                    }
                    else if (fitur_menu == "AUDIT")
                    {
                        resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Audit_Asset/", IMAGE_NAME /*+ ".PNG"*/);
                    }

                    //file.SaveAs(Server.MapPath(resultFilePath));
                    System.IO.File.Delete(Server.MapPath(resultFilePath));
                }
                catch (Exception ex)
                {

                }
            }

            var MSG = "Nice";
            return Json(new { MSG });
        }
        #endregion

        #region Get Information Data Asset 
        public ActionResult get_Data_Asset(string NO_ASSET)
        {
            var data = R.get_Data_Asset(NO_ASSET);
            return Json(new { data, NO_ASSET }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region PENGADAAN ASSET
        #region Hyperlink Page Data Asset
        public ActionResult PENGADAAN_ASSET()
        {
            GetDataHeader();
            Settings.Title = "PENGADAAN ASSET";
            ViewData["Title1"] = Settings.Title;

            return View("Pengadaan_Asset/Home_Pengadaan_Asset");
        }
        #endregion
        #endregion


        //-----------------------------------------------------------PAGE REGISTER ASSET (Tidak Digunakan)---------------------------------------
        #region Page Register Asset
        #region Hyperlink Page Register Asset
        public ActionResult REG_ASSET()
        {
            GetDataHeader();
            Settings.Title = "Register Data Asset";
            ViewData["Title1"] = Settings.Title;
            return View("Register_Asset/Data_Register_Asset");
        }
        #endregion
        #endregion



        //-----------------------------------------------------------PAGE REQUEST ASSET----------------------------------------------------------
        #region Page Request Asset
        #region Hyperlink Page Request Asset
        public ActionResult REQ_ASSET()
        {
            Settings.Title = "List Request Data Asset";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            ViewData["nama_lokasi"] = R.getLokasi();


            return View("Request_Asset/Data_Request_Asset");
        }
        #endregion

        #region Search Data Request Asset
        public ActionResult Search_Data_Request_Asset(int start, int display, string DATA_ID, string NO_REQUEST_ASSET, string NAMA_ASSET, string PIC_REQUEST, string DEPT_REQUEST, string ID_PR, string TGL_REQUEST, string TGL_PR, string STATUS_REQUEST)
        {
            //Buat Paging//
            PagingModel_DISA100001 pg = new PagingModel_DISA100001(R.getCount_Request_Asset(DATA_ID, NO_REQUEST_ASSET, NAMA_ASSET, PIC_REQUEST, DEPT_REQUEST, ID_PR, TGL_REQUEST, TGL_PR, STATUS_REQUEST), start, display);

            //Munculin Data ke Grid//
            List<DISA10001_REQUEST_ASSET> List = R.getData_Request_Asset(pg.StartData, pg.EndData, NO_REQUEST_ASSET, NAMA_ASSET, PIC_REQUEST, DEPT_REQUEST, ID_PR, TGL_REQUEST, TGL_PR, STATUS_REQUEST).ToList();
            ViewData["Data_Request_Asset"] = List;

            ViewData["PagingDISA100001"] = pg;
            return PartialView("Request_Asset/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Tambah Data Request_Asset (Single Insert Data)
        //public ActionResult ADD_NEW_REQUEST_ASSET(
        ////string DATA_ID,
        //string NAMA_ASSET,
        //string QTY,
        //string PIC_REQUEST,
        //string DEPARTMENT,
        //string TGL_REQUEST
        //)
        //{
        //    string sts = null;
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    //string pass = EncryptPassword(PASSWORD);

        //    //Cek no_urut
        //    string NOMOR_URUT_REQUEST = R.getNo_Urutan_Request();

        //    try
        //    {
        //        string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
        //        var Exec = DISA100001Repository.Create_New_Request_Asset(/*DATA_ID,*/ NOMOR_URUT_REQUEST, NAMA_ASSET, QTY, PIC_REQUEST, DEPARTMENT, TGL_REQUEST);
        //        sts = Exec[0].STACK;

        //        if (Exec[0].LINE_STS == "DUPLICATE")
        //        {
        //            var res = M.get_default_message("MWP004", "New Request Asset", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else if (Exec[0].STACK == "TRUE")
        //        {
        //            var res = M.get_default_message("MWP001", "New Reqeust Asset", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else
        //        {
        //            message = Exec[0].LINE_STS;
        //        }
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        #region Tambah Data Request Asset (Multiple Insert Data)
        public ActionResult Insert_Data_Detail_Request()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Cek no_urut
            string NOMOR_URUT_REQUEST = R.getNo_Urutan_Request();

            //Tanggal
            DateTime CREATED_DATE = DateTime.Now;

            //Status Request
            string STATUS_REQUEST = "ON PROGRESS CREATE PR";

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var items = JsonConvert.DeserializeObject<DISA10001_REQUEST_ASSET_INPUT_FORM>(json);
                var Exec = DISA100001Repository.Create_Detail_Request(items, NOMOR_URUT_REQUEST, username, CREATED_DATE, STATUS_REQUEST);
                sts = "TRUE";
                message = "Data berhasil disimpan!";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Delete Data Request Asset
        public ActionResult Delete_Data_Request_Asset(string DATA)
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
                        string DELETE = R.Delete_Data_Request_Asset(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Request Asset", "", "");
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

        #region Cancel Data Request Asset
        public ActionResult Cancel_Data_Request_Asset(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            string date_now = DateTime.Now.ToString();

            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string STATUS = "CANCEL by " + username + " " + date_now;
                        string DELETE = R.Cancel_Data_Request_Asset(Datas[i], STATUS);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Request Asset", "", "");
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

        #region Update Data Request Asset
        public ActionResult Update_Data_Request_Asset(string DATA)
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
                string NO_REQUEST_ASSET = Datas[1];
                string TGL_REQUEST_ASSET = Datas[2];
                string NAMA_ASSET = Datas[3];
                //string QTY_ASSET = Datas[4];
                string PIC_REQUEST = Datas[4];
                string DEPT_REQUEST = Datas[5];

                var EXEC = R.Update_Data_Request_Asset(ID, NO_REQUEST_ASSET, TGL_REQUEST_ASSET, NAMA_ASSET, /*QTY_ASSET,*/ PIC_REQUEST, DEPT_REQUEST);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Request Asset", "", "");
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

        #region Add New Data Asset (REGISTER ASSET)
        public ActionResult ADD_NEW_ASSET(
            string DATA_ID,
            string ID,
            string NO_REQUEST,
            string ID_PR,
            string NAMA_ASSET,
            string NAMA_ASSET_INVOICE,
            string ITEM_CODE,
            string MEREK,
            string TIPE,
            string JENIS_DOKUMEN,
            string NO_AJU,
            string TGL_DOKUMEN,
            DateTime TGL_REGISTER,
            string TAHUN,
            string UMUR,
            string SUPPLIER,
            string KETERANGAN,
            string SPESIFIKASI,
            string HARGA_SATUAN,
            string JENIS_ASSET,
            string KATEGORI_ASSET,
            string PIC_REQUEST,
            string DEPT_REQUEST,
            string FOTO_NAME,
            string NAMA_USER,
            string DEPT_USER,
            string STATUS_KONDISI,
            string KD_LOKASI,
            string HALTE,
            string STATUS
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Ubah Harga Satuan
            string harga = HARGA_SATUAN.Substring(3);
            char[] charsToTrim = { '*', '.', ',', ' ' };
            string cleanString = harga.Trim(charsToTrim);
            string harga_replace = cleanString.Replace(",", "");
            HARGA_SATUAN = harga_replace.Trim();

            //Tanggal
            DateTime TGL_REQUEST = DateTime.Now;
            string BULAN = TGL_REGISTER.ToString("MM");

            //Flag Register Asset
            string FLG_REGISTER_ASSET = "1";

            //User Login
            string USERNAME = username;

            //Create No_Asset
            string NOMOR_URUT_REGISTER = R.getUrutan_No_Asset();
            string NO_ASSET = TAHUN + "." + BULAN + "." + JENIS_ASSET + "." + KATEGORI_ASSET + "." + NOMOR_URUT_REGISTER;


            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100001Repository.Create(DATA_ID, ID, NO_REQUEST, ID_PR, NAMA_ASSET, NAMA_ASSET_INVOICE, ITEM_CODE, MEREK, TIPE, JENIS_DOKUMEN, NO_AJU, TGL_DOKUMEN, TGL_REGISTER.ToString(), TAHUN, UMUR, BULAN, SUPPLIER, KETERANGAN, SPESIFIKASI, HARGA_SATUAN, JENIS_ASSET, KATEGORI_ASSET, PIC_REQUEST, DEPT_REQUEST, FOTO_NAME, NAMA_USER, DEPT_USER, STATUS_KONDISI, KD_LOKASI, HALTE, STATUS, FLG_REGISTER_ASSET, USERNAME, TGL_REQUEST, NO_ASSET, NOMOR_URUT_REGISTER);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "REGISTER ASSET", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "REGISTER", "", "");
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

        #region Detail Request Data Asset
        //public virtual ActionResult Detail_Request_Asset(string ID, string NO_REQUEST_ASSET, string ID_PR)
        //{
        //    List<Request_Detail_Asset> GetData_Request_Detail = R.GetDataReqAsset_Detail(ID, NO_REQUEST_ASSET, ID_PR).ToList();
        //    ViewData["Title"] = "Detail Request Asset";
        //    ViewData["Data_Request_Detail_Asset"] = GetData_Request_Detail;

        //    if (GetData_Request_Detail.Count == 0)
        //    {
        //        ViewData["No_Request"] = GetData_Request_Detail.FirstOrDefault().NO_REQUEST_ASSET.ToString();
        //        ViewData["Nama_Asset"] = GetData_Request_Detail.FirstOrDefault().NAMA_ASSET.ToString();
        //        ViewData["Keterangan"] = GetData_Request_Detail.FirstOrDefault().KETERANGAN.ToString();
        //        ViewData["Tgl_Request"] = GetData_Request_Detail.FirstOrDefault().TGL_REQUEST.ToString();
        //        ViewData["Request_By"] = GetData_Request_Detail.FirstOrDefault().PIC_REQUEST.ToString();
        //        ViewData["Dept"] = GetData_Request_Detail.FirstOrDefault().DEPT_REQUEST.ToString();

        //        if (GetData_Request_Detail.FirstOrDefault().ID_PR.ToString() == null || GetData_Request_Detail.FirstOrDefault().ID_PR.ToString() == "")
        //        {
        //            ViewData["No_PR"] = "<belum buat PR>";
        //        }
        //        else
        //        {
        //            ViewData["No_PR"] = GetData_Request_Detail.FirstOrDefault().ID_PR.ToString();
        //        }
        //        if (GetData_Request_Detail.FirstOrDefault().TUJUAN.ToString() == null || GetData_Request_Detail.FirstOrDefault().TUJUAN.ToString() == "")
        //        {
        //            ViewData["Tujuan"] = "<belum buat PR>";
        //        }
        //        else
        //        {
        //            ViewData["Tujuan"] = GetData_Request_Detail.FirstOrDefault().TUJUAN.ToString();
        //        }
        //        if (GetData_Request_Detail.FirstOrDefault().EFFECT.ToString() == null || GetData_Request_Detail.FirstOrDefault().EFFECT.ToString() == "")
        //        {
        //            ViewData["Effect"] = "<belum buat PR>";
        //        }
        //        else
        //        {
        //            ViewData["Effect"] = GetData_Request_Detail.FirstOrDefault().EFFECT.ToString();
        //        }
        //    }
        //    else
        //    {
        //        ViewData["No_Request"] = GetData_Request_Detail.FirstOrDefault().NO_REQUEST_ASSET.ToString();
        //        ViewData["Nama_Asset"] = GetData_Request_Detail.FirstOrDefault().NAMA_ASSET.ToString();
        //        ViewData["Keterangan"] = GetData_Request_Detail.FirstOrDefault().KETERANGAN.ToString();
        //        ViewData["Tgl_Request"] = GetData_Request_Detail.FirstOrDefault().TGL_REQUEST.ToString();
        //        ViewData["Request_By"] = GetData_Request_Detail.FirstOrDefault().PIC_REQUEST.ToString();
        //        ViewData["Dept"] = GetData_Request_Detail.FirstOrDefault().DEPT_REQUEST.ToString();

        //        if (GetData_Request_Detail.FirstOrDefault().ID_PR.ToString() == null || GetData_Request_Detail.FirstOrDefault().ID_PR.ToString() == "")
        //        {
        //            ViewData["No_PR"] = "<belum buat PR>";
        //        }
        //        else
        //        {
        //            ViewData["No_PR"] = GetData_Request_Detail.FirstOrDefault().ID_PR.ToString();
        //        }
        //        if (GetData_Request_Detail.FirstOrDefault().TUJUAN.ToString() == null || GetData_Request_Detail.FirstOrDefault().TUJUAN.ToString() == "")
        //        {
        //            ViewData["Tujuan"] = "<belum buat PR>";
        //        }
        //        else
        //        {
        //            ViewData["Tujuan"] = GetData_Request_Detail.FirstOrDefault().TUJUAN.ToString();
        //        }
        //        if (GetData_Request_Detail.FirstOrDefault().EFFECT.ToString() == null || GetData_Request_Detail.FirstOrDefault().EFFECT.ToString() == "")
        //        {
        //            ViewData["Effect"] = "<belum buat PR>";
        //        }
        //        else
        //        {
        //            ViewData["Effect"] = GetData_Request_Detail.FirstOrDefault().EFFECT.ToString();
        //        }
        //    }


        //    return PartialView("Request_Asset/Datagrid_Data_Detail");
        //}
        #endregion

        #region Autocomplete Item Code
        //[HttpPost]
        //public JsonResult getItemCode(string ITEM_CODE)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var item_code = db.Fetch<DISA10001_REQUEST_ASSET>("DISA100001/Request_Asset/DISA100001_getItemCode", new
        //    {
        //        ITEM_CODE
        //    }).ToList();

        //    return Json(item_code);
        //}
        #endregion

        #region Download Excel List Asset
        [HttpGet]
        public virtual ActionResult DownloadExcel_Request_Asset(string NO_REQUEST_ASSET, string NAMA_ASSET, string PIC_REQUEST, string DEPT_REQUEST, string ID_PR)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Data_Request_Asset_Template.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DISA10001_REQUEST_ASSET_DOWNLOAD> dataRequestAsset = R.DownloadExcel_Request_Asset(1, 10000000, NO_REQUEST_ASSET, NAMA_ASSET, PIC_REQUEST, DEPT_REQUEST, ID_PR).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B6"].LoadFromCollection(dataRequestAsset);
                worksheet.Cells["B6:J" + (dataRequestAsset.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:J" + (dataRequestAsset.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:J" + (dataRequestAsset.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:J" + (dataRequestAsset.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data Request Asset_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion
        #endregion

        //-----------------------------------------------------------PAGE INVENTARISASI ASSET----------------------------------------------------
        #region Page Inventarisasi Asset

        #region Hyperlink Page Data Asset
        public ActionResult DATA_ASSET()
        {
            GetDataHeader();
            Settings.Title = "List Data Asset";
            ViewData["Title1"] = Settings.Title;

            GetDataValidasiUser(username, Settings.Title);

            ViewData["nama_lokasi"] = R.getLokasi();

            return View("Master_Asset/Data_Asset");
        }
        #endregion


        #region Search Data Asset
        public ActionResult Search_Data_Asset(
            int start, int display, string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET, string DEPARTMENT, string ITEM_CODE,
            string STATUS_KONDISI)
        {
            //Buat Paging//
            PagingModel_DISA100001 pg = new PagingModel_DISA100001(R.getCountDISA100001(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI), start, display);

            //Munculin Data ke Grid//
            List<DISA100001Master> List = R.getDataAsset(pg.StartData, pg.EndData, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["DataDISA100001"] = List;

            //-------------------------------------- All Data View ------------------------------
            //Qty & Amount Total
            var JENIS_ASSET = "";

            List<DISA100001Master> QtyAmountTotal = R.Qty_Amount_Asset(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_Total"] = QtyAmountTotal.FirstOrDefault().QTY.ToString();

            if (QtyAmountTotal.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_Total"] = 0;
            }
            else
            {
                ViewData["Amount_Total"] = QtyAmountTotal.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Fixed Asset (FA)
            JENIS_ASSET = "FA";
            List<DISA100001Master> QtyAmountFA = R.Qty_Amount_Asset(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_FA"] = QtyAmountFA.FirstOrDefault().QTY.ToString();

            if (QtyAmountFA.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_FA"] = 0;
            }
            else
            {
                ViewData["Amount_FA"] = QtyAmountFA.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Small Asset (SA)
            JENIS_ASSET = "SA";
            List<DISA100001Master> QtyAmountSA = R.Qty_Amount_Asset(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_SA"] = QtyAmountSA.FirstOrDefault().QTY.ToString();

            if (QtyAmountSA.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_SA"] = 0;
            }
            else
            {
                ViewData["Amount_SA"] = QtyAmountSA.FirstOrDefault().AMOUNT.ToString();
            }

            //------------------------ Good Condition (OK) Qty & Amount ----------------------
            STATUS_KONDISI = "OK";
            JENIS_ASSET = "";

            // Qty & Amount Total
            List<DISA100001Master> QtyAmountTotal_OK = R.Qty_Amount_Asset_OK(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_Total_OK"] = QtyAmountTotal_OK.FirstOrDefault().QTY.ToString();

            if (QtyAmountTotal_OK.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_Total_OK"] = 0;
            }
            else
            {
                ViewData["Amount_Total_OK"] = QtyAmountTotal_OK.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Fixed Asset (FA)
            JENIS_ASSET = "FA";

            List<DISA100001Master> QtyAmountFA_OK = R.Qty_Amount_Asset_OK(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_FA_OK"] = QtyAmountFA_OK.FirstOrDefault().QTY.ToString();

            if (QtyAmountFA_OK.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_FA_OK"] = 0;
            }
            else
            {
                ViewData["Amount_FA_OK"] = QtyAmountFA_OK.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Small Asset (SA)
            JENIS_ASSET = "SA";
            List<DISA100001Master> QtyAmountSA_OK = R.Qty_Amount_Asset_OK(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_SA_OK"] = QtyAmountSA_OK.FirstOrDefault().QTY.ToString();

            if (QtyAmountSA_OK.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_SA_OK"] = 0;
            }
            else
            {
                ViewData["Amount_SA_OK"] = QtyAmountSA_OK.FirstOrDefault().AMOUNT.ToString();
            }

            //------------------------ Not Good Condition (NG) Qty & Amount ----------------------
            STATUS_KONDISI = "NG";
            JENIS_ASSET = "";

            // Qty & Amount Total
            List<DISA100001Master> QtyAmountTotal_NG = R.Qty_Amount_Asset_NG(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_Total_NG"] = QtyAmountTotal_NG.FirstOrDefault().QTY.ToString();

            if (QtyAmountTotal_NG.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_Total_NG"] = 0;
            }
            else
            {
                ViewData["Amount_Total_NG"] = QtyAmountTotal_NG.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Fixed Asset (FA)
            JENIS_ASSET = "FA";

            List<DISA100001Master> QtyAmountFA_NG = R.Qty_Amount_Asset_NG(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_FA_NG"] = QtyAmountFA_NG.FirstOrDefault().QTY.ToString();

            if (QtyAmountFA_NG.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_FA_NG"] = 0;
            }
            else
            {
                ViewData["Amount_FA_NG"] = QtyAmountFA_NG.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Small Asset (SA)
            JENIS_ASSET = "SA";
            List<DISA100001Master> QtyAmountSA_NG = R.Qty_Amount_Asset_NG(DATA_ID, NO_ASSET, NAMA_ASSET, NAMA_FOTO, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, JENIS_ASSET, DEPARTMENT, ITEM_CODE, STATUS_KONDISI).ToList();
            ViewData["Qty_SA_NG"] = QtyAmountSA_NG.FirstOrDefault().QTY.ToString();

            if (QtyAmountSA_NG.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_SA_NG"] = 0;
            }
            else
            {
                ViewData["Amount_SA_NG"] = QtyAmountSA_NG.FirstOrDefault().AMOUNT.ToString();
            }


            ViewData["PagingDISA100001"] = pg;
            return PartialView("Master_Asset/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Detail Data Asset
        //public virtual ActionResult GetDataDetail(string NO_ASSET)
        //{
        //    List<DISA100001DetailAsset> GetDataAsset_Detail = R.GetDataAsset_Detail_ByNoAsset(NO_ASSET).ToList();
        //        ViewData["Title"] = " Detail Asset";
        //        ViewData["NO_ASSET"] = " No. Asset : " + GetDataAsset_Detail.FirstOrDefault().NO_ASSET.ToString();
        //        ViewData["NAMA_ASSET"] = " Nama Asset : " + GetDataAsset_Detail.FirstOrDefault().NAMA_ASSET.ToString();
        //        ViewData["DataDetail_Asset"] = GetDataAsset_Detail;
        //    return PartialView("Datagrid_Data_Detail");
        //}
        public virtual ActionResult GetDataDetail(string ID)
        {
            List<DISA100001DetailAsset> GetDataAsset_Detail = R.GetDataAsset_Detail_ByNoAsset(ID).ToList();
            ViewData["Title"] = "Detail Asset";
            if (GetDataAsset_Detail.FirstOrDefault().NAMA_FOTO.ToString() == null || GetDataAsset_Detail.FirstOrDefault().NAMA_FOTO.ToString() == "")
            {
                ViewData["NAMA_FOTO"] = "belum ada gambar";
            }
            else
            {
                ViewData["NAMA_FOTO"] = GetDataAsset_Detail.FirstOrDefault().NAMA_FOTO.ToString();
            }
            ViewData["DataDetail_Asset"] = GetDataAsset_Detail;
            return PartialView("Master_Asset/Datagrid_Data_Detail");
        }
        #endregion

        #region History Data Asset
        public virtual ActionResult GetDataHistory(string ID)
        {
            try
            {
                List<History_Data_Asset> GetDataHistory_Detail = R.GetDataHistory(ID).ToList();
                ViewData["Title"] = "History Asset";

                if (GetDataHistory_Detail.Count > 0)
                {
                    ViewData["DataHistory_Asset"] = GetDataHistory_Detail;
                    ViewData["NO_ASSET"] = GetDataHistory_Detail.FirstOrDefault().NO_ASSET.ToString();
                    ViewData["NAMA_ASSET"] = GetDataHistory_Detail.FirstOrDefault().NAMA_ASSET.ToString();

                    if (GetDataHistory_Detail.FirstOrDefault().ID_PR.ToString() == null || GetDataHistory_Detail.FirstOrDefault().ID_PR.ToString() == "")
                    {
                        ViewData["ID_PR"] = "-";
                    }
                    else
                    {
                        ViewData["ID_PR"] = GetDataHistory_Detail.FirstOrDefault().ID_PR.ToString();
                    }

                    sts = "TRUE";
                    message = "Success";
                }
                else
                {
                    sts = "FALSE";
                    message = "Data History Not Found!";
                }

            }
            catch (InvalidDataException)
            {

            }

            //var page_control = "";
            //if (sts == "TRUE")
            //{
            //    page_control = PartialView("Master_Asset/Datagrid_Data_History").ToString();
            //}
            //else if (sts == "FALSE")
            //{
            //    page_control = Json(new { sts, message }, JsonRequestBehavior.AllowGet).ToString();
            //}

            return PartialView("Master_Asset/Datagrid_Data_History");
        }
        #endregion

        #region Update Image Asset
        public ActionResult UPDATE_IMAGE_ASSET(
            string DATA_ID,
            string ID,
            string FOTO_NAME
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Tanggal
            DateTime DATE_UPDATED = DateTime.Now;

            //User Login
            string USERNAME = username;

            //Keterangan
            string KETERANGAN = "Perubahan pada gambar asset";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var EXEC = DISA100001Repository.Update_Img(DATA_ID, ID, FOTO_NAME, KETERANGAN, USERNAME, DATE_UPDATED);
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

        #region Update Data Asset
        public ActionResult Update_Data_Asset(string DATA)
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
                string ID_TB_M_REQ_ASSET = Datas[1];
                string NO_ASSET = Datas[2];
                string NAMA_ASSET = Datas[3];
                string NAMA_ASSET_INVOICE = Datas[4];
                string ITEM_CODE_NEW = Datas[5];
                //string NAMA_FOTO = Datas[6];
                //string NM_FOTO = Datas[3];
                string MEREK = Datas[6];
                string TIPE = Datas[7];
                string SUPPLIER = Datas[8];
                //string QTY = Datas[7];
                string HARGA_SATUAN = Datas[9];
                string COST_UPGRADE = Datas[10];
                string NOTE_KETERANGAN = Datas[11];
                string SPESIFIKASI = Datas[12];
                string UMUR_EKONOMIS = Datas[13];
                //string TOTAL = Datas[9];
                //string JENIS_ASSET = Datas[10];
                //string KATEGORI_ASSET = Datas[11];
                //string PIC_BELI = Datas[9];
                string DEPT_USER = Datas[14];
                string NAMA_USER = Datas[15];
                string KD_LOKASI = Datas[16];
                string HALTE = Datas[17];
                //string JENIS_DOC = Datas[14];
                //string NO_BC = Datas[15];
                //string TGL_BC = Datas[16];
                //string TGL_REGIST = Datas[17];
                string STATUS_KONDISI = Datas[18];
                string STATUS_PENGADAAN = Datas[19];
                string STATUS_PENGGUNAAN = Datas[20];
                string FLG_LABEL_ASSET = Datas[21];
                string KETERANGAN = Datas[22];
                //string FLG_DISPOSE_ASSET = Datas[20];
                //string TGL_DISPOSE = Datas[21];

                //Ubah Harga Satuan
                string harga = "";
                string cleanString = "";
                string harga_replace = "";
                char[] charsToTrim = { '*', '.', ',', ' ' };
                if (HARGA_SATUAN != "0" && COST_UPGRADE.Contains("IDR"))
                {
                    harga = HARGA_SATUAN.Substring(3);
                    cleanString = harga.Trim(charsToTrim);
                    harga_replace = cleanString.Replace(",", "");
                    HARGA_SATUAN = harga_replace.Trim();
                }

                //Ubah Cost Upgrade
                string cost = "";
                string cost_replace = "";
                if (COST_UPGRADE != "0" && COST_UPGRADE.Contains("IDR"))
                {
                    cost = COST_UPGRADE.Substring(3);
                    cleanString = cost.Trim(charsToTrim);
                    cost_replace = cleanString.Replace(",", "");
                    COST_UPGRADE = cost_replace.Trim();
                }


                //Get Date Updated
                DateTime DATE_UPDATED = DateTime.Now;

                //var EXEC = R.Update_Data(ID, ID_TB_M_REQ_ASSET, NO_ASSET, NAMA_ASSET, NAMA_ASSET_INVOICE, ITEM_CODE_NEW, NAMA_FOTO, MEREK, TIPE, SUPPLIER, HARGA_SATUAN, DEPT_USER, NAMA_USER, KD_LOKASI, HALTE, STATUS_KONDISI, STATUS_PENGADAAN, STATUS_PENGGUNAAN, FLG_LABEL_ASSET, username, DATE_UPDATED);

                var EXEC = R.Update_Data(ID, ID_TB_M_REQ_ASSET, NO_ASSET, NAMA_ASSET, NAMA_ASSET_INVOICE, ITEM_CODE_NEW, MEREK, TIPE, SUPPLIER, HARGA_SATUAN, COST_UPGRADE, NOTE_KETERANGAN, SPESIFIKASI, UMUR_EKONOMIS, DEPT_USER, NAMA_USER, KD_LOKASI, HALTE, STATUS_KONDISI, STATUS_PENGADAAN, STATUS_PENGGUNAAN, FLG_LABEL_ASSET, username, DATE_UPDATED, KETERANGAN);
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

        #region Delete Data Asset
        public ActionResult Delete_Data_Asset(string DATA)
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

        #region Download Excel List Asset
        [HttpGet]
        public virtual ActionResult DownloadExcel_ListAsset(string NO_ASSET, string NAMA_ASSET, string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET,
            string DEPARTMENT_USER, string ITEM_CODE, string STATUS_KONDISI)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Data_List_Asset_Template.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DISA10001_LIST_ASSET_DOWNLOAD> dataListAsset = R.DownloadExcel_Asset(1, 10000000, NO_ASSET, NAMA_ASSET, MEREK, SUPPLIER, FLG_DISPOSE_ASSET, DEPARTMENT_USER, ITEM_CODE, STATUS_KONDISI).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B6"].LoadFromCollection(dataListAsset);
                worksheet.Cells["B6:AG" + (dataListAsset.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:AG" + (dataListAsset.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:AG" + (dataListAsset.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:AG" + (dataListAsset.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data List Asset_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #endregion //END DATA ASSET Controller

        //-----------------------------------------------------------PAGE LAPOR ASSET------------------------------------------------------------
        #region Page Lapor Asset
        #region Hyperlink Page Lapor Asset
        public ActionResult LAPOR_ASSET()
        {
            GetDataHeader();
            ViewData["nama_lokasi"] = R.getLokasi();
            //ViewData["no_asset"] = R.getListAsset();

            Settings.Title = "List Lapor Data Asset";
            ViewData["Title1"] = Settings.Title;

            GetDataValidasiUser(username, Settings.Title);

            return View("Lapor_Asset/Data_Lapor_Asset");
        }
        #endregion

        #region Move File Foto Lapor
        //public ActionResult MoveFileLaporAsset()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        //{
        //    var f = Request.Files;
        //    var saveFile = "";
        //    var resultFilePath = "";
        //    for (int i = 0; i < Request.Files.Count; i++)
        //    {
        //        var file = Request.Files[i];
        //        var filename = Path.GetExtension(file.FileName);
        //        var nama_file = Request.Form["Name"];
        //        //saveFile = Path.Combine(Server.MapPath("../~/Content/Upload"), filename);
        //        //resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset", nama_file);
        //        resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Lapor_Asset/", nama_file /*+ ".PNG"*/);
        //        file.SaveAs(Server.MapPath(resultFilePath));
        //    }
        //    var MSG = "Nice";
        //    return Json(new { MSG });
        //}
        #endregion

        #region Search Data Lapor Asset
        public ActionResult Search_Data_Lapor(int start, int display, string DATA_ID, string NO_LAPOR, string NO_ASSET, string KONDISI_ASSET,
            string NAMA_USER, string DEPARTMENT_USER)
        {
            //Buat Paging//
            PagingModel_DISA100001 pg = new PagingModel_DISA100001(R.getCount_LaporAsset(DATA_ID, NO_LAPOR, NO_ASSET, KONDISI_ASSET, NAMA_USER, DEPARTMENT_USER), start, display);

            //Munculin Data ke Grid//
            List<DISA10001_LAPOR_ASSET> List = R.getDataLaporAsset(pg.StartData, pg.EndData, NO_LAPOR, NO_ASSET, KONDISI_ASSET, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["DataDISA100001"] = List;

            ViewData["PagingDISA100001"] = pg;
            return PartialView("Lapor_Asset/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Tambah Data Lapor Asset
        public ActionResult TAMBAH_DATA_LAPOR(
            string DATA_ID,
            string NO_ASSET,
            string FOTO_NAME,
            string STATUS_KONDISI,
            string HARGA,
            string COST_UPGRADE,
            string SPESIFIKASI,
            string LOKASI,
            string SUB_LOKASI,
            string HALTE,
            string NAMA_USER,
            string DEPT_USER,
            string KETERANGAN,
            string TGL_LAPOR_2
            )
        {
            string sts = null;
            string message = null;
            string CEK_NOASSET = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Ubah Harga Satuan
            //string harga = HARGA_SATUAN.Substring(3);
            //char[] charsToTrim = { '*', '.', ',', ' ' };
            //string cleanString = harga.Trim(charsToTrim);
            //string harga_replace = cleanString.Replace(",", "");
            //HARGA_SATUAN = harga_replace.Trim();

            //Tanggal Lapor
            DateTime TGL_LAPOR = DateTime.Now;

            //User Login
            string USERNAME = username;
            DateTime CREATED_DATE = DateTime.Now;

            //Create No_Lapor
            string NO_LAPOR = R.getUrutanLapor();

            //Nama Foto
            FOTO_NAME = NO_LAPOR + FOTO_NAME;

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100001Repository.Tambah_Lapor(DATA_ID, NO_LAPOR, NO_ASSET, FOTO_NAME, STATUS_KONDISI, HARGA, COST_UPGRADE, SPESIFIKASI, LOKASI, SUB_LOKASI, HALTE, NAMA_USER, DEPT_USER, KETERANGAN, TGL_LAPOR, USERNAME, CREATED_DATE);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "LAPOR ASSET", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "LAPOR ASSET", "", "");
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
            return Json(new { sts, message, NO_LAPOR }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data Lapor Asset
        public ActionResult Update_Data_Lapor_Asset(string DATA)
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
                string NO_LAPOR = Datas[1];
                string NO_ASSET = Datas[2];
                string KETERANGAN = Datas[3];
                string STATUS_KONDISI = Datas[4];
                string PIC_LAPOR = Datas[5];
                string KD_LOKASI_BARU = Datas[6];
                string SUB_LOKASI_BARU = Datas[7];
                string NAMA_USER_BARU = Datas[8];
                string DEPT_USER_BARU = Datas[9];
                string HALTE_BARU = Datas[10];
                string HARGA_BARU = Datas[11];
                string COST_UPGRADE_BARU = Datas[12];
                string SPESIFIKASI_BARU = Datas[13];

                //User Login
                string USERNAME = username;
                DateTime UPDATED_DATE = DateTime.Now;

                var EXEC = R.Update_Data_Lapor_Asset(ID, NO_LAPOR, NO_ASSET, KETERANGAN, STATUS_KONDISI, PIC_LAPOR, KD_LOKASI_BARU, SUB_LOKASI_BARU, NAMA_USER_BARU, DEPT_USER_BARU, HALTE_BARU, HARGA_BARU, COST_UPGRADE_BARU, SPESIFIKASI_BARU, USERNAME, UPDATED_DATE);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Request Asset", "", "");
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


        #region Update Image Lapor Asset
        public ActionResult UPDATE_IMAGE_LAPOR_ASSET(
            string DATA_ID,
            string ID,
            string NO_ASSET,
            string FOTO_NAME
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Tanggal
            DateTime DATE_UPDATED = DateTime.Now;

            //User Login
            string USERNAME = username;

            //Keterangan
            string KETERANGAN = "Perubahan pada gambar asset";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var EXEC = DISA100001Repository.Update_Img_Lapor_Asset(DATA_ID, ID, NO_ASSET, FOTO_NAME, KETERANGAN, USERNAME, DATE_UPDATED);
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

        #region Approve Lapor Asset
        public ActionResult APPROVE_DATA_LAPOR(
            string DATA_ID,
            string ID,
            string ID_TB_M_LAPOR,
            string NO_ASSET,
            string STATUS_KONDISI
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Tanggal
            DateTime DATE_APPROVAL = DateTime.Now;

            //User Login
            string USERNAME = username;

            //Keterangan
            //string KETERANGAN = "Approval Lapor Asset by " + USERNAME;
            string KETERANGAN = "No Lapor: '" + ID + "', Has Been Approved By " + USERNAME;

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var EXEC = DISA100001Repository.approveLapor(DATA_ID, ID, ID_TB_M_LAPOR, NO_ASSET, STATUS_KONDISI, KETERANGAN, USERNAME, DATE_APPROVAL);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Lapor Asset", "", "");
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

        #region Reject Lapor Asset
        public ActionResult REJECT_DATA_LAPOR(
            string DATA_ID,
            string ID,
            string ID_TB_M_LAPOR,
            string NO_ASSET,
            string STATUS_KONDISI
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Tanggal
            DateTime DATE_REJECT = DateTime.Now;

            //User Login
            string USERNAME = username;

            //Keterangan
            //string KETERANGAN = "Approval Lapor Asset by " + USERNAME;
            string KETERANGAN = "No Lapor: '" + ID + "', Has Been Rejected By " + USERNAME;

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var EXEC = DISA100001Repository.rejectLapor(DATA_ID, ID, ID_TB_M_LAPOR, NO_ASSET, STATUS_KONDISI, KETERANGAN, USERNAME, DATE_REJECT);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Lapor Asset", "", "");
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

        #region Delete Lapor Asset
        public ActionResult Delete_Lapor_Asset(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Get User
            string USERNAME = username;

            //Fitur
            string FITUR = "LAPOR";

            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        //string STATUS = Datas[1];
                        //string DELETE = R.Delete_Lapor_Asset(Datas[i], STATUS);
                        var DELETE_IMAGE = DeleteFileFoto(Datas[i], FITUR);
                        string DELETE = R.Delete_Lapor_Asset(Datas[i], USERNAME);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Lapor Asset", "", "");
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

        #region Download Excel Lapor Asset
        [HttpGet]
        public virtual ActionResult DownloadExcel_LaporAsset(string NO_LAPOR, string NO_ASSET, string KONDISI_ASSET, string NAMA_USER, string DEPARTMENT_USER)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Data_Lapor_Asset_Template.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DISA10001_LIST_LAPOR_DOWNLOAD> dataLaporAsset = R.DownloadExcel_LaporAsset(1, 10000000, NO_LAPOR, NO_ASSET, KONDISI_ASSET, NAMA_USER, DEPARTMENT_USER).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B6"].LoadFromCollection(dataLaporAsset);
                worksheet.Cells["B6:L" + (dataLaporAsset.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:L" + (dataLaporAsset.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:L" + (dataLaporAsset.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:L" + (dataLaporAsset.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data Lapor Asset_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #endregion

        //-----------------------------------------------------------PAGE DISPOSE ASSET----------------------------------------------------------
        #region Page Dispose Asset
        #region Hyperlink Page Data Asset
        public ActionResult DISPOSE_ASSET()
        {
            GetDataHeader();
            Settings.Title = "List Dispose Asset";
            ViewData["Title1"] = Settings.Title;
            ViewData["nama_lokasi"] = R.getLokasi();
            //ViewData["no_asset"] = R.getListAsset();

            GetDataValidasiUser(username, Settings.Title);

            return View("Dispose_Asset/Data_Dispose_Asset");
        }
        #endregion

        #region Search Data Dispose Asset
        public ActionResult Search_Data_Dispose(int start, int display, string DATA_ID, string NO_DISPOSE, string NO_ASSET, string STATUS_APPROVAL)
        {
            //Buat Paging//
            PagingModel_DISA100001 pg = new PagingModel_DISA100001(R.getCount_DisposeAsset(DATA_ID, NO_DISPOSE, NO_ASSET, STATUS_APPROVAL), start, display);

            //Munculin Data ke Grid//
            List<DISA10001_DISPOSE_ASSET> List = R.getDataDisposeAsset(pg.StartData, pg.EndData, NO_DISPOSE, NO_ASSET, STATUS_APPROVAL).ToList();
            ViewData["DataDISA100001"] = List;

            ViewData["PagingDISA100001"] = pg;
            return PartialView("Dispose_Asset/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Tambah Data Dispose Asset
        public ActionResult TAMBAH_DATA_DISPOSE(
            string DATA_ID,
            string NO_ASSET,
            string FOTO_NAME,
            string STATUS_KONDISI,
            string STATUS_APPROVAL,
            string KETERANGAN
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //User Login
            string USERNAME = username;
            DateTime CREATED_DATE = DateTime.Now;
            string CREATED_BY_SIGN = USERNAME + ".jpg";

            //Cek Dept. User
            string DEPT_USER = R.getDeptUser(NO_ASSET);

            //Create No_Dispose
            string NO_DISPOSE = R.getUrutanDispose(DEPT_USER);

            //Nama Foto
            FOTO_NAME = NO_DISPOSE + FOTO_NAME;

            //Status Approval
            STATUS_APPROVAL = STATUS_APPROVAL + USERNAME;

            //Fitur
            string NAMA_FITUR = "DISPOSE ASSET";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100001Repository.Tambah_Dispose(DATA_ID, NO_DISPOSE, NO_ASSET, FOTO_NAME, STATUS_KONDISI, STATUS_APPROVAL, NAMA_FITUR, KETERANGAN, USERNAME, CREATED_DATE, CREATED_BY_SIGN);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "DISPOSE ASSET", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "DISPOSE ASSET", "", "");
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
            return Json(new { sts, message, NO_DISPOSE }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Tambah Data Dispose Asset (Multiple Insert Data)
        public ActionResult Insert_Data_Detail_Dispose()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string NO_ASSET = "";
            string DEPT_USER = "";
            string NO_DISPOSE = "";

            //User Login
            string USERNAME = username;
            string CREATED_BY_SIGN = USERNAME + ".jpg";

            //Fitur
            string NAMA_FITUR = "DISPOSE ASSET";

            //Tanggal
            DateTime CREATED_DATE = DateTime.Now;

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                var items = JsonConvert.DeserializeObject<DISA10001_DISPOSE_ASSET_INPUT_FORM>(json);

                foreach (var _detailItem in items.list_detail_create)
                {
                    NO_ASSET = _detailItem.NO_ASSET;
                }

                //Cek Dept. User
                DEPT_USER = R.getDeptUser(NO_ASSET);

                //Create No_Dispose
                NO_DISPOSE = R.getUrutanDispose(DEPT_USER.Trim());


                var Exec = DISA100001Repository.Create_Detail_Dispose(items, NO_DISPOSE, USERNAME, CREATED_DATE, CREATED_BY_SIGN, NAMA_FITUR);
                //var Exec = DISA100001Repository.Create_Detail_Request(items, NOMOR_URUT_REQUEST, username, CREATED_DATE, STATUS_REQUEST);
                sts = "TRUE";
                message = "Data berhasil disimpan!";

                if(sts == "TRUE")
                {
                    Exec = DISA100001Repository.Create_Summary_Dispose(items, NO_DISPOSE, USERNAME, CREATED_DATE, CREATED_BY_SIGN, NAMA_FITUR);
                }

            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, NO_DISPOSE }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Detail Data Dispose Asset
        public virtual ActionResult GetDataDetailDispose(string ID)
        {
            try
            {
                List<DISA10001_DISPOSE_ASSET> GetDataDispose_Detail = R.GetDataDetailDispose(ID).ToList();
                ViewData["Title"] = "Detail Dispose Asset";

                if (GetDataDispose_Detail.Count > 0)
                {
                    ViewData["DataDispose_Asset_Detail"] = GetDataDispose_Detail;
                    ViewData["NO_DISPOSE"] = GetDataDispose_Detail.FirstOrDefault().NO_DISPOSE.ToString();
                    ViewData["STATUS_APPROVAL"] = GetDataDispose_Detail.FirstOrDefault().STATUS_APPROVAL.ToString();
                    ViewData["CREATED_DATE"] = GetDataDispose_Detail.FirstOrDefault().CREATED_DATE.ToString();

                    sts = "TRUE";
                    message = "Success";
                }
                else
                {
                    sts = "FALSE";
                    message = "Data Detail Dispose Not Found!";
                }

            }
            catch (InvalidDataException)
            {

            }

            return PartialView("Dispose_Asset/Data_Show_Detail");
        }
        #endregion

        #region Download Lampiran
        public virtual ActionResult DownloadLampiran(string NAMA_FOTO_LAPORAN)
        {
            string filePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset/Dispose_Asset/", NAMA_FOTO_LAPORAN);
            Response.ContentType = "application/x-msexcel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();

            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        #region Get Bind Data Dispose
        public ActionResult getBindDataDispose(string NO_DISPOSE)
        {
            var sts = new object();
            string message = null;
            try
            {
                var data = R.getBindDataDispose(NO_DISPOSE);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", mesage = "Error" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        //#region Update Data Dispose Asset
        //public ActionResult UPDATE_DATA_DISPOSE(
        //    string ID,
        //    string NO_DISPOSE,
        //    string NO_ASSET,
        //    string STATUS_KONDISI_ASSET,
        //    string STATUS_APPROVAL,
        //    string KETERANGAN,
        //    string FOTO_NAME
        //    )
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    var message = new object();
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    try
        //    {
        //        string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

        //        //Nama Foto
        //        if (FOTO_NAME != "")
        //        {
        //            FOTO_NAME = NO_DISPOSE + FOTO_NAME;
        //        }
        //        else
        //        {
        //            FOTO_NAME = NO_DISPOSE + ".PNG";
        //        }

        //        //User Login
        //        string USERNAME = username;
        //        DateTime UPDATED_DATE = DateTime.Now;
        //        string UPDATED_SIGN = USERNAME + ".JPG";

        //        //Status Approval
        //        STATUS_APPROVAL = STATUS_APPROVAL + USERNAME;

        //        //Status Kondisi
        //        string NAMA_FITUR = "DISPOSE";

        //        //var EXEC = R.Update_Data_Lapor_Asset(ID, NO_LAPOR, NO_ASSET, KETERANGAN, STATUS_KONDISI, PIC_LAPOR, KD_LOKASI_BARU, SUB_LOKASI_BARU, NAMA_USER_BARU, DEPT_USER_BARU, HALTE_BARU, HARGA_BARU, COST_UPGRADE_BARU, SPESIFIKASI_BARU, USERNAME, UPDATED_DATE);

        //        var EXEC = DISA100001Repository.Update_Dispose_Asset(ID, NO_DISPOSE, NO_ASSET, STATUS_KONDISI_ASSET, STATUS_APPROVAL, NAMA_FITUR, KETERANGAN, FOTO_NAME, USERNAME, UPDATED_DATE, UPDATED_SIGN);

        //        sts = EXEC[0].STACK;
        //        if (EXEC[0].STACK == "TRUE")
        //        {
        //            var res = M.get_default_message("MWP003", "Dispose Asset", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else
        //        {
        //            message = EXEC[0].LINE_STS;
        //        }


        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message, NO_DISPOSE }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion


        #region Update Data Multiple Dispose Asset
        public ActionResult UPDATE_DATA_MULTIPLE_DISPOSE()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string NO_ASSET = "";
            string DEPT_USER = "";
            string NO_DISPOSE = "";

            var typeFunction = "UPDATE";


            //User Login
            string USERNAME = username;
            string CREATED_BY_SIGN = USERNAME + ".jpg";

            //Fitur
            string NAMA_FITUR = "DISPOSE ASSET";

            //Tanggal
            DateTime CREATED_DATE = DateTime.Now;

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                var items = JsonConvert.DeserializeObject<DISA10001_DISPOSE_ASSET_INPUT_FORM>(json);

                foreach (var _detailItem in items.list_detail_create)
                {
                    NO_DISPOSE = items.NO_DISPOSE;

                    List<DISA10001_DISPOSE_ASSET> GetDataDispose_Detail = R.GetDataDetailDispose(NO_DISPOSE).ToList();
                    if (GetDataDispose_Detail.Count > 0)
                    {
                        foreach (DISA10001_DISPOSE_ASSET item in GetDataDispose_Detail)
                        {
                            NO_ASSET = item.NO_ASSET;

                            string DELETE = R.Delete_Dispose_Asset(NO_DISPOSE, NO_ASSET, USERNAME, typeFunction);

                        }
                    }

                    var Exec = DISA100001Repository.Create_Detail_Dispose(items, NO_DISPOSE, USERNAME, CREATED_DATE, CREATED_BY_SIGN, NAMA_FITUR);
                    sts = "TRUE";
                    message = "Data berhasil disimpan!";

                    if (sts == "TRUE")
                    {
                        Exec = DISA100001Repository.Create_Summary_Dispose(items, NO_DISPOSE, USERNAME, CREATED_DATE, CREATED_BY_SIGN, NAMA_FITUR);
                    }

                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, NO_DISPOSE }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //#region Delete Detail Dispose Asset
        //public ActionResult Delete_Detail_Dispose_Asset(string NO_ASSET)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    string USERNAME = username;

        //    var NOMOR_DISPOSE = "";

        //    //Fitur
        //    string FITUR = "DISPOSE";

        //    List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
        //    try
        //    {
        //        var Datas = DATA.Split(',');
        //        NOMOR_DISPOSE = Datas[0].ToString();

        //        for (int i = 0; i < Datas.Count(); i++)
        //        {
        //            if (Datas[i] != "")
        //            {
        //                var DELETE_IMAGE = DeleteFileFoto(Datas[i], FITUR);
        //                string DELETE = R.Delete_Dispose_Asset(Datas[i], USERNAME);
        //                DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
        //            }
        //        }

        //        sts = "TRUE";
        //        var res = M.get_default_message("MWP002", "Dispose Asset", "", "");
        //        message = res[0].MSG_TEXT;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message, NOMOR_DISPOSE, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion


        #region Delete Dispose Asset
        public ActionResult Delete_Dispose_Asset(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string USERNAME = username;
            var NO_ASSET = "";
            var typeFunction = "DELETE";

            var NOMOR_DISPOSE = "";

            //Fitur
            string FITUR = "DISPOSE";

            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                NOMOR_DISPOSE = Datas[0].ToString();

                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        List<DISA10001_DISPOSE_ASSET> GetDataDispose_Detail = R.GetDataDetailDispose(Datas[i]).ToList();
                        if (GetDataDispose_Detail.Count > 0)
                        {
                            foreach (DISA10001_DISPOSE_ASSET item in GetDataDispose_Detail)
                            {
                                NO_ASSET = item.NO_ASSET;

                                var DELETE_IMAGE = DeleteFileFoto(Datas[i], FITUR);
                                string DELETE = R.Delete_Dispose_Asset(Datas[i], NO_ASSET, USERNAME, typeFunction);
                                DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                            }
                        }
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Dispose Asset", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, NOMOR_DISPOSE, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Approve Dispose Asset
        public ActionResult APPROVE_DATA_DISPOSE(
            string ID,
            string ID_TB_M_DISPOSE,
            string NO_DISPOSE,
            string NO_ASSET,
            string STATUS_APPROVAL
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Tanggal
            DateTime DATE_APPROVAL = DateTime.Now;

            //User Login
            string USERNAME = username;

            //Keterangan
            string KETERANGAN = "";
            if (STATUS_APPROVAL == "ACKNOWLEDGE")
            {
                KETERANGAN = "No. Dispose: '" + NO_DISPOSE + "', Has Been Acknowledge By " + USERNAME;
            }
            else
            {
                KETERANGAN = "No. Dispose: '" + NO_DISPOSE + "', Has Been Approved By " + USERNAME;
            }

            //Fitur
            string NAMA_FITUR = "DISPOSE ASSET";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

                List<DISA10001_DISPOSE_ASSET> GetDataDispose_Detail = R.GetDataDetailDispose(NO_DISPOSE).ToList();
                if (GetDataDispose_Detail.Count > 0)
                {
                 
                    foreach (DISA10001_DISPOSE_ASSET item in GetDataDispose_Detail)
                    {
                        NO_ASSET = item.NO_ASSET;

                        var EXEC = DISA100001Repository.approveDisposeAsset(ID, ID_TB_M_DISPOSE, NO_DISPOSE, NO_ASSET, STATUS_APPROVAL, KETERANGAN, USERNAME, DATE_APPROVAL, NAMA_FITUR);
                        sts = EXEC[0].STACK;

                        if (EXEC[0].STACK == "TRUE")
                        {
                            var res = M.get_default_message("MWP003", "Dispose Asset", "", "");
                            message = res[0].MSG_TEXT;
                        }
                        else
                        {
                            message = EXEC[0].LINE_STS;
                        }
                    }
                        //NO_ASSET = GetDataDispose_Detail.FirstOrDefault().NO_ASSET.ToString();
                }
                else
                {
                    sts = "FALSE";
                    message = "Data Detail Dispose Not Found!";
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

        #region Reject Dispose Asset
        public ActionResult REJECT_DISPOSE_ASSET(
            string ID,
            string ID_TB_M_DISPOSE,
            string NO_DISPOSE,
            string NO_ASSET,
            string STATUS_APPROVAL
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Tanggal
            DateTime DATE_REJECT = DateTime.Now;

            //User Login
            string USERNAME = username;

            //Keterangan
            string KETERANGAN = "No Dispose: '" + NO_DISPOSE + "', Has Been Rejected By " + USERNAME;

            //Status Approval
            if (STATUS_APPROVAL == "PREPARED")
            {
                STATUS_APPROVAL = "REJECTED DEPT.HEAD USER By " + USERNAME;
            }
            else if (STATUS_APPROVAL == "CHECKED")
            {
                STATUS_APPROVAL = "REJECTED AMS By " + USERNAME;
            }
            else if (STATUS_APPROVAL == "APPROVED_AMS")
            {
                STATUS_APPROVAL = "REJECTED DEPT.HEAD AMS By " + USERNAME;
            }
            else if (STATUS_APPROVAL == "APPROVED_DEPT_HEAD_AMS")
            {
                STATUS_APPROVAL = "REJECTED ACKNOWLEDGE By " + USERNAME;
            }


            //Status Kondisi
            string STATUS_KONDISI = "DISPOSE";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                List<DISA10001_DISPOSE_ASSET> GetDataDispose_Detail = R.GetDataDetailDispose(NO_DISPOSE).ToList();
                if (GetDataDispose_Detail.Count > 0)
                {
                    foreach (DISA10001_DISPOSE_ASSET item in GetDataDispose_Detail)
                    {
                        NO_ASSET = item.NO_ASSET;
                        var EXEC = DISA100001Repository.rejectDispose(ID, ID_TB_M_DISPOSE, NO_DISPOSE, NO_ASSET, STATUS_APPROVAL, STATUS_KONDISI, KETERANGAN, USERNAME, DATE_REJECT);
                        sts = EXEC[0].STACK;
                        if (EXEC[0].STACK == "TRUE")
                        {
                            var res = M.get_default_message("MWP003", "Dispose Asset", "", "");
                            message = res[0].MSG_TEXT;
                        }
                        else
                        {
                            message = EXEC[0].LINE_STS;
                        }
                    }
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

        #region Download Excel Dispose Asset
        [HttpGet]
        public virtual ActionResult DownloadExcel_DisposeAsset(string NO_DISPOSE, string NO_ASSET, string STATUS_APPROVAL)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Data_Dispose_Asset_Template.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DISA10001_LIST_DISPOSE_DOWNLOAD> dataDisposeAsset = R.DownloadExcel_DisposeAsset(1, 10000000, NO_DISPOSE, NO_ASSET, STATUS_APPROVAL).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B6"].LoadFromCollection(dataDisposeAsset);
                worksheet.Cells["B6:R" + (dataDisposeAsset.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:R" + (dataDisposeAsset.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:R" + (dataDisposeAsset.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:R" + (dataDisposeAsset.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data Dispose Asset_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #region Print Out Dispose
        public virtual ActionResult Printout_Dispose(
            string NO_DISPOSE
            //,string NO_ASSET ,string KETERANGAN
            , string USER_CREATED, string DEPT_HEAD_USER_CREATED, string AMS_CREATED, string DEPT_HEAD_AMS_CREATED, string ACKNOWLEDGE_BY, string DEPT_USER
        )
        {
            //or if you use asp.net, get the relative path
            string filePath = "";
            //filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Form_Dispose_Asset_Template.xlsx");
            filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Form_Dispose_Asset_Template_portrait.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                // Create source.
                BitmapImage bi = new BitmapImage();

                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //Create Cells
                ExcelCellAddress cellAddress = new ExcelCellAddress();

                //Get List Dispose
                List<DISA10001_LIST_DISPOSE_PRINTOUT> dataDisposeAsset = R.PrintOutExcel_DisposeAsset(1, 10000000, NO_DISPOSE).ToList();

                //----------- PORTRAIT ------------ //
                worksheet.Cells["C6"].Value = NO_DISPOSE;
                //worksheet.Cells["F8"].Value = NO_ASSET;
                worksheet.Cells["C7"].Value = DateTime.Now.ToString("dd-MM-yyyy");
                //worksheet.Cells["F10"].Value = DEPT_USER;
                //worksheet.Cells["B14"].Value = KETERANGAN;            

                //add some data
                worksheet.Cells["B10"].LoadFromCollection(dataDisposeAsset);
                worksheet.Cells["B10:G" + (dataDisposeAsset.Count + 9)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B10:G" + (dataDisposeAsset.Count + 9)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B10:G" + (dataDisposeAsset.Count + 9)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B10:G" + (dataDisposeAsset.Count + 9)].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                //------- Setting Tanda Tangan (PORTRAIT) -----//
                int PixelTop = 925;
                int Width = 85;
                int Height = 80;

                //Jika belum tanda tangan (image blank)
                //Image blankImg = Image.FromFile(@"\\192.168.0.10\_tpquick\Online System\POnline\Sign\" + "_BLANK.jpg");
                //ExcelPicture blankSign = worksheet.Drawings.AddPicture("_BLANK.jpg", blankImg);
                //blankSign.SetPosition(PixelTop, 115);
                //blankSign.SetSize(Width, Height);


                //Tanda Tangan dan Nama User
                Image UserCreated_Name = Image.FromFile(@"\\192.168.0.10\_tpquick\Online System\POnline\Sign\" + USER_CREATED.ToUpper() + ".jpg");
                ExcelPicture UserCreated_Sign = worksheet.Drawings.AddPicture(USER_CREATED + ".jpg", UserCreated_Name);
                UserCreated_Sign.SetPosition(PixelTop, 90);
                UserCreated_Sign.SetSize(Width, Height);
                
                worksheet.Cells["C46"].Value = USER_CREATED;

                //Tanda Tangan dan Nama Dept Head User
                Image Dept_Head_UserCreated_Name;
                ExcelPicture Dept_Head_UserCreated_Sign;
                if (DEPT_HEAD_USER_CREATED != "")
                {
                    Dept_Head_UserCreated_Name = Image.FromFile(@"\\192.168.0.10\_tpquick\Online System\POnline\Sign\" + DEPT_HEAD_USER_CREATED.ToUpper() + ".jpg");
                    
                    if (DEPT_HEAD_USER_CREATED != USER_CREATED)
                    {
                        Dept_Head_UserCreated_Sign = worksheet.Drawings.AddPicture(DEPT_HEAD_USER_CREATED + ".jpg", Dept_Head_UserCreated_Name);
                    }
                    else
                    {
                        Dept_Head_UserCreated_Sign = worksheet.Drawings.AddPicture(DEPT_HEAD_USER_CREATED + "_DEPTHEAD_USER.jpg", Dept_Head_UserCreated_Name);

                    }

                    Dept_Head_UserCreated_Sign.SetPosition(PixelTop, 205);
                    Dept_Head_UserCreated_Sign.SetSize(Width, Height);

                    worksheet.Cells["D46"].Value = DEPT_HEAD_USER_CREATED;
                }

                //Tanda Tangan dan Nama AMS
                Image AMS_Name;
                ExcelPicture AMS_Sign;
                if (AMS_CREATED != "")
                {
                    AMS_Name = Image.FromFile(@"\\192.168.0.10\_tpquick\Online System\POnline\Sign\" + AMS_CREATED.ToUpper() + ".jpg");
                    
                    if(AMS_CREATED != DEPT_HEAD_USER_CREATED)
                    {
                        AMS_Sign = worksheet.Drawings.AddPicture(AMS_CREATED + ".jpg", AMS_Name);
                    }
                    else
                    {
                        AMS_Sign = worksheet.Drawings.AddPicture(AMS_CREATED + "_AMS.jpg", AMS_Name);
                    }

                    AMS_Sign.SetPosition(PixelTop, 315);
                    AMS_Sign.SetSize(Width, Height);

                    worksheet.Cells["E46"].Value = AMS_CREATED;
                }

                //Tanda Tangan dan Nama Dept. Head AMS
                Image Dept_Head_AMS_Name;
                ExcelPicture Dept_Head_AMS_Sign;
                if(DEPT_HEAD_AMS_CREATED != "")
                {
                    Dept_Head_AMS_Name = Image.FromFile(@"\\192.168.0.10\_tpquick\Online System\POnline\Sign\" + DEPT_HEAD_AMS_CREATED.ToUpper() + ".jpg");
                    
                    if(DEPT_HEAD_AMS_CREATED != AMS_CREATED)
                    {
                        Dept_Head_AMS_Sign = worksheet.Drawings.AddPicture(DEPT_HEAD_AMS_CREATED + ".jpg", Dept_Head_AMS_Name);
                    }
                    else
                    {
                        Dept_Head_AMS_Sign = worksheet.Drawings.AddPicture(DEPT_HEAD_AMS_CREATED + "_DEPTHEAD_AMS.jpg", Dept_Head_AMS_Name);
                    }
                    Dept_Head_AMS_Sign.SetPosition(PixelTop, 425);
                    Dept_Head_AMS_Sign.SetSize(Width, Height);

                    worksheet.Cells["F46"].Value = DEPT_HEAD_AMS_CREATED;
                }


                //Tanda Tangan dan Nama GM
                Image GM_Name;
                ExcelPicture GM_Sign;
                if (ACKNOWLEDGE_BY != "")
                {
                    GM_Name = Image.FromFile(@"\\192.168.0.10\_tpquick\Online System\POnline\Sign\" + ACKNOWLEDGE_BY.ToUpper() + ".jpg");
                    
                    if(ACKNOWLEDGE_BY != DEPT_HEAD_AMS_CREATED)
                    {
                        GM_Sign = worksheet.Drawings.AddPicture(ACKNOWLEDGE_BY + ".jpg", GM_Name);
                    }
                    else{
                        GM_Sign = worksheet.Drawings.AddPicture(ACKNOWLEDGE_BY + "_GM.jpg", GM_Name);
                    }

                    GM_Sign.SetPosition(PixelTop, 535);
                    GM_Sign.SetSize(Width, Height);

                    worksheet.Cells["G46"].Value = ACKNOWLEDGE_BY;
                }

                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();

            }

            var filename = "Form Dispose_" + DateTime.Now.ToString("yyyyMMdd-hhmm") + ".xlsx";
            //Print(filename);

            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        #endregion


        //#region Dispose Data Asset
        //public ActionResult Approve_Dispose(string DATA)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    List<DisposeModel> DISPOSE_MSG = new List<DisposeModel>();
        //    try
        //    {
        //        var Datas = DATA.Split(',');
        //        for (int i = 0; i < Datas.Count(); i++)
        //        {
        //            if (Datas[i] != "")
        //            {
        //                string DELETE = R.Dispose_Data(Datas[i]);
        //                DISPOSE_MSG.Add(new DisposeModel { DISPOSE_NAME = Datas[i], DISPOSE_MSG = DELETE });
        //            }
        //        }

        //        sts = "TRUE";
        //        var res = M.get_default_message("MWP002", "Dispose Asset", "", "");
        //        message = res[0].MSG_TEXT;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message, DISPOSE_MSG }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion //OLD

        #endregion

        //-----------------------------------------------------------PAGE AUDIT ASSET------------------------------------------------------------
        #region Page Audit Asset

        #region Hyperlink Page Input Audit Asset
        public ActionResult PAGE_INPUT_AUDIT_ASSET()
        {
            GetDataHeader();
            Settings.Title = "Input Audit Asset";
            ViewData["Title1"] = Settings.Title;
            ViewData["nama_lokasi"] = R.getLokasi();
            //ViewData["no_asset"] = R.getListAsset();

            GetDataValidasiUser(username, Settings.Title);


            return View("Audit_Asset/Input_Audit_Asset");
        }
        #endregion

        #region TAMBAH DATA AUDIT ASSET
        public ActionResult TAMBAH_DATA_AUDIT(
            string DATA_ID,
            string NO_ASSET,
            string JENIS_AUDIT,
            string PERIODE_BULAN,
            string PERIODE_SEMESTER,
            string TAHUN,
            string STATUS_KONDISI,
            string KETERANGAN,
            string FOTO_NAME
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //User Login
            string USERNAME = username;
            DateTime CREATED_DATE = DateTime.Now;

            //Create No Audit
            string NO_AUDIT = R.getUrutanAudit();

            //Get Month
            //string bulan = "";
            //if (JENIS_AUDIT == "BULANAN")
            //{
            //    bulan = PERIODE_BULAN.Substring(5, 2);
            //    PERIODE_BULAN = bulan;
            //}

            //Nama Foto
            FOTO_NAME = NO_AUDIT + FOTO_NAME;

            //Update Status Audit
            string STATUS_AUDIT = "Last Audited by " + USERNAME + " on " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); 

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100001Repository.Tambah_Audit(NO_AUDIT, NO_ASSET, JENIS_AUDIT, PERIODE_BULAN, PERIODE_SEMESTER, TAHUN, STATUS_KONDISI, KETERANGAN, FOTO_NAME, USERNAME, CREATED_DATE, STATUS_AUDIT);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "AUDIT ASSET", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "AUDIT ASSET", "", "");
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
            return Json(new { sts, message, NO_AUDIT }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Hyperlink Page Data Audit Bulanan
        public ActionResult PAGE_DATA_AUDIT_ASSET_BULANAN()
        {
            GetDataHeader();
            Settings.Title = "List Audit Asset Bulanan";
            ViewData["Title1"] = Settings.Title;
            ViewData["nama_lokasi"] = R.getLokasi();
            //ViewData["no_asset"] = R.getListAsset();

            GetDataValidasiUser(username, Settings.Title);

            ViewData["fitur_audit"] = "Fitur_Audit_Bulanan";
            return View("Audit_Asset/Data_Audit_Asset");
        }
        #endregion

        #region Hyperlink Page Data Audit Semester
        public ActionResult PAGE_DATA_AUDIT_ASSET_SEMESTER()
        {
            GetDataHeader();
            Settings.Title = "List Audit Asset Semester";
            ViewData["Title1"] = Settings.Title;
            ViewData["nama_lokasi"] = R.getLokasi();
            //ViewData["no_asset"] = R.getListAsset();

            GetDataValidasiUser(username, Settings.Title);

            ViewData["fitur_audit"] = "Fitur_Audit_Semester";
            return View("Audit_Asset/Data_Audit_Asset");
        }
        #endregion

        #region Search Data Audit Asset
        public ActionResult Search_Data_Audit(int start, int display, string DATA_ID, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, 
            string STATUS, string TAHUN, string PERIODE, string KETERANGAN,
            string NAMA_USER, string DEPARTMENT_USER)
        {
            //Buat Paging//
            PagingModel_DISA100001 pg = new PagingModel_DISA100001(R.getCount_AuditAsset(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, KETERANGAN, NAMA_USER, DEPARTMENT_USER), start, display);

            //Munculin Data ke Grid//
            List<DISA10001_AUDIT_ASSET> List = R.getDataAuditAsset(pg.StartData, pg.EndData, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["DataDISA100001"] = List;

            ViewData["PagingDISA100001"] = pg;

            string JENIS_ASSET = "";

            //------------------------ All Data Qty & Amount ----------------------
            //Qty & Amount Total
            List<DISA10001_AUDIT_ASSET> QtyAmountTotal = R.Qty_Amount_Audit(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_Total"] = QtyAmountTotal.FirstOrDefault().QTY.ToString();

            if (QtyAmountTotal.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_Total"] = 0;
            }
            else
            {
                ViewData["Amount_Total"] = QtyAmountTotal.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Fixed Asset (FA)
            JENIS_ASSET = "FA";
            List<DISA10001_AUDIT_ASSET> QtyAmountFA = R.Qty_Amount_Audit(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_FA"] = QtyAmountFA.FirstOrDefault().QTY.ToString();

            if (QtyAmountFA.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_FA"] = 0;
            }
            else
            {
                ViewData["Amount_FA"] = QtyAmountFA.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Small Asset (SA)
            JENIS_ASSET = "SA";
            List<DISA10001_AUDIT_ASSET> QtyAmountSA = R.Qty_Amount_Audit(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_SA"] = QtyAmountSA.FirstOrDefault().QTY.ToString();

            if (QtyAmountSA.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_SA"] = 0;
            }
            else
            {
                ViewData["Amount_SA"] = QtyAmountSA.FirstOrDefault().AMOUNT.ToString();
            }

            //------------------------ Good Condition (OK) Qty & Amount ----------------------
            STATUS = "OK";
            JENIS_ASSET = "";

            // Qty & Amount Total
            List<DISA10001_AUDIT_ASSET> QtyAmountTotal_OK = R.Qty_Amount_Audit_OK(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_Total_OK"] = QtyAmountTotal_OK.FirstOrDefault().QTY.ToString();

            if (QtyAmountTotal_OK.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_Total_OK"] = 0;
            }
            else
            {
                ViewData["Amount_Total_OK"] = QtyAmountTotal_OK.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Fixed Asset (FA)
            JENIS_ASSET = "FA";

            List<DISA10001_AUDIT_ASSET> QtyAmountFA_OK = R.Qty_Amount_Audit_OK(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_FA_OK"] = QtyAmountFA_OK.FirstOrDefault().QTY.ToString();

            if (QtyAmountFA_OK.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_FA_OK"] = 0;
            }
            else
            {
                ViewData["Amount_FA_OK"] = QtyAmountFA_OK.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Small Asset (SA)
            JENIS_ASSET = "SA";
            List<DISA10001_AUDIT_ASSET> QtyAmountSA_OK = R.Qty_Amount_Audit_OK(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_SA_OK"] = QtyAmountSA_OK.FirstOrDefault().QTY.ToString();

            if (QtyAmountSA_OK.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_SA_OK"] = 0;
            }
            else
            {
                ViewData["Amount_SA_OK"] = QtyAmountSA_OK.FirstOrDefault().AMOUNT.ToString();
            }

            //------------------------ Not Good Condition (NG) Qty & Amount ----------------------
            STATUS = "NG";
            JENIS_ASSET = "";

            // Qty & Amount Total
            List<DISA10001_AUDIT_ASSET> QtyAmountTotal_NG = R.Qty_Amount_Audit_NG(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_Total_NG"] = QtyAmountTotal_NG.FirstOrDefault().QTY.ToString();

            if (QtyAmountTotal_NG.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_Total_NG"] = 0;
            }
            else
            {
                ViewData["Amount_Total_NG"] = QtyAmountTotal_NG.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Fixed Asset (FA)
            JENIS_ASSET = "FA";

            List<DISA10001_AUDIT_ASSET> QtyAmountFA_NG = R.Qty_Amount_Audit_NG(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_FA_NG"] = QtyAmountFA_NG.FirstOrDefault().QTY.ToString();

            if (QtyAmountFA_NG.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_FA_NG"] = 0;
            }
            else
            {
                ViewData["Amount_FA_NG"] = QtyAmountFA_NG.FirstOrDefault().AMOUNT.ToString();
            }

            //Qty & Amount Data Small Asset (SA)
            JENIS_ASSET = "SA";
            List<DISA10001_AUDIT_ASSET> QtyAmountSA_NG = R.Qty_Amount_Audit_NG(DATA_ID, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, JENIS_ASSET, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();
            ViewData["Qty_SA_NG"] = QtyAmountSA_NG.FirstOrDefault().QTY.ToString();

            if (QtyAmountSA_NG.FirstOrDefault().QTY.ToString() == "0")
            {
                ViewData["Amount_SA_NG"] = 0;
            }
            else
            {
                ViewData["Amount_SA_NG"] = QtyAmountSA_NG.FirstOrDefault().AMOUNT.ToString();
            }


            var page_control = "";
            if (JENIS_AUDIT == "BULANAN")
            {
                page_control = "Audit_Asset/Datagrid_Data_Bulanan";
            }
            else if (JENIS_AUDIT == "SEMESTER")
            {
                page_control = "Audit_Asset/Datagrid_Data_Semester";
            }

            return PartialView(page_control, pg.CountData);
        }
        #endregion

        #region Update Data Audit Asset
        public ActionResult UPDATE_DATA_AUDIT(
            string ID,
            string NO_AUDIT,
            string JENIS_AUDIT,
            string NO_ASSET,
            string KETERANGAN,
            string PERIODE,
            string TAHUN,
            string STATUS_KONDISI,
            string FOTO_NAME
            )
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

                //Nama Foto
                if (FOTO_NAME != "")
                {
                    FOTO_NAME = NO_AUDIT + FOTO_NAME;
                }

                //User Login
                string USERNAME = username;
                DateTime UPDATED_DATE = DateTime.Now;
                string UPDATED_SIGN = USERNAME + ".JPG";

                //Status Kondisi
                string NAMA_FITUR = "";
                if (JENIS_AUDIT == "BULANAN")
                {
                    NAMA_FITUR = "AUDIT ASSET";
                }
                else if (JENIS_AUDIT == "SEMESTER")
                {
                    NAMA_FITUR = "AUDIT ASSET";
                }

                //Update Status Audit
                string STATUS_AUDIT = "Last Audited by " + USERNAME + " on " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                //var EXEC = R.Update_Data_Lapor_Asset(ID, NO_LAPOR, NO_ASSET, KETERANGAN, STATUS_KONDISI, PIC_LAPOR, KD_LOKASI_BARU, SUB_LOKASI_BARU, NAMA_USER_BARU, DEPT_USER_BARU, HALTE_BARU, HARGA_BARU, COST_UPGRADE_BARU, SPESIFIKASI_BARU, USERNAME, UPDATED_DATE);

                var EXEC = DISA100001Repository.Update_Audit_Asset(ID, NO_AUDIT, JENIS_AUDIT, NO_ASSET, KETERANGAN, PERIODE, TAHUN, STATUS_KONDISI, FOTO_NAME, USERNAME, UPDATED_DATE, NAMA_FITUR, STATUS_AUDIT);

                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Audit Asset", "", "");
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
            return Json(new { sts, message, NO_AUDIT }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Audit Asset
        public ActionResult Delete_Audit_Asset(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string USERNAME = username;

            string NOMOR_AUDIT = "";
            //string NOMOR_AUDIT = DATA.Substring(0, 9);

            string FITUR = "AUDIT";

            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                NOMOR_AUDIT = Datas[0].ToString();

                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        var DELETE_IMAGE = DeleteFileFoto(Datas[i], FITUR);
                        string DELETE = R.Delete_Audit_Asset(Datas[i], USERNAME);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Audit Asset", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, NOMOR_AUDIT, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Download Excel Audit Asset
        [HttpGet]
        public virtual ActionResult DownloadExcel_AuditAsset(string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, string STATUS, string TAHUN, string PERIODE,
            string KETERANGAN, string NAMA_USER, string DEPARTMENT_USER)
        {
            //or if you use asp.net, get the relative path
            string filePath = "";
            if (JENIS_AUDIT == "BULANAN")
            {
                filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Data_Audit_Asset_Bulan_Template.xlsx");
            }
            else if (JENIS_AUDIT == "SEMESTER")
            {
                filePath = Server.MapPath("~/Content/TemplateReport/Management_Asset/Data_Audit_Asset_Semester_Template.xlsx");
            }

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DISA10001_LIST_AUDIT_DOWNLOAD> dataAuditAsset = R.DownloadExcel_AuditAsset(1, 10000000, NO_AUDIT, NO_ASSET, JENIS_AUDIT, STATUS, TAHUN, PERIODE, KETERANGAN, NAMA_USER, DEPARTMENT_USER).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
                worksheet.Cells["B6"].LoadFromCollection(dataAuditAsset);
                worksheet.Cells["B6:R" + (dataAuditAsset.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:R" + (dataAuditAsset.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:R" + (dataAuditAsset.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:R" + (dataAuditAsset.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data Audit Asset_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        #endregion



        #endregion




    }
}