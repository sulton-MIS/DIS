using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.WP03013
{
    public class WP03013Repository
    {
        #region Get ANZEN
        public List<AnzenModel> getAnzen(string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AnzenModel>("WP03008/WP03008_getAnzen", new { username });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region get training modul

        public List<TrainingModul> GetTrainingModuls()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<TrainingModul>("WP03013/WP03013_GetTrainingModul");
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03008
        public int getCountWP03013(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string EMPLOYEE_NAME, string IDENTITYNUMBER, string COMPANY, string ANZENNO, string INDUCTION)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03008/WP03008_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                EMPLOYEE_NAME,
                IDENTITYNUMBER,
                COMPANY,
                ANZENNO,
                INDUCTION
            });
            db.Close();
            return result;
        }
        #endregion

        #region GetTrainingModuleDetail

        //WP03013_GetTrainingDetail
        public TrainingModul GetTrainingDetailById(int id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var trainingModul = db.SingleOrDefault<TrainingModul>("WP03013/WP03013_GetTrainingDetail", new
            {
                Id = id
            });
            db.Close();
            return trainingModul;
        }

       
        #endregion

        public class PagingModel_WP03013
        {
            public int CountData { get; set; }
            public int StartData { get; set; }
            public int EndData { get; set; }
            public int PositionPage { get; set; }
            public List<int> ListIndex { get; set; }
            public PagingModel_WP03013(int countdata, int positionpage, int dataperpage)
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

        public class AnzenModel
        {
            public string ANZEN_NO { get; set; }
            public string ANZEN_FROM { get; set; }
            public string ANZEN_TO { get; set; }
        }


    }
}