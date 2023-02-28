using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA100003Master
{
    public class DISA100003Repository
    {
        #region Get_Data_Grid_DISA100003
        public List<DISA100003Master> getDataDISA100003(int Start, int Display, string ITEM_CODE, string JENIS_PACKING, string HARGA)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100003Master>("DISA100003/DISA100003_SearchData", new
            {
                START = Start,
                DISPLAY = Display,                
                ITEM_CODE,
                JENIS_PACKING,
                HARGA
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA100003
        public int getCountDISA100003(string DATA_ID, string ITEM_CODE, string JENIS_PACKING, string HARGA)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100003/DISA100003_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ITEM_CODE,
                JENIS_PACKING,
                HARGA
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA100003> Create(string item_code, string jenis_packing, string qty_pcs, string factory_size, string indirect, string berat, string panjang, string lebar, string tinggi, string harga, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100003>("DISA100003/DISA100003_Create", new
            {
                item_code,
                jenis_packing,
                qty_pcs,
                factory_size,
                indirect,
                berat,
                panjang,
                lebar,
                tinggi,
                harga,
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
            var d = db.SingleOrDefault<string>("DISA100003/DISA100003_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA100003> Update_Data(string ID, string item_code, string jenis_packing, string qty_pcs, string factory_size, string indirect, string berat, string panjang, string lebar, string tinggi, string harga, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100003>("DISA100003/DISA100003_Update", new
            {
                ID,
                item_code,
                jenis_packing,
                qty_pcs,
                factory_size,
                indirect,
                berat,
                panjang,
                lebar,
                tinggi,
                harga,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion      



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISA100003/DISA100003_getExecutor");

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

    public class PagingModel_DISA100003
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA100003(int countdata, int positionpage, int dataperpage)
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