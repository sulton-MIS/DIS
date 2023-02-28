using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models
{
    public class MenuInfoRepository
    {
        private MenuInfoRepository() { }
        private static MenuInfoRepository instance = null;

        public static MenuInfoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuInfoRepository();
                }
                return instance;
            }
        }

        public MenuInfo GetMenuInfo(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            dynamic args = new
            {
                USERNAME
            };

            MenuInfo result = db.SingleOrDefault<MenuInfo>("Shared/GetMenuinfo", args);
            db.Close();
            return result;
        }
    }
}