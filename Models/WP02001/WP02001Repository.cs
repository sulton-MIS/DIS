using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using AI070.Models.WP02001;
using System.Runtime.CompilerServices;

namespace AI070.Models.WP02001Master
{
    public class WP02001Repository
    {
        #region Get_Data_Grid_WP02001
        public List<WP02001Master> getDataWP02001(int Start, int Display, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_TIME, string PROJECT_TIMETO, string STATUS)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02001Master>("WP02001/WP02001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                PROJECT_NAME,
                PROJECT_LOCATION,
                PROJECT_DATE,
                PROJECT_DATETO,
                DIVISION,
                PROJECT_TIME,
                PROJECT_TIMETO,
                STATUS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP02001
        public int getCountWP02001(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string PROJECT_NAME, string PROJECT_LOCATION, string PROJECT_DATE, string PROJECT_DATETO, string DIVISION, string PROJECT_TIME, string PROJECT_TIMETO, string STATUS)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP02001/WP02001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                PROJECT_NAME,
                PROJECT_LOCATION,
                PROJECT_DATE,
                PROJECT_DATETO,
                DIVISION,
                PROJECT_TIME,
                PROJECT_TIMETO,
                STATUS
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP02001/WP02001_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public static List<WP02001InputForm> Update(WP02001InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02001InputForm>("WP02001/WP02001_UpdateProject", new
            {
                items.WP_PROJECT_ID,
                items.ID_TB_M_AREA,
                items.WP_PROJECT_CODE,
                items.WP_PROJECT_NAME,
                items.ID_TB_M_LOCATION,
                items.DEP_OR_DIV_CODE,
                items.IMPLEMENT_DATE_FROM,
                items.IMPLEMENT_DATE_TO,
                items.IMPLEMENT_TIME_FROM,
                items.WORKING_STATUS,
                items.WORKING_NOTES,
                items.PROJECT_STATUS,
                username
            });

            if (items.project_job.Count > 0)
            {
                foreach (var _modeljob in items.project_job)
                {
                    var jobdata = db.Fetch<WP02001InputForm>("WP02001/WP02001_UpdateProjectJob", new
                    {
                        _modeljob.ID,
                        items.WP_PROJECT_ID,
                        _modeljob.JOB_NAME,
                        _modeljob.WP_IMPB_NO,
                        _modeljob.START_DATE,
                        _modeljob.END_DATE,
                        username
                    });
                }
            }

            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP02001InputForm> Create(WP02001InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateProject", new
            {
                items.WP_PROJECT_ID,
                items.ID_TB_M_AREA,
                items.WP_PROJECT_CODE,
                items.WP_PROJECT_NAME,
                items.ID_TB_M_LOCATION,
                items.DEP_OR_DIV_CODE,
                items.IMPLEMENT_DATE_FROM,
                items.IMPLEMENT_DATE_TO,
                items.IMPLEMENT_TIME_FROM,
                items.WORKING_STATUS,
                items.WORKING_NOTES,
                items.PROJECT_STATUS,
                username
            });

            var ProjectID = hdr.ToList()[0].WP_PROJECT_ID;
            items.WP_PROJECT_ID = ProjectID;
            int ctrprj = Int32.Parse(ProjectID);

            if (items.project_job.Count > 0)
            {
                foreach (var _modeljob in items.project_job)
                {
                    ctrprj += 1;
                    items.WP_IMPB_NO = "";
                        //_modeljob.WP_IMPB_NO.Contains("TEMP") 
                        //? "IMPB-SHE-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadRight(2) + ctrprj.ToString().PadLeft(4, '0')
                        //: _modeljob.WP_IMPB_NO;

                    var jobdata = db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateProjectJob", new
                    {
                        items.WP_PROJECT_JOB_ID,
                        items.WP_PROJECT_ID,
                        _modeljob.JOB_NAME,
                        items.WP_IMPB_NO,
                        _modeljob.START_DATE,
                        _modeljob.END_DATE,
                        username
                    });

                    //items.WP_PROJECT_JOB_ID = jobdata.ToList()[0].WP_PROJECT_JOB_ID;

                    //if (_modeljob.WP_IMPB_NO.Length > 1)
                    //{
                    //    if (items.project_list_implementor.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList().Count > 0)
                    //    {
                    //        foreach (var _model in items.project_list_implementor.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList())
                    //        {
                    //            db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateWorking", new
                    //            {
                    //                items.WP_PROJECT_JOB_ID,
                    //                _modeljob.WP_IMPB_NO,
                    //                _model.EXECUTOR,
                    //                _model.ID_TB_M_COMPANY,
                    //                _model.EMPLOYEE_LEAD_PROJECT,
                    //                _model.EMPLOYEE_SUPERVISOR_PROJECT,
                    //                username
                    //            });
                    //        }
                    //    }

                    //    if (items.project_list_working.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList().Count > 0)
                    //    {
                    //        foreach (var _model in items.project_list_working.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList())
                    //        {
                    //            db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateWorking", new
                    //            {
                    //                items.WP_PROJECT_JOB_ID,
                    //                _modeljob.WP_IMPB_NO,
                    //                _model.ID_TB_M_WORKING_TYPE,
                    //                _model.DANGER_TYPE,
                    //                _model.DAY_1,
                    //                _model.DAY_2,
                    //                _model.DAY_3,
                    //                _model.DAY_4,
                    //                _model.DAY_5,
                    //                _model.DAY_6,
                    //                _model.DAY_7,
                    //                _model.SIX_A,
                    //                _model.SIX_B,
                    //                _model.SIX_C,
                    //                _model.SIX_D,
                    //                _model.SIX_E,
                    //                _model.SIX_F,
                    //                _model.SIX_ALPHA,
                    //                username
                    //            });
                    //        }
                    //    }

                    //    if (items.project_list_identification.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList().Count > 0)
                    //    {
                    //        foreach (var _model in items.project_list_identification.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList())
                    //        {
                    //            db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateIdentification", new
                    //            {
                    //                items.WP_PROJECT_JOB_ID,
                    //                _model.ID_TB_M_WORKING_TYPE,
                    //                _modeljob.WP_IMPB_NO,
                    //                _model.IDENTITY_DANGER_POTENTIAL,
                    //                _model.IDENTITY_DANGER_PREVENTION,
                    //                _model.ID_TB_M_EMPLOYEE,
                    //                _model.HENKANTEN_SAFETY,
                    //                username
                    //            });
                    //        }
                    //    }

                    //    if (items.project_list_impact.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList().Count > 0)
                    //    {
                    //        foreach (var _model in items.project_list_impact.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList())
                    //        {
                    //            db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateImpact", new
                    //            {
                    //                items.WP_PROJECT_JOB_ID,
                    //                _model.ID_TB_M_WORKING_TYPE,
                    //                _modeljob.WP_IMPB_NO,
                    //                _model.IDENTITY_IMPACT_POTENTIAL,
                    //                _model.IDENTITY_IMPACT_PREVENTION,
                    //                _model.ID_TB_M_EMPLOYEE,
                    //                _model.HENKANTEN_ENV,
                    //                username
                    //            });
                    //        }
                    //    }

                    //    if (items.project_list_supervision.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList().Count > 0)
                    //    {
                    //        foreach (var _model in items.project_list_supervision.Where(w => w.WP_IMPB_NO == _modeljob.WP_IMPB_NO).ToList())
                    //        {
                    //            db.Fetch<WP02001InputForm>("WP02001/WP02001_CreateSupervision", new
                    //            {
                    //                items.WP_PROJECT_JOB_ID,
                    //                _modeljob.WP_IMPB_NO,
                    //                _model.ID_TB_M_EMPLOYEE,
                    //                username
                    //            });
                    //        }
                    //    }
                    //}

                    
                }
            }

            
            db.Close();
            return hdr.ToList();
        }

        public static List<WP02001InputForm> Delete(WP02001InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<WP02001InputForm>("WP02001/WP02001_DeleteProject", new
            {
                items.WP_PROJECT_ID,
                username
            });

            db.Close();
            return hdr.ToList();
        }

        #region Get Project Code
        public string GetProjectCode(Sequence_model items, string username,string AreaCode)
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
            var ProjectCode = AreaCode.PadLeft(2,'0') + items.YEAR_TRX.Substring(2,2) 
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
            var d = db.Fetch<CompanyModel>("WP02001/WP02001_getCompany");

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


        #region Get project job
        public List<project_job_model> getProjectJob(string WP_PROJECT_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<project_job_model>("WP02001/WP02001_getProjectJob", new { 
                WP_PROJECT_ID = WP_PROJECT_ID
            });

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

    public class WorkingTypeModel
    {
        public int ID_TB_M_WORKING_TYPE { get; set; }
        public string WORKING_NAME { get; set; }
    }

    public class DivisionModel
    {
        public string DIV { get; set; }
        public string DIV_ID { get; set; }
    }

    public class WorkingHoursModel
    {
        public string WorkingHours { get; set; }
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

    public class PagingModel_WP02001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP02001(int countdata, int positionpage, int dataperpage)
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