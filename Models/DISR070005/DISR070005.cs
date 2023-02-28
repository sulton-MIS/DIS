using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR070005Master
{
    public class DISR070005
    {
        public string ID { get; set; }
        public string ID_TOOL { get; set; }
        public string NAME_TOOL { get; set; }
        public string FACTORY { get; set; }
        public string LIFETIME { get; set; }
        public string TOTAL_SHOOT { get; set; }
        public string LIMIT { get; set; }
        public string STATUS { get; set; }
        public string TIME_KOSHIN { get; set; }

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}