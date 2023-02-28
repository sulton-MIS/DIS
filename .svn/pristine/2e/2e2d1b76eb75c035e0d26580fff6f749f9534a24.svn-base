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
using AI070.Models.WP0101Master;

namespace AI070.Controllers
{
    public class WP0101Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP0101Repository R = new WP0101Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Register Project Header";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
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
                ViewData["Project_Location"] = R.getLocation();
                ViewData["Division"] = R.getDivision();
                ViewData["Status"] = R.getStatus();
                ViewData["Executor"] = R.getExecutor();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_TIME, string PROJECT_TIMETO, string STATUS)
        {
            //Buat Paging//
            PagingModel_WP0101 pg = new PagingModel_WP0101(R.getCountWP0101(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE), start, display);

            //Munculin Data ke Grid//
            List<WP0101Master> List = R.getDataWP0101(pg.StartData, pg.EndData, PROJECT_NAME, PROJECT_LOCATION, PROJECT_DATE, PROJECT_DATETO, DIVISION, PROJECT_TIME, PROJECT_TIMETO, STATUS).ToList();
            ViewData["DataWP0101"] = List;
            ViewData["PagingWP0101"] = pg;
            ViewData["Project_Location"] = R.getLocation();
            ViewData["Division"] = R.getDivision();
            ViewData["Status"] = R.getStatus();
            ViewData["Executor"] = R.getExecutor();

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string PROJECT_CODE, string PROJECT_NAME, string LOCATION, string DATE, string TIME, string DIVISION, string EXECUTOR, string CONTRACTOR, string LEADER_NAME, string SUPERVISOR_NAME, string STATUS)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP0101Repository.Create(PROJECT_CODE, PROJECT_NAME, LOCATION, DATE, TIME, DIVISION, EXECUTOR, CONTRACTOR, LEADER_NAME, SUPERVISOR_NAME, STATUS, username);
                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
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
                string PROJECT_CODE = Datas[1];
                string PROJECT_NAME = Datas[2];
                string LOCATION = Datas[3];
                string DATE = Datas[4];
                string TIME = Datas[5];
                string DIVISION = Datas[6];
                string EXECUTOR = Datas[7];
                string CONTRACTOR = Datas[8];
                string LEADERNAME = Datas[9];
                string SUPERVISOR = Datas[10];
                string STATUS = Datas[11];

                var EXEC = R.Update_Data(ID, PROJECT_CODE, PROJECT_NAME, LOCATION, DATE, TIME, DIVISION, EXECUTOR, CONTRACTOR, LEADERNAME, SUPERVISOR, STATUS, username);
                sts = EXEC[0].STACK;
                message = EXEC[0].LINE_STS;

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

            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++) {
                    if(Datas[i] != "")
                    {
                        R.Delete_Data(Datas[i]);
                    }
                }

                sts = "TRUE";
                message = "Data has been successfully Deleted";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        #region Test
        public ActionResult Test()
        {
            var sts = new object();
            string message = null;
            try
            {
                sts = R.getDivision();
            }
            catch (Exception M)
            {

            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
