using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class UserInfoRepository
    {
        private UserInfoRepository() { }
        private static UserInfoRepository instance = null;

        public static UserInfoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInfoRepository();
                }
                return instance;
            }
        }

        public UserInfo GetUserInfo(string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                Username = username
            };

            UserInfo result = db.SingleOrDefault<UserInfo>("Shared/GetUserinfo", args);
            db.Close();
            return result;
        }
        
        public UserInfo GetUserPlantInfo(string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                Username = username
            };

            UserInfo result = db.SingleOrDefault<UserInfo>("Shared/GetUserinfo", args);
            db.Close();
            return result;
        }
        public bool SaveUserLocation(string username, string locationCode)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                LocationCode = locationCode,
                Username = username
            };
                        
            var result = db.Execute("SaveUserLocation", args);
            db.Close();
            return result > 0;
        }

        public bool SaveUserPassword(string username, string passowrd, string ip, string check)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                Username = username,
                Password = passowrd,
                IP = ip,
                Check = check
            };

            var result = db.Execute("SaveUserPassword", args);
            db.Close();
            return result > 0;
        }

        public string GetUserPassword(string username, string ip)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                Username = username,
                IP = ip
            };

            UserInfo result = db.SingleOrDefault<UserInfo>("GetUserPassword", args);
            db.Close();
            if (result ==null)
            {
                return "|";
            }
            else
            {
                return result.Username + "|" + result.Password;
            }
            
        }
    }
}