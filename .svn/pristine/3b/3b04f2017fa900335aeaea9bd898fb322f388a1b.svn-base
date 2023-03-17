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
using AI070.Models.WP04004Master;

namespace AI070.Controllers
{
    public class WP04004Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP04004Repository R = new WP04004Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "User Plant";
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
                ViewData["Plant"] = R.getPlant();
                ViewData["Company"] = R.getCompany(); 
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string USERNAME)
        {
            //Buat Paging//
            PagingModel_WP04004 pg = new PagingModel_WP04004(R.getCountWP04004(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, USERNAME), start, display);

            //Munculin Data ke Grid//
            List<WP04004Master> List = R.getDataWP04004(pg.StartData, pg.EndData, USERNAME).ToList();
            ViewData["DataWP04004"] = List;
            ViewData["PagingWP04004"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string USERNAME, string PLANT_CD, string PLANT_NM, string COMPANY)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP04004Repository.Create(USERNAME, PLANT_CD, PLANT_NM, COMPANY, username);
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
                string USERNAME = Datas[1];
                string PLANT_CD = Datas[2];
                string PLANT_NM = Datas[3];
                string COMPANY = Datas[4];
                var EXEC = R.Update_Data(ID, USERNAME, PLANT_CD, PLANT_NM, COMPANY, username);
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

    }
}
