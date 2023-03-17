using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.WP03011
{
	public class WP03011Repository
	{

        public Employee GetEmployeeByRegNumber(string regNumber)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<Employee>("WP03011/WP03011_GetEmployeeByRegNumber", new { regNumber });
            db.Close();
            return d.FirstOrDefault();
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Company { get; set; }

        public string IdentityNo { get; set; }

        public string SafetyNo { get; set; }

        public DateTime SafetyFrom { get; set; }

        public DateTime SafetyTo { get; set; }

    }

}