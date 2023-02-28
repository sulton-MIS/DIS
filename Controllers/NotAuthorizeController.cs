using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;

namespace AI070.Controllers
{
    public class NotAuthorizeController : BaseController
    {
        protected override void Startup()
        {
            Settings.Title = "Sorry... You are not authorized<br> <br>Please, contact administrator!";
        }

    }
}
