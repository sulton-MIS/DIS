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
    public class HomeController : BaseController
    {
        WP01004Repository R = new WP01004Repository();
        protected override void Startup()
        {
            Settings.Title = "Home";
  
            if (!ApplicationSettings.Instance.Security.SimulateAuthenticatedSession)
            {
                ViewData["ListFunction"] = AppRepository.Instance.getApps(AppRepository.Instance.countApps());
            }
            else
            {
                ViewData["ListFunction"] = null;
            }
            ViewData["UserInfo"] = UserInfo;
        }

        public ActionResult WidgetSettings()
        {
            return PartialView("_WidgetSettings");
        }

    }
}
