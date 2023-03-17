using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP04004Master
{
    public class WP04004Repository
    {
        #region Get_Data_Grid_WP04004
        public List<WP04004Master> getDataWP04004(int Start, int Display, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04004Master>("WP04004/WP04004_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP04004
        public int getCountWP04004(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string USERNAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP04004/WP04004_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                USERNAME
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP04004/WP04004_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP04004> Update_Data(string ID, string USERNAME, string PLANT_CD, string PLANT_NM, string COMPANY, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04004>("WP04004/WP04004_Update", new
            {
                ID,
                PLANT_CD,
                PLANT_NM,
                USERNAME,
                COMPANY,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP04004> Create(string USERNAME, string PLANT_CD, string PLANT_NM, string COMPANY, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04004>("WP04004/WP04004_Create", new
            {
                USERNAME,
                PLANT_CD,
                PLANT_NM,
                COMPANY,
                username
            });
            db.Close();
            return d.ToList();
        }

        #region Get Plant
        public List<PlantModel> getPlant()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<PlantModel>("WP04004/WP04004_getPlant");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Company
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("WP04004/WP04004_getCompany");

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

    public class PlantModel
    {
        public string ID { get; set; }
        public string PLANT_CD { get; set; }
        public string PLANT_DESC { get; set; }
    }

    public class CompanyModel
    {
        public string ID { get; set; }
        public string COMPANY { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class PagingModel_WP04004
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP04004(int countdata, int positionpage, int dataperpage)
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