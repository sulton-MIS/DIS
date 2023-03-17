using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP03006;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rotativa;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using Rotativa.Options;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QRCoder;

namespace AI070.Controllers.WP03006
{
    public class WP03006Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03006Repository R = new WP03006Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Data Score Participant";
                ViewData["Title"] = Settings.Title;
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        [HttpGet]
        public virtual ActionResult GetSummmaryData(int start, int display, string RegNo, string IdentityType, string IdentityNo, string UserName, string Email)
        {
            List<WP03006Master> examScore = R.GetDataByFilter(start, display, RegNo, IdentityType, IdentityNo, UserName, Email);

            PagingModel_WP03006 pg = new PagingModel_WP03006(R.CountData(RegNo, IdentityType, IdentityNo, UserName, Email, true), start, display);

            ViewData["ExamSubject"] = R.GetExamSubject();
            ViewData["PagingWP03006"] = pg;
            ViewData["Title"] = "Data Score Participant";
            ViewData["SummaryData"] = examScore;
            return PartialView("Datagrid_SummaryData");
        }

        [HttpGet]
        public virtual ActionResult PrintPDF(string regNo, string IdentityNo, string UserName, string Email)
        {
            List<WP03006Master> examScore = R.  GetDataByFilter(1, 1000000, regNo, IdentityNo, UserName, Email,"ikbal@dmcti.co.id");

            ViewData["Header"] = "Report Exam Score";
            ViewData["SummaryData"] = examScore;

            return new ViewAsPdf("PreviewPDF")
            {
                FileName = "ReportExamScore_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".pdf",
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = { Left = 0, Right = 0, Top = 0 },
                //ContentDisposition = ContentDisposition.Inline
            };
        }

        [HttpGet]
        public virtual ActionResult PrintExcel(string regNo, string IdentityNo, string UserName, string Email)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/ReportExamScore.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<WP03006Master> examScore = R.GetDataByFilter(1, 1000000, regNo, IdentityNo, UserName, Email,"ikbal@dmcti.co.id");

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["A1"].Value = "Report Exam Score";
                worksheet.Cells["A5"].LoadFromCollection(examScore);
                worksheet.DeleteColumn(1);
                worksheet.Cells["A5:P" + (examScore.Count + 4)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:P" + (examScore.Count + 4)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:P" + (examScore.Count + 4)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:P" + (examScore.Count + 4)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            ViewData["Header"] = "Report Exam Score";
            ViewData["SummaryData"] = examScore;
            var filename = "ReportExamScore-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";

            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        [HttpGet]
        public virtual ActionResult NameCard(int Id)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Replace("NameCard","Certified");

            Employee employee = R.GetEmployeeById(Id.ToString());

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var filename = "KartuNama-" + employee.Name + ".pdf";
            var filePath = Path.Combine(Server.MapPath("/App_Data"), filename);

            ViewData["employee"] = employee;
            ViewData["qrCode"] = BitmapToBytes(qrCodeImage);

            return new ViewAsPdf(employee)
            {
                FileName = filename,
                PageSize = Size.B9,
                PageOrientation = Orientation.Landscape,
                PageMargins = { Left = 0, Right = 0, Top = 0, Bottom = 0 },
                SaveOnServerPath = filePath
            };
        }

        [HttpGet]
        public virtual ActionResult Certified(int Id)
        {
            Employee employee = R.GetEmployeeById(Id.ToString());

            ViewData["employee"] = employee;
            var filename = "Sertifikat-" + employee.Name + ".pdf";
            var filePath = Path.Combine(Server.MapPath("/App_Data"), filename);

            return new ViewAsPdf(employee)
            {
                FileName = filename,
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = { Left = 0, Right = 0, Top = 0, Bottom = 0 },
                SaveOnServerPath = filePath
            };
        }

        [HttpGet]
        public virtual ActionResult NameCardByScore(int Id)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Replace("NameCard", "Certified");

            Employee employee = R.GetEmployeeByScore(Id.ToString());

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var filename = "KartuNama-" + employee.Name + ".pdf";
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\" + filename;

            ViewData["employee"] = employee;
            ViewData["qrCode"] = BitmapToBytes(qrCodeImage);

            return new ViewAsPdf("NameCard")
            {
                FileName = filename,
                PageSize = Size.B9,
                PageOrientation = Orientation.Landscape,
                PageMargins = { Left = 0, Right = 0, Top = 0, Bottom = 0 },
                SaveOnServerPath = filePath
            };
        }

        [HttpGet]
        public virtual ActionResult CertifiedByScore(int Id)
        {
            Employee employee = R.GetEmployeeByScore(Id.ToString());

            ViewData["employee"] = employee;
            var filename = "Sertifikat-" + employee.Name + ".pdf";
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\" + filename;

            return new ViewAsPdf("Certified")
            {
                FileName = filename,
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = { Left = 0, Right = 0, Top = 0, Bottom = 0 },
                SaveOnServerPath = filePath
            };
        }

        private static byte[] BitmapToBytes(System.Drawing.Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}