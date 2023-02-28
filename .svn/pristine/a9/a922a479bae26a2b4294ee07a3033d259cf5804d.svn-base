using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class AreaInfoRepository
    {
        private AreaInfoRepository() { }
        private static AreaInfoRepository instance = null;
        public static AreaInfoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AreaInfoRepository();
                }
                return instance;
            }
        }
        public List<AreaInfo> GetAreaInfo()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<AreaInfo>("Shared/GetAreainfo");

            db.Close();
            return result.ToList();
        }
    }
}