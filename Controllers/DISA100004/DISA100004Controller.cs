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
using AI070.Models.DISA100004Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISA100004Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA100004Repository R = new DISA100004Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Transportation";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ITEM_CODE, string JENIS_TRANSPORTATION, string TRANSPORTATION_COST)
        {
            //Buat Paging//
            PagingModel_DISA100004 pg = new PagingModel_DISA100004(R.getCountDISA100004(DATA_ID, ITEM_CODE, JENIS_TRANSPORTATION, TRANSPORTATION_COST), start, display);

            //Munculin Data ke Grid//
            List<DISA100004Master> List = R.getDataDISA100004(pg.StartData, pg.EndData, ITEM_CODE, JENIS_TRANSPORTATION, TRANSPORTATION_COST).ToList();
            ViewData["DataDISA100004"] = List;
            ViewData["PagingDISA100004"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW(
            string item_code, 
            string lot_size, 
            string master_qty, 
            string box_qty, 
            string weight, 
            string total_weight, 
            string jenis_transportation, 
            string transportation_cost, 
            string awb_free_jpn, 
            string edi_free_jpn,
            string ams_free_jpn,
            string trucking_0_250_kg_jpn,
            string handling_air_under_50_kg_jpn,
            string handling_air_upto_50_kg,
            string total_cost
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100004Repository.Create(
                     item_code,
                     lot_size,
                     master_qty,
                     box_qty,
                     weight,
                     total_weight,
                     jenis_transportation,
                     transportation_cost,
                     awb_free_jpn,
                     edi_free_jpn,
                     ams_free_jpn,
                     trucking_0_250_kg_jpn,
                     handling_air_under_50_kg_jpn,
                     handling_air_upto_50_kg,
                     total_cost,
                    username
                    );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Transportation", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Transportation", "", "");
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
                string item_code = Datas[1];
                string lot_size = Datas[2];
                string master_qty = Datas[3];
                string box_qty = Datas[4];
                string weight = Datas[5];
                string total_weight = Datas[6];
                string jenis_transportation = Datas[7];
                string transportation_cost = Datas[8];
                string awb_free_jpn = Datas[9];
                string edi_free_jpn = Datas[10];
                string ams_free_jpn = Datas[11];
                string trucking_0_250_kg_jpn = Datas[12];
                string handling_air_under_50_kg_jpn = Datas[13];
                string handling_air_upto_50_kg = Datas[14];
                string total_cost = Datas[15];

                string STATUS = "1";
                var EXEC = R.Update_Data(
                    ID,
                    item_code,
                    lot_size,
                    master_qty,
                    box_qty,
                    weight,
                    total_weight,
                    jenis_transportation,
                    transportation_cost,
                    awb_free_jpn,
                    edi_free_jpn,
                    ams_free_jpn,
                    trucking_0_250_kg_jpn,
                    handling_air_under_50_kg_jpn,
                    handling_air_upto_50_kg,
                    total_cost,
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Transportation", "", "");
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
                var res = M.get_default_message("MWP002", "Master Transportation", "", "");
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