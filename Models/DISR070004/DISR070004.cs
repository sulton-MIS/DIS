using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR070004Master
{
    public class DISR070004
    {
        public string ID { get; set; }
        public string id_kikai { get; set; }
        public string name_kikai { get; set; }
        public string id_koteishubetsu { get; set; }
        public string name_koteishubetsu { get; set; }
        public string IPaddress { get; set; }
        public string line { get; set; }
        public string cluster { get; set; }
        public string Factory { get; set; }
        public string comment { get; set; }
        public DateTime time_koshin { get; set; }
        public string group_kikai { get; set; }
        public string group_kikai_sort { get; set; }
        public bool flg_visible_oven { get; set; }
        public string machine_name { get; set; }
        public string initial_kikai { get; set; }

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}