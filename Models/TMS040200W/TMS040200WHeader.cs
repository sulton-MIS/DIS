using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AD021.Models.TMS040200W
{
    public class TMS040200WHeader
    {
        public int TRAINING_SCH_ID { get; set; }
        public string TRAINING_TOPIC_CD { get; set; }
        public string TRAINING_SHIFT_COLOR { get; set; }
        public string TRAINING_TOPIC_NM { get; set; }
        public string LOCATION { get; set; }
        public DateTime TRAINING_SCH_FR { get; set; }
        public DateTime TRAINING_SCH_TO { get; set; }
        public string ROOM { get; set; }
        public int PARTICIPANT { get; set; }
        public string SCHEDULE { get; set; }
        public string LEVEL_PARTICIPANT { get; set; }
        public string TRAINING_SCH_STS { get; set; }

    }
}