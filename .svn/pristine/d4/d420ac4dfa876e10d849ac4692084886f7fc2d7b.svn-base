using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using AI070.Models.WP02003;
using System.Runtime.CompilerServices;

namespace AI070.Models.WP02003Master
{
    public class WP02003Repository
    {

        #region Get_Data_Grid_WP02003
        public List<WP02003Master> getDataWP02003(int Start, int Display, string PROJECT_NAME, string COMPANY, string TITLE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02003Master>("WP02003/WP02003_SearchData", new {
                START = Start,
                DISPLAY = Display,
                PROJECT_NAME,
                COMPANY,
                TITLE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP02001
        public int getCountWP02003(string PROJECT_NAME, string COMPANY, string TITLE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP02003/WP02003_SearchCount", new
            {
                PROJECT_NAME,
                COMPANY,
                TITLE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP02003/WP02003_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public static List<WP02003InputForm> Update(WP02003InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            db.BeginTransaction();

            var wpdaily = db.Fetch<WP02003InputForm>("WP02003/WP02003_Update_TB_R_WP_DAILY", new
            {
                items.TB_R_WP_DAILY_ID,
                items.WP_PROJECT_ID,
                items.WP_PROJECT_JOB_ID,
                items.JOB_TITLE,
                items.DAILY_DOC,
                username
            });
            foreach (var item in items.LISTDATADAILYWORKEQUIPMENT)
            {
                var dailyworkequipment = db.Fetch<DATADAILYWORKEQUIPMENT>("WP02003/WP02003_Update_TB_R_WP_DAILY_WORK_EQUIPMENT", new
                {
                    item.TB_R_WP_DAILY_WORK_EQUIPMENT_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_ITEM_ID,
                    item.ACTION,
                    username
                });
            }
            foreach (var item in items.LISTDATADAILYUTILREQUEST)
            {
                var dailyutilrequest = db.Fetch<DATADAILYUTILREQUEST>("WP02003/WP02003_Update_TB_R_WP_DAILY_UTIL_REQUEST", new
                {
                    item.TB_R_WP_DAILY_UTIL_REQUEST_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_ITEM_ID,
                    item.ACTION,
                    username
                });
            }
            foreach (var item in items.LISTDATADAILYAPD)
            {
                var dailyapd = db.Fetch<DATADAILYAPD>("WP02003/WP02003_Update_TB_R_WP_DAILY_APD", new
                {
                    item.TB_R_WP_DAILY_APD_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_ITEM_ID,
                    item.ACTION,
                    username
                });
            }
            foreach (var item in items.LISTDATADAILYWORKERLIST)
            {
                var dailyapd = db.Fetch<DATADAILYWORKERLIST>("WP02003/WP02003_Update_TB_R_WP_DAILY_WORKER_LIST", new
                {
                    item.TB_R_WP_DAILY_WORKER_LIST_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_EMPLOYEE_ID,
                    item.ACTION,
                    username
                });
            }
            foreach (var item in items.LISTDATADAILYWIDEN)
            {
                var dailyapd = db.Fetch<DATADAILYWIDEN>("WP02003/WP02003_Update_TB_R_WP_DAILY_WI_DEN", new
                {
                    item.TB_R_WP_DAILY_WI_DEN_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.WORKING_NAME,
                    item.TIME_FROM,
                    item.TIME_TO,
                    item.STOP_SIX,
                    item.TB_M_EMPLOYEE_ID,
                    item.ACTION,
                    username
                });
            }

            db.CommitTransaction();

            db.Close();
            return wpdaily.ToList();
        }
        #endregion

        public static List<WP02003InputForm> Create(WP02003InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            //db.BeginTransaction();
            
            var wpdaily = db.Fetch<WP02003InputForm>("WP02003/WP02003_Create_TB_R_WP_DAILY", new
            {
                items.TB_R_WP_DAILY_ID,
                items.WP_PROJECT_ID,
                items.WP_PROJECT_JOB_ID,
                items.JOB_TITLE,
                items.DAILY_DOC,
                items.STATUS,
                username
            });

            foreach (var item in items.LISTDATADAILYWORKEQUIPMENT)
            {
                var dailyworkequipment = db.Fetch<DATADAILYWORKEQUIPMENT>("WP02003/WP02003_Create_TB_R_WP_DAILY_WORK_EQUIPMENT", new
                {
                    item.TB_R_WP_DAILY_WORK_EQUIPMENT_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_ITEM_ID,
                    username
                });
            }

            foreach (var item in items.LISTDATADAILYUTILREQUEST)
            {
                var dailyutilrequest = db.Fetch<DATADAILYUTILREQUEST>("WP02003/WP02003_Create_TB_R_WP_DAILY_UTIL_REQUEST", new
                {
                    item.TB_R_WP_DAILY_UTIL_REQUEST_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_ITEM_ID,
                    username
                });
            }

            foreach (var item in items.LISTDATADAILYAPD)
            {
                var dailyapd = db.Fetch<DATADAILYAPD>("WP02003/WP02003_Create_TB_R_WP_DAILY_APD", new
                {
                    item.TB_R_WP_DAILY_APD_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_ITEM_ID,
                    username
                });
            }

            foreach (var item in items.LISTDATADAILYWORKERLIST)
            {
                var dailyapd = db.Fetch<DATADAILYWORKERLIST>("WP02003/WP02003_Create_TB_R_WP_DAILY_WORKER_LIST", new
                {
                    item.TB_R_WP_DAILY_WORKER_LIST_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.TB_M_EMPLOYEE_ID,
                    username
                });
            }

            foreach (var item in items.LISTDATADAILYWIDEN)
            {
                var dailyapd = db.Fetch<DATADAILYWIDEN>("WP02003/WP02003_Create_TB_R_WP_DAILY_WI_DEN", new
                {
                    item.TB_R_WP_DAILY_WI_DEN_ID,
                    item.TB_R_WP_DAILY_ID,
                    item.WORKING_NAME,
                    item.TIME_FROM,
                    item.TIME_TO,
                    item.STOP_SIX,
                    item.TB_M_EMPLOYEE_ID,
                    username
                });
            }

            //db.CommitTransaction();

            db.Close();
            return wpdaily.ToList();
        }

        #region Get Project 

        public List<ProjectModel> getProject()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ProjectModel>("WP02003/WP02003_getProject");

            db.Close();
            return d.ToList();
        }
        #endregion

      

        #region Get project job
        public List<ProjectJobModel> getProjectJob(string WP_PROJECT_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ProjectJobModel>("WP02003/WP02003_getProjectJob", new
            {
                WP_PROJECT_ID = WP_PROJECT_ID
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Work Item
        public List<WorkItemModel> getWorkItem()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            //var d = db.Fetch<WorkItemModel>("WP02001/WP02001_getProjectJob", new
            //{
            //    WP_PROJECT_ID = WP_PROJECT_ID
            //});
            var d = db.Fetch<WorkItemModel>("WP02003/WP02003_getWorkItem");

            db.Close();
            return d.ToList();
        }
        #endregion


        #region Get Utility Item Request
        public List<WorkItemModel> getUtilityItemRequest()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            //var d = db.Fetch<WorkItemModel>("WP02001/WP02001_getProjectJob", new
            //{
            //    WP_PROJECT_ID = WP_PROJECT_ID
            //});
            var d = db.Fetch<WorkItemModel>("WP02003/WP02003_getUtilityItemRequest");

            db.Close();
            return d.ToList();
        }
        #endregion


        #region Get APD
        public List<WorkItemModel> getAPD()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            //var d = db.Fetch<WorkItemModel>("WP02001/WP02001_getProjectJob", new
            //{
            //    WP_PROJECT_ID = WP_PROJECT_ID
            //});
            var d = db.Fetch<WorkItemModel>("WP02003/WP02003_getAPD");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get APD
        public List<PekerjaModel> getListPekerja(string COMPANY)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<PekerjaModel>("WP02003/WP02003_getListPekerja", new { COMPANY });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get INCIDENTY
        public List<IncidentModel> getListIncident(string EMPLOYEE_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<IncidentModel>("WP02003/WP02003_getListIncident", new { EMPLOYEE_ID });

            db.Close();
            return d.ToList();
        }
        #endregion


        #region
        public void GetShift(string Id) {
            try
            {
                IDBContext db = DatabaseManager.Instance.GetContext();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get Project Detail
        public ProjectDetail getProjectDetail(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<ProjectDetail>("WP02003/WP02003_getProjectDetail", new
            {
                ID = ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Get WP Daily Work Equipment
        public List<DATADAILYWORKEQUIPMENT> getWpDailyWorkEqu(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DATADAILYWORKEQUIPMENT>("WP02003/WP02003_getWpDailyWorkEqu", new
            {
                WP_DAILY_ID = ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get WP Daily Util Request
        public List<DATADAILYUTILREQUEST> getWpDailyUtilReq(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DATADAILYUTILREQUEST>("WP02003/WP02003_getWpDailyUtilReq", new
            {
                WP_DAILY_ID = ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get WP Daily APD
        public List<DATADAILYAPD> getWpDailyAPD(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DATADAILYAPD>("WP02003/WP02003_getWpDailyAPD", new
            {
                WP_DAILY_ID = ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get WP Daily Worker List
        public List<DATADAILYWORKERLIST> getWpDailyWorkList(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DATADAILYWORKERLIST>("WP02003/WP02003_getWpDailyWorkList", new
            {
                WP_DAILY_ID = ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get WP Daily WIDEN
        public List<DATADAILYWIDEN> getWpDailyWiDe(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DATADAILYWIDEN>("WP02003/WP02003_getWpDailyWiDen", new
            {
                WP_DAILY_ID = ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Code
        public string GetProjectCode(Sequence_model items, string username, string AreaCode)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<Sequence_model>("WP02001/WP02001_getSeqNumber", new
            {
                items.TYPE_TRX,
                items.YEAR_TRX,
                items.MONTH_TRX,
                username
            });

            var SEQ = hdr.ToList()[0].SEQ_NUMBER;
            var ProjectCode = AreaCode.PadLeft(2, '0') + items.YEAR_TRX.Substring(2, 2)
                            + items.MONTH_TRX.PadLeft(2, '0') + SEQ.PadLeft(3, '0');

            db.Close();
            return ProjectCode;
        }
        #endregion

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("WP02001/WP02001_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Area
        public List<AreaModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AreaModel>("WP02001/WP02001_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Company
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("WP02003/WP02003_getCompany");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP02001/WP02001_getLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Status
        public List<StatusModel> getStatus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<StatusModel>("WP02001/WP02001_getStatus");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Shift

        public List<ShiftModel> getShift(string Id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var data = db.SingleOrDefault<string>("WP02003/WP02003_getShift", new
            {
                ProyekId = Id
            });
            db.Close();
            var shifts = new List<ShiftModel>();
            var strShift = data.Split('-');
            shifts.Add(new ShiftModel { Start = strShift[0], End = strShift[1] });
            return shifts;
        }
        #endregion 

    }

    public class ProjectName
    {
        public string PROJECT_NAME { get; set; }
    }

    public class ProjectModel
    {
        public string ID { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }

    }

    public class ProjectJobModel
    {
        public string ID { get; set; }
        public string JOB_NAME { get; set; }
        public string WP_IMPB_NO { get; set; }


    }

    public class IncidentModel
    {
        public string PROJECT_NAME { get; set; }
        public string IMPB { get; set; }
        public string INCIDENT_TITLE { get; set; }
        public string INCIDENT_LEVEL { get; set; }
        public string INCIDENT_DATE { get; set; }
    }

    public class WorkItemModel
    {
        public string ID_TB_M_ITEM { get; set; }
        public string ITEM_NAME { get; set; }
    }

    public class PekerjaModel
    {
        public string ID_TB_M_EMPLOYEE { get; set; }
        public string USERNAME { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string IDENTITY_NO { get; set; }
        public string TOTAL_INCIDENT { get; set; }
    }

    public class ProjectDetail
    {
        public string ID { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
        public string AREA_NAME { get; set; }
        public string AREA_PATH { get; set; }
        public string LOCATION_NAME { get; set; }
        public string IMPLEMENT_DATE_FROM { get; set; }
        public string IMPLEMENT_DATE_TO { get; set; }
        public string COMPANY_NAME { get; set; }
    }


    public class StatusModel
    {
        public string ID { get; set; }
        public string Status { get; set; }
    }

    public class ShiftModel
    {
        public string Start { get; set; }
        public string End { get; set; }
    }


    public class DivisionModel
    {
        public string Division { get; set; }
    }

    public class LocationModel
    {
        public int ID_TB_M_LOCATION { get; set; }
        public int ID_TB_M_AREA { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class AreaModel
    {
        public int ID_TB_M_AREA { get; set; }
        public string AREA_NAME { get; set; }
    }

    public class PicModel
    {
        public int ID_TB_M_EMPLOYEE { get; set; }
        public int ID_TB_M_COMPANY { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string PIC_STATUS { get; set; }
        public string ANZEN_SERTIFICATE_NO { get; set; }
        public string REG_NO { get; set; }
        public string SECTION { get; set; }
    }

    public class CompanyModel
    {
        public int ID_TB_M_COMPANY { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
    }

    public class EmployeeModel
    {
        public int ID_TB_M_EMPLOYEE { get; set; }
        public int ID_TB_M_COMPANY { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string PIC_STATUS { get; set; }
        public string ANZEN_SERTIFICATE_NO { get; set; }


    }

    public class PengawasModel
    {
        public int ID_TB_M_EMPLOYEE { get; set; }
        public int ID_TB_M_COMPANY { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string PIC_STATUS { get; set; }
        public string ANZEN_SERTIFICATE_NO { get; set; }
        public string REG_NO { get; set; }
        public string SECTION { get; set; }


    }

    public class PagingModel_WP02003
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP02003(int countdata, int positionpage, int dataperpage)
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