using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA100003Master
{
    public class DISA100003
    {
        public string id { get; set; }
        public string item_code { get; set; }
        public string jenis_packing { get; set; }
        public string qty_pcs { get; set; }
        public string factory_size { get; set; }
        public string indirect { get; set; }
        public string berat { get; set; }
        public string panjang { get; set; }
        public string lebar { get; set; }
        public string tinggi { get; set; }
        public string harga { get; set; }
        
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}