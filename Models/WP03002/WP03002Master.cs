using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP03002Master
{
    public class WP03002Master
    {
        public Int32 ROW_NUM { get; set; }
        public Int32 ID { get; set; }
        public string TITLE { get; set; }
        public Int16 PASSING_SCORE_REQUIREMENT { get; set; }
        public Int16 EXAM_DURATION { get; set; }
        public DateTime DATE_START { get; set; }
        public DateTime DATE_END { get; set; }
        public Int16 REMEDIAL { get; set; }
        public string EXAM_TYPE { get; set; }
        public Int16 TOTAL_PUBLISHED { get; set; }
        public Int16 IS_PUBLISHED { get; set; }
        public string EXAM_FOR { get; set; }
        public Int16 IS_DELETED { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DT { get; set; }
        
    }

}