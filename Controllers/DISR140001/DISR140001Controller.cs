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
using AI070.Models.DISR140001Master;
using Newtonsoft.Json;
using AI070.Models.DISR140001;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AI070.Controllers
{
    public class DISR140001Controller : BaseController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR140001Repository R = new DISR140001Repository();
        User U = new User();
        String reg_no;
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;
        string sts;
        string message;

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
                Settings.Title = "Label Gaikan";
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
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);

                reg_no = Lookup.Get<Toyota.Common.Credential.User>().RegistrationNumber.ToString();
                ViewData["User"] = username;
                ViewData["RegNo"] = reg_no;

                GetIdentitasUser(username);

                ViewData["dmc_code"] = R.getDmcTypeItemMaster();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region User Identity
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

        #region Validasi User
        public ActionResult validasiOpenForm(string formMenu)
        {
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            string USERNAME = username;

            string sts = null;
            string message = null;

            try
            {
                //Check User Validasi
                List<LIST_CHECK_USER> getValidasiForm = R.getcheck_User(USERNAME, formMenu);


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


        //==============================================================================================================================
        //========================================================= ADM_PAGE ===========================================================
        //==============================================================================================================================
        #region Page Admin
        #region Hyperlink Page List Data
        public ActionResult LIST_DATA_SUMMARY()
        {
            Settings.Title = "List Data Summary Gaikan";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);
            
            ViewData["fitur"] = "Fitur_List_Summary";
            return View("Adm_Page/Index");
        }
        #endregion
        
        #region Hyperlink Page List Data
        public ActionResult LIST_DATA_DETAIL()
        {
            Settings.Title = "List Data Detail Gaikan";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            ViewData["fitur"] = "Fitur_List_Detail";
            return View("Adm_Page/Index");
        }
        #endregion

        #region Search Data Detail
        public ActionResult Search_Data_Detail(int start, int display, string DATA_ID, string ID_BUNDLE, string ID_PRODUKSI, string DMC_CODE, string LOT_NO, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {

            PagingModel_DISR140001 pg = new PagingModel_DISR140001(R.getCount_Detail(DATA_ID, ID_BUNDLE, ID_PRODUKSI, DMC_CODE, LOT_NO, TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN), start, display);

            //Munculin Data ke Grid//
            List<DISR140001Master> List = R.getData_Detail(pg.StartData, pg.EndData, ID_BUNDLE, ID_PRODUKSI, DMC_CODE, LOT_NO, TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN).ToList();
            ViewData["DataDISR140001"] = List;
            ViewData["PagingDISR140001"] = pg;
            ViewData["dmc_code"] = R.getDmcTypeItemMaster();

            return PartialView("Adm_Page/Datagrid_Data_Detail", pg.CountData);
        }
        #endregion

        #region Download Excel List Detail
        [HttpGet]
        public virtual ActionResult DownloadExcel_Detail(string ID_BUNDLE, string ID_PRODUKSI, string DMC_CODE, string LOT_NO, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            //or if you use asp.net, get the relative path
            string filePath = "";
            filePath = Server.MapPath("~/Content/TemplateReport/Label_Gaikan/Data_List_Detail_Gaikan.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<Download_List_Detail> data_List_Detail = R.DownloadExcel_List_Detail(1, 10000000, ID_BUNDLE, ID_PRODUKSI, DMC_CODE, LOT_NO, TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                worksheet.Cells["B6"].LoadFromCollection(data_List_Detail);
                worksheet.Cells["B6:S" + (data_List_Detail.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:S" + (data_List_Detail.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:S" + (data_List_Detail.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:S" + (data_List_Detail.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data List Detail Gaikan_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data_Summary(int start, int display, string DATA_ID, string ID_BUNDLE, string DMC_CODE, /*string LOT_NO,*/ string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {

            PagingModel_DISR140001 pg = new PagingModel_DISR140001(R.getCount_Summary(DATA_ID, ID_BUNDLE, DMC_CODE, /*LOT_NO,*/ TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN), start, display);

            //Munculin Data ke Grid//
            List<DISR140001Master> List = R.getData_Summary(pg.StartData, pg.EndData, ID_BUNDLE, DMC_CODE, /*LOT_NO,*/ TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN).ToList();
            ViewData["DataDISR140001"] = List;
            ViewData["PagingDISR140001"] = pg;
            ViewData["dmc_code"] = R.getDmcTypeItemMaster();

            return PartialView("Adm_Page/Datagrid_Data_Summary", pg.CountData);
        }
        #endregion

        #region Download Excel List Summary
        [HttpGet]
        public virtual ActionResult DownloadExcel_Summary(string ID_BUNDLE, string DMC_CODE, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            //or if you use asp.net, get the relative path
            string filePath = "";
            filePath = Server.MapPath("~/Content/TemplateReport/Label_Gaikan/Data_List_Summary_Gaikan.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<Download_List_Summary> data_List_Summary = R.DownloadExcel_List_Summary(1, 10000000, ID_BUNDLE, DMC_CODE, TRANS_DATE, TRANS_DATETO, NIK_GAIKAN, OPR_GAIKAN).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                worksheet.Cells["B6"].LoadFromCollection(data_List_Summary);
                worksheet.Cells["B6:Y" + (data_List_Summary.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:Y" + (data_List_Summary.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:Y" + (data_List_Summary.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:Y" + (data_List_Summary.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data List Summary Gaikan_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        #endregion
        
        #region Update Data
        public ActionResult UPDATE_DATA_MULTIPLE()
        {
            var typeFunction = "UPDATE";
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            string ID_BUNDEL = "";
            string SERIAL = "";
            string SHIFT = "";

            //User Login
            string USERNAME = username;

            //Fitur
            string NAMA_FITUR = "EDIT LABEL GAIKAN";

            //Tanggal
            DateTime CREATED_DATE = DateTime.Now;

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                var items = JsonConvert.DeserializeObject<DISR140001InputForm>(json);

                foreach (var _detailItem in items.data_detail)
                {
                    ID_BUNDEL = items.ID_BUNDLE;

                    List<list_detail_gaikan_model> GetData_Detail = R.getBindDataDetailGaikan(ID_BUNDEL).ToList();

                    //Get Shift from Detail Data
                    SHIFT = GetData_Detail.FirstOrDefault().SHIFT.ToString();

                    if (GetData_Detail.Count > 0)
                    {
                        foreach (list_detail_gaikan_model item in GetData_Detail)
                        {
                            ID_BUNDEL = item.ID;
                            SERIAL = item.SERIAL;

                            var ExecuteDelete = DISR140001Repository.Delete(item, USERNAME, typeFunction);

                        }
                    }

                    var Exec = DISR140001Repository.Update(items, ID_BUNDEL, SHIFT, username);

                    //var Exec = DISR140001Repository.Create_Detail_Dispose(items, NO_DISPOSE, USERNAME, CREATED_DATE, CREATED_BY_SIGN, NAMA_FITUR);
                    sts = "TRUE";
                    message = "Data berhasil disimpan!";
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, ID_BUNDEL }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data()
        {
            var typeFunction = "DELETE";
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var item = JsonConvert.DeserializeObject<list_detail_gaikan_model>(json);

                var Exec = DISR140001Repository.Delete(item, username, typeFunction);
                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        //==============================================================================================================================
        //========================================================= CHECKER_PAGE =======================================================
        //==============================================================================================================================
        #region Page Checker
        #region Hyperlink Checker Page 
        public ActionResult CHECKER_PAGE()
        {
            Settings.Title = "Validasi Data Gaikan";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            return View("Checker_Page/Index");
        }
        #endregion

        #region Validasi Checker
        public ActionResult VALIDASI_DATA(
            string NIK, 
            string ID_BUNDLE
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                var Exec = R.Validasi_Data(NIK, ID_BUNDLE, username);
                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #endregion

        //==============================================================================================================================
        //========================================================== OPT_PAGE ==========================================================
        //==============================================================================================================================
        #region Page Operator
        #region Hyperlink Operator Page 
        public ActionResult FORM_INPUT()
        {
            Settings.Title = "Form Input Gaikan";
            ViewData["Title1"] = Settings.Title;

            GetDataHeader();
            GetDataValidasiUser(username, Settings.Title);

            return View("Opt_Page/Index");
        }
        #endregion

        #region Add New
        public ActionResult Insert_Data()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            reg_no = Lookup.Get<Toyota.Common.Credential.User>().RegistrationNumber.ToString();

            string NIK_ADM = null;
            string NAMA_ADM = null;
            string INPUT_ADM_DATE = null;
            if(reg_no == "ADM_ASSY")
            {
                GetIdentitasUser(username);
                NIK_ADM = NIK;
                NAMA_ADM = NAMA_USER;
                INPUT_ADM_DATE = DateTime.Now.ToString();
            }

            string ID_BUNDLE = null;
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                var items = JsonConvert.DeserializeObject<DISR140001InputForm>(json);

                Sequence_model seqmodel = new Sequence_model();
                seqmodel.TYPE_TRX = "BUNDLE_CODE";
                seqmodel.YEAR_TRX = DateTime.Now.Year.ToString();
                seqmodel.MONTH_TRX = DateTime.Now.Month.ToString();
                seqmodel.DAY_TRX = DateTime.Now.Day.ToString();
                items.BUNDLE_CODE = R.GetBundleCode(seqmodel, username);
                ID_BUNDLE = items.BUNDLE_CODE;
                var dataShift = R.getShift();

                var Exec = DISR140001Repository.Create(items, items.BUNDLE_CODE, dataShift, username, NIK_ADM, INPUT_ADM_DATE);
                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, ID_BUNDLE }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        //==============================================================================================================================
        //========================================================== OTHERS FUNCTION ===================================================
        //==============================================================================================================================

        #region Data Validasi User
        public void GetDataValidasiUser(string USERNAME, string NAMA_FORM)
        {
            try
            {
                //Check User Validasi
                List<LIST_CHECK_USER> getValidasiUser = R.getcheck_User(USERNAME, NAMA_FORM);

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
                    
                    //Export Data
                    if (getValidasiUser.FirstOrDefault().export is null || getValidasiUser.FirstOrDefault().export.ToString() == "")
                    {
                        ViewData["export"] = "Nothing";
                    }
                    else
                    {
                        ViewData["export"] = getValidasiUser.FirstOrDefault().export.ToString();
                    }
                }
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Get Data Operator 
        public ActionResult get_Data_Operator(string id_sagyosha)
        {
            var data = R.get_Data_Operator(id_sagyosha);
            return Json(new { data, id_sagyosha }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Seihin 
        public ActionResult get_Data_Seihin(string id_seisan)
        {
            var data = R.get_Data_Seihin(id_seisan);
            return Json(new { data, id_seisan }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Proses
        public ActionResult get_Data_Proses(string id_kotei)
        {
            var data = R.get_Data_Proses(id_kotei);
            return Json(new { data, id_kotei }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Convertion Table
        public ActionResult get_Data_ConvertionTable(string id_seihin)
        {
            var data = R.get_Data_ConvertionTable(id_seihin);
            return Json(new { data, id_seihin }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Data Check Serial No
        public ActionResult check_Serial_DB(string SERIAL_NO, string DMC_CODE)
        {
            var isExist = false;

            var checkData = R.get_check_Serial_DB(SERIAL_NO, DMC_CODE);

            if (checkData == "true")
            {
                isExist = true;
            }
            else
            {
                isExist = false;
            }

            return Json(new { isExist }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        #region Get Data Gaikan To Print
        public ActionResult getDetailGaikan_Print(string ID_BUNDLE, string PAGE_VIEWER)
        {
            var sts = new object();
            string message = null;

            List<list_detail_gaikan_model> getDataGaikan = R.getBindDataDetailGaikan(ID_BUNDLE);
            ViewData["List_Data_Gaikan"] = getDataGaikan;
            if (getDataGaikan.Count > 0)
            {
                ViewData["ID"] = getDataGaikan.FirstOrDefault().ID.ToString();
                ViewData["ID_PRODUKSI"] = getDataGaikan.FirstOrDefault().ID_PRODUKSI.ToString();
                ViewData["DMC_CODE"] = getDataGaikan.FirstOrDefault().DMC_CODE.ToString();
                ViewData["JENIS_LOTTO"] = getDataGaikan.FirstOrDefault().JENIS_LOTTO.ToString();
                ViewData["STATUS_LOTTO"] = getDataGaikan.FirstOrDefault().STATUS_LOTTO.ToString();

                string SERIAL_LOTTO = GET_SERIAL_LOTTO(getDataGaikan);
                ViewData["SERIAL"] = SERIAL_LOTTO;

                ViewData["QTY_BUNDLE_ACT"] = getDataGaikan.FirstOrDefault().QTY_BUNDLE_ACT.ToString();
                ViewData["NAMA"] = getDataGaikan.FirstOrDefault().NAMA.ToString();
                ViewData["KETERANGAN"] = getDataGaikan.FirstOrDefault().KETERANGAN.ToString();

                /*====== Update Jumlah Print ========*/
                var Exec = R.Update_Jml_Print(ID_BUNDLE);
            }

            return View(PAGE_VIEWER + "/PrintPreview");
        }
        #endregion

        #region Get Serial Lotto
        public string GET_SERIAL_LOTTO(List<list_detail_gaikan_model> getDataGaikan)
        {
            string SERIAL_LOTTO = "";
            var isExist = false;

            for (int i = 0; i < getDataGaikan.Count; i++)
            {
                var jml_lotto = 0;
                var temp_Lotto = getDataGaikan[i].SERIAL;

                if (i == getDataGaikan.Count - 1)
                {
                    //SERIAL += getDataGaikan[i].SERIAL;

                    if (getDataGaikan.FirstOrDefault().STATUS_LOTTO.ToString() == "Campuran")
                    {
                        if (SERIAL_LOTTO.Contains(getDataGaikan[i].SERIAL) != true)
                        {
                            SERIAL_LOTTO += getDataGaikan[i].SERIAL;

                            for (var j = 0; j < getDataGaikan.Count; j++)
                            {
                                if (j != getDataGaikan.Count - 1)
                                {
                                    if (getDataGaikan[j + 1].SERIAL == getDataGaikan[i].SERIAL)
                                    {
                                        jml_lotto += 1;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }

                            if (jml_lotto == 0)
                            {
                                jml_lotto += 1;
                            }

                            //Add Jumlah Lotto
                            SERIAL_LOTTO += "(" + jml_lotto + "), ";
                        }

                    }
                    else if (getDataGaikan.FirstOrDefault().STATUS_LOTTO.ToString() == "Non Campuran")
                    {
                        SERIAL_LOTTO += getDataGaikan[i].SERIAL;
                    }
                }
                else
                {
                    if (getDataGaikan.FirstOrDefault().STATUS_LOTTO.ToString() == "Campuran")
                    {
                        if (SERIAL_LOTTO == "")
                        {
                            SERIAL_LOTTO = getDataGaikan[i].SERIAL;
                            //jml_lotto = getDataGaikan.Count(s => SERIAL_LOTTO.Contains(getDataGaikan[i].SERIAL));
                            jml_lotto = 1;
                            for (var j = 0; j < getDataGaikan.Count; j++)
                            {
                                if (j != getDataGaikan.Count - 1)
                                {
                                    if (getDataGaikan[j + 1].SERIAL == getDataGaikan[i].SERIAL)
                                    {
                                        jml_lotto += 1;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }

                            SERIAL_LOTTO += "(" + jml_lotto + "), ";
                        }
                        else
                        {
                            if (SERIAL_LOTTO.Contains(getDataGaikan[i].SERIAL) != true)
                            {
                                SERIAL_LOTTO += getDataGaikan[i].SERIAL;

                                for (var j = 0; j < getDataGaikan.Count; j++)
                                {
                                    if (j != getDataGaikan.Count - 1)
                                    {
                                        if (getDataGaikan[j + 1].SERIAL == getDataGaikan[i].SERIAL)
                                        {
                                            jml_lotto += 1;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                                if (jml_lotto == 0)
                                {
                                    jml_lotto += 1;
                                }

                                //Add Jumlah Lotto
                                SERIAL_LOTTO += "(" + jml_lotto + "), ";
                            }

                        }

                    }
                    else if (getDataGaikan.FirstOrDefault().STATUS_LOTTO.ToString() == "Non Campuran")
                    {
                        SERIAL_LOTTO += getDataGaikan[i].SERIAL + ", ";
                    }

                }
            }
            return SERIAL_LOTTO;
        }
        #endregion

        [HttpGet]
        #region Get Bind Data Gaikan
        public ActionResult getDetailGaikan(string ID_BUNDLE)
        {
            var sts = new object();
            string message = null;
            try
            {
                var data = R.getBindDataDetailGaikan(ID_BUNDLE);

                return Json(new { sts = "TRUE", list = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                return Json(new { sts = "FALSE", mesage = "Error" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

    }
}
