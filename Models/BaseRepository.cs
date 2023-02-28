using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class BaseRepository
    { 


        #region Simplecommon

        //common crud by septareosagita@gmail.com 
        //created on 1 Februari 2017

        protected Result GetResultMessage(string MSG_ID, bool sts=false)
        {
            Result Message;
            IDBContext db = DatabaseManager.Instance.GetContext(); 
            Message = db.SingleOrDefault<Result>("STD/GetMessage", new { MSG_ID = MSG_ID });
            Message.MESSAGE_STS = sts;
            db.Close(); 
            return Message;
        }

        protected Result GetResultMessage(string MSG_ID, dynamic obj)
        {
            Result Message;
            try
            {
                Message = GetResultMessage(MSG_ID);
                Message.MESSAGE_OBJ = obj;
                Message.MESSAGE_STS = true;
            }
            catch
            {
                Message = GetResultMessage(MSG_ID);
                Message.MESSAGE_STS = false; 
            } 
            return Message;
        }

        protected Result SaveInsertUpdate(string query, dynamic args, bool insert)
        {
            Result rslt = Result.Instance;
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {  
                db.BeginTransaction();
                //rslt = GetResultMessage((string)GetData(query, args));
                rslt = GetResultMessage(GetData<string>(query, args));
                db.CommitTransaction();
                db.Close();
                rslt.MESSAGE_STS = true;
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                rslt = GetResultMessage(insert ? StaticMessage.InsertError : StaticMessage.UpdateError);
                rslt.MESSAGE_STS = false;
            }
            finally
            {
                rslt.MESSAGE_OBJ = new object();
            }
            return rslt;
        }



        #endregion


        protected IEnumerable<T> GetListData<T>(string spName, dynamic args)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            IEnumerable<T> result = db.Fetch<T>(spName, args);
            db.Close();
            return result;
        }

        protected T GetData<T>(string spName, dynamic args)
        { 
            IDBContext db = DatabaseManager.Instance.GetContext(); 
            T result = db.SingleOrDefault<T>(spName, args); 
            db.Close();
            return result;
        }

        public string getMessage(string query,dynamic args)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            string msg = db.SingleOrDefault<string>(query, args);
            db.Close();
            return msg;
        }
    
        public int Count(string spName, dynamic args)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            int result = 0;

            try
            {
                result = db.SingleOrDefault<int>(spName, args);
            }
            catch (Exception ex)
            {
                result = 0;
            }

            db.Close();
            return result;
        }

        public int SaveData(string spName, dynamic args)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Execute(spName, args);
            db.Close();
            return result;
        }

        public int DeleteData(string spName, dynamic args)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Execute(spName, args);
            db.Close();
            return result;
        }

        public int UploadData(string spName, dynamic args)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Execute(spName, args);
            db.Close();
            return result;
        }

        public string GetProcessId()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetProcessId");

            return result.ToString();
        }
        public string GetUserPlantCode()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetUserPlantCode");

            return result.ToString();
        }
        public int GetLogProcessId()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetLogProcessId");

            return result;
        }

        public int GetOrderLogProcessId()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetOrderLogProcessId");

            return result;
        }

        public string GetSequenceNo()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetSequenceNo");

            return result.ToString();
        }

        public string GetSequenceNoPC()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetSequenceNoPC");

            return result.ToString();
        }

        public string GetSequenceNoPWC()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetSequenceNoPWC");

            return result.ToString();
        }

        public string GetSequenceNoRPP()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            int result = db.SingleOrDefault<int>("GetSequenceNoRPP");

            return result.ToString();
        }
    }
}