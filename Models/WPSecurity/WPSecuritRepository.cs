using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WPSecurityMaster
{
    public class WPSecurityRepository
    {
        #region Get Contractor
        //public List<WPSecurityMaster> GetContractor(string EMPLOYEE, string COMPANY, string IMPLEMENT_FROM, string IMPLEMENT_TO)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
        //    var d = db.Fetch<WPSecurityMaster>("WPSecurity/WPSecurity_SearchContractor", new
        //    {
        //        EMPLOYEE,
        //        COMPANY,
        //        IMPLEMENT_FROM,
        //        IMPLEMENT_TO
        //    });
        //    db.Close();
        //    return d.ToList();
        //}
        public List<WPSecurityMaster> GetContractor(
            string MDATE,
            string NIK,
            string NAMA,
            string GRP,
            string HARI_01,
            string HARI_02,
            string HARI_03,
            string HARI_04,
            string HARI_05,
            string HARI_06,
            string HARI_07,
            string HARI_08,
            string HARI_09,
            string HARI_10,
            string HARI_11,
            string HARI_12,
            string HARI_13,
            string HARI_14,
            string HARI_15,
            string HARI_16,
            string HARI_17,
            string HARI_18,
            string HARI_19,
            string HARI_20,
            string HARI_21,
            string HARI_22,
            string HARI_23,
            string HARI_24,
            string HARI_25,
            string HARI_26,
            string HARI_27,
            string HARI_28,
            string HARI_29,
            string HARI_30,
            string HARI_31
            )            
        {
            //DateTime parm_mdate = DateTime.Today;
            //parm_mdate = INITIAL_MDATE;
     

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<WPSecurityMaster>("WPSecurity/WPSecurity_SearchContractor", new
            {
                MDATE,
                NIK,
                NAMA,
                GRP,
                HARI_01,
                HARI_02,
                HARI_03,
                HARI_04,
                HARI_05,
                HARI_06,
                HARI_07,
                HARI_08,
                HARI_09,
                HARI_10,
                HARI_11,
                HARI_12,
                HARI_13,    
                HARI_14,
                HARI_15,
                HARI_16,
                HARI_17,
                HARI_18,
                HARI_19,
                HARI_20,
                HARI_21,
                HARI_22,
                HARI_23,
                HARI_24,
                HARI_25,
                HARI_26,
                HARI_27,
                HARI_28,
                HARI_29,
                HARI_30,
                HARI_31

            });          
           
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get GetDataScan
        public List<WPScanMaster> GetDataScan(string scanQR, string TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPScanMaster>("WPSecurity/WPSecurity_scanQR", new
            {
                scanQR,
                TYPE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get GetDataEmployeeDetail
        public List<WPEmployeeDetail> GetDataEmployeeDetail(string scanQR, string TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPEmployeeDetail>("WPSecurity/WPSecurity_getEmployeeDetail", new
            {
                scanQR,
                TYPE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get NIK
        public string GetNIK(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.SingleOrDefault<string>("WPSecurity/WPSecurity_getNIK", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Get GetWpProjectJobID
        public string GetWpProjectJobID(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.SingleOrDefault<string>("WPSecurity/WPSecurity_GetWpProjectJobID", new { ID });
            db.Close();
            return d;
        }
        #endregion
        #region Get getImplementor
        public List<WpImplementor> getImplementor(string TYPE, string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WpImplementor>("WPSecurity/WPSecurity_getImplementor", new { ID, TYPE });
            db.Close();
            return d.ToList();
        }
        # endregion

        #region Get getIMPBDetail
        public List<WPIMPBDetail> getIMPBDetail(string TYPE, string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPIMPBDetail>("WPSecurity/WPSecurity_getIMPBDetail", new { TYPE, ID });
            db.Close();
            return d.ToList();
        }
        # endregion

        #region Get getTotalContractor
        public List<WPTotalContractor> getTotalContractor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPTotalContractor>("WPSecurity/WPSecurity_getTotalContractor");
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get getTotalContractor
        public List<HealtyModel> getHealtyCheck()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<HealtyModel>("WPSecurity/WPSecurity_getHealtyCheck");
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get getDashboardTable
        public List<WPSecurityMaster> getDashboardTable(int page, int start, int end)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPSecurityMaster>("WPSecurity/WPSecurity_getDashboardTable", new
            {
                page,
                start,
                end
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get SECURITY CHECK
        public List<WPSecurityMaster> CHECK_DATA_SECURITY(string ID, string IMPB_NO, string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPSecurityMaster>("WPSecurity/WPSecurity_Check", new
            {
                ID,
                IMPB_NO,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Check Out
        public int getCheckOut(string ID, string IMPB_NO, string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.SingleOrDefault<int>("WPSecurity/WPSecurity_getCheckOut", new
            {
                ID,
                IMPB_NO,
                Username
            });
            db.Close();
            return d;
        }
        #endregion

        public List<WPSecurity> getMarqueeText()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("Localhost");
            var d = db.Fetch<WPSecurity>("WPSecurity/WPSecurity_MarqueeText");
            db.Close();
            return d.ToList();
        }

        public class WPTotalContractor
        {
            public string TOTAL_KONTRAKTOR { get; set; }
            public string TOTAL_IN { get; set; }
            public string TOTAL_OUT { get; set; }
        }

        public class WpImplementor
        {
            public string PIMPINAN_PELAKSANA { get; set; }
            public string PENGAWAS_PELAKSANA { get; set; }
            public string PELAKSANA_PROYEK { get; set; }
            public string SECTION_OR_DIV { get; set; }

        }

        public class WPIMPBDetail
        {
            public string PROJECT_NAME { get; set; }
            public string ID_PROJECT { get; set; }
            public string LOKASI_PROYEK { get; set; }
            public string AREA { get; set; }
            public string STATUS_IJIN_KERJA { get; set; }
            public string DIVISI { get; set; }
            public string IMPB_NO { get; set; }
            public string MULAI_PELAKSANAAN { get; set; }
            public string AKHIR_PELAKSANAAN { get; set; }
            public string JAM_PELAKSANAAN { get; set; }

        }

        public class HealtyModel
        {
            public string STATUS { get; set; }
            public string MESSAGE_TEXT { get; set; }
        }

        public class WPEmployeeDetail
        {
            public string ID { get; set; }
            public string REG_NO { get; set; }
            public string ANZEN_LEADER { get; set; }
            public string ANZEN_SERTIFICATE_NO { get; set; }
            public string ANZEN_DT_FROM { get; set; }
            public string ANZEN_DT_TO { get; set; }
            public string SAFETY_INDUCTION_NO { get; set; }
            public string VALID_DARI { get; set; }
            public string VALID_SAMPAI { get; set; }
            public string FIRST_NAME { get; set; }
            public string LAST_NAME {get; set;}
            public string NO_IDENTITY { get; set; }
            public string IDENTITY_NO { get; set; }
            public string IDENTITY_TYPE { get; set; }
            public string ADDRESS { get; set; }
            public string SECTION { get; set; }
            public string EMAIL { get; set; }
            public string PHONE { get; set; }
            public string PIC_STATUS { get; set; }
            public string GENDER { get; set; }
            public string COMPANY { get; set; }

    }

        public class WPScanMaster
        {
            public string ID { get; set; }
            public string IMPB_NO { get; set; }
            public string NAMA_PROYEK { get; set; }
            public string AREA { get; set; }
            public string LOKASI_PROYEK { get; set; }
            public string STATUS_IJIN_KERJA { get; set; }
            public string DIVISI { get; set; }
            public string ANZEN_SERTIFICATE_NO { get; set; }
            public string ANZEN_VALID_FROM { get; set; }
            public string ANZEN_VALID_TO { get; set; }
            public string IDENTITY_TYPE { get; set; }
            public string NO_IDENTITY { get; set; }
            public string CHECK_IN { get; set; }
            public string PHONE { get; set; }
            public string PIC_STATUS { get; set; }
            public string COMPANY { get; set; }
            public string PELAKSANA_PROYEK { get; set; }
            public string BAGIAN { get; set; }
            public string PIMPINAN_PELAKSANAAN { get; set; }
            public string PENGAWAS_PELAKSANAAN { get; set; }
            public string MULAI_PELAKSANAAN { get; set; }
            public string AKHIR_PELAKSANAAN { get; set; }
            public string JAM_PELAKSANAAN { get; set; }
            public string FOTO { get; set; }
            public string REG_NO { get; set; }
            public string ANZEN_LEADER { get; set; }
            public string ANZEN_NO { get; set; }
            public string FIRST_NAME { get; set; }
            public string LAST_NAME { get; set; }
            public string NO_SAFETY_INDUCTION { get; set; }
            public string VALID_DARI { get; set; }
            public string VALID_SAMPAI { get; set; }
            public string SECTION { get; set; }
            public string SECURITY_CHECK { get; set; }
            public string ID_PROJECT { get; set; }
            public string STACK { get; set; }
            public string LINE_STS { get; set; }
        }
    }
}