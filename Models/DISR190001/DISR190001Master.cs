using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR190001Master
{
    public class DISR190001Master
    {
        public string ID { get; set; }
        public string ID_PRODUKSI { get; set; }
        public string ID_SEISAN { get; set; }
        public string ID_SEIHIN { get; set; }
        public string ID_HINMOKU { get; set; }
        public string OTHER_LOTNO { get; set; }
        public string ID_KOTEI { get; set; }
        public string ID_KIKAI { get; set; }
        public string TIME_SAGYO { get; set; }
        public string TIME_DANDORI { get; set; }
        public string TIME_KOSHIN { get; set; }
        public string TIME_KANRYO { get; set; }
        public string TIME_SAKUSEI { get; set; }
        public string AMNT_YOTEI { get; set; }
        public string AMNT_OK { get; set; }
        public string AMNT_PND { get; set; }
        public string AMNT_NG { get; set; }
        public string QTY_TOTAL { get; set; }
        public string ID_SAGYOSHA1 { get; set; }
        public string ID_SAGYOSHA2 { get; set; }
        public string ID_SAGYOSHA3 { get; set; }
        public string Z_INPUTUSER_ADM { get; set; }
        public string FRG_OUTPUT { get; set; }
        
        //Master Kotei
        public string NAME_KOTEI { get; set; }

        //Master Kikai
        public string NAME_KIKAI { get; set; }

        //Master Sagyosha
        //public string NAME_SAGYOSHA { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}