using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP0102Master
{
    public class WP0102Master
    {
        public Int64 ID { get; set; }
        public string Project_CD { get; set; }
        public string Location { get; set; }
        public string Jobs { get; set; }
        public Int32 LowLevel { get; set; }
        public Int32 MediumLevel { get; set; }
        public Int32 HighLevel { get; set; }
        public string DATE { get; set; }
        public string CATEGORY { get; set; }
        public string REMARKS { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string UPLOADED_BY { get; set; }
        public string UPLOADED_DT { get; set; }
        public string CREATE_BY { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_BY { get; set; }
        public string UPDATE_DT { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}