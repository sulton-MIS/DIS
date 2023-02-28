using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03004Master
{
    public class WP03004Repository
    {
        #region Get_Data_Grid_WP03004
        public List<WP03004Master> getDataWP03004(
                                                    int Start,
                                                    int Display,
                                                    string TITLE
                                                  )
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03004Master>("WP03004/WP03004_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                TITLE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03004
        public int getCountWP03004(string TITLE)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03004/WP03004_SearchCount", new
            {
                TITLE
            });
            db.Close();
            return result;
        }
        #endregion

        #region GetSingleData
        public static TrainingDTO GetDetailTraining(int id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var data = db.Fetch<TrainingDTO>("WP03004/WP03004_GetDataById", new
            {
                id
            });
            db.Close();
            return data.FirstOrDefault();
        }

        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03004/WP03004_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<WP03004> Update_Data(
                                            string Id,
                                            string Title,
                                            string Description,
                                            string File_Modul,
                                            string File_Name,
                                            string Content,
                                            string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03004>("WP03004/WP03004_Update", new
            {
                Id,
                Title,
                Description,
                File_Modul,
                File_Name,
                Content,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Data
        public static WP03004 Insert(
                                            string Title,
                                            string Training_for,
                                            string Description,
                                            string File_Path,
                                            string File_Name,
                                            string Content,
                                            string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03004>("WP03004/WP03004_Insert", new
            {
                Title,
                Training_for,
                Description,
                File_Path,
                File_Name,
                Content,
                Username
            });
            db.Close();
            return d.FirstOrDefault();
        }
        #endregion



        #region Show Detail Training
        public List<DetailTrainingModel> get_ShowDetailTraining(string id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<DetailTrainingModel>("WP03004/WP03004_GetDetailTraining", new
            {
                ID = id
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    #region Paging Model
    public class PagingModel_WP03004
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03004(int countdata, int positionpage, int dataperpage)
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

}

#region Detail Training Model
public class DetailTrainingModel
{
    public int ROW_NUM { get; set; }
    public string TITLE { get; set; }
    public string COMPANY_NAME { get; set; }
    public string ANSWER { get; set; }
    public string CORRECT_AMOUNT { get; set; }
    public string WRONG_AMOUNT { get; set; }
    public string NOT_ANSWERED_AMOUNT { get; set; }
    public string REMEDIAL { get; set; }
    public string SCORE { get; set; }
    public string PASS_GRADUATED { get; set; }
    public string TIMER { get; set; }
    public string SUBMIT_DATE { get; set; }
    public string STATUS { get; set; }
}
#endregion