using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using AI070.Models.WP02002;

namespace AI070.Models.WP02002Master
{
    public class WP02002Repository
    {
        #region Get_Data_Grid_WP02002
        public List<WP02002Master> getDataWP02002(int Start, int Display, string PROJECT_CODE, string PROJECT_NAME, string DATE_FROM
            , string DATE_TO, string COMPANY, string LOCATION, string DIVISION, string WP_IMPB_NO)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02002Master>("WP02002/WP02002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                PROJECT_CODE,
                PROJECT_NAME,
                DATE_FROM,
                DATE_TO,
                COMPANY,
                LOCATION,
                DIVISION,
                WP_IMPB_NO
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP02002
        public int getCountWP02002(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE
            , string PROJECT_CODE, string PROJECT_NAME, string DATE_FROM, string DATE_TO, 
            string COMPANY, string LOCATION, string DIVISION, string WP_IMPB_NO)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP02002/WP02002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                PROJECT_CODE,
                PROJECT_NAME,
                DATE_FROM,
                DATE_TO,
                COMPANY,
                LOCATION,
                DIVISION,
                WP_IMPB_NO
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP02002/WP02002_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP02002> Update_Data(string ID, string PROJECT_CODE, string JOBS, string LOWLEVEL, string MEDIUMLEVEL, string HIGHLEVEL, string DATE, string CAT_A, string CAT_B, string CAT_C, string CAT_D, string CAT_E, string CAT_F, string REMARKS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02002>("WP02002/WP02002_Update", new
            {
                ID,
                PROJECT_CODE,
                JOBS,
                LOWLEVEL,
                MEDIUMLEVEL,
                HIGHLEVEL,
                DATE,
                CAT_A,
                CAT_B,
                CAT_C,
                CAT_D,
                CAT_E,
                CAT_F,
                REMARKS,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public int updateIMPBLocation(string top, string left, string width, string height, string windowHeight, string windowWidth)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<int>("WP02002/WP02002_UpdateIMPBLocation", new
            {
                top,
                left,
                width,
                height,
                windowHeight,
                windowWidth
            });
            db.Close();
            return d;
        }

        public static List<WP02002> Create(string PROJECT_CODE, string LOCATION, string JOBS, string DANGERLEVEL, string DATE, string CATA, string CATB, string CATC, string CATD, string CATE, string CATF, string REMARKS, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02002>("WP02002/WP02002_Create", new
            {
               PROJECT_CODE,
               LOCATION,
               JOBS,
               DANGERLEVEL,
               DATE,
               CATA,
               CATB,
               CATC,
               CATD,
               CATE,
               CATF,
               REMARKS,
               USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Dropdown

        #region Get Area
        public List<AreaModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AreaModel>("WP02002/WP02002_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Company
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("WP02002/WP02002_getCompany");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ExecutorModel>("WP02002/WP02002_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("WP02002/WP02002_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public static List<LocationModel> getLocation(string PROJECT_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP02002/WP02002_getLocation", new
            {
                PROJECT_CODE
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Code
        public List<ProjectCodeModel> getProjectCode()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ProjectCodeModel>("WP02002/WP02002_getProjectCode");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Jobs
        public List<JobsModel> getJobs()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<JobsModel>("WP02002/WP02002_getJobs");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Location
        public List<LocationModel> getDataLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP02002/WP02002_getDataLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Category
        public List<CategoryModel> getCategory()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CategoryModel>("WP02002/WP02002_getCategory");

            db.Close();
            return d.ToList();
        }
        #endregion


        #region Get Status
        public List<StatusModel> getStatus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<StatusModel>("WP02002/WP02002_getStatus");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP02002/WP02002_getLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Employee
        public List<EmployeeModel> getEmployee()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<EmployeeModel>("WP02002/WP02002_getEmployee");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Pengawas
        public List<PengawasModel> getPengawas()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<PengawasModel>("WP02002/WP02002_getPengawas");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Pic
        public List<PicModel> getPic()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<PicModel>("WP02002/WP02002_getPic");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get WorkingType
        public List<WorkingTypeModel> getWorkingType()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WorkingTypeModel>("WP02002/WP02002_getWorkingType");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get WorkingHours
        public List<WorkingHoursModel> getWorkingHours()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WorkingHoursModel>("WP02002/WP02002_getWorkingHours");

            db.Close();
            return d.ToList();
        }
        #endregion

        #endregion

        #region Process Data

        public static List<WP02002InputForm> IMPBProcess(WP02002InputForm items, string username)
        {
            List<WP02002InputForm> result = new List<WP02002InputForm>();
            IDBContext db = DatabaseManager.Instance.GetContext();

            try
            {
                var jobdata = db.Fetch<WP02002InputForm>("WP02002/WP02002_UpdateProjectJob", new
                {
                    items.ID,
                    items.WP_PROJECT_JOB_ID,
                    items.WP_PROJECT_ID,
                    items.JOB_NAME,
                    items.JOB_STATUS,
                    items.WP_IMPB_NO,
                    items.RISK_LEVEL,
                    username
                });


                db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessImplementor", new
                {
                    ID = items.IMPLEMENTOR_ID,
                    items.WP_PROJECT_JOB_ID,
                    items.WP_IMPB_NO,
                    items.EXECUTOR,
                    items.ID_TB_M_COMPANY,
                    items.EMPLOYEE_LEAD_PROJECT,
                    items.EMPLOYEE_SUPERVISOR_PROJECT,
                    username
                });

                UpdateEmployeeJob(items.WP_PROJECT_JOB_ID, items.EMPLOYEE_LEAD_PROJECT, username);
                UpdateEmployeeJob(items.WP_PROJECT_JOB_ID, items.EMPLOYEE_SUPERVISOR_PROJECT, username);

                foreach (var _model in items.project_list_working)
                {
                    db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessWorking", new
                    {
                        _model.ID,
                        items.WP_PROJECT_JOB_ID,
                        _model.ID_TB_M_WORKING_TYPE,
                        _model.DANGER_TYPE,
                        _model.DAY_1,
                        _model.DAY_2,
                        _model.DAY_3,
                        _model.DAY_4,
                        _model.DAY_5,
                        _model.DAY_6,
                        _model.DAY_7,
                        _model.SIX_A,
                        _model.SIX_B,
                        _model.SIX_C,
                        _model.SIX_D,
                        _model.SIX_E,
                        _model.SIX_F,
                        _model.SIX_ALPHA,
                        username
                    });
                }

                foreach (var _model in items.project_list_identification)
                {
                    db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessIdentification", new
                    {
                        _model.ID,
                        items.WP_PROJECT_JOB_ID,
                        _model.ID_TB_M_WORKING_TYPE,
                        items.WP_IMPB_NO,
                        _model.IDENTITY_DANGER_POTENTIAL,
                        _model.IDENTITY_DANGER_PREVENTION,
                        _model.ID_TB_M_EMPLOYEE,
                        _model.HENKANTEN_SAFETY,
                        username
                    });

                    UpdateEmployeeJob(items.WP_PROJECT_JOB_ID, _model.ID_TB_M_EMPLOYEE, username);
                }

                foreach (var _model in items.project_list_impact)
                {
                    db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessImpact", new
                    {
                        _model.ID,
                        items.WP_PROJECT_JOB_ID,
                        _model.ID_TB_M_WORKING_TYPE,
                        items.WP_IMPB_NO,
                        _model.IDENTITY_IMPACT_POTENTIAL,
                        _model.IDENTITY_IMPACT_PREVENTION,
                        _model.ID_TB_M_EMPLOYEE,
                        _model.HENKANTEN_ENV,
                        username
                    });

                    UpdateEmployeeJob(items.WP_PROJECT_JOB_ID, _model.ID_TB_M_EMPLOYEE, username);
                }

                foreach (var _model in items.project_list_supervision)
                {
                    db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessSupervision", new
                    {
                        _model.ID,
                        items.WP_PROJECT_JOB_ID,
                        items.WP_IMPB_NO,
                        _model.ID_TB_M_EMPLOYEE,
                        username
                    });

                    UpdateEmployeeJob(items.WP_PROJECT_JOB_ID, _model.ID_TB_M_EMPLOYEE, username);
                }

                foreach (var _model in items.project_list_shift)
                {
                    db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessShift", new
                    {
                        _model.ID,
                        items.WP_PROJECT_JOB_ID,
                        items.WP_IMPB_NO,
                        _model.SHIFT_ID,
                        username
                    });

                }

                db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessHenkatenSafety", new
                {
                    ID = items.project_henkaten_safety.ID,
                    items.WP_PROJECT_JOB_ID,
                    items.project_henkaten_safety.HK_SAFETY_MACHINE,
                    items.project_henkaten_safety.HK_SAFETY_MODIFICATION,
                    items.project_henkaten_safety.HK_SAFETY_PROCESS,
                    items.project_henkaten_safety.IS_HENKATEN_SAFETY,
                    username
                });

                db.Fetch<WP02002InputForm>("WP02002/WP02002_ProcessHenkatenEnv", new
                {
                    ID = items.project_henkaten_env.ID,
                    items.WP_PROJECT_JOB_ID,
                    items.project_henkaten_env.HK_ENV_BUILDING,
                    items.project_henkaten_env.HK_ENV_MACHINE,
                    items.project_henkaten_env.HK_ENV_MATERIAL,
                    items.project_henkaten_env.HK_ENV_PROCESS,
                    items.project_henkaten_env.IS_HENKATEN_ENV,
                    username
                });

                db.Execute("WP02002/WP02002_UpdateIMPBLocation", new {
                    items.WP_PROJECT_JOB_ID,
                    items.TOP_POS,
                    items.LEFT_POS,
                    items.WIDTH_SQUARE,
                    items.HEIGHT_SQUARE,
                    items.WINDOW_HEIGHT,
                    items.WINDOW_WIDTH,
                    items.BORDER_COLOR,
                    items.ROTATE
                });

                db.Close();
                return jobdata.ToList();
            }
            catch (Exception ex )
            {
                db.Close();
                result.Add(new WP02002InputForm
                {
                    STACK = "FALSE",
                    LINE_STS = ex.Message
                });

                return result;
            }
        }

        public static List<WP02002InputForm> SubmitTrans(WP02002InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            List<WP02002InputForm> result = new List<WP02002InputForm>();

            try
            {
                var jobdata = db.Fetch<WP02002InputForm>("WP02002/WP02002_UpdateProjectJob", new
                {
                    items.ID,
                    items.WP_PROJECT_JOB_ID,
                    items.WP_PROJECT_ID,
                    items.JOB_NAME,
                    items.JOB_STATUS,
                    items.WP_IMPB_NO,
                    items.RISK_LEVEL,
                    username
                });
                db.Close();
                return jobdata.ToList();
            }
            catch (Exception ex)
            {
                db.Close();
                result.Add(new WP02002InputForm
                {
                    STACK = "FALSE",
                    LINE_STS = ex.Message
                });

                return result;
            }
        }

        public static void UpdateEmployeeJob(string WP_PROJECT_JOB_ID, string ID_TB_M_EMPLOYEE,string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<WP02002InputForm>("WP02002/WP02002_UpdateEmployee", new
            {
                WP_PROJECT_JOB_ID,
                ID_TB_M_EMPLOYEE,
                username
            });

            db.Close();
        }

        public static void DeleteWorkingList(string ID,string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<working_model>("WP02002/WP02002_DeleteWorking", new
            {
                ID = ID,
                USERNAME = username
            });

            db.Close();
        }

        public static void DeleteShiftList(string ID, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<WorkingHoursModel>("WP02002/WP02002_DeleteShift", new
            {
                ID = ID,
                USERNAME = username
            });

            db.Close();
        }

        public static void DeleteIdentificationList(string ID, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<identification_model>("WP02002/WP02002_DeleteIdentification", new
            {
                ID = ID,
                USERNAME = username
            });

            db.Close();
        }

        public static void DeleteImpactList(string ID, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<impact_model>("WP02002/WP02002_DeleteImpact", new
            {
                ID = ID,
                USERNAME = username
            });

            db.Close();
        }

        public static void DeleteSupervisionList(string ID, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            db.Fetch<impact_model>("WP02002/WP02002_DeleteSupervision", new
            {
                ID = ID,
                USERNAME = username
            });

            db.Close();
        }

        public string GetEmployeeJob(string ID_TB_M_EMPLOYEE,string WP_PROJECT_JOB_ID="")
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var rst = db.Fetch<WP02002InputForm>("WP02002/WP02002_UpdateEmployee", new
            {
                ID_TB_M_EMPLOYEE
            });

            db.Close();

            if (rst[0].JOB_STATUS != "FINISH" && rst[0].WP_PROJECT_JOB_ID != WP_PROJECT_JOB_ID)
            {
                return "FALSE";
            }
            else
                return "TRUE";
        }
        #endregion

