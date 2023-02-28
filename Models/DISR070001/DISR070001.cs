using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR070001Master
{
    public class DISR070001
    {
        public string id { get; set; }
        public string id_sagyosha { get; set; }
        public string name_sagyosha { get; set; }
        public string dept { get; set; }
        public string bagian { get; set; }
        public string jabatan { get; set; }
        public string grp { get; set; }
        public DateTime time_koshin { get; set; }
        public DateTime tmk { get; set; }
        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}