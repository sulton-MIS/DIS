using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA200004Master
{
    public class DISA200004Repository
    {
        #region Get_Data_Grid_DISA200004
        public List<DISA200004Master> getDataDISA200004(int Start, int Display, string no_jurnal, string no_asset, string nama_barang, string jenis_asset)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA200004Master>("DISA200004/DISA200004_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                no_jurnal,
                no_asset,
                nama_barang,
                jenis_asset
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA200004
        public int getCountDISA200004(string DATA_ID, string no_jurnal, string no_asset, string nama_barang, string jenis_asset)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            int result = db.SingleOrDefault<int>("DISA200004/DISA200004_SearchCount", new
            {
                DATA_ID = DATA_ID,
                no_jurnal,
                no_asset,
                nama_barang,
                jenis_asset
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get No_Urut
        //public int getNo_Urutan()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    int result = db.SingleOrDefault<int>("DISA200004/DISA200004_getUrutan", new
        //    { 
                
        //    });
        //    if (result.ToString() != null)
        //    {
        //        result += 1;
        //    }
        //    else
        //    {
        //        result = 1;
        //    }
            
        //    db.Close();
        //    return result;
        //}
        #endregion

        #region Add Data
        public static List<DISA200004> Create(string DATA_ID, 
            string NO_URUT,
            string NAMA_ASSET,
            string NAMA_FOTO,
            //string SOURCE_FOTO, 
            string MEREK,
            string TIPE,
            string SUPPLIER,
            string TAHUN,
            string QTY,
            string HARGA_SATUAN,
            //string TOTAL,
            string JENIS_ASSET,
            string KATEGORI_ASSET,
            string PIC_BELI,
            string DEPT_USER,
            string NAMA_USER,
            string KD_LOKASI,
            string HALTE,
            string JENIS_DOC,
            string NO_BC,
            string TGL_BC,
            string TGL_REGIST,
            string STATUS,
            string FLG_LABEL_ASSET
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA200004>("DISA200004/DISA200004_Create", new
            {
                DATA_ID,
                NO_URUT,
                NAMA_ASSET,
                NAMA_FOTO,
                //SOURCE_FOTO,
                MEREK,
                TIPE,
                SUPPLIER,
                TAHUN,
                QTY,
                HARGA_SATUAN,
                //TOTAL,
                JENIS_ASSET,
                KATEGORI_ASSET,
                PIC_BELI,
                DEPT_USER,
                NAMA_USER,
                KD_LOKASI,
                HALTE,
                JENIS_DOC,
                NO_BC,
                TGL_BC,
                TGL_REGIST,
                STATUS,
                FLG_LABEL_ASSET
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string NO_ASSET)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.SingleOrDefault<string>("DISA200004/DISA200004_Delete", new
            {
                NO_ASSET
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA200004> Update_Data(string ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, /*string SOURCE_FOTO,*/ string MEREK, string TIPE, string SUPPLIER, string TAHUN, string QTY, string HARGA_SATUAN, /*string TOTAL,*/ string JENIS_ASSET, string KATEGORI_ASSET, string PIC_BELI, string DEPT_USER, string NAMA_USER, string KD_LOKASI, string HALTE, string JENIS_DOC, string NO_BC, string TGL_BC, string TGL_REGIST, string STATUS, string FLG_LABEL_ASSET)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA200004>("DISA200004/DISA200004_Update", new
            {
                ID,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                //SOURCE_FOTO,
                MEREK,
                TIPE,
                SUPPLIER,
                TAHUN,
                QTY,
                HARGA_SATUAN,
                //TOTAL,
                JENIS_ASSET,
                KATEGORI_ASSET,
                PIC_BELI,
                DEPT_USER,
                NAMA_USER,
                KD_LOKASI,
                HALTE,
                JENIS_DOC,
                NO_BC,
                TGL_BC,
                TGL_REGIST,
                STATUS,
                FLG_LABEL_ASSET
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Lokasi
        //public List<LokasiModel> getLokasi()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<LokasiModel>("DISA200004/DISA200004_getLokasi");

        //    db.Close();
        //    return d.ToList();
        //}
        #endregion
        
        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("");
            var d = db.Fetch<ExecutorModel>("DISA200004/DISA200004_getExecutor");

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

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISA200004
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA200004(int countdata, int positionpage, int dataperpage)
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