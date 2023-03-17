using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models
{
    public class IMPBRepository
    {

        private IMPBRepository() { }
        private static IMPBRepository instance = null;

        public static IMPBRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IMPBRepository();
                }
                return instance;
            }
        }

        #region Check IMPB Detail
        public List<IMPBMaster> getIMPBDetail(string AREA)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<IMPBMaster>("getIMPBDetail", new { AREA });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region getHomeContent
        public Object getHomeContent(string AREA)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int d1 = db.SingleOrDefault<int>("Home/getAlltotalWorker", new { AREA });
            int d2 = db.SingleOrDefault<int>("Home/getTotalSecurityCheck", new { AREA });
            var d3 = db.Fetch<HomeContent>("Home/getIncidentLevel", new { AREA });
            var d4 = db.Fetch<DangerLevel>("Home/getRiskDangerLevel", new { AREA });
            int d5 = db.SingleOrDefault<int>("Home/getTotalCompany", new { AREA });

            var list = new[]
            {
                new { 
                    AllWorkers = d1, 
                    WorkersCheckIn = d2, 
                    Incident = d3.ToList(),
                    Danger = d4.ToList(),
                    TotalCompany = d5
                }
            }.ToList();

            db.Close();
            return list;
        }
        #endregion


        #region Check IMPB Henkanten
        public List<HenkantenENV> getIMPBHenkanten(string IMPB)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<HenkantenENV>("getIMPBHenkanten", new { IMPB });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class HenkantenENV{
        public string HENKANTEN_ENV { get; set; }
        public string HENKANTEN_SAFETY { get; set; }
    }

    public class HomeContent
    {
        public int CONTRACTOR { get; set; }
        public int WORKERS_ALL { get; set; }
        public int WORKERS_IN { get; set; }
        public int CATEGORY_L { get; set; }
        public int CATEGORY_M { get; set; }
        public int CATEGORY_H { get; set; }
        public int INCIDENT_L { get; set; }
        public int INCIDENT_M { get; set; }
        public int INCIDENT_H { get; set; }

    }

    public class DangerLevel
    {
        public string DANGER_L { get; set; }
        public string DANGER_M { get; set; }
        public string DANGER_H { get; set; }
    }

    public class IMPBMaster
    {
        public string IMPB { get; set; }
        public string PROJECT_NAME { get; set; }
        public string PROJECT_JOBS { get; set; }
        public string LEADER { get; set; }
        public string SUPERVISOR { get; set; }
        public string SUPERVISOR_TMMIN { get; set; }
        public string INCIDENT { get; set; }
        public string EXECUTOR { get; set; }
        public string SECTION { get; set; }
        public string EMPLOYEE { get; set; }
        public string TOTAL_CHECK_IN { get; set; }
        public string TOTAL_EMPLOYEE { get; set; }
        public string TYPE { get; set; }
        public string DANGER { get; set; }
        public string VIOLATION { get; set; }
        public string NOTE { get; set; }
        public string TOP_POSITION { get; set; }
        public string LEFT_POSITION { get; set; }
        public string HEIGHT { get; set; }
        public string WIDTH { get; set; }
        public string PING { get; set; }
        public string WINDOW_HEIGHT { get; set; }
        public string WINDOW_WIDTH { get; set; }
        public string BORDER_COLOR { get; set; }
        public string ROTATION { get; set; }
        public string CREATED_BY { get; set; }

    }
}