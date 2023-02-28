using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA200001Master
{
    public class DISA200001Repository
    {
        #region Get_Data_Grid_DISA200001
        public List<DISA200001Master> getDataDISA200001(int Start, int Display, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, string MEREK, string SUPPLIER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA200001Master>("DISA200001/DISA200001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA200001
        public int getCountDISA200001(string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, string MEREK, string SUPPLIER)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA200001/DISA200001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get No_Urut
        public int getNo_Urutan()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA200001/DISA200001_getUrutan", new
            { 
                
            });
            if (result.ToString() != null)
            {
                result += 1;
            }
            else
            {
                result = 1;
            }
            
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA200001> Create(string DATA_ID, 
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
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA200001>("DISA200001/DISA200001_Create", new
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
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA200001/DISA200001_Delete", new
            {
                NO_ASSET
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA200001> Update_Data(string ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, /*string SOURCE_FOTO,*/ string MEREK, string TIPE, string SUPPLIER, string TAHUN, string QTY, string HARGA_SATUAN, /*string TOTAL,*/ string JENIS_ASSET, string KATEGORI_ASSET, string PIC_BELI, string DEPT_USER, string NAMA_USER, string KD_LOKASI, string HALTE, string JENIS_DOC, string NO_BC, string TGL_BC, string TGL_REGIST, string STATUS, string FLG_LABEL_ASSET)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA200001>("DISA200001/DISA200001_Update", new
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
        public List<LokasiModel> getLokasi()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<LokasiModel>("DISA200001/DISA200001_getLokasi");

            db.Close();
            return d.ToList();
        }
        #endregion
        
        //#region Get Urutan
        //public List<UrutanModel> getUrutan()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext();
        //    var d = db.Fetch<UrutanModel>("DISA200001/DISA200001_getUrutan");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion
        
        

        //#region Get Division
        //public List<DivisionModel> getDivision()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<DivisionModel>("DISR070001/DISR070001_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<CompanyModel>("DISR070001/DISR070001_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<IdentityModel>("DISR070001/DISR070001_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<SectionModel>("DISR070001/DISR070001_getSection", new
        //    {
        //        SYSTEM_CD
        //    });

        //    db.Close();
        //    return d.ToList();
        //}



        //#endregion

        //#region Get PIC
        //public List<PICModel> getPIC()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<PICModel>("DISR070001/DISR070001_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("");
            var d = db.Fetch<ExecutorModel>("DISA200001/DISA200001_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    //public class StatusModel
    //{
    //    public string ID { get; set; }
    //    public string Status { get; set; }
    //}

    //public class DivisionModel
    //{
    //    public string Division { get; set; }
    //    public string DIV { get; set; }
    //    public string DIV_ID { get; set; }
    //}

    //public class CompanyModel
    //{
    //    public string ID { get; set; }
    //    public string COMPANY { get; set; }
    //}

    //public class IdentityModel
    //{
    //    public string ID { get; set; }
    //    public string IDENTITY_TEXT { get; set; }
    //}

    //public class PICModel
    //{
    //    public string ID { get; set; }
    //    public string PIC_TEXT { get; set; }
    //}

    public class LokasiModel
    {
        public string id_tb_m_lokasi { get; set; }
        public string kd_lokasi { get; set; }
        public string nama_lokasi { get; set; }
    }
    public class UrutanModel
    {
        public string no_urut { get; set; }
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

    public class PagingModel_DISA200001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA200001(int countdata, int positionpage, int dataperpage)
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