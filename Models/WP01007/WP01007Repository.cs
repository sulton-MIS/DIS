using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP01007Master
{
    public class WP01007Repository
    {
        #region Get_Data_Grid_WP01007
        public List<WP01007Master> getDataWP01007(int Start, int Display, string ITEM_NAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01007Master>("WP01007/WP01007_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ITEM_NAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_WP01007
        public List<ItemModel> GetItemType()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ItemModel>("WP01007/WP01007_GetItemType");
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP01007
        public int getCountWP01007(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string ITEM_NAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP01007/WP01007_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                ITEM_NAME
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<string>("WP01007/WP01007_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<WP01007> Update_Data(string ID, string ITEM_NAME, string ITEM_TYPE, string ITEM_ST,string ITEM_DESC, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01007>("WP01007/WP01007_Update", new
            {
                ID,
                ITEM_TYPE,
                ITEM_NAME,
                ITEM_ST,
                ITEM_DESC,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP01007> Create(string ITEM_NAME, string ITEM_TYPE, string ITEM_STATUS, string ITEM_DESC, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01007>("WP01007/WP01007_Create", new
            {
                ITEM_NAME,
                ITEM_TYPE,
                ITEM_STATUS,
                ITEM_DESC,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        #region Get Project Location
        public List<LocationModel> getArea()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<LocationModel>("WP01007/WP01007_getArea");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class StatusModel
    {
        public string ID { get; set; }
        public string Status { get; set; }
    }

    public class ItemModel
    {
        public string ID { get; set; }
        public string TYPE { get; set; }
        public string ITEM_TYPE { get; set; }
        public string CD { get; set; }
    }

    public class DivisionModel
    {
        public string Division { get; set; }
    }

    public class LocationModel
    {
        public string AREA_CD { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
    }

    public class ExecutorModel
    {
        public string Executor_ID { get; set; }
        public string Executor { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }
    public class PagingModel_WP01007
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP01007(int countdata, int positionpage, int dataperpage)
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