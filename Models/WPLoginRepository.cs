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
    public class WPLoginRepository
    {
        #region Check Username
        public List<WPLoginMaster> checkUsername(string USERNAME, string PASSWORD)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Fetch<WPLoginMaster>("WPLogin/WPLogin_checkUsername", new
            {
                USERNAME,
                PASSWORD
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class WPLoginMaster
    {
        public string ID_TB_M_EMPLOYEE { get; set; }
        public string COMPANY { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string SECTION { get; set; }
        public string REG_NO { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string PIC_STATUS { get; set; }

    }
}