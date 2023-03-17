using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP01004Master
{
    public class WP01004Repository
    {
        #region Get_Data_Grid_WP01004
        public List<WP01004Master> getDataWP01004(int Start, int Display, string WORKING_NAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01004Master>("WP01004/WP01004_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                WORKING_NAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP01004
        public int getCountWP01004(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string WORKING_NAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP01004/WP01004_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                WORKING_NAME
            });
            db.Close();
            return result;
        }
        #endregion

        public List<WorkingModel> getWorkingType(string IMPB)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WorkingModel>("WP01004/WP01004_getWorkingType", new
            {
                IMPB
            });
            db.Close();
            return d.ToList();
        }

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<string>("WP01004/WP01004_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<WP01004> Update_Data(string ID, string WORKING_NAME, string STATUS, string ICON, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01004>("WP01004/WP01004_Update", new
            {
                ID,
                WORKING_NAME,
                ICON,
                STATUS,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP01004> Create(string WORKING_NAME, string STATUS, string ICON, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01004>("WP01004/WP01004_Create", new
            {
                WORKING_NAME,
                STATUS,
                ICON,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<LocationModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP01004/WP01004_getArea");

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

    public class WorkingModel
    {
        public string ICON{ get; set; }
        public string WORKING_NAME { get; set; }
    }

    public class DivisionModel
    {
        public string Division { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
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

    public class PagingModel_WP01004
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP01004(int countdata, int positionpage, int dataperpage)
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