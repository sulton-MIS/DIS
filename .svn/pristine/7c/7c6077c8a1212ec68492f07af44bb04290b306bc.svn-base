using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using AI070.Models.WP02002Master;

namespace AI070.Models.WP02006
{
    public class WP02006Repository
    {
        #region Get_Data_Grid_WP02006
        public List<WP02006Master> GetDataWP02006(int Start, int Display, string PROJECT_CODE, string PROJECT_NAME, string DATE_FROM
            , string DATE_TO, string COMPANY, string LOCATION, string DIVISION, string WP_IMPB_NO)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP02006Master>("WP02006/WP02006_GetApprovedProject", new
            {
                START = Start,
                DISPLAY = Display,
                PROJECT_CODE,
                PROJECT_NAME,
                DATE_FROM,
                DATE_TO,
                COMPANY,
                LOCATION,
                DIVISION,
                WP_IMPB_NO
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP02006
        public int GetCountWP02006(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE
            , string PROJECT_CODE, string PROJECT_NAME, string DATE_FROM, string DATE_TO,
            string COMPANY, string LOCATION, string DIVISION, string WP_IMPB_NO)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP02006/WP02006_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                PROJECT_CODE,
                PROJECT_NAME,
                DATE_FROM,
                DATE_TO,
                COMPANY,
                LOCATION,
                DIVISION,
                WP_IMPB_NO
            });
            db.Close();
            return result;
        }
        #endregion
    }
}