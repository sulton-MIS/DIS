using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03001Master
{
    public class WP03001Repository
    {
        #region Get_Data_Grid_WP03001
        public List<WP03001Master> getDataWP03001(
                                                    int Start,
                                                    int Display,
                                                    string QUESTION,
                                                    string ANSWER_KEY)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03001Master>("WP03001/WP03001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                QUESTION,
                ANSWER_KEY
            });
            db.Close();
            return d.ToList();
        }

        public WP03001Master GetQuestion(int Id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03001Master>("WP03001/WP03001_SearchData", new
            {
                ID_TB_M_LEARN_QUESTION = Id
            });
            db.Close();
            return d.FirstOrDefault();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03001
        public int getCountWP03001(
                                    string DATA_ID,
                                    string TIME_UNIT_CRITERIA,
                                    string EXECUTION_TIME,
                                    string STATUS_ACTIVE,
                                    string QUESTION,
                                    string ANSWER_KEY)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03001/WP03001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                QUESTION,
                ANSWER_KEY
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03001/WP03001_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP03001> Update_Data(
                                            string ID,
                                            string QUESTION,
                                            string Category,
                                            string ANSWER_CHOICE_A,
                                            string ANSWER_CHOICE_B,
                                            string ANSWER_CHOICE_C,
                                            string ANSWER_CHOICE_D,
                                            string ANSWER_CHOICE_E,
                                            string ANSWER_KEY,
                                            string IMAGE,
                                            string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03001>("WP03001/WP03001_Update", new
            {
                ID,
                QUESTION,
                Category,
                ANSWER_CHOICE_A,
                ANSWER_CHOICE_B,
                ANSWER_CHOICE_C,
                ANSWER_CHOICE_D,
                ANSWER_CHOICE_E,
                ANSWER_KEY,
                IMAGE,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Create
        public static List<WP03001> Create(
                                        string CATEGORY,
                                        string QUESTION,
                                        string ANSWER_CHOICE_A,
                                        string ANSWER_CHOICE_B,
                                        string ANSWER_CHOICE_C,
                                        string ANSWER_CHOICE_D,
                                        string ANSWER_CHOICE_E,
                                        string ANSWER_KEY,
                                        string IMAGE,
                                        string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03001>("WP03001/WP03001_Create", new
            {
                CATEGORY,
                QUESTION,
                ANSWER_CHOICE_A,
                ANSWER_CHOICE_B,
                ANSWER_CHOICE_C,
                ANSWER_CHOICE_D,
                ANSWER_CHOICE_E,
                ANSWER_KEY,
                IMAGE,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Category
        public List<CategoryModel> getCategory()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CategoryModel>("WP03001/WP03001_getQuestionBankCategory");

            db.Close();
            return d.ToList();
        }
        #endregion

    }


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

    #region Paging Model
    public class PagingModel_WP03001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03001(int countdata, int positionpage, int dataperpage)
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

}