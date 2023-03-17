using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Web.Platform;
using Toyota.Common.Database;

namespace AI070.Models.Shared
{
    public class Supplier:Person
    {
        public string IP_Status { get; set; }
        public long Reply { get; set; }
        public bool Ping { get; set; }
        public string SUPP_CD { get; set; }
        public string SUPP_PLANT_CD { get; set; }
        public string SUPP_NAME { get; set; }
        public string EMAIL { get; set; }
        public int TTL_PART { get; set; }
        public string IP_ADDRESS { get; set; }
        public string DIRECT_STS { get; set; }
        public string MAIN_SUPP_FLG { get; set; }
        public string PLANT_CD { get; set; }
        public List<Supplier> getSuppliers()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Query<Supplier>("Shared/Supplier");
            db.Close();

            return res.ToList();
        }
    }
}