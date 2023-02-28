using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class FunctionRepository
    {
        private FunctionRepository() { }
        private static FunctionRepository instance = null;
        public static FunctionRepository Instance 
        {
            get 
            {
                if (instance == null)
                {
                    instance = new FunctionRepository();
                }
                return instance;
            }
        }

        public IEnumerable<Function> GetFuncNameList()
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var args = new
            {

            };

            IEnumerable<Function> result = db.Fetch<Function>("STD/GetFunctionName", args);
            db.Close();

            return result;
        }

        public string GetDataByID(string MODULE_ID, string Function_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var args = new
            {
                MODULE_ID = MODULE_ID,
                FUNCTION_ID = Function_ID
            };

            string result = db.SingleOrDefault<string>("STD/FunctionGetByID", args);
            db.Close();

            return result;
        }
        public string GetDataByFunctionID(string Function_ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var args = new
            {
                FUNCTION_ID = Function_ID
            };

            string result = db.SingleOrDefault<string>("STD/FunctionGetByFunctionID", args);
            db.Close();

            return result;
        }
    }
}