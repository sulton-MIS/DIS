using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.DISA100007Master;
using System.Security.Cryptography;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;

namespace AI070.Controllers
{
    public class DISA100007Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA100007Repository R = new DISA100007Repository();
        User U = new User();
        string username;
        String reg_no;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;
        string message;
        string sts;

        //Identitas User
        string NIK;
        string NAMA_USER;
        string NAMA_USER_ALIAS;
        string KODE_SECTION;
        string NAMA_SECTION;
        string NAMA_SECTION_ALIAS;
        string KODE_DEPT;
        string NAMA_DEPT;
        string NAMA_DEPT_ALIAS;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Document Control";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult GenerateMessage(string MSG_ID, string p_PARAM1, string p_PARAM2, string p_PARAM3, string p_PARAM4)
        {
            try
            {
                M.MSG_ID = MSG_ID;
                M.p_PARAM1 = p_PARAM1;
                M.p_PARAM2 = p_PARAM2;
                M.p_PARAM3 = p_PARAM3;
                M.p_PARAM4 = p_PARAM4;
                var res = M.getMessageTextWithFunctionSQL(M);
                MESSAGE_TXT = res[0].MSG_TEXT;
                MESSAGE_TYPE = res[0].MSG_TYPE;
            }
            catch (Exception M)
            {
                MESSAGE_TXT = M.Message.ToString();
                MESSAGE_TYPE = "Err";
            }
            return Json(new { MESSAGE_TXT, MESSAGE_TYPE }, JsonRequestBehavior.AllowGet);
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                //ViewData["EXECUTOR"] = R.getExecutor();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
                ViewData["User"] = username;

                reg_no = Lookup.Get<Toyota.Common.Credential.User>().RegistrationNumber.ToString();
                ViewData["RegNo"] = reg_no;

                GetIdentitasUser(username);

                //Jika roles user (cek di table TB_M_USER_MAPPING) "Admin Document Control" / "Super Admin", maka department isi kosong (all).
                if (reg_no == "ADC" || reg_no == "SU")
                {
                    NAMA_DEPT_ALIAS = "";
                }

                //Get List Dokumen
                ViewData["nama_dokumen"] = R.getListDocument(NAMA_DEPT_ALIAS);
                
                //Get Data Department
                ViewData["nama_department"] = R.getListDepartment();

                //Get Data Section
                ViewData["nama_section"] = R.getListSection();

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Identitas User
        public void GetIdentitasUser(string username)
        {
            string USERNAME = username;
            try
            {
                //ViewData["NIK"] = R.getUserIdentity(USERNAME);

                List<IdentitasUser_Model> getUserIdentity = R.getUserIdentity(USERNAME);
                if (getUserIdentity.Count > 0)
                {
                    ViewData["NIK"] = getUserIdentity.FirstOrDefault().NIK.ToString();
                    ViewData["NAMA_USER"] = getUserIdentity.FirstOrDefault().NAMA_USER.ToString();
                    ViewData["NAMA_USER_ALIAS"] = getUserIdentity.FirstOrDefault().NAMA_USER_ALIAS.ToString();
                    ViewData["KODE_SECTION"] = getUserIdentity.FirstOrDefault().KODE_SECTION.ToString();
                    ViewData["NAMA_SECTION"] = getUserIdentity.FirstOrDefault().NAMA_SECTION.ToString();
                    ViewData["NAMA_SECTION_ALIAS"] = getUserIdentity.FirstOrDefault().NAMA_SECTION_ALIAS.ToString();
                    ViewData["KODE_DEPT"] = getUserIdentity.FirstOrDefault().KODE_DEPT.ToString();
                    ViewData["NAMA_DEPT"] = getUserIdentity.FirstOrDefault().NAMA_DEPT.ToString();
                    ViewData["NAMA_DEPT_ALIAS"] = getUserIdentity.FirstOrDefault().NAMA_DEPT_ALIAS.ToString();

                    NIK = ViewData["NIK"].ToString();
                    NAMA_USER = ViewData["NAMA_USER"].ToString();
                    NAMA_USER_ALIAS = ViewData["NAMA_USER_ALIAS"].ToString();
                    KODE_SECTION = ViewData["KODE_SECTION"].ToString();
                    NAMA_SECTION = ViewData["NAMA_SECTION"].ToString();
                    NAMA_SECTION_ALIAS = ViewData["NAMA_SECTION_ALIAS"].ToString();
                    KODE_DEPT = ViewData["KODE_DEPT"].ToString();
                    NAMA_DEPT = ViewData["NAMA_DEPT"].ToString();
                    NAMA_DEPT_ALIAS = ViewData["NAMA_DEPT_ALIAS"].ToString();
                }


            }
            catch (Exception M)
            {
                message = "Please completed identity user !";
                M.Message.ToString();
            }
        }
        #endregion

        #region Validasi Open Form
        public ActionResult validasiOpenForm(string formMenu)
        {
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string USERNAME = username;

            string sts = null;
            string message = null;

            try
            {
                //Check User Validasi
                List<DISA10007_LIST_CHECK_USER> getValidasiForm = R.getcheck_User(USERNAME, formMenu);


                if (getValidasiForm.Count > 0)
                {
                    //View Data
                    if (getValidasiForm.FirstOrDefault().view is null || getValidasiForm.FirstOrDefault().view.ToString() == "" ||
                        getValidasiForm.FirstOrDefault().view.ToString() == "False")
                    {
                        sts = "FALSE";
                        message = "Not Success!";
                    }
                    else
                    {
                        sts = "TRUE";
                        message = "Success!";
                    }

                }
                else
                {
                    sts = "FALSE";
                    message = "Not Success!";
                }
            }
            catch (Exception M)
            {
                sts = "FALSE";
                message = M.Message.ToString();
            }

            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Data Validasi User
        public void GetDataValidasiUser(string USERNAME, string NAMA_FORM)
        {
            try
            {
                //Check User Validasi
                List<DISA10007_LIST_CHECK_USER> getValidasiUser = R.getcheck_User(USERNAME, NAMA_FORM);

                if (getValidasiUser.Count > 0)
                {
                    //Save Data
                    if (getValidasiUser.FirstOrDefault().save is null || getValidasiUser.FirstOrDefault().save.ToString() == "")
                    {
                        ViewData["save"] = "Nothing";
                    }
                    else
                    {
                        ViewData["save"] = getValidasiUser.FirstOrDefault().save.ToString();
                    }

                    //Add Data
                    if (getValidasiUser.FirstOrDefault().add is null || getValidasiUser.FirstOrDefault().add.ToString() == "")
                    {
                        ViewData["add"] = "Nothing";
                    }
                    else
                    {
                        ViewData["add"] = getValidasiUser.FirstOrDefault().add.ToString();
                    }

                    //Edit Data
                    if (getValidasiUser.FirstOrDefault().edit is null || getValidasiUser.FirstOrDefault().edit.ToString() == "")
                    {
                        ViewData["edit"] = "Nothing";
                    }
                    else
                    {
                        ViewData["edit"] = getValidasiUser.FirstOrDefault().edit.ToString();
                    }

                    //Edit Keterangan
                    if (getValidasiUser.FirstOrDefault().edit_keterangan is null || getValidasiUser.FirstOrDefault().edit_keterangan.ToString() == "")
                    {
                        ViewData["edit_keterangan"] = "Nothing";
                    }
                    else
                    {
                        ViewData["edit_keterangan"] = getValidasiUser.FirstOrDefault().edit_keterangan.ToString();
                    }

                    //Edit Image
                    if (getValidasiUser.FirstOrDefault().edit_image is null || getValidasiUser.FirstOrDefault().edit_image.ToString() == "")
                    {
                        ViewData["edit_image"] = "Nothing";
                    }
                    else
                    {
                        ViewData["edit_image"] = getValidasiUser.FirstOrDefault().edit_image.ToString();
                    }

                    //Delete Data
                    if (getValidasiUser.FirstOrDefault().delete is null || getValidasiUser.FirstOrDefault().delete.ToString() == "")
                    {
                        ViewData["delete"] = "Nothing";
                    }
                    else
                    {
                        ViewData["delete"] = getValidasiUser.FirstOrDefault().delete.ToString();
                    }
                    
                    //Dispose Data
                    if (getValidasiUser.FirstOrDefault().dispose is null || getValidasiUser.FirstOrDefault().dispose.ToString() == "")
                    {
                        ViewData["dispose"] = "Nothing";
                    }
                    else
                    {
                        ViewData["dispose"] = getValidasiUser.FirstOrDefault().dispose.ToString();
                    }

                    //Register Data
                    if (getValidasiUser.FirstOrDefault().register is null || getValidasiUser.FirstOrDefault().register.ToString() == "")
                    {
                        ViewData["register"] = "Nothing";
                    }
                    else
                    {
                        ViewData["register"] = getValidasiUser.FirstOrDefault().register.ToString();
                    }

                    //View Data
                    if (getValidasiUser.FirstOrDefault().view is null || getValidasiUser.FirstOrDefault().view.ToString() == "")
                    {
                        ViewData["view"] = "Nothing";
                    }
                    else
                    {
                        ViewData["view"] = getValidasiUser.FirstOrDefault().view.ToString();
                    }

                    //Download Data
                    if (getValidasiUser.FirstOrDefault().download is null || getValidasiUser.FirstOrDefault().download.ToString() == "")
                    {
                        ViewData["download"] = "Nothing";
                    }
                    else
                    {
                        ViewData["download"] = getValidasiUser.FirstOrDefault().download.ToString();
                    }

                    //Upload Data
                    if (getValidasiUser.FirstOrDefault().upload is null || getValidasiUser.FirstOrDefault().upload.ToString() == "")
                    {
                        ViewData["upload"] = "Nothing";
                    }
                    else
                    {
                        ViewData["upload"] = getValidasiUser.FirstOrDefault().upload.ToString();
                    }

                    //Print Data
                    if (getValidasiUser.FirstOrDefault().print is null || getValidasiUser.FirstOrDefault().print.ToString() == "")
                    {
                        ViewData["print"] = "Nothing";
                    }
                    else
                    {
                        ViewData["print"] = getValidasiUser.FirstOrDefault().print.ToString();
                    }

                    //Approve 1
                    if (getValidasiUser.FirstOrDefault().approve1 is null || getValidasiUser.FirstOrDefault().approve1.ToString() == "")
                    {
                        ViewData["approve1"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve1"] = getValidasiUser.FirstOrDefault().approve1.ToString();
                    }

                    //Approve 2
                    if (getValidasiUser.FirstOrDefault().approve2 is null || getValidasiUser.FirstOrDefault().approve2.ToString() == "")
                    {
                        ViewData["approve2"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve2"] = getValidasiUser.FirstOrDefault().approve2.ToString();
                    }

                    //Approve 3
                    if (getValidasiUser.FirstOrDefault().approve3 is null || getValidasiUser.FirstOrDefault().approve3.ToString() == "")
                    {
                        ViewData["approve3"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve3"] = getValidasiUser.FirstOrDefault().approve3.ToString();
                    }

                    //Approve 4
                    if (getValidasiUser.FirstOrDefault().approve4 is null || getValidasiUser.FirstOrDefault().approve4.ToString() == "")
                    {
                        ViewData["approve4"] = "Nothing";
                    }
                    else
                    {
                        ViewData["approve4"] = getValidasiUser.FirstOrDefault().approve4.ToString();
                    }

                    //Acknowledge
                    if (getValidasiUser.FirstOrDefault().acknowledge is null || getValidasiUser.FirstOrDefault().acknowledge.ToString() == "")
                    {
                        ViewData["acknowledge"] = "Nothing";
                    }
                    else
                    {
                        ViewData["acknowledge"] = getValidasiUser.FirstOrDefault().acknowledge.ToString();
                    }

                    //Enable Data
                    if (getValidasiUser.FirstOrDefault().enable is null || getValidasiUser.FirstOrDefault().enable.ToString() == "")
                    {
                        ViewData["enable"] = "Nothing";
                    }
                    else
                    {
                        ViewData["enable"] = getValidasiUser.FirstOrDefault().enable.ToString();
                    }

                    //Visible Data
                    if (getValidasiUser.FirstOrDefault().visible is null || getValidasiUser.FirstOrDefault().visible.ToString() == "")
                    {
                        ViewData["visible"] = "Nothing";
                    }
                    else
                    {
                        ViewData["visible"] = getValidasiUser.FirstOrDefault().visible.ToString();
                    }
                }
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        //--------------------------------------------------------- PAGE MASTER DOCUMENT --------------------------------------------
        #region Page Master Document
        #region Hyperlink Page Master Document
        public ActionResult PAGE_MASTER_DOCUMENT()
        {
            Settings.Title = "List Master Document";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            return View("Master_Document/Page_Master");
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(
            int start, int display, string DATA_ID, 
            string JENIS_TRANSAKSI, string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string STATUS_APPROVE,string STATUS_DISPOSE, 
            string NOMOR_RAK, string LABEL_RAK, string TGL_REGISTER, string PAGE_VIEWER)
        {
            //Buat Paging//
            PagingModel_DISA100007 pg = new PagingModel_DISA100007(R.getCountDISA100007(DATA_ID, JENIS_TRANSAKSI, NO_DOKUMEN, NAMA_DOKUMEN, DEPARTMENT, STATUS_APPROVE, STATUS_DISPOSE, NOMOR_RAK, LABEL_RAK, TGL_REGISTER, PAGE_VIEWER), start, display);

            //Munculin Data ke Grid//
            List<DISA100007Master> List = R.getDataDISA100007(pg.StartData, pg.EndData, JENIS_TRANSAKSI, NO_DOKUMEN, NAMA_DOKUMEN, DEPARTMENT, STATUS_APPROVE, STATUS_DISPOSE, NOMOR_RAK, LABEL_RAK, TGL_REGISTER, PAGE_VIEWER).ToList();
            ViewData["DataDISA100007"] = List;
            ViewData["PagingDISA100007"] = pg;

            ViewData["fitur_jenis_transaksi"] = JENIS_TRANSAKSI;


            var page_control = "";
            if (PAGE_VIEWER == "WaitingApproval")
            {
                if(JENIS_TRANSAKSI == "taruh")
                {
                    page_control = "Waiting_Approval/Datagrid_Data";
                }
                else if(JENIS_TRANSAKSI == "pinjam")
                {
                    page_control = "Waiting_Approval/Datagrid_Data_Pinjam";
                }
            }
            else if (PAGE_VIEWER == "MasterListDokumen")
            {
                page_control = "Master_Document/Datagrid_Data";
            }

            return PartialView(page_control);
        }
        #endregion
        
        #region Get Information Data Dokumen 
        public ActionResult get_Data_Dokumen(
            string NAMA_DOKUMEN, string LABEL_RAK,
            string NO_RAK, string DEPARTMENT, string BAGIAN)
        {
            var data = R.get_Data_Dokumen(NAMA_DOKUMEN, LABEL_RAK, NO_RAK, DEPARTMENT, BAGIAN);
            return Json(new { data, NAMA_DOKUMEN }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Tambah Data Master
        public ActionResult TAMBAH_DATA_MASTER_DOCUMENT(
            string JENIS_TRANSAKSI,
            string NAMA_DOKUMEN,
            string QTY_BUNDLE,
            string DEPARTMENT,
            string BAGIAN,
            string NO_RAK,
            string LABEL_RAK,
            string MASA_SIMPAN,
            string KETERANGAN,
            string PAGE_VIEWER
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Create No. Document
            var NO_DOKUMEN = R.getUrutanDocument();

            //Get Last Date
            DateTime ESTIMASI_DISPOSE = R.get_last_date(CREATED_DATE, MASA_SIMPAN);

            //Get Data Rak
            string RAK = LABEL_RAK;
            //string RAK = NO_RAK + "-" + LABEL_RAK;

            //Flag Approve
            string FLG_APPROVE = "FALSE";

            //Fitur
            var NAMA_FITUR = "Tambah Data";

            //Menu
            var NAMA_MENU = "";

            if (PAGE_VIEWER == "MasterListDokumen")
            {
                NAMA_MENU = "List Master Dokumen";
            }
            else
            {
                NAMA_MENU = "List Waiting Approval Document";
            }

            //Note Log
            var NOTE_LOG = "New Document Incoming.";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100007Repository.Create_Master_Document(
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
                );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "TAMBAH_DATA_MASTER_DOCUMENT", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "TAMBAH_DATA_MASTER_DOCUMENT", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        #region Tambah Data Pinjam Dokumen
        public ActionResult TAMBAH_DATA_PINJAM_DOCUMENT(
            string JENIS_TRANSAKSI,
            string NAMA_DOKUMEN,
            string NAMA_PEMINJAM,
            string QTY_BUNDLE,
            string DEPARTMENT,
            string BAGIAN,
            string NO_RAK,
            string LABEL_RAK,
            string MASA_PINJAM,
            string TGL_PINJAM,
            string KETERANGAN,
            string PAGE_VIEWER
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Get Last Date
            DateTime ESTIMASI_KEMBALI = DateTime.Parse(TGL_PINJAM).AddDays(Int32.Parse(MASA_PINJAM));

            //Get Data Rak
            string RAK = LABEL_RAK;

            //Flag Approve
            string FLG_PINJAM = "TRUE";

            //Fitur
            var NAMA_FITUR = "Tambah Data Pinjam";

            //Menu
            var NAMA_MENU = "";

            if (PAGE_VIEWER == "MasterListDokumen")
            {
                NAMA_MENU = "List Master Dokumen";
            }
            else
            {
                NAMA_MENU = "List Waiting Approval Document";
            }

            //Note Log
            var NOTE_LOG = "New Data Peminjaman.";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100007Repository.Create_Pinjam_Document(
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
                    );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "TAMBAH_DATA_PEMINJAMAN_DOCUMENT", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "TAMBAH_DATA_PEMINJAMAN_DOCUMENT", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        #region Tambah Data Pinjam Dokumen
        public ActionResult TAMBAH_DATA_PINJAM_DOCUMENT_NEW(
            string JENIS_TRANSAKSI,
            string NO_DOKUMEN,
            string NAMA_DOKUMEN,
            string NAMA_PEMINJAM,
            string DEPARTMENT_PEMINJAM,
            string BAGIAN_PEMINJAM,
            string MASA_PINJAM,
            string TGL_PINJAM,
            string NOTE_PEMINJAM
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Get Last Date
            DateTime ESTIMASI_KEMBALI = DateTime.Parse(TGL_PINJAM).AddDays(Int32.Parse(MASA_PINJAM));

            //Fitur
            var NAMA_FITUR = "Tambah Data Pinjam";

            //Menu
            var NAMA_MENU = "";

            //Note Log
            var NOTE_LOG = "New Data Peminjaman. // Nama Peminjam: " + NAMA_PEMINJAM + "// Department Peminjam: " + DEPARTMENT_PEMINJAM + "// Bagian Peminjam: " + BAGIAN_PEMINJAM;

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100007Repository.Create_Pinjam_Document_New(
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
                    );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "TAMBAH_DATA_PEMINJAMAN_DOCUMENT", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "TAMBAH_DATA_PEMINJAMAN_DOCUMENT", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data Master Dokumen
        public ActionResult Update_Data_Master_Document(string DATA)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string NO_DOKUMEN = Datas[1];
                string NAMA_DOKUMEN = Datas[2];
                string QTY_BUNDLE = Datas[3];
                string DEPARTMENT = Datas[4];
                string BAGIAN = Datas[5];
                string NO_RAK = Datas[6];
                string LABEL_RAK = Datas[7];
                string MASA_SIMPAN = Datas[8];
                string KETERANGAN = Datas[9];
                string TGL_REGISTER = Datas[10];
                string LOG_HISTORY_KETERANGAN = Datas[11];
                string PAGE_VIEWER = Datas[12];

                //Get User
                string USERNAME = username;

                //Get Date Updated
                DateTime DATE_UPDATED = DateTime.Now;

                //Get Last Date
                DateTime getDateRegister = DateTime.ParseExact(TGL_REGISTER, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime ESTIMASI_DISPOSE = R.get_last_date(getDateRegister, MASA_SIMPAN);

                //Fitur
                var NAMA_FITUR = "Updated Data";

                //Menu
                var NAMA_MENU = "";

                if (PAGE_VIEWER == "MasterListDokumen")
                {
                    NAMA_MENU = "List Master Dokumen";
                }
                else
                {
                    NAMA_MENU = "List Waiting Approval Document";
                }

                var EXEC = R.Update_Data_Master(ID, NO_DOKUMEN, NAMA_DOKUMEN, QTY_BUNDLE, DEPARTMENT, BAGIAN, NO_RAK, LABEL_RAK, MASA_SIMPAN, KETERANGAN, ESTIMASI_DISPOSE, LOG_HISTORY_KETERANGAN, USERNAME, DATE_UPDATED, NAMA_FITUR, NAMA_MENU, PAGE_VIEWER);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Update Master Document", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data Master Document
        public ActionResult Delete_Data_Master_Document(string DATA, string PAGE_VIEWER)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Get User
            string USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Fitur
            var NAMA_FITUR = "Hapus Data";

            //Menu
            var NAMA_MENU = "";

            if (PAGE_VIEWER == "MasterListDokumen")
            {
                NAMA_MENU = "List Master Dokmen";
            }
            else
            {
                NAMA_MENU = "List Waiting Approval Document";
            }

            //Note Log
            var NOTE_LOG = "New Document Incoming.";

            //Get Tg

            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R.Delete_Data_Master_Document(Datas[i], NAMA_MENU, NAMA_FITUR, NOTE_LOG, USERNAME, CREATED_DATE, PAGE_VIEWER);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Delete Master Document", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Dispose Data Master Document
        public ActionResult DISPOSE_DATA_MASTER(
            string ID
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Fitur
            var NAMA_FITUR = "Dispose Data";

            //Menu
            var NAMA_MENU = "List Master Document";

            //Note Log
            var NOTE_LOG = "No. Document: " + ID + ", Has Been Disposed.";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100007Repository.Dispose_Master_Document(
                     ID,
                     USERNAME,
                     CREATED_DATE,
                     NAMA_FITUR,
                     NAMA_MENU,
                     NOTE_LOG
                    );
                sts = Exec[0].STACK;

              if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Dispose Master Document", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Kembalikan Dokumen
        public ActionResult KEMBALIKAN_DATA_DOKUMEN(
            string ID,
            string NO_DOKUMEN,
            string NAMA_DOKUMEN
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Fitur
            var NAMA_FITUR = "Kembalikan Data";

            //Menu
            var NAMA_MENU = "List Pinjam Document";

            //Note Log
            var NOTE_LOG = "No. Document: " + NO_DOKUMEN + ", Sudah Dikembalikan.";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100007Repository.Kembalikan_Document(
                     ID,
                     NO_DOKUMEN,
                     NAMA_DOKUMEN,
                     USERNAME,
                     CREATED_DATE,
                     NAMA_FITUR,
                     NAMA_MENU,
                     NOTE_LOG
                    );
                sts = Exec[0].STACK;

              if (Exec[0].STACK == "TRUE")
              {
                var res = M.get_default_message("MWP001", "Kembalikan Document", "", "");
                message = res[0].MSG_TEXT;
              }
              else
              {
                message = Exec[0].LINE_STS;
              }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Download Excel List
        [HttpGet]
        public virtual ActionResult DownloadExcel_ListDocument(
            string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string STATUS_APPROVE, string STATUS_DISPOSE, string PAGE_VIEWER
            )
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Document_Control/Data_List_Document_Template.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DISA100007_Download_Excel> dataListDocument = R.DownloadExcel_Document(1, 10000000, NO_DOKUMEN, NAMA_DOKUMEN, DEPARTMENT, STATUS_APPROVE, STATUS_DISPOSE, PAGE_VIEWER).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B6"].LoadFromCollection(dataListDocument);
                worksheet.Cells["B6:S" + (dataListDocument.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:S" + (dataListDocument.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:S" + (dataListDocument.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:S" + (dataListDocument.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data List Document" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #region History Data Asset
        public virtual ActionResult GetDataHistory(string ID)
        {
            try
            {
                List<History_Data> GetDataHistory_Detail = R.GetDataHistory(ID).ToList();
                ViewData["Title"] = "History";

                if (GetDataHistory_Detail.Count > 0)
                {
                    ViewData["DataHistory_Document"] = GetDataHistory_Detail;
                    ViewData["NO_DOKUMEN"] = GetDataHistory_Detail.FirstOrDefault().no_document.ToString();
                    ViewData["NAMA_DOKUMEN"] = GetDataHistory_Detail.FirstOrDefault().nama_document.ToString();


                    sts = "TRUE";
                    message = "Success";
                }
                else
                {
                    sts = "FALSE";
                    message = "Data History Not Found!";
                }

            }
            catch (InvalidDataException)
            {

            }

            return PartialView("Master_Document/Datagrid_Data_History");
        }
        #endregion

        #endregion



        //--------------------------------------------------------- PAGE WAITING APPROVAL --------------------------------------------
        #region PAGE WAITING APPROVAL

        #region Hyperlink Page Waiting Approval
        public ActionResult PAGE_WAITING_APPROVAL()
        {
            Settings.Title = "List Waiting Approval Document";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            ViewData["fitur_jenis_transaksi"] = "taruh";

            return View("Waiting_Approval/Page_Waiting_Approval");
        }
        #endregion

        #region Approve Data Document
        public ActionResult APPROVE_DOCUMENT(
            string ID,
            string NO_DOCUMENT,
            string NO_RAK,
            string LABEL_RAK,
            string APPROVED_BY
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            //Fitur
            var NAMA_FITUR = "Approval Data";

            //Menu
            var NAMA_MENU = "List Waiting Approval Document";

            //Note Log
            var NOTE_LOG = "No. Document: " + ID + ", Has Been Approved by: " + USERNAME + " (" + APPROVED_BY + ")";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA100007Repository.Approved_Data_Document(
                     ID,
                     NO_DOCUMENT,
                     NO_RAK,
                     LABEL_RAK,
                     APPROVED_BY,
                     USERNAME,
                     CREATED_DATE,
                     NAMA_FITUR,
                     NAMA_MENU,
                     NOTE_LOG
                    );
                sts = Exec[0].STACK;

                if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Approve Document", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Detail Data Dispose Asset
        public virtual ActionResult GetDataDetail(string ID)
        {
            try
            {
                List<DISA100007Master> GetData_Detail = R.GetDataDetail(ID).ToList();
                ViewData["Title"] = "Detail Document";

                if (GetData_Detail.Count > 0)
                {
                    ViewData["Data_Document_Detail"] = GetData_Detail;
                    ViewData["NO_DOCUMENT"] = GetData_Detail.FirstOrDefault().NO_DOCUMENT.ToString();
                    ViewData["NAMA_DOCUMENT"] = GetData_Detail.FirstOrDefault().NAMA_DOCUMENT.ToString();
                    ViewData["DEPARTMENT"] = GetData_Detail.FirstOrDefault().DEPARTMENT.ToString();
                    ViewData["BAGIAN"] = GetData_Detail.FirstOrDefault().BAGIAN.ToString();
                    ViewData["RAK"] = GetData_Detail.FirstOrDefault().RAK.ToString();
                    ViewData["LABEL_RAK"] = GetData_Detail.FirstOrDefault().LABEL_RAK.ToString();
                    ViewData["TGL_REGISTER"] = GetData_Detail.FirstOrDefault().TGL_REGISTER.ToString();
                    ViewData["ESTIMASI_DISPOSE"] = GetData_Detail.FirstOrDefault().ESTIMASI_DISPOSE.ToString();
                    ViewData["MASA_SIMPAN"] = GetData_Detail.FirstOrDefault().MASA_SIMPAN.ToString();
                    ViewData["KETERANGAN"] = GetData_Detail.FirstOrDefault().KETERANGAN.ToString();

                    sts = "TRUE";
                    message = "Success";
                }
                else
                {
                    sts = "FALSE";
                    message = "Data Detail Document Not Found!";
                }

            }
            catch (InvalidDataException)
            {

            }

            return PartialView("Waiting_Approval/Data_Show_Detail");
        }
        #endregion


        #endregion

        //------------------------------------------------------ PAGE PINJAM DOCUMENT ------------------------------------------
        #region PAGE PINJAM DOKUMEN

        #region Hyperlink Page Pinjam Document
        public ActionResult PAGE_PINJAM_DOCUMENT()
        {
            Settings.Title = "List Pinjam Document";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            return View("Pinjam_Document/Page_Pinjam");
        }
        #endregion  

        #region Search Data
        public ActionResult Search_Data_Pinjam_Document(
            int start, int display, string DATA_ID,
            string NO_DOKUMEN, string NAMA_DOKUMEN, string DEPARTMENT,
            string NOMOR_RAK, string LABEL_RAK, string TGL_PINJAM, string STATUS_PENGEMBALIAN)
        {
            //Buat Paging//
            PagingModel_DISA100007 pg = new PagingModel_DISA100007(R.getCount_Pinjam_Document(DATA_ID, NO_DOKUMEN, NAMA_DOKUMEN, DEPARTMENT, NOMOR_RAK, LABEL_RAK, TGL_PINJAM, STATUS_PENGEMBALIAN), start, display);

            //Munculin Data ke Grid//
            List<DISA100007Master> List = R.getData_Pinjam_Document(pg.StartData, pg.EndData, NO_DOKUMEN, NAMA_DOKUMEN, DEPARTMENT, NOMOR_RAK, LABEL_RAK, TGL_PINJAM, STATUS_PENGEMBALIAN).ToList();
            ViewData["DataDISA100007"] = List;
            ViewData["PagingDISA100007"] = pg;


            return PartialView("Pinjam_Document/Datagrid_Data");
        }
        #endregion

        #endregion
    }
}