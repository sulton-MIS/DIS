using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Web.Platform;
using Toyota.Common.Database;

namespace AI070.Models.Shared
{
    public class Message
    {
        public string MSG_ID { get; set; }
        public string MSG_TEXT { get; set; }
        public string MSG_TYPE { get; set; }
        public string MSG_ICON { get; set; }
        public string DESCRIPTION { get; set; }

        public string p_PARAM1 { get; set; }
        public string p_PARAM2 { get; set; }
        public string p_PARAM3 { get; set; }
        public string p_PARAM4 { get; set; }

        public string result { get; set; }
        public string messages {get;set;}

        public List<Message> get_message(Message msg)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            // Shared/Get_Message
            var res = db.Query<Message>("EXEC SP_GENERATE_MSG @p_MSG_ID, @p_PARAM1, @p_PARAM2, @p_PARAM3, @p_PARAM4", new
            {
                p_MSG_ID = msg.MSG_ID,
                p_PARAM1 = msg.p_PARAM1,
                p_PARAM2 = msg.p_PARAM2,
                p_PARAM3 = msg.p_PARAM3,
                p_PARAM4 = msg.p_PARAM4
            });
            db.Close();

            // return processID
            return res.ToList();
        }

        public List<Message> get_all_message(Message msg)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            // Shared/Get_Message
            var res = db.Query<Message>("Shared/AllMessage");
            db.Close();
            return res.ToList();
        }

        public List<Message> get_default_message(String MSG_ID, String PARAM1, String PARAM2, String PARAM3)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Query<Message>("Shared/Message", new { 
                MSG_ID,
                PARAM1,
                PARAM2,
                PARAM3
            });
            db.Close();
            return result.ToList();
        }

        public List<Message> getMessageTextWithFunctionSQL(Message msg)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Query<Message>("Shared/MessageTextWithFunctionSQL", new {
                p_MSG_ID = msg.MSG_ID,
                p_PARAM1 = msg.p_PARAM1,
                p_PARAM2 = msg.p_PARAM2,
                p_PARAM3 = msg.p_PARAM3,
                p_PARAM4 = msg.p_PARAM4            
            });
            db.Close();
            return result.ToList();
        }
    }
}