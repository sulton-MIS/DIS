using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;

namespace AI070.Controllers
{
    public class MessageController : Controller
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;
        public ActionResult GenerateMessage(string MSG_ID, string p_PARAM1, string p_PARAM2, string p_PARAM3, string p_PARAM4)
        {
            try
            {
                M.MSG_ID = MSG_ID;
                M.p_PARAM1 = p_PARAM1;
                M.p_PARAM2 = p_PARAM2;
                M.p_PARAM3 = p_PARAM3;
                M.p_PARAM4 = p_PARAM4;
                var res = M.get_all_message(M);
                return Json(new { res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception M)
            {
                MESSAGE_TXT = M.Message.ToString();
                MESSAGE_TYPE = "Err";
                return Json(new { MESSAGE_TXT, MESSAGE_TYPE }, JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}
