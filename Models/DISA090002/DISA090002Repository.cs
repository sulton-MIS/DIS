using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA090002Master
{
    public class DISA090002Repository
    {
        #region Get_Data_Grid_DISA090002
        public List<DISA090002Master> getDataDISA090002(int Start, int Display, string NAMA_MESIN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090002Master>("DISA090002/DISA090002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NAMA_MESIN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA090002
        public int getCountDISA090002(string DATA_ID, string NAMA_MESIN)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA090002/DISA090002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NAMA_MESIN
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA090002> Create(
            string NAMA_MESIN,
            string PATH_MESIN,
            string USERNAME,
            DateTime CREATED_DATE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090002>("DISA090002/Setting_Database/DISA090002_Create", new
            {
                NAMA_MESIN,
                PATH_MESIN,
                USERNAME,
                CREATED_DATE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data
        public List<DISA090002> Update_Data(
            string ID,
            string NAMA_MESIN,
            string PATH_MESIN,
            string USERNAME,
            DateTime UPDATED_DATE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090002>("DISA090002/Setting_Database/DISA090002_Update", new
            {
                ID,
                NAMA_MESIN,
                PATH_MESIN,
                USERNAME,
                UPDATED_DATE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string NAMA_MESIN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA090002/Setting_Database/DISA090002_Delete", new
            {
                NAMA_MESIN
            });
            db.Close();
            return d;
        }
        #endregion

        #region Get Path Mesin
        public string getPathMesin(string NAMA_MESIN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string getPathMesin = db.SingleOrDefault<string>("DISA090002/DISA090002_getPathMesin", new {
                NAMA_MESIN
            });

            string result = getPathMesin;
            
            db.Close();
            return result;
        }
        #endregion

        //------------------------------------------------------------ PAGE HISTORY DISTRIBUSI ---------------------------------------------------
        #region PAGE HISTORY DISTRIBUSI
        #region Get_Data_Grid_DISA090002
        public List<DISA090002_History_Distribusi> getDataHistory(int Start, int Display, string NAMA_MESIN, string STATUS, string CREATED_BY, string CREATED_DATE_FROM, string CREATED_DATE_TO)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090002_History_Distribusi>("DISA090002/History_Distribusi/DISA090002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NAMA_MESIN,
                STATUS,
                CREATED_DATE_FROM,
                CREATED_DATE_TO,
                CREATED_BY
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA090002
        public int getCountDataHistory(string DATA_ID, string NAMA_MESIN, string STATUS, string CREATED_BY, string CREATED_DATE_FROM, string CREATED_DATE_TO)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA090002/History_Distribusi/DISA090002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NAMA_MESIN,
                STATUS,
                CREATED_DATE_FROM,
                CREATED_DATE_TO,
                CREATED_BY
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA090002> Create_History(
            string NAMA_MESIN,
            string STATUS,
            string KETERANGAN,
            string USERNAME,
            DateTime CREATED_DATE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090002>("DISA090002/History_Distribusi/DISA090002_Create", new
            {
                NAMA_MESIN,
                STATUS,
                KETERANGAN,
                USERNAME,
                CREATED_DATE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #endregion


        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISA090002/DISA090002_getExecutor");

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
    
    public class DistribusiModel
    {
        public string DISTRIBUSI_NAME { get; set; }
        public string DISTRIBUSI_MSG { get; set; }
    }


    public class ExecutorModel
    {
        public DateTime ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISA090002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA090002(int countdata, int positionpage, int dataperpage)
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