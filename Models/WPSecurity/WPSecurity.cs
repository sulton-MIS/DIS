﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WPSecurityMaster
{
    public class WPSecurity
    {
        // untuk combobox Time 
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

    }

}