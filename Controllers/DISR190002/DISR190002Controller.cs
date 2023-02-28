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
using AI070.Models.DISR190002Master;
using System.Security.Cryptography;
using System.Text;
using Rotativa.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Printing;
using Neodynamic.SDK.Web;
using System.Diagnostics;

using LinqToExcel;
using System.Drawing;
using System.Drawing.Printing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Management;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Data;
using SautinSoft;
using Microsoft.Win32;
using GemBox.Spreadsheet;
//using Microsoft.Extensions.Caching.Memory;

namespace AI070.Controllers
{
    public class DISR190002Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR190002Repository R = new DISR190002Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        private Font printFontKode;
        private Font printFontNama;
        private StreamReader streamToPrint;
        static string filePath;


        protected override void Startup()
        {  
            try
            {
                Settings.Title = "Label Chukan";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();

            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);

                ViewData["all_tipe"] = R.get_Data_All_Tipe();

                var gethostname = Dns.GetHostEntry(Dns.GetHostName());
                string hostname = gethostname.HostName;

                var ip_address = GetLocalIPAddress();
                ViewData["printers"] = getListPrinter(hostname, ip_address);

                //## Detection WCPP Method ##
                ViewBag.WCPPDetectionScript = Neodynamic.SDK.Web.WebClientPrint.CreateWcppDetectionScript(Url.Action("ProcessRequest", "", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);
                //ViewData["WCPPDetectionScript"] = Neodynamic.SDK.Web.WebClientPrint.CreateWcppDetectionScript(Url.Action("ProcessRequest", "", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);

                //## Printer Neodynamic Method ##
                ViewBag.WCPScript = Neodynamic.SDK.Web.WebClientPrint.CreateScript(Url.Action("ProcessRequest", "", null, HttpContext.Request.Url.Scheme), Url.Action("PrintFile", "DISR190002", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);
                //ViewData["WCPScript"] = Neodynamic.SDK.Web.WebClientPrint.CreateScript(Url.Action("ProcessRequest", "", null, HttpContext.Request.Url.Scheme), Url.Action("PrintFile", "DISR190002", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);


            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        [AllowAnonymous]
        public void ProcessRequest()
        {
            //get session ID
            string sessionID = (HttpContext.Request["sid"] != null ? HttpContext.Request["sid"] : null);

            //get Query String
            string queryString = HttpContext.Request.Url.Query;

            try
            {
                //Determine and get the Type of Request 
                RequestType prType = WebClientPrint.GetProcessRequestType(queryString);

                if (prType == RequestType.GenPrintScript ||
                    prType == RequestType.GenWcppDetectScript)
                {
                    //Let WebClientPrint to generate the requested script
                    byte[] script = WebClientPrint.GenerateScript(Url.Action("ProcessRequest", "", null, HttpContext.Request.Url.Scheme), queryString);

                    HttpContext.Response.ContentType = "text/javascript";
                    HttpContext.Response.BinaryWrite(script);
                    HttpContext.Response.End();
                }
                else if (prType == RequestType.ClientSetWcppVersion)
                {
                    //This request is a ping from the WCPP utility
                    //so store the session ID indicating it has the WCPP installed
                    //also store the WCPP Version if available
                    string wcppVersion = HttpContext.Request["wcppVer"];
                    if (string.IsNullOrEmpty(wcppVersion))
                        wcppVersion = "1.0.0.0";

                    HttpContext.Application.Set(sessionID + "wcppInstalled", wcppVersion);
                }
                else if (prType == RequestType.ClientSetInstalledPrinters)
                {
                    //WCPP Utility is sending the installed printers at client side
                    //so store this info with the specified session ID
                    string printers = HttpContext.Request["printers"];
                    if (string.IsNullOrEmpty(printers) == false)
                        printers = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(printers));

                    HttpContext.Application.Set(sessionID + "printers", printers);

                }
                else if (prType == RequestType.ClientSetInstalledPrintersInfo)
                {
                    //WCPP Utility is sending the client installed printers with detailed info
                    //so store this info with the specified session ID
                    //Printers Info is in JSON format
                    string printersInfo = HttpContext.Request.Params["printersInfoContent"];

                    if (string.IsNullOrEmpty(printersInfo) == false)
                        printersInfo = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(printersInfo));

                    HttpContext.Application.Set(sessionID + "printersInfo", printersInfo);


                }
                else if (prType == RequestType.ClientGetWcppVersion)
                {
                    //return the WCPP version for the specified sid if any
                    bool sidWcppVersion = (HttpContext.Application.Get(sessionID + "wcppInstalled") != null);

                    HttpContext.Response.ContentType = "text/plain";
                    HttpContext.Response.Write((sidWcppVersion ? HttpContext.Application.Get(sessionID + "wcppInstalled") : ""));
                    HttpContext.Response.End();

                }
                else if (prType == RequestType.ClientGetInstalledPrinters)
                {
                    //return the installed printers for the specified sid if any
                    bool sidHasPrinters = (HttpContext.Application.Get(sessionID + "printers") != null);

                    HttpContext.Response.ContentType = "text/plain";
                    HttpContext.Response.Write((sidHasPrinters ? HttpContext.Application.Get(sessionID + "printers") : ""));
                    HttpContext.Response.End();
                }
                else if (prType == RequestType.ClientGetInstalledPrintersInfo)
                {
                    //return the installed printers with detailed info for the specified Session ID (sid) if any
                    bool sidHasPrinters = (HttpContext.Application[sessionID + "printersInfo"] != null);

                    HttpContext.Response.ContentType = "text/plain";
                    HttpContext.Response.Write(sidHasPrinters ? HttpContext.Application[sessionID + "printersInfo"] : "");

                }

            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.Write(ex.Message + " - StackTrace: " + ex.StackTrace);
                HttpContext.Response.End();
            }
        }


        #region Get Information Data Asset 
        public ActionResult get_Tipe(string ID_SEISAN)
        {
            var data = R.get_Data_Tipe(ID_SEISAN);
            return Json(new { data, ID_SEISAN }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Information Data Asset 
        public ActionResult get_All_Tipe()
        {
            var data = R.get_Data_All_Tipe();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ID_SEISAN, string ID_HINMOKU)
        {
            //Buat Paging//
            PagingModel_DISR190002 pg = new PagingModel_DISR190002(R.getCountDISR190002(DATA_ID, ID_SEISAN, ID_HINMOKU), start, display);

            //Munculin Data ke Grid//
            List<DISR190002Master> List = R.getDataDISR190002(pg.StartData, pg.EndData, ID_SEISAN, ID_HINMOKU).ToList();
            ViewData["DataDISR190002"] = List;
            ViewData["PagingDISR190002"] = pg;

            var item_code = "";

            if (List.Count > 0)
            {
                item_code = List.FirstOrDefault().ID_HINMOKU.ToString();
            }

            //var model = new Models.DISR190002Master.DISR190002Master();

            if (item_code != "")
            {
                List<DISR190002Similar_Type> ListSimilar = R.GetData_Similar_ByCode(item_code).ToList();
                //ViewBag.ListSimilar = R.GetData_Similar_ByCode(item_code);

                ViewData["DataSimilar"] = ListSimilar;
            }



            return PartialView("Datagrid_Data", pg.CountData);
            //return PartialView("Datagrid_Data");
        }
        #endregion

        #region Search Data Item Code
        //public ActionResult Search_Data_ItemCode(int start, int display, string DATA_ID, string CODE)
        //{
        //    //Buat Paging//
        //    PagingModel_DISR190002 pg = new PagingModel_DISR190002(R.getCountDISR190002_ItemCode(DATA_ID, CODE), start, display);

        //    //Munculin Data ke Grid//
        //    List<DISR190002Master> List = R.getDataDISR190002_ItemCode(pg.StartData, pg.EndData, CODE).ToList();
        //    ViewData["DataDISR190002"] = List;
        //    ViewData["PagingDISR190002"] = pg;
        //    return PartialView("Datagrid_Data_Similar", pg.CountData);
        //}
        #endregion

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

        #region IP Address User
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion

        //#region List Printer Installed (Server Side)
        //public List<string> getListPrinter(string hostname, string ip_address)
        //{
        //    List<string> ListPrinter = new List<string>();

        //    string sts = null;
        //    string message = null;
        //    ConnectionOptions co = new ConnectionOptions();
        //    co.EnablePrivileges = true;
        //    co.Impersonation = ImpersonationLevel.Impersonate;
        //    System.Net.IPHostEntry h = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        //    string IPAddress = h.AddressList.GetValue(0).ToString();
        //    string lm = System.Net.Dns.GetHostName().ToString();

        //    string sid;
        //    string user_sid;

        //    try
        //    {
        //        var user = WindowsIdentity.GetCurrent().User;
        //        user_sid = UserPrincipal.Current.Sid.ToString();

        //        String checkInstalledPrinters;
        //        for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
        //        {
        //            checkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
        //            ListPrinter.Add(checkInstalledPrinters);
        //        }

        //    }
        //    catch (Exception M)
        //    {
        //        M.Message.ToString();
        //    }

        //    return ListPrinter.ToList();
        //}

        //#endregion


        #region List Printer Installed (Client Side)
        public List<string> getListPrinter(string hostname, string ip_address)
        {
            List<string> ListPrinter = new List<string>();

            string sts = null;
            string message = null;
            ConnectionOptions co = new ConnectionOptions();
            co.EnablePrivileges = true;
            co.Impersonation = ImpersonationLevel.Impersonate;
            System.Net.IPHostEntry h = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string IPAddress = h.AddressList.GetValue(0).ToString();
            string lm = System.Net.Dns.GetHostName().ToString();

            string sid;
            string user_sid;

            string computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Replace(lm, "");  //clients machine name

            try
            {
                var user = WindowsIdentity.GetCurrent().User;
                user_sid = UserPrincipal.Current.Sid.ToString();

                //NTAccount ntuser = new NTAccount(user_sid);
                //SecurityIdentifier sID = (SecurityIdentifier)ntuser.Translate(typeof(SecurityIdentifier));
                //sid = sID.ToString();

                ManagementScope myScope = new ManagementScope("\\\\" + hostname + "\\root\\default", co);
                ManagementPath mypath = new ManagementPath("StdRegProv");
                ManagementClass wmiRegistry = new ManagementClass(myScope, mypath, null);
                const uint HKEY_LOCAL_MACHINE = unchecked((uint)0x80000002);

                string keyPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\Client Side Rendering Print Provider\\" + user_sid + "\\Printers\\Connections";
                object[] methodArgs = new object[] { HKEY_LOCAL_MACHINE, keyPath, null };
                uint returnValue = (uint)wmiRegistry.InvokeMethod("EnumKey", methodArgs);

                if (null != methodArgs[2])
                {
                    string[] subKeys = methodArgs[2] as String[];

                    if (subKeys == null)
                    {
                        message = "No Printers Found";
                        //return null;
                        return null;
                    }

                    ManagementBaseObject inParam = wmiRegistry.GetMethodParameters("GetStringValue");
                    inParam["hDefKey"] = HKEY_LOCAL_MACHINE;

                    string keyName = "";
                    foreach (string subKey in subKeys)
                    {
                        //Display application name
                        keyPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\Client Side Rendering Print Provider\\" + user_sid + "\\Printers\\Connections" + subKey;
                        keyName = "DisplayName";
                        inParam["sSubKeyName"] = keyPath;
                        inParam["sValueName"] = keyName;
                        ManagementBaseObject outParam = wmiRegistry.InvokeMethod("GetStringValue", inParam, null);

                        var printer = subKey.Replace(',', '\\');

                        ListPrinter.Add(printer);
                    }
                }
                else
                {
                    message = "No Printers Found";
                }

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }

            return ListPrinter.ToList();
        }

        #endregion

        #region Printout To Printer  
        public ActionResult Print_Data(string PRINTER_NAME, string ID_SEISAN, string ID_HINMOKU, string OTHER_LOTNO, string LOT_IHOUSE,
            string QTY, string ADM_IT, string SIMILAR_CHECKED, string SIMILAR, string OPT_PRESS,
            string OPT_LAM, string TINTA_DOT, string QTY_PRINT,
            string GLASS_BUWON_CHECKED, string GLASS_BUWON, string AFTER_LAMINATE_CHECKED, string AFTER_LAMINATE,
            string display_special_print, string chekPengganti, string PENGGANTI1, string PENGGANTI2,
            string chekTambahan, string TAMBAHAN1, string TAMBAHAN2, string TAMBAHAN3)
        {
            List<string> ListFile = new List<string>();

            string sts = null;
            string message = null;
            string PENGGANTI = null;
            string TAMBAHAN = null;

            string filename = null;

            string jenis_label = "";

            //or if you use asp.net, get the relative path
            string filePath = "";
            if (ID_SEISAN.Contains("-010-") || ID_SEISAN.Contains("-012-") || ID_SEISAN.Contains("-014-") ||
                ID_SEISAN.Contains("-110-") || ID_SEISAN.Contains("-111-") || ID_SEISAN.Contains("-115-") ||
                ID_SEISAN.Contains("-114-"))
            {
                filePath = Server.MapPath("~/Content/TemplateReport/Label_Chukan/printlabelChukan_New_tail.xlsx");
                jenis_label = "tail";
            }
            else
            {
                filePath = Server.MapPath("~/Content/TemplateReport/Label_Chukan/printlabelChukan_New_film_glass.xlsx");
                jenis_label = "film";
            }

            //Check Special Print
            int URUTAN_TAMBAHAN = 1;
            if (display_special_print != "false")
            {
                if (chekPengganti != "false")
                {
                    QTY_PRINT = "1";
                }
                else if (chekTambahan != "false")
                {
                    //Get Urutan Tambahan
                    if (TAMBAHAN1 != "")
                    {
                        URUTAN_TAMBAHAN = int.Parse(TAMBAHAN1);
                    }

                    if (TAMBAHAN2 != "")
                    {
                        QTY_PRINT = TAMBAHAN2;
                    }
                }
            }

            for (int j = URUTAN_TAMBAHAN; j <= int.Parse(QTY_PRINT); j++)
            {
                //Delay Before Looping (milisecond (1 second))
                System.Threading.Thread.Sleep(1000);

                //create filename
                filename = "Label Chukan_" + DateTime.Now.ToString("yyyyMMdd_hhmmss_") + j + ".xlsx";

                //create a fileinfo object of an excel file on the disk
                FileInfo file = new FileInfo(filePath);

                byte[] FileBytesArray;
                //create a new Excel package from the file
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    //create an instance of the the first sheet in the loaded file
                    OfficeOpenXml.ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    //add some data
                    worksheet.Cells["B2"].Value = ID_HINMOKU;
                    worksheet.Cells["B4"].Value = "*" + ID_SEISAN + "*";
                    worksheet.Cells["B5"].Value = ADM_IT;
                    worksheet.Cells["B6"].Value = OPT_PRESS;
                    worksheet.Cells["B8"].Value = OPT_LAM;
                    worksheet.Cells["B9"].Value = TINTA_DOT;
                    worksheet.Cells["D5"].Value = OTHER_LOTNO;
                    worksheet.Cells["D6"].Value = QTY;
                    worksheet.Cells["F2"].Value = GLASS_BUWON;


                    //Lot Ihouse
                    if (LOT_IHOUSE != "")
                    {
                        worksheet.Cells["E5"].Value = LOT_IHOUSE;

                        //Similar
                        if (SIMILAR != "")
                        {
                            worksheet.Cells["E6"].Value = SIMILAR;
                        }
                        else
                        {
                            worksheet.Cells["E6"].Value = "";
                        }
                    }
                    else
                    {
                        //Similar
                        if (SIMILAR != "")
                        {
                            worksheet.Cells["E5"].Value = SIMILAR;
                        }
                        else
                        {
                            worksheet.Cells["E5"].Value = "";
                        }
                    }

                    worksheet.Cells["C8"].Value = AFTER_LAMINATE;

                    //Special Print Checked
                    if (display_special_print == "false") //bukan special print
                    {
                        worksheet.Cells["E8"].Value = j + "/" + QTY_PRINT;
                    }
                    else //special print
                    {
                        if (chekPengganti != "false")
                        {
                            worksheet.Cells["E8"].Value = PENGGANTI1 + "/" + PENGGANTI2;
                        }
                        else if (chekTambahan != "false")
                        {
                            worksheet.Cells["E8"].Value = j + "/" + TAMBAHAN3;

                            if (j > int.Parse(QTY_PRINT))
                            {
                                return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
                            }

                        }
                    }

                    //save the changes
                    FileBytesArray = excelPackage.GetAsByteArray();

                    //Create Temp File
                    var pathFolder = Server.MapPath("~/Content/Upload/Label_Chukan_temp/");
                    System.IO.File.WriteAllBytes(pathFolder + filename, FileBytesArray);

                    //Convert File To PDF
                    //filename = convertToPdf(pathFolder, filename);

                    try
                    {
                        ListFile.Add(pathFolder + filename);

                        //Print File
                        //PrintFiletoPrinter(PRINTER_NAME, pathFolder, filename);

                        sts = "true";
                    }
                    catch (Exception M)
                    {
                        sts = "false";
                        message = M.Message.ToString();
                    }

                }
            }

            return Json(new { sts, message, ListFile }, JsonRequestBehavior.AllowGet);
        }
        
        private string convertToPdf(string path, string file)
        {
            string extension = System.IO.Path.GetExtension(path + file);
            string new_filePDF = file.Substring(0, file.Length - extension.Length) + ".pdf"; //new file pdf

            SautinSoft.ExcelToPdf excelFile = new SautinSoft.ExcelToPdf();
            excelFile.ConvertFile(path + file, path + new_filePDF);

            return new_filePDF;
        }

        [AllowAnonymous]
        public void PrintFile(string PRINTER_NAME, string Pathfile)
        {
            string sts = null;
            string message = null;

            try
            {
                string printerName = PRINTER_NAME;
                string pagesFrom = "1";
                string pagesTo = "1";
                string new_fileName = Guid.NewGuid().ToString("N");
                
                PrintFileXLS file = new PrintFileXLS(System.Web.HttpContext.Current.Server.MapPath(Pathfile), new_fileName);
                if (string.IsNullOrEmpty(pagesFrom) == false)
                    file.PagesFrom = int.Parse(pagesFrom);
                if (string.IsNullOrEmpty(pagesTo) == false)
                    file.PagesTo = int.Parse(pagesTo);

                ClientPrintJob cpj = new ClientPrintJob();
                cpj.PrintFile = file;
                if (printerName == "null")
                    cpj.ClientPrinter = new DefaultPrinter();
                else
                {
                    cpj.ClientPrinter = new InstalledPrinter(printerName);
                }

                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.BinaryWrite(cpj.GetContent());
                System.Web.HttpContext.Current.Response.End();
                
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
        }
        
        //protected void PrintFiletoPrinter(string PRINTER_NAME, string pathFolder, string filename)
        //{
        //    string sts = null;
        //    string message = null;

        //    try
        //    {
        //        // If using Professional version, put your serial key below.
        //        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

        //        // Load Excel workbook from file's path.
        //        ExcelFile workbook = ExcelFile.Load(pathFolder + filename);

        //        // Set sheets print options.
        //        foreach (GemBox.Spreadsheet.ExcelWorksheet worksheet in workbook.Worksheets)
        //        {
        //            ExcelPrintOptions sheetPrintOptions = worksheet.PrintOptions;

        //            sheetPrintOptions.Portrait = true;

        //            //sheetPrintOptions.HorizontalCentered = true;
        //            //sheetPrintOptions.VerticalCentered = true;

        //            //sheetPrintOptions.PrintHeadings = true;
        //            //sheetPrintOptions.PrintGridlines = true;
        //        }

        //        // Create spreadsheet's print options. 
        //        PrintOptions printOptions = new PrintOptions();
        //        printOptions.SelectionType = SelectionType.ActiveSheet;

        //        // Print Excel workbook to default printer (e.g. 'Microsoft Print to Pdf').
        //        string printerName = PRINTER_NAME; //isi null untuk default printer
        //        workbook.Print(printerName, printOptions);

        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //}

        public string CheckPrinterConfiguration(string printerIP, string printerName)
        {
            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[]
            { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            string fulllName = queues.Where(q => q.Name == printerName &&
            q.QueuePort.Name == printerIP).Select(q => q.FullName).FirstOrDefault();
            return fulllName;
        }

        public ActionResult deleteFiles()
        {
            string sts = null;
            string message = null;

            //Get Name Directory
            var pathFolder = Server.MapPath("~/Content/Upload/Label_Chukan_temp/");
            System.IO.DirectoryInfo directory = new DirectoryInfo(pathFolder);

            //var pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            //System.IO.DirectoryInfo directory = new DirectoryInfo(@"D:\Output Label Chukan\");
            try
            {
                //Delete Files
                foreach (FileInfo file_label_chukan in directory.EnumerateFiles())
                {
                    //Delete temp files
                    if (file_label_chukan.Name.Contains("Label Chukan"))
                    {
                        file_label_chukan.Delete();
                    }
                }

                sts = "true";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }

            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}