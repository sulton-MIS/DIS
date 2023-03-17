using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using AI070.Models.DISR140001;
using System.Runtime.CompilerServices;

namespace AI070.Models.DISR140001Master
{
    public class DISR140001Repository
    {
        #region Get Pilih Dmc Type From Item Master
        public List<ItemMaster> getDmcTypeItemMaster()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<ItemMaster>("DISR140001/DISR140001_GetListDmcType");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISR140001
        public List<DISR140001Master> getDataDISR140001(int Start, int Display, string ID_BUNDLE, string DMC_CODE, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR140001Master>("DISR140001/DISR140001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ID_BUNDLE,
                DMC_CODE,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISR140001
        public int getCountDISR140001(string DATA_ID, string ID_BUNDLE, string DMC_CODE, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR140001/DISR140001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ID_BUNDLE,
                DMC_CODE,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get Nama Operator
        public List<ListNik> get_Data_Operator(string id_sagyosha)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListNik>("DISR140001/DISR140001_getDataOperator", new
            {
                id_sagyosha
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Seihin
        public List<ListSeihin> get_Data_Seihin(string id_seisan)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListSeihin>("DISR140001/DISR140001_getDataIDSeihin", new
            {
                id_seisan
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Proses
        public List<ListProses> get_Data_Proses(string id_kotei)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListProses>("DISR140001/DISR140001_getDataProses", new
            {
                id_kotei
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Convertion Table
        public List<ListConvertionTable> get_Data_ConvertionTable(string id_seihin)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<ListConvertionTable>("DISR140001/DISR140001_getDataConvertionTable", new
            {
                id_seihin
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Create Data
        public static List<DISR140001InputForm> Create(DISR140001InputForm items, string BUNDLE_CODE, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            if (items.data_detail.Count > 0)
            {
                foreach (var _detailItem in items.data_detail)
                {
                    var jobdata = db.Fetch<DISR140001InputForm>("DISR140001/DISR140001_CreateFGdetail", new
                    {
                        BUNDLE_CODE,
                        _detailItem.ID_PRODUKSI,
                        _detailItem.DMC_CODE,
                        _detailItem.ID_PROSES,
                        _detailItem.NAMA_PROSES,
                        _detailItem.SERIAL,
                        _detailItem.LOTNO,
                        _detailItem.BERAT_PCS_ACT,
                        _detailItem.NAMA,
                        username
                    });
                }
            }

            var hdr = db.Fetch<DISR140001InputForm>("DISR140001/DISR140001_CreateFGnew", new
            {
                BUNDLE_CODE,
                items.DMC_CODE,
                items.JUMLAH_BDL_STD,
                items.JUMLAH_BDL_ACT,
                items.BERAT_BDL_STD,
                items.BERAT_BDL_ACT,
                items.NIK,
                items.NAMA,
                username
            });
            db.Close();
            return hdr.ToList();
        }
        #endregion

        #region Delete Data
       
        public static List<DISR140001InputForm> Delete(DISR140001InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            string BUNDLE_CODE = items.BUNDLE_ID;
            var hdr = db.Fetch<DISR140001InputForm>("DISR140001/DISR140001_Delete", new
            {
                BUNDLE_CODE,
                username
            });

            db.Close();
            return hdr.ToList();
        }

        #endregion

        #region Update Data
        public static List<DISR140001InputForm> Update(DISR140001InputForm items, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DISR140001InputForm>("DISR140001/DISR140001_UpdateProject", new
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
                    var jobdata = db.Fetch<DISR140001InputForm>("DISR140001/DISR140001_UpdateProjectJob", new
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

        #region Get Project Code
        public string GetBundleCode(Sequence_model items, string username)
        {
            int SORT_NO = 1;

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            var hdr = db.Fetch<Sequence_model>("DISR140001/DISR140001_getSeqNumber", new
            {
                items.TYPE_TRX,
                items.YEAR_TRX,
                items.MONTH_TRX,
                items.DAY_TRX,
                username
            });

            if (hdr.Count > 0)
            {
                int SEQ = hdr.ToList()[0].SEQ_NUMBER;
                SORT_NO = SEQ + 1;
            }

            string ZERO = "";
            int NUM = SORT_NO.ToString().Length;
            if (NUM == 1)
            {
                ZERO = "0000";
            }
            else if (NUM == 2)
            {
                ZERO = "000";
            }
            else if (NUM == 3)
            {
                ZERO = "00";
            }
            else if (NUM == 4)
            {
                ZERO = "0";
            }

            var BundleCode = "B" + items.YEAR_TRX.Substring(2,2) + items.MONTH_TRX.PadLeft(2, '0') + items.DAY_TRX.PadLeft(2, '0') + ZERO + SORT_NO;

            db.Close();
            return BundleCode;
        }
        #endregion

        #region Get Division
        public List<DivisionModel> getDivision()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DivisionModel>("DISR140001/DISR140001_getDivision");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Area
        public List<AreaModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<AreaModel>("DISR140001/DISR140001_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Company
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("DISR140001/DISR140001_getCompany");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project Location
        public List<LocationModel> getLocation()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("DISR140001/DISR140001_getLocation");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Status
        public List<StatusModel> getStatus()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<StatusModel>("DISR140001/DISR140001_getStatus");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get project job
        public List<project_job_model> getProjectJob(string WP_PROJECT_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<project_job_model>("DISR140001/DISR140001_getProjectJob", new { 
                WP_PROJECT_ID = WP_PROJECT_ID
            });

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class ItemMaster
    {
        public string DMC_CODE { get; set; }
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

    public class PagingModel_DISR140001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR140001(int countdata, int positionpage, int dataperpage)
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