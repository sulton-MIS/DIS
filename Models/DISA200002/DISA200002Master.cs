using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA200002Master
{
    public class DISA200002Master
    {
        public string ID { get; set; }
        public string JENIS_MAT { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string MAINBUMO { get; set; }
        public string UOM { get; set; }
        public string HOKAN { get; set; }
        public string ZAIK { get; set; }
        public string BIKOU { get; set; } //jenis
        public string LOTTO { get; set; } 
        public string ADM_TPICS { get; set; } 
        public string OPT_PACKING { get; set; } 
        public string OPT_PRESS { get; set; }
        public string OPT_SCRIBE { get; set; } 
        public string QTY_PRINT { get; set; } 

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}