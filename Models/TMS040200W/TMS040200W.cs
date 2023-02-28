using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AD021.Models.TMS040200W
{
    public class TMS040200W
    {
        public string NAME { get; set; }
        public int NOREG { get; set; }
        public int CLASS { get; set; }
        public string POSITION { get; set; }
        public string DIVISION { get; set; }
        public string DEPARTEMENT { get; set; }
        public string EMAIL { get; set; }
        public string TRAINING_SCH_ID { get; set; }
        public string TRAINER_ID { get; set; }
        public int TRAINING_DAY { get; set; }
        public string TRAINING_TIME { get; set; }
        public string TRAINER_BU_STS { get; set; }
        public DateTime APPROVED_DT { get; set; }
        public string APPROVED_BY { get; set; }
        public DateTime REJECTED_DT { get; set; }
        public string REJECTED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime UPDATED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public string TRAINING_TOPIC_CD { get; set; }
        public string TRAINING_TOPIC_NM { get; set; }
        public DateTime TRAINING_SCH_FR { get; set; }
        public DateTime TRAINING_SCH_TO { get; set; }
        public string SCHEDULE { get; set; }
        public string PAX_STS { get; set; }
        public String TRAINING_SCH_STS { get; set; }
    }
}