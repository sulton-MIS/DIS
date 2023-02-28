using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neodynamic.SDK.Web;

namespace AI070.Controllers
{
    public class PrintHtmlCardsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.WCPScript = WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), Url.Action("PrintImage", "PrintHtmlCards", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);
            return View();
        }

        [AllowAnonymous]
        public void PrintImage(string useDefaultPrinter, string printerName, string imageFileName)
        {

            //create a temp file name for our image file...

            //Because we know the Card size is 3.125in x 4.17in, we can specify 
            //it through a special format in the file name (see http://goo.gl/Owzr9o) so the
            //printing output size is honored; otherwise the output will be sized to Page Width & Height
            //specified by the printer driver default setting
            string fileName = imageFileName + "-PW=3.125-PH=4.17" + ".png";

            //Create a PrintFile object with the image file
            PrintFile file = new PrintFile(Convert.FromBase64String((string)HttpContext.Application[imageFileName]), fileName);
            //Create a ClientPrintJob and send it back to the client!
            ClientPrintJob cpj = new ClientPrintJob();
            //set file to print...
            cpj.PrintFile = file;


            //set client printer...
            if (useDefaultPrinter == "checked" || printerName == "null")
                cpj.ClientPrinter = new DefaultPrinter();
            else
                cpj.ClientPrinter = new InstalledPrinter(printerName);

            //send it...
            HttpContext.Response.ContentType = "application/octet-stream";
            HttpContext.Response.BinaryWrite(cpj.GetContent());
            HttpContext.Response.End();

        }

    }

}