using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA200002Master
{
    public class DISA200002
    {
        public string ID { get; set; }
        public string CODE { get; set; }
        public string MAINBUMO { get; set; }
        public string UOM { get; set; }
        public string HOKAN { get; set; }
        public string ZAIK { get; set; }
        public string BIKOU { get; set; } //jenis

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}