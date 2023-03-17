using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.WP03006
{
	public class WP03006Repository
	{
        public List<WP03006Master> GetDataByFilter(int PageNumber, int Display, string RegNo, string IdentityType, string IdentityNo, string UserName, string Email)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03006Master>("WP03006/WP03006_GetExamScore", new
            {
                PageNumber,
                Display,
                RegNo,
                IdentityType,
                IdentityNo,
                UserName,
                Email
            }).ToList();
            db.Close();
            return d;
        }

        public int CountData(string RegNo, string IdentityType, string IdentityNo, string UserName, string Email, bool IsDetail)
        {
            string RANK = "1";
            if (IsDetail)
            {
                RANK = "0";
            }

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03006/WP03006_CountExamScore", new
            {
                RegNo,
                IdentityType,
                IdentityNo,
                UserName,
                Email,
                RANK
            });
            db.Close();
            return result;
        }

        public List<KeyList> GetExamSubject()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<KeyList>("WP03006/WP03006_GetExamSubject");

            db.Close();
            return d.ToList();
        }

        public Employee GetEmployeeById(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<Employee>("WP03006/WP03006_GetEmployee", new { ID });

            db.Close();
            return d.FirstOrDefault();
        }

        public Employee GetEmployeeByScore(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<Employee>("WP03006/WP03006_GetEmployeeByScore", new { ID });

            db.Close();
            return d.FirstOrDefault();
        }
    }

    public class PagingModel_WP03006
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03006(int countdata, int positionpage, int dataperpage)
        {
            List<int> list = new List<int>();
            EndData = positionpage * dataperpage;
            CountData = countdata;
            PositionPage = positionpage;
            StartData = (positionpage - 1) * dataperpage + 1;
            Double jml = countdata / dataperpage;
            if (countdata % dataperpage > 0)
            {
                jml = jml + 1;
            }

            for (int i = 0; i < jml; i++)
            {
                list.Add(i);
            }
            ListIndex = list;
        }
    }
}