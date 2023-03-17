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
    public class WP03008Controller_old : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03008Repository R = new WP03008Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        #region Startup
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
        #endregion

        #region Generate Message
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
        #endregion

        #region Get Data Header
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

        #region Search Data
        public ActionResult Search_Data(
                                        int start,
                                        int display,
                                        String RegNo,
                                        String IdentityNo,
                                        String UserName,
                                        String Email
                                        )
        {
            string Anzen = Session["WP_ID_TB_M_EMPLOYEE"].ToString();

            //Buat Paging//
            PagingModel_WP03008 pg = new PagingModel_WP03008(
                                                              R.getCountWP03008(Anzen, RegNo, IdentityNo, UserName, Email),
                                                              start,
                                                              display
                                                            );

            //Munculin Data ke Grid//
            List<WP03008Master> List = R.getDataWP03008(pg.StartData, pg.EndData, Anzen, RegNo, IdentityNo, UserName, Email).ToList();
            ViewData["DataWP03008"] = List;
            ViewData["PagingWP03008"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add
        [HttpGet]
        public virtual ActionResult Add()
        {
            ViewBag.form_type = "New";
            Settings.Title = "Add Member List";
            ViewData["Title"] = Settings.Title;
            ViewData["IDENTITY"] = R.getIdentity();
            return PartialView("ADD_EDIT");
        }
        #endregion

        #region Insert
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

        [HttpPost]
        public virtual ActionResult Insert(
                                            string RegNo
                                            , string FirstName
                                            , string LastName
                                            , string Username_member
                                            , string Password
                                            , string Email
                                            , string Address
                                            , string Phone
                                            , string IdentityType
                                            , string IdentityNo
                                            , string SINo
                                            , string SIFrom
                                            , string SITo
                                            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            int Exist_data = 0;

            //Check Exist Data IdentityNo
            int count_data_IdentityNo = R.Check_Exist_Data("IdentityNo", IdentityNo);
            if (count_data_IdentityNo > 0)
            {
                Exist_data = count_data_IdentityNo;
                sts = "false";
                message = "Data Identity Number Is Exist";
            }

            //Check Exist Data Email
            int count_data_email = R.Check_Exist_Data("Email", Email);
            if (count_data_email > 0)
            {
                Exist_data = count_data_email;
                sts = "false";
                message = "Data Email Is Exist";
            }

            //Check Exist Data UserName
            int count_data_Username = R.Check_Exist_Data("UserName", Username_member);
            if (count_data_Username > 0)
            {
                Exist_data = count_data_Username;
                sts = "false";
                message = "Data Username Is Exist";
            }

            //Check Exist Data RegNo
            int count_data_RegNo = R.Check_Exist_Data("RegNo", RegNo);
            if (count_data_RegNo > 0)
            {
                Exist_data = count_data_RegNo;
                sts = "false";
                message = "Data Registration Number Is Exist";
            }


            if (Exist_data == 0)
            {
                //insert data
                try
                {
                    string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                    string Password_encrypt = EncryptPassword(Password);

                    var Exec = WP03008Repository.Insert(
                                                            RegNo
                                                            , FirstName
                                                            , LastName
                                                            , Username_member
                                                            , Password_encrypt
                                                            , Email
                                                            , Address
                                                            , Phone
                                                            , IdentityType
                                                            , IdentityNo
                                                            , SINo
                                                            , SIFrom
                                                            , SITo
                                                            , Session["WP_ID_TB_M_EMPLOYEE"].ToString()
                                                            , username);
                    sts = Exec[0].STACK;
                    message = Exec[0].LINE_STS;
                }
                catch (Exception M)
                {
                    sts = "false";
                    message = M.Message.ToString();
                }
            }

            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        public virtual ActionResult Edit(
                                            string Id
                                            , string RegNo
                                            , string FirstName
                                            , string LastName
                                            , string Username_member
                                            , string Email
                                            , string Address
                                            , string Phone
                                            , string IdentityType
                                            , string IdentityNo
                                            , string SINo
                                            , string SIFrom
                                            , string SITo
                                         )
        {
            ViewBag.form_type = "Edit";
            Settings.Title = "Edit Member List";
            ViewData["Title"] = Settings.Title;
            ViewData["IDENTITY"] = R.getIdentity();

            ViewBag.Id = Id;
            ViewBag.RegNo = RegNo;
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            ViewBag.Username_member = Username_member;
            ViewBag.Email = Email;
            ViewBag.Address = Address;
            ViewBag.Phone = Phone;
            ViewBag.IdentityType = IdentityType;
            ViewBag.IdentityNo = IdentityNo;
            ViewBag.SINo = SINo;
            ViewBag.SIFrom = SIFrom;
            ViewBag.SITo = SITo;

            return PartialView("ADD_EDIT");
        }
        #endregion

        #region Update Data
        [HttpPost]
        public ActionResult Update(string DATA)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string Id = Datas[0];
                string RegNo = Datas[1];
                string FirstName = Datas[2];
                string LastName = Datas[3];
                string Username_member = Datas[4];
                string Email = Datas[5];
                string Address = Datas[6];
                string Phone = Datas[7];
                string IdentityType = Datas[8];
                string IdentityNo = Datas[9];
                string SINo = Datas[10];
                string SIFrom = Datas[11];
                string SITo = Datas[12];

                var EXEC = R.Update_Data(
                                            Id,
                                            RegNo,
                                            FirstName,
                                            LastName,
                                            Username_member,
                                            Email,
                                            Address,
                                            Phone,
                                            IdentityType,
                                            IdentityNo,
                                            SINo,
                                            SIFrom,
                                            SITo,
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
    }
}
