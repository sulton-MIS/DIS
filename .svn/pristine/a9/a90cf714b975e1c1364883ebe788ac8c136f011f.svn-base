using AI070.Models;
using AI070.Models.Shared;
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
using AI070.Models.WP03011;

namespace AI070.Controllers.WP03011
{
    public class WP03011Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03011Repository R = new WP03011Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Print Certified";
                ViewData["Title"] = Settings.Title;
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
                //GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        [HttpGet]
        public virtual ActionResult NameCardByScore(string regNumber, string type)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Replace("NameCard", "Certified");

            Employee employee = R.GetEmployeeByRegNumber(regNumber);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var filename = "KartuNama-" + employee.Name + ".pdf";
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\" + filename;

            ViewData["employee"] = employee;
            ViewData["qrCode"] = BitmapToBytes(qrCodeImage);

            //if(type == "pdf")
            //{
            //    return new ViewAsPdf("NameCard")
            //    {
            //        FileName = filename,
            //        PageSize = Size.B9,
            //        PageOrientation = Orientation.Portrait,
            //        PageMargins = { Left = 0, Right = 0, Top = 0, Bottom = 0 },
            //        SaveOnServerPath = filePath
            //    };
            //}

            return View("NameCard");
        }

        [HttpGet]
        public virtual ActionResult CertifiedByScore(string regNumber)
        {
            //return Json(new { regNumber }, JsonRequestBehavior.AllowGet);
            var employee = R.GetEmployeeByRegNumber(regNumber);
            var Message = new Object();
            string url = "";
            try
            {
                
                if(employee != null)
                {
                    ViewData["employee"] = employee;
                    url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Replace("NameCard", "Certified");
                    var filename = "Sertifikat-" + employee.Name + ".pdf";
                    var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\" + filename;
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    ViewData["qrCode"] = BitmapToBytes(qrCodeImage);

                    return new ViewAsPdf("Certified")
                    {
                        FileName = filename,
                        PageSize = Size.A4,
                        PageOrientation = Orientation.Landscape,
                        PageMargins = { Left = 0, Right = 0, Top = 0, Bottom = 0 }
                    };
                    //return View("Certified");
                }
                else
                {
                    Message = "Data Not Found";
                }
            }
            catch (Exception e)
            {
                Message = e.Message.ToString();
                
            }
            return Json(new { Message, url }, JsonRequestBehavior.AllowGet);

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