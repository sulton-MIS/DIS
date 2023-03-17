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
        //public List<DISA090002Master> getDataDISA090002(int Start, int Display, DateTime TARGET_DATE, decimal TARGET_AMOUNT, decimal TARGET_PRINT, decimal T_JAM_KE_1, decimal T_JAM_KE_2, decimal T_JAM_KE_3, decimal T_JAM_KE_4, decimal T_JAM_KE_5, decimal T_JAM_KE_6, decimal T_JAM_KE_7, decimal T_JAM_KE_8, decimal T_JAM_KE_9, decimal T_JAM_KE_10, decimal T_JAM_KE_11, decimal T_JAM_KE_12, decimal T_JAM_KE_13, decimal T_JAM_KE_14, decimal T_JAM_KE_15_16, decimal T_JAM_KE_17, decimal T_JAM_KE_18, decimal T_JAM_KE_19, decimal T_JAM_KE_20, decimal T_JAM_KE_21, decimal T_JAM_KE_22)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<DISA090002Master>("DISA090002/DISA090002_SearchData", new
        //    {
        //        START = Start,
        //        DISPLAY = Display,
        //        TARGET_DATE,
        //        TARGET_AMOUNT,
        //        TARGET_PRINT,
        //        T_JAM_KE_1,
        //        T_JAM_KE_2,
        //        T_JAM_KE_3,
        //        T_JAM_KE_4,
        //        T_JAM_KE_5,
        //        T_JAM_KE_6,
        //        T_JAM_KE_7,
        //        T_JAM_KE_8,
        //        T_JAM_KE_9,
        //        T_JAM_KE_10,
        //        T_JAM_KE_11,
        //        T_JAM_KE_12,
        //        T_JAM_KE_13,
        //        T_JAM_KE_14,
        //        T_JAM_KE_15_16,
        //        T_JAM_KE_17,
        //        T_JAM_KE_18,
        //        T_JAM_KE_19,
        //        T_JAM_KE_20,
        //        T_JAM_KE_21,
        //        T_JAM_KE_22
        //    });
        //    db.Close();
        //    return d.ToList();
        //}
        #endregion

        #region Count_Get_Data_Grid_DISA090002
        //public int getCountDISA090002(string DATA_ID, DateTime TARGET_DATE, decimal TARGET_AMOUNT, decimal TARGET_PRINT, decimal T_JAM_KE_1, decimal T_JAM_KE_2, decimal T_JAM_KE_3, decimal T_JAM_KE_4, decimal T_JAM_KE_5, decimal T_JAM_KE_6, decimal T_JAM_KE_7, decimal T_JAM_KE_8, decimal T_JAM_KE_9, decimal T_JAM_KE_10, decimal T_JAM_KE_11, decimal T_JAM_KE_12, decimal T_JAM_KE_13, decimal T_JAM_KE_14, decimal T_JAM_KE_15_16, decimal T_JAM_KE_17, decimal T_JAM_KE_18, decimal T_JAM_KE_19, decimal T_JAM_KE_20, decimal T_JAM_KE_21, decimal T_JAM_KE_22)
        //{

        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    int result = db.SingleOrDefault<int>("DISA090002/DISA090002_SearchCount", new
        //    {
        //        DATA_ID = DATA_ID,
        //        TARGET_DATE,
        //        TARGET_AMOUNT,
        //        TARGET_PRINT,
        //        T_JAM_KE_1,
        //        T_JAM_KE_2,
        //        T_JAM_KE_3,
        //        T_JAM_KE_4,
        //        T_JAM_KE_5,
        //        T_JAM_KE_6,
        //        T_JAM_KE_7,
        //        T_JAM_KE_8,
        //        T_JAM_KE_9,
        //        T_JAM_KE_10,
        //        T_JAM_KE_11,
        //        T_JAM_KE_12,
        //        T_JAM_KE_13,
        //        T_JAM_KE_14,
        //        T_JAM_KE_15_16,
        //        T_JAM_KE_17,
        //        T_JAM_KE_18,
        //        T_JAM_KE_19,
        //        T_JAM_KE_20,
        //        T_JAM_KE_21,
        //        T_JAM_KE_22
        //    });
        //    db.Close();
        //    return result;
        //}
        #endregion

        //#region Add Data
        //public static List<DISA090002> Create(
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
        //    var d = db.Fetch<DISA090002>("DISA090002/DISA090002_Create", new
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
        //    var d = db.SingleOrDefault<string>("DISA090002/DISA090002_Delete", new
        //    {
        //        ID
        //    });
        //    db.Close();
        //    return d;
        //}
        //#endregion

        //#region Update Data
        //public List<DISA090002> Update_Data(
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
        //    var d = db.Fetch<DISA090002>("DISA090002/DISA090002_Update", new
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
        //    var d = db.Fetch<DivisionModel>("DISA090002/DISA090002_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<CompanyModel>("DISA090002/DISA090002_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<IdentityModel>("DISA090002/DISA090002_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<SectionModel>("DISA090002/DISA090002_getSection", new
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
        //    var d = db.Fetch<PICModel>("DISA090002/DISA090002_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

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

    //public class StatusModel
    //{
    //    public DateTime ID { get; set; }
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
    //    public DateTime ID { get; set; }
    //    public string COMPANY { get; set; }
    //}

    //public class IdentityModel
    //{
    //    public DateTime ID { get; set; }
    //    public DateTime IDENTITY_TEXT { get; set; }
    //}

    //public class PICModel
    //{
    //    public DateTime ID { get; set; }
    //    public string PIC_TEXT { get; set; }
    //}

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    //public class SectionModel
    //{
    //    public DateTime ID { get; set; }
    //    public string SECTION_TEXT { get; set; }
    //}

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