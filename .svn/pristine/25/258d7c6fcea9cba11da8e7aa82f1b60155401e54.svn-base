using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Web.Platform;
using Toyota.Common.Database;

namespace AI070.Models.Shared
{
    public class Notice
    {
        public string MANIFEST_NO { get; set; }
        public string NOTICE_ID { get; set; }
        public string PROCESS_TYPE { get; set; }
        public string REF_DOC_NO { get; set; }
        public string NOTICE_MSG { get; set; }
        public string READ_FLG { get; set; }
        public string NOTICE_BY { get; set; }
        public string NOTICE_DT { get; set; }

        public List<Notice> GetListNotice(Notice ntc)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Query<Notice>(
                "Notice/Notice_GetListNotice",
                new
                {
                    MANIFEST_NO = ntc.MANIFEST_NO
                }
            );
            db.Close();
            return res.ToList();
        }


        public string Send_Notice(Notice ntc)
        {

            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Execute(
                "Notice/Notice_Send_Notice",
                new
                {
                    REF_DOC_NO = ntc.MANIFEST_NO,
                    NOTICE_MSG = ntc.NOTICE_MSG,
                    NOTICE_BY = ntc.NOTICE_BY

                }
            );
            db.Close();
            return res.ToString();
        }

        public string updateReadFlag(Notice ntc) {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var res = db.Execute(
                "Notice/Notice_UpdateReadFlag_Notice",
                new
                {
                    REF_DOC_NO = ntc.MANIFEST_NO

                }
            );
            db.Close();
            return res.ToString();
        }
    }
}