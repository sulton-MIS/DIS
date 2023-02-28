using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR190002Master
{
    public class DISR190002Repository
    {
        #region Get Detail Data Tipe
        public List<DISR190002Master> get_Data_Tipe(string ID_SEISAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR190002Master>("DISR190002/DISR190002_getDataTipe", new
            {
                ID_SEISAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion
        
        #region Get Detail Data All Tipe
        public List<DISR190002Master> get_Data_All_Tipe()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR190002Master>("DISR190002/DISR190002_getDataAllTipe", new{ });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISR190002
        public List<DISR190002Master> getDataDISR190002(int Start, int Display, string ID_SEISAN, string ID_HINMOKU)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR190002Master>("DISR190002/DISR190002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ID_SEISAN,
                ID_HINMOKU
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Similar_Type
        //Detail Parts
        public List<DISR190002Similar_Type> GetData_Similar_ByCode(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR190002Similar_Type>("DISR190002/DISR190002_SearchData_ItemCode", new
            {
                DMC_CODE
            }).ToList();
            db.Close();
            return d;
        }
        #endregion


        #region Count_Get_Data_Grid_DISR190002
        public int getCountDISR190002(string DATA_ID, string ID_SEISAN, string ID_HINMOKU)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR190002/DISR190002_SearchCount", new
            {
                DATA_ID = DATA_ID
                ,ID_SEISAN
                ,ID_HINMOKU
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get_Data_Grid_DISR190002_ItemCode
        //public List<DISR190002Master> getDataDISR190002_ItemCode(int Start, int Display, string CODE)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<DISR190002Master>("DISR190002/DISR190002_SearchData_ItemCode", new
        //    {
        //        START = Start,
        //        DISPLAY = Display,
        //        CODE
        //    });
        //    db.Close();
        //    return d.ToList();
        //}
        #endregion

        #region Count_Get_Data_Grid_DISR190002_ItemCode
        //public int getCountDISR190002_ItemCode(string DATA_ID, string CODE)
        //{

        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    int result = db.SingleOrDefault<int>("DISR190002/DISR190002_SearchCount_ItemCode", new
        //    {
        //        DATA_ID = DATA_ID
        //        ,CODE
        //    });
        //    db.Close();
        //    return result;
        //}
        #endregion

        //#region Add Data
        //public static List<DISR190002> Create(
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
        //    var d = db.Fetch<DISR190002>("DISR190002/DISR190002_Create", new
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
        //    var d = db.SingleOrDefault<string>("DISR190002/DISR190002_Delete", new
        //    {
        //        ID
        //    });
        //    db.Close();
        //    return d;
        //}
        //#endregion

        //#region Update Data
        //public List<DISR190002> Update_Data(
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
        //    var d = db.Fetch<DISR190002>("DISR190002/DISR190002_Update", new
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
        //    var d = db.Fetch<DivisionModel>("DISR190002/DISR190002_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<CompanyModel>("DISR190002/DISR190002_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<IdentityModel>("DISR190002/DISR190002_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<SectionModel>("DISR190002/DISR190002_getSection", new
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
        //    var d = db.Fetch<PICModel>("DISR190002/DISR190002_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISR190002/DISR190002_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class DISR190002Similar_Type
    {
        public string ID { get; set; }
        public string CODE { get; set; }
    }


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

    public class PagingModel_DISR190002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR190002(int countdata, int positionpage, int dataperpage)
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