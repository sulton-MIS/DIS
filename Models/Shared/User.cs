using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.Shared
{
    public class User
    {
        public string ID { get; set; }
        public string NOREG { get; set; }
        public string POSITION { get; set; }
        public string DIV_ID { get; set; }
        public string PLANT_ID { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }
        public string Username { get; internal set; }
        public string PASSWORD { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public string CHANGED_DT { get; set; }

        public string COMPANY { get; set; }

        public List<User> getUserMapping(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Query<User>("Shared/User", new
            {
                USERNAME = USERNAME
            });
            db.Close();

            return res.ToList();
        }
    }
}