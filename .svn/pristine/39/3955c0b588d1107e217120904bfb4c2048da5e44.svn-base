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
using AI070.Models.WP03002Master;

namespace AI070.Controllers
{
    public class WP03002Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03002Repository R = new WP03002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Exam Subject";
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
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(
                                        int start, 
                                        int display, 
                                        string DATA_ID, 
                                        string EXECUTION_TIME, 
                                        string TIME_UNIT_CRITERIA, 
                                        string STATUS_ACTIVE, 
                                        string TITLE, 
                                        string EXAM_TYPE)
        {
            //Buat Paging//
            PagingModel_WP03002 pg = new PagingModel_WP03002(R.getCountWP03002(
                                                                                DATA_ID, 
                                                                                EXECUTION_TIME, 
                                                                                TIME_UNIT_CRITERIA, 
                                                                                STATUS_ACTIVE,
                                                                                TITLE,
                                                                                EXAM_TYPE), 
                                                                start, display);

            //Munculin Data ke Grid//
            List<WP03002Master> List = R.getDataWP03002(pg.StartData, pg.EndData, TITLE, EXAM_TYPE).ToList();
            ViewData["DataWP03002"] = List;
            ViewData["PagingWP03002"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(
            string TITLE,
            string PASSING_SCORE_REQUIREMENT,
            string EXAM_DURATION,
            string DATE_EXAM_PERIOD_START,
            string DATE_EXAM_PERIOD_END,
            string REMEDIAL,
            string EXAM_TYPE,
            string TOTAL_PUBLISHED,
            string IS_PUBLISHED,
            string Exam_For
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP03002Repository.Create(
                                                        TITLE,
                                                        PASSING_SCORE_REQUIREMENT,
                                                        EXAM_DURATION,
                                                        DATE_EXAM_PERIOD_START,
                                                        DATE_EXAM_PERIOD_END,
                                                        REMEDIAL,
                                                        EXAM_TYPE,
                                                        TOTAL_PUBLISHED,
                                                        IS_PUBLISHED,
                                                        Exam_For,
                                                        username);
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
                string TITLE = Datas[1];
                string PASSING_SCORE_REQUIREMENT = Datas[2];
                string EXAM_DURATION = Datas[3];
                string DATE_EXAM_PERIOD_START = Datas[4];
                string DATE_EXAM_PERIOD_END = Datas[5];
                string REMEDIAL = Datas[6];
                string EXAM_TYPE = Datas[7];
                string TOTAL_PUBLISHED = Datas[8];
                string IS_PUBLISHED = Datas[9];
                string Exam_For = Datas[10];


                var EXEC = R.Update_Data(
                                            ID,
                                            TITLE,
                                            PASSING_SCORE_REQUIREMENT,
                                            EXAM_DURATION,
                                            DATE_EXAM_PERIOD_START,
                                            DATE_EXAM_PERIOD_END,
                                            REMEDIAL,
                                            EXAM_TYPE,
                                            TOTAL_PUBLISHED,
                                            IS_PUBLISHED,
                                            Exam_For,
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
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
