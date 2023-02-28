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
using AI070.Models.DISA070001Master;
using System.Security.Cryptography;
using System.Text;

using Toyota.Common.Database;

using System.Data;
using System.Data.Entity;
//using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Net;
using System.Text.RegularExpressions;
using LinqToExcel;
using System.Data.SqlClient;
using System.Configuration;

namespace AI070.Controllers
{
    public class DISA070001Controller : PageController
    {

        //private TxDTIPRDEntities3 db = new TxDTIPRDEntities3();
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA070001Repository R = new DISA070001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Aktual Masalah Produksi";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string DATE, string TIME, string HALTE)
        {
            //Buat Paging//
            PagingModel_DISA070001 pg = new PagingModel_DISA070001(R.getCountDISA070001(DATA_ID, DATE, TIME, HALTE), start, display);

            //Munculin Data ke Grid//
            List<DISA070001Master> List = R.getDataDISA070001(pg.StartData, pg.EndData, DATE, TIME, HALTE).ToList();
            ViewData["DataDISA070001"] = List;
            ViewData["PagingDISA070001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW(string HALTE, string DATE, string TIME, string OPMJ, string MASALAH, string ACTION)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA070001Repository.Create(
                                                        HALTE,
                                                        DATE,
                                                        TIME,                                                        
                                                        OPMJ,
                                                        MASALAH,
                                                        ACTION,
                                                        username
                                                        );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Aktual Masalah Produksi", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Aktual Masalah Produksi", "", "");
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


        #region Upload Data   
        [HttpPost]
        public ActionResult UploadExcelsheet()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                List<DISA070001Master> _lstProductMaster = new List<DISA070001Master>();
                string filePath = string.Empty;
                if (Request.Files != null)
                {
                    string path = Server.MapPath("~/Uploads/Actual Trouble/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName("ProductUploadSheet-" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss-ff") + Path.GetExtension(file.FileName));
                    string extension = Path.GetExtension("ProductUploadSheet-" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss-ff") + Path.GetExtension(file.FileName));
                    file.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        //IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
                        case ".xls": //Excel 97-03.
                            //conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 and above.
                            //conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                            break;
                    }
                    int total = 0;
                    int entered = 0;
                    int failed = 0;

                    conString = string.Format(conString, filePath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                DataTable dt = new DataTable();
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();


                                if (dt.Rows.Count > 0)
                                {

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        total++;
                                        _lstProductMaster.Add(new DISA070001Master
                                        {
                                            //ProductSKU = row["VendorSKU"].ToString().Trim() + "GL" + DateTime.Now.Year.ToString().Substring(2),
                                            DATE = row["date"].ToString().Replace("'", "''"),
                                            TIME = row["time"].ToString().Trim(),
                                            HALTE = row["halte"].ToString().Trim(),
                                            OPMJ = row["opmj"].ToString().Replace("'", "''"),
                                            MASALAH = row["masalah"].ToString().Replace("'", "''"),
                                            ACTION = row["action"].ToString().Replace("'", "''"),                                            
                                        
                                        });
                                        entered++;
                                        //if (entered > 0)
                                        //{
                                        //    GetOccassionRecipientMasters();
                                        //}
                                    }
                                }
                            }
                            failed = total - entered;
                            if (failed > 0)
                            {
                                ViewBag.Fail = failed + " Records not entered";
                            }
                            else
                            {
                                ViewBag.Pass = entered + " Records entered";
                                ViewBag.Fail = failed + " Records not entered";
                            }
                            ViewBag.Total = total + " Total Records";
                        }
                    }
                }
                List<DISA070001Master> _productmaster = new List<DISA070001Master>();
                ViewBag.maindata = _lstProductMaster;
                //return Json(_lstProductMaster, JsonRequestBehavior.AllowGet);
                return View("ImportProductsFromExcel", _lstProductMaster);
            }
            else
            {
                //return Json("", JsonRequestBehavior.AllowGet);
                return View();
            }

        }
    


