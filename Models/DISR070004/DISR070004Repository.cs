using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR070004Master
{
    public class DISR070004Repository
    {
        #region Get_Data_Grid_DISR070004
        public List<DISR070004Master> getDataDISR070004(int Start, int Display, string id_kikai, string name_kikai)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070004Master>("DISR070004/DISR070004_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                id_kikai,
                name_kikai
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISR070004
        public int getCountDISR070004(string DATA_ID, string id_kikai, string name_kikai)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR070004/DISR070004_SearchCount", new
            {
                DATA_ID = DATA_ID,
                id_kikai,
                name_kikai
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISR070004> Create(string DATA_ID, string id_kikai, string name_kikai, string id_koteishubetsu, string IPaddress, string line, string cluster, string factory, string comment, string time_koshin, string group_kikai, string group_kikai_sort, string flg_visible_oven, string machine_name, string initial_kikai)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070004>("DISR070004/DISR070004_Create", new
            {
                DATA_ID,
                id_kikai,
                name_kikai,
                id_koteishubetsu,
                IPaddress,
                line,
                cluster,
                factory,
                comment,
                time_koshin,
                group_kikai,
                group_kikai_sort,
                flg_visible_oven,
                machine_name,
                initial_kikai
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.SingleOrDefault<string>("DISR070004/DISR070004_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISR070004> Update_Data(
            string ID, string id_kikai, string name_kikai, string id_koteishubetsu, string IPaddress, 
            string line, string cluster, string factory, string comment, /*string time_koshin,*/ string group_kikai, 
            string group_kikai_sort, /*string flg_visible_oven,*/ string machine_name, string initial_kikai)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070004>("DISR070004/DISR070004_Update", new
            {
                ID,
                id_kikai,
                name_kikai,
                id_koteishubetsu,
                IPaddress,
                line,
                cluster,
                factory,
                comment,
                group_kikai,
                group_kikai_sort,
                machine_name,
                initial_kikai
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        

        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ExecutorModel>("DISR070004/DISR070004_getExecutor");

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

  
    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISR070004
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR070004(int countdata, int positionpage, int dataperpage)
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