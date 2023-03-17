﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP01003Master
{
    public class WP01003Master
    {
        public Int32 ID { get; set; }
        public string AREA_ID { get; set; }
        public string AREA_CD { get; set; }
        public string AREA_NAME { get; set; }
        public string LOC_CD { get; set; }
        public string LOC_NAME { get; set; }
        public string LONG { get; set; }
        public string LAT { get; set; }
        public string WIDE { get; set; }
        public string POINT { get; set; }
        public string CREATE_BY { get; set; }
        public DateTime CREATE_DT { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DT { get; set; }
        public string STATUS { get; set; }
        public string STATUS_ID { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}