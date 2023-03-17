using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP04001Master
{
    public class WP04001Repository
    {
        #region Get_Data_Grid_WP04001
        public List<WP04001Master> getDataWP04001(int Start, int Display, string AUTHORIZATION_NAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04001Master>("WP04001/WP04001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                AUTHORIZATION_NAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP04001
        public int getCountWP04001(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string AUTHORIZATION_NAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP04001/WP04001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                AUTHORIZATION_NAME
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP04001/WP04001_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP04001> Update_Data(string ID, string AUTHORIZATION_NAME,string AUTHORIZATION_DESC, string MENUS, string MENU_PARENT, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04001>("WP04001/WP04001_Update", new
            {
                ID,
                AUTHORIZATION_NAME,
                AUTHORIZATION_DESC,
                MENUS,
                MENU_PARENT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP04001> Create(string AUTHORIZATION_NAME, string AUTHORIZATION_STATUS, string AUTHORIZATION_DESC, string MENUS, string MENUS_PARENT, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04001>("WP04001/WP04001_Create", new
            {
                AUTHORIZATION_NAME,
                AUTHORIZATION_STATUS,
                AUTHORIZATION_DESC,
                MENUS,
                MENUS_PARENT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<LocationModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP04001/WP04001_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Menus
        public List<MenuModel> getMenus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<MenuModel>("WP04001/WP04001_getMenus");

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

    public class MenuModel
    { 
        public string MENU_CODE { get; set; }
        public string MENU_NAME { get; set; }
        public string MENU_PARENT { get; set; }
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

    public class PagingModel_WP04001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP04001(int countdata, int positionpage, int dataperpage)
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