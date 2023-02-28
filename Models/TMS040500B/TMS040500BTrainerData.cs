using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AD021.Models.TMS040500B
{
    public class TMS040500BTrainerData
    {
        public string TRAINING_SCH_ID { get; set; }
        public string TRAINER_ID { get; set; }
        public string NAME { get; set; }
        public string CLASS { get; set; }
        public string POSITION { get; set; }
        public string DIVISION { get; set; }
        public string DEPARTEMENT { get; set; }
        public string EMAIL { get; set; }
        public int TRAINING_DAY { get; set; }
        public DateTime TRAINING_DATE { get; set; }
        public string TRAINING_DAY_NAME { get; set; }
        public string TRAINING_TIME { get; set; }
        public string TRAINER_BU_STS { get; set; }
        public int TRAINER_SEQ { get; set; }
        public DateTime APPROVED_DT { get; set; }
        public string APPROVED_BY { get; set; }
        public DateTime REJECTED_DT { get; set; }
        public string REJECTED_DY { get; set; }
    }
}