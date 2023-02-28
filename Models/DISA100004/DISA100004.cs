using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA100004Master
{
    public class DISA100004
    {
        public string id { get; set; }
        public string item_code { get; set; }
        public string lot_size { get; set; }
        public string master_qty { get; set; }
        public string box_qty { get; set; }
        public string weight { get; set; }
        public string total_weight { get; set; }
        public string jenis_transportation { get; set; }
        public string transportation_cost { get; set; }
        public string awb_free_jpn { get; set; }
        public string edi_free_jpn { get; set; }
        public string ams_free_jpn { get; set; }
        public string trucking_0_250_kg_jpn { get; set; }
        public string handling_air_under_50_kg_jpn { get; set; }
        public string handling_air_upto_50_kg { get; set; }
        public string total_cost { get; set; }

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}