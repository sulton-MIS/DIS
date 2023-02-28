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
using AI070.Models.DISR170002Master;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AI070.Controllers
{
    public class DISR170002Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR170002Repository R = new DISR170002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;
        string sts;
        string message;
  
        protected override void Startup()
        {
            try
            {
                String Title = "OPMJ Per Tipe";

                ViewData["Title"] = Title;
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
                if (username == null)
                {
                    Response.Redirect("Login");
                }
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
            //return View();
        }

        public ActionResult GetOpmj(
            string MDATE,            
            string DMC_CODE,
            //string GRP,
            string HARI_01,
            string HARI_02,
            string HARI_03,
            string HARI_04,
            string HARI_05,
            string HARI_06,
            string HARI_07,
            string HARI_08,
            string HARI_09,
            string HARI_10,
            string HARI_11,
            string HARI_12,
            string HARI_13,
            string HARI_14,
            string HARI_15,
            string HARI_16,
            string HARI_17,
            string HARI_18,
            string HARI_19,
            string HARI_20,
            string HARI_21,
            string HARI_22,
            string HARI_23,
            string HARI_24,
            string HARI_25,
            string HARI_26,
            string HARI_27,
            string HARI_28,
            string HARI_29,
            string HARI_30,
            string HARI_31
            )
        {
            var data = R.GetOpmj(
                MDATE,                
                DMC_CODE,
                //GRP,
                HARI_01,
                HARI_02,
                HARI_03,
                HARI_04,
                HARI_05,
                HARI_06,
                HARI_07,
                HARI_08,
                HARI_09,
                HARI_10,
                HARI_11,
                HARI_12,
                HARI_13,
                HARI_14,
                HARI_15,
                HARI_16,
                HARI_17,
                HARI_18,
                HARI_19,
                HARI_20,
                HARI_21,
                HARI_22,
                HARI_23,
                HARI_24,
                HARI_25,
                HARI_26,
                HARI_27,
                HARI_28,
                HARI_29,
                HARI_30,
                HARI_31
                );


            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual ActionResult PrintExcel(
            string MDATE,            
            string DMC_CODE,
            //string GRP,
            string HARI_01,
            string HARI_02,
            string HARI_03,
            string HARI_04,
            string HARI_05,
            string HARI_06,
            string HARI_07,
            string HARI_08,
            string HARI_09,
            string HARI_10,
            string HARI_11,
            string HARI_12,
            string HARI_13,
            string HARI_14,
            string HARI_15,
            string HARI_16,
            string HARI_17,
            string HARI_18,
            string HARI_19,
            string HARI_20,
            string HARI_21,
            string HARI_22,
            string HARI_23,
            string HARI_24,
            string HARI_25,
            string HARI_26,
            string HARI_27,
            string HARI_28,
            string HARI_29,
            string HARI_30,
            string HARI_31
            )
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/Data_OPMJ_tipe.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);            

            var data = R.GetOpmj(                
                MDATE,                
                DMC_CODE,
                //GRP,
                HARI_01,
                HARI_02,
                HARI_03,
                HARI_04,
                HARI_05,
                HARI_06,
                HARI_07,
                HARI_08,
                HARI_09,
                HARI_10,
                HARI_11,
                HARI_12,
                HARI_13,
                HARI_14,
                HARI_15,
                HARI_16,
                HARI_17,
                HARI_18,
                HARI_19,
                HARI_20,
                HARI_21,
                HARI_22,
                HARI_23,
                HARI_24,
                HARI_25,
                HARI_26,
                HARI_27,
                HARI_28,
                HARI_29,
                HARI_30,
                HARI_31
                );

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["C3"].Value = "Download Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                worksheet.Cells["B5"].LoadFromCollection(data);
                worksheet.Cells["B5:AK" + (data.Count + 5)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B5:AK" + (data.Count + 5)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B5:AK" + (data.Count + 5)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["B5:AK" + (data.Count + 5)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.DeleteColumn(2);
                worksheet.DeleteColumn(3, 3);
                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            var filename = "Data Opmj_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        //public ActionResult Logout()
        //{
        //    Session["WP_Username"] = null;
        //    return RedirectToAction("Index");
        //}
    }
}
