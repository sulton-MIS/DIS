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
using AI070.Models.DISA090002Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISA090002Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA090002Repository R = new DISA090002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Distribusi Denki";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string NAMA_MESIN, string PAGE_VIEWER)
        {
            //Buat Paging//
            PagingModel_DISA090002 pg = new PagingModel_DISA090002(R.getCountDISA090002(DATA_ID, NAMA_MESIN), start, display);

            //Munculin Data ke Grid//
            List<DISA090002Master> List = R.getDataDISA090002(pg.StartData, pg.EndData, NAMA_MESIN).ToList();
            ViewData["DataDISA090002"] = List;
            ViewData["PagingDISA090002"] = pg;
            var page_control = "";
            if (PAGE_VIEWER == "DistribusiData")
            {
                page_control = "Datagrid_Data";
            }
            else if(PAGE_VIEWER == "Page_SettingDB")
            {
                page_control = "Setting_Database/Datagrid_Data";
            }
            return PartialView(page_control);
        }
        #endregion


        public ActionResult MoveFileNew()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            string sts = "true";
            string message = "";
            string nama_mesin = "";
            string nama_mesin_error = "";

            var status = "";

            //Get User Login
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            var USERNAME = username;

            //Get Date
            DateTime CREATED_DATE = DateTime.Now;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                var mesin = Request.Form["Mesin"];
                var nama_file = Request.Form["Name"];
                var DATA = Request.Form["Var"];

                char[] charsToTrim = { '"'};
                string DATA_REPLACE = DATA.Trim(charsToTrim);

                try
                {
                    var Datas = DATA_REPLACE.Split(',');
                    for (int n = 0; n < Datas.Count(); n++)
                    {
                        nama_mesin = Datas[n];

                        if (Datas[n] != "")
                        {
                            string PathDenki = R.getPathMesin(Datas[n]);
                            if(PathDenki != null)
                            {
                                resultFilePath = System.IO.Path.Combine(@"" + PathDenki, nama_file);
                                file.SaveAs(resultFilePath);

                                ////resultFilePath = @"" + PathDenki + nama_file;
                                //resultFilePath = Path.Combine(@"" + PathDenki, nama_file);
                                //file.SaveAs(resultFilePath);
                                status = "Success";
                                message = "Data Has Been Distributed Successfully!";

                                var Exec = DISA090002Repository.Create_History( nama_mesin, status, message, USERNAME, CREATED_DATE);

                            }
                            
                        }
                    }
                }
                catch (Exception M)
                {
                    nama_mesin_error = nama_mesin;
                    status = "Failed";

                    sts = "false";
                    //message = "Failed To Distribute Data.";
                    message = M.Message.ToString();

                    if (message.Contains("The network name cannot be found."))
                    {
                        message = "Alamat Path Tidak Ditemukan.";
                    }


                    var Exec = DISA090002Repository.Create_History(nama_mesin_error, status, message, USERNAME, CREATED_DATE);

                }

                
            }
            var MSG = "Nice";
            return Json(new { MSG, message, sts, nama_mesin_error });
        }

        //public ActionResult MoveFile()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        //{
        //    var f = Request.Files;
        //    var saveFile = "";
        //    var resultFilePath = "";
        //    string message = "";
        //    for (int i = 0; i < Request.Files.Count; i++)
        //    {
        //        var file = Request.Files[i];
        //        var filename = Path.GetExtension(file.FileName);
        //        var mesin = Request.Form["Mesin"];
        //        var nama_file = Request.Form["Name"];

        //        if (mesin == "denki-1")
        //        {
        //            //old method
        //            //saveFile = Path.Combine(Server.MapPath("~/Content/Upload/Test/Denki1"), filename);
        //            //resultFilePath = Path.Combine("~/Content/Upload/Test/Denki1", Request.Form["Name"]);
        //            //file.SaveAs(Server.MapPath(resultFilePath));

        //            //New Method
        //            resultFilePath = @"\\192.168.2.53\Touch_Intl_New\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-2")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.55\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-3")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.54\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-4")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.56\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-5")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.57\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-6")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.60\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-7")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.61\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-8")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.62\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-9")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.63\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-10")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.64\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-11")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.65\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-12")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.66\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //        if (mesin == "denki-13")
        //        {
        //            //New Method
        //            resultFilePath = @"\\192.168.2.67\Touch_Intl\" + nama_file;
        //            file.SaveAs(resultFilePath);
        //        }
        //    }
        //    var MSG = "Nice";
        //    return Json(new { MSG, message });
        //}



        //----------------------------------------------------------PAGE SETTING DATABASE-------------------------------------------

        #region PAGE SETTING DATABASE

        #region Hyperlink Page Setting DB
        public ActionResult PAGE_SETTING_DB()
        {
            GetDataHeader();
            Settings.Title = "Setting Lokasi Database";
            ViewData["Title1"] = Settings.Title;

            return View("Setting_Database/Page_Setting_Database");
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

        #region Add New
        public ActionResult ADD_NEW(
            string NAMA_MESIN,
            string PATH_MESIN
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);

            //Get User Login
            var USERNAME = username;

            //Get Datetime
            DateTime CREATED_DATE = DateTime.Now;

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA090002Repository.Create(
                     NAMA_MESIN,
                     PATH_MESIN,
                     USERNAME,
                     CREATED_DATE
                    );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Setting Database Denki", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Setting Database Denki", "", "");
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

        #region Update Data
        public ActionResult Update_Data(string NAMA_MESIN, string PATH_MESIN, string ID)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

                //Get Username
                var USERNAME = username;
                DateTime UPDATED_DATE = DateTime.Now;

                var EXEC = R.Update_Data(
                    ID,
                    NAMA_MESIN,
                    PATH_MESIN,
                    USERNAME,
                    UPDATED_DATE
                    );
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Setting Database Denki", "", "");
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
                var res = M.get_default_message("MWP002", "Master Setting Database Denki", "", "");
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

        #endregion

        //----------------------------------------------------------PAGE HISTORY DISTRIBUSI-----------------------------------------
        #region PAGE HISTORY DISTRIBUSI

        #region Hyperlink Page History Distribusi
        public ActionResult PAGE_HISTORY_DISTRIBUSI()
        {
            GetDataHeader();
            Settings.Title = "History Distribusi Denki";
            ViewData["Title1"] = Settings.Title;

            return View("History_Distribusi/Page_History_Distribusi");
        }
        #endregion  

        #region Search Data History
        public ActionResult Search_Data_History(int start, int display, string DATA_ID, string NAMA_MESIN, string STATUS, string CREATED_BY, string CREATED_DATE_FROM, string CREATED_DATE_TO)
        {
            //Buat Paging//
            PagingModel_DISA090002 pg = new PagingModel_DISA090002(R.getCountDataHistory(DATA_ID, NAMA_MESIN, STATUS, CREATED_BY, CREATED_DATE_FROM, CREATED_DATE_TO), start, display);

            //Munculin Data ke Grid//
            List<DISA090002_History_Distribusi> List = R.getDataHistory(pg.StartData, pg.EndData, NAMA_MESIN, STATUS, CREATED_BY, CREATED_DATE_FROM, CREATED_DATE_TO).ToList();
            ViewData["DataDISA090002"] = List;
            ViewData["PagingDISA090002"] = pg;

            return PartialView("History_Distribusi/Datagrid_Data");
        }
        #endregion

        #endregion
    }
}