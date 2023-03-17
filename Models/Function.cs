using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models
{
    public class Function
    {
        public string MODULE_ID { get; set; }
        public string FUNCTION_ID { get; set; }
        public string FUNCTION_TYPE { get; set; }
        public string FUNCTION_NAME { get; set; }
        public DateTime CREATED_DT { get; set; }
        public DateTime? CHANGED_DT { get; set; }
        public string CREATED_BY { get; set; }
        public string CHANGED_BY { get; set; }
    }
}