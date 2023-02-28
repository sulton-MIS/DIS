using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AI070.Models.WP03007;
using AI070.Models.WP03008Master;
using AI070.Models.WP03013;
using Toyota.Common.Web.Platform;
using static AI070.Models.WP03013.WP03013Repository;

namespace AI070.Controllers.WP03007
{
    public class WP03007Controller : PageController
    {
        private WP03007Repository db = new WP03007Repository();
        private WP03008Repository r = new WP03008Repository();
        private WP03013Repository dbW = new WP03013Repository();

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Exam";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult SearchData(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string EMPLOYEE_NAME, string IDENTITYNUMBER, string ANZENNO, string INDUCTION)
        {
            string COMPANY = Lookup.Get<Toyota.Common.Credential.User>().Company.Id;
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            ANZENNO = r.getAnzen(username).Count() > 0 ? (r.getAnzen(username)[0].ANZEN_NO).ToString() : "";

            PagingModel_WP03013 pg = new PagingModel_WP03013(dbW.getCountWP03013(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, EMPLOYEE_NAME, IDENTITYNUMBER, COMPANY, ANZENNO, INDUCTION), start, display);

            //Munculin Data ke Grid//
            List<WP03008Master> List = r.getDataWP03008(pg.StartData, pg.EndData, EMPLOYEE_NAME, IDENTITYNUMBER, COMPANY, ANZENNO, INDUCTION).ToList();
            ViewData["DataWP03008"] = List;
            ViewData["PagingWP03008"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #region Data Header 
        public void GetDataHeader()
        {
            try
            {
                ViewData["COMPANY"] = r.getCompany();
                ViewData["EXECUTOR"] = r.getExecutor();
                ViewData["IDENTITY"] = r.getIdentity();
                ViewData["SECTION"] = r.getSection("TMMIN");
                ViewData["PIC"] = r.getPIC();
                ViewData["Division"] = r.getDivision();
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = Models.UserInfoRepository.Instance.GetUserInfo(username);

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion 

        public ActionResult Start(int UserId, int SubjectId)
        {
            MasterEmployee userData = db.GetMasterEmployee(UserId);
            MasterExamSubject quest = db.GetExamSubjectActive(SubjectId);
            List<MasterExamQuestion> data = db.GetExamQuestionActive(SubjectId).OrderBy(x => x.Id).ToList();

            if (quest.ExamType == "Random")
            {
                Random rng = new Random();
                int n = data.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    MasterExamQuestion value = data[k];
                    data[k] = data[n];
                    data[n] = value;
                }
            }

            ViewBag.Breadcum = quest.Title;
            ViewBag.User = (userData.Name);
            ViewData["SubjectId"] = quest.Id;
            ViewData["UserId"] = userData.Id;
            ViewData["examDuration"] = (int)Math.Abs((quest.ExamPeriodEnd - DateTime.Now).TotalMinutes) > (int)quest.ExamDuration ? (int)quest.ExamDuration : (int)Math.Abs((quest.ExamPeriodEnd - DateTime.Now).TotalMinutes);
            return View(data);
        }

        public ActionResult Finish(int UserId)
        {
            MasterEmployee userData = db.GetMasterEmployee(UserId);
            MasterExamScore userScore = db.GetExamScore(UserId);

            ViewBag.User = (userData.Name);
            ViewData["UserId"] = userData.Id;
            return View(userScore);
        }
        public ActionResult ExamPortal(int id)
        {
            //int UserId = int.Parse(Session["WP_ID_TB_M_EMPLOYEE"].ToString());

            MasterEmployee userData = db.GetMasterEmployee(id);
            List<MasterExamSubject> quest = db.GetListExamSubjectActive(id);

            ViewBag.User = (userData.Name);
            ViewData["UserId"] = userData.Id;
            return View(quest);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Step(List<ExamAnswerDTO> answerList, int subjectId, int userId, int timeElapased)
        {

            MasterEmployee employeData = db.GetMasterEmployee(userId);
            MasterExamSubject subjectData = db.GetExamSubjectActive(subjectId);
            List<MasterExamQuestion> data = db.GetExamQuestionActive(subjectId);

            var compar = data
                    .Join(
                        answerList,
                        m => m.Id,
                        r => r.Id,
                        (m, r) => new
                        {
                            r.Id,
                            r.No,
                            realKey = m.AnswerUserChoose,
                            answer = r.AnswerUserChoose,
                            choose = (r.AnswerUserChoose == m.AnswerChoice_A ? "A" 
                                    : (r.AnswerUserChoose == m.AnswerChoice_B ? "B" 
                                    : (r.AnswerUserChoose == m.AnswerChoice_C ? "C"
                                    : (r.AnswerUserChoose == m.AnswerChoice_D ? "D"
                                    : (r.AnswerUserChoose == m.AnswerChoice_E ? "E"
                                    : "NOT_ANSWER")))))
                        }
                    ).OrderBy(x => x.No).ToList();

            int varTrue = 0;
            int varFalse = 0;
            int varNull = 0;

            string answer = String.Empty;


            foreach (var i in compar)
            {
                answer = answer + ", " + i.Id + "_" + i.No + "_" + i.choose;

                if (String.IsNullOrWhiteSpace(i.answer))
                {
                    varNull++;
                }
                else if (i.answer.Equals(i.realKey))
                {
                    varTrue++;
                }
                else
                {
                    varFalse++;
                }
            }

            answer = answer.Remove(0, 2);

            int total_exam = varTrue + varFalse + varNull; //total real exam 
            int total_published = subjectData.TOTAL_PUBLISHED; //total exam published --> tidak digunakan hanya untuk compare jumlah soal publish dengan real exam
            int score = ((varTrue * 100) / total_exam); //Score
            string status = score >= subjectData.PassingScore ? "PASS" : "NOT PASS";

            db.CreateExamScore(new MasterExamScore
            {
                EmployeeId = employeData.Id,
                SubjectId = subjectData.Id,
                CompanyId = employeData.CompanyId,
                Answer = answer,
                CorrectAmount = varTrue,
                WrongAmount = varFalse,
                NotAnswerAmount = varNull,
                PassGraduate = subjectData.PassingScore,
                Score = score,
                Timer = (int)(timeElapased / 60),
                SubmitDate = DateTime.Now,
                Status = status
            });

            return Json("Sukses");
        }

    }
}