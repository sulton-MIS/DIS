using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA100002Master
{
    public class DISA100002Repository
    {
        #region Get_Data_Grid_DISA100002
        public List<DISA100002Master> getDataDISA100002(int Start, int Display, string KD_LOKASI, string NAMA_LOKASI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100002Master>("DISA100002/DISA100002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                KD_LOKASI,
                NAMA_LOKASI
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA100002
        public int getCountDISA100002(string DATA_ID, string KD_LOKASI, string NAMA_LOKASI)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100002/DISA100002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                KD_LOKASI,
                NAMA_LOKASI
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA100002> Create(string DATA_ID, string KD_LOKASI, string NAMA_LOKASI, string AREA)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100002>("DISA100002/DISA100002_Create", new
            {
                DATA_ID,
                KD_LOKASI,
                NAMA_LOKASI,
                AREA
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100002/DISA100002_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA100002> Update_Data(string ID, string KD_LOKASI, string NAMA_LOKASI, string AREA)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100002>("DISA100002/DISA100002_Update", new
            {
                ID,
                KD_LOKASI,
                NAMA_LOKASI,
                AREA
            });
            db.Close();
            return d.ToList();
        }
        #endregion

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
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISA100002/DISA100002_getExecutor");

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

    public class PagingModel_DISA100002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA100002(int countdata, int positionpage, int dataperpage)
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