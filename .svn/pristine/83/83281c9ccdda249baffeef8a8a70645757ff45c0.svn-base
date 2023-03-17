using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP03005;
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

namespace AI070.Controllers.WP03009
{
    public class WP03009Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03005Repository R = new WP03005Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Report Data Participant";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

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

        //[HttpGet]
        //public virtual ActionResult PrintPDF(string employeName, string companyName)
        //{
        //    List<WP03005Master> dataParticipant = R.GetDataParticipant(employeName, companyName).ToList();

        //    ViewData["Header"] = "Data Participant";
        //    ViewData["dataParticipant"] = dataParticipant;

        //    return new ViewAsPdf("PreviewPDF")
        //    {
        //        FileName = "Data Participant" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".pdf",
        //        PageSize = Size.A4,
        //        PageOrientation = Orientation.Landscape,
        //        PageMargins = { Left = 0, Right = 0, Top = 0 },
        //        ContentDisposition = ContentDisposition.Inline
        //    };
        //}

        //[HttpGet]
        //public virtual ActionResult PrintExcel(string employeName, string companyName)
        //{
        //    //or if you use asp.net, get the relative path
        //    string filePath = Server.MapPath("~/Content/TemplateReport/Data_Participant.xlsx");

        //    //create a fileinfo object of an excel file on the disk
        //    FileInfo file = new FileInfo(filePath);

        //    List<WP03005Master> dataParticipant = R.GetDataParticipant(employeName, companyName).ToList();

        //    byte[] FileBytesArray;
        //    //create a new Excel package from the file
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //    using (ExcelPackage excelPackage = new ExcelPackage(file))
        //    {
        //        //create an instance of the the first sheet in the loaded file
        //        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

        //        //add some data
        //        worksheet.Cells["C3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
        //        worksheet.Cells["B5"].LoadFromCollection(dataParticipant);
        //        worksheet.DeleteColumn(2);
        //        worksheet.Cells["C5:P" + (dataParticipant.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells["C5:P" + (dataParticipant.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells["C5:P" + (dataParticipant.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells["C5:P" + (dataParticipant.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        worksheet.DeleteColumn(16);
        //        //save the changes
        //        //excelPackage.Save();
        //        FileBytesArray = excelPackage.GetAsByteArray();
        //    }

        //    var filename = "Data Participant_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
        //    return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        //}
    }
}