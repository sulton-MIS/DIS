using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using TDKUtility;
using Toyota.Common.Database;
using AI070.Models;

namespace AI070.Controllers
{
    public class VisitorCounterAppController : BaseController
    { 
        private void getCounter(string from, string to, string application, string function, string username, int page, int size)
        {
            DateTime datefrom = TDKUtility.DateFormat.ToDateFromString(from.ToViewDate());
            DateTime dateto = TDKUtility.DateFormat.ToDateFromString(to.ToViewDate());

            Paging pg = new Paging(Counter.Instance.CountVisitor(datefrom, dateto, application, function, username), page, size);
            ViewData["Paging"] = pg;
            ViewData["Counter"] = Counter.Instance.getVisitor(pg.StartData, pg.EndData, datefrom,dateto,application,function,username).ToList();
        } 

        protected override void Startup()
        {
            Settings.Title = "Visitor counter per application";
            if (!ApplicationSettings.Instance.Security.SimulateAuthenticatedSession)
            {
                ViewData["ListFunction"] = AppRepository.Instance.getApps(AppRepository.Instance.countApps());
            }
            else
            {
                ViewData["ListFunction"] = null;
            }
        }
         
        public ActionResult getCounterApp(string application,string username, string functionname, string periodeFrom, string periodeTo, int page, int size)
        {
            getCounter(periodeFrom, periodeTo, application, functionname, username, page, size);
            return PartialView("_View");
        }
         
        public void DownloadReport(string from, string to, string application, string username, string function)
        {
            //string newdate = "";
            //if ((from != null) && (to != null) && (from != "") && (to != ""))
            //{
            //    string[] periode = from.Split('-');
            //    newdate = periode[1] + "-" + periode[0];
            //}
            //else
            //{
            //    newdate = DateTime.Now.Year + "-" + DateTime.Now.Month;
            //}
            DateTime datefrom = TDKUtility.DateFormat.ToDateFromString(from.ToViewDate());
            DateTime dateto = TDKUtility.DateFormat.ToDateFromString(to.ToViewDate());


            List<VisitorApplication> List = Counter.Instance.getVisitor(1, Counter.Instance.CountVisitor(datefrom,dateto,application,function,username), datefrom,dateto, application, function,username);
            List<string[]> ListArr = new List<string[]>();// array for choose data
            String[] header = { "Application", "Function","Username", "Count", "Period" };//for header name
            ListArr.Add(header);

            //choose data for show in report
            foreach (VisitorApplication obj in List)
            {
                String[] myArr = { obj.ApplicationId,obj.ApplicationScreen,obj.AppAccessUser, obj.Counting.ToString(), obj.ApplicationPeriode.ToViewDate() };
                ListArr.Add(myArr);
            }
            Response.PutExcel(ListArr, new VisitorApplication(), "VisitCounter");

        }
          
    }
}
