using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP02003
{
    public class WP02003InputForm
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("TB_R_WP_DAILY_ID")]
        public string TB_R_WP_DAILY_ID { get; set; }

        [JsonProperty("WP_PROJECT_ID")]
        public string WP_PROJECT_ID { get; set; }

        [JsonProperty("WP_PROJECT_CODE")]
        public string WP_PROJECT_CODE { get; set; }

        [JsonProperty("WP_PROJECT_NAME")]
        public string WP_PROJECT_NAME { get; set; }

        [JsonProperty("WP_PROJECT_JOB_ID")]
        public string WP_PROJECT_JOB_ID { get; set; }

        [JsonProperty("JOB_NAME")]
        public string JOB_NAME { get; set; }

        [JsonProperty("JOB_TITLE")]
        public string JOB_TITLE { get; set; }

        [JsonProperty("ID_TB_M_LOCATION")]
        public string ID_TB_M_LOCATION { get; set; }

        [JsonProperty("ID_TB_M_AREA")]
        public string ID_TB_M_AREA { get; set; }

        [JsonProperty("IMPLEMENT_DATE_FROM")]
        public DateTime IMPLEMENT_DATE_FROM { get; set; }

        [JsonProperty("IMPLEMENT_DATE_TO")]
        public DateTime IMPLEMENT_DATE_TO { get; set; }

        [JsonProperty("ID_TB_M_COMPANY")]
        public string ID_TB_M_COMPANY { get; set; }

        [JsonProperty("COMPANY_NAME")]
        public string COMPANY_NAME { get; set; }

        [JsonProperty("TB_M_ITEM_ID")]
        public string TB_M_ITEM_ID { get; set; }

        [JsonProperty("ITEM_NAME")]
        public string ITEM_NAME { get; set; }

        [JsonProperty("DAILY_DOC")]
        public string DAILY_DOC { get; set; }

        [JsonProperty("TB_M_EMPLOYEE_ID")]
        public string TB_M_EMPLOYEE_ID { get; set; }

        [JsonProperty("WORKING_NAME")]
        public string WORKING_NAME { get; set; }

        [JsonProperty("TIME_FROM")]
        public string TIME_FROM { get; set; }

        [JsonProperty("TIME_TO")]
        public string TIME_TO { get; set; }

        [JsonProperty("STOP_SIX")]
        public string STOP_SIX { get; set; }

        [JsonProperty("WP_IMPB_NO")]
        public string WP_IMPB_NO { get; set; }

        [JsonProperty("PROJECT_STATUS")]
        public string PROJECT_STATUS { get; set; }

        [JsonProperty("DEP_OR_DIV_CODE")]
        public string DEP_OR_DIV_CODE { get; set; }

        [JsonProperty("IMPLEMENT_TIME_FROM")]
        public string IMPLEMENT_TIME_FROM { get; set; }

        [JsonProperty("WORKING_STATUS")]
        public string WORKING_STATUS { get; set; }

        [JsonProperty("WORKING_NOTES")]
        public string WORKING_NOTES { get; set; }

        [JsonProperty("EXECUTOR")]
        public string EXECUTOR { get; set; }

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

        [JsonProperty("LISTDATADAILYWORKEQUIPMENT")]
        public List<DATADAILYWORKEQUIPMENT> LISTDATADAILYWORKEQUIPMENT { get; set; }

        [JsonProperty("LISTDATADAILYUTILREQUEST")]
        public List<DATADAILYUTILREQUEST> LISTDATADAILYUTILREQUEST { get; set; }

        [JsonProperty("LISTDATADAILYAPD")]
        public List<DATADAILYAPD> LISTDATADAILYAPD { get; set; }

        [JsonProperty("LISTDATADAILYWORKERLIST")]
        public List<DATADAILYWORKERLIST> LISTDATADAILYWORKERLIST { get; set; }

        [JsonProperty("LISTDATADAILYWIDEN")]
        public List<DATADAILYWIDEN> LISTDATADAILYWIDEN { get; set; }

        [JsonProperty("STATUS")]
        public string STATUS { get; set; }

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

    public class DATADAILYWORKEQUIPMENT
    {
        public string TB_R_WP_DAILY_WORK_EQUIPMENT_ID { get; set; }
        public string TB_R_WP_DAILY_ID { get; set; }
        public string TITLE { get; set; }
        public string DAILY_DOC { get; set; }
        public string ITEM_NAME { get; set; }
        public string TB_M_ITEM_ID { get; set; }
        public string username { get; set; }
        public string ACTION { get; set; }
    }

    public class DATADAILYUTILREQUEST
    {
        public string TB_R_WP_DAILY_UTIL_REQUEST_ID { get; set; }
        public string TB_R_WP_DAILY_ID { get; set; }
        public string TB_M_ITEM_ID { get; set; }
        public string username { get; set; }
        public string ACTION { get; set; }
    }

    public class DATADAILYAPD
    {
        public string TB_R_WP_DAILY_APD_ID { get; set; }
        public string TB_R_WP_DAILY_ID { get; set; }
        public string TB_M_ITEM_ID { get; set; }
        public string username { get; set; }
        public string ACTION { get; set; }
    }

    public class DATADAILYWORKERLIST
    {
        public string TB_R_WP_DAILY_WORKER_LIST_ID { get; set; }
        public string TB_R_WP_DAILY_ID { get; set; }
        public string TB_M_EMPLOYEE_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string NIK { get; set; }
        public string username { get; set; }
        public string ACTION { get; set; }
    }

    public class DATADAILYWIDEN
    {
        public string TB_R_WP_DAILY_WI_DEN_ID { get; set; }
        public string TB_R_WP_DAILY_ID { get; set; }
        public string WORKING_NAME { get; set; }
        public string TIME_FROM { get; set; }
        public string TIME_TO { get; set; }
        public string STOP_SIX { get; set; }
        public string TB_M_EMPLOYEE_ID { get; set; }
        public string username { get; set; }
        public string ACTION { get; set; }
    }
}