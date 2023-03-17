﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP01002Master;

namespace AI070.Controllers
{
    public class WP01002Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP01002Repository R = new WP01002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Area";
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


        public ActionResult MoveFile()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                //saveFile = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                resultFilePath = Path.Combine("~/Content/Upload/Area", Request.Form["AREA_CD"] + filename);
                file.SaveAs(Server.MapPath(resultFilePath));
            }

            return Json(new { resultFilePath });
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                ViewData["UploadSize"] = R.getUploadSize()[0].SIZE;
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string AREA_CODE, string AREA_NAME)
        {
            //Buat Paging//
            PagingModel_WP01002 pg = new PagingModel_WP01002(R.getCountWP01002(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, AREA_CODE, AREA_NAME), start, display);

            //Munculin Data ke Grid//
            List<WP01002Master> List = R.getDataWP01002(pg.StartData, pg.EndData, AREA_CODE, AREA_NAME).ToList();
            ViewData["DataWP01002"] = List;
            ViewData["PagingWP01002"] = pg;
            ViewData["UploadSize"] = R.getUploadSize()[0].SIZE;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string AREA_CODE, string AREA_NAME, string AREA_STATUS, string EXT)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP01002Repository.Create(AREA_CODE, AREA_NAME, AREA_STATUS, EXT, username);
                sts = Exec[0].STACK;
                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004","Master Area","", "");
                    message = res[0].MSG_TEXT;
                }
                else if(Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Area", "","");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
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
                string AREA_CODE = Datas[1];
                string AREA_NAME = Datas[2];
                string AREA_ST = Datas[3];
                string EXT = Datas[4];
                var EXEC = R.Update_Data(ID, AREA_CODE, AREA_NAME, AREA_ST, EXT, username);
                sts = EXEC[0].STACK;
                if (EXEC[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Area", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Area", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }

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
            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R.Delete_Data(Datas[i], username);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Area", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
