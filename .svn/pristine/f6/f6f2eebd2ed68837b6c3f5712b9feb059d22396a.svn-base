using AI070.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// added by ark.deden
namespace AI070.Controllers.Shared
{
    public class ErrExcMessageController : Controller
    {
        private Message M = new Message();
        private JsonResult GenerateMessage(bool sts, string type, string message)
        {
            return Json(new { sts, type, message }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Generate(string MSG_ID,
                                  string p_PARAM1,
                                  string p_PARAM2,
                                  string p_PARAM3,
                                  string p_PARAM4)
        {
            try
            {
                var message = new Message
                {
                    MSG_ID = MSG_ID,
                    p_PARAM1 = p_PARAM1,
                    p_PARAM2 = p_PARAM2,
                    p_PARAM3 = p_PARAM3,
                    p_PARAM4 = p_PARAM4
                };
                var res = M.getMessageTextWithFunctionSQL(message).FirstOrDefault();
                return GenerateMessage(true, res != null ? res.MSG_TYPE : "", res != null ? res.MSG_TEXT : "");
            }
            catch (Exception M)
            {
                return GenerateMessage(false, "Err", M.Message.ToString());
            }
        }
    }
}