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
using Toyota.Common.Credential;
using System.Security.Cryptography;
using System.Text;
using User = Toyota.Common.Credential.User;

namespace AI070.Controllers
{

    public class WPLoginController : Controller
    {

        ResultMessage rm = new ResultMessage();
        WPLoginRepository R = new WPLoginRepository();
        Message M = new Message();

        public ActionResult Index()
        {
            try
            {
                String Title = "LOGIN";
                ViewData["Title"] = Title;
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
            return View();
        }

        [HttpPost]
        public ActionResult checkUser(string USERNAME, string PASSWORD)
        {
            var data = new object();
            try
            {
                PASSWORD = EncryptPassword(PASSWORD);
                var EXEC = R.checkUsername(USERNAME, PASSWORD);
                data = EXEC;
                
                if (EXEC.Count() > 0)
                {
                    ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(USERNAME);
                    ViewData["MenuInfoList"] = MenuInfoRepository.Instance.GetMenuInfo(USERNAME);

                    Session["WP_ID_TB_M_EMPLOYEE"] = EXEC[0].ID_TB_M_EMPLOYEE;
                    Session["WP_Username"] = EXEC[0].USERNAME;
                    Session["WP_Company"] = EXEC[0].COMPANY;
                    Session["WP_REG_NO"] = EXEC[0].REG_NO;
                    Session["WP_Section"] = EXEC[0].SECTION;
                    Session["WP_EMAIL"] = EXEC[0].EMAIL;
                    Session["WP_PIC_STATUS"] = EXEC[0].PIC_STATUS;
                    Session["WP_FIRST_NAME"] = EXEC[0].FIRST_NAME;
                    Session["WP_LAST_NAME"] = EXEC[0].LAST_NAME;
                }
            }
            catch (Exception M)
            {
                data = M.Message.ToString();
            }
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckUserPlantMapping(string username)
        {
            int isError = SystemRepository.Instance.CheckUserPlantMapping(username);
            return Json(new
            {
                isError = isError
            });
        }

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

    }
}
