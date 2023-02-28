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
using AI070.Models.WP02001Master;
using Newtonsoft.Json;
using AI070.Models.WP02001;
using AI070.Models.WP02005;
using AI070.Models.WP02005Master;
using AI070.Models.WP02002Master;

namespace AI070.Controllers
{
    public class WP02005Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP02002Repository R = new WP02002Repository();
        WP02005Repository S = new WP02005Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Project Evaluation";
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
                ViewData["Division"] = S.getDivision();
                ViewData["Company"] = S.getCompany();
                ViewData["Location"] = S.getLocation();

                ViewData["Employee"] = R.getEmployee();
                ViewData["Area"] = R.getArea();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["userid_login"] = username;
                ViewData["username_login"] = Lookup.Get<Toyota.Common.Credential.User>().FirstName.ToString() + " " + Lookup.Get<Toyota.Common.Credential.User>().LastName.ToString();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_CODE, string WP_IMPB_NO, string COMPANY)
        {
            //if (STATUS != "New")
            //    STATUS = "1";
            //else
            //    STATUS = "0";

            //Buat Paging//
            PagingModel_WP02005 pg = new PagingModel_WP02005(S.getCountWP02005(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, PROJECT_NAME, PROJECT_LOCATION, PROJECT_DATE, PROJECT_DATETO, DIVISION, PROJECT_CODE, WP_IMPB_NO, COMPANY), start, display);

            //Munculin Data ke Grid//
            List<WP02005Master> List = S.getDataWP02005(pg.StartData, pg.EndData, PROJECT_NAME, PROJECT_LOCATION, PROJECT_DATE, PROJECT_DATETO, DIVISION, PROJECT_CODE, WP_IMPB_NO, COMPANY).ToList();
            ViewData["DataWP02005"] = List;
            ViewData["PagingWP02005"] = pg;
            ViewData["Division"] = S.getDivision();
            ViewData["Company"] = S.getCompany();
            ViewData["Location"] = S.getLocation();

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Submit Data
        public ActionResult Submit_Data()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
        
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var items = JsonConvert.DeserializeObject<WP02005InputForm>(json);

                var Exec = WP02005Repository.SubmitRating(items, username);
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

        public ActionResult InsertIncident()
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
            var items = JsonConvert.DeserializeObject<IncidentModel>(Request.Form["INCIDENTDATA"]);

            var filephoto = Request.Files["EVIDENCEFILE"];

            var PHOTO_NAME = Request.Form["EVIDENCENAME"];

            items.ATTACHMENT = PHOTO_NAME;

            var Exec = WP02005Repository.ProcessIncident(items, username);

            if (filephoto != null)
            {
                resultFilePath = Path.Combine("~/Content/Upload/Execution", PHOTO_NAME);
                filephoto.SaveAs(Server.MapPath(resultFilePath));
            }

            return Json(new { data = Exec });
        }

        public ActionResult UpdateIncident()
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
            var items = JsonConvert.DeserializeObject<IncidentModel>(Request.Form["INCIDENTDATA"]);

            var filephoto = Request.Files["EVIDENCEFILE"];

            var PHOTO_NAME = Request.Form["EVIDENCENAME"];

            items.ATTACHMENT = PHOTO_NAME;

            var Exec = WP02005Repository.ProcessIncident(items, username);

            if (filephoto != null)
            {
                resultFilePath = Path.Combine("~/Content/Upload/Execution", PHOTO_NAME);
                filephoto.SaveAs(Server.MapPath(resultFilePath));
            }

            return Json(new { data = Exec });
        }

        public ActionResult Delete_Data()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var items = JsonConvert.DeserializeObject<WP02005InputForm>(json);

                if (items.TYPES == "Incident")
                {
                    var Exec = WP02005Repository.DeleteIncident(items, username);
                }
                else
                {
                    var Exec = WP02005Repository.DeleteItemCheck(items, username);
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadFile()
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";

            var filephoto = Request.Files["SUPPORT_PHOTO"];
            var filedoc = Request.Files["SUPPORT_DOC"];

            var PHOTO_NAME = Request.Form["PHOTO_NAME"];
            var DOC_NAME = Request.Form["DOC_NAME"];

            string path = Path.Combine("~/Content/Upload/Execution", "");

            if (filephoto != null)
            {
                resultFilePath = Path.Combine("~/Content/Upload/Execution", PHOTO_NAME);
                filephoto.SaveAs(Server.MapPath(resultFilePath));
            }

            if (filedoc != null)
            {
                resultFilePath = Path.Combine("~/Content/Upload/Execution", DOC_NAME);
                filedoc.SaveAs(Server.MapPath(resultFilePath));
            }


            return Json(new { resultFilePath });
        }
        #endregion

        #region GetData
        [HttpGet]
        public ActionResult getListIncident(string WP_PROJECT_JOB_ID)
        {
            var sts = new object();
            string message = null;
            try
            {
                var data = S.getListIncident(WP_PROJECT_JOB_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", mesage = M.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult getListItemCheck(string WP_PROJECT_JOB_ID)
        {
            var sts = new object();
            string message = null;
            try
            {
                var data = S.getListItemCheck(WP_PROJECT_JOB_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", mesage = M.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult getListEmployee(string WP_PROJECT_JOB_ID)
        {
            var sts = new object();
            string message = null;
            try
            {
                var data = S.GetEmployee(WP_PROJECT_JOB_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", mesage = M.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
    }
}
