using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DIST060001Master
{
    public class DIST060001Repository
    {
        #region Get_Data_Grid_DIST060001
        public List<DIST060001Master> getDataDIST060001(
            int Start, 
            int Display,
            string ItemCode,
            string Parts,
            string type
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DIST060001Master>("DIST060001/DIST060001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ItemCode,
                Parts,
                type
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DIST060001
        public int getCountDIST060001(
            string DATA_ID,
            string ItemCode,
            string Parts,
            string type
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            int result = db.SingleOrDefault<int>("DIST060001/DIST060001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ItemCode,
                Parts,
                type
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DIST060001> Create(
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DIST060001>("DIST060001/DIST060001_Create", new
            {
                ItemCode,
                Parts,
                SizeProduct,
                type,
                BundleQty,
                InnerQty,
                MasterQty,
                InnerType,
                InnerL,
                InnerW,
                InnerH,
                InnerWeight,
                MasterType,
                MasterL,
                MasterW,
                MasterH,
                MasterWeight,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.SingleOrDefault<string>("DIST060001/DIST060001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DIST060001> Update_Data(
            string ID,
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DIST060001>("DIST060001/DIST060001_Update", new
            {
                ID,
                ItemCode,
                Parts,
                SizeProduct,
                type,
                BundleQty,
                InnerQty,
                MasterQty,
                InnerType,
                InnerL,
                InnerW,
                InnerH,
                InnerWeight,
                MasterType,
                MasterL,
                MasterW,
                MasterH,
                MasterWeight,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion      

        #region Download Data Excel
        public List<DIST060001Master> DownloadExcel(int PageNumber, int Display,
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DIST060001Master>("DIST060001/DIST060001_Download_Excel", new
            {
                PageNumber,
                Display,
                ItemCode,
                Parts,
                SizeProduct,
                type,
                BundleQty,
                InnerQty,
                MasterQty,
                InnerType,
                InnerL,
                InnerW,
                InnerH,
                InnerWeight,
                MasterType,
                MasterL,
                MasterW,
                MasterH,
                MasterWeight
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<ExecutorModel>("DIST060001/DIST060001_getExecutor");

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

    //public class SectionModel
    //{
    //    public string ID { get; set; }
    //    public string SECTION_TEXT { get; set; }
    //}

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DIST060001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DIST060001(int countdata, int positionpage, int dataperpage)
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