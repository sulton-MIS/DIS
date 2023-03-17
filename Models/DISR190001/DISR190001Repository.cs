using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR190001Master
{
    public class DISR190001Repository
    {
        #region Get_Data_Grid_DISR190001
        public List<DISR190001Master> getDataDISR190001(int Start, int Display, string ID_PRODUKSI, string DMC_CODE, string DMC_PART, string LOT_NO, string KODE_PROSES, string KODE_MESIN, string WAKTU_MULAI, string WAKTU_SELESAI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR190001Master>("DISR190001/DISR190001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ID_PRODUKSI,
                DMC_CODE,
                DMC_PART,
                LOT_NO,
                KODE_PROSES,
                KODE_MESIN,
                WAKTU_MULAI,
                WAKTU_SELESAI
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Detail_DISR190001
        //Detail Proses
        public List<DISR190001Detail> GetData_Detail_ByID(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR190001Detail>("DISR190001/DISR190001_DetailData", new
            {
                ID
            }).ToList();
            db.Close();
            return d;
        }

        //Detail Parts
        public List<DISR190001Detail_Parts> GetData_Detail_ByCode(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR190001Detail_Parts>("DISR190001/DISR190001_DetailData_Parts", new
            {
                DMC_CODE
            }).ToList();
            db.Close();
            return d;
        }
        #endregion


        #region Count_Get_Data_Grid_DISR190001
        public int getCountDISR190001(string DATA_ID, string DMC_CODE, string DMC_PART, string LOT_NO, string KODE_PROSES, string KODE_MESIN, string WAKTU_MULAI, string WAKTU_SELESAI)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR190001/DISR190001_SearchCount", new
            {
                DATA_ID = DATA_ID
                ,DMC_CODE
                ,DMC_PART
                ,LOT_NO
                ,KODE_PROSES
                ,KODE_MESIN
                ,WAKTU_MULAI
                ,WAKTU_SELESAI
            });
            db.Close();
            return result;
        }
        #endregion

        //#region Add Data
        //public static List<DISR190001> Create(
        //    DateTime target_date,
        //    decimal target_amount,
        //    decimal target_amount_jam_ke_1,
        //    decimal target_amount_jam_ke_2,
        //    decimal target_amount_jam_ke_3,
        //    decimal targer_amount_jam_ke_4,
        //    decimal target_amount_jam_ke_5,
        //    decimal target_amount_jam_ke_6,
        //    decimal target_amount_jam_ke_7,
        //    decimal target_amount_jam_ke_8,
        //    decimal target_amount_jam_ke_9,
        //    decimal terget_amount_jam_ke_10,
        //    decimal target_amount_jam_ke_11,
        //    decimal target_amount_jam_ke_12,
        //    decimal target_amount_jam_ke_13,
        //    decimal target_amount_jam_ke_14,
        //    decimal target_amount_jam_ke_15_16_istirahat,
        //    decimal target_amount_jam_ke_17,
        //    decimal target_amount_jam_ke_18,
        //    decimal target_amount_jam_ke_19,
        //    decimal target_amount_jam_ke_20,
        //    decimal target_amount_jam_ke_21,
        //    decimal target_amount_jam_ke_22,
        //    string username)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<DISR190001>("DISR190001/DISR190001_Create", new
        //    {
        //        target_date,
        //        target_amount,
        //        target_amount_jam_ke_1,
        //        target_amount_jam_ke_2,
        //        target_amount_jam_ke_3,
        //        targer_amount_jam_ke_4,
        //        target_amount_jam_ke_5,
        //        target_amount_jam_ke_6,
        //        target_amount_jam_ke_7,
        //        target_amount_jam_ke_8,
        //        target_amount_jam_ke_9,
        //        terget_amount_jam_ke_10,
        //        target_amount_jam_ke_11,
        //        target_amount_jam_ke_12,
        //        target_amount_jam_ke_13,
        //        target_amount_jam_ke_14,
        //        target_amount_jam_ke_15_16_istirahat,
        //        target_amount_jam_ke_17,
        //        target_amount_jam_ke_18,
        //        target_amount_jam_ke_19,
        //        target_amount_jam_ke_20,
        //        target_amount_jam_ke_21,
        //        target_amount_jam_ke_22,
        //        username
        //    });
        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Delete Data
        //public string Delete_Data(DateTime ID)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.SingleOrDefault<string>("DISR190001/DISR190001_Delete", new
        //    {
        //        ID
        //    });
        //    db.Close();
        //    return d;
        //}
        //#endregion

        //#region Update Data
        //public List<DISR190001> Update_Data(
        //    DateTime ID,
        //    DateTime target_date,
        //    decimal target_amount,
        //    decimal target_print,
        //    decimal target_amount_jam_ke_1,
        //    decimal target_amount_jam_ke_2,
        //    decimal target_amount_jam_ke_3,
        //    decimal targer_amount_jam_ke_4,
        //    decimal target_amount_jam_ke_5,
        //    decimal target_amount_jam_ke_6,
        //    decimal target_amount_jam_ke_7,
        //    decimal target_amount_jam_ke_8,
        //    decimal target_amount_jam_ke_9,
        //    decimal terget_amount_jam_ke_10,
        //    decimal target_amount_jam_ke_11,
        //    decimal target_amount_jam_ke_12,
        //    decimal target_amount_jam_ke_13,
        //    decimal target_amount_jam_ke_14,
        //    decimal target_amount_jam_ke_15_16_istirahat,
        //    decimal target_amount_jam_ke_17,
        //    decimal target_amount_jam_ke_18,
        //    decimal target_amount_jam_ke_19,
        //    decimal target_amount_jam_ke_20,
        //    decimal target_amount_jam_ke_21,
        //    decimal target_amount_jam_ke_22,
        //    string username)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<DISR190001>("DISR190001/DISR190001_Update", new
        //    {
        //        ID,
        //        target_date,
        //        target_amount,
        //        target_print,
        //        target_amount_jam_ke_1,
        //        target_amount_jam_ke_2,
        //        target_amount_jam_ke_3,
        //        targer_amount_jam_ke_4,
        //        target_amount_jam_ke_5,
        //        target_amount_jam_ke_6,
        //        target_amount_jam_ke_7,
        //        target_amount_jam_ke_8,
        //        target_amount_jam_ke_9,
        //        terget_amount_jam_ke_10,
        //        target_amount_jam_ke_11,
        //        target_amount_jam_ke_12,
        //        target_amount_jam_ke_13,
        //        target_amount_jam_ke_14,
        //        target_amount_jam_ke_15_16_istirahat,
        //        target_amount_jam_ke_17,
        //        target_amount_jam_ke_18,
        //        target_amount_jam_ke_19,
        //        target_amount_jam_ke_20,
        //        target_amount_jam_ke_21,
        //        target_amount_jam_ke_22,                                
        //        username
        //    });
        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Division
        //public List<DivisionModel> getDivision()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<DivisionModel>("DISR190001/DISR190001_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<CompanyModel>("DISR190001/DISR190001_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<IdentityModel>("DISR190001/DISR190001_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<SectionModel>("DISR190001/DISR190001_getSection", new
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
        //    var d = db.Fetch<PICModel>("DISR190001/DISR190001_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISR190001/DISR190001_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    #region DEKLARASI DETAIL_DATA
    //Detail Proses
    public class DISR190001Detail
    {
        public string ID { get; set; }
        public string ID_PRODUKSI { get; set; }
        public string ID_SEISAN { get; set; }
        public string ID_SEIHIN { get; set; }
        public string ID_HINMOKU { get; set; }
        public string OTHER_LOTNO { get; set; }
        public string LOT { get; set; }
        public string ID_KOTEI { get; set; }
        public string ID_KIKAI { get; set; }
        public string TIME_SAGYO { get; set; }
        public string TIME_DANDORI { get; set; }
        public string TIME_KOSHIN { get; set; }
        public string TIME_KANRYO { get; set; }
        public string TIME_SAKUSEI { get; set; }
        public string AMNT_YOTEI { get; set; }
        public string AMNT_OK { get; set; }
        public string AMNT_PND { get; set; }
        public string AMNT_NG { get; set; }
        public string QTY_TOTAL { get; set; }
        public string ID_SAGYOSHA1 { get; set; }
        public string NAME_SAGYOSHA1 { get; set; }
        public string ID_SAGYOSHA2 { get; set; }
        public string ID_SAGYOSHA3 { get; set; }
        public string Z_INPUTUSER_ADM { get; set; }
        public string FRG_OUTPUT { get; set; }

        //Master Kotei
        public string NAME_KOTEI { get; set; }

        //Master Kikai
        public string NAME_KIKAI { get; set; }

        //Master Sagyosha
        //public string NAME_SAGYOSHA { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    //Detail Parts
    public class DISR190001Detail_Parts
    {
        public string ID { get; set; }
        public string CODE { get; set; }
        public string KCODE { get; set; }
        public string NAME { get; set; }
        public string OYANAME { get; set; }
        public string KONAME { get; set; }
        public string BUMONAME { get; set; }
        public string BUNR { get; set; }
        public string KOBUNR { get; set; }
        public string DORIREKIOYA { get; set; }
        public string DORIREKIKO { get; set; }
        public string DOSEIBAN { get; set; }
        public string LINKSLIP { get; set; }
        public string BUMO { get; set; }
        public string MAINBUMO { get; set; }
    }
    #endregion

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    public class ExecutorModel
    {
        public DateTime ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISR190001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR190001(int countdata, int positionpage, int dataperpage)
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