        public List<IMPBLocationModel> getIMPBLocation(string ID, string status)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var rst = db.Fetch<IMPBLocationModel>("WP02002/WP02002_getIMPBLocation", new
            {
                ID,
                status
            });

            db.Close();
            return rst.ToList();
        }

        #region Get IMPB Code
        public string GetIMPBCode(Sequence_model items, string username, string AreaCode)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            var hdr = db.Fetch<Sequence_model>("WP02002/WP02002_getSeqNumber", new
            {
                items.TYPE_TRX,
                items.YEAR_TRX,
                items.MONTH_TRX,
                username
            });

            var SEQ = hdr.ToList()[0].SEQ_NUMBER;
            var IMPBCode = "IMPB-SHE" + AreaCode.PadLeft(2, '0') + "-" + items.YEAR_TRX.Substring(2, 2)
                            + items.MONTH_TRX.PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') 
                            + SEQ.PadLeft(3, '0');

            db.Close();
            return IMPBCode;
        }
        #endregion

        #region Get Detail
        public WP02002InputForm getDetail(string WP_PROJECT_JOB_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            WP02002InputForm form = new WP02002InputForm();

            form.project_list_working = db.Fetch<working_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "WORKING" }).ToList();
            form.project_list_shift = db.Fetch<shift_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "SHIFT" }).ToList();
            form.project_list_identification = db.Fetch<identification_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "IDENTIFICATION" }).ToList();
            form.project_list_impact = db.Fetch<impact_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "IMPACT" }).ToList();
            form.project_list_supervision = db.Fetch<pengawasan_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "SUPERVISION" }).ToList();
            form.project_henkaten_env = db.Fetch<henkaten_env_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "HENKATEN_ENV" }).ToList().FirstOrDefault();
            form.project_henkaten_safety = db.Fetch<henkaten_safety_model>("WP02002/WP02002_getDetail", new { WP_PROJECT_JOB_ID, TYPE = "HENKATEN_SAFETY" }).ToList().FirstOrDefault();

            db.Close();
            return form;
        }
        #endregion
    }

    public class StatusModel
    {
        public string ID { get; set; }
        public string STATUS { get; set; }
    }

    public class IMPBLocationModel
    {
        public int ID { get; set; }
        public string TOP_POSITION { get; set; }
        public string LEFT_POSITION { get; set; }
        public string HEIGHT { get; set; }
        public string WIDTH { get; set; }
        public string PING { get; set; }
        public string WINDOW_HEIGHT { get; set; }
        public string WINDOW_WIDTH { get; set; }
        public string BORDER_COLOR { get; set; }
        public string ROTATION { get; set; }
    }

    public class ProjectCodeModel
    {
        public string PROJECT_CODE { get; set; }
    }

    public class JobsModel
    {
        public string ID_TB_M_WORKING_TYPE { get; set; }
        public string WORKING_NAME { get; set; }

    }

    public class CategoryModel
    {
        public string CATEGORY { get; set; }
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
        public string WorkingHoursText { get; set; }
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
        public string COMPANY_CODE { get; set; }

        public string REG_NO { get; set; }
        public string SECTION { get; set; }
        public DateTime ANZEN_DT_FROM { get; set; }
        public DateTime ANZEN_DT_TO { get; set; }
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

    public class PagingModel_WP02002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP02002(int countdata, int positionpage, int dataperpage)
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