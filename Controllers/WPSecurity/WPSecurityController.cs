﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WPSecurityMaster;

namespace AI070.Controllers
{
    public class WPSecurityController : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WPSecurityRepository R = new WPSecurityRepository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;
        string sts;
        string message;

        protected override void Startup()
        {
            try
            {
                String Title = "Security";

                ViewData["Title"] = Title;
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
                if (username == null)
                {
                    Response.Redirect("Login");
                }
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
            //return View();
        }

        public ActionResult getDataScan(string scanQR)
        {
            string check_scanner = scanQR.Substring(0, 4);
            var employee_details = new object();
            var data = new object();
            string employee_id = "";
            string get_job_id;
            var get_implementor = new object();
            var get_impb_detail = new object();

            if(check_scanner == "IMPB")
            {
                string getNIK = R.GetNIK(scanQR);
                var employee_detail = R.GetDataEmployeeDetail(getNIK, "IMPB");
                if (employee_detail.Count > 0)
                {
                    employee_id = employee_detail[0].ID;
                }
                get_job_id = R.GetWpProjectJobID(employee_id);
                get_implementor = R.getImplementor("IMPB", scanQR);
                get_impb_detail = R.getIMPBDetail("IMPB", scanQR);
                employee_details = employee_detail;
            }
            else
            {
                var employee_detail = R.GetDataEmployeeDetail(scanQR, "ID_CARD");
                if(employee_detail.Count > 0)
                {
                    employee_id = employee_detail[0].ID;
                }
                get_job_id = R.GetWpProjectJobID(employee_id);
                get_implementor = R.getImplementor("", get_job_id);
                get_impb_detail = R.getIMPBDetail("", get_job_id);
                employee_details = employee_detail;
            }
            
            return Json(new { sts, message, employee_id, employee_details, get_implementor, get_impb_detail, scanQR, check_scanner }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getTotalContractor()
        {
            var data = R.getTotalContractor();
            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HealtyCheck()
        {
            var data = R.getHealtyCheck();
            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDashboardTable(int page)
        {
            int start = page * 10 - 10 + 1;
            int end = page * 10;
            var data = R.getDashboardTable(page, start , end);
            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CHECK_DATA_SECURITY(string ID, string IMPB_NO)
        {
            //string SECURITY_ID = Session["WP_ID_TB_M_EMPLOYEE"].ToString();
            string Username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            var data = R.CHECK_DATA_SECURITY(ID, IMPB_NO, Username);
            return Json(new { sts, message, data, Username }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult checkOutScan(string ID, string IMPB_NO)
        {
            //string SECURITY_ID = Session["WP_ID_TB_M_EMPLOYEE"].ToString();
            string Username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            int data = R.getCheckOut(ID, IMPB_NO, Username);
            return Json(new { sts, message, data, Username }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dashboard()
        {
            try
            {
                ViewData["Marquee"] = R.getMarqueeText();
            }
            catch (Exception e)
            {
                
            }
            return View("Dashboard");
        }
        
        public ActionResult TEST()
        {
            return View("TEST/test");
        }

        public ActionResult GetContractor(string EMPLOYEE_NAME, string COMPANY, string IMPLEMENT_FROM, string IMPLEMENT_TO)
        {
            var data = R.GetContractor(EMPLOYEE_NAME, COMPANY, IMPLEMENT_FROM, IMPLEMENT_TO);
            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["WP_Username"] = null;
            return RedirectToAction("Index");
        }
    }
}