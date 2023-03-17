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
using AI070.Models.WP04003Master;

namespace AI070.Controllers
{
    public class WP04003Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP04003Repository R = new WP04003Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "User Mapping";
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
                ViewData["Role"] = R.getRole();
                ViewData["USERNAME"] = R.getUsername();
                ViewData["LOCATION"] = R.getLocation();
                ViewData["AREA"] = AreaInfoRepository.Instance.GetAreaInfo();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        public ActionResult getUserData(string USERNAME)
        {
            var data = R.getUserData(USERNAME);
            return Json(new { data, USERNAME }, JsonRequestBehavior.AllowGet);
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string NOREG, string USERNAME, string EMAIL)
        {
            //Buat Paging//
            PagingModel_WP04003 pg = new PagingModel_WP04003(R.getCountWP04003(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, NOREG, USERNAME, EMAIL), start, display);

            //Munculin Data ke Grid//
            List<WP04003Master> List = R.getDataWP04003(pg.StartData, pg.EndData, NOREG, USERNAME, EMAIL).ToList();
            ViewData["DataWP04003"] = List;
            ViewData["PagingWP04003"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string NOREG, string ROLE, string USERNAME, string EMAIL, string FIRST_NAME, string LAST_NAME, string AREA, string LOCATION)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP04003Repository.Create(NOREG, USERNAME, ROLE, EMAIL, FIRST_NAME, LAST_NAME, AREA, LOCATION, username);
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
                string NOREG = Datas[1];
                string USERNAME = Datas[2];
                string ROLE = Datas[3];
                string EMAIL = Datas[4];
                string FIRST_NAME = Datas[5];
                string LAST_NAME = Datas[6];
                string AREA = Datas[7];
                string LOCATION = Datas[8];
                var EXEC = R.Update_Data(
                    ID, 
                    NOREG,
                    USERNAME,
                    ROLE,
                    EMAIL,
                    FIRST_NAME,
                    LAST_NAME,
                    AREA,
                    LOCATION,
                    username);
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
