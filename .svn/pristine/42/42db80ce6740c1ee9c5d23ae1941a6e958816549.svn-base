using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class LocationInfoRepository
    {
        private LocationInfoRepository() { }
        private static LocationInfoRepository instance = null;
        public static LocationInfoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocationInfoRepository();
                }
                return instance;
            }
        }
        public List<LocationInfo> GetLocationInfo()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<LocationInfo>("Shared/GetLocationinfo");

            db.Close();
            return result.ToList();
        }
    }

    public class LocationInfo
    {
        public string LOCATION_ID { get; set; }
        public string LOCATION_NAME { get; set; }
        public string AREA_ID { get; set; }
    }
}