using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP01006Master
{
    public class WP01006
    {
        public string AREA_CODE { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}