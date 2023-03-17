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
using AI070.Models.WP03008Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class WP03008Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03008Repository R = new WP03008Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Member List";
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

        #region Data Header asdad
        public void GetDataHeader()
        {
            try
            {
                ViewData["COMPANY"] = R.getCompany();
                ViewData["EXECUTOR"] = R.getExecutor();
                ViewData["IDENTITY"] = R.getIdentity();
                ViewData["SECTION"] = R.getSection("TMMIN");
                ViewData["PIC"] = R.getPIC();
                ViewData["Division"] = R.getDivision();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion 

        #region Section
        public ActionResult Test(string SYSTEM_CD)
        {
            var sts = new object();
            var message = new object();
            try
            {
                var Exec = R.getExecutor();
                sts = "TRUE";
                message = Exec;
            }
            catch (Exception M)
            {
                sts = "Err";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetDataSection
        public ActionResult GetDataSection(string SYSTEM_CD)
        {
            var sts = new object();
            var message = new object();
            try
            {
                var Exec = R.getSection(SYSTEM_CD);
                sts = "TRUE";
                message = Exec;
            }
            catch (Exception M)
            {
                sts = "Err";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataDivison()
        {
            var sts = new object();
            var message = new object();
            try
            {
                var Exec = R.getDivision();
                sts = "TRUE";
                message = Exec;
            }
            catch (Exception M)
            {
                sts = "Err";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region PIC
        public ActionResult GetDataPIC(string SYSTEM_CD)
        {
            var sts = new object();
            var message = new object();
            try
            {
                var Exec = R.getPIC();
                sts = "TRUE";
                message = Exec;
            }
            catch (Exception M)
            {
                sts = "Err";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

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
                resultFilePath = Path.Combine("~/Content/Upload/Foto", Request.Form["Regnumber"] +".PNG");
                file.SaveAs(Server.MapPath(resultFilePath));
            }
            var MSG = "Nice";
            return Json(new { MSG });
        }

        public ActionResult MoveFileCertificate()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                saveFile = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                resultFilePath = Path.Combine("~/Content/Upload/Certificate", Request.Form["Regnumber"] + ".PNG");
                file.SaveAs(Server.MapPath(resultFilePath));
            }
            var MSG = "Nice";
            return Json(new { MSG });
        }

        public ActionResult MoveFileID()//UploadModel model)//, IEnumerable<HttpPostedFileBase> picture)
        {
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var filename = Path.GetExtension(file.FileName);
                saveFile = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                resultFilePath = Path.Combine("~/Content/Upload/KTP", Request.Form["ID"] + ".PNG");
                file.SaveAs(Server.MapPath(resultFilePath));
            }
            var MSG = "Nice";
            return Json(new { MSG });
        }

        #region Search Data z
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string EMPLOYEE_NAME, string IDENTITYNUMBER, string ANZENNO, string INDUCTION)
        {
            string COMPANY = Lookup.Get<Toyota.Common.Credential.User>().Company.Id;
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            ANZENNO = (R.getAnzen(username)[0].ANZEN_NO).ToString();

            PagingModel_WP03008 pg = new PagingModel_WP03008(R.getCountWP03008(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA, STATUS_ACTIVE, EMPLOYEE_NAME, IDENTITYNUMBER, COMPANY, ANZENNO, INDUCTION), start, display);

            //Munculin Data ke Grid//
            List<WP03008Master> List = R.getDataWP03008(pg.StartData, pg.EndData, EMPLOYEE_NAME, IDENTITYNUMBER, COMPANY, ANZENNO, INDUCTION).ToList();
            ViewData["DataWP03008"] = List;
            ViewData["PagingWP03008"] = pg;
            
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region searchIdentity
        public ActionResult searchIdentity(string NIK)
        {
            string MSG;
            var CheckNIK = R.CheckNIK(NIK);
            if(CheckNIK.Count > 0)
            {
                MSG = "true";
            }
            else
            {
                MSG = "false";
            }
            return Json(new { MSG, CheckNIK }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add New

        string HashMd5(HashAlgorithm md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            
            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        string EncryptPassword(string value)
        {
            using (var md5 = MD5.Create())
            {
                return HashMd5(md5, value);
            }
        }

        private bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = EncryptPassword(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult ADD_NEW(string COMPANY, string REGNUMBER, string EMAIL, string SECTION, string FIRSTNAME, string LASTNAME, string ADDRESS, string PHONE, string IDENTITY_TYPE, string IDENTITY_NO, string SAFETY_INDUCTION_NO, string SAFETY_INDUCTION_FROM, string SAFETY_INDUCTION_TO, string SEQ_NO, string STATUS, string GENDER)
        {
            string sts = null;
            string message = null;
            string PIC_STATUS = "MEM";
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            var getAnzenLeader = R.getAnzen(username);
            string ANZEN_NO = "";
            string ANZEN_DT_FROM = "";
            string ANZEN_DT_TO = "";
            SECTION = "GENERAL";
            if(getAnzenLeader.Count > 0)
            {
                ANZEN_NO = getAnzenLeader[0].ANZEN_NO;
                ANZEN_DT_FROM = getAnzenLeader[0].ANZEN_FROM;
                ANZEN_DT_TO = getAnzenLeader[0].ANZEN_TO;
            }
            try
            {
                var Exec = WP03008Repository.Create(COMPANY, REGNUMBER, EMAIL, SECTION, FIRSTNAME, LASTNAME, ADDRESS, PHONE, IDENTITY_TYPE, IDENTITY_NO, PIC_STATUS, ANZEN_NO, ANZEN_DT_FROM, ANZEN_DT_TO, SAFETY_INDUCTION_NO, SAFETY_INDUCTION_FROM, SAFETY_INDUCTION_TO, SEQ_NO, STATUS, GENDER, username);
                sts = Exec[0].STACK;

                if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "User / Worker Master", "", "");
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
        public ActionResult Update_Data(string DATA)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string NOREG = Datas[1];
                string COMPANY = Datas[2];
                string FIRSTNAME = Datas[3];
                string LASTNAME = Datas[4];
                string EMAIL = Datas[5];
                string ADDRESS = Datas[6];
                string PHONE = Datas[7];
                string IDENTITY_TYPE = Datas[8];
                string IDENTITY_NO = Datas[9];
                string SAFETY_INDUCTION_NO = Datas[10];
                string SAFETY_INDUCTION_FROM = Datas[11];
                string SAFETY_INDUCTION_TO = Datas[12];
                string GENDER = Datas[13];
                string STATUS = "1";
                var EXEC = R.Update_Data(ID, NOREG, COMPANY, FIRSTNAME, LASTNAME, EMAIL, ADDRESS, PHONE, IDENTITY_TYPE, IDENTITY_NO, SAFETY_INDUCTION_NO, SAFETY_INDUCTION_FROM, SAFETY_INDUCTION_TO, STATUS, GENDER, username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "User / Worker Master", "", "");
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
            return Json(new { sts, message  }, JsonRequestBehavior.AllowGet);
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
                var res = M.get_default_message("MWP002", "User / Worker Master", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
