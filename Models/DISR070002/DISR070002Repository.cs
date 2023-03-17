using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISR070002Master
{
    public class DISR070002Repository
    {
        #region Get_Data_Grid_DISR070002
        public List<DISR070002Master> getDataDISR070002(int Start, int Display, string ID_NG, string NAME_NG)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070002Master>("DISR070002/DISR070002_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ID_NG,
                NAME_NG
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISR070002
        public int getCountDISR070002(string DATA_ID, string ID_NG, string NAME_NG)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR070002/DISR070002_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ID_NG,
                NAME_NG
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISR070002> Create(string DATA_ID, string ID_NG, string NAME_NG, string TIME_KOSHIN, string NGSTATUS, string FLG_COUNT)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070002>("DISR070002/DISR070002_Create", new
            {
                DATA_ID,
                ID_NG,
                NAME_NG,
                TIME_KOSHIN,
                NGSTATUS,
                FLG_COUNT
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.SingleOrDefault<string>("DISR070002/DISR070002_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISR070002> Update_Data(string ID, string name_ng, string id_ng, string NgStatus)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070002>("DISR070002/DISR070002_Update", new
            {
                ID,
                name_ng,
                id_ng,
                NgStatus
                //time_koshin,
                //flg_count
                //STATUS
                //time_koshin,
                //flg_count
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        //#region Get Division
        //public List<DivisionModel> getDivision()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<DivisionModel>("DISR070001/DISR070001_getDivision");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        //#region Get Project Location
        //public List<CompanyModel> getCompany()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<CompanyModel>("DISR070001/DISR070001_getCompany");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Identity
        //public List<IdentityModel> getIdentity()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<IdentityModel>("DISR070001/DISR070001_getIdentity");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion

        //#region Get Section
        //public List<SectionModel> getSection(string SYSTEM_CD)
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<SectionModel>("DISR070001/DISR070001_getSection", new
        //    {
        //        SYSTEM_CD
        //    });

        //    db.Close();
        //    return d.ToList();
        //}



        //#endregion

        //#region Get PIC
        //public List<PICModel> getPIC()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
        //    var d = db.Fetch<PICModel>("DISR070001/DISR070001_getPic");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion



        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ExecutorModel>("DISR070002/DISR070002_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    //public class StatusModel
    //{
    //    public string ID { get; set; }
    //    public string Status { get; set; }
    //}

    //public class DivisionModel
    //{
    //    public string Division { get; set; }
    //    public string DIV { get; set; }
    //    public string DIV_ID { get; set; }
    //}

    //public class CompanyModel
    //{
    //    public string ID { get; set; }
    //    public string COMPANY { get; set; }
    //}

    //public class IdentityModel
    //{
    //    public string ID { get; set; }
    //    public string IDENTITY_TEXT { get; set; }
    //}

    //public class PICModel
    //{
    //    public string ID { get; set; }
    //    public string PIC_TEXT { get; set; }
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

    public class PagingModel_DISR070002
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR070002(int countdata, int positionpage, int dataperpage)
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