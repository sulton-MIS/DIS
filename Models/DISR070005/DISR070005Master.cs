using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AI070.Models.DISR070005Master
{
    public class DISR070005Master
    {
        public string ID { get; set; }
        public string ID_TOOL { get; set; }
        public string NAME_TOOL { get; set; }
        public string FACTORY { get; set; }
        public string LIFETIME { get; set; }
        public string TOTAL_SHOOT { get; set; }
        public string LIMIT { get; set; }
        public string STATUS { get; set; }
        public string TIME_KOSHIN { get; set; }

        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }       

    }



    public class DISA10001_TOOL_INPUT_FORM
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("ID_TOOL")]
        public string ID_TOOL { get; set; }

        [JsonProperty("NAME_TOOL")]
        public string NAME_TOOL { get; set; }

        [JsonProperty("FACTORY")]
        public string FACTORY { get; set; }

        [JsonProperty("LIFETIME")]
        public string LIFETIME { get; set; }

        [JsonProperty("TOTAL_SHOOT")]
        public string TOTAL_SHOOT { get; set; }

        [JsonProperty("LIMIT")]
        public string LIMIT { get; set; }

        [JsonProperty("STATUS")]
        public string STATUS { get; set; }

        [JsonProperty("DMC_CODE")]
        public string DMC_CODE { get; set; }

        [JsonProperty("list_detail_create")]
        public List<list_detail_create_model> list_detail_create { get; set; } //list multiple data

        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class list_detail_create_model
    {
        public string ID { get; set; }
        public string ID_TOOL { get; set; }
        public string NAME_TOOL { get; set; }
        public string LIFETIME { get; set; }
        public string TOTAL_SHOOT { get; set; }
        public string LIMIT { get; set; }
        public string DMC_CODE { get; set; }
    }


}