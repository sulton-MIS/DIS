using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA100002Master
{
    public class DISA100002
    {
        public string ID { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string AREA { get; set; }
        
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}