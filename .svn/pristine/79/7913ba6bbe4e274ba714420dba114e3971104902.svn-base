using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.WP01004Master;
namespace AI070.Controllers
{
    public class DashboardController : PageController
    {
        WP01004Repository R = new WP01004Repository();

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Dashboard";
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(Lookup.Get<Toyota.Common.Credential.User>().Username);
                ViewData["AreaInfo"] = AreaInfoRepository.Instance.GetAreaInfo();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult getWorkingType(string IMPB)
        {
            var Data = new Object();
            string Message = "";
            try
            {
                Data = R.getWorkingType(IMPB);
                Message = "true";
            }
            catch (Exception M)
            {
                Message = M.Message.ToString();
            }
            return Json(new { Data, Message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getIMPBHenkanten(string IMPB)
        {
            var Data = new Object();
            string Message = "";
            try
            {
                Data = IMPBRepository.Instance.getIMPBHenkanten(IMPB);
                Message = "true";
            }
            catch (Exception M)
            {
                Message = M.Message.ToString();
            }
            return Json(new { Data, Message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getHomeContent(string AREA)
        {
            var data = IMPBRepository.Instance.getHomeContent(AREA);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult getIMPBDetail(string AREA)
        {
            var data = IMPBRepository.Instance.getIMPBDetail(AREA);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WidgetSettings()
        {
            return PartialView("_WidgetSettings");
        }

    }
}
