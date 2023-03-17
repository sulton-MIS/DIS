﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02007Master
{
    public class WP02007
    {
        // untuk combobox Time 
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
        public string JOB_NAME { get; set; }
        public string DATE { get; set; }
        public string DATE_TO { get; set; }
        public string DIVISION { get; set; }
        public string LOCATION { get; set; }
        public string COMPANY { get; set; }
        public string TIME { get; set; }
        public string TIME_TO { get; set; }
        public string STATUS { get; set; }
        public string STATUS_TEXT { get; set; }
        // untuk combobox Time 
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
        public int RTN_ID { get; set; }
    }

}