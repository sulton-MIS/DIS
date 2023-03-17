using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WPMemberMaster
{
    public class WPMemberMaster
    {
        public string SYSTEM_ID { get; set; }
        public string SYSTEM_TYPE { get; set; }
        public string SYSTEM_CD { get; set; }
        public string SYSTEM_VALID_FR { get; set; }
        public string SYSTEM_VALID_TO { get; set; }
        public string SYSTEM_VALUE_TXT { get; set; }
        public string SYSTEM_VALUE_DT { get; set; }
        public string SYSTEM_VALUE_NUM { get; set; }
        public string SYSTEM_DESC { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public string CHANGED_DT { get; set; }
        public string STATUS { get; set; }
        public string STATUS_ID { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string UPLOADED_BY { get; set; }
        public string UPLOADED_DT { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}