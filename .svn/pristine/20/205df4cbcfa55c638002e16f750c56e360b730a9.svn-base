using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03009
{
    public class WP03009Repository
    {
        public List<MasterExamScore> GetExamScore(int EmployeeId)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<MasterExamScore>("WP03007/WP03007_GetExamScorePerUser", new
            {
                EmployeeId
            }).ToList();
            db.Close();
            return result;
        }

    }

}
