using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR090001Master
{
    public class DISR090001
    {
        public string id { get; set; }
        public string id_sagyosha { get; set; }
        public string name_sagyosha { get; set; }
        public string flg_opmj { get; set; }
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}