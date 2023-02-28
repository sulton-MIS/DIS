using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA070001Master
{
    public class DISA070001
    {        
        public string ID { get; set; }
        public string DATE { get; set; }
        public string TIME { get; set; }
        public string HALTE { get; set; }
        public string OPMJ { get; set; }
        public string MASALAH { get; set; }
        public string ACTION { get; set; }

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}