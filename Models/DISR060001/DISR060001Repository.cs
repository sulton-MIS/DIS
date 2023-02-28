using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR060001Master
{
    public class DISR060001Repository
    {
        #region Get_Data_Grid_DISR060001
        public List<DISR060001Master> getDataDISR060001(int Start, int Display, string i_user, string dept, string e_mail)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR060001Master>("DISR060001/DISR060001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,                
                i_user,
                dept,
                e_mail
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISR060001
        public int getCountDISR060001(string DATA_ID, string i_user, string dept, string e_mail)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            int result = db.SingleOrDefault<int>("DISR060001/DISR060001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                i_user,
                dept,
                e_mail
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISR060001> Create(string i_user, string c_pwd, string i_user_long, string dept, string authority, string e_mail, string EmailSender, string section, string IdLevel, string IdAccesable)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR060001>("DISR060001/DISR060001_Create", new
            {
                i_user,
                c_pwd,
                i_user_long,
                dept,
                authority,
                e_mail,     
                EmailSender,
                section,
                IdLevel,
                IdAccesable
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.SingleOrDefault<string>("DISR060001/DISR060001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISR060001> Update_Data(string ID, string i_user, string c_pwd, string i_user_long, string dept, string authority, string e_mail, string EmailSender, string section, string IdLevel, string IdAccesable)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR060001>("DISR060001/DISR060001_Update", new
            {
                ID,
                i_user,
                c_pwd,
                i_user_long,
                dept,
                authority,
                e_mail,
                EmailSender,
                section,
                IdLevel,
                IdAccesable
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        //#region Get Division
        //public List<DivisionModel> getDivision()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<DivisionModel>("DISR060001/DISR060001_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<CompanyModel>("DISR060001/DISR060001_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<IdentityModel>("DISR060001/DISR060001_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<SectionModel>("DISR060001/DISR060001_getSection", new
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
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
        //    var d = db.Fetch<PICModel>("DISR060001/DISR060001_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<ExecutorModel>("DISR060001/DISR060001_getExecutor");

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

    public class PagingModel_DISR060001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR060001(int countdata, int positionpage, int dataperpage)
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