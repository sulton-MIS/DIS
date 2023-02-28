using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA090002Master
{
    public class DISA090002Master
    {
        public string ID { get; set; }
        public string ID_TB_M_DENKI { get; set; }
        public string NAMA_MESIN { get; set; }
        public string PATH_MESIN { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
        
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }
    
    public class DISA090002_History_Distribusi
    {
        public string ID { get; set; }
        public string ID_TB_HISTORY_DISTRIBUSI { get; set; }
        public string NAMA_MESIN { get; set; }
        public string STATUS { get; set; }
        public string KETERANGAN { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

}