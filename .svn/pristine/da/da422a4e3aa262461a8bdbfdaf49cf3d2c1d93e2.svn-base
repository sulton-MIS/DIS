using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP0101Master
{
    public class WP0101Repository
    {
        #region Get_Data_Grid_WP0101
        public List<WP0101Master> getDataWP0101(int Start, int Display, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_TIME, string PROJECT_TIMETO, string STATUS)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP0101Master>("WP0101/WP0101_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                PROJECT_NAME,
                PROJECT_LOCATION,
                PROJECT_DATE,
                PROJECT_DATETO,
                DIVISION,
                PROJECT_TIME,
                PROJECT_TIMETO,
                STATUS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP0101
        public int getCountWP0101(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP0101/WP0101_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP0101/WP0101_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP0101> Update_Data(string ID, string PROJECT_CODE, string PROJECT_NAME, string LOCATION, string DATE, string TIME, string DIVISION, string EXECUTOR, string CONTRACTOR, string LEADER, string SUPERVISOR, string STATUS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP0101>("WP0101/WP0101_Update", new
            {
                ID,
                PROJECT_CODE,
                PROJECT_NAME,
                LOCATION,
                DATE,
                TIME,
                DIVISION,
                EXECUTOR,
                CONTRACTOR,
                LEADER,
                SUPERVISOR,
                STATUS,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP0101> Create(string PROJECT_CODE, string PROJECT_NAME, string LOCATION, string DATE, string TIME, string DIVISION, string EXECUTOR, string CONTRACTOR, string LEADER_NAME, string SUPERVISOR_NAME, string STATUS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP0101>("WP0101/WP0101_Create", new
            {
                PROJECT_CODE,
                PROJECT_NAME,
                LOCATION,
                DATE,
                TIME,
                DIVISION,
                EXECUTOR,
                CONTRACTOR,
                LEADER_NAME,
                SUPERVISOR_NAME,
                STATUS,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("WP0101/WP0101_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP0101/WP0101_getLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Status
        public List<StatusModel> getStatus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<StatusModel>("WP0101/WP0101_getStatus");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExecutorModel>("WP0101/WP0101_getExecutor");

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

    public class DivisionModel
    {
        public string Division { get; set; }
    }

    public class LocationModel
    {
        public string Loc_ID { get; set; }
        public string Location { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class PagingModel_WP0101
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP0101(int countdata, int positionpage, int dataperpage)
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