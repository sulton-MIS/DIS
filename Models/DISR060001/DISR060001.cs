using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR060001Master
{
    public class DISR060001
    {
        public string ID { get; set; }
        public string i_user { get; set; }
        public string c_pwd { get; set; }
        public string i_user_long { get; set; }
        public string dept { get; set; }
        public string authority { get; set; }
        public string e_mail { get; set; }
        public string EmailSender { get; set; }
        public string section { get; set; }
        public string IdLevel { get; set; }
        public string IdAccessable { get; set; }
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}