using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.Shared
{
    public class Dock
    {
        public string DOCK_CD { get; set; }
        public string DOCK_NM { get; set; }
        public string PLANT_CD { get; set; }

        public List<Dock> getDocks()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Query<Dock>("Shared/Dock");
            db.Close();

            return res.ToList();
        }
    }
}