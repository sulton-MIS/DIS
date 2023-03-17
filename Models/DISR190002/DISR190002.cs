using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR190002Master
{
    public class DISR190002
    {
        public string ID { get; set; }
        public string ID_SEISAN { get; set; }
        public string CODE { get; set; }
        public string OTHER_LOTNO { get; set; }
        public string ID_KOTEI { get; set; }
        public string ID_JUCHUCHUBAN { get; set; }
        public string ID_SEISANRENBAN { get; set; }


        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}