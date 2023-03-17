using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02001
{
    public class WP02001InputForm
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("WP_IMPB_NO")]
        public string WP_IMPB_NO { get; set; }

        [JsonProperty("ID_TB_M_AREA")]
        public string ID_TB_M_AREA { get; set; }

        [JsonProperty("WP_PROJECT_CODE")]
        public string WP_PROJECT_CODE { get; set; }

        [JsonProperty("PROJECT_STATUS")]
        public string PROJECT_STATUS { get; set; }

        [JsonProperty("WP_PROJECT_NAME")]
        public string WP_PROJECT_NAME { get; set; }

        [JsonProperty("ID_TB_M_LOCATION")]
        public string ID_TB_M_LOCATION { get; set; }

        [JsonProperty("DEP_OR_DIV_CODE")]
        public string DEP_OR_DIV_CODE { get; set; }

        [JsonProperty("IMPLEMENT_DATE_FROM")]
        public DateTime IMPLEMENT_DATE_FROM { get; set; }

        [JsonProperty("IMPLEMENT_DATE_TO")]
        public DateTime IMPLEMENT_DATE_TO { get; set; }

        [JsonProperty("IMPLEMENT_TIME_FROM")]
        public string IMPLEMENT_TIME_FROM { get; set; }

        [JsonProperty("WORKING_STATUS")]
        public string WORKING_STATUS { get; set; }

        [JsonProperty("WORKING_NOTES")]
        public string WORKING_NOTES { get; set; }

        [JsonProperty("EXECUTOR")]
        public string EXECUTOR { get; set; }

        [JsonProperty("ID_TB_M_COMPANY")]
        public string ID_TB_M_COMPANY { get; set; }

        [JsonProperty("EMPLOYEE_LEAD_PROJECT")]
        public string EMPLOYEE_LEAD_PROJECT { get; set; }

        [JsonProperty("EMPLOYEE_SUPERVISOR_PROJECT")]
        public string EMPLOYEE_SUPERVISOR_PROJECT { get; set; }

        [JsonProperty("project_job")]
        public List<project_job_model> project_job { get; set; }

        [JsonProperty("project_list_working")]
        public List<working_model> project_list_working { get; set; }

        [JsonProperty("project_list_identification")]
        public List<identification_model> project_list_identification { get; set; }

        [JsonProperty("project_list_impact")]
        public List<impact_model> project_list_impact { get; set; }

        [JsonProperty("project_list_supervision")]
        public List<pengawasan_model> project_list_supervision { get; set; }

        [JsonProperty("project_list_implementor")]
        public List<implementor_model> project_list_implementor { get; set; }

        [JsonProperty("WP_PROJECT_ID")]
        public string WP_PROJECT_ID { get; set; }

        [JsonProperty("JOB_NAME")]
        public string JOB_NAME { get; set; }

        [JsonProperty("WP_PROJECT_JOB_ID")]
        public string WP_PROJECT_JOB_ID { get; set; }

        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class Sequence_model
    {
        public string ID { get; set; }
        public string TYPE_TRX { get; set; }
        public string YEAR_TRX { get; set; }
        public string MONTH_TRX { get; set; }
        public string SEQ_NUMBER { get; set; }
    }
    public class implementor_model
    {
        public string ID { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string EXECUTOR { get; set; }
        public string ID_TB_M_COMPANY { get; set; }
        public string EMPLOYEE_LEAD_PROJECT { get; set; }
        public string EMPLOYEE_SUPERVISOR_PROJECT { get; set; }
    }

    public class project_job_model
    {
        public string ID { get; set; }
        public string JOB_NAME { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
        public string JOB_STATUS { get; set; }
    }

    public class working_model
    {
        public string ID { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string ID_TB_M_WORKING_TYPE { get; set; }
        public string DANGER_TYPE { get; set; }
        public string DAY_1 { get; set; }
        public string DAY_2 { get; set; }
        public string DAY_3 { get; set; }
        public string DAY_4 { get; set; }
        public string DAY_5 { get; set; }
        public string DAY_6 { get; set; }
        public string DAY_7 { get; set; }
        public string SIX_A { get; set; }
        public string SIX_B { get; set; }
        public string SIX_C { get; set; }
        public string SIX_D { get; set; }
        public string SIX_E { get; set; }
        public string SIX_F { get; set; }
        public string SIX_ALPHA { get; set; }
    }

    public class identification_model
    {
        public string ID { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string ID_TB_M_WORKING_TYPE { get; set; }
        public string IDENTITY_DANGER_POTENTIAL { get; set; }
        public string IDENTITY_DANGER_PREVENTION { get; set; }
        public string ID_TB_M_EMPLOYEE { get; set; }
        public string HENKANTEN_SAFETY { get; set; }

    }

    public class impact_model
    {
        public string ID { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string ID_TB_M_WORKING_TYPE { get; set; }
        public string IDENTITY_IMPACT_POTENTIAL { get; set; }
        public string IDENTITY_IMPACT_PREVENTION { get; set; }
        public string ID_TB_M_EMPLOYEE { get; set; }
        public string HENKANTEN_ENV { get; set; }

    }

    public class pengawasan_model
    {
        public string ID { get; set; }
        public string WP_IMPB_NO { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string ID_TB_M_EMPLOYEE { get; set; }
     

    }
}