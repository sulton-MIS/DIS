using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AI070.Models
{
    public static class StaticMessage
    { 
        public static string DeleteSuccess = ConfigurationManager.AppSettings["DeleteSuccess"];
        public static string DeleteError = ConfigurationManager.AppSettings["DeleteError"]; 
        public static string SaveSuccess = ConfigurationManager.AppSettings["SaveSuccess"];
        public static string UpdateError = ConfigurationManager.AppSettings["UpdateError"];
        public static string InsertError = ConfigurationManager.AppSettings["InsertError"];
        public static string InsertDuplicate = ConfigurationManager.AppSettings["InsertDuplicate"];
        public static string InsertFailed = ConfigurationManager.AppSettings["InsertFailed"];
        public static string RetrieveError = ConfigurationManager.AppSettings["RetrieveError"];
        public static string DataNotFound = ConfigurationManager.AppSettings["DataNotFound"];
        public static string ConcurencyError = ConfigurationManager.AppSettings["ConcurencyError"];
        public static string FormatNotValid = ConfigurationManager.AppSettings["FormatNotValid"];
        public static string Confirm = ConfigurationManager.AppSettings["Confirm"];
        public static string RetrievalSuccess = ConfigurationManager.AppSettings["RetrievalSuccess"];

        public const string VIEW_DATE = "dd-MM-yyyy";
        public static string FormatDateOrNull(this string datetime)
        {
            DateTime d = new DateTime(1900, 1, 1);
            string v = "";

            if (DateTime.TryParseExact(datetime,
                                       VIEW_DATE + " hh:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None,
                                       out d))
            { v = d.ToString(VIEW_DATE); }
            else if (DateTime.TryParseExact(datetime,
                                       "MM/dd/yyyy hh:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None,
                                       out d))
            { v = d.ToString(VIEW_DATE); }
            else if (DateTime.TryParseExact(datetime,
                                   "dd/MM/yyyy hh:mm:ss",
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None,
                                   out d))
            { v = d.ToString(VIEW_DATE); }
            else if (DateTime.TryParseExact(datetime,
                                   "M/d/yyyy hh:mm:ss",
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None,
                                   out d))
            { v = d.ToString(VIEW_DATE); }
            else if (DateTime.TryParseExact(datetime,
                                   "d/M/yyyy hh:mm:ss",
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None,
                                   out d))
            { v = d.ToString(VIEW_DATE); }
            else if (DateTime.TryParseExact(datetime,
                              "d/m/yyyy hh:mm:ss",
                              System.Globalization.CultureInfo.InvariantCulture,
                              System.Globalization.DateTimeStyles.None,
                              out d))
            { v = d.ToString(VIEW_DATE); }
            else if (DateTime.TryParseExact(datetime,
                              "D/M/yyyy hh:mm:ss",
                              System.Globalization.CultureInfo.InvariantCulture,
                              System.Globalization.DateTimeStyles.None,
                              out d))
            { v = d.ToString(VIEW_DATE); }
            else
            {
                v = datetime;
            }

            return v;
        }
        public static string FormatDateOrNull(this DateTime datetime)
        {
            return datetime.ToString(VIEW_DATE);
        }
    }
}