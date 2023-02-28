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
using AI070.Models.DISR190001Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISR190001Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR190001Repository R = new DISR190001Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Cari ID Produksi";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string ID_PRODUKSI, string DMC_CODE, string DMC_PART, string LOT_NO, string KODE_PROSES, string KODE_MESIN, string WAKTU_MULAI, string WAKTU_SELESAI)
        {
            //Buat Paging//
            PagingModel_DISR190001 pg = new PagingModel_DISR190001(R.getCountDISR190001(DATA_ID, DMC_CODE, DMC_PART, LOT_NO, KODE_PROSES, KODE_MESIN, WAKTU_MULAI, WAKTU_SELESAI), start, display);

            //Munculin Data ke Grid//
            List<DISR190001Master> List = R.getDataDISR190001(pg.StartData, pg.EndData, ID_PRODUKSI, DMC_CODE, DMC_PART, LOT_NO, KODE_PROSES, KODE_MESIN, WAKTU_MULAI, WAKTU_SELESAI).ToList();
            ViewData["DataDISR190001"] = List;
            ViewData["PagingDISR190001"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion        

        #region Detail Data
        public virtual ActionResult GetDataDetail(string ID, string ID_HINMOKU, string LOT_NO)
        {
            //Get Detail Proses
            List<DISR190001Detail> GetData_Detail = R.GetData_Detail_ByID(ID).ToList();
            ViewData["Title"] = "Detail Cari ID Produksi";
            if (GetData_Detail.Count == 0)
            {
                //ViewData["Dmc_Type"] = "";
                ViewData["DataDetail"] = GetData_Detail;
            }
            else
            {
                //ViewData["ID_SEIHIN"] = GetData_Detail.FirstOrDefault().ID_SEIHIN.ToString();
                ViewData["DataDetail"] = GetData_Detail;
            }

            ViewData["ID_PRODUKSI"] = ID;
            ViewData["ID_HINMOKU"] = ID_HINMOKU;
            ViewData["LOT_NO"] = LOT_NO;
            
            //string LOT = GetData_Detail.FirstOrDefault().LOT.ToString();
            //ViewData["LOT"] = LOT;

            //Get Detail Parts
            List<DISR190001Detail_Parts> Get_Detail_Parts = R.GetData_Detail_ByCode(ID_HINMOKU).ToList();
            if (Get_Detail_Parts.Count == 0)
            {
                ViewData["Detail_Parts"] = Get_Detail_Parts;
            }
            else
            {
                ViewData["Detail_Parts"] = Get_Detail_Parts;
            }

            return PartialView("Datagrid_Data_Detail");
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

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                ViewData["EXECUTOR"] = R.getExecutor();  
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion        

        //#region Add New        
        //public ActionResult ADD_NEW(
        //    DateTime target_date,
        //    decimal target_amount,
        //    decimal target_print,
        //    decimal target_amount_jam_ke_1,
        //    decimal target_amount_jam_ke_2,
        //    decimal target_amount_jam_ke_3,
        //    decimal targer_amount_jam_ke_4,
        //    decimal target_amount_jam_ke_5,
        //    decimal target_amount_jam_ke_6,
        //    decimal target_amount_jam_ke_7,
        //    decimal target_amount_jam_ke_8,
        //    decimal target_amount_jam_ke_9,
        //    decimal terget_amount_jam_ke_10,
        //    decimal target_amount_jam_ke_11,
        //    decimal target_amount_jam_ke_12,
        //    decimal target_amount_jam_ke_13,
        //    decimal target_amount_jam_ke_14,
        //    decimal target_amount_jam_ke_15_16_istirahat,
        //    decimal target_amount_jam_ke_17,
        //    decimal target_amount_jam_ke_18,
        //    decimal target_amount_jam_ke_19,
        //    decimal target_amount_jam_ke_20,
        //    decimal target_amount_jam_ke_21,
        //    decimal target_amount_jam_ke_22
        //    )
        //{
        //    string sts = null;
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    //string pass = EncryptPassword(PASSWORD);
        //    try
        //    {
        //        string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
        //        var Exec = DISR190001Repository.Create(
        //             target_date,
        //             target_amount,
        //             target_amount_jam_ke_1,
        //             target_amount_jam_ke_2,
        //             target_amount_jam_ke_3,
        //             targer_amount_jam_ke_4,
        //             target_amount_jam_ke_5,
        //             target_amount_jam_ke_6,
        //             target_amount_jam_ke_7,
        //             target_amount_jam_ke_8,
        //             target_amount_jam_ke_9,
        //             terget_amount_jam_ke_10,
        //             target_amount_jam_ke_11,
        //             target_amount_jam_ke_12,
        //             target_amount_jam_ke_13,
        //             target_amount_jam_ke_14,
        //             target_amount_jam_ke_15_16_istirahat,
        //             target_amount_jam_ke_17,
        //             target_amount_jam_ke_18,
        //             target_amount_jam_ke_19,
        //             target_amount_jam_ke_20,
        //             target_amount_jam_ke_21,
        //             target_amount_jam_ke_22,
        //            username);
        //        sts = Exec[0].STACK;

        //        if (Exec[0].LINE_STS == "DUPLICATE")
        //        {
        //            var res = M.get_default_message("MWP004", "Master Qty Amount Target", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else if (Exec[0].STACK == "TRUE")
        //        {
        //            var res = M.get_default_message("MWP001", "Master Qty Amount Target", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else
        //        {
        //            message = Exec[0].LINE_STS;
        //        }
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        //#region Update Data
        //public ActionResult Update_Data(string DATA)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    var message = new object();
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    try
        //    {
        //        string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
        //        var Datas = DATA.Split(',');
        //        string ID = Datas[0];
        //        DateTime target_date = Datas[1];
        //        decimal target_amount = Datas[2];
        //        decimal target_print = Datas[3];
        //        decimal target_amount_jam_ke_1 = Datas[4];
        //        decimal target_amount_jam_ke_2 = Datas[5];
        //        decimal target_amount_jam_ke_3 = Datas[6];
        //        decimal targer_amount_jam_ke_4 = Datas[7];
        //        decimal target_amount_jam_ke_5 = Datas[8];
        //        decimal target_amount_jam_ke_6 = Datas[9];
        //        decimal target_amount_jam_ke_7 = Datas[10];
        //        decimal target_amount_jam_ke_8 = Datas[11];
        //        decimal target_amount_jam_ke_9 = Datas[12];
        //        decimal terget_amount_jam_ke_10 = Datas[13];
        //        decimal target_amount_jam_ke_11 = Datas[14];
        //        decimal target_amount_jam_ke_12 = Datas[15];
        //        decimal target_amount_jam_ke_13 = Datas[16];
        //        decimal target_amount_jam_ke_14 = Datas[17];
        //        decimal target_amount_jam_ke_15_16_istirahat = Datas[18];
        //        decimal target_amount_jam_ke_17 = Datas[19];
        //        decimal target_amount_jam_ke_18 = Datas[20];
        //        decimal target_amount_jam_ke_19 = Datas[21];
        //        decimal target_amount_jam_ke_20 = Datas[22];
        //        decimal target_amount_jam_ke_21 = Datas[23];
        //        decimal target_amount_jam_ke_22 = Datas[25];

        //        string STATUS = "1";
        //        var EXEC = R.Update_Data(
        //            ID,
        //            target_date,
        //            target_amount,
        //            target_amount_jam_ke_1,
        //            target_amount_jam_ke_2,
        //            target_amount_jam_ke_3,
        //            targer_amount_jam_ke_4,
        //            target_amount_jam_ke_5,
        //            target_amount_jam_ke_6,
        //            target_amount_jam_ke_7,
        //            target_amount_jam_ke_8,
        //            target_amount_jam_ke_9,
        //            terget_amount_jam_ke_10,
        //            target_amount_jam_ke_11,
        //            target_amount_jam_ke_12,
        //            target_amount_jam_ke_13,
        //            target_amount_jam_ke_14,
        //            target_amount_jam_ke_15_16_istirahat,
        //            target_amount_jam_ke_17,
        //            target_amount_jam_ke_18,
        //            target_amount_jam_ke_19,
        //            target_amount_jam_ke_20,
        //            target_amount_jam_ke_21,
        //            target_amount_jam_ke_22,
        //            STATUS,
        //            username);
        //        sts = EXEC[0].STACK;
        //        if (EXEC[0].STACK == "TRUE")
        //        {
        //            var res = M.get_default_message("MWP003", "Master Qty Amount Target", "", "");
        //            message = res[0].MSG_TEXT;
        //        }
        //        else
        //        {
        //            message = EXEC[0].LINE_STS;
        //        }


        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        //#region Delete Data
        //public ActionResult Delete_Data(string DATA)
        //{
        //    string stsRespon;
        //    var sts = new object();
        //    string message = null;
        //    username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
        //    List<DeleteModel> DELETE_MSG = new List<DeleteModel>();
        //    try
        //    {
        //        var Datas = DATA.Split(',');
        //        for (int i = 0; i < Datas.Count(); i++)
        //        {
        //            if (Datas[i] != "")
        //            {
        //                string DELETE = R.Delete_Data(Datas[i]);
        //                DELETE_MSG.Add(new DeleteModel { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
        //            }
        //        }

        //        sts = "TRUE";
        //        var res = M.get_default_message("MWP002", "Master Operator", "", "");
        //        message = res[0].MSG_TEXT;
        //    }
        //    catch (Exception M)
        //    {
        //        sts = "false";
        //        message = M.Message.ToString();
        //    }
        //    return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

    }
}