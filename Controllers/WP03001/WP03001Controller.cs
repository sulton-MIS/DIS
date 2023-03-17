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
using AI070.Models.WP03001Master;
using System.Text.RegularExpressions;

namespace AI070.Controllers
{
    public class WP03001Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03001Repository R = new WP03001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Question Bank";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

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
                ViewData["CATEGORY"] = R.getCategory();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(
                                        int start,
                                        int display,
                                        string DATA_ID,
                                        string EXECUTION_TIME,
                                        string TIME_UNIT_CRITERIA,
                                        string STATUS_ACTIVE,
                                        string QUESTION,
                                        string ANSWER_KEY)
        {
            //Buat Paging//
            PagingModel_WP03001 pg = new PagingModel_WP03001(R.getCountWP03001(
                                                                                DATA_ID,
                                                                                EXECUTION_TIME,
                                                                                TIME_UNIT_CRITERIA,
                                                                                STATUS_ACTIVE,
                                                                                QUESTION,
                                                                                ANSWER_KEY),
                                                                start, display);

            //Munculin Data ke Grid//
            List<WP03001Master> List = R.getDataWP03001(pg.StartData, pg.EndData, QUESTION, ANSWER_KEY).ToList();
            ViewData["DataWP03001"] = List;
            ViewData["PagingWP03001"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(
            string CATEGORY,
            string QUESTION,
            string ANSWER_CHOICE_A,
            string ANSWER_CHOICE_B,
            string ANSWER_CHOICE_C,
            string ANSWER_CHOICE_D,
            string ANSWER_CHOICE_E,
            string ANSWER_KEY,
            string IMAGE_PATH
            )
        {

            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP03001Repository.Create(
                                                        RemoveHTMLTags(CATEGORY),
                                                        RemoveHTMLTags(QUESTION),
                                                        RemoveHTMLTags(ANSWER_CHOICE_A),
                                                        RemoveHTMLTags(ANSWER_CHOICE_B),
                                                        RemoveHTMLTags(ANSWER_CHOICE_C),
                                                        RemoveHTMLTags(ANSWER_CHOICE_D),
                                                        RemoveHTMLTags(ANSWER_CHOICE_E),
                                                        RemoveHTMLTags(ANSWER_KEY),
                                                        IMAGE_PATH,
                                                        username);
                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                string fname = "";
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];


                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  

                        string simpan = Path.Combine(Server.MapPath("~/Content/Upload/QuestionBankImage/"), "Image-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".jpg");
                        file.SaveAs(simpan);
                    }
                    // Returns message that successfully uploaded  
                    return Json("../Content/Upload/QuestionBankImage/Image-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".jpg");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        //public  string StripHTML(string input)
        //{
        //    return Regex.Replace(input, "<.*?>", String.Empty);
        //}

        public  string RemoveHTMLTags(string value)
        {
            Regex regex = new Regex("\\<[^\\>]*\\>");
            value = regex.Replace(value, String.Empty);
            return value;
        }

        #region Update Data
        [ValidateInput(false)]
        [HttpPut]
        public ActionResult Edit(string DATA)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                string dataParam = DATA;

                var Datas = dataParam.Split(',');
                string ID = Datas[0];
                string QUESTION = Datas[1];
                string Category = Datas[2];
                string ANSWER_CHOICE_A = Datas[3];
                string ANSWER_CHOICE_B = Datas[4];
                string ANSWER_CHOICE_C = Datas[5];
                string ANSWER_CHOICE_D = Datas[6];
                string ANSWER_CHOICE_E = Datas[7];
                string ANSWER_KEY = Datas[8];
                string IMAGE = Datas[9];
                var EXEC = R.Update_Data(
                                            ID,
                                            QUESTION,
                                            Category,
                                            ANSWER_CHOICE_A,
                                            ANSWER_CHOICE_B,
                                            ANSWER_CHOICE_C,
                                            ANSWER_CHOICE_D,
                                            ANSWER_CHOICE_E,
                                            ANSWER_KEY,
                                            IMAGE,
                                            username);
                sts = EXEC[0].STACK;
                message = EXEC[0].LINE_STS;

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

            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        R.Delete_Data(Datas[i]);
                    }
                }

                sts = "TRUE";
                message = "Data has been successfully Deleted";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AddEdit
        public virtual ActionResult AddEdit(int id)
        {
            try
            {
                Settings.Title = "Question Bank";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }

            //if (id != 0)
            //{
            //    ViewData.Model = Data.User.GetUserByID(id);
            //}
            //else
            //{
            //    ViewData.Model = new Data.User();
            //}

            //LoadRole();
            return PartialView("AddEdit");
            //return View();
        }
        #endregion
    }
}


