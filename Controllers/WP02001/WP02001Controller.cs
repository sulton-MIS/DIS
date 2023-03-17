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

namespace AI070.Controllers
{
    public class WP02001Controller : BaseController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP02001Repository R = new WP02001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Project Registration";
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
                ViewData["Area"] = R.getArea();
                ViewData["Company"] = R.getCompany();
                ViewData["Location"] = R.getLocation();
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
            //if (STATUS != "New")
            //    STATUS = "1";
            //else
            //    STATUS = "0";

            //Buat Paging//
            PagingModel_WP02001 pg = new PagingModel_WP02001(R.getCountWP02001(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, PROJECT_NAME, PROJECT_LOCATION, PROJECT_DATE, PROJECT_DATETO, DIVISION, PROJECT_TIME, PROJECT_TIMETO, STATUS), start, display);

            //Munculin Data ke Grid//
            List<WP02001Master> List = R.getDataWP02001(pg.StartData, pg.EndData, PROJECT_NAME, PROJECT_LOCATION, PROJECT_DATE, PROJECT_DATETO, DIVISION, PROJECT_TIME, PROJECT_TIMETO, STATUS).ToList();
            ViewData["DataWP02001"] = List;
            ViewData["PagingWP02001"] = pg;
            ViewData["Project_Location"] = R.getLocation();
            ViewData["Division"] = R.getDivision();
            ViewData["Status"] = R.getStatus();
            ViewData["Area"] = R.getArea();
            ViewData["Company"] = R.getCompany();
            ViewData["Location"] = R.getLocation();

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult Insert_Data()
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
                var items = JsonConvert.DeserializeObject<WP02001InputForm>(json);

                Sequence_model seqmodel = new Sequence_model();
                seqmodel.TYPE_TRX = "PROJECT_CODE";
                seqmodel.YEAR_TRX = DateTime.Now.Year.ToString();
                seqmodel.MONTH_TRX = DateTime.Now.Month.ToString();
                items.WP_PROJECT_CODE = R.GetProjectCode(seqmodel, username, items.ID_TB_M_AREA);

                var Exec = WP02001Repository.Create(items, username);
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
        public ActionResult Update_Data()
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
                var items = JsonConvert.DeserializeObject<WP02001InputForm>(json);

                var Exec = WP02001Repository.Update(items, username);
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

        #region Delete Data
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
                var items = JsonConvert.DeserializeObject<WP02001InputForm>(json);

                var Exec = WP02001Repository.Delete(items, username);
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

        [HttpGet]
        #region Get Project Job
        public ActionResult getProjectJob(string WP_PROJECT_ID)
        {
            var sts = new object();
            string message = null;
            try
            {
                var data = R.getProjectJob(WP_PROJECT_ID);

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
