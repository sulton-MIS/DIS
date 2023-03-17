using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02005
{
    public class WP02005InputForm
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("WP_PROJECT_ID")]
        public string WP_PROJECT_ID { get; set; }

        [JsonProperty("JOB_NAME")]
        public string JOB_NAME { get; set; }

        [JsonProperty("WP_PROJECT_JOB_ID")]
        public string WP_PROJECT_JOB_ID { get; set; }

        [JsonProperty("WP_IMPB_NO")]
        public string WP_IMPB_NO { get; set; }

        [JsonProperty("WP_PROJECT_CODE")]
        public string WP_PROJECT_CODE { get; set; }

        [JsonProperty("JOB_STATUS")]
        public string JOB_STATUS { get; set; }

        [JsonProperty("PROJECT_STATUS")]
        public string PROJECT_STATUS { get; set; }

        [JsonProperty("PROJECT_NAME")]
        public string PROJECT_NAME { get; set; }

        [JsonProperty("INCIDENT_TITLE")]
        public string INCIDENT_TITLE { get; set; }

        [JsonProperty("INCIDENT_DESCRIPTION")]
        public string INCIDENT_DESCRIPTION { get; set; }

        [JsonProperty("SUPPORT_PHOTO")]
        public string SUPPORT_PHOTO { get; set; }

        [JsonProperty("SUPPORT_DOC")]
        public string SUPPORT_DOC { get; set; }

        [JsonProperty("RATING_CONTRACTOR")]
        public string RATING_CONTRACTOR { get; set; }

        [JsonProperty("RATING_LEADER")]
        public string RATING_LEADER { get; set; }

        [JsonProperty("RATING_SUPERVISOR")]
        public string RATING_SUPERVISOR { get; set; }

        [JsonProperty("RATING_WORKER")]
        public string RATING_WORKER { get; set; }

        [JsonProperty("EVALUATION_NOTES")]
        public string EVALUATION_NOTES { get; set; }

        [JsonProperty("STATUS")]
        public string STATUS { get; set; }

        [JsonProperty("TYPES")]
        public string TYPES { get; set; }

        public string STACK { get; set; }
        public string LINE_STS { get; set; }

        [JsonProperty("ItemCheckList")]
        public List<ItemCheckModel> ItemCheckList { get; set; }
    }

    public class IncidentModel
    {
        public int ID { get; set; }
        public int WP_PROJECT_JOB_ID { get; set; }
        public string INCIDENT_TITLE { get; set; }
        public int ID_TB_M_EMPLOYEE { get; set; }
        public int ID_TB_M_COMPANY { get; set; }
        public int ID_TB_M_AREA { get; set; }
        public string INCIDENT_DATE { get; set; }
        public string INCIDENT_LEVEL { get; set; }
        public string ATTACHMENT { get; set; }
        public int? USER_REPORT { get; set; }
        public string ACTION { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public DateTime? CHANGED_DT { get; set; }

        public string WP_IMPB_NO { get; set; }
        public string PIC_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string AREA_NAME { get; set; }
        public string REPORTER_NAME { get; set; }
    }

    public class ItemCheckModel
    {
        public int ID { get; set; }
        public int WP_PROJECT_JOB_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public int ID_TB_M_EMPLOYEE { get; set; }
        public string ITEM_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public DateTime? CHANGED_DT { get; set; }

        public string PIC_NAME { get; set; }
    }
}