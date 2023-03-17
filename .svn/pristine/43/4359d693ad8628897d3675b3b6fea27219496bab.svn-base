using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP01006Master
{
    public class WP01006Repository
    {
        #region Get_Data_Grid_WP01006
        public List<WP01006Master> getDataWP01006(int Start, int Display, string COMPANY_CODE, string COMPANY_NAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01006Master>("WP01006/WP01006_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                COMPANY_CODE,
                COMPANY_NAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP01006
        public int getCountWP01006(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string COMPANY_CODE, string COMPANY_NAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP01006/WP01006_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                COMPANY_CODE,
                COMPANY_NAME
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<string>("WP01006/WP01006_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<WP01006> Update_Data(string ID, string COMPANY_CODE, string COMPANY_NAME,string COMPANY_INITIAL, string CONTACT_PERSON, string EMAIL,string ADDRESS,string PHONE, string STATUS, string FLAG, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01006>("WP01006/WP01006_Update", new
            {
                ID,
                COMPANY_CODE,
                COMPANY_NAME,
                COMPANY_INITIAL,
                CONTACT_PERSON,
                EMAIL,
                ADDRESS,
                PHONE,
                STATUS,
                FLAG,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP01006> Create(string COMPANY_CODE, string COMPANY_NAME, string COMPANY_INITIAL, string CONTACT_PERSON, string ADDRESS, string EMAIL, string PHONE, string STATUS, string FLAG, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01006>("WP01006/WP01006_Create", new
            {
                COMPANY_CODE,
                COMPANY_NAME,
                COMPANY_INITIAL,
                CONTACT_PERSON,
                ADDRESS,
                EMAIL,
                PHONE,
                STATUS,
                FLAG,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<LocationModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP01006/WP01006_getArea");

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
        public string AREA_CD { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }
    public class PagingModel_WP01006
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP01006(int countdata, int positionpage, int dataperpage)
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