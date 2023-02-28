using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WPMemberMaster
{
    public class WPMemberRepository
    {
        #region Get_Data_Grid_WPMember
        public List<WPMemberMaster> getDataWPMember(int start, int display, string DATA_ID, string EXECUTION_TIME, string TIME_UNIT_CRITERIA, string STATUS_ACTIVE, string SYSTEM_ID, string SYSTEM_TYPE, string SYSTEM_VALUE_TEXT, string SYSTEM_FROM, string SYSTEM_TO, string SYSTEM_VALUE_NUM)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WPMemberMaster>("WPMember/WPMember_SearchData", new
            {
                START = start,
                DISPLAY = display,
                DATA_ID,
                EXECUTION_TIME,
                TIME_UNIT_CRITERIA,
                STATUS_ACTIVE,
                SYSTEM_ID,
                SYSTEM_TYPE,
                SYSTEM_VALUE_TEXT,
                SYSTEM_FROM,
                SYSTEM_TO, 
                SYSTEM_VALUE_NUM,
                
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WPMember
        public int getCountWPMember(string DATA_ID, string TIME_UNIT_CRITERIA, string EXECUTION_TIME, string STATUS_ACTIVE, string SYSTEM_ID, string SYSTEM_TYPE, string SYSTEM_VALUE_TEXT, string SYSTEM_FROM, string SYSTEM_TO, string SYSTEM_VALUE_NUM)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WPMember/WPMember_SearchCount", new
            {
                DATA_ID = DATA_ID,
                TIME_UNIT_CRITERIA = TIME_UNIT_CRITERIA,
                EXECUTION_TIME = EXECUTION_TIME,
                STATUS_ACTIVE = STATUS_ACTIVE,
                SYSTEM_ID,
                SYSTEM_TYPE,
                SYSTEM_VALUE_TEXT,
                SYSTEM_FROM,
                SYSTEM_TO,
                SYSTEM_VALUE_NUM,
            });
            db.Close();
            return result;
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID, string SYSTEM_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WPMember/WPMember_Delete", new
            {
                ID,
                SYSTEM_TYPE
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WPMember> Update_Data(string ID, string TYPE, string SYSTEM_ID, string SYSTEM_TYPE, string SYSTEM_CD, string SYSTEM_VALID_FR, string SYSTEM_VALID_TO, string SYSTEM_VALUE_TXT, string SYSTEM_VALUE_NUM, string SYSTEM_VALUE_DT, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WPMember>("WPMember/WPMember_Update", new
            {
                ID,
                TYPE,
                SYSTEM_ID,
                SYSTEM_TYPE,
                SYSTEM_CD,
                SYSTEM_VALID_FR,
                SYSTEM_VALID_TO,
                SYSTEM_VALUE_TXT,
                SYSTEM_VALUE_NUM,
                SYSTEM_VALUE_DT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        public static List<WPMember> Create(string SYSTEM_ID, string SYSTEM_TYPE, string SYSTEM_CD, string SYSTEM_VALID_FR, string SYSTEM_VALID_TO, string SYSTEM_VALUE_TXT, string SYSTEM_VALUE_NUM, string SYSTEM_VALUE_DT, string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WPMember>("WPMember/WPMember_Create", new
            {
                SYSTEM_ID,
                SYSTEM_TYPE,
                SYSTEM_CD,
                SYSTEM_VALID_FR,
                SYSTEM_VALID_TO,
                SYSTEM_VALUE_TXT,
                SYSTEM_VALUE_NUM,
                SYSTEM_VALUE_DT,
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
    }

    public class PagingModel_WPMember
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WPMember(int countdata, int positionpage, int dataperpage)
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