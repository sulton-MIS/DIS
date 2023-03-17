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
using AI070.Models.DISR190002Master;
using System.Security.Cryptography;
using System.Text;
using Rotativa.Options;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Printing;
//using Neodynamic.SDK.Web;

namespace AI070.Controllers
{
    public class DISR190002Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR190002Repository R = new DISR190002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Label Chukan";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ID_SEISAN, string ID_HINMOKU)
        {
            //Buat Paging//
            PagingModel_DISR190002 pg = new PagingModel_DISR190002(R.getCountDISR190002(DATA_ID, ID_SEISAN, ID_HINMOKU), start, display);

            //Munculin Data ke Grid//
            List<DISR190002Master> List = R.getDataDISR190002(pg.StartData, pg.EndData, ID_SEISAN, ID_HINMOKU).ToList();
            ViewData["DataDISR190002"] = List;
            ViewData["PagingDISR190002"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion    
        
        #region Search Data Item Code
        public ActionResult Search_Data_ItemCode(int start, int display, string DATA_ID, string CODE)
        {
            //Buat Paging//
            PagingModel_DISR190002 pg = new PagingModel_DISR190002(R.getCountDISR190002_ItemCode(DATA_ID, CODE), start, display);

            //Munculin Data ke Grid//
            List<DISR190002Master> List = R.getDataDISR190002_ItemCode(pg.StartData, pg.EndData, CODE).ToList();
            ViewData["DataDISR190002"] = List;
            ViewData["PagingDISR190002"] = pg;
            return PartialView("Datagrid_Data_Similar", pg.CountData);
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

        //#region Add New        
        //public ActionResult ADD_NEW(
        //    DateTime target_date,
        //    decimal target_amount,
        //    decimal target_print,
        //    decimal target_amount_jam_ke_1,
        //    decimal target_amount_jam_ke_2,
        //    decimal target_amount_jam_ke_3,
        //    decimal targer_amount_jam_ke_4,
        //    decimal target_amount_jam_ke_5,
        //    decimal target_amount_jam_ke_6,
        //    decimal target_amount_jam_ke_7,
        //    decimal target_amount_jam_ke_8,
        //    decimal target_amount_jam_ke_9,
        //    decimal terget_amount_jam_ke_10,
        //    decimal target_amount_jam_ke_11,
        //    decimal target_amount_jam_ke_12,
        //    decimal target_amount_jam_ke_13,
        //    decimal target_amount_jam_ke_14,
        //    decimal target_amount_jam_ke_15_16_istirahat,
        //    decimal target_amount_jam_ke_17,
        //    decimal target_amount_jam_ke_18,
        //    decimal target_amount_jam_ke_19,
        //    decimal target_amount_jam_ke_20,
        //    decimal target_amount_jam_ke_21,
        //    decimal target_amount_jam_ke_22
        //    )
        //{
        //    string sts = null;
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    //string pass = EncryptPassword(PASSWORD);
        //    try
        //    {
        //        string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
        //        var Exec = DISR190002Repository.Create(
        //             target_date,
        //             target_amount,
        //             target_amount_jam_ke_1,
        //             target_amount_jam_ke_2,
        //             target_amount_jam_ke_3,
        //             targer_amount_jam_ke_4,
        //             target_amount_jam_ke_5,
        //             target_amount_jam_ke_6,
        //             target_amount_jam_ke_7,
        //             target_amount_jam_ke_8,
        //             target_amount_jam_ke_9,
        //             terget_amount_jam_ke_10,
        //             target_amount_jam_ke_11,
        //             target_amount_jam_ke_12,
        //             target_amount_jam_ke_13,
        //             target_amount_jam_ke_14,
        //             target_amount_jam_ke_15_16_istirahat,
        //             target_amount_jam_ke_17,
        //             target_amount_jam_ke_18,
        //             target_amount_jam_ke_19,
        //             target_amount_jam_ke_20,
        //             target_amount_jam_ke_21,
        //             target_amount_jam_ke_22,
        //            username);
        //        sts = Exec[0].STACK;

        //        if (Exec[0].LINE_STS == "DUPLICATE")
        //        {
        //            var res = M.get_default_message("MWP004", "Master Qty Amount Target", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else if (Exec[0].STACK == "TRUE")
        //        {
        //            var res = M.get_default_message("MWP001", "Master Qty Amount Target", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else
        //        {
        //            message = Exec[0].LINE_STS;
        //        }
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        //#region Update Data
        //public ActionResult Update_Data(string DATA)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    var message = new object();
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    try
        //    {
        //        string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
        //        var Datas = DATA.Split(',');
        //        string ID = Datas[0];
        //        DateTime target_date = Datas[1];
        //        decimal target_amount = Datas[2];
        //        decimal target_print = Datas[3];
        //        decimal target_amount_jam_ke_1 = Datas[4];
        //        decimal target_amount_jam_ke_2 = Datas[5];
        //        decimal target_amount_jam_ke_3 = Datas[6];
        //        decimal targer_amount_jam_ke_4 = Datas[7];
        //        decimal target_amount_jam_ke_5 = Datas[8];
        //        decimal target_amount_jam_ke_6 = Datas[9];
        //        decimal target_amount_jam_ke_7 = Datas[10];
        //        decimal target_amount_jam_ke_8 = Datas[11];
        //        decimal target_amount_jam_ke_9 = Datas[12];
        //        decimal terget_amount_jam_ke_10 = Datas[13];
        //        decimal target_amount_jam_ke_11 = Datas[14];
        //        decimal target_amount_jam_ke_12 = Datas[15];
        //        decimal target_amount_jam_ke_13 = Datas[16];
        //        decimal target_amount_jam_ke_14 = Datas[17];
        //        decimal target_amount_jam_ke_15_16_istirahat = Datas[18];
        //        decimal target_amount_jam_ke_17 = Datas[19];
        //        decimal target_amount_jam_ke_18 = Datas[20];
        //        decimal target_amount_jam_ke_19 = Datas[21];
        //        decimal target_amount_jam_ke_20 = Datas[22];
        //        decimal target_amount_jam_ke_21 = Datas[23];
        //        decimal target_amount_jam_ke_22 = Datas[25];

        //        string STATUS = "1";
        //        var EXEC = R.Update_Data(
        //            ID,
        //            target_date,
        //            target_amount,
        //            target_amount_jam_ke_1,
        //            target_amount_jam_ke_2,
        //            target_amount_jam_ke_3,
        //            targer_amount_jam_ke_4,
        //            target_amount_jam_ke_5,
        //            target_amount_jam_ke_6,
        //            target_amount_jam_ke_7,
        //            target_amount_jam_ke_8,
        //            target_amount_jam_ke_9,
        //            terget_amount_jam_ke_10,
        //            target_amount_jam_ke_11,
        //            target_amount_jam_ke_12,
        //            target_amount_jam_ke_13,
        //            target_amount_jam_ke_14,
        //            target_amount_jam_ke_15_16_istirahat,
        //            target_amount_jam_ke_17,
        //            target_amount_jam_ke_18,
        //            target_amount_jam_ke_19,
        //            target_amount_jam_ke_20,
        //            target_amount_jam_ke_21,
        //            target_amount_jam_ke_22,
        //            STATUS,
        //            username);
        //        sts = EXEC[0].STACK;
        //        if (EXEC[0].STACK == "TRUE")
        //        {
        //            var res = M.get_default_message("MWP003", "Master Qty Amount Target", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else
        //        {
        //            message = EXEC[0].LINE_STS;
        //        }


        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        //#region Delete Data
        //public ActionResult Delete_Data(string DATA)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
        //    try
        //    {
        //        var Datas = DATA.Split(',');
        //        for (int i = 0; i < Datas.Count(); i++)
        //        {
        //            if (Datas[i] != "")
        //            {
        //                string DELETE = R.Delete_Data(Datas[i]);
        //                DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
        //            }
        //        }

        //        sts = "TRUE";
        //        var res = M.get_default_message("MWP002", "Master Operator", "", "");
        //        message = res[0].MSG_TEXT;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

           
        public virtual ActionResult PrintOut(
            string ID_SEISAN, string ID_HINMOKU, string OTHER_LOTNO, string LOT_IHOUSE,
            string QTY, string ADM_IT, string SIMILAR, string OPT_PRESS,
            string OPT_LAM, string TINTA_DOT, string QTY_PRINT,
            string GLASS_BUWON, string AFTER_LAMINATE,
            string PENGGANTI1, string PENGGANTI2, string TAMBAHAN1, string TAMBAHAN2, string TAMBAHAN3
        )
        {
            //or if you use asp.net, get the relative path
            string filePath = "";
            if (ID_SEISAN.Contains("-010-") || ID_SEISAN.Contains("-012-") || ID_SEISAN.Contains("-014-") ||
                ID_SEISAN.Contains("-110-") || ID_SEISAN.Contains("-111-") || ID_SEISAN.Contains("-115-") ||
                ID_SEISAN.Contains("-114-"))
            {
                filePath = Server.MapPath("~/Content/TemplateReport/tail.xlsx");
            }
            else
            {
                filePath = Server.MapPath("~/Content/TemplateReport/film_glass.xlsx");
            }



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
                worksheet.Cells["B2"].Value = ID_HINMOKU;
                worksheet.Cells["B4"].Value = ID_SEISAN;
                worksheet.Cells["B5"].Value = ADM_IT;
                worksheet.Cells["B6"].Value = OPT_PRESS;
                worksheet.Cells["B8"].Value = OPT_LAM;
                worksheet.Cells["B9"].Value = TINTA_DOT;
                worksheet.Cells["D5"].Value = OTHER_LOTNO;
                worksheet.Cells["D6"].Value = QTY;
                worksheet.Cells["F2"].Value = GLASS_BUWON;
                worksheet.Cells["C8"].Value = AFTER_LAMINATE;

                //Lot Ihouse
                if (LOT_IHOUSE != "")
                {
                    worksheet.Cells["E5"].Value = LOT_IHOUSE;

                    //Similar
                    if (SIMILAR != "")
                    {
                        worksheet.Cells["E6"].Value = SIMILAR;
                    }
                    else
                    {
                        worksheet.Cells["E6"].Value = "";
                    }
                }
                else
                {
                    //Similar
                    if (SIMILAR != "")
                    {
                        worksheet.Cells["E5"].Value = SIMILAR;
                    }
                    else
                    {
                        worksheet.Cells["E5"].Value = "";
                    }
                }


                //Pengganti
                var PENGGANTI = PENGGANTI1 + "/" + PENGGANTI2;

                if (PENGGANTI != "")
                {
                    worksheet.Cells["E8"].Value = PENGGANTI;
                }
                else
                {
                    worksheet.Cells["E8"].Value = "";
                }


                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();

            }

            
            var filename = "Label Chukan_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #region PrintExcel
        [HttpGet]
        public virtual ActionResult PrintExcel(
            string ID_SEISAN, string ID_HINMOKU, string OTHER_LOTNO, string LOT_IHOUSE,
            string QTY, string ADM_IT, string SIMILAR, string OPT_PRESS,
            string OPT_LAM, string TINTA_DOT, string QTY_PRINT,
            string GLASS_BUWON, string AFTER_LAMINATE, 
            string PENGGANTI1, string PENGGANTI2, string TAMBAHAN1, string TAMBAHAN2, string TAMBAHAN3
        )
        {
            //Looping print
            //Int32 jml_print = Int32.Parse(QTY_PRINT);
            //Int32 i = 1;
            //while (i <= jml_print)
            //{
            //    PrintOut(ID_SEISAN, ID_HINMOKU, OTHER_LOTNO, LOT_IHOUSE, QTY, ADM_IT, SIMILAR, OPT_PRESS, OPT_LAM, TINTA_DOT, QTY_PRINT, GLASS_BUWON, AFTER_LAMINATE, PENGGANTI1, PENGGANTI2, TAMBAHAN1, TAMBAHAN2, TAMBAHAN3);
            //    i++;
            //}

            //or if you use asp.net, get the relative path
            string filePath = "";
            if (ID_SEISAN.Contains("-010-") || ID_SEISAN.Contains("-012-") || ID_SEISAN.Contains("-014-") ||
                ID_SEISAN.Contains("-110-") || ID_SEISAN.Contains("-111-") || ID_SEISAN.Contains("-115-") ||
                ID_SEISAN.Contains("-114-"))
            {
                filePath = Server.MapPath("~/Content/TemplateReport/tail.xlsx");
            }
            else
            {
                filePath = Server.MapPath("~/Content/TemplateReport/film_glass.xlsx");
            }

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
                worksheet.Cells["B2"].Value = ID_HINMOKU;
                worksheet.Cells["B4"].Value = ID_SEISAN;
                worksheet.Cells["B5"].Value = ADM_IT;
                worksheet.Cells["B6"].Value = OPT_PRESS;
                worksheet.Cells["B8"].Value = OPT_LAM;
                worksheet.Cells["B9"].Value = TINTA_DOT;
                worksheet.Cells["D5"].Value = OTHER_LOTNO;
                worksheet.Cells["D6"].Value = QTY;
                worksheet.Cells["F2"].Value = GLASS_BUWON;
                worksheet.Cells["C8"].Value = AFTER_LAMINATE;

                //Lot Ihouse
                if (LOT_IHOUSE != "")
                {
                    worksheet.Cells["E5"].Value = LOT_IHOUSE;

                    //Similar
                    if (SIMILAR != "")
                    {
                        worksheet.Cells["E6"].Value = SIMILAR;
                    }
                    else
                    {
                        worksheet.Cells["E6"].Value = "";
                    }
                }
                else
                {
                    //Similar
                    if (SIMILAR != "")
                    {
                        worksheet.Cells["E5"].Value = SIMILAR;
                    }
                    else
                    {
                        worksheet.Cells["E5"].Value = "";
                    }
                }


                //Pengganti
                var PENGGANTI = PENGGANTI1 + "/" + PENGGANTI2;

                if (PENGGANTI != "")
                {
                    worksheet.Cells["E8"].Value = PENGGANTI;
                }
                else
                {
                    worksheet.Cells["E8"].Value = "1/1";
                }


                //save the changes
                //excelPackage.Save();
                FileBytesArray = excelPackage.GetAsByteArray();

            }

            var filename = "Label Chukan_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        #endregion
    }
}