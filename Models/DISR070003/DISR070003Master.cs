using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR070003Master
{
    public class DISR070003Master
    {
        public string ID { get; set; }
        public string id_kotei { get; set; }
        public string name_kotei { get; set; }
        public string halte { get; set; }
        public string id_koteishubetsu { get; set; }
        public string name_koteishubetsu { get; set; }
        public string flg_increByCavity { get; set; }
        public string rate_handankaishi { get; set; }
        public string rate_ALRTchien { get; set; }
        public string rate_chinritsu { get; set; }
        public string rate_warikomikyoyouritsu { get; set; }
        public string id_gamenshubetsu { get; set; }
        public string flg_RTJNon { get; set; }
        public string comment { get; set; }
        public string flg_rimen { get; set; }
        public string flg_need_tool { get; set; }
        public string time_koshin { get; set; }
        public string flag_logical { get; set; }
        public string initial_process { get; set; }
        public string flg_check_schedule { get; set; }
        public string flg_disp_material { get; set; }
        public string flg_warning_material { get; set; }
        public string flg_daily_loss { get; set; }
        public string flg_oven { get; set; }
        public string group_process { get; set; }
        public string category { get; set; }
        public string sort_no { get; set; }
        public string flg_chokoritsu { get; set; }
        public string bgcolor { get; set; }
        public string group_process_cost { get; set; }
        public string type_process { get; set; }
        public string category_process { get; set; }
        public string flg_protect_skill { get; set; }
        public string prod_cost_level { get; set; }
        public string flg_use_cl { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}