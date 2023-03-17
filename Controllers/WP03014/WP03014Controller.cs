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
using AI070.Models.WP03014Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class WP03014Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03014Repository R = new WP03014Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        #region Startup
        protected override void Startup()
        {
            try
            {
                Settings.Title = "Register Worker in Project";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }
        #endregion

        #region Generate Message
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
        #endregion

        #region Get Data Header
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
                                        String Worker,
                                        String Project,
                                        String Company
                                        )
        {
            //Buat Paging//
            PagingModel_WP03014 pg = new PagingModel_WP03014(
                                                              R.getCountWP03014(),
                                                              start,
                                                              display
                                                            );

            //Munculin Data ke Grid//
            List<WP03014Master> List = R.getDataWP03014(pg.StartData, pg.EndData, Worker, Project, Company).ToList();
            ViewData["DataWP03014"] = List;
            ViewData["PagingWP03014"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add
        [HttpGet]
        public virtual ActionResult Add()
        {
            ViewBag.form_type = "New";
            Settings.Title = "Add Worker in Project";
            ViewData["Title"] = Settings.Title;
            ViewData["WORKER_LIST"] = R.getWorker();
            ViewData["PROJECT_LIST"] = R.getProject();
            ViewData["COMPANY_LIST"] = R.getCompany();
            return PartialView("ADD_EDIT");
        }
        #endregion

        #region Insert
        
        [HttpPost]
        public virtual ActionResult Insert(
                                            string Worker
                                            , string Project
                                            , string Company
                                            , string JoinDate
                                            , string Company_from
                                            , string Company_to
                                            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

                var Exec = WP03014Repository.Insert(
                                                        Worker
                                                        , Project
                                                        , Company
                                                        , JoinDate
                                                        , Company_from
                                                        , Company_to
                                                        , username);
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

        #region Edit
        [HttpGet]
        public virtual ActionResult Edit(
                                            string ID
                                            , string Worker
                                            , string Project
                                            , string Company
                                            , string JoinDate
                                            , string Company_from
                                            , string Company_to
                                         )
        {
            ViewBag.form_type = "Edit";
            Settings.Title = "Edit Worker in Project";
            ViewData["Title"] = Settings.Title;
            ViewData["WORKER_LIST"] = R.getWorker();
            ViewData["PROJECT_LIST"] = R.getProject();
            ViewData["COMPANY_LIST"] = R.getCompany();

            ViewBag.ID = ID;
            ViewBag.Worker = Worker;
            ViewBag.Project = Project;
            ViewBag.Company = Company;
            ViewBag.JoinDate = JoinDate;
            ViewBag.Company_from = Company_from;
            ViewBag.Company_to = Company_to;

            return PartialView("ADD_EDIT");
        }
        #endregion

        #region Update Data
        [HttpPost]
        public ActionResult Update(string DATA)
        {
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string Worker = Datas[1];
                string Project = Datas[2];
                string Company = Datas[3];
                string JoinDate = Datas[4];
                string Company_from = Datas[5];
                string Company_to = Datas[6];

                var EXEC = R.Update_Data(
                                            ID,
                                            Worker,
                                            Project,
                                            Company,
                                            JoinDate,
                                            Company_from,
                                            Company_to,
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
