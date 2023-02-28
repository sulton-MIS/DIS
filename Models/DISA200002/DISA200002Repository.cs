using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA200002Master
{
    public class DISA200002Repository
    {
        #region Get_Data_Grid_DISA200002
        public List<DISA200002Master> getDataDISA200002(int Start, int Display, string JENIS_MAT, string CODE, string NAME, string MAINBUMO, string HOKAN, string ZAIK)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA200002Master>("DISA200002/DISA200002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                JENIS_MAT,
                CODE,
                NAME,
                MAINBUMO,
                HOKAN,
                ZAIK
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Material
        public List<DISA200002Master> GetMaterial(
            string JENIS_MAT, string CODE, string NAME, string MAINBUMO
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA200002Master>("DISA200002/DISA200002_getMaterial", new
            {
                JENIS_MAT,
                CODE,
                NAME,
                MAINBUMO
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA200002
        public int getCountDISA200002(string DATA_ID, string JENIS_MAT, string CODE, string NAME, string MAINBUMO, string HOKAN, string ZAIK)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            int result = db.SingleOrDefault<int>("DISA200002/DISA200002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                JENIS_MAT,
                CODE,
                NAME,
                MAINBUMO,
                HOKAN,
                ZAIK
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get MainBumo
        public List<MainBumoModel> getMainBumo()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<MainBumoModel>("DISA200002/DISA200002_getMainBumo");

            db.Close();
            return d.ToList();
        }
        #endregion
        
        #region Get Hokan
        public List<HokanModel> getHokan()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<HokanModel>("DISA200002/DISA200002_getHokan");

            db.Close();
            return d.ToList();
        }
        #endregion


        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("");
            var d = db.Fetch<ExecutorModel>("DISA200002/DISA200002_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

   

    public class MainBumoModel
    {
        public string MAINBUMO { get; set; }
    }
    public class HokanModel
    {
        public string HOKAN { get; set; }
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

    public class PagingModel_DISA200002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA200002(int countdata, int positionpage, int dataperpage)
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