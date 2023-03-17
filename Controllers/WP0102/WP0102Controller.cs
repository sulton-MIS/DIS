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
using AI070.Models.WP0102Master;

namespace AI070.Controllers
{
    public class WP0102Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP0102Repository R = new WP0102Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Register Project Detail";
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
                ViewData["Project_Code"] = R.getProjectCode();
                ViewData["Jobs"] = R.getJobs();
                ViewData["Category"] = R.getCategory();
                ViewData["Location"] = R.getDataLocation();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string PROJECT_CODE)
        {
            //Buat Paging//
            PagingModel_WP0102 pg = new PagingModel_WP0102(R.getCountWP0102(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, PROJECT_CODE), start, display);

            //Munculin Data ke Grid//
            List<WP0102Master> List = R.getDataWP0102(pg.StartData, pg.EndData, PROJECT_CODE).ToList();
            ViewData["DataWP0102"] = List;
            ViewData["PagingWP0102"] = pg;
            ViewData["Project_Code"] = R.getProjectCode();
            ViewData["Jobs"] = R.getJobs();
            ViewData["Category"] = R.getCategory();
            ViewData["Location"] = R.getDataLocation();

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Get Location
        public ActionResult getLocation(string PROJECT_CODE)
        {
            string sts = null;
            string message = null;
            var data = new object();
            try
            {
                var Exec = WP0102Repository.getLocation(PROJECT_CODE);
                sts = "TRUE";
                message = "";
                data = Exec;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string PROJECT_CODE, string LOCATION, string JOBS, string DANGERLEVEL, string DATE, string CATEGORY, string REMARKS)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP0102Repository.Create(PROJECT_CODE, LOCATION, JOBS, DANGERLEVEL, DATE, CATEGORY, REMARKS, username);
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
                string LOCATION = Datas[2];
                string JOBS = Datas[3];
                string LOWLEVEL = Datas[4];
                string MEDIUMLEVEL = Datas[5];
                string HIGHLEVEL = Datas[6];
                string DATE = Datas[7];
                string CATEGORY = Datas[8];
                string REMARKS = Datas[9];
                

                var EXEC = R.Update_Data(ID, PROJECT_CODE, LOCATION, JOBS, LOWLEVEL, MEDIUMLEVEL, HIGHLEVEL, DATE, CATEGORY, REMARKS, username);
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
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
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
            return Json(new { sts, message, DATA }, JsonRequestBehavior.AllowGet);
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
