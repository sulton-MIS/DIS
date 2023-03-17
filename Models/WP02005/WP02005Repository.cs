using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using AI070.Models.WP02005;
using System.Runtime.CompilerServices;

namespace AI070.Models.WP02005Master
{
    public class WP02005Repository
    {
        #region Get_Data_Grid_WP02005
        public List<WP02005Master> getDataWP02005(int Start, int Display, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_CODE, string WP_IMPB_NO, string COMPANY)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02005Master>("WP02005/WP02005_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                PROJECT_NAME,
                PROJECT_LOCATION,
                PROJECT_DATE,
                PROJECT_DATETO,
                DIVISION,
                PROJECT_CODE,
                WP_IMPB_NO,
                COMPANY
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP02005
        public int getCountWP02005(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_CODE, string WP_IMPB_NO, string COMPANY)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP02005/WP02005_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                PROJECT_NAME,
                PROJECT_LOCATION,
                PROJECT_DATE,
                PROJECT_DATETO,
                DIVISION,
                PROJECT_CODE,
                WP_IMPB_NO,
                COMPANY
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("WP02001/WP02001_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Company
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("WP02001/WP02001_getCompany");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP02001/WP02001_getLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP02005InputForm> SubmitRating(WP02005InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<WP02005InputForm>("WP02005/WP02005_SubmitData", new
            {
                items.WP_PROJECT_ID,
                items.WP_PROJECT_JOB_ID,
                items.INCIDENT_TITLE,
                items.INCIDENT_DESCRIPTION,
                items.SUPPORT_PHOTO,
                items.SUPPORT_DOC,
                items.RATING_CONTRACTOR,
                items.RATING_LEADER,
                items.RATING_SUPERVISOR,
                items.RATING_WORKER,
                items.EVALUATION_NOTES,
                username
            });

            foreach(var data in items.ItemCheckList)
            {
                db.Fetch<ItemCheckModel>("WP02005/WP02005_ProcessItemCheck", new
                {
                    data.ID
                   ,data.WP_PROJECT_JOB_ID
                   ,data.ITEM_NAME
                   ,data.ITEM_DESCRIPTION
                   ,data.ID_TB_M_EMPLOYEE
                   ,data.ITEM_STATUS
                   ,username
                });
            }
            
            db.Close();
            return hdr.ToList();
        }

        public static IncidentModel ProcessIncident(IncidentModel items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<IncidentModel>("WP02005/WP02005_ProcessIncident", new
            {
               items.ID
               ,items.WP_PROJECT_JOB_ID
               ,items.INCIDENT_TITLE
               ,items.ID_TB_M_EMPLOYEE
               ,items.ID_TB_M_COMPANY
               ,items.ID_TB_M_AREA
               ,items.INCIDENT_DATE
               ,items.INCIDENT_LEVEL
               ,items.ATTACHMENT
               ,items.USER_REPORT
               ,items.ACTION
               ,username
            });

            //db.Fetch<IncidentModel>("WP02005/WP02005_SubmitData", new
            //{
            //    items.WP_PROJECT_JOB_ID,
            //    username
            //});

            db.Close();
            return hdr.ToList().FirstOrDefault();
        }

        public static ItemCheckModel ProcessItemCheck(ItemCheckModel items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<ItemCheckModel>("WP02005/WP02005_ProcessItemCheck", new
            {
                items.ID
               ,items.WP_PROJECT_JOB_ID
               ,items.ITEM_NAME
               ,items.ITEM_DESCRIPTION
               ,items.ID_TB_M_EMPLOYEE
               ,items.ITEM_STATUS
               , username
            });

            db.Close();
            return hdr.ToList().FirstOrDefault();
        }

        public static WP02005InputForm DeleteItemCheck(WP02005InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<ItemCheckModel>("WP02005/WP02005_DeleteItemCheck", new
            {
                items.ID
                ,
                USERNAME = username
            });

            db.Close();
            return items;
        }

        public static WP02005InputForm DeleteIncident(WP02005InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<ItemCheckModel>("WP02005/WP02005_DeleteIncident", new
            {
                items.ID
                ,
                USERNAME = username
            });

            db.Close();
            return items;
        }

        public List<IncidentModel> getListIncident(string WP_PROJECT_JOB_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<IncidentModel>("WP02005/WP02005_getIncident", new
            {
                WP_PROJECT_JOB_ID = WP_PROJECT_JOB_ID
            });

            db.Close();
            return d.ToList();
        }

        public List<ItemCheckModel> getListItemCheck(string WP_PROJECT_JOB_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ItemCheckModel>("WP02005/WP02005_getItemCheck", new
            {
                WP_PROJECT_JOB_ID = WP_PROJECT_JOB_ID
            });

            db.Close();
            return d.ToList();
        }

        public List<WP02002Master.EmployeeModel> GetEmployee(string WP_PROJECT_JOB_ID)
        {
            try
            {
                IDBContext db = DatabaseManager.Instance.GetContext();
                var d = db.Fetch<WP02002Master.EmployeeModel>("WP02005/WP02005_getEmployee", new
                {
                    WP_PROJECT_JOB_ID = WP_PROJECT_JOB_ID
                });

                db.Close();
                return d.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

    public class DivisionModel
    {
        public string DIV { get; set; }
        public string DIV_ID { get; set; }
    }

    public class CompanyModel
    {
        public int ID_TB_M_COMPANY { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
    }

    public class LocationModel
    {
        public int ID_TB_M_LOCATION { get; set; }
        public int ID_TB_M_AREA { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class PagingModel_WP02005
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP02005(int countdata, int positionpage, int dataperpage)
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