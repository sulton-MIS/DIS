using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AI070.Controllers
{
    public class StoreImageFileController : Controller
    {
        [AllowAnonymous]
        public void StoreFile()
        {
            //generate random file name
            string randFileName = "MyFile-" + Guid.NewGuid().ToString();
            //save image content to Application Cache
            System.Web.HttpContext.Current.Application[randFileName] = System.Web.HttpContext.Current.Request.Form["base64ImageContent"];
            //return file name back to client
            System.Web.HttpContext.Current.Response.ContentType = "text/plain";
            System.Web.HttpContext.Current.Response.Write(randFileName);
            System.Web.HttpContext.Current.Response.End();

        }
    }
}