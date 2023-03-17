using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP03003Master
{
    public class WP03003Master
    {
        public int Id { get; set; }
        public int No { get; set; }
        public int SubjectId { get; set; }
        public int QuestionId { get; set; }

        //DETAIL EXAM SUBJECT
        public string TITLE { get; set; }

        //DETAIL QUESTION BANK
        public string QUESTION { get; set; }
        public string ANSWER_CHOICE_A { get; set; }
        public string ANSWER_CHOICE_B { get; set; }
        public string ANSWER_CHOICE_C { get; set; }
        public string ANSWER_CHOICE_D { get; set; }
        public string ANSWER_CHOICE_E { get; set; }
        public string ANSWER_KEY { get; set; }


        public Int16 IS_DELETED { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DT { get; set; }
        
    }

}