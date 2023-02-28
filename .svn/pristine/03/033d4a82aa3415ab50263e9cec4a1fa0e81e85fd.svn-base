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
using AI070.Models.WP02002Master;
using AI070.Models.WP02002;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Rotativa;

namespace AI070.Controllers
{
    public class WP02002Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP02002Repository R = new WP02002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Register Project Detail";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult GenerateMessage(string MSG_ID, string p_PARAM1, string p_PARAM2, string p_PARAM3, string p_PARAM4)
        {
            try
            {
                M.MSG_ID = MSG_ID;
                M.p_PARAM1 = p_PARAM1;
                M.p_PARAM2 = p_PARAM2;
                M.p_PARAM3 = p_PARAM3;
                M.p_PARAM4 = p_PARAM4;
                var res = M.getMessageTextWithFunctionSQL(M);
                MESSAGE_TXT = res[0].MSG_TEXT;
                MESSAGE_TYPE = res[0].MSG_TYPE;
            }
            catch (Exception M)
            {
                MESSAGE_TXT = M.Message.ToString();
                MESSAGE_TYPE = "Err";
            }
            return Json(new { MESSAGE_TXT, MESSAGE_TYPE }, JsonRequestBehavior.AllowGet);
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                ViewData["Project_Code"] = R.getProjectCode();
                ViewData["Jobs"] = R.getJobs();
                ViewData["Category"] = R.getCategory();
                ViewData["Location"] = R.getDataLocation();

