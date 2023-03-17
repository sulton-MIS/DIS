using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using AI070.Models;

namespace AI070.Controllers
{
    public class ProfileController : PageController
    {
        protected override void Startup()
        {
            Settings.Title = "Dashboard";
            string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
            try
            {
                Settings.Title = "Profile";
                ViewData["Title"] = Settings.Title;
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
                ViewData["AreaInfo"] = AreaInfoRepository.Instance.GetAreaInfo();
                ViewData["LocationInfo"] = LocationInfoRepository.Instance.GetLocationInfo();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        [HttpPost]
        public ActionResult updateData(string USERNAME_OLD, string AREA, string LOCATION, string USERNAME, string PASSWORD, string EMAIL, string FIRST_NAME, string LAST_NAME, string PHONE, string GENDER, string BIRTH_DATE) {
            string MESSAGE = "";
            var data = new Object();
            try
            {
                data = ProfileRepository.Instance.updateData(USERNAME_OLD, AREA, LOCATION, USERNAME, PASSWORD, EMAIL, FIRST_NAME, LAST_NAME, PHONE, GENDER, BIRTH_DATE);
            }
            catch (Exception M) {
                MESSAGE = M.Message.ToString();
            }
            return Json(new { MESSAGE, data }, JsonRequestBehavior.AllowGet);
        }
    }
}
