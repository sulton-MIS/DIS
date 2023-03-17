﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP04002Master
{
    public class WP04002Master
    {
        public string ID { get; set; }
        public string USERNAME { get; set; }
        public string PLANT_CD { get; set; }
        public string PLANT_NM { get; set; }
        public string ROLE_NAME { get; set; }
        public string ROLE_CD { get; set; }
        public string ROLE_DESC { get; set; }
        public string AUTH_ID { get; set; }
        public string AUTH_NAME { get; set; }
        public string SESSION_TIME_OUT { get; set; }
        public string LOCK_TIME_OUT { get; set; }
        public string ROLE_ST { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public string UPDATED_DT { get; set; }
        public string STATUS { get; set; }
        public string STATUS_ID { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

}