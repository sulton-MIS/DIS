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
using AI070.Models;
using AI070.Models.WPMemberMaster;

namespace AI070.Controllers
{
    public class WPMemberController : Controller
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WPMemberRepository R = new WPMemberRepository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        public ActionResult Index()
        {
            try
            {
                String Title = "Member";
                ViewData["Title"] = Title;
                if(Session["WP_Username"] == null)
                {
                    return Redirect("WPLogin");
                }
                //ViewData["WpUsers"] = WPLoginRepository.Instance.GetUserInfo(Username);
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["WP_Username"] = null;
            return RedirectToAction("Index");
        }
    }
}
