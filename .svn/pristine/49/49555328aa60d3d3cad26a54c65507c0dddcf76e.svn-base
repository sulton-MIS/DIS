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

namespace AI070.Controllers.WP03010
{
    public class WP03010Controller : PageController
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
                Settings.Title = "Report Score";
                ViewData["Title"] = Settings.Title;
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        [HttpGet]
        public virtual ActionResult PrintPDF(string regNo, string examSubject)
        {
            List<WP03006Master> examScore = R.GetDataByFilter(1, 1000000, regNo, "", "", "","ikbal@dmcti.co.id");

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
        public virtual ActionResult PrintExcel(string regNo, string examSubject)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/ReportExamScore.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<WP03006Master> examScore = R.GetDataByFilter(1, 1000000, regNo, "", "", "", "ikbal@dmcti.co.id");

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
                worksheet.Cells["A5:M" + (examScore.Count + 4)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:M" + (examScore.Count + 4)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:M" + (examScore.Count + 4)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:M" + (examScore.Count + 4)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            ViewData["Header"] = "Report Exam Score";
            ViewData["SummaryData"] = examScore;
            var filename = "ReportExamScore-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";

            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

    }
}