using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA090001Master
{
    public class DISA090001Repository
    {
        #region Get_Data_Grid_DISA090001
        public List<DISA090001Master> getDataDISA090001(
            int Start, 
            int Display,
            string TARGET_DATE,
            string TARGET_PRINT_QTY,
            string TARGET_QTY_JAM_KE_1,
            string TARGET_AMOUNT_JAM_KE_1,
            string TARGET_QTY_JAM_KE_2,
            string TARGET_AMOUNT_JAM_KE_2,
            string TARGET_QTY_JAM_KE_3,
            string TARGET_AMOUNT_JAM_KE_3,
            string TARGET_QTY_JAM_KE_4,
            string TARGET_AMOUNT_JAM_KE_4,
            string TARGET_QTY_JAM_KE_5,
            string TARGET_AMOUNT_JAM_KE_5,
            string TARGET_QTY_JAM_KE_6,
            string TARGET_AMOUNT_JAM_KE_6,
            string TARGET_QTY_JAM_KE_7,
            string TARGET_AMOUNT_JAM_KE_7,
            string TARGET_QTY_JAM_KE_8,
            string TARGET_AMOUNT_JAM_KE_8,
            string TARGET_QTY_JAM_KE_9,
            string TARGET_AMOUNT_JAM_KE_9,
            string TARGET_QTY_JAM_KE_10,
            string TARGET_AMOUNT_JAM_KE_10,
            string TARGET_QTY_JAM_KE_11,
            string TARGET_AMOUNT_JAM_KE_11,
            string TARGET_QTY_JAM_KE_12,
            string TARGET_AMOUNT_JAM_KE_12,
            string TARGET_QTY_JAM_KE_13,
            string TARGET_AMOUNT_JAM_KE_13,
            string TARGET_QTY_JAM_KE_14,
            string TARGET_AMOUNT_JAM_KE_14,
            string TARGET_QTY_JAM_KE_15_16,
            string TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
            string TARGET_QTY_JAM_KE_17,
            string TARGET_AMOUNT_JAM_KE_17,
            string TARGET_QTY_JAM_KE_18,
            string TARGET_AMOUNT_JAM_KE_18,
            string TARGET_QTY_JAM_KE_19,
            string TARGET_AMOUNT_JAM_KE_19,
            string TARGET_QTY_JAM_KE_20,
            string TARGET_AMOUNT_JAM_KE_20,
            string TARGET_QTY_JAM_KE_21,
            string TARGET_AMOUNT_JAM_KE_21,
            string TARGET_QTY_JAM_KE_22,
            string TARGET_AMOUNT_JAM_KE_22
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090001Master>("DISA090001/DISA090001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                TARGET_DATE,
                TARGET_PRINT_QTY,
                TARGET_QTY_JAM_KE_1,
                TARGET_AMOUNT_JAM_KE_1,
                TARGET_QTY_JAM_KE_2,
                TARGET_AMOUNT_JAM_KE_2,
                TARGET_QTY_JAM_KE_3,
                TARGET_AMOUNT_JAM_KE_3,
                TARGET_QTY_JAM_KE_4,
                TARGET_AMOUNT_JAM_KE_4,
                TARGET_QTY_JAM_KE_5,
                TARGET_AMOUNT_JAM_KE_5,
                TARGET_QTY_JAM_KE_6,
                TARGET_AMOUNT_JAM_KE_6,
                TARGET_QTY_JAM_KE_7,
                TARGET_AMOUNT_JAM_KE_7,
                TARGET_QTY_JAM_KE_8,
                TARGET_AMOUNT_JAM_KE_8,
                TARGET_QTY_JAM_KE_9,
                TARGET_AMOUNT_JAM_KE_9,
                TARGET_QTY_JAM_KE_10,
                TARGET_AMOUNT_JAM_KE_10,
                TARGET_QTY_JAM_KE_11,
                TARGET_AMOUNT_JAM_KE_11,
                TARGET_QTY_JAM_KE_12,
                TARGET_AMOUNT_JAM_KE_12,
                TARGET_QTY_JAM_KE_13,
                TARGET_AMOUNT_JAM_KE_13,
                TARGET_QTY_JAM_KE_14,
                TARGET_AMOUNT_JAM_KE_14,
                TARGET_QTY_JAM_KE_15_16,
                TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
                TARGET_QTY_JAM_KE_17,
                TARGET_AMOUNT_JAM_KE_17,
                TARGET_QTY_JAM_KE_18,
                TARGET_AMOUNT_JAM_KE_18,
                TARGET_QTY_JAM_KE_19,
                TARGET_AMOUNT_JAM_KE_19,
                TARGET_QTY_JAM_KE_20,
                TARGET_AMOUNT_JAM_KE_20,
                TARGET_QTY_JAM_KE_21,
                TARGET_AMOUNT_JAM_KE_21,
                TARGET_QTY_JAM_KE_22,
                TARGET_AMOUNT_JAM_KE_22
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA090001
        public int getCountDISA090001(
            string DATA_ID,
            string TARGET_DATE,
            string TARGET_PRINT_QTY,
            string TARGET_QTY_JAM_KE_1,
            string TARGET_AMOUNT_JAM_KE_1,
            string TARGET_QTY_JAM_KE_2,
            string TARGET_AMOUNT_JAM_KE_2,
            string TARGET_QTY_JAM_KE_3,
            string TARGET_AMOUNT_JAM_KE_3,
            string TARGET_QTY_JAM_KE_4,
            string TARGET_AMOUNT_JAM_KE_4,
            string TARGET_QTY_JAM_KE_5,
            string TARGET_AMOUNT_JAM_KE_5,
            string TARGET_QTY_JAM_KE_6,
            string TARGET_AMOUNT_JAM_KE_6,
            string TARGET_QTY_JAM_KE_7,
            string TARGET_AMOUNT_JAM_KE_7,
            string TARGET_QTY_JAM_KE_8,
            string TARGET_AMOUNT_JAM_KE_8,
            string TARGET_QTY_JAM_KE_9,
            string TARGET_AMOUNT_JAM_KE_9,
            string TARGET_QTY_JAM_KE_10,
            string TARGET_AMOUNT_JAM_KE_10,
            string TARGET_QTY_JAM_KE_11,
            string TARGET_AMOUNT_JAM_KE_11,
            string TARGET_QTY_JAM_KE_12,
            string TARGET_AMOUNT_JAM_KE_12,
            string TARGET_QTY_JAM_KE_13,
            string TARGET_AMOUNT_JAM_KE_13,
            string TARGET_QTY_JAM_KE_14,
            string TARGET_AMOUNT_JAM_KE_14,
            string TARGET_QTY_JAM_KE_15_16,
            string TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
            string TARGET_QTY_JAM_KE_17,
            string TARGET_AMOUNT_JAM_KE_17,
            string TARGET_QTY_JAM_KE_18,
            string TARGET_AMOUNT_JAM_KE_18,
            string TARGET_QTY_JAM_KE_19,
            string TARGET_AMOUNT_JAM_KE_19,
            string TARGET_QTY_JAM_KE_20,
            string TARGET_AMOUNT_JAM_KE_20,
            string TARGET_QTY_JAM_KE_21,
            string TARGET_AMOUNT_JAM_KE_21,
            string TARGET_QTY_JAM_KE_22,
            string TARGET_AMOUNT_JAM_KE_22
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA090001/DISA090001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TARGET_DATE,
                TARGET_PRINT_QTY,
                TARGET_QTY_JAM_KE_1,
                TARGET_AMOUNT_JAM_KE_1,
                TARGET_QTY_JAM_KE_2,
                TARGET_AMOUNT_JAM_KE_2,
                TARGET_QTY_JAM_KE_3,
                TARGET_AMOUNT_JAM_KE_3,
                TARGET_QTY_JAM_KE_4,
                TARGET_AMOUNT_JAM_KE_4,
                TARGET_QTY_JAM_KE_5,
                TARGET_AMOUNT_JAM_KE_5,
                TARGET_QTY_JAM_KE_6,
                TARGET_AMOUNT_JAM_KE_6,
                TARGET_QTY_JAM_KE_7,
                TARGET_AMOUNT_JAM_KE_7,
                TARGET_QTY_JAM_KE_8,
                TARGET_AMOUNT_JAM_KE_8,
                TARGET_QTY_JAM_KE_9,
                TARGET_AMOUNT_JAM_KE_9,
                TARGET_QTY_JAM_KE_10,
                TARGET_AMOUNT_JAM_KE_10,
                TARGET_QTY_JAM_KE_11,
                TARGET_AMOUNT_JAM_KE_11,
                TARGET_QTY_JAM_KE_12,
                TARGET_AMOUNT_JAM_KE_12,
                TARGET_QTY_JAM_KE_13,
                TARGET_AMOUNT_JAM_KE_13,
                TARGET_QTY_JAM_KE_14,
                TARGET_AMOUNT_JAM_KE_14,
                TARGET_QTY_JAM_KE_15_16,
                TARGET_AMOUNT_JAM_KE_15_16_ISTIRAHAT,
                TARGET_QTY_JAM_KE_17,
                TARGET_AMOUNT_JAM_KE_17,
                TARGET_QTY_JAM_KE_18,
                TARGET_AMOUNT_JAM_KE_18,
                TARGET_QTY_JAM_KE_19,
                TARGET_AMOUNT_JAM_KE_19,
                TARGET_QTY_JAM_KE_20,
                TARGET_AMOUNT_JAM_KE_20,
                TARGET_QTY_JAM_KE_21,
                TARGET_AMOUNT_JAM_KE_21,
                TARGET_QTY_JAM_KE_22,
                TARGET_AMOUNT_JAM_KE_22
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA090001> Create(
            string target_date,
            string target_print_qty,
            string target_qty_jam_ke_1,
            string target_amount_jam_ke_1,
            string target_qty_jam_ke_2,
            string target_amount_jam_ke_2,
            string target_qty_jam_ke_3,
            string target_amount_jam_ke_3,
            string target_qty_jam_ke_4,
            string target_amount_jam_ke_4,
            string target_qty_jam_ke_5,
            string target_amount_jam_ke_5,
            string target_qty_jam_ke_6,
            string target_amount_jam_ke_6,
            string target_qty_jam_ke_7,
            string target_amount_jam_ke_7,
            string target_qty_jam_ke_8,
            string target_amount_jam_ke_8,
            string target_qty_jam_ke_9,
            string target_amount_jam_ke_9,
            string target_qty_jam_ke_10,
            string target_amount_jam_ke_10,
            string target_qty_jam_ke_11,
            string target_amount_jam_ke_11,
            string target_qty_jam_ke_12,
            string target_amount_jam_ke_12,
            string target_qty_jam_ke_13,
            string target_amount_jam_ke_13,
            string target_qty_jam_ke_14,
            string target_amount_jam_ke_14,
            string target_qty_jam_ke_15_16,
            string target_amount_jam_ke_15_16_istirahat,
            string target_qty_jam_ke_17,
            string target_amount_jam_ke_17,
            string target_qty_jam_ke_18,
            string target_amount_jam_ke_18,
            string target_qty_jam_ke_19,
            string target_amount_jam_ke_19,
            string target_qty_jam_ke_20,
            string target_amount_jam_ke_20,
            string target_qty_jam_ke_21,
            string target_amount_jam_ke_21,
            string target_qty_jam_ke_22,
            string target_amount_jam_ke_22,
            string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090001>("DISA090001/DISA090001_Create", new
            {
                target_date,                
                target_print_qty,
                target_qty_jam_ke_1,
                target_amount_jam_ke_1,
                target_qty_jam_ke_2,
                target_amount_jam_ke_2,
                target_qty_jam_ke_3,
                target_amount_jam_ke_3,
                target_qty_jam_ke_4,
                target_amount_jam_ke_4,
                target_qty_jam_ke_5,
                target_amount_jam_ke_5,
                target_qty_jam_ke_6,
                target_amount_jam_ke_6,
                target_qty_jam_ke_7,
                target_amount_jam_ke_7,
                target_qty_jam_ke_8,
                target_amount_jam_ke_8,
                target_qty_jam_ke_9,
                target_amount_jam_ke_9,
                target_qty_jam_ke_10,
                target_amount_jam_ke_10,
                target_qty_jam_ke_11,
                target_amount_jam_ke_11,
                target_qty_jam_ke_12,
                target_amount_jam_ke_12,
                target_qty_jam_ke_13,
                target_amount_jam_ke_13,
                target_qty_jam_ke_14,
                target_amount_jam_ke_14,
                target_qty_jam_ke_15_16,
                target_amount_jam_ke_15_16_istirahat,
                target_qty_jam_ke_17,
                target_amount_jam_ke_17,
                target_qty_jam_ke_18,
                target_amount_jam_ke_18,
                target_qty_jam_ke_19,
                target_amount_jam_ke_19,
                target_qty_jam_ke_20,
                target_amount_jam_ke_20,
                target_qty_jam_ke_21,
                target_amount_jam_ke_21,
                target_qty_jam_ke_22,
                target_amount_jam_ke_22,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA090001/DISA090001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA090001> Update_Data(
            string ID,
            string target_date,
            string target_print_qty,
            string target_qty_jam_ke_1,
            string target_amount_jam_ke_1,
            string target_qty_jam_ke_2,
            string target_amount_jam_ke_2,
            string target_qty_jam_ke_3,
            string target_amount_jam_ke_3,
            string target_qty_jam_ke_4,
            string target_amount_jam_ke_4,
            string target_qty_jam_ke_5,
            string target_amount_jam_ke_5,
            string target_qty_jam_ke_6,
            string target_amount_jam_ke_6,
            string target_qty_jam_ke_7,
            string target_amount_jam_ke_7,
            string target_qty_jam_ke_8,
            string target_amount_jam_ke_8,
            string target_qty_jam_ke_9,
            string target_amount_jam_ke_9,
            string target_qty_jam_ke_10,
            string target_amount_jam_ke_10,
            string target_qty_jam_ke_11,
            string target_amount_jam_ke_11,
            string target_qty_jam_ke_12,
            string target_amount_jam_ke_12,
            string target_qty_jam_ke_13,
            string target_amount_jam_ke_13,
            string target_qty_jam_ke_14,
            string target_amount_jam_ke_14,
            string target_qty_jam_ke_15_16,
            string target_amount_jam_ke_15_16_istirahat,
            string target_qty_jam_ke_17,
            string target_amount_jam_ke_17,
            string target_qty_jam_ke_18,
            string target_amount_jam_ke_18,
            string target_qty_jam_ke_19,
            string target_amount_jam_ke_19,
            string target_qty_jam_ke_20,
            string target_amount_jam_ke_20,
            string target_qty_jam_ke_21,
            string target_amount_jam_ke_21,
            string target_qty_jam_ke_22,
            string target_amount_jam_ke_22)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA090001>("DISA090001/DISA090001_Update", new
            {
                ID,
                target_date,
                target_print_qty,
                target_qty_jam_ke_1,
                target_amount_jam_ke_1,
                target_qty_jam_ke_2,
                target_amount_jam_ke_2,
                target_qty_jam_ke_3,
                target_amount_jam_ke_3,
                target_qty_jam_ke_4,
                target_amount_jam_ke_4,
                target_qty_jam_ke_5,
                target_amount_jam_ke_5,
                target_qty_jam_ke_6,
                target_amount_jam_ke_6,
                target_qty_jam_ke_7,
                target_amount_jam_ke_7,
                target_qty_jam_ke_8,
                target_amount_jam_ke_8,
                target_qty_jam_ke_9,
                target_amount_jam_ke_9,
                target_qty_jam_ke_10,
                target_amount_jam_ke_10,
                target_qty_jam_ke_11,
                target_amount_jam_ke_11,
                target_qty_jam_ke_12,
                target_amount_jam_ke_12,
                target_qty_jam_ke_13,
                target_amount_jam_ke_13,
                target_qty_jam_ke_14,
                target_amount_jam_ke_14,
                target_qty_jam_ke_15_16,
                target_amount_jam_ke_15_16_istirahat,
                target_qty_jam_ke_17,
                target_amount_jam_ke_17,
                target_qty_jam_ke_18,
                target_amount_jam_ke_18,
                target_qty_jam_ke_19,
                target_amount_jam_ke_19,
                target_qty_jam_ke_20,
                target_amount_jam_ke_20,
                target_qty_jam_ke_21,
                target_amount_jam_ke_21,
                target_qty_jam_ke_22,
                target_amount_jam_ke_22
            });
            db.Close();
            return d.ToList();
        }
        #endregion        

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISA090001/DISA090001_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }    

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    //public class SectionModel
    //{
    //    public DateTime ID { get; set; }
    //    public string SECTION_TEXT { get; set; }
    //}

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISA090001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA090001(int countdata, int positionpage, int dataperpage)
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