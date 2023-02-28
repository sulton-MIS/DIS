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
using AI070.Models.WP02003Master;
using Newtonsoft.Json;
using AI070.Models.WP02003;


namespace AI070.Controllers.WP02003
{
    public class WP02003Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP02003Repository R = new WP02003Repository();
        //User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "KYK (Kiken Yochi Kontraktor)";
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
                ViewData["Project"] = R.getProject();
                ViewData["Company"] = R.getCompany();

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(int start, int display, string PROJECT_NAME, string COMPANY, string TITLE)
        {
            //Buat Paging//
            PagingModel_WP02003 pg = new PagingModel_WP02003(R.getCountWP02003(PROJECT_NAME, COMPANY, TITLE), start, display);

            //Munculin Data ke Grid//
            List<WP02003Master> List = R.getDataWP02003(pg.StartData, pg.EndData, PROJECT_NAME, COMPANY, TITLE).ToList();
            ViewData["DataWP02003"] = List;
            ViewData["PagingWP02003"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW()
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
                var items = JsonConvert.DeserializeObject<WP02003InputForm>(json);
                var Exec = WP02003Repository.Create(items, username);
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

        #region Update New
        public ActionResult UPDATE_DATA()
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
                var items = JsonConvert.DeserializeObject<WP02003InputForm>(json);

                var Exec = WP02003Repository.Update(items, username);
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
        public ActionResult Delete_Data(string data)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                R.Delete_Data(data);

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "KYK", "", "");
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


        #region Get Shift based on JobId

        [HttpGet]
        public ActionResult getShift(string proyekId)
        {
            try
            {
                var data = R.getShift(proyekId);
                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Get Project Job
        [HttpGet]
        public ActionResult getProjectJob(string WP_PROJECT_ID)
        {
            try
            {
                var data = R.getProjectJob(WP_PROJECT_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get Work Item
        [HttpGet]
        public ActionResult getWorkItem()
        {
            try
            {
                var data = R.getWorkItem();

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get Utility Item Request
        [HttpGet]
        public ActionResult getUtilityItemRequest()
        {
            try
            {
                var data = R.getUtilityItemRequest();

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get APD
        [HttpGet]
        public ActionResult getAPD()
        {
            try
            {
                var data = R.getAPD();

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get List Pekerja
        [HttpGet]
        public ActionResult getListPekerja(string name)
        {
            var data = R.getListPekerja("");
            ViewData["dataPekerja"] = data;
            return PartialView("Datagrid_Pekerja");
            //try
            //{


            //    //return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception M)
            //{
            //    return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            //}
        }

        #endregion

        #region Get List PekerjanJson
        [HttpGet]
        public ActionResult getListPekerjaJson()
        {
            try
            {
                string Company = Lookup.Get<Toyota.Common.Credential.User>().Company.Id;
                var data = R.getListPekerja(Company);
                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Get List IncidentJson
        [HttpGet]
        public ActionResult getListIncidentJson(string EMPLOYEE_ID)
        {
            try
            {
                var data = R.getListIncident(EMPLOYEE_ID);
                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Get  Project Job Detail
        [HttpGet]
        public ActionResult getProjectDetail(string ID)
        {
            try
            {
                var data = R.getProjectDetail(ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get  Project Work Equipment
        [HttpGet]
        public ActionResult getWpDailyWorkEqu(string WP_DAILY_ID)
        {
            try
            {
                var data = R.getWpDailyWorkEqu(WP_DAILY_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get  Project Util Request
        [HttpGet]
        public ActionResult getWpDailyUtilReq(string WP_DAILY_ID)
        {
            try
            {
                var data = R.getWpDailyUtilReq(WP_DAILY_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get  Project APD
        [HttpGet]
        public ActionResult getWpDailyAPD(string WP_DAILY_ID)
        {
            try
            {
                var data = R.getWpDailyAPD(WP_DAILY_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get  Project Worker List
        [HttpGet]
        public ActionResult getWpDailyWorkList(string WP_DAILY_ID)
        {
            try
            {
                var data = R.getWpDailyWorkList(WP_DAILY_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Get  Project WIDEN
        [HttpGet]
        public ActionResult getWpDailyWiDe(string WP_DAILY_ID)
        {
            try
            {
                var data = R.getWpDailyWiDe(WP_DAILY_ID);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", list = M.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region
        //[HttpGet]
        //public ActionResult GetShiftList()
        //{
        //    return;
        //    try
        //    {
        //        var data = R.ge


        //    return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception M)
        //    {
        //        return Json(new
        //        {
        //            sts = "FALSE",
        //            list = M.Message
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        #endregion

        public ActionResult MoveFile()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                saveFile = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                resultFilePath = Path.Combine("~/Content/Upload", Request.Form["Name_File"]);
                file.SaveAs(Server.MapPath(resultFilePath));
            }
            var MSG = "Nice";
            return Json(new { MSG });
        }

        #region Get GUID
        [HttpGet]
        public ActionResult getGuid()
        {
            return Json(new { guid = System.Guid.NewGuid().ToString() }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}