/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AD021] Vehicle Inspection and Traceability System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : AD021000100W
 * Function Name    : Login Screen
 * Function Group   : User Menu
 * Program Id       : AD021000100WController
 * Program Name     : Login Controller
 * Program Type     : Controller
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Arri
 * Version          : 01.00.00
 * Creation Date    : 03/11/2015 10:05:40
 * 
 * Update history     Re-fix date       Person in charge      Description 
 * 1.0                14/12/2015        FID.Ine               Update function ForgetPassword
 *
 * Copyright(C) 2016 - . All Rights Reserved                                                                                              
 *************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AD021.Models.AD021000100W;

namespace AD021.Controllers
{
    public class AD021000100WController : LoginPageController
    {
        protected override void Startup()
        {
            Settings.Title = "Login";
            getRole();
        }

        public ActionResult userLogin(string userid, string password)
        {
            AD021000100W loggedInForm = new AD021000100W();
            loggedInForm.USER_NAME = userid;
            loggedInForm.USER_PASSWORD = password;

            return ProcessLogOn(loggedInForm);
        }

        private ActionResult ProcessLogOn(AD021000100W user)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                if (AD021000100WRepository.Instance.IsValid(user.USER_NAME, user.USER_PASSWORD))
                {
                    result = AD021000100WRepository.Instance.UpdateLoginStatus(user.USER_NAME, user.USER_PASSWORD);
                    if(result.Equals("1")){
                        //FormsAuthentication.SetAuthCookie(user.USER_NAME, false);
                        result = "Success";
                    }else{
                        result = "Failed";
                    }
                }
                else if (AD021000100WRepository.Instance.IsLogin(user.USER_NAME, user.USER_PASSWORD))
                {
                    result = "login";
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                    result = "Error";
                }
            }
            
            return Login(user.USER_NAME, user.USER_PASSWORD);
        }

        public JsonResult getUserID(String userId)
        {
            var result = AD021000100WRepository.Instance.getUserID(userId);
            return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPassword(String userId, String passlogin)
        {
            var result = AD021000100WRepository.Instance.getPassword(userId, passlogin);
            return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public String ForgetPassword(String p_UserID)
        {
            if (!string.IsNullOrEmpty(p_UserID))
            {
                var passwd = AD021000100WRepository.Instance.getPassword(p_UserID);
                if (passwd.ToArray().Length!=0)
                {
                    ViewData["Password"] = passwd;
                    TMS040500BController.Instance.ForgetPassword(passwd);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            return "0";            
        }       

        private void getRole()
        {
            ViewData["Role"] = AD021000100WRepository.Instance.GetRole();
        }

        public ActionResult UserLogout()
        {
            string result = "";
            //string sysCat = "PARAMETER";
            //string sysSCat = "USER_AUTHENTICATION";
            //string sysCD = "USER_ID";

            User u = Lookup.Get<User>();

            //string UserID = AD021000100WRepository.Instance.getSystemMaster(sysCat, sysSCat, sysCD);
            string UserID = u.RegistrationNumber;

            if (UserID != null)
            {
                result = AD021000100WRepository.Instance.UpdateLoginStatus(UserID);
                if (result.Equals("1"))
                {
                    //Session["UserID"] = null;
                    result = "Success";
                }
            }
            else {
                result = "False";
            }
            //if (result == "Success")
            //    return (ActionResult)this.Redirect(this.Descriptor.BaseUrl + "/" + ApplicationSettings.Instance.Security.LoginController);
            //else
            //    return (ActionResult)this.Redirect(this.Descriptor.BaseUrl + "/" + ApplicationSettings.Instance.Runtime.HomeController);
            return Logout();
        }

    }
}
