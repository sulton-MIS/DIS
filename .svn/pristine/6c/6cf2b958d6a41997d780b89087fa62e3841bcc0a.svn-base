using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP02002Master;
using AI070.Models.WP02006;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;

namespace AI070.Controllers.WP02006
{
    public class WP02006Controller : PageController
    {
        // GET: WP02006
        WP02006Repository db = new WP02006Repository();
        WP02002Repository R = new WP02002Repository();
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Work Flow";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
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

                ViewData["Project_Location"] = R.getLocation();
                ViewData["Division"] = R.getDivision();
                ViewData["Status"] = R.getStatus();
                ViewData["Executor"] = R.getExecutor();
                ViewData["Area"] = R.getArea();
                ViewData["Company"] = R.getCompany();
                ViewData["Employee"] = R.getEmployee();
                ViewData["Location"] = R.getLocation();
                ViewData["WorkingType"] = R.getWorkingType();
                ViewData["Pic"] = R.getPic();
                ViewData["Pengawas"] = R.getPengawas();
                ViewData["WorkingHours"] = R.getWorkingHours();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
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

        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME
            , string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string PROJECT_CODE
            , string PROJECT_NAME, string DATE_FROM, string DATE_TO, string COMPANY, string LOCATION, string DIVISION, string WP_IMPB_NO)
        {
            //Buat Paging//
            PagingModel_WP02006 pg = new PagingModel_WP02006(db.GetCountWP02006(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA
                , STATUS_ACTIVE, PROJECT_CODE, PROJECT_NAME, DATE_FROM, DATE_TO, COMPANY,
                 LOCATION, DIVISION, WP_IMPB_NO), start, display);

            //Munculin Data ke Grid//
            List<WP02006Master> List = db.GetDataWP02006(pg.StartData, pg.EndData, PROJECT_CODE, PROJECT_NAME, DATE_FROM, DATE_TO
                , COMPANY, LOCATION, DIVISION, WP_IMPB_NO).ToList();
            ViewData["DataWP02006"] = List;
            ViewData["PagingWP02006"] = pg;
            ViewData["Project_Code"] = R.getProjectCode();
            ViewData["Jobs"] = R.getJobs();
            ViewData["Category"] = R.getCategory();
            ViewData["Location"] = R.getDataLocation();
            return PartialView("Datagrid_Data", pg.CountData);
        }

        public ActionResult Detail(int id)
        {
            return View();
        }

    }
}