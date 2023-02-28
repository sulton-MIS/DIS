using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models
{
    public class ProfileRepository
    {

        private ProfileRepository() { }
        private static ProfileRepository instance = null;

        public static ProfileRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProfileRepository();
                }
                return instance;
            }
        }

        public int updateData(string USERNAME_OLD, string AREA, string LOCATION, string USERNAME, string PASSWORD, string EMAIL, string FIRST_NAME, string LAST_NAME, string PHONE, string GENDER, string BIRTH_DATE) {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<int>("Profile_Update", new
            {
                 USERNAME_OLD,
                 AREA,
                 LOCATION,
                 USERNAME,
                 PASSWORD,
                 EMAIL,
                 FIRST_NAME,
                 LAST_NAME,
                 PHONE,
                 GENDER,
                 BIRTH_DATE
            });
            db.Close();
            return d;
        }
    }
}