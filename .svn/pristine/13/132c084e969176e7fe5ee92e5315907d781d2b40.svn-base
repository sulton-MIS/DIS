using AI070.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using System.Security.Cryptography;
using System.Text;
namespace AI070.Controllers
{
    public class LoginController : LoginPageController
    {
        public ActionResult CheckUserPassword(string username, string password)
        {
            List<UserInfo> userinfo = new List<UserInfo>() { };
            //password = EncryptPassword(password);
            password = password;
            username = username.ToString();
            int checkUser = SystemRepository.Instance.CheckUserPassword(username, password);
            if (checkUser == 1)
            {
                userinfo = SystemRepository.Instance.getUserInfo(username);
                if (userinfo.Count > 0)
                {
                    Lookup.Add(new User
                    {
                        Username = userinfo[0].Username,
                        FirstName = userinfo[0].First_Name,
                        LastName = userinfo[0].Last_Name,
                        RegistrationNumber = userinfo[0].NOREG,
                        //Gender = userinfo[0].Gender_code,
                        Roles = new List<Toyota.Common.Credential.Role>(){ new Toyota.Common.Credential.Role() { Id = userinfo[0].authID, Name=userinfo[0].authName } },
                        Address = userinfo[0].Address,
                        Company = new Toyota.Common.Generalist.CompanyInfo{ Id = userinfo[0].Company_ID, Name = userinfo[0].Company }
                    });

                    Session["User_Section"] = userinfo[0].Section;
                    Session["User_Company"] = userinfo[0].Company_ID;
                }
            }
            
            var userData = Lookup.Get<User>();

            return Json(new
            {
                userData,
                userinfo,
                checkUser,
                password
            });
        }

        string HashMd5(HashAlgorithm md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
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
