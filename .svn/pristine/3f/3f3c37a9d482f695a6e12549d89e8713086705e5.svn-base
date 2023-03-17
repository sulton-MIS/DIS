using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
namespace AI070.Models
{
    public class SystemRepository : BaseRepository
    {
        private SystemRepository() { }
        private static SystemRepository instance = null;

        public static SystemRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemRepository();
                }
                return instance;
            }
        }
        public int CheckUserPlantMapping(string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            int result = 0;
            dynamic args = new
            {
                Username = username
            };
            try
            {
                result = db.SingleOrDefault<int>("CheckUserPlantMapping", args);
            }
            catch (Exception ex)
            {
                result = 0;
            }

            db.Close();
            return result;
        }

        #region Check User Password
        public int CheckUserPassword(string USERNAME, string PASSWORD)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int d = db.SingleOrDefault<int>("Shared/CheckUser", new
            {
                USERNAME,
                PASSWORD
            });
            db.Close();
            return d;
        }
        #endregion

        #region Check Authorization
        public int CheckUserAuthorization(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int d = db.SingleOrDefault<int>("Shared/CheckUserAuthorization", new
            {
                USERNAME
            });
            db.Close();
            return d;
        }
        #endregion

        #region Get User Info
        public List<UserInfo> getUserInfo(string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<UserInfo>("Shared/User", new
            {
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public SystemMaster GetStatus(string Status)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                Status = Status
            };

            SystemMaster result = db.SingleOrDefault<SystemMaster>("SYSTEM_GetStatus", args);
            db.Close();
            return result;
        }

        public List<SystemMaster> GetBySYSTEM_ID(string SystemID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                SystemID = SystemID
            };

            List<SystemMaster> result = db.Fetch<SystemMaster>("STD/GetSystemBySystemID", args);
            db.Close();
            return result;
        }
        public List<SystemMaster> GetAllByIDType(string systemID,string systemType)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                SystemID = systemID,
                SystemType = systemType
            };

            List<SystemMaster> result = db.Fetch<SystemMaster>("STD/GetAllByIDType", args);
            db.Close();
            return result;
        }


        public string GetLOG_H_STS(string SystemType)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                SYSTEM_TYPE = SystemType
            };

            string result = db.SingleOrDefault<string>("STD/GetLogStatusFromSystem", args);
            db.Close();
            return result;
        }

        public string GetSystemByIDType(string System_ID, string System_Type)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                SYSTEM_ID = System_ID,
                SYSTEM_TYPE = System_Type
            };

            string result = db.SingleOrDefault<string>("STD/GetSystemByIDType", args);
            db.Close();
            return result;
        }

        public string GetPostStatusFromSystem(string SystemType)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                SYSTEM_TYPE = SystemType
            };

            string result = db.SingleOrDefault<string>("STD/GetPostStatusFromSystem", args);
            db.Close();
            return result;
        }


        public string GetIntSource(string IntSrc)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                SYSTEM_TYPE = IntSrc
            };

            string result = db.SingleOrDefault<string>("SYSTEM_GetINT_SRC", args);
            db.Close();
            return result;
        }


        public List<String> GetRecordsPerPage()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new { };

            List<String> result = db.Fetch<String>("STD/GetRecordsPerPage", args);
            db.Close();
            return result;
        }
        public List<SystemMaster> GetListLogHStatus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new { SystemID = "LOG_H_STS"};

            List<SystemMaster> result = db.Fetch<SystemMaster>("STD/GetSystemBySystemID", args);
            db.Close();
            return result;
        }

        public List<String> GetOrderTypeLookup()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new { };

            List<String> result = db.Fetch<String>("SYSTEM_GetOrderType", args);
            db.Close();
            return result;
        }
    }
}