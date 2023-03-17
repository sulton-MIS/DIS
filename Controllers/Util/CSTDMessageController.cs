﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using AI070.Models.STD;

namespace AI070.Controllers.Util
{
    public class CSTDMessageController : BaseController
    {
        #region Function Get Message
        [HttpPost]
        public JsonResult Message(String msgID, params object[] msgParam)
        {
            String result = String.Empty;
            result = STDMessage.Instance.getTextMessage(msgID);
            if (msgParam != null)
            {
                if (msgParam.Count() > 0)
                {
                    result = String.Format(result, msgParam);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
