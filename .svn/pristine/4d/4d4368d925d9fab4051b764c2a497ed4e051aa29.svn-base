using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP03012;
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

namespace AI070.Controllers.WP03012
{
    public class WP03012Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03012Repository R = new WP03012Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE; 

        protected override void Startup()
        {
            try
            {
                ViewBag.ID_Employee = Session["WP_ID_TB_M_EMPLOYEE"];
                Settings.Title = "Data Score";
                ViewData["Title"] = Settings.Title;
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        [HttpGet]
        public virtual ActionResult GetSummmaryData(
            int start, 
            int display, 
            string RegNo, 
            string IdentityNo, 
            string UserName, 
            string Email, 
            int ID_Employee
            )
        {
            List<WP03012Master> examScore = R.GetDataByFilter(start, display, RegNo, IdentityNo, UserName, Email, ID_Employee);

            PagingModel_WP03012 pg = new PagingModel_WP03012(R.CountData(RegNo, IdentityNo, UserName, Email, ID_Employee, true), start, display);

            ViewData["ExamSubject"] = R.GetExamSubject();
            ViewData["PagingWP03012"] = pg;
            ViewData["Company"] = R.GetCompany();
            ViewBag.ID_Employee = Session["WP_ID_TB_M_EMPLOYEE"];
            ViewData["Title"] = "Data Score";
            ViewData["SummaryData"] = examScore;

            return PartialView("Datagrid_SummaryData");
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