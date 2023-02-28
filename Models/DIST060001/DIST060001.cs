using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DIST060001Master
{
    public class DIST060001
    {
        public string id { get; set; }
        public string ItemCode { get; set; }
        public string Parts { get; set; }
        public string SizeProduct { get; set; }
        public string type { get; set; }
        public string BundleQty { get; set; }
        public string InnerQty { get; set; }
        public string MasterQty { get; set; }
        public string InnerType { get; set; }
        public string InnerL { get; set; }
        public string InnerW { get; set; }
        public string InnerH { get; set; }
        public string InnerWeight { get; set; }
        public string MasterType { get; set; }
        public string MasterL { get; set; }
        public string MasterW { get; set; }
        public string MasterH { get; set; }
        public string MasterWeight { get; set; }


        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}