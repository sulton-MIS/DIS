using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR190001Master
{
    public class DISR190001
    {
        public string id { get; set; }
        //public DateTime target_date { get; set; }
        //public decimal target_amount { get; set; }
        
        public string ID_PRODUKSI { get; set; }
        public string DMC_CODE { get; set; }
        public string DMC_PART { get; set; }
        public string LOT_NO { get; set; }
        public string KODE_PROSES { get; set; }
        public string KODE_MESIN { get; set; }
        public string WAKTU_BUAT { get; set; }
        public string WAKTU_SETTING { get; set; }
        public string WAKTU_UPDATE { get; set; }
        public string WAKTU_SELESAI { get; set; }
        public string QTY_SCHEDULE { get; set; }
        public string QTY_OK { get; set; }
        public string QTY_PND { get; set; }
        public string QTY_NG { get; set; }
        public string QTY_TOTAL { get; set; }
        public string ID_SAGYO_1 { get; set; }
        public string ID_SAGYO_2 { get; set; }
        public string ID_SAGYO_3 { get; set; }
        public string Z_INPUTUSER_ADM { get; set; }

        //Master Kotei
        public string NAMA_PROSES { get; set; }

        //Master Kikai
        public string NAMA_MESIN { get; set; }

        //Master Sagyosha
        //public string NAME_SAGYOSHA { get; set; }

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}