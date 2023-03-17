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
using AI070.Models.DISR060001Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISR060001Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR060001Repository R = new DISR060001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master User";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string i_user, string dept, string e_mail)
        {
            //Buat Paging//
            PagingModel_DISR060001 pg = new PagingModel_DISR060001(R.getCountDISR060001(DATA_ID, i_user, dept, e_mail), start, display);

            //Munculin Data ke Grid//
            List<DISR060001Master> List = R.getDataDISR060001(pg.StartData, pg.EndData, i_user, dept, e_mail).ToList();
            ViewData["DataDISR060001"] = List;
            ViewData["PagingDISR060001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW(string i_user, string c_pwd, string i_user_long, string dept, string authority, string e_mail, string EmailSender, string section, string IdLevel, string IdAccesable)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISR060001Repository.Create(i_user, c_pwd, i_user_long, dept, authority, e_mail, EmailSender, section, IdLevel, IdAccesable);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Operator", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Operator", "", "");
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

        //#region Section
        //public ActionResult Test(string SYSTEM_CD)
        //{
        //    var sts = new object();
        //    var message = new object();
        //    try
        //    {
        //        var Exec = R.getExecutor();
        //        sts = "TRUE";
        //        message = Exec;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "Err";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        //#region GetDataSection
        //public ActionResult GetDataSection(string SYSTEM_CD)
        //{
        //    var sts = new object();
        //    var message = new object();
        //    try
        //    {
        //        var Exec = R.getSection(SYSTEM_CD);
        //        sts = "TRUE";
        //        message = Exec;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "Err";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult GetDataDivison()
        //{
        //    var sts = new object();
        //    var message = new object();
        //    try
        //    {
        //        var Exec = R.getDivision();
        //        sts = "TRUE";
        //        message = Exec;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "Err";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        //#region PIC
        //public ActionResult GetDataPIC(string SYSTEM_CD)
        //{
        //    var sts = new object();
        //    var message = new object();
        //    try
        //    {
        //        var Exec = R.getPIC();
        //        sts = "TRUE";
        //        message = Exec;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "Err";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion


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
                string i_user = Datas[1];
                string c_pwd = Datas[2];
                string i_user_long = Datas[3];
                string dept = Datas[4];
                string authority = Datas[5];
                string e_mail = Datas[6];
                string EmailSender = Datas[7];
                string section = Datas[8];
                string IdLevel = Datas[9];
                string IdAccesable = Datas[10];

                //string name_sagyosha = Datas[1];
                //string id_sagyosha = Datas[2];
                //string dept = Datas[3];
                //string bagian = Datas[4];
                //string jabatan = Datas[5];
                //string grp = Datas[6];
                //string comment = Datas[7];
                //string tmk = Datas[8];

                string STATUS = "1";
                var EXEC = R.Update_Data(ID, i_user, c_pwd, i_user_long, dept, authority, e_mail, EmailSender, section, IdLevel, IdAccesable);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master User", "", "");
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
                var res = M.get_default_message("MWP002", "Master User", "", "");
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

    }
}