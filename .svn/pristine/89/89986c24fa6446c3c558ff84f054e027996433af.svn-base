using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP04002Master
{
    public class WP04002Repository
    {
        #region Get_Data_Grid_WP04002
        public List<WP04002Master> getDataWP04002(int Start, int Display, string ROLE_NAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04002Master>("WP04002/WP04002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ROLE_NAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP04002
        public int getCountWP04002(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string ROLE_NAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP04002/WP04002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                ROLE_NAME
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP04002/WP04002_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP04002> Update_Data(string ID, string ROLE_NAME, string ROLE_DESC, string AUTH, string SESSION_TIME_OUT, string LOCK_TIME_OUT, string ROLE_ST, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04002>("WP04002/WP04002_Update", new
            {
                ID,
                ROLE_NAME,
                ROLE_ST,
                ROLE_DESC,
                AUTH,
                SESSION_TIME_OUT,
                LOCK_TIME_OUT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP04002> Create(string AUTH, string ROLE_NAME, string ROLE_STATUS, string ROLE_DESC, string SESSION_TIME_OUT, string LOCK_TIME_OUT, string ROLE_ST, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04002>("WP04002/WP04002_Create", new
            {
                AUTH,
                ROLE_NAME,
                ROLE_STATUS,
                ROLE_DESC,
                SESSION_TIME_OUT,
                LOCK_TIME_OUT,
                ROLE_ST,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<LocationModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP04002/WP04002_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Authorization
        public List<AuthModel> getAuthorization()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AuthModel>("WP04002/WP04002_getAuth");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class StatusModel
    {
        public string ID { get; set; }
        public string Status { get; set; }
    }

    public class AuthModel
    {
        public string ID { get; set; }
        public string AUTH_NAME { get; set; }
    }

    public class DivisionModel
    {
        public string Division { get; set; }
    }

    public class LocationModel
    {
        public string AREA_CD { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class PagingModel_WP04002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP04002(int countdata, int positionpage, int dataperpage)
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