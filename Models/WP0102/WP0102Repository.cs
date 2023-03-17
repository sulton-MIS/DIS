using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP0102Master
{
    public class WP0102Repository
    {
        #region Get_Data_Grid_WP0102
        public List<WP0102Master> getDataWP0102(int Start, int Display, string PROJECT_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP0102Master>("WP0102/WP0102_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                PROJECT_CODE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP0102
        public int getCountWP0102(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string PROJECT_CODE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP0102/WP0102_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                PROJECT_CODE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP0102/WP0102_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP0102> Update_Data(string ID, string PROJECT_CODE, string LOCATION, string JOBS, string LOWLEVEL, string MEDIUMLEVEL, string HIGHLEVEL, string DATE, string CATEGORY, string REMARKS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP0102>("WP0102/WP0102_Update", new
            {
                ID,
                PROJECT_CODE,
                LOCATION,
                JOBS,
                LOWLEVEL,
                MEDIUMLEVEL,
                HIGHLEVEL,
                DATE,
                CATEGORY,
                REMARKS,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP0102> Create(string PROJECT_CODE, string LOCATION, string JOBS, string DANGERLEVEL, string DATE, string CATEGORY, string REMARKS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP0102>("WP0102/WP0102_Create", new
            {
               PROJECT_CODE,
               LOCATION,
               JOBS,
               DANGERLEVEL,
               DATE,
               CATEGORY,
               REMARKS,
               USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("WP0102/WP0102_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public static List<LocationModel> getLocation(string PROJECT_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP0102/WP0102_getLocation", new { 
                PROJECT_CODE
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Code
        public List<ProjectCodeModel> getProjectCode()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ProjectCodeModel>("WP0102/WP0102_getProjectCode");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Code
        public List<JobsModel> getJobs()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<JobsModel>("WP0102/WP0102_getJobs");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Code
        public List<LocationModel> getDataLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP0102/WP0102_getDataLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Code
        public List<CategoryModel> getCategory()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CategoryModel>("WP0102/WP0102_getCategory");

            db.Close();
            return d.ToList();
        }
        #endregion


        #region Get Status
        public List<StatusModel> getStatus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<StatusModel>("WP0102/WP0102_getStatus");

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

    public class ProjectCodeModel
    {
        public string Project_CD { get; set; }
    }

    public class DivisionModel
    {
        public string Division { get; set; }
    }

    public class JobsModel
    {
        public string Jobs { get; set; }
    }

    public class CategoryModel
    {
        public string Category { get; set; }
    }

    public class LocationModel
    {
        public string Loc_ID { get; set; }
        public string Location { get; set; }
    }

    public class PagingModel_WP0102
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP0102(int countdata, int positionpage, int dataperpage)
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