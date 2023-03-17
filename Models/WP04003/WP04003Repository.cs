using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP04003Master
{
    public class WP04003Repository
    {
        #region Get_Data_Grid_WP04003
        public List<WP04003Master> getDataWP04003(int Start, int Display, string NOREG, string USERNAME, string EMAIL)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04003Master>("WP04003/WP04003_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NOREG,
                USERNAME,
                EMAIL
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public List<RoleModel> getRole()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<RoleModel>("WP04003/WP04003_getRole");
            db.Close();
            return d.ToList();
        }

        public List<UserModel> getUserData(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<UserModel>("WP04003/WP04003_getUserData", new {
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        public List<UsernameModel> getUsername()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<UsernameModel>("WP04003/WP04003_getUsername");
            db.Close();
            return d.ToList();
        }

        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP04003/WP04003_getLocation");
            db.Close();
            return d.ToList();
        }

        #region Count_Get_Data_Grid_WP04003
        public int getCountWP04003(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string NOREG, string USERNAME, string EMAIL)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP04003/WP04003_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                NOREG,
                USERNAME,
                EMAIL
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP04003/WP04003_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP04003> Update_Data(string ID, 
                    string NOREG,
                    string USERNAME,
                    string ROLE,
                    string EMAIL,
                    string FIRST_NAME,
                    string LAST_NAME, 
                    string AREA,
                    string LOCATION,
                    string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04003>("WP04003/WP04003_Update", new
            {
                ID,
                NOREG,
                USERNAME,
                ROLE,
                EMAIL,
                FIRST_NAME,
                LAST_NAME,
                AREA,
                LOCATION,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP04003> Create(string NOREG, string USERNAME, string ROLE, string EMAIL, string FIRST_NAME, string LAST_NAME, string AREA, string LOCATION, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP04003>("WP04003/WP04003_Create", new
            {
                NOREG,
                USERNAME,
                ROLE,
                EMAIL,
                FIRST_NAME,
                LAST_NAME,
                AREA,
                LOCATION,
                username
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<LocationModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP04003/WP04003_getArea");

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

    public class RoleModel
    {
        public string ID { get; set; }
        public string ROLE_NAME { get; set; }
    }

    public class UserModel
    {
        public string REG_NO { get; set; }
        public string EMAIL { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string PHONE { get; set; }
    }

    public class LocationModel
    {
        public string ID_AREA { get; set; }
        public string ID { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class UsernameModel
    {
        public string USERNAME { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class PagingModel_WP04003
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP04003(int countdata, int positionpage, int dataperpage)
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