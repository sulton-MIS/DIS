using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

// added by ark.deden
namespace AI070.Models.Shared
{
    public class MessageNo
    {
        public string msgno {get;set;}

        public static List<string> GetMsgNoLike(string msgNo)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Query<String>("Shared/MessageNoLike", new
            {
                msgno = msgNo
            });
            db.Close();
            return result.ToList();
        }
    }
}