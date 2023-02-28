using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP01002Master
{
    public class WP01002Repository
    {
        #region Get_Data_Grid_WP01002
        public List<WP01002Master> getDataWP01002(int Start, int Display, string AREA_CODE, string AREA_NAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01002Master>("WP01002/WP01002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                AREA_CODE,
                AREA_NAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP01002
        public int getCountWP01002(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string AREA_CODE, string AREA_NAME)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP01002/WP01002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                AREA_CODE,
                AREA_NAME
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.SingleOrDefault<string>("WP01002/WP01002_Delete", new
            {
                ID,
                USERNAME
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<WP01002> Update_Data(string ID, string AREA_CODE, string AREA_NAME, string AREA_ST, string EXT, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01002>("WP01002/WP01002_Update", new
            {
                ID,
                AREA_CODE,
                AREA_NAME,
                AREA_ST,
                EXT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WP01002> Create(string AREA_CODE, string AREA_NAME, string AREA_STATUS, string EXT, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP01002>("WP01002/WP01002_Create", new
            {
                AREA_CODE,
                AREA_NAME,
                AREA_STATUS,
                EXT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }

        public List<SizeModel> getUploadSize()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<SizeModel>("WP01002/WP01002_getUploadSize");
            db.Close();
            return d.ToList();
        }
    }

    public class SizeModel
    {
        public string SIZE { get; set; }
    }

    public class LocationModel
    {
        public string AREA_CD { get; set; }
        public string AREA_NAME { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    public class PagingModel_WP01002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP01002(int countdata, int positionpage, int dataperpage)
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