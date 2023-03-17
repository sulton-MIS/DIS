using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03002Master
{
    public class WP03002Repository
    {
        #region Get_Data_Grid_WP03002
        public List<WP03002Master> getDataWP03002(
                                                    int Start, 
                                                    int Display, 
                                                    string TITLE, 
                                                    string EXAM_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03002Master>("WP03002/WP03002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                TITLE,
                EXAM_TYPE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03002
        public int getCountWP03002(
                                    string DATA_ID, 
                                    string TIME_UNIT_CRITERIA, 
                                    string EXECUTION_TIME, 
                                    string STATUS_ACTIVE, 
                                    string TITLE, 
                                    string EXAM_TYPE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03002/WP03002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                TITLE,
                EXAM_TYPE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03002/WP03002_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion
        
        #region Update Data
        public List<WP03002> Update_Data(
                                            string ID, 
                                            string TITLE,
                                            string PASSING_SCORE_REQUIREMENT, 
                                            string EXAM_DURATION, 
                                            string DATE_EXAM_PERIOD_START, 
                                            string DATE_EXAM_PERIOD_END, 
                                            string REMEDIAL, 
                                            string EXAM_TYPE, 
                                            string TOTAL_PUBLISHED, 
                                            string IS_PUBLISHED, 
                                            string Exam_For,
                                            string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03002>("WP03002/WP03002_Update", new
            {
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
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion


        public static List<WP03002> Create(
                                            string TITLE,
                                            string PASSING_SCORE_REQUIREMENT,
                                            string EXAM_DURATION,
                                            string DATE_EXAM_PERIOD_START,
                                            string DATE_EXAM_PERIOD_END,
                                            string REMEDIAL,
                                            string EXAM_TYPE,
                                            string TOTAL_PUBLISHED,
                                            string IS_PUBLISHED,
                                            string Exam_For,
                                            string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03002>("WP03002/WP03002_Create", new
            {
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
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
    }

    public class LocationModel
    {
        public string AREA_CD { get; set; }
        public string AREA_NAME { get; set; }
    }

    public class PagingModel_WP03002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03002(int countdata, int positionpage, int dataperpage)
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
}