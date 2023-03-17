using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02003Master
{
    public class WP02003Master
    {
        // untuk combobox Time 
        public Int64 ID { get; set; }
        public string WP_DAILY_ID { get; set; }
        public string PROJECT_ID { get; set; }
        public string PROJECT_JOB_ID { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
        public string AREA_NAME { get; set; }
        public string LOC_NAME { get; set; }
        public string DOCS { get; set; }
        public string ID_TB_M_LOCATION { get; set; }
        public string ID_TB_M_AREA { get; set; }
        public string IMPLEMENT_DATE_FROM { get; set; }
        public string IMPLEMENT_DATE_TO { get; set; }
        public string IMPLEMENT_DATE_FROM_DISP { get; set; }
        public string IMPLEMENT_DATE_TO_DISP { get; set; }
        public string DEP_OR_DIV_CODE { get; set; }
        public string WORKING_STATUS_DESC { get; set; }
        public string WORKING_STATUS { get; set; }
        public string WORKING_NOTES { get; set; }
        public string PROJECT_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public DateTime? CHANGED_DT { get; set; }
        public string STATUS { get; set; }
        public string STATUS_ID { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string UPLOADED_BY { get; set; }
        public string UPLOADED_DT { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
        public DateTime DATE_FROM { get; set; }
        public DateTime DATE_TO { get; set; }
        public string PROJECT_AREA { get; set; }
        public string PROJECT_LOCATION { get; set; }
        public string EXECUTOR { get; set; }
        public string DIVISI { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string TITLE { get; set; }


    }

}