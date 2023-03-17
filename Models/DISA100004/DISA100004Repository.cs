using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA100004Master
{
    public class DISA100004Repository
    {
        #region Get_Data_Grid_DISA100004
        public List<DISA100004Master> getDataDISA100004(int Start, int Display, string ITEM_CODE, string JENIS_TRANSPORTATION, string TRANSPORTATION_COST)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100004Master>("DISA100004/DISA100004_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ITEM_CODE,
                JENIS_TRANSPORTATION,
                TRANSPORTATION_COST
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA100004
        public int getCountDISA100004(string DATA_ID, string ITEM_CODE, string JENIS_TRANSPORTATION, string TRANSPORTATION_COST)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100004/DISA100004_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ITEM_CODE,
                JENIS_TRANSPORTATION,
                TRANSPORTATION_COST
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA100004> Create(
            string item_code,
            string lot_size,
            string master_qty,
            string box_qty,
            string weight,
            string total_weight,
            string jenis_transportation,
            string transportation_cost,
            string awb_free_jpn,
            string edi_free_jpn,
            string ams_free_jpn,
            string trucking_0_250_kg_jpn,
            string handling_air_under_50_kg_jpn,
            string handling_air_upto_50_kg,
            string total_cost,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100004>("DISA100004/DISA100004_Create", new
            {
                item_code,
                lot_size,
                master_qty,
                box_qty,
                weight,
                total_weight,
                jenis_transportation,
                transportation_cost,
                awb_free_jpn,
                edi_free_jpn,
                ams_free_jpn,
                trucking_0_250_kg_jpn,
                handling_air_under_50_kg_jpn,
                handling_air_upto_50_kg,
                total_cost,
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
            var d = db.SingleOrDefault<string>("DISA100004/DISA100004_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA100004> Update_Data(
            string ID,
            string item_code,
            string lot_size,
            string master_qty,
            string box_qty,
            string weight,
            string total_weight,
            string jenis_transportation,
            string transportation_cost,
            string awb_free_jpn,
            string edi_free_jpn,
            string ams_free_jpn,
            string trucking_0_250_kg_jpn,
            string handling_air_under_50_kg_jpn,
            string handling_air_upto_50_kg,
            string total_cost,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100004>("DISA100004/DISA100004_Update", new
            {
                ID,
                item_code,
                lot_size,
                master_qty,
                box_qty,
                weight,
                total_weight,
                jenis_transportation,
                transportation_cost,
                awb_free_jpn,
                edi_free_jpn,
                ams_free_jpn,
                trucking_0_250_kg_jpn,
                handling_air_under_50_kg_jpn,
                handling_air_upto_50_kg,
                total_cost,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion      



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ExecutorModel>("DISA100004/DISA100004_getExecutor");

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
    //    public string ID { get; set; }
    //    public string SECTION_TEXT { get; set; }
    //}

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISA100004
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA100004(int countdata, int positionpage, int dataperpage)
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