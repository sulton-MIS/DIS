using System;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models
{
    public class UserInfo
    {
        public string NOREG { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public GenderType Gender_code { get; set; }
        public string Address { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Identity_Type { get; set; }
        public string Identity_No { get; set; }
        public string PIC_status { get; set; }
        public string Company_ID { get; set; }
        public string Company { get; set; }
        public string Company_Code { get; set; }
        public string Section { get; set; }
        public string PlantName { get; set; }
        public string authID { get; set; }
        public string authName { get; set; }
        public string authFunction { get; set; }
        public string Area { get; set; }
        public string Area_Name { get; set; }
        public string Area_ID { get; set; }
        public string Location_ID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationDisplay { get; set; }
        public string DivID { get; set; }


    }

    public enum GenderType
    {
        Male = 0,
        Female = 1,
        Unknown = 2
    }
}