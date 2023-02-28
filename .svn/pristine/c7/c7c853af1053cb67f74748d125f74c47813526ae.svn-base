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
using AI070.Models.WP03003Master;

namespace AI070.Controllers
{
    public class WP03003Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03003Repository repo = new WP03003Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Manage Question on Exam";
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
                ViewData["ExamSubject"] = repo.GetExamSubject();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Get Detail Exam Subject
        public ActionResult GetDetailExamSubject(string ID)
        {
            var sts = new object();
            var message = new object();
            try
            {
                var Exec = repo.GetDetailExamSubject(ID);
                sts = "TRUE";
                message = Exec;
            }
            catch (Exception M)
            {
                sts = "Err";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //#region Get Detail Exam Subject
        //public ActionResult GetDetailQuestionBank(string ID)
        //{
        //    var sts = new object();
        //    var message = new object();
        //    try
        //    {
        //        var Exec = repo.GetDetailQuestionBank(ID);
        //        sts = "TRUE";
        //        message = Exec;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "Err";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        #region Search Data
        [HttpGet]
        public ActionResult Search_Data(int start, int display, int subjectId)
        {
            PagingModel_WP03003 pg = new PagingModel_WP03003(repo.GetCountManageQuestion(subjectId), start, display);

            List<WP03003Master> manageQuestions = repo.GetManageQuestionList(start, display, subjectId);

            ViewData["DataWP03003"] = manageQuestions;
            ViewData["PagingWP03003"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        [HttpPost]
        public ActionResult Move(string IdSubject, string IdQuestions, bool removeFromSubject)
        {
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                repo.MoveData(IdSubject, IdQuestions, username, removeFromSubject);

                sts = "TRUE";
                message = "Data has been successfully Move";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            Settings.Title = "Manage Question";
            ViewData["Title"] = Settings.Title;
            GetDataHeader();

            ExamDetailSubjectModel examSubject = repo.GetDetailExamSubject(id.ToString()).FirstOrDefault();

            ViewData["DetailSubject"] = examSubject;
            return View("Edit");
        }

        [HttpGet]
        public virtual ActionResult QuestionTableSelected(int id, string question, string category)
        {
            List<ExamDetailQuestionBank> questionSelected = repo.GetQuestionBySelectedSubject(id, question, category);

            ViewBag.identifyId = "LeftSide";
            ViewBag.QuestionBlockTitle = "Soal yang terpilih";
            return PartialView("QuestionTable", questionSelected);
        }

        [HttpGet]
        public virtual ActionResult QuestionTableUnSelected(int id, string question, string category)
        {
            List<ExamDetailQuestionBank> questionUnselected = repo.GetQuestionByUnselectedSubject(id, question, category);

            ViewBag.identifyId = "RightSide";
            ViewBag.QuestionBlockTitle = "Soal yang tersedia";
            return PartialView("QuestionTable", questionUnselected);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult QuestionFilter(string identifyId)
        {
            ViewBag.identifyId = identifyId;
            ViewData["CATEGORY"] = repo.getCategory();
            return PartialView("QuestionFilter", ViewData["CATEGORY"]);
        }
    }
}
