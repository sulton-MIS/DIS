using AI070.Models.WP02002Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02002
{
    public class WP02002InputForm
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("IMPLEMENTOR_ID")]
        public string IMPLEMENTOR_ID { get; set; }

        [JsonProperty("WP_IMPB_NO")]
        public string WP_IMPB_NO { get; set; }

        [JsonProperty("ID_TB_M_AREA")]
        public string ID_TB_M_AREA { get; set; }

        [JsonProperty("WP_PROJECT_CODE")]
        public string WP_PROJECT_CODE { get; set; }

        [JsonProperty("JOB_STATUS")]
        public string JOB_STATUS { get; set; }

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

        [JsonProperty("project_list_shift")]
        public List<shift_model> project_list_shift { get; set; }

        [JsonProperty("project_henkaten_env")]
        public henkaten_env_model project_henkaten_env { get; set; }

        [JsonProperty("project_henkaten_safety")]
        public henkaten_safety_model project_henkaten_safety { get; set; }

        [JsonProperty("WP_PROJECT_ID")]
        public string WP_PROJECT_ID { get; set; }

        [JsonProperty("JOB_NAME")]
        public string JOB_NAME { get; set; }

        [JsonProperty("WP_PROJECT_JOB_ID")]
        public string WP_PROJECT_JOB_ID { get; set; }

        [JsonProperty("RISK_LEVEL")]
        public string RISK_LEVEL { get; set; }

        [JsonProperty("JOB_TYPE")]
        public string JOB_TYPE { get; set; }

        [JsonProperty("MasterData")]
        public WP02002Master.WP02002Master MasterData { get; set; }

        [JsonProperty("WorkingStr")]
        public string WorkingStr { get; set; }

        [JsonProperty("IdentificationStr")]
        public string IdentificationStr { get; set; }

        [JsonProperty("ImpactStr")]
        public string ImpactStr { get; set; }

        [JsonProperty("Supervisionstr")]
        public string Supervisionstr { get; set; }

        //IMPB LOCATION

        [JsonProperty("topPos")]
        public string TOP_POS { get; set; }

        [JsonProperty("leftPos")]
        public string LEFT_POS { get; set; }

        [JsonProperty("heightSquare")]
        public string HEIGHT_SQUARE { get; set; }

        [JsonProperty("widthSquare")]
        public string WIDTH_SQUARE { get; set; }

        [JsonProperty("windowWidth")]
        public string WINDOW_WIDTH { get; set; }

        [JsonProperty("windowHeight")]
        public string WINDOW_HEIGHT { get; set; }

        [JsonProperty("borderColor")]
        public string BORDER_COLOR { get; set; }
        [JsonProperty("rotate")]
        public string ROTATE { get; set; }

        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class henkaten_safety_model
    {
        public string ID { get; set; }
        public string IS_HENKATEN_SAFETY { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string HK_SAFETY_PROCESS { get; set; }
        public string HK_SAFETY_MACHINE { get; set; }
        public string HK_SAFETY_MODIFICATION { get; set; }
    }

    public class henkaten_env_model
    {
        public string ID { get; set; }
        public string IS_HENKATEN_ENV { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string HK_ENV_PROCESS { get; set; }
        public string HK_ENV_MACHINE { get; set; }
        public string HK_ENV_MATERIAL { get; set; }
        public string HK_ENV_BUILDING { get; set; }
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
    }

    public class shift_model
    {
        public string ID { get; set; }
        public string WP_PROJECT_JOB_ID { get; set; }
        public string SHIFT_ID { get; set; }
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