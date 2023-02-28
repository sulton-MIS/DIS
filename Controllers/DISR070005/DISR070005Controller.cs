using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
using System.IO;
//using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.DISR070005Master;
//using System.Security.Cryptography;w
//using System.Text;

//using Toyota.Common.Database;

//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Validation;
//using System.Data.OleDb;
//using System.Net;
//using System.Text.RegularExpressions;
//using LinqToExcel;
//using System.Data.SqlClient;
//using System.Configuration;

using System.Drawing;
using System.Drawing.Printing;
using Newtonsoft.Json;
using Neodynamic.SDK.Web;

namespace AI070.Controllers
{
    public class DISR070005Controller : PageController
    {

        //private TxDTIPRDEntities3 db = new TxDTIPRDEntities3();
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR070005Repository R = new DISR070005Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        private Font printFontKode;
        private Font printFontNama;
        private StreamReader streamToPrint;
        static string filePath;
        string kode_tools;
        string nama_tools;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Tools Sapan / Nukigata";
                ViewData["Title"] = Settings.Title;
                ViewData["dmc_type"] = R.getDmcTypeItemMaster();
                GetDataHeader();
                getPrinter();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ID_TOOL, string NAME_TOOL, string FACTORY)
        {
            //Buat Paging//
            PagingModel_DISR070005 pg = new PagingModel_DISR070005(R.getCountDISR070005(
                DATA_ID, 
                ID_TOOL,
                NAME_TOOL,
                FACTORY), start, display);

            //Munculin Data ke Grid//
            List<DISR070005Master> List = R.getDataDISR070005(
                pg.StartData, 
                pg.EndData, 
                ID_TOOL,
                NAME_TOOL,
                FACTORY).ToList();
            ViewData["DataDISR070005"] = List;
            ViewData["PagingDISR070005"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Tambah Data (Multiple Insert Data)
        public ActionResult Insert_Data_Detail_Tool()
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            

            //CREATE DATA DETAIL TOOLS FGS
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var items = JsonConvert.DeserializeObject<DISA10001_TOOL_INPUT_FORM>(json);
                var Exec = DISR070005Repository.Create_Detail_Request(items);
                sts = "TRUE";
                message = "Data berhasil disimpan!";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }

            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW(string ID_TOOL, string NAME_TOOL, string FACTORY, string LIFETIME, string LIMIT, string STATUS, string TIME_KOSHIN)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISR070005Repository.Create(
                                                        ID_TOOL,
                                                        NAME_TOOL,
                                                        FACTORY,
                                                        LIFETIME,                                                        
                                                        LIMIT,
                                                        STATUS,
                                                        TIME_KOSHIN,
                                                        username
                                                        );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Tool Sappan / Nukigata", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Tool Sappan / Nukigata", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
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
        public ActionResult Update_Data(string DATA)
        {            
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string ID_TOOL = Datas[1];
                string NAME_TOOL = Datas[2];
                string FACTORY = Datas[3];                
                string LIFETIME = Datas[4];               
                string LIMIT = Datas[5];
                string STATUS = Datas[6];

                var EXEC = R.Update_Data(ID, ID_TOOL, NAME_TOOL, FACTORY, LIFETIME, LIMIT, STATUS, username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Tools Sappan / Nukigata", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data(string DATA)
        {            
            var sts = new object();
            string message = null;

            
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R.Delete_Data(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Tools Sappan / Nukigata", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Print Data   

        public ActionResult getPrinter()
        {
            ViewBag.WCPScript = WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), Url.Action("PrintImage", "PrintHtmlCards", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);

            return View();
        }

        public void Print_Data(string DATA, int KALI_PRINT)
        {
            var sts = new object();
            string message = null;

            for (int j = 0; j < KALI_PRINT; j++)
            {            
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        kode_tools = "* " + Datas[i] + " *";

                        List<DISR070005Master> NamaTools = R.getNameToolDISR070005(Datas[i]).ToList();
                        if (NamaTools.Count > 0)
                        {
                            foreach (DISR070005Master T in NamaTools)
                            {
                                nama_tools = T.NAME_TOOL;
                            }
                        }
                   
                        try
                        {                                          
                            PrintDocument pd = new PrintDocument();
                            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);                            
                            pd.Print();                     
                        }
                        catch (Exception M)
                        {
                            sts = "false";
                            message = M.Message.ToString();
                        }
                    }
                }
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Rectangle rect_kode = new Rectangle(310, 30, 250, 0);
            Rectangle rect_nama = new Rectangle(310, 60, 250, 0);

            // Create a StringFormat object with the each line of text, and the block
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            printFontKode = new Font("IDAHC39M Code 39 Barcode", 8);
            printFontNama = new Font("CIDFont+F1", 6);

            //float kode_leftMargin = 350;
            //float kode_topMargin = 20;

            //float nama_leftMargin = 330;
            //float nama_topMargin = 60;

            ev.Graphics.DrawString(kode_tools, printFontKode, Brushes.Black, rect_kode, stringFormat);
            ev.Graphics.DrawString(nama_tools, printFontNama, Brushes.Black, rect_nama, stringFormat);      
        }

       
        #endregion

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }

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

    }
}