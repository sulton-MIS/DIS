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
using AI070.Models.DISR140001Master;
using Newtonsoft.Json;
using AI070.Models.DISR140001;

namespace AI070.Controllers
{
    public class DISR140001Controller : BaseController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR140001Repository R = new DISR140001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Label Gaikan";
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
                ViewData["dmc_code"] = R.getDmcTypeItemMaster();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Get Data Operator 
        public ActionResult get_Data_Operator(string id_sagyosha)
        {
            var data = R.get_Data_Operator(id_sagyosha);
            return Json(new { data, id_sagyosha }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Seihin 
        public ActionResult get_Data_Seihin(string id_seisan)
        {
            var data = R.get_Data_Seihin(id_seisan);
            return Json(new { data, id_seisan }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Proses
        public ActionResult get_Data_Proses(string id_kotei)
        {
            var data = R.get_Data_Proses(id_kotei);
            return Json(new { data, id_kotei }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Convertion Table
        public ActionResult get_Data_ConvertionTable(string id_seihin)
        {
            var data = R.get_Data_ConvertionTable(id_seihin);
            return Json(new { data, id_seihin }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ID_BUNDLE, string DMC_CODE, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            
            PagingModel_DISR140001 pg = new PagingModel_DISR140001(R.getCountDISR140001(DATA_ID, ID_BUNDLE, DMC_CODE, TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN), start, display);

            //Munculin Data ke Grid//
            List<DISR140001Master> List = R.getDataDISR140001(pg.StartData, pg.EndData, ID_BUNDLE, DMC_CODE, TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN).ToList();
            ViewData["DataDISR140001"] = List;
            ViewData["PagingDISR140001"] = pg;
            ViewData["dmc_code"] = R.getDmcTypeItemMaster();

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
                var items = JsonConvert.DeserializeObject<DISR140001InputForm>(json);

                Sequence_model seqmodel = new Sequence_model();
                seqmodel.TYPE_TRX = "BUNDLE_CODE";
                seqmodel.YEAR_TRX = DateTime.Now.Year.ToString();
                seqmodel.MONTH_TRX = DateTime.Now.Month.ToString();
                seqmodel.DAY_TRX = DateTime.Now.Day.ToString();
                items.BUNDLE_CODE = R.GetBundleCode(seqmodel, username);

                var Exec = DISR140001Repository.Create(items, items.BUNDLE_CODE, username);
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
                var items = JsonConvert.DeserializeObject<DISR140001InputForm>(json);

                var Exec = DISR140001Repository.Delete(items, username);
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
