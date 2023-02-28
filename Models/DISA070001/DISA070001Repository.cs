using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA070001Master
{
    public class DISA070001Repository
    {
        #region Get_Data_Grid_DISA070001
        public List<DISA070001Master> getDataDISA070001(int Start, int Display, string DATE, string TIME, string HALTE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA070001Master>("DISA070001/DISA070001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,                
                DATE,
                TIME,
                HALTE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA070001
        public int getCountDISA070001(string DATA_ID, string DATE, string TIME, string HALTE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA070001/DISA070001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                DATE,
                TIME,
                HALTE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA070001> Create(string HALTE, string DATE, string TIME, string OPMJ, string MASALAH, string ACTION, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA070001>("DISA070001/DISA070001_Create", new
            {
                HALTE,
                DATE,
                TIME,                
                OPMJ,
                MASALAH,
                ACTION,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Upload Data
        public static List<DISA070001> Upload_Data(string HALTE, string DATE, string TIME, string OPMJ, string MASALAH, string ACTION, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA070001>("DISA070001/DISA070001_Upload", new
            {
                HALTE,
                DATE,
                TIME,
                OPMJ,
                MASALAH,
                ACTION,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA070001/DISA070001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA070001> Update_Data(string ID, string HALTE, string DATE, string TIME, string OPMJ, string MASALAH, string ACTION, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA070001>("DISA070001/DISA070001_Update", new
            {
                ID,
                HALTE,
                DATE,
                TIME,                
                OPMJ,
                MASALAH,
                ACTION,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion      

    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    public class PagingModel_DISA070001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA070001(int countdata, int positionpage, int dataperpage)
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