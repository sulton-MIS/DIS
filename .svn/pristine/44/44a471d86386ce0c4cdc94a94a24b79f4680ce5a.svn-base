using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AI070.Models;
using AI070.Models.WP03004Master;
using Toyota.Common.Web.Platform;

using AI070.Models.Shared;
using AI070.Models.WP03013;
using static AI070.Models.WP03013.WP03013Repository;
using AI070.Models.WP03008Master;

namespace AI070.Controllers.WP03013
{
    public class WP03013Controller : PageController
    {
        private WP03013Repository db = new WP03013Repository();
        private WP03008Repository r = new WP03008Repository();
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
                Settings.Title = "Training";
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
                ViewData["COMPANY"] = r.getCompany();
                ViewData["EXECUTOR"] = r.getExecutor();
                ViewData["IDENTITY"] = r.getIdentity();
                ViewData["SECTION"] = r.getSection("TMMIN");
                ViewData["PIC"] = r.getPIC();
                ViewData["Division"] = r.getDivision();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion 

        //public ActionResult Index(int id)
        //{
        //    TrainingDTO data = WP03004Repository.GetDetailTraining(id);
        //    return View(data);
        //}

        public ActionResult SearchData(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string EMPLOYEE_NAME, string IDENTITYNUMBER, string ANZENNO, string INDUCTION)
        {
            string COMPANY = Lookup.Get<Toyota.Common.Credential.User>().Company.Id;
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            ANZENNO = r.getAnzen(username).Count() > 0 ? (r.getAnzen(username)[0].ANZEN_NO).ToString() : "";

            PagingModel_WP03013 pg = new PagingModel_WP03013(db.getCountWP03013(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, EMPLOYEE_NAME, IDENTITYNUMBER, COMPANY, ANZENNO, INDUCTION), start, display);

            //Munculin Data ke Grid//
            List<WP03008Master> List = r.getDataWP03008(pg.StartData, pg.EndData, EMPLOYEE_NAME, IDENTITYNUMBER, COMPANY, ANZENNO, INDUCTION).ToList();
            ViewData["DataWP03008"] = List;
            ViewData["PagingWP03008"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }

        public ActionResult TrainingPortal(int id)
        {
            var data = db.GetTrainingModuls();
            ViewBag.UserId = id;
            return View(data);
            //List<WP03004Master> quest = db.getDataWP03004(1, 1000000, "");
            //ViewData["UserId"] = Session["WP_ID_TB_M_EMPLOYEE"].ToString();
            //ViewBag.User = string.Format("{0} {1}",  Lookup.Get<Toyota.Common.Credential.User>().FirstName.ToString(), Lookup.Get<Toyota.Common.Credential.User>().LastName.ToString());
            //return View(quest);
        }

        public ActionResult OpenModule(int id, int userid) 
        {
            var data = db.GetTrainingDetailById(id);

            return View(data);
        }

        public ActionResult DownloadFile(string filename) {
            var filePath = System.IO.Path.Combine(Server.MapPath("~/Content/Upload/ModulTraining/"), filename);
            var mimeType = MimeMapping.GetMimeMapping(filename);
            return File(filePath, mimeType);
        }

    }
}