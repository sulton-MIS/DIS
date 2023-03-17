using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03003Master
{
    public class WP03003Repository
    {
        #region Get_Data_Grid_WP03003
        public List<WP03003Master> GetManageQuestionList(int pageNumber, int display, int subjectId)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var items = db.Fetch<WP03003Master>("WP03003/WP03003_SearchData", new
            {
                pageNumber,
                display,
                subjectId
            });
            db.Close();
            return items.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03003
        public int GetCountManageQuestion(int subjectId)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03003/WP03003_SearchCount", new { subjectId });
            db.Close();
            return result;
        }
        #endregion

        public List<ExamSubjectModel> GetExamSubject()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamSubjectModel>("WP03003/WP03003_getExamSubject");

            db.Close();
            return d.ToList();
        }

        #region Get Category
        public List<CategoryModel> getCategory()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CategoryModel>("WP03001/WP03001_getQuestionBankCategory");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Detail Exam Subject
        public List<ExamDetailSubjectModel> GetDetailExamSubject(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamDetailSubjectModel>("WP03003/WP03003_getDetailExamSubject", new
            {
                ID
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Detail Question Bank
        public List<ExamDetailQuestionBank> GetDetailQuestionBank(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamDetailQuestionBank>("WP03003/WP03003_getDetailQuestionBank", new
            {
                ID
            });

            db.Close();
            return d.ToList();
        }

        #endregion

        public List<ExamDetailQuestionBank> GetQuestionBySelectedSubject(int ID, string question, string category)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamDetailQuestionBank>("WP03003/WP03003_getDetailQuestionBySubject", new
            {
                ID,
                question,
                category
            });

            db.Close();
            return d.ToList();
        }

        public List<ExamDetailQuestionBank> GetQuestionCategory()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamDetailQuestionBank>("WP03003/WP03003_getQuestionBankCategory", new { });

            db.Close();
            return d.ToList();
        }

        public List<ExamDetailQuestionBank> GetQuestionByUnselectedSubject(int ID, string question, string category)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamDetailQuestionBank>("WP03003/WP03003_getDetailQuestionByUnselectedSubject", new
            {
                ID,
                question,
                category
            });

            db.Close();
            return d.ToList();
        }

        public int FindData(string IDSUBJECT, string IDQUESTION)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03003/WP03003_CountExamQuestionByRelation", new
            {
                IDSUBJECT,
                IDQUESTION
            });
            db.Close();
            return result;
        }

        public static ExamSubjectModel Create(string IDSUBJECT, string IDQUESTION, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExamSubjectModel>("WP03003/WP03003_Create", new
            {
                IDSUBJECT,
                IDQUESTION,
                USERNAME
            }).FirstOrDefault();
            db.Close();

            return d;
        }

        public void MoveData(string IDSUBJECT, string IDQUESTIONS, string USERNAME, bool removeFromExamSubject)
        {
            //IDQUESTIONS berupa inline Id
            string ISDELETED = "";

            if (removeFromExamSubject)
            {
                ISDELETED = "1";
            }
            else
            {
                var IdQuestions = IDQUESTIONS.Split(',');

                foreach (var Id in IdQuestions)
                {
                    var n = FindData(IDSUBJECT, Id);

                    if (n == 0)
                    {
                        var tempData = Create(IDSUBJECT, Id, USERNAME);
                    }
                }

                ISDELETED = "0";
            }

            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03003/WP03003_Delete", new
            {
                ISDELETED,
                IDSUBJECT,
                IDQUESTIONS
            });
            db.Close();
        }

    }

    #region Exam Subject Model
    public class ExamSubjectModel
    {
        public string ID { get; set; }
        public string TITLE { get; set; }
    }
    #endregion

    #region Question Bank Model
    public class QuestionBankModel
    {
        public string ID { get; set; }
        public string ANSWER_KEY { get; set; }
    }
    #endregion

    #region Exam Detail Subject Model
    public class ExamDetailSubjectModel
    {
        public string ID { get; set; }
        public string TITLE { get; set; }
        public string PASSING_SCORE_REQUIREMENT { get; set; }
        public string EXAM_DURATION { get; set; }
        public string DATE_START { get; set; }
        public string DATE_END { get; set; }
        public string REMEDIAL { get; set; }
        public string EXAM_TYPE { get; set; }
        public string TOTAL_PUBLISHED { get; set; }
        public string IS_PUBLISHED { get; set; }
    }
    #endregion

    #region Exam Detail Question Bank
    public class ExamDetailQuestionBank
    {
        public string ID { get; set; }
        public string QUESTION { get; set; }
        public string ANSWER_CHOICE_A { get; set; }
        public string ANSWER_CHOICE_B { get; set; }
        public string ANSWER_CHOICE_C { get; set; }
        public string ANSWER_CHOICE_D { get; set; }
        public string ANSWER_CHOICE_E { get; set; }
        public string ANSWER_KEY { get; set; }
        public string CATEGORY { get; set; }
    }
    #endregion

    #region Paging Model
    public class PagingModel_WP03003
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03003(int countdata, int positionpage, int dataperpage)
        {
            List<int> list = new List<int>();
            EndData = positionpage * dataperpage;
            CountData = countdata;
            PositionPage = positionpage;
            StartData = (positionpage - 1) * dataperpage + 1;
            Double jml = countdata / dataperpage;
            if (countdata % dataperpage > 0)
            {
                jml = jml + 1;
            }

            for (int i = 0; i < jml; i++)
            {
                list.Add(i);
            }
            ListIndex = list;
        }
    }
    #endregion

    #region Category Model
    public class CategoryModel
    {
        public string SYSTEM_ID { get; set; }
        public string SYSTEM_TYPE { get; set; }
        public string ID { get; set; }
        public string CATEGORY { get; set; }
        public string SYSTEM_VALID_FR { get; set; }
        public string SYSTEM_VALID_TO { get; set; }
    }
    #endregion

}