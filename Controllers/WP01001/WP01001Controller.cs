﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP01001Master;

namespace AI070.Controllers
{
    public class WP01001Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP01001Repository R = new WP01001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "System Master";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                //Response.Redirect("authorized");
            }
        }

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
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                ViewData["DataWP01001"] = null;
                ViewData["PagingWP01001"] = null;
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string SYSTEM_ID, string SYSTEM_TYPE, string SYSTEM_VALUE_TEXT, string SYSTEM_FROM, string SYSTEM_TO, string SYSTEM_VALUE_NUM, string SYSTEM_DESC)
        {
            //Buat Paging//
            PagingModel_WP01001 pg = new PagingModel_WP01001(R.getCountWP01001(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, SYSTEM_ID, SYSTEM_TYPE, SYSTEM_VALUE_TEXT, SYSTEM_FROM, SYSTEM_TO, SYSTEM_VALUE_NUM), start, display);

            //Munculin Data ke Grid//
            List<WP01001Master> List = R.getDataWP01001(pg.StartData, pg.EndData, DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, SYSTEM_ID, SYSTEM_TYPE, SYSTEM_VALUE_TEXT, SYSTEM_FROM, SYSTEM_TO, SYSTEM_VALUE_NUM).ToList();
            ViewData["DataWP01001"] = List;
            ViewData["PagingWP01001"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string SYSTEM_ID, string SYSTEM_TYPE, string SYSTEM_CD, string SYSTEM_VALID_FR, string SYSTEM_VALID_TO, string SYSTEM_VALUE_TXT, string SYSTEM_VALUE_NUM, string SYSTEM_VALUE_DT)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP01001Repository.Create(SYSTEM_ID, SYSTEM_TYPE, SYSTEM_CD, SYSTEM_VALID_FR, SYSTEM_VALID_TO, SYSTEM_VALUE_TXT, SYSTEM_VALUE_NUM, SYSTEM_VALUE_DT, username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "System Master", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "System Master", "", "");
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
                string TYPE = Datas[1];
                string SYSTEM_ID = Datas[2];
                string SYSTEM_TYPE = Datas[3];
                string SYSTEM_CD = Datas[4];
                string SYSTEM_VALID_FR = Datas[5];
                string SYSTEM_VALID_TO = Datas[6];
                string SYSTEM_VALUE_TXT = Datas[7];
                string SYSTEM_VALUE_NUM = Datas[8];
                string SYSTEM_VALUE_DT = Datas[9];

                var EXEC = R.Update_Data(ID, TYPE, SYSTEM_ID, SYSTEM_TYPE, SYSTEM_CD, SYSTEM_VALID_FR, SYSTEM_VALID_TO, SYSTEM_VALUE_TXT, SYSTEM_VALUE_NUM, SYSTEM_VALUE_DT, username);
                sts = EXEC[0].STACK;
                var res = M.get_default_message("MWP003", "System Master", "", "");
                message = res[0].MSG_TEXT;

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
        public ActionResult Delete_Data(string DATA, string TYPE, string CD)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            var DELETE_ID = new Object();
            var DELETE_MSG = new Object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                var Datas = DATA.Split(',');
                var Types = TYPE.Split(',');
                var Cd = CD.Split(',');
                for (int i = 0; i < Datas.Count(); i++) {
                    if(Datas[i] != "")
                    {
                        var DELETE = R.Delete_Data(Datas[i], Types[i], Cd[i]);

                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "System Master", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
