using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.WP03008Master
{
    public class WP03008Repository
    {
        #region Get_Data_Grid_WP03008
        public List<WP03008Master> getDataWP03008(
                                                    int Start,
                                                    int Display,
                                                    string Anzen,
                                                    string RegNo,
                                                    string IdentityNo,
                                                    string UserName,
                                                    string Email
                                                  )
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WP03008Master>("WP03008/WP03008_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                Anzen,
                RegNo,
                IdentityNo,
                UserName,
                Email
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WP03008
        public int getCountWP03008(
            string Anzen,
            string RegNo,
            string IdentityNo,
            string UserName,
            string Email
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03008/WP03008_SearchCount", new
            {
                Anzen,
                RegNo,
                IdentityNo,
                UserName,
                Email
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get Identity Type
        public List<IdentityModel> getIdentity()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<IdentityModel>("WP01005/WP01005_GetIdentity");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public void Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03008/WP03008_Delete", new
            {
                ID
            });
            db.Close();
        }
        #endregion

        #region Update Data
        public List<QueryResult> Update_Data(
                                            string Id,
                                            string RegNo,
                                            string FirstName,
                                            string LastName,
                                            string Username_member,
                                            string Email,
                                            string Address,
                                            string Phone,
                                            string IdentityType,
                                            string IdentityNo,
                                            string SINo,
                                            string SIFrom,
                                            string SITo,
                                            string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<QueryResult>("WP03008/WP03008_Update", new
            {
                Id
                ,
                RegNo
                ,
                FirstName
                ,
                LastName
                ,
                Username_member
                ,
                Email
                ,
                Address
                ,
                Phone
                ,
                IdentityType
                ,
                IdentityNo
                ,
                SINo
                ,
                SIFrom
                ,
                SITo
                ,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Check_Exist_Data_Registration_No
        public int Check_Exist_Data(string param_data, string param1)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("WP03008/WP03008_CheckExistData", new
            { param_data , param1 });
            db.Close();
            return result;
        }
        #endregion

        //#region Check_Exist_Data_Identity_No
        //public int Check_Exist_IdentityNo(string param_data, string param1)
        //{

        //    IDBContext db = DatabaseManager.Instance.GetContext();
        //    int result = db.SingleOrDefault<int>("WP03008/WP03008_CheckExistData", new
        //    { param1 });
        //    db.Close();
        //    return result;
        //}
        //#endregion

        #region Insert Data
        public static List<QueryResult> Insert(
                                            string RegNo
                                            , string FirstName
                                            , string LastName
                                            , string Username_member
                                            , string Password
                                            , string Email
                                            , string Address
                                            , string Phone
                                            , string IdentityType
                                            , string IdentityNo
                                            , string SINo
                                            , string SIFrom
                                            , string SITo
                                            , string Anzen
                                            , string Username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<QueryResult>("WP03008/WP03008_Insert", new
            {
                RegNo
                ,
                FirstName
                ,
                LastName
                ,
                Username_member
                ,
                Password
                ,
                Email
                ,
                Address
                ,
                Phone
                ,
                IdentityType
                ,
                IdentityNo
                ,
                SINo
                ,
                SIFrom
                ,
                SITo
                ,
                Anzen
                ,
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
            var d = db.Fetch<DetailTrainingModel>("WP03008/WP03008_GetDetailTraining", new
            {
                ID = id
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    #region Paging Model
    public class PagingModel_WP03008
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_WP03008(int countdata, int positionpage, int dataperpage)
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

    #region Identity Type Model
    public class IdentityModel
    {
        public string ID { get; set; }
        public string IDENTITY_TEXT { get; set; }
    }
    #endregion

}
