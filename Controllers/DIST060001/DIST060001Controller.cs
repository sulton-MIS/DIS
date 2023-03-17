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
using AI070.Models.DIST060001Master;
using System.Security.Cryptography;
using System.Text;
using NPOI.OpenXmlFormats.Drawing;
using NPOI.OpenXmlFormats.Spreadsheet;
using OfficeOpenXml.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AI070.Controllers
{
    public class DIST060001Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DIST060001Repository R = new DIST060001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Convention Table Packing";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(
            int start, 
            int display, 
            string DATA_ID, 
            string ItemCode, 
            string Parts,            
            string type            
            )
        {
            //Buat Paging//
            PagingModel_DIST060001 pg = new PagingModel_DIST060001(R.getCountDIST060001(
                DATA_ID,
                ItemCode,
                Parts,               
                type            
                ), start, display);

            //Munculin Data ke Grid//
            List<DIST060001Master> List = R.getDataDIST060001(pg.StartData, pg.EndData,
                ItemCode,
                Parts,                
                type
                ).ToList();
            ViewData["DataDIST060001"] = List;
            ViewData["PagingDIST060001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Download Excel 
        [HttpGet]
        public virtual ActionResult DownloadExcel(
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Data_Convention_Table.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<DIST060001Master> ConvTable = R.DownloadExcel(1, 10000000, 
                    ItemCode,
                    Parts,
                    SizeProduct,
                    type,
                    BundleQty,
                    InnerQty,
                    MasterQty,
                    InnerType,
                    InnerL,
                    InnerW,
                    InnerH,
                    InnerWeight,
                    MasterType,
                    MasterL,
                    MasterW,
                    MasterH,
                    MasterWeight).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B6"].LoadFromCollection(ConvTable);
                worksheet.Cells["B6:W" + (ConvTable.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:W" + (ConvTable.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:W" + (ConvTable.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B6:W" + (ConvTable.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "ConventionTable_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion
        #region Add New        
        public ActionResult ADD_NEW(
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DIST060001Repository.Create(
                    ItemCode,
                    Parts,
                    SizeProduct,
                    type,
                    BundleQty,
                    InnerQty,
                    MasterQty,
                    InnerType,
                    InnerL,
                    InnerW,
                    InnerH,
                    InnerWeight,
                    MasterType,
                    MasterL,
                    MasterW,
                    MasterH,
                    MasterWeight,
                    username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Convention Table Packing", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Convention Table Packing", "", "");
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
                ViewData["EXECUTOR"] = R.getExecutor();              
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion        

        #region Update Data
        public ActionResult Update_Data(string DATA)
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
                string ItemCode = Datas[1];
                string Parts = Datas[2];
                string SizeProduct = Datas[3];
                string type = Datas[4];
                string BundleQty = Datas[5];
                string InnerQty = Datas[6];
                string MasterQty = Datas[7];
                string InnerType = Datas[8];
                string InnerL = Datas[9];
                string InnerW = Datas[10];
                string InnerH = Datas[11];
                string InnerWeight = Datas[12];
                string MasterType = Datas[13];
                string MasterL = Datas[14];
                string MasterW = Datas[15];
                string MasterH = Datas[16];
                string MasterWeight = Datas[17];

                string STATUS = "1";
                var EXEC = R.Update_Data(
                    ID,
                    ItemCode,
                    Parts,
                    SizeProduct,
                    type,
                    BundleQty,
                    InnerQty,
                    MasterQty,
                    InnerType,
                    InnerL,
                    InnerW,
                    InnerH,
                    InnerWeight,
                    MasterType,
                    MasterL,
                    MasterW,
                    MasterH,
                    MasterWeight,
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Convention Table Packing", "", "");
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
            string stsRespon;
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
                var res = M.get_default_message("MWP002", "Master Convention Table Packing", "", "");
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

       
    }
}