using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.WP03008Master
{
    public class WP03008Repository
    {
        #region Get_Data_Grid_WP03008
        public List<WP03008Master> getDataWP03008(int Start, int Display, string EMPLOYEE_NAME, string IDENTITYNUMBER, string COMPANY, string ANZENNO, string INDUCTION)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03008Master>("WP03008/WP03008_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                EMPLOYEE_NAME,
                IDENTITYNUMBER,
                COMPANY,
                ANZENNO,
                INDUCTION
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03008
        public int getCountWP03008(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string EMPLOYEE_NAME, string IDENTITYNUMBER, string COMPANY, string ANZENNO, string INDUCTION)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03008/WP03008_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                EMPLOYEE_NAME,
                IDENTITYNUMBER,
                COMPANY,
                ANZENNO,
                INDUCTION
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03008/WP03008_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP03008> Update_Data(string ID, string NOREG, string COMPANY, string FIRSTNAME, string LASTNAME, string EMAIL, string ADDRESS,string PHONE,string IDENTITY_TYPE,string IDENTITY_NO,string SAFETY_INDUCTION_NO,string SAFETY_INDUCTION_FROM,string SAFETY_INDUCTION_TO, string STATUS, string GENDER, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03008>("WP03008/WP03008_Update", new
            {
                ID,
                NOREG,
                COMPANY,
                FIRSTNAME,
                LASTNAME,
                EMAIL,
                ADDRESS,
                PHONE,
                IDENTITY_TYPE,
                IDENTITY_NO,
                SAFETY_INDUCTION_NO,
                SAFETY_INDUCTION_FROM,
                SAFETY_INDUCTION_TO,
                STATUS,
                GENDER,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP03008> Create(string COMPANY, string REGNUMBER, string EMAIL, string SECTION, string FIRSTNAME, string LASTNAME, string ADDRESS, string PHONE, string IDENTITY_TYPE, string IDENTITY_NO, string PIC_STATUS, string ANZEN_NO, string ANZEN_DT_FROM, string ANZEN_DT_TO, string SAFETY_INDUCTION_NO, string SAFETY_INDUCTION_FROM, string SAFETY_INDUCTION_TO, string SEQ_NO, string STATUS, string GENDER, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03008>("WP03008/WP03008_Create", new
            {
                COMPANY,
                REGNUMBER,
                FIRSTNAME,
                LASTNAME,
                EMAIL,
                SECTION,
                ADDRESS,
                PHONE,
                IDENTITY_TYPE,
                IDENTITY_NO,
                ANZEN_NO,
                ANZEN_DT_FROM,
                ANZEN_DT_TO,
                SAFETY_INDUCTION_NO,
                SAFETY_INDUCTION_FROM,
                SAFETY_INDUCTION_TO,
                SEQ_NO,
                STATUS,
                GENDER,
                PIC_STATUS,
                username
            });
            db.Close();
            return d.ToList();
        }

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("WP03008/WP03008_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get ANZEN
        public List<AnzenModel> getAnzen(string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AnzenModel>("WP03008/WP03008_getAnzen", new { username });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Check Contractor
        public List<CheckContractor> CheckNIK(string NIK)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CheckContractor>("WP03008/WP03008_checkNIK", new { NIK });

            db.Close();
            return d.ToList();
        }
        #endregion


        #region Get Project Location
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("WP03008/WP03008_getCompany");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Identity
        public List<IdentityModel> getIdentity()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<IdentityModel>("WP03008/WP03008_getIdentity");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Section
        public List<SectionModel> getSection(string SYSTEM_CD)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<SectionModel>("WP03008/WP03008_getSection", new {
                SYSTEM_CD
            });

            db.Close();
            return d.ToList();
        }



        #endregion

        #region Get PIC
        public List<PICModel> getPIC()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<PICModel>("WP03008/WP03008_getPic");

            db.Close();
            return d.ToList();
        }
        #endregion



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExecutorModel>("WP03008/WP03008_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class StatusModel
    {
        public string ID { get; set; }
        public string Status { get; set; }
    }

    public class DivisionModel
    {
        public string Division { get; set; }
        public string DIV { get; set; }
        public string DIV_ID { get; set; }
    }

    public class AnzenModel
    {
        public string ANZEN_NO { get; set; }
        public string ANZEN_FROM { get; set; }
        public string ANZEN_TO { get; set; }
    }

    public class CheckContractor
    {
        public string NIK { get; set; }
        public string FIRST_NAME {get;set;}
        public string  LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public string REG_NO { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
        public string GENDER { get; set; }
        public string ID_COMPANY { get; set; }
        public string COMPANY_NAME { get; set; }
        public string SAFETY_INDUCTION_NO { get; set; }
        public string SAFETY_INDUCTION_FROM { get; set; }
        public string SAFETY_INDUCTION_TO { get; set; }
        public string ID_TB_M_EMPLOYEE { get; set; }
        public string END_DATE { get; set; }
        public string STATUS_EMPLOYEE { get; set; }
    }

    public class CompanyModel
    {
        public string ID { get; set; }
        public string COMPANY { get; set; }
    }

    public class IdentityModel
    {
        public string ID { get; set; }
        public string IDENTITY_TEXT { get; set; }
    }

    public class PICModel
    {
        public string ID { get; set; }
        public string PIC_TEXT { get; set; }
    }

    public class SectionModel
    {
        public string ID { get; set; }
        public string SECTION_TEXT { get; set; }
    }

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_WP03008
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03008(int countdata, int positionpage, int dataperpage)
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