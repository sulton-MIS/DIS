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
using AI070.Models.DISR070003Master;
using System.Security.Cryptography;
using System.Text;

namespace AI070.Controllers
{
    public class DISR070003Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISR070003Repository R = new DISR070003Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Master Proses";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Search Data
        public ActionResult Search_Data(int start, int display, string DATA_ID, string id_kotei, string name_kotei, string halte, /*string id_koteishubetsu,*/string name_koteishubetsu, string flg_increByCavity, string rate_handankaishi, string rate_ALRTchien, string rate_chinritsu, string rate_warikomikyoyouritsu, string id_gamenshubetsu, string flg_RTJNon, string comment, string flg_rimen, string flg_need_tool,
                         string time_koshin, string flag_logical, string initial_process, string flg_check_schedule, string flg_disp_material, string flg_warning_material, string flg_daily_loss, string flg_oven, string group_process, string category, string sort_no, string flg_chokoritsu, string bgcolor, string group_process_cost, string type_process,
                         string category_process, string flg_protect_skill, string prod_cost_level, string flg_use_cl)
        {
            //Buat Paging//
            PagingModel_DISR070003 pg = new PagingModel_DISR070003(R.getCountDISR070003(DATA_ID, id_kotei, name_kotei, halte, /*id_koteishubetsu,*/name_koteishubetsu, flg_increByCavity, rate_handankaishi, rate_ALRTchien, rate_chinritsu, rate_warikomikyoyouritsu, id_gamenshubetsu, flg_RTJNon, comment, flg_rimen, flg_need_tool,
                         time_koshin, flag_logical, initial_process, flg_check_schedule, flg_disp_material, flg_warning_material, flg_daily_loss, flg_oven, group_process, category, sort_no, flg_chokoritsu, bgcolor, group_process_cost, type_process,
                         category_process, flg_protect_skill, prod_cost_level, flg_use_cl), start, display);

            //Munculin Data ke Grid//
            List<DISR070003Master> List = R.getDataDISR070003(pg.StartData, pg.EndData, id_kotei, name_kotei, halte, /*id_koteishubetsu,*/name_koteishubetsu, flg_increByCavity, rate_handankaishi, rate_ALRTchien, rate_chinritsu, rate_warikomikyoyouritsu, id_gamenshubetsu, flg_RTJNon, comment, flg_rimen, flg_need_tool,
                         time_koshin, flag_logical, initial_process, flg_check_schedule, flg_disp_material, flg_warning_material, flg_daily_loss, flg_oven, group_process, category, sort_no, flg_chokoritsu, bgcolor, group_process_cost, type_process,
                         category_process, flg_protect_skill, prod_cost_level, flg_use_cl).ToList();
            ViewData["DataDISR070003"] = List;
            ViewData["PagingDISR070003"] = pg;
            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW(
            string DATA_ID, 
            string id_kotei, 
            //int id_kotei, 
            string name_kotei, 
            string halte, 
            string id_koteishubetsu, 
            string flg_increByCavity, 
            /*string rate_handankaishi, 
             * string rate_ALRTchien, 
             * string rate_chinritsu, 
             * string rate_warikomikyoyouritsu,*/ 
            string id_gamenshubetsu, 
            string flg_RTJNon, 
            string comment, 
            string flg_rimen, 
            string flg_need_tool,
            /*string time_koshin,*/ 
            string flag_logical, 
            string initial_process, 
            string flg_check_schedule, 
            string flg_disp_material, 
            string flg_warning_material, 
            /*string flg_daily_loss,*/ 
            string flg_oven, 
            string group_process, 
            string category, 
            string sort_no, 
            string flg_chokoritsu, 
            string bgcolor, 
            string group_process_cost, 
            string type_process,
            string category_process, 
            /*string flg_protect_skill,*/ 
            string prod_cost_level, 
            string flg_use_cl)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISR070003Repository.Create(
                    DATA_ID, 
                    id_kotei, 
                    name_kotei, 
                    halte, 
                    id_koteishubetsu, 
                    flg_increByCavity, 
                    /*rate_handankaishi, rate_ALRTchien, rate_chinritsu, rate_warikomikyoyouritsu,*/ 
                    id_gamenshubetsu, 
                    flg_RTJNon, 
                    comment, 
                    flg_rimen, 
                    flg_need_tool,
                    /*time_koshin,*/ 
                    flag_logical, 
                    initial_process, 
                    flg_check_schedule, 
                    flg_disp_material, 
                    flg_warning_material, 
                    /*flg_daily_loss,*/ 
                    flg_oven, 
                    group_process, 
                    category, 
                    sort_no, 
                    flg_chokoritsu, 
                    bgcolor, 
                    group_process_cost, 
                    type_process,
                    category_process, 
                    /*flg_protect_skill,*/ 
                    prod_cost_level, 
                    flg_use_cl);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Kotei", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Kotei", "", "");
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
                //ViewData["COMPANY"] = R.getCompany();
                ViewData["EXECUTOR"] = R.getExecutor();
                //ViewData["IDENTITY"] = R.getIdentity();
                //ViewData["SECTION"] = R.getSection("TMMIN");
                //ViewData["PIC"] = R.getPIC();
                //ViewData["Division"] = R.getDivision();
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion


        #region Update Data
        public ActionResult Update_Data(string DATA)
        {
            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string id_kotei = Datas[1];
                string name_kotei = Datas[2];
                string halte = Datas[3];
                string id_koteishubetsu = Datas[4];
                string flg_increByCavity = Datas[5];
                string id_gamenshubetsu = Datas[6];
                string flg_RTJNon = Datas[7];
                string comment = Datas[8];
                string flg_rimen = Datas[9];
                string flg_need_tool = Datas[10];
                string flag_logical = Datas[11];
                string initial_process = Datas[12];
                string flg_check_schedule = Datas[13];
                string flg_disp_material = Datas[14];
                string flg_warning_material = Datas[15];
                string flg_oven = Datas[16];
                string group_process = Datas[17];
                string category = Datas[18];
                string sort_no = Datas[19];
                string flg_chokoritsu = Datas[20];
                string bgcolor = Datas[21];
                string group_process_cost = Datas[22];
                string type_process = Datas[23];
                string category_process = Datas[24];
                string prod_cost_level = Datas[25];
                string flg_use_cl = Datas[26];

                var EXEC = R.Update_Data(
                    ID,
                    id_kotei,
                    name_kotei,
                    halte,
                    id_koteishubetsu,
                    flg_increByCavity,
                    id_gamenshubetsu,
                    flg_RTJNon,
                    comment,
                    flg_rimen,
                    flg_need_tool,
                    flag_logical,
                    initial_process,
                    flg_check_schedule,
                    flg_disp_material,
                    flg_warning_material,
                    flg_oven,
                    group_process,
                    category,
                    sort_no,
                    flg_chokoritsu,
                    bgcolor,
                    group_process_cost,
                    type_process,
                    category_process,
                    prod_cost_level,
                    flg_use_cl
                );
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Kotei", "", "");
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
            string stsRespon;
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
                var res = M.get_default_message("MWP002", "Master Kotei", "", "");
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

    }
}