//[HttpPost]
//public JsonResult UploadExcel(ad_dis_rtjn_master_actual_masalah ad_dis_rtjn_master_actual_masalah, HttpPostedFileBase FileUpload)
//{
//    List<string> data = new List<string>();
//    if (FileUpload != null)
//    {
//        // tdata.ExecuteCommand("truncate table OtherCompanyAssets");
//        if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
//        {
//            string filename = FileUpload.FileName;
//            string targetpath = Server.MapPath("~/Doc/");
//            FileUpload.SaveAs(targetpath + filename);
//            string pathToExcelFile = targetpath + filename;
//            var connectionString = "";
//            if (filename.EndsWith(".xls"))
//            {
//                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
//            }
//            else if (filename.EndsWith(".xlsx"))
//            {
//                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
//            }

//            var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
//            var ds = new DataSet();
//            adapter.Fill(ds, "ExcelTable");
//            DataTable dtable = ds.Tables["ExcelTable"];
//            string sheetName = "Sheet1";
//            var excelFile = new ExcelQueryFactory(pathToExcelFile);
//            var artistAlbums = from a in excelFile.Worksheet<ad_dis_rtjn_master_actual_masalah>(sheetName) select a;
//            foreach (var a in artistAlbums)
//            {
//                try
//                {
//                    if (a.DATE != "" && a.TIME != "" && a.HALTE != "")
//                    {
//                        ad_dis_rtjn_master_actual_masalah TU = new ad_dis_rtjn_master_actual_masalah();
//                        TU.DATE = a.DATE;
//                        TU.TIME = a.TIME;
//                        TU.HALTE = a.HALTE;
//                        db.ad_dis_rtjn_master_actual_masalah.Add(TU);
//                        db.SaveChanges();
//                    }
//                    else
//                    {
//                        data.Add("<ul>");
//                        if (a.DATE == "" || a.DATE == null) data.Add("<li> name is required</li>");
//                        if (a.TIME == "" || a.TIME == null) data.Add("<li> Address is required</li>");
//                        if (a.HALTE == "" || a.HALTE == null) data.Add("<li>ContactNo is required</li>");
//                        data.Add("</ul>");
//                        data.ToArray();
//                        return Json(data, JsonRequestBehavior.AllowGet);
//                    }
//                }
//                catch (DbEntityValidationException ex)
//                {
//                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
//                    {
//                        foreach (var validationError in entityValidationErrors.ValidationErrors)
//                        {
//                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
//                        }
//                    }
//                }
//            }
//            //deleting excel file from folder
//            if ((System.IO.File.Exists(pathToExcelFile)))
//            {
//                System.IO.File.Delete(pathToExcelFile);
//            }
//            return Json("success", JsonRequestBehavior.AllowGet);
//        }
//        else
//        {
//            //alert message for invalid file format
//            data.Add("<ul>");
//            data.Add("<li>Only Excel file format is allowed</li>");
//            data.Add("</ul>");
//            data.ToArray();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }
//    }
//    else
//    {
//        data.Add("<ul>");
//        if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
//        data.Add("</ul>");
//        data.ToArray();
//        return Json(data, JsonRequestBehavior.AllowGet);
//    }
//}
#endregion

        #region Update Data
public ActionResult Update_Data(string DATA)
        {            
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string HALTE = Datas[1];
                string DATE = Datas[2];
                string TIME = Datas[3];                
                string OPMJ = Datas[4];
                string ACTION = Datas[5];
                string MASALAH = Datas[6];               
                
                var EXEC = R.Update_Data(ID, HALTE, DATE, TIME, OPMJ, ACTION, MASALAH, username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Aktual Masalah Produksi", "", "");
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

        #region Delete Data
        public ActionResult Delete_Data(string DATA)
        {            
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R.Delete_Data(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Aktual Masalah Produksi", "", "");
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

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion
        
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

    }
}