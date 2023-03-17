using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02002Master
{
    public class WP02002Master
    {
		public int ROW_NUM { get; set; }
		public int ID { get; set; }
		public int WP_PROJECT_ID { get; set; }
		public int WP_PROJECT_JOB_ID { get; set; }
		public string JOB_NAME { get; set; }
		public string WP_IMPB_NO { get; set; }
		public string JOB_STATUS { get; set; }
		public string PROJECT_CODE { get; set; }
		public string PROJECT_NAME { get; set; }
		public int ID_TB_M_AREA { get; set; }
		public string AREA_NAME { get; set; }
		public string IMAGE_PATH { get; set; }
		public int ID_TB_M_LOCATION { get; set; }
		public string LOC_NAME { get; set; }
		public string DEP_OR_DIV_CODE { get; set; }
		public string IMPLEMENT_DATE_FROM { get; set; }
		public string IMPLEMENT_DATE_TO { get; set; }
		public string IMPLEMENT_DATE_FROM_DISP { get; set; }
		public string IMPLEMENT_DATE_TO_DISP { get; set; }
		public string WORKING_STATUS_DESC { get; set; }
		public string WORKING_STATUS { get; set; }
		public string WORKING_NOTES { get; set; }
		public string PROJECT_STATUS { get; set; }
		public string EXECUTOR { get; set; }
		public string EXECUTOR_DESC { get; set; }
		public int? ID_TB_M_COMPANY { get; set; }
		public string COMPANY_NAME { get; set; }
		public int? EMPLOYEE_LEAD_PROJECT { get; set; }
		public string LEADER_NAME { get; set; }
		public int? EMPLOYEE_SUPERVISOR_PROJECT { get; set; }
		public string SUPERVISOR_NAME { get; set; }
		public string DIV { get; set; }
		public string START_DATE { get; set; }
		public string END_DATE { get; set; }
		public string CREATED_BY { get; set; }
		public DateTime CREATED_DT { get; set; }
		public string CHANGED_BY { get; set; }
		public DateTime? CHANGED_DT { get; set; }
		public string STACK { get; set; }
        public string LINE_STS { get; set; }

		public string RISK_LEVEL { get; set; }
    }

}