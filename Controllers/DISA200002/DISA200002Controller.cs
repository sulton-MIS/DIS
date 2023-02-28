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
using AI070.Models.DISA200002Master;
using System.Security.Cryptography;
using System.Text;
using Rotativa.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Printing;
//using Neodynamic.SDK.Web;

namespace AI070.Controllers
{
    public class DISA200002Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA200002Repository R = new DISA200002Repository();
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
                Settings.Title = "Find Material";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult MoveFile()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                saveFile = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                resultFilePath = Path.Combine("~/Content/Upload/Foto/ManajementAsset", Request.Form["Name"] + ".PNG");
                file.SaveAs(Server.MapPath(resultFilePath));
            }
            var MSG = "Nice";
            return Json(new { MSG });
        }


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string JENIS_MAT, string CODE, string NAME, string MAINBUMO, string HOKAN, string ZAIK)
        {
            //Buat Paging//
            PagingModel_DISA200002 pg = new PagingModel_DISA200002(R.getCountDISA200002(DATA_ID, JENIS_MAT, CODE, NAME, MAINBUMO, HOKAN, ZAIK), start, display);

            //Munculin Data ke Grid//
            List<DISA200002Master> List = R.getDataDISA200002(pg.StartData, pg.EndData, JENIS_MAT, CODE, NAME, MAINBUMO, HOKAN, ZAIK).ToList();
            ViewData["DataDISA200002"] = List;
            ViewData["PagingDISA200002"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Get Data Material
        public ActionResult GetMaterial(
            string JENIS_MAT, string CODE, string NAME, string MAINBUMO
            )
        {
        var data = R.GetMaterial(
            JENIS_MAT,
            CODE,
            NAME,
            MAINBUMO
            );

            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
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
                //ViewData["COMPANY"] = R.getCompany();
                //ViewData["no_urut"] = "TESTING";
                //ViewData["no_urut"] = R.getNo_Urutan();
                //ViewData["nama_lokasi"] = R.getLokasi();
                ViewData["MAINBUMO"] = R.getMainBumo();
                ViewData["HOKAN"] = R.getHokan();
                ViewData["EXECUTOR"] = R.getExecutor();
                //ViewData["IDENTITY"] = R.getIdentity();
                //ViewData["SECTION"] = R.getSection("TMMIN");
                //ViewData["PIC"] = R.getPIC();
                //ViewData["Division"] = R.getDivision();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region PrintExcel
        [HttpGet]
        public virtual ActionResult PrintExcel(
            string CODE, string NAME, string ZAIK, string UOM, string LOTTO, string MAINBUMO,
            string ADM_TPICS, string OPT_PACKING, string OPT_SCRIBE, string OPT_PRESS
        )
        {
            string filePath = "";
            filePath = Server.MapPath("~/Content/TemplateReport/label_material.xlsx");

            //or if you use asp.net, get the relative path
            //string filePath = "";
            //if (ID_SEISAN.Contains("-010-") || ID_SEISAN.Contains("-012-") || ID_SEISAN.Contains("-014-") ||
            //    ID_SEISAN.Contains("-110-") || ID_SEISAN.Contains("-111-") || ID_SEISAN.Contains("-115-") ||
            //    ID_SEISAN.Contains("-114-"))
            //{
            //    filePath = Server.MapPath("~/Content/TemplateReport/tail.xlsx");
            //}
            //else
            //{
            //    filePath = Server.MapPath("~/Content/TemplateReport/film_glass.xlsx");
            //}

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //add some data
                worksheet.Cells["B1"].Value = NAME;
                worksheet.Cells["B3"].Value = CODE;
                worksheet.Cells["B4"].Value = LOTTO;
                worksheet.Cells["B5"].Value = ADM_TPICS;
                worksheet.Cells["B6"].Value = OPT_PRESS;
                worksheet.Cells["B7"].Value = OPT_PACKING;
                worksheet.Cells["D5"].Value = MAINBUMO;
                worksheet.Cells["D6"].Value = OPT_SCRIBE;
                worksheet.Cells["D7"].Value = ZAIK + "" + UOM;

                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();

            }

            var filename = "Label Material_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        #endregion

    }
}