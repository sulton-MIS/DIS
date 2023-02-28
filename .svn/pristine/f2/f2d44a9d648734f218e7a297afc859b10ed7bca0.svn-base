using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03014Master
{
    public class WP03014Repository
    {
        #region Get_Data_Grid_WP03014
        public List<WP03014Master> getDataWP03014(
                                                    int Start,
                                                    int Display,
                                                    string Worker,
                                                    string Project,
                                                    string Company
                                                  )
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03014Master>("WP03014/WP03014_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                Worker,
                Project,
                Company
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03014
        public int getCountWP03014()
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03014/WP03014_SearchCount", new { });
            db.Close();
            return result;
        }
        #endregion

        #region Get Worker
        public List<WorkerModel> getWorker()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WorkerModel>("WP03014/WP03014_GetWorker");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Project
        public List<ProjectModel> getProject()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<ProjectModel>("WP03014/WP03014_GetProject");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Company
        public List<CompanyModel> getCompany()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<CompanyModel>("WP03014/WP03014_GetCompany");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03014/WP03014_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<QueryResult> Update_Data(
                                            string ID,
                                            string Worker,
                                            string Project,
                                            string Company,
                                            string JoinDate,
                                            string Company_from,
                                            string Company_to,
                                            string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<QueryResult>("WP03014/WP03014_Update", new
            {
                ID,
                Worker,
                Project,
                Company,
                JoinDate,
                Company_from,
                Company_to,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Data
        public static List<QueryResult> Insert(
                                            string Worker
                                            , string Project
                                            , string Company
                                            , string JoinDate
                                            , string Company_from
                                            , string Company_to
                                            , string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<QueryResult>("WP03014/WP03014_Insert", new
            {
                Worker,
                Project,
                Company,
                JoinDate,
                Company_from,
                Company_to,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Show Detail Training
        public List<DetailTrainingModel> get_ShowDetailTraining(string id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DetailTrainingModel>("WP03014/WP03014_GetDetailTraining", new
            {
                ID = id
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    #region Paging Model
    public class PagingModel_WP03014
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03014(int countdata, int positionpage, int dataperpage)
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
    #endregion

    #region Query Result
    public class QueryResult
    {
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }
    #endregion

    #region Work Model
    public class WorkerModel
    {
        public string ID { get; set; }
        public string REG_NO { get; set; }
        public string EMPLOYEE_NAME { get; set; }
    }
    #endregion

    #region Project Model
    public class ProjectModel
    {
        public string ID { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
    }
    #endregion

    #region Company Model
    public class CompanyModel
    {
        public string ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
    }
    #endregion

}
