using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.Shared
{
    public class SystemModel
    {
        public string SYSTEM_ID { get; set; }
        public string SYSTEM_TYPE { get; set; }
        public string SYSTEM_VALUE_TEXT { get; set; }

        public List<SystemModel> getSystems(string SYSTEM_ID, string SYSTEM_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Query<SystemModel>("Shared/System", new
            {
                SYSTEM_ID = SYSTEM_ID,
                SYSTEM_TYPE = SYSTEM_TYPE
            });
            db.Close();

            return res.ToList();
        }
    }
}