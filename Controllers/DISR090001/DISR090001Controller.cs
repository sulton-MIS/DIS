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
using AI070.Models.DISR090001Master;
using System.Security.Cryptography;
using System.Text;
using static AI070.Models.DISR090001Master.DISR090001Repository;

namespace AI070.Controllers
{
    public class DISR090001Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR090001Repository R = new DISR090001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Setting MP OPMJ";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EMPLOYEE_NAME, string IDENTITYNUMBER, string STATUS_OPMJ)
        {
            //Buat Paging//
            DISR090001Repository.PagingModel_DISR090001 pg = new PagingModel_DISR090001(R.getCountDISR090001(DATA_ID, EMPLOYEE_NAME, IDENTITYNUMBER, STATUS_OPMJ), start, display);

            //Munculin Data ke Grid//
            List<DISR090001Master> List = R.getDataDISR090001(pg.StartData, pg.EndData, EMPLOYEE_NAME, IDENTITYNUMBER, STATUS_OPMJ).ToList();
            ViewData["DataDISR090001"] = List;
            ViewData["PagingDISR090001"] = pg;
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
                string name_sagyosha = Datas[1];
                string id_sagyosha = Datas[2];
                string status_opmj = Datas[3];
               

                string STATUS = "1";
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        var EXEC = R.Update_Data(Datas[i], name_sagyosha, id_sagyosha, status_opmj, STATUS, username);
                        sts = EXEC[0].STACK;
                        if (EXEC[0].STACK == "TRUE")
                        {
                            var res = M.get_default_message("MWP003", "Master Operator", "", "");
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

        //#region Delete Data
        //public ActionResult Delete_Data(string DATA)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
        //    try
        //    {
        //        var Datas = DATA.Split(',');
        //        for (int i = 0; i < Datas.Count(); i++)
        //        {
        //            if (Datas[i] != "")
        //            {
        //                string DELETE = R.Delete_Data(Datas[i]);
        //                DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
        //            }
        //        }

        //        sts = "TRUE";
        //        var res = M.get_default_message("MWP002", "Master Operator", "", "");
        //        message = res[0].MSG_TEXT;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

    }
}