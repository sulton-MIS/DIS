using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP03004Master_Score
{
    public class WP03004Master_Score
    {
        public Int32 ROW_NUM { get; set; }
        public Int32 ID { get; set; }
        public Int32 ID_TB_M_EMPLOYEE { get; set; }
        public string ID_TB_R_LEARN_EXAM_SUBJECT { get; set; }
        public string ID_TB_M_COMPANY { get; set; }
        public string ANSWER { get; set; }
        public string CORRECT_AMOUNT { get; set; }
        public string WRONG_AMOUNT { get; set; }
        public string NOT_ANSWERED_AMOUNT { get; set; }
        public string REMEDIAL { get; set; }
        public string SCORE { get; set; }
        public string PASS_GRADUATED { get; set; }
        public string TIMER { get; set; }
        public Int16 SUBMIT_DATE { get; set; }
    }

}