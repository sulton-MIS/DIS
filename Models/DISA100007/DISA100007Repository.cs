using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA100007Master
{
    public class DISA100007Repository
    {
        #region Identitas User
        public List<IdentitasUser_Model> getUserIdentity(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<IdentitasUser_Model>("DISA100007/DISA100007_UserIdentity", new
            {
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Cek User Akses
        public List<DISA10007_LIST_CHECK_USER> getcheck_User(string USERNAME, string NAMA_FORM)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10007_LIST_CHECK_USER>("DISA100007/DISA100007_CheckUser", new
            {
                USERNAME,
                NAMA_FORM
            });
            db.Close();
            return d.ToList();
        }

        #endregion

        #region Get Department
        public List<DISA100007Master> getListDocument(string NAMA_DEPARTMENT)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007Master>("DISA100007/DISA100007_getListDokumen", new
            {
                NAMA_DEPARTMENT
            });

            db.Close();
            return d.ToList();
        }
        #endregion
        
        #region Get Department
        public List<DepartmentModel> getListDepartment()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DepartmentModel>("DISA100007/DISA100007_getDepartment");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Section
        public List<SectionModel> getListSection()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<SectionModel>("DISA100007/DISA100007_getSection");

            db.Close();
            return d.ToList();
        }
        #endregion


        //------------------------------------------------------------ PAGE MASTER DOCUMENT --------------------------------------------------------
        #region Get_Data_Grid_DISA100007
        public List<DISA100007Master> getDataDISA100007(int Start, int Display,
            string JENIS_TRANSAKSI, string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string STATUS_APPROVE, string STATUS_DISPOSE, string NOMOR_RAK, string LABEL_RAK, string TGL_REGISTER,
            string PAGE_VIEWER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007Master>("DISA100007/DISA100007_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                JENIS_TRANSAKSI,
                NO_DOKUMEN, 
                NAMA_DOKUMEN, 
                DEPARTMENT, 
                STATUS_APPROVE, 
                STATUS_DISPOSE,
                NOMOR_RAK,
                LABEL_RAK,
                TGL_REGISTER,
                PAGE_VIEWER
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA100007
        public int getCountDISA100007(string DATA_ID, string JENIS_TRANSAKSI, string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string STATUS_APPROVE, string STATUS_DISPOSE, string NOMOR_RAK, string LABEL_RAK, string TGL_REGISTER, string PAGE_VIEWER)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100007/DISA100007_SearchCount", new
            {
                DATA_ID = DATA_ID,
                JENIS_TRANSAKSI,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                DEPARTMENT,
                STATUS_APPROVE,
                STATUS_DISPOSE,
                NOMOR_RAK,
                LABEL_RAK,
                TGL_REGISTER,
                PAGE_VIEWER
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get No_Urut_Document
        public string getUrutanDocument()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string get_last_ID = db.SingleOrDefault<string>("DISA100007/Master_Document/DISA100007_getUrutan_Document", new { });

            string result;
            int no_document;
            int last_ID;

            if (get_last_ID == null)
            {
                last_ID = 0;
            }
            else
            {
                last_ID = Int32.Parse(get_last_ID);
            }

            //Set No. Document
            no_document = last_ID + 1;

            result = no_document.ToString();

            db.Close();
            return result;
        }
        #endregion

        //public static DateTime DateSerial(int Year, int Month, int Day);

        #region Get Last Date
        public DateTime get_last_date(DateTime CREATED_DATE, string MASA_SIMPAN)
        {
            DateTime result;
            //Int32 newMasaSimpan = Int32.Parse(MASA_SIMPAN);
            double newMasaSimpan = double.Parse(MASA_SIMPAN);

            DateTime newMonth = DateTime.Parse(CREATED_DATE.ToString("M")).AddMonths(1);
            String getMonth = newMonth.ToString("MM");
            Int32 month_int = Int32.Parse(getMonth);

            DateTime newYear = DateTime.Parse(CREATED_DATE.ToString()).AddYears((int)Math.Round(newMasaSimpan));
            String getYear = newYear.ToString("yyyy");
            Int32 year_int = Int32.Parse(getYear);

            //Digunakan apabila bulan ini adalah bulan 12 (Desember)
            if (month_int == 01)
            {
                year_int = year_int + 1;
            }

            DateTime Date_result = new DateTime(year_int, month_int, 1); //Setting jadi tanggal 1 bulan berikutnya
            DateTime lastDate = DateTime.Parse(Date_result.ToString()).AddDays(-1); //Setting dikurang 1 hari

            result = lastDate;

            return result;
        }
        #endregion

        #region Get Detail Data Dokumen
        public List<DISA100007Master> get_Data_Dokumen(
            string NAMA_DOKUMEN, string LABEL_RAK,
            string NO_RAK, string DEPARTMENT, string BAGIAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007Master>("DISA100007/DISA100007_getDataDokumen", new
            {
                NAMA_DOKUMEN,
                LABEL_RAK,
                NO_RAK,
                DEPARTMENT,
                BAGIAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Add Data
        public static List<DISA100007> Create_Master_Document(
            string JENIS_TRANSAKSI,
            string NO_DOKUMEN,
            string NAMA_DOKUMEN,
            string QTY_BUNDLE,
            string DEPARTMENT,
            string BAGIAN,
            string NO_RAK,
            string RAK,
            string MASA_SIMPAN,
            DateTime ESTIMASI_DISPOSE,
            string KETERANGAN,
            string FLG_APPROVE,
            string USERNAME,
            DateTime CREATED_DATE,
            string NAMA_FITUR,
            string NAMA_MENU,
            string NOTE_LOG
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Master_Document/DISA100007_Create", new
            {
                JENIS_TRANSAKSI,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                QTY_BUNDLE,
                DEPARTMENT,
                BAGIAN,
                NO_RAK,
                RAK,
                MASA_SIMPAN,
                ESTIMASI_DISPOSE,
                KETERANGAN,
                FLG_APPROVE,
                USERNAME,
                CREATED_DATE,
                NAMA_FITUR,
                NAMA_MENU,
                NOTE_LOG
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Add Data Pinjam Document (OLD)
        public static List<DISA100007> Create_Pinjam_Document(
            string JENIS_TRANSAKSI,
            string NAMA_DOKUMEN,
            string QTY_BUNDLE,
            string NAMA_PEMINJAM,
            string DEPARTMENT,
            string BAGIAN,
            string NO_RAK,
            string RAK,
            string MASA_PINJAM,
            string TGL_PINJAM,
            DateTime ESTIMASI_KEMBALI,
            string KETERANGAN,
            string FLG_PINJAM,
            string USERNAME,
            DateTime CREATED_DATE,
            string NAMA_FITUR,
            string NAMA_MENU,
            string NOTE_LOG
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Master_Document/DISA100007_Create_Pinjam_Document", new
            {
                JENIS_TRANSAKSI,
                NAMA_DOKUMEN,
                QTY_BUNDLE,
                NAMA_PEMINJAM,
                DEPARTMENT,
                BAGIAN,
                NO_RAK,
                RAK,
                MASA_PINJAM,
                TGL_PINJAM,
                ESTIMASI_KEMBALI,
                KETERANGAN,
                FLG_PINJAM,
                USERNAME,
                CREATED_DATE,
                NAMA_FITUR,
                NAMA_MENU,
                NOTE_LOG
            });
            db.Close();
            return d.ToList();
        }
        #endregion
        
        #region Add Data Pinjam Document (New)
        public static List<DISA100007> Create_Pinjam_Document_New(
            string JENIS_TRANSAKSI,
            string NO_DOKUMEN,
            string NAMA_DOKUMEN,
            string NAMA_PEMINJAM,
            string DEPARTMENT_PEMINJAM,
            string BAGIAN_PEMINJAM,
            string MASA_PINJAM,
            string TGL_PINJAM,
            DateTime ESTIMASI_KEMBALI,
            string NOTE_PEMINJAM,
            string USERNAME,
            DateTime CREATED_DATE,
            string NAMA_FITUR,
            string NAMA_MENU,
            string NOTE_LOG
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Master_Document/DISA100007_Create_Pinjam_Document", new
            {
                JENIS_TRANSAKSI,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                NAMA_PEMINJAM,
                DEPARTMENT_PEMINJAM,
                BAGIAN_PEMINJAM,
                MASA_PINJAM,
                TGL_PINJAM,
                ESTIMASI_KEMBALI,
                NOTE_PEMINJAM,
                USERNAME,
                CREATED_DATE,
                NAMA_FITUR,
                NAMA_MENU,
                NOTE_LOG
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data
        public List<DISA100007> Update_Data_Master(
            string ID,
            string NO_DOKUMEN,
            string NAMA_DOKUMEN,
            string QTY_BUNDLE,
            string DEPARTMENT, 
            string BAGIAN, 
            string NO_RAK, 
            string LABEL_RAK, 
            string MASA_SIMPAN, 
            string KETERANGAN, 
            DateTime ESTIMASI_DISPOSE, 
            string LOG_HISTORY_KETERANGAN,
            string USERNAME,
            DateTime DATE_UPDATED,
            string NAMA_FITUR,
            string NAMA_MENU,
            string PAGE_VIEWER
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Master_Document/DISA100007_Update", new
            {
                ID,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                QTY_BUNDLE,
                DEPARTMENT,
                BAGIAN,
                NO_RAK,
                LABEL_RAK,
                MASA_SIMPAN,
                KETERANGAN,
                ESTIMASI_DISPOSE,
                LOG_HISTORY_KETERANGAN,
                USERNAME,
                DATE_UPDATED,
                NAMA_FITUR,
                NAMA_MENU,
                PAGE_VIEWER
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_Master_Document(
            string ID, string NAMA_MENU, string NAMA_FITUR, 
            string NOTE_LOG, string USERNAME, DateTime CREATED_DATE, string PAGE_VIEWER
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100007/Master_Document/DISA100007_Delete", new
            {
                ID,
                NAMA_MENU,
                NAMA_FITUR,
                NOTE_LOG,
                USERNAME,
                CREATED_DATE,
                PAGE_VIEWER
            });
            db.Close();
            return d;
        }
        #endregion

        #region DisposeData
        public static List<DISA100007> Dispose_Master_Document(
            string ID,
            string USERNAME,
            DateTime CREATED_DATE,
            string NAMA_FITUR,
            string NAMA_MENU,
            string NOTE_LOG
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Master_Document/DISA100007_Dispose", new
            {
                ID,
                USERNAME,
                CREATED_DATE,
                NAMA_FITUR,
                NAMA_MENU,
                NOTE_LOG
            });
            db.Close();
            return d.ToList();
        }
        #endregion
        
        #region Kembalikan Dokumen
        public static List<DISA100007> Kembalikan_Document(
            string ID,
            string NO_DOKUMEN,
            string NAMA_DOKUMEN,
            string USERNAME,
            DateTime CREATED_DATE,
            string NAMA_FITUR,
            string NAMA_MENU,
            string NOTE_LOG
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Master_Document/DISA100007_Kembalikan_Document", new
            {
                ID,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                USERNAME,
                CREATED_DATE,
                NAMA_FITUR,
                NAMA_MENU,
                NOTE_LOG
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Download Data Excel
        public List<DISA100007_Download_Excel> DownloadExcel_Document(
            int PageNumber, int Display, string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string STATUS_APPROVE, string STATUS_DISPOSE, string PAGE_VIEWER
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007_Download_Excel>("DISA100007/Master_Document/DISA100007_Download_Excel", new
            {
                PageNumber,
                Display,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                DEPARTMENT,
                STATUS_APPROVE,
                STATUS_DISPOSE,
                PAGE_VIEWER
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

        #region History Data
        public List<History_Data> GetDataHistory(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<History_Data>("DISA100007/Master_Document/DISA100007_HistoryData", new
            {
                ID
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        //------------------------------------------------------------ PAGE WAITING APPROVAL ---------------------------------------------------
        #region PAGE WAITING APPROVAL

        #region Approve Data
        public static List<DISA100007> Approved_Data_Document(
            string ID,
            string NO_DOCUMENT,
            string NO_RAK,
            string LABEL_RAK,
            string APPROVED_BY,
            string USERNAME,
            DateTime CREATED_DATE,
            string NAMA_FITUR,
            string NAMA_MENU,
            string NOTE_LOG
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007>("DISA100007/Waiting_Approval/DISA100007_Approve", new
            {
                ID,
                NO_DOCUMENT,
                APPROVED_BY,
                NO_RAK,
                LABEL_RAK,
                USERNAME,
                CREATED_DATE,
                NAMA_FITUR,
                NAMA_MENU,
                NOTE_LOG
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Detail Data Dispose Asset
        public List<DISA100007Master> GetDataDetail(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007Master>("DISA100001/Waiting_Approval/DISA100001_Show_Detail", new
            {
                ID
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #endregion



        //------------------------------------------------------------- PAGE PINJAM DOKUMEN ---------------------------------------------------
        #region Get_Data_Grid_DISA100007
        public List<DISA100007Master> getData_Pinjam_Document(int Start, int Display,
            string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string NOMOR_RAK, string LABEL_RAK, string TGL_PINJAM, string STATUS_PENGEMBALIAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100007Master>("DISA100007/Pinjam_Document/DISA100007_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                DEPARTMENT,
                NOMOR_RAK,
                LABEL_RAK,
                TGL_PINJAM,
                STATUS_PENGEMBALIAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA100007
        public int getCount_Pinjam_Document(string DATA_ID, string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string NOMOR_RAK, string LABEL_RAK, string TGL_PINJAM, string STATUS_PENGEMBALIAN)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100007/Pinjam_Document/DISA100007_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_DOKUMEN,
                NAMA_DOKUMEN,
                DEPARTMENT,
                NOMOR_RAK,
                LABEL_RAK,
                TGL_PINJAM,
                STATUS_PENGEMBALIAN
            });
            db.Close();
            return result;
        }
        #endregion


        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISA100007/DISA100007_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }


    //-------------------------------------------------------------- IDENTITY VAR ---------------------------------------------------------
    public class IdentitasUser_Model
    {
        public string NIK { get; set; }
        public string NAMA_USER { get; set; }
        public string NAMA_USER_ALIAS { get; set; }
        public string KODE_SECTION { get; set; }
        public string NAMA_SECTION { get; set; }
        public string NAMA_SECTION_ALIAS { get; set; }
        public string KODE_DEPT { get; set; }
        public string NAMA_DEPT { get; set; }
        public string NAMA_DEPT_ALIAS { get; set; }

    }

    public class DepartmentModel
    {
        public string kode_dept { get; set; }
        public string nama_dept { get; set; }
        public string nama_dept_alias { get; set; }
    }

    public class SectionModel
    {
        public string kode_dept { get; set; }
        public string kode_section { get; set; }
        public string nama_section { get; set; }
        public string nama_section_alias { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }
    
    public class DistribusiModel
    {
        public string DISTRIBUSI_NAME { get; set; }
        public string DISTRIBUSI_MSG { get; set; }
    }


    public class ExecutorModel
    {
        public DateTime ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISA100007
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA100007(int countdata, int positionpage, int dataperpage)
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