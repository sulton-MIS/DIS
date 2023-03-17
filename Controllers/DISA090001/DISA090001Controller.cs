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
using AI070.Models.DISA090001Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISA090001Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA090001Repository R = new DISA090001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Qty Amount Target";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(
            int start, 
            int display, 
            string DATA_ID, 
            string TARGET_DATE,
            string HALTE,
            string TARGET_PRINT_QTY, 
            string TARGET_QTY_JAM_KE_1,
            string TARGET_AMOUNT_JAM_KE_1,
            string TARGET_QTY_JAM_KE_2,
            string TARGET_AMOUNT_JAM_KE_2,
            string TARGET_QTY_JAM_KE_3,
            string TARGET_AMOUNT_JAM_KE_3,
            string TARGET_QTY_JAM_KE_4,
            string TARGET_AMOUNT_JAM_KE_4,
            string TARGET_QTY_JAM_KE_5,
            string TARGET_AMOUNT_JAM_KE_5,
            string TARGET_QTY_JAM_KE_6,
            string TARGET_AMOUNT_JAM_KE_6,
            string TARGET_QTY_JAM_KE_7,
            string TARGET_AMOUNT_JAM_KE_7,
            string TARGET_QTY_JAM_KE_8,
            string TARGET_AMOUNT_JAM_KE_8,
            string TARGET_QTY_JAM_KE_9,
            string TARGET_AMOUNT_JAM_KE_9,
            string TARGET_QTY_JAM_KE_10,
            string TARGET_AMOUNT_JAM_KE_10,
            string TARGET_QTY_JAM_KE_11,
            string TARGET_AMOUNT_JAM_KE_11,
            string TARGET_QTY_JAM_KE_12,
            string TARGET_AMOUNT_JAM_KE_12,
            string TARGET_QTY_JAM_KE_13,
            string TARGET_AMOUNT_JAM_KE_13,
            string TARGET_QTY_JAM_KE_14,
            string TARGET_AMOUNT_JAM_KE_14,
            string TARGET_QTY_JAM_KE_15_16_ISTIRAHAT,
            string TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
            string TARGET_QTY_JAM_KE_17,
            string TARGET_AMOUNT_JAM_KE_17,
            string TARGET_QTY_JAM_KE_18,
            string TARGET_AMOUNT_JAM_KE_18,
            string TARGET_QTY_JAM_KE_19,
            string TARGET_AMOUNT_JAM_KE_19,
            string TARGET_QTY_JAM_KE_20,
            string TARGET_AMOUNT_JAM_KE_20,
            string TARGET_QTY_JAM_KE_21,
            string TARGET_AMOUNT_JAM_KE_21,
            string TARGET_QTY_JAM_KE_22,
            string TARGET_AMOUNT_JAM_KE_22)
        {
            //Buat Paging//
            PagingModel_DISA090001 pg = new PagingModel_DISA090001(R.getCountDISA090001(
                DATA_ID, 
                TARGET_DATE, 
                HALTE,
                TARGET_PRINT_QTY,
                TARGET_QTY_JAM_KE_1,
                TARGET_AMOUNT_JAM_KE_1,
                TARGET_QTY_JAM_KE_2,
                TARGET_AMOUNT_JAM_KE_2,
                TARGET_QTY_JAM_KE_3,
                TARGET_AMOUNT_JAM_KE_3,
                TARGET_QTY_JAM_KE_4,
                TARGET_AMOUNT_JAM_KE_4,
                TARGET_QTY_JAM_KE_5,
                TARGET_AMOUNT_JAM_KE_5,
                TARGET_QTY_JAM_KE_6,
                TARGET_AMOUNT_JAM_KE_6,
                TARGET_QTY_JAM_KE_7,
                TARGET_AMOUNT_JAM_KE_7,
                TARGET_QTY_JAM_KE_8,
                TARGET_AMOUNT_JAM_KE_8,
                TARGET_QTY_JAM_KE_9,
                TARGET_AMOUNT_JAM_KE_9,
                TARGET_QTY_JAM_KE_10,
                TARGET_AMOUNT_JAM_KE_10,
                TARGET_QTY_JAM_KE_11,
                TARGET_AMOUNT_JAM_KE_11,
                TARGET_QTY_JAM_KE_12,
                TARGET_AMOUNT_JAM_KE_12,
                TARGET_QTY_JAM_KE_13,
                TARGET_AMOUNT_JAM_KE_13,
                TARGET_QTY_JAM_KE_14,
                TARGET_AMOUNT_JAM_KE_14,
                TARGET_QTY_JAM_KE_15_16_ISTIRAHAT,
                TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
                TARGET_QTY_JAM_KE_17,
                TARGET_AMOUNT_JAM_KE_17,
                TARGET_QTY_JAM_KE_18,
                TARGET_AMOUNT_JAM_KE_18,
                TARGET_QTY_JAM_KE_19,
                TARGET_AMOUNT_JAM_KE_19,
                TARGET_QTY_JAM_KE_20,
                TARGET_AMOUNT_JAM_KE_20,
                TARGET_QTY_JAM_KE_21,
                TARGET_AMOUNT_JAM_KE_21,
                TARGET_QTY_JAM_KE_22,
                TARGET_AMOUNT_JAM_KE_22), start, display);

            //Munculin Data ke Grid//
            List<DISA090001Master> List = R.getDataDISA090001(
                pg.StartData, 
                pg.EndData, 
                TARGET_DATE, 
                HALTE,
                TARGET_PRINT_QTY,
                TARGET_QTY_JAM_KE_1,
                TARGET_AMOUNT_JAM_KE_1,
                TARGET_QTY_JAM_KE_2,
                TARGET_AMOUNT_JAM_KE_2,
                TARGET_QTY_JAM_KE_3,
                TARGET_AMOUNT_JAM_KE_3,
                TARGET_QTY_JAM_KE_4,
                TARGET_AMOUNT_JAM_KE_4,
                TARGET_QTY_JAM_KE_5,
                TARGET_AMOUNT_JAM_KE_5,
                TARGET_QTY_JAM_KE_6,
                TARGET_AMOUNT_JAM_KE_6,
                TARGET_QTY_JAM_KE_7,
                TARGET_AMOUNT_JAM_KE_7,
                TARGET_QTY_JAM_KE_8,
                TARGET_AMOUNT_JAM_KE_8,
                TARGET_QTY_JAM_KE_9,
                TARGET_AMOUNT_JAM_KE_9,
                TARGET_QTY_JAM_KE_10,
                TARGET_AMOUNT_JAM_KE_10,
                TARGET_QTY_JAM_KE_11,
                TARGET_AMOUNT_JAM_KE_11,
                TARGET_QTY_JAM_KE_12,
                TARGET_AMOUNT_JAM_KE_12,
                TARGET_QTY_JAM_KE_13,
                TARGET_AMOUNT_JAM_KE_13,
                TARGET_QTY_JAM_KE_14,
                TARGET_AMOUNT_JAM_KE_14,
                TARGET_QTY_JAM_KE_15_16_ISTIRAHAT,
                TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
                TARGET_QTY_JAM_KE_17,
                TARGET_AMOUNT_JAM_KE_17,
                TARGET_QTY_JAM_KE_18,
                TARGET_AMOUNT_JAM_KE_18,
                TARGET_QTY_JAM_KE_19,
                TARGET_AMOUNT_JAM_KE_19,
                TARGET_QTY_JAM_KE_20,
                TARGET_AMOUNT_JAM_KE_20,
                TARGET_QTY_JAM_KE_21,
                TARGET_AMOUNT_JAM_KE_21,
                TARGET_QTY_JAM_KE_22,
                TARGET_AMOUNT_JAM_KE_22).ToList();

            ViewData["DataDISA090001"] = List;
            ViewData["PagingDISA090001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
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
                ViewData["EXECUTOR"] = R.getExecutor();  
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion        

        #region Add New        
        public ActionResult ADD_NEW(
            string target_date,
            string halte,
            string target_print_qty,
            string target_qty_jam_ke_1,
            string target_amount_jam_ke_1,
            string target_qty_jam_ke_2,
            string target_amount_jam_ke_2,
            string target_qty_jam_ke_3,
            string target_amount_jam_ke_3,
            string target_qty_jam_ke_4,
            string target_amount_jam_ke_4,
            string target_qty_jam_ke_5,
            string target_amount_jam_ke_5,
            string target_qty_jam_ke_6,
            string target_amount_jam_ke_6,
            string target_qty_jam_ke_7,
            string target_amount_jam_ke_7,
            string target_qty_jam_ke_8,
            string target_amount_jam_ke_8,
            string target_qty_jam_ke_9,
            string target_amount_jam_ke_9,
            string target_qty_jam_ke_10,
            string target_amount_jam_ke_10,
            string target_qty_jam_ke_11,
            string target_amount_jam_ke_11,
            string target_qty_jam_ke_12,
            string target_amount_jam_ke_12,
            string target_qty_jam_ke_13,
            string target_amount_jam_ke_13,
            string target_qty_jam_ke_14,
            string target_amount_jam_ke_14,
            string target_qty_jam_ke_15_16_istirahat,
            string target_amount_jam_ke_15_16_istirahat,
            string target_qty_jam_ke_17,
            string target_amount_jam_ke_17,
            string target_qty_jam_ke_18,
            string target_amount_jam_ke_18,
            string target_qty_jam_ke_19,
            string target_amount_jam_ke_19,
            string target_qty_jam_ke_20,
            string target_amount_jam_ke_20,
            string target_qty_jam_ke_21,
            string target_amount_jam_ke_21,
            string target_qty_jam_ke_22,
            string target_amount_jam_ke_22
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA090001Repository.Create(
                         target_date,
                         halte,
                         target_print_qty,
                         target_qty_jam_ke_1,
                         target_amount_jam_ke_1,
                         target_qty_jam_ke_2,
                         target_amount_jam_ke_2,
                         target_qty_jam_ke_3,
                         target_amount_jam_ke_3,
                         target_qty_jam_ke_4,
                         target_amount_jam_ke_4,
                         target_qty_jam_ke_5,
                         target_amount_jam_ke_5,
                         target_qty_jam_ke_6,
                         target_amount_jam_ke_6,
                         target_qty_jam_ke_7,
                         target_amount_jam_ke_7,
                         target_qty_jam_ke_8,
                         target_amount_jam_ke_8,
                         target_qty_jam_ke_9,
                         target_amount_jam_ke_9,
                         target_qty_jam_ke_10,
                         target_amount_jam_ke_10,
                         target_qty_jam_ke_11,
                         target_amount_jam_ke_11,
                         target_qty_jam_ke_12,
                         target_amount_jam_ke_12,
                         target_qty_jam_ke_13,
                         target_amount_jam_ke_13,
                         target_qty_jam_ke_14,
                         target_amount_jam_ke_14,
                         target_qty_jam_ke_15_16_istirahat,
                         target_amount_jam_ke_15_16_istirahat,
                         target_qty_jam_ke_17,
                         target_amount_jam_ke_17,
                         target_qty_jam_ke_18,
                         target_amount_jam_ke_18,
                         target_qty_jam_ke_19,
                         target_amount_jam_ke_19,
                         target_qty_jam_ke_20,
                         target_amount_jam_ke_20,
                         target_qty_jam_ke_21,
                         target_amount_jam_ke_21,
                         target_qty_jam_ke_22,
                         target_amount_jam_ke_22,
                         username);

                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Qty Amount Target", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Qty Amount Target", "", "");
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
                string target_date = Datas[1];
                string halte = Datas[2];
                string target_print_qty = Datas[3];
                string target_qty_jam_ke_1 = Datas[4];
                string target_amount_jam_ke_1 = Datas[5];
                string target_qty_jam_ke_2 = Datas[6];
                string target_amount_jam_ke_2 = Datas[7];
                string target_qty_jam_ke_3 = Datas[8];
                string target_amount_jam_ke_3 = Datas[9];
                string target_qty_jam_ke_4 = Datas[10];
                string target_amount_jam_ke_4 = Datas[11];
                string target_qty_jam_ke_5 = Datas[12];
                string target_amount_jam_ke_5 = Datas[13];
                string target_qty_jam_ke_6 = Datas[14];
                string target_amount_jam_ke_6 = Datas[15];
                string target_qty_jam_ke_7 = Datas[16];
                string target_amount_jam_ke_7 = Datas[17];
                string target_qty_jam_ke_8 = Datas[18];
                string target_amount_jam_ke_8 = Datas[19];
                string target_qty_jam_ke_9 = Datas[20];
                string target_amount_jam_ke_9 = Datas[21];
                string target_qty_jam_ke_10 = Datas[22];
                string target_amount_jam_ke_10 = Datas[23];
                string target_qty_jam_ke_11 = Datas[24];
                string target_amount_jam_ke_11 = Datas[25];
                string target_qty_jam_ke_12 = Datas[26];
                string target_amount_jam_ke_12 = Datas[27];
                string target_qty_jam_ke_13 = Datas[28];
                string target_amount_jam_ke_13 = Datas[29];
                string target_qty_jam_ke_14 = Datas[30];
                string target_amount_jam_ke_14 = Datas[31];
                string target_qty_jam_ke_15_16_istirahat = Datas[32];
                string target_amount_jam_ke_15_16_istirahat = Datas[33];
                string target_qty_jam_ke_17 = Datas[34];
                string target_amount_jam_ke_17 = Datas[35];
                string target_qty_jam_ke_18 = Datas[36];
                string target_amount_jam_ke_18 = Datas[37];
                string target_qty_jam_ke_19 = Datas[38];
                string target_amount_jam_ke_19 = Datas[39];
                string target_qty_jam_ke_20 = Datas[40];
                string target_amount_jam_ke_20 = Datas[41];
                string target_qty_jam_ke_21 = Datas[42];
                string target_amount_jam_ke_21 = Datas[43];
                string target_qty_jam_ke_22 = Datas[44];
                string target_amount_jam_ke_22 = Datas[45];

                //string STATUS = "1";
                var EXEC = R.Update_Data(
                        ID,
                        target_date,
                        halte,
                         target_print_qty,
                         target_qty_jam_ke_1,
                         target_amount_jam_ke_1,
                         target_qty_jam_ke_2,
                         target_amount_jam_ke_2,
                         target_qty_jam_ke_3,
                         target_amount_jam_ke_3,
                         target_qty_jam_ke_4,
                         target_amount_jam_ke_4,
                         target_qty_jam_ke_5,
                         target_amount_jam_ke_5,
                         target_qty_jam_ke_6,
                         target_amount_jam_ke_6,
                         target_qty_jam_ke_7,
                         target_amount_jam_ke_7,
                         target_qty_jam_ke_8,
                         target_amount_jam_ke_8,
                         target_qty_jam_ke_9,
                         target_amount_jam_ke_9,
                         target_qty_jam_ke_10,
                         target_amount_jam_ke_10,
                         target_qty_jam_ke_11,
                         target_amount_jam_ke_11,
                         target_qty_jam_ke_12,
                         target_amount_jam_ke_12,
                         target_qty_jam_ke_13,
                         target_amount_jam_ke_13,
                         target_qty_jam_ke_14,
                         target_amount_jam_ke_14,
                         target_qty_jam_ke_15_16_istirahat,
                         target_amount_jam_ke_15_16_istirahat,
                         target_qty_jam_ke_17,
                         target_amount_jam_ke_17,
                         target_qty_jam_ke_18,
                         target_amount_jam_ke_18,
                         target_qty_jam_ke_19,
                         target_amount_jam_ke_19,
                         target_qty_jam_ke_20,
                         target_amount_jam_ke_20,
                         target_qty_jam_ke_21,
                         target_amount_jam_ke_21,
                         target_qty_jam_ke_22,
                         target_amount_jam_ke_22);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Qty Amount Target", "", "");
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
                var res = M.get_default_message("MWP002", "Master Operator", "", "");
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