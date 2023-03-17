using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.WP03012
{
	public class WP03012Repository
	{
        public List<WP03012Master> GetDataByFilter(int PageNumber, int Display, string RegNo, string IdentityNo, string UserName, string Email, int ID_Employee)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03012Master>("WP03012/WP03012_GetExamScore", new
            {
                PageNumber,
                Display,
                RegNo,
                IdentityNo,
                UserName,
                Email,
                ID_Employee
            }).ToList();
            db.Close();
            return d;
        }

        public int CountData(string RegNo, string IdentityNo, string UserName, string Email, int ID_Employee, bool IsDetail)
        {
            string RANK = "1";
            if (IsDetail)
            {
                RANK = "0";
            }

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03012/WP03012_CountExamScore", new
            {
                RegNo,
                IdentityNo,
                UserName,
                Email,
                ID_Employee,
                RANK
            });
            db.Close();
            return result;
        }

        public List<KeyList> GetExamSubject()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<KeyList>("WP03012/WP03012_GetExamSubject");

            db.Close();
            return d.ToList();
        }

        public List<KeyList> GetCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<KeyList>("WP03012/WP03012_GetCompany");

            db.Close();
            return d.ToList();
        }

        public Employee GetEmployeeById(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<Employee>("WP03012/WP03012_GetEmployee", new { ID });

            db.Close();
            return d.FirstOrDefault();
        }

        public Employee GetEmployeeByScore(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<Employee>("WP03012/WP03012_GetEmployeeByScore", new { ID });

            db.Close();
            return d.FirstOrDefault();
        }
    }

    public class PagingModel_WP03012
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03012(int countdata, int positionpage, int dataperpage)
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