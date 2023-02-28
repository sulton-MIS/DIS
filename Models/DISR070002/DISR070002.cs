using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR070002Master
{
    public class DISR070002
    {
        public string ID { get; set; }
        public string id_ng { get; set; }
        public string name_ng { get; set; }
        public DateTime time_koshin { get; set; }
        public bool NgStatus { get; set; }
        public bool flg_count { get; set; }
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}