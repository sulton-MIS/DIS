using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models
{
    public class BaseModel
    {
        public Guid SID { get; set; }
        public int Number { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string SCREEN_MODE { get; set; }
    }
}