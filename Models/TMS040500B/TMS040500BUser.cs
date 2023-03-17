using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AD021.Models.TMS040500B
{
    public class TMS040500BUser
    {
        public String USER_ID { get; set; }
        public String USER_PASS { get; set; }
        public String EMAIL { get; set; }

        public String USER_NOREG { get; set; }
        public String USER_ROLE { get; set; }
        public String USER_NAME { get; set; }
        public String DIVISION_CD { get; set; }
        public String CLASS_NO { get; set; }
        public DateTime PASSWORD_EXP_DT { get; set; }
        public DateTime LAST_CHANGE_PASSWORD { get; set; }
        public String USER_STS { get; set; }
        public String USER_LOGIN_STS { get; set; }
        public String USER_PASSWORD { get; set; }
        public String USER_GROUP { get; set; }
        public String CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public String UPDATED_BY { get; set; }
        public DateTime UPDATED_DT { get; set; }
    }
}