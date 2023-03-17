using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP01003Master
{
    public class WP01003Repository
    {
        #region Get_Data_Grid_WP01003
        public List<WP01003Master> getDataWP01003(int Start, int Display, string AREA_CODE, string LOC_NAME, string LOC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01003Master>("WP01003/WP01003_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                AREA_CODE,
                LOC_NAME,
                LOC_CODE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP01003
        public int getCountWP01003(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string AREA_CODE, string LOC_NAME, string LOC_CODE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP01003/WP01003_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                AREA_CODE,
                LOC_NAME,
                LOC_CODE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<string>("WP01003/WP01003_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<WP01003> Update_Data(string ID, string AREA_CODE, string LOC_CD, string LOC_NAME, string STATUS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01003>("WP01003/WP01003_Update", new
            {
                ID,
                AREA_CODE,
                LOC_CD,
                LOC_NAME,
                STATUS,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP01003> Create(string AREA_CODE, string LOC_CD, string LOC_NAME, string STATUS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01003>("WP01003/WP01003_Create", new
            {
                AREA_CODE,
                LOC_CD,
                LOC_NAME,
                USERNAME,
                STATUS
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<AreaModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AreaModel>("WP01003/WP01003_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP01003/WP01003_getLocation");

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
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    public class AreaModel
    {
        public string AREA_CD { get; set; }
        public string AREA_ID { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class PagingModel_WP01003
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP01003(int countdata, int positionpage, int dataperpage)
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