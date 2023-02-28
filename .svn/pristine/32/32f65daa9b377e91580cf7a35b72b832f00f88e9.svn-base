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

namespace AI070.Controllers.WP03005
{
    public class WP03005Controller : PageController
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
                Settings.Title = "Data Participant";
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
                
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        [HttpGet]
        public virtual ActionResult GetDataParticipant(int start, int display, string RegNo, string IdentityType, string IdentityNo, string UserName, string Email)
        {
            GetDataHeader();
            List<WP03005Master> dataParticipant = R.GetDataParticipant(start, display, RegNo, IdentityType, IdentityNo, UserName, Email).ToList();
            ViewData["Title"] = "Data Participant";
            ViewData["dataParticipant"] = dataParticipant;

            ViewBag.RegNo = RegNo;
            ViewBag.IdentityType = IdentityType;
            ViewBag.IdentityNo = IdentityNo;
            ViewBag.UserName = UserName;
            ViewBag.Email = Email;

            return PartialView("Datagrid_SummaryData");
        }

        [HttpGet]
        public virtual ActionResult GetDataParticipant_detailExam(string ID)
        {
            List<WP03005DetailScore> GetDataParticipant_DetailExam = R.GetDataParticipant_DetailExam_ById(ID).ToList();
            if(GetDataParticipant_DetailExam.Count == 0)
            {
                ViewData["Title"] = " Detail Exam Score";
                ViewData["RegNo"] = " -- Belum ikut ujian -- " ;
                ViewData["Name"] = " ";
                ViewData["DataParticipant_DetailExam"] = GetDataParticipant_DetailExam;
            }
            else
            {
                ViewData["Title"] = " Detail Exam Score";
                ViewData["RegNo"] = " Reg. Number : " + GetDataParticipant_DetailExam.FirstOrDefault().REG_NO.ToString() ;
                ViewData["Name"] = " Name : " + GetDataParticipant_DetailExam.FirstOrDefault().NAME.ToString();
                ViewData["DataParticipant_DetailExam"] = GetDataParticipant_DetailExam;
            }
            return PartialView("Datagrid_DetailData");
        }

        [HttpGet]
        public virtual ActionResult PrintPDF(string RegNo, string IdentityType, string IdentityNo, string UserName, string Email)
        {
            List<WP03005Master> dataParticipant = R.GetDataParticipant(1, 10000000, RegNo, IdentityType, IdentityNo, UserName, Email).ToList();

            ViewData["Header"] = "Data Participant";
            ViewData["Download_date"] = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
            ViewData["dataParticipant"] = dataParticipant;

            return new ViewAsPdf("PreviewPDF")
            {
                FileName = "Data Participant" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".pdf",
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = { Left = 0, Right = 0, Top = 0 },
                //ContentDisposition = ContentDisposition.Inline
            };
        }

        [HttpGet]
        public virtual ActionResult PrintExcel(string RegNo, string IdentityType, string IdentityNo, string UserName, string Email)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Data_Participant.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            List<WP03005Master> dataParticipant = R.GetDataParticipant(1, 10000000, RegNo, IdentityType, IdentityNo, UserName, Email).ToList();

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["C3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B5"].LoadFromCollection(dataParticipant);
                worksheet.Cells["B5:O" + (dataParticipant.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B5:O" + (dataParticipant.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B5:O" + (dataParticipant.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B5:O" + (dataParticipant.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.DeleteColumn(2);
                worksheet.DeleteColumn(15,23);
                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data Participant_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
    }
}