using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class LookupRepository
    {
        public static IEnumerable<Lookup> GetLookups(string lookupName)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var args = new
            {

            };

            IEnumerable<Lookup> result = db.Fetch<Lookup>(lookupName + "GetLookup", args);
            db.Close();

            return result;
        }

        public static IEnumerable<Lookup> GetLookups(string lookupName, string userName)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var args = new
            {
                UserName = userName
            };

            IEnumerable<Lookup> result = db.Fetch<Lookup>(lookupName + "GetLookup", args);
            db.Close();

            return result;
        }
    }
}