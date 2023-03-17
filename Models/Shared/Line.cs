using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.Shared
{
    public class Line
    {
        public string LINE_ID { get; set; }
        public string LINE_PRIORITY_SEQ { get; set; }
        public string PLANT_CD { get; set; }
        public string DIV_ID { get; set; }
        public string LINE_NM { get; set; }
        public string STACK { get; set; }
        public string MAX_CAP { get; set; }
        public string LINE_CAT { get; set; }
        public string LINE_TYPE { get; set; }
        public string LINE_CASE_CD { get; set; }
        public string LINE_STS { get; set; }
        public string LINE_RENBAN_STS { get; set; }
        public string LINE_FILL_IN_QTY { get; set; }
        public string LINE_STUFFING_QTY { get; set; }
        public string LINE_RENBAN_TYPE { get; set; }
        public string LINE_RENBAN_NO { get; set; }
        public string LINE_RENBAN_CASE_QTY { get; set; }
        public string START_CASE_DT { get; set; }
        public string END_CASE_DT { get; set; }
        public string VANNING_DT { get; set; }
        public string DELETE_FLG { get; set; }
        public string CREATED_DT { get; set; }
        public string CREATED_BY { get; set; }
        public string CHANGED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public string DELETED_BY { get; set; }
        public string DELETED_DT { get; set; }
    }
}