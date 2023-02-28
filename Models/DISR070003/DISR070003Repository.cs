using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR070003Master
{
    public class DISR070003Repository
    {
        #region Get_Data_Grid_DISR070003
        public List<DISR070003Master> getDataDISR070003(int Start, int Display, string id_kotei, string name_kotei, string halte, /*string id_koteishubetsu,*/string name_koteishubetsu, string flg_increByCavity, string rate_handankaishi, string rate_ALRTchien, string rate_chinritsu, string rate_warikomikyoyouritsu, string id_gamenshubetsu, string flg_RTJNon, string comment, string flg_rimen, string flg_need_tool,
                         string time_koshin, string flag_logical, string initial_process, string flg_check_schedule, string flg_disp_material, string flg_warning_material, string flg_daily_loss, string flg_oven, string group_process, string category, string sort_no, string flg_chokoritsu, string bgcolor, string group_process_cost, string type_process,
                         string category_process, string flg_protect_skill, string prod_cost_level, string flg_use_cl)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070003Master>("DISR070003/DISR070003_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                id_kotei,
                name_kotei,
                halte,
                //id_koteishubetsu,
                name_koteishubetsu,
                flg_increByCavity,
                rate_handankaishi,
                rate_ALRTchien,
                rate_chinritsu,
                rate_warikomikyoyouritsu,
                id_gamenshubetsu,
                flg_RTJNon,
                comment,
                flg_rimen,
                flg_need_tool,
                time_koshin,
                flag_logical,
                initial_process,
                flg_check_schedule,
                flg_disp_material,
                flg_warning_material,
                flg_daily_loss,
                flg_oven,
                group_process,
                category,
                sort_no,
                flg_chokoritsu,
                bgcolor,
                group_process_cost,
                type_process,
                category_process,
                flg_protect_skill,
                prod_cost_level,
                flg_use_cl
            });
            db.Close();
            return d.ToList();
        }

   
        #endregion

        #region Count_Get_Data_Grid_DISR070003
        public int getCountDISR070003(
            string DATA_ID, 
            string id_kotei, 
            string name_kotei, 
            string halte, 
            /*string id_koteishubetsu,*/
            string name_koteishubetsu, 
            string flg_increByCavity, 
            string rate_handankaishi, 
            string rate_ALRTchien, 
            string rate_chinritsu, 
            string rate_warikomikyoyouritsu, 
            string id_gamenshubetsu, 
            string flg_RTJNon, 
            string comment, 
            string flg_rimen, 
            string flg_need_tool,
            string time_koshin, 
            string flag_logical, 
            string initial_process, 
            string flg_check_schedule, 
            string flg_disp_material, 
            string flg_warning_material, 
            string flg_daily_loss, 
            string flg_oven, 
            string group_process, 
            string category, 
            string sort_no, 
            string flg_chokoritsu, 
            string bgcolor, 
            string group_process_cost, 
            string type_process,
            string category_process, 
            string flg_protect_skill, 
            string prod_cost_level, 
            string flg_use_cl
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR070003/DISR070003_SearchCount", new
            {
                DATA_ID = DATA_ID,
                id_kotei,
                name_kotei,
                halte,
                //id_koteishubetsu,
                name_koteishubetsu,
                flg_increByCavity,
                rate_handankaishi,
                rate_ALRTchien,
                rate_chinritsu,
                rate_warikomikyoyouritsu,
                id_gamenshubetsu,
                flg_RTJNon,
                comment,
                flg_rimen,
                flg_need_tool,
                time_koshin,
                flag_logical,
                initial_process,
                flg_check_schedule,
                flg_disp_material,
                flg_warning_material,
                flg_daily_loss,
                flg_oven,
                group_process,
                category,
                sort_no,
                flg_chokoritsu,
                bgcolor,
                group_process_cost,
                type_process,
                category_process,
                flg_protect_skill,
                prod_cost_level,
                flg_use_cl
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISR070003> Create(
            string DATA_ID,
            string id_kotei,
            //Int32 id_kotei, 
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
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070003>("DISR070003/DISR070003_Create", new
            {
                DATA_ID,
                id_kotei,
                name_kotei,
                halte,
                id_koteishubetsu,
                flg_increByCavity,
                //rate_handankaishi,
                //rate_ALRTchien,
                //rate_chinritsu,
                //rate_warikomikyoyouritsu,
                id_gamenshubetsu,
                flg_RTJNon,
                comment,
                flg_rimen,
                flg_need_tool,
                //time_koshin,
                flag_logical,
                initial_process,
                flg_check_schedule,
                flg_disp_material,
                flg_warning_material,
                //flg_daily_loss,
                flg_oven,
                group_process,
                category,
                sort_no,
                flg_chokoritsu,
                bgcolor,
                group_process_cost,
                type_process,
                category_process,
                //flg_protect_skill,
                prod_cost_level,
                flg_use_cl
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.SingleOrDefault<string>("DISR070003/DISR070003_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISR070003> Update_Data(
            string ID, 
            string id_kotei,
            string name_kotei,
            string halte,
            string id_koteishubetsu,
            string flg_increByCavity,
            string id_gamenshubetsu,
            string flg_RTJNon,
            string comment,
            string flg_rimen,
            string flg_need_tool,
            string flag_logical,
            string initial_process,
            string flg_check_schedule,
            string flg_disp_material,
            string flg_warning_material,
            string flg_oven,
            string group_process,
            string category,
            string sort_no,
            string flg_chokoritsu,
            string bgcolor,
            string group_process_cost,
            string type_process,
            string category_process,
            string prod_cost_level,
            string flg_use_cl
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070003>("DISR070003/DISR070003_Update", new
            {
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
                //flg_protect_skill,
                prod_cost_level,
                flg_use_cl
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        //#region Get Division
        //public List<DivisionModel> getDivision()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<DivisionModel>("DISR070001/DISR070001_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<CompanyModel>("DISR070001/DISR070001_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<IdentityModel>("DISR070001/DISR070001_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<SectionModel>("DISR070001/DISR070001_getSection", new
        //    {
        //        SYSTEM_CD
        //    });

        //    db.Close();
        //    return d.ToList();
        //}



        //#endregion

        //#region Get PIC
        //public List<PICModel> getPIC()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<PICModel>("DISR070001/DISR070001_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ExecutorModel>("DISR070003/DISR070003_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    //public class StatusModel
    //{
    //    public string ID { get; set; }
    //    public string Status { get; set; }
    //}

    //public class DivisionModel
    //{
    //    public string Division { get; set; }
    //    public string DIV { get; set; }
    //    public string DIV_ID { get; set; }
    //}

    //public class CompanyModel
    //{
    //    public string ID { get; set; }
    //    public string COMPANY { get; set; }
    //}

    //public class IdentityModel
    //{
    //    public string ID { get; set; }
    //    public string IDENTITY_TEXT { get; set; }
    //}

    //public class PICModel
    //{
    //    public string ID { get; set; }
    //    public string PIC_TEXT { get; set; }
    //}

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    //public class SectionModel
    //{
    //    public string ID { get; set; }
    //    public string SECTION_TEXT { get; set; }
    //}

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISR070003
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR070003(int countdata, int positionpage, int dataperpage)
        {
            List<int> list = new List<int>();
            EndData = positionpage * dataperpage;
            CountData = countdata;
            PositionPage = positionpage;
            StartData = (positionpage - 1) * dataperpage + 1;
            Double jml = countdata / dataperpage;
            if (countdata % dataperpage > 0)
            {
                jml = jml + 1;
            }

            for (int i = 0; i < jml; i++)
            {
                list.Add(i);
            }
            ListIndex = list;
        }
    }
}