using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;
using Newtonsoft.Json;

namespace AI070.Models.DISA140001Master
{
    public class DISA140001Repository
    {
        #region Get_Data_Grid_DISA140001
        public List<DISA140001Master> getDataDISA140001(int Start, int Display, string ID_PRODUKSI, string TIPE, string NIK, string NAMA, string SERIAL_NO, string SHIFT, string FROM_DATE, string END_DATE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA140001Master>("DISA140001/DISA140001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ID_PRODUKSI,
                TIPE,
                NIK,
                NAMA,
                SERIAL_NO,
                SHIFT,
                FROM_DATE,
                END_DATE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Nama Tools
        public List<DISA140001Master> getNameToolDISA140001(string ID_TOOL)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA140001Master>("DISA140001/DISA140001_GetNameTool", new
            {
                ID_TOOL
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA140001
        public int getCountDISA140001(string DATA_ID, string ID_PRODUKSI, string TIPE, string NIK, string NAMA, string SERIAL_NO, string SHIFT, string FROM_DATE, string END_DATE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA140001/DISA140001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ID_PRODUKSI,
                TIPE,
                NIK,
                NAMA,
                SERIAL_NO,
                SHIFT,
                FROM_DATE,
                END_DATE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get LIst Nik
        public List<ListNik> getListNik()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListNik>("DISA140001/DISA140001_GetListNik");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Detail Data Operator
        public List<ListNik> get_Data_Operator(string id_sagyosha)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListNik>("DISA140001/DISA140001_getDataOperator", new
            {
                id_sagyosha
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Add Data
        public static List<DISA140001> Create(string ID_PRODUKSI, string ID_PROSES, string NAMA_PROSES, string TIPE, string NIK, string NAMA, string SERIAL_NO, string LOTTO, string QTY, string TOTAL_BERAT, string KETERANGAN, string SHIFT, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA140001>("DISA140001/DISA140001_Create", new
            {
                ID_PRODUKSI,
                ID_PROSES,
                NAMA_PROSES,
                TIPE,
                NIK,
                NAMA,
                SERIAL_NO,
                LOTTO,
                QTY,
                TOTAL_BERAT,
                KETERANGAN,
                SHIFT,
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
            var d = db.SingleOrDefault<string>("DISA140001/DISA140001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA140001> Update_Data(string ID, string ID_PRODUKSI, string ID_PROSES, string NAMA_PROSES, string TIPE, string NIK, string NAMA, string SERIAL_NO, string LOTTO, string QTY, string TOTAL_BERAT, string KETERANGAN, string SHIFT, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA140001>("DISA140001/DISA140001_Update", new
            {
                ID,
                ID_PRODUKSI,
                ID_PROSES,
                NAMA_PROSES,
                TIPE,
                NIK,
                NAMA,
                SERIAL_NO,
                LOTTO,
                QTY,
                TOTAL_BERAT,
                KETERANGAN,
                SHIFT,
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

    public class ListNik
    {
        public string id_sagyosha { get; set; }
        public string name_sagyosha { get; set; }
    }

    public class PagingModel_DISA140001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA140001(int countdata, int positionpage, int dataperpage)
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