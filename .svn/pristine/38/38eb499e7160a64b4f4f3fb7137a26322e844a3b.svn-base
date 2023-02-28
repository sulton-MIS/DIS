using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.WP03005
{
	public class WP03005Repository
	{
        public List<WP03005DetailScore> GetDataParticipant_DetailExam_ById(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03005DetailScore>("WP03005/WP03005_GetDataParticipant_DetailExam", new
            {
                ID
            }).ToList();
            db.Close();
            return d;
        }

        public List<WP03005Master> GetDataParticipant(int PageNumber, int Display, string RegNo, string IdentityType, string IdentityNo, string UserName, string Email)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03005Master>("WP03005/WP03005_GetDataParticipant", new
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

        public int CountData(string IDSUBJECT, string IDEMPLOYEE, string EXAMSTATUS, bool IsDetail)
        {
            string RANK = "1";
            if (IsDetail)
            {
                RANK = "0";
            }

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03005/WP03005_CountExamScore", new
            {
                IDSUBJECT,
                IDEMPLOYEE,
                RANK
            });
            db.Close();
            return result;
        }

        public List<KeyList> GetRegNo()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<KeyList>("WP03005/WP03005_GetRegNo");

            db.Close();
            return d.ToList();
        }

        public List<KeyList> GetCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<KeyList>("WP03005/WP03005_GetCompany");

            db.Close();
            return d.ToList();
        }

        
    }

    #region Paging Model

    public class WP03005DetailScore
    {
        public int ROWNUM { get; set; }
        public int ID { get; set; }
        public string REG_NO { get; set; }
        public string NAME { get; set; }
        public string TITLE { get; set; }
        public string REMEDIAL { get; set; }
        public string COMPANY_NAME { get; set; }
        public string ANSWER { get; set; }
        public string CORRECT_AMOUNT { get; set; }
        public string WRONG_AMOUNT { get; set; }
        public string NOT_ANSWERED_AMOUNT { get; set; }
        public string SCORE { get; set; }
        public string PASS_GRADUATED { get; set; }
        public string TIMER { get; set; }
        public string SUBMIT_DATE { get; set; }
        public string STATUS { get; set; }

    }
    #endregion

    public class PagingModel_WP03005
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03005(int countdata, int positionpage, int dataperpage)
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