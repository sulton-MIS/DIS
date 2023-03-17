using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR090001Master
{
    public class DISR090001Repository
    {
        #region Get_Data_Grid_DISR090001
        public List<DISR090001Master> getDataDISR090001(int Start, int Display, string EMPLOYEE_NAME, string IDENTITYNUMBER, string STATUS_OPMJ)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR090001Master>("DISR090001/DISR090001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                EMPLOYEE_NAME,
                IDENTITYNUMBER,
                STATUS_OPMJ
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISR090001
        public int getCountDISR090001(string DATA_ID, string EMPLOYEE_NAME, string IDENTITYNUMBER, string STATUS_OPMJ)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR090001/DISR090001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                EMPLOYEE_NAME,
                IDENTITYNUMBER,
                STATUS_OPMJ
            });
            db.Close();
            return result;
        }
        #endregion



        #region Update Data
        public List<DISR090001> Update_Data(string ID, string name_sagyosha, string id_sagyosha, string status_opmj, string username, string username1)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR090001>("DISR090001/DISR090001_Update", new
            {
                ID,
                name_sagyosha,
                id_sagyosha,
                status_opmj,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion


        //public string Delete_Data(string ID)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.SingleOrDefault<string>("DISR070001/DISR070001_Delete", new
        //    {
        //        ID
        //    });
        //    db.Close();
        //    return d;
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

        public class PagingModel_DISR090001
        {
            public int CountData { get; set; }
            public int StartData { get; set; }
            public int EndData { get; set; }
            public int PositionPage { get; set; }
            public List<int> ListIndex { get; set; }
            public PagingModel_DISR090001(int countdata, int positionpage, int dataperpage)
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
}