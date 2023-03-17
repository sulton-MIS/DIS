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
using AI070.Models.DISA140001Master;
using System.Security.Cryptography;
using System.Text;

using Toyota.Common.Database;

using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Net;
using System.Text.RegularExpressions;
using LinqToExcel;
using System.Data.SqlClient;
using System.Configuration;

using System.Drawing;
using System.Drawing.Printing;
using Newtonsoft.Json;

namespace AI070.Controllers
{
    public class DISA140001Controller : PageController
    {
        //private TxDTIPRDEntities3 db = new TxDTIPRDEntities3();
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA140001Repository R = new DISA140001Repository();
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
                Settings.Title = "Label Gaikan";
                ViewData["Title"] = Settings.Title;
                ViewData["id_sagyosha"] = R.getListNik();
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Get Data Operator 
        public ActionResult get_Data_Operator(string id_sagyosha)
        {
            var data = R.get_Data_Operator(id_sagyosha);
            return Json(new { data, id_sagyosha }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ID_PRODUKSI, string TIPE, string NIK, string NAMA, string SERIAL_NO, string SHIFT, string FROM_DATE, string END_DATE)
        {
            //Buat Paging//
            PagingModel_DISA140001 pg = new PagingModel_DISA140001(R.getCountDISA140001(
                DATA_ID, 
                ID_PRODUKSI,
                TIPE,
                NIK,
                NAMA,
                SERIAL_NO,
                SHIFT,  
                FROM_DATE,
                END_DATE), start, display);

            //Munculin Data ke Grid//
            List<DISA140001Master> List = R.getDataDISA140001(
                pg.StartData, 
                pg.EndData,
                ID_PRODUKSI,
                TIPE,
                NIK,
                NAMA,
                SERIAL_NO,
                SHIFT,
                FROM_DATE,
                END_DATE).ToList();
            ViewData["DataDISA140001"] = List;
            ViewData["PagingDISA140001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion
       
        #region Add New        
        public ActionResult ADD_NEW(string ID_PRODUKSI, string ID_PROSES, string NAMA_PROSES, string TIPE, string NIK, string NAMA, string SERIAL_NO, string LOTTO, string QTY, string TOTAL_BERAT, string KETERANGAN, string SHIFT)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();            

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA140001Repository.Create(
                                                        ID_PRODUKSI,
                                                        ID_PROSES,
                                                        NAMA_PROSES,
                                                        TIPE,                                                        
                                                        NIK,
                                                        NAMA,
                                                        SERIAL_NO,
                                                        LOTTO,
                                                        QTY,
                                                        TOTAL_BERAT,
                                                        KETERANGAN,
                                                        SHIFT,
                                                        username                                                        
                                                        );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Label Gaikan", "", "");
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
                string ID_PRODUKSI = Datas[1];
                string ID_PROSES = Datas[2];
                string NAMA_PROSES = Datas[3];                
                string TIPE = Datas[4];               
                string NIK = Datas[5];
                string NAMA = Datas[6];
                string SERIAL_NO = Datas[7];
                string LOTTO = Datas[8];
                string QTY = Datas[9];
                string TOTAL_BERAT = Datas[10];
                string KETERANGAN = Datas[11];
                string SHIFT = Datas[12];

                var EXEC = R.Update_Data(
                    ID, 
                    ID_PRODUKSI,
                    ID_PROSES,
                    NAMA_PROSES,
                    TIPE,
                    NIK,
                    NAMA,
                    SERIAL_NO,
                    LOTTO,
                    QTY,
                    TOTAL_BERAT,
                    KETERANGAN,
                    SHIFT,
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Label Gaikan", "", "");
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
                var res = M.get_default_message("MWP002", "Label Gaikan", "", "");
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

                        List<DISA140001Master> NamaTools = R.getNameToolDISA140001(Datas[i]).ToList();
                        if (NamaTools.Count > 0)
                        {
                            foreach (DISA140001Master T in NamaTools)
                            {
                                //nama_tools = T.NAME_TOOL;
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

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            printFontKode = new Font("IDAHC39M Code 39 Barcode", 8);
            printFontNama = new Font("CIDFont+F1", 6);

            //PRINT KODE
            ev.Graphics.DrawString(kode_tools, printFontKode, Brushes.Black, rect_kode, stringFormat);
            //PRINT NAMA
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