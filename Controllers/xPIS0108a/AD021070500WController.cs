/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AD021] Vehicle Inspection and Traceability System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : AD021070500W
 * Function Name    : Shower test Screen
 * Function Group   : Report 
 * Program Id       : AD021070500WController
 * Program Name     : Shower Test Controller
 * Program Type     : Controller
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Rekhas
 * Version          : 01.00.00
 * Creation Date    : 8/Mei/2017 00:00:00
 * 
 * Update history     Re-fix date       Person in charge      Description 
 * created                             TMMIN)Reo
 * update get data                      FID) Rekhas
 * Copyright(C) 2016 - . All Rights Reserved                                                                                              
 *************************************************************************************************/
using AD021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AD021.Controllers
{
    public class AD021070500WController : Controller
    { 
        public ActionResult Index()
        {
            
            ViewData["Tack"] = SystemRepository.Instance.GetBySYSTEM_ID("TACK_TIME");
            ViewData["OK_Ratio_Target"] = Convert.ToInt64(Math.Floor(Convert.ToDouble(AD021070100WRepo.Instance.getOKRatioTarget())));

            DateTime dayStart = DateTime.ParseExact(SystemRepository.Instance.GetSystemByIDType("SHIFT_TIME","START_DAY"), "HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime dayEnd = DateTime.ParseExact(SystemRepository.Instance.GetSystemByIDType("SHIFT_TIME", "END_DAY"), "HH:mm:ss",
                                      System.Globalization.CultureInfo.InvariantCulture);
            DateTime nightStart = DateTime.ParseExact(SystemRepository.Instance.GetSystemByIDType("SHIFT_TIME", "START_NIGHT"), "HH:mm:ss",
                                      System.Globalization.CultureInfo.InvariantCulture);
            DateTime nigthEnd = DateTime.ParseExact(SystemRepository.Instance.GetSystemByIDType("SHIFT_TIME", "END_NIGHT"), "HH:mm:ss",
                                      System.Globalization.CultureInfo.InvariantCulture);
            string shift = "";
            if (DateTime.Now.Ticks > dayStart.Ticks && DateTime.Now.Ticks < dayEnd.Ticks)
            {
                shift = "D";
            }else
            //if (DateTime.Now.Ticks > nightStart.Ticks && DateTime.Now.Ticks < nigthEnd.Ticks)
            {
                shift = "N";
            }
            
            Result result = AD021070100WRepo.Instance.getShowerTest(shift);
            ViewData["Shift"]= shift;
            if (result.MESSAGE_STS)
            {
                ViewData["DataShower"] = (List<AD021070500W>)result.MESSAGE_OBJ; 
            }  
            return View();
            
        }

        public ActionResult getShowerTest()
        {
            string shift = "";
            Result result = AD021070100WRepo.Instance.getShowerTest(shift);
            if (result.MESSAGE_STS)
            {
                ViewData["DataShower"] = (List<AD021070500W>)result.MESSAGE_OBJ;
                return PartialView("_Grid");
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            } 
        }
 
    }
}