                ViewData["Project_Location"] = R.getLocation();
                ViewData["Division"] = R.getDivision();
                ViewData["Status"] = R.getStatus();
                ViewData["Executor"] = R.getExecutor();
                ViewData["Area"] = R.getArea();
                ViewData["Company"] = R.getCompany();
                //ViewData["Employee"] = R.getEmployee();
                ViewData["Location"] = R.getLocation();
                ViewData["WorkingType"] = R.getWorkingType();
                //ViewData["Pic"] = R.getPic();
                //ViewData["Pengawas"] = R.getPengawas();
                ViewData["WorkingHours"] = R.getWorkingHours();
                TempData["EmployeeList"] = R.getEmployee();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string EXECUTION_TIME
            , string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string PROJECT_CODE
            ,string PROJECT_NAME, string DATE_FROM, string DATE_TO, string COMPANY, string LOCATION, string DIVISION, string WP_IMPB_NO)
        {
            //Buat Paging//
            PagingModel_WP02002 pg = new PagingModel_WP02002(R.getCountWP02002(DATA_ID, EXECUTION_TIME, TIME_UNIT_CRITERIA
                , STATUS_ACTIVE, PROJECT_CODE,  PROJECT_NAME,  DATE_FROM,  DATE_TO,  COMPANY, 
                 LOCATION,  DIVISION,  WP_IMPB_NO), start, display);

            //Munculin Data ke Grid//
            List<WP02002Master> List = R.getDataWP02002(pg.StartData, pg.EndData, PROJECT_CODE, PROJECT_NAME, DATE_FROM, DATE_TO
                , COMPANY,LOCATION, DIVISION, WP_IMPB_NO).ToList();
            ViewData["DataWP02002"] = List;
            ViewData["PagingWP02002"] = pg;
            ViewData["Project_Code"] = R.getProjectCode();
            ViewData["Jobs"] = R.getJobs();
            ViewData["Category"] = R.getCategory();
            ViewData["Location"] = R.getDataLocation();
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Get Location
        public ActionResult getLocation(string PROJECT_CODE)
        {
            string sts = null;
            string message = null;
            var data = new object();
            try
            {
                var Exec = WP02002Repository.getLocation(PROJECT_CODE);
                sts = "TRUE";
                message = "";
                data = Exec;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add New
        public ActionResult ADD_NEW(string PROJECT_CODE, string LOCATION, string JOBS, string DANGERLEVEL, string DATE, string CATA, string CATB, string CATC, string CATD, string CATE, string CATF, string REMARKS)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = WP02002Repository.Create(PROJECT_CODE, LOCATION, JOBS, DANGERLEVEL, DATE, CATA, CATB, CATC, CATD, CATE, CATF, REMARKS, username);
                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data()
        {
            string sts = null;
            string message = null;
            string WP_IMPB_NO = "";
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var items = JsonConvert.DeserializeObject<WP02002InputForm>(json);

                if (items.WP_IMPB_NO == "")
                {
                    Sequence_model seqmodel = new Sequence_model();
                    seqmodel.TYPE_TRX = "IMPB_CODE";
                    seqmodel.YEAR_TRX = DateTime.Now.Year.ToString();
                    seqmodel.MONTH_TRX = DateTime.Now.Month.ToString();
                    items.WP_IMPB_NO = R.GetIMPBCode(seqmodel, username, items.ID_TB_M_AREA);
                }

                WP_IMPB_NO = items.WP_IMPB_NO;
                
                var Exec = WP02002Repository.IMPBProcess(items, username);

                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;
                
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, WP_IMPB_NO }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Submit_Only()
        {
            string sts = null;
            string message = null;
            string WP_IMPB_NO = "";
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var items = JsonConvert.DeserializeObject<WP02002InputForm>(json);

                var Exec = WP02002Repository.SubmitTrans(items, username);

                sts = Exec[0].STACK;
                message = Exec[0].LINE_STS;

            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, WP_IMPB_NO }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadHenkatenFile()
        {
            string WP_IMPB_NO = Request.Form["WP_IMPB_NO"];
            var f = Request.Files;
            var saveFile = "";
            var resultFilePath = "";

            var fileenv = Request.Files["HKENVFILE"];
            var filesafety = Request.Files["HKSAFETYFILE"];

            var envname = Request.Form["HKENVNAME"];
            var safetyname = Request.Form["HKSAFETYNAME"];

            string path = Path.Combine("~/Content/Upload/Henkaten", "");

            if (fileenv != null)
            {
                resultFilePath = Path.Combine("~/Content/Upload/Henkaten", envname);
                fileenv.SaveAs(Server.MapPath(resultFilePath));
            }
            
            if (filesafety != null)
            {
                resultFilePath = Path.Combine("~/Content/Upload/Henkaten", safetyname);
                filesafety.SaveAs(Server.MapPath(resultFilePath));
            }
            

            return Json(new { resultFilePath });
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        R.Delete_Data(Datas[i]);
                    }
                }

                sts = "TRUE";
                message = "Data has been successfully Deleted";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DATA }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        public ActionResult GetEmployeeJob(string EmployeeID,string JobID)
        {
            var result = R.GetEmployeeJob(EmployeeID, JobID);

            return Json(new { JobValidate = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getIMPBLocation(string ID)
        {
            var result = R.getIMPBLocation(ID, "");
            var data = R.getIMPBLocation(ID, "All");
            return Json(new { result, data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDataDetail(string WP_PROJECT_JOB_ID)
        {
            var result = R.getDetail(WP_PROJECT_JOB_ID);

            return Json(new { result}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReportIMPB(string WP_PROJECT_JOB_ID, string WP_IMPB_NO)
        {
            var MasterData = R.getDataWP02002(0, 10, "", "", "", "", "", "", "", WP_IMPB_NO).ToList().FirstOrDefault();
            var result = R.getDetail(WP_PROJECT_JOB_ID);
            result.MasterData = MasterData;

            result.WorkingStr = GenerateWorkingTableString(result.project_list_working);
            result.IdentificationStr = GenerateHenkatenSafetyTableString(result.project_list_identification);
            result.ImpactStr = GenerateHenkatenEnvTableString(result.project_list_impact);
            result.Supervisionstr = GenerateSupervisionTableString(result.project_list_supervision);

            return View(result);
        }

        public ActionResult PrintReportIMPB(string WP_PROJECT_JOB_ID,string WP_IMPB_NO)
        {
            try
            {
                var MasterData = R.getDataWP02002(0, 10, "", "", "", "", "", "", "", WP_IMPB_NO).ToList().FirstOrDefault();
                var result = R.getDetail(WP_PROJECT_JOB_ID);
                result.MasterData = MasterData;

                result.WorkingStr = GenerateWorkingTableString(result.project_list_working);
                result.IdentificationStr = GenerateHenkatenSafetyTableString(result.project_list_identification);
                result.ImpactStr = GenerateHenkatenEnvTableString(result.project_list_impact);
                result.Supervisionstr = GenerateSupervisionTableString(result.project_list_supervision);

                //string customeSwitch = "";

                //string footerPath = Server.MapPath("~/Views/WP02002/Footer.html");
                //customeSwitch = string.Format("--print-media-type --footer-html \"{0}\"", footerPath);

                return new ViewAsPdf("~/Views/WP02002/ReportIMPB.cshtml", result)
                {
                    FileName = "IMPB_" + DateTime.Now.ToString("yyyyMMddhhmm") + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Portrait,
                    PageMargins = new Rotativa.Options.Margins(10, 10, 30, 10),
                    //CustomSwitches = customeSwitch,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateWorkingTableString(List<working_model> data)
        {
            string DataWorking = "";
            var listworking = R.getWorkingType();

            foreach (var Working in data)
            {
                DataWorking += "<tr><td data-title='"+ Working.ID +"' name='"+ Working.ID_TB_M_WORKING_TYPE +"'>" + listworking.Where(w => w.ID_TB_M_WORKING_TYPE == Int32.Parse(Working.ID_TB_M_WORKING_TYPE)
                ).FirstOrDefault().WORKING_NAME + "</td>";

                if (Working.DANGER_TYPE == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td><td></td><td></td>";
                }
                else if (Working.DANGER_TYPE == "2")
                {
                    DataWorking += "<td></td><td style='text-align:center'>&radic;</td><td></td>";
                }
                else if (Working.DANGER_TYPE == "3")
                {
                    DataWorking += "<td></td><td></td><td style='text-align:center'>&radic;</td>";
                }

                if (Working.DAY_1 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.DAY_2 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.DAY_3 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.DAY_4 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.DAY_5 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.DAY_6 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.DAY_7 == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_A == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_B == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_C == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_D == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_E == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_F == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                if (Working.SIX_ALPHA == "1")
                {
                    DataWorking += "<td style='text-align:center'>&radic;</td>";
                }
                else
                {
                    DataWorking += "<td></td>";
                }

                DataWorking += "</tr>";
            }

            return DataWorking;
        } 

        private string GenerateHenkatenSafetyTableString(List<identification_model> data)
        {
            string DataIdentification = "";
            var listemp = R.getEmployee();
            var listworking = R.getWorkingType();
            int ctr = 1;

            foreach(var Iden in data)
            {
                DataIdentification += "<tr><td data-title='" + Iden.ID + "' name='" + Iden.ID_TB_M_WORKING_TYPE + "'>" + listworking.Where(w => w.ID_TB_M_WORKING_TYPE == Int32.Parse(Iden.ID_TB_M_WORKING_TYPE)
                ).FirstOrDefault().WORKING_NAME + "</td>";
                DataIdentification += "<td>" + Iden.IDENTITY_DANGER_POTENTIAL + "</td>";
                DataIdentification += "<td>" + Iden.IDENTITY_DANGER_PREVENTION + "</td>";
                DataIdentification += "<td>" + listemp.Where(w => w.ID_TB_M_EMPLOYEE == Int32.Parse(Iden.ID_TB_M_EMPLOYEE))
                    .FirstOrDefault().NAME + "</td>";
                
                if(ctr == 1)
                {
                    DataIdentification += "<td rowspan='3'>Henkaten Safety <br /><table width='100%' border='1'><tbody>";
                    DataIdentification += "<tr><td width='80%'>1.Perubahan Proses</td><td width='20%'>&radic;</td></tr><tr>";
                    DataIdentification += "<td width='80%'>2.Mesin Baru</td><td width='20%'>&radic;</td>";
                    DataIdentification += "</tr><tr><td width='80%'>3.Modifikasi M/C</td><td width='20%'>&radic;</td></tr></tbody><tfoot><tr>";
                    DataIdentification += "<td width='50%'>Henkaten No</td><td width='50%'></td></tr></tfoot></table></td></td>";
                }
                
                if (ctr > 3)
                {
                    DataIdentification += "<td></td>";
                }

                DataIdentification += "</tr>";
            }

            return DataIdentification;
        }

        private string GenerateHenkatenEnvTableString(List<impact_model> data)
        {
            string DataIdentification = "";
            var listemp = R.getEmployee();
            int ctr = 1;

            foreach (var Iden in data)
            {
                DataIdentification += "<tr><td>" + ctr.ToString() + ".</td>";
                DataIdentification += "<td>" + Iden.IDENTITY_IMPACT_POTENTIAL + "</td>";
                DataIdentification += "<td>" + Iden.IDENTITY_IMPACT_PREVENTION + "</td>";
                DataIdentification += "<td>" + listemp.Where(w => w.ID_TB_M_EMPLOYEE == Int32.Parse(Iden.ID_TB_M_EMPLOYEE))
                    .FirstOrDefault().NAME + "</td>";
                if (ctr == 1)
                {
                    DataIdentification += "<td rowspan='3'>Henkaten Env <br /><table width='100%' border='1'><tbody>";
                    DataIdentification += "<tr><td width='80%'>1.Penambahan Proses</td><td width='20%'>&radic;</td></tr><tr>";
                    DataIdentification += "<td width='80%'>2.Penambahan Jenis Material / Chemical</td><td width='20%'>&radic;</td>";
                    DataIdentification += "</tr><tr><td width='80%'>3.Mesin Baru</td><td width='20%'>&radic;</td></tr><tr><td width='80%'>";
                    DataIdentification += "4.Penambahan Bangunan</td><td width='20%'>&radic;</td></tr></tbody><tfoot><tr>";
                    DataIdentification += "<td width='50%'>Henkaten No</td><td width='50%'></td></tr></tfoot></table></td></td>";
                }

                if (ctr > 3)
                {
                    DataIdentification += "<td></td>";
                }
                DataIdentification += "</tr>";
            }

            return DataIdentification;
        }

        private string GenerateSupervisionTableString(List<pengawasan_model> data)
        {
            string DataIdentification = "";
            var listemp = R.getPengawas();
            int ctr = 1;

            foreach (var Iden in data)
            {
                var empsel = listemp.Where(w => w.ID_TB_M_EMPLOYEE == Int32.Parse(Iden.ID_TB_M_EMPLOYEE))
                    .FirstOrDefault();
                DataIdentification += "<tr><td>" + ctr.ToString() + ".</td>";
                DataIdentification += "<td>" + empsel.NAME + "</td>";
                DataIdentification += "<td>" + empsel.REG_NO+ "</td>";
                DataIdentification += "<td>" + empsel.PHONE + "</td>";
                DataIdentification += "<td>" + empsel.SECTION + "</td>";
                DataIdentification += "<td>" + empsel.ANZEN_SERTIFICATE_NO + "</td>";
                DataIdentification += "<td></td>";
                DataIdentification += "</tr>";
            }

            return DataIdentification;
        }

        [HttpGet]
        public ActionResult DeleteData(string ID,string Mode)
        {
            string Message = "";

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                if (Mode == "Working")
                {
                    WP02002Repository.DeleteWorkingList(ID, username);
                }
                else if (Mode == "Shift")
                {
                    WP02002Repository.DeleteShiftList(ID, username);
                }
                else if (Mode == "Identification")
                {
                    WP02002Repository.DeleteIdentificationList(ID, username);
                }
                else if (Mode == "Impact")
                {
                    WP02002Repository.DeleteImpactList(ID, username);
                }
                else if (Mode == "Supervision")
                {
                    WP02002Repository.DeleteSupervisionList(ID, username);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            
            return Json(new { Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataEmployee(string term, int company=0,string picstatus="",string companycode="",int EmployeeId = 0)
        {
            try
            {
                var ListEmployee = (List<EmployeeModel>)TempData["EmployeeList"];
                ListEmployee = ListEmployee == null ? R.getEmployee() : ListEmployee.ToList();
                var dataList = ListEmployee
                                    .Where(s => s.NAME.ToUpper().Contains(term.ToUpper()) && s.ID_TB_M_COMPANY == (company == 0 ? s.ID_TB_M_COMPANY : company)
                                    && s.PIC_STATUS == (string.IsNullOrEmpty(picstatus) ? s.PIC_STATUS : picstatus)
                                    && s.COMPANY_CODE.ToUpper() == (string.IsNullOrEmpty(companycode) ? s.COMPANY_CODE.ToUpper() : companycode.ToUpper())
                                    && s.ID_TB_M_EMPLOYEE == (EmployeeId == 0 ? s.ID_TB_M_EMPLOYEE : EmployeeId))
                                    .Select(x => new
                                    {
                                        id = x.ID_TB_M_EMPLOYEE,
                                        text = x.NAME,
                                        name = x.REG_NO + "," + x.PHONE + "," + x.SECTION + "," + x.ANZEN_SERTIFICATE_NO,
                                        code = x.COMPANY_CODE
                                    });
                return Json(dataList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDataEmployeeDetail(int EmployeeId)
        {
            try
            {
                var ListEmployee = (List<EmployeeModel>)TempData["EmployeeList"];
                ListEmployee = ListEmployee == null ? R.getEmployee() : ListEmployee.ToList();
                var dataList = ListEmployee
                                    .Where(s => s.ID_TB_M_EMPLOYEE == (EmployeeId == 0 ? s.ID_TB_M_EMPLOYEE : EmployeeId)).FirstOrDefault();
                return Json(dataList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
