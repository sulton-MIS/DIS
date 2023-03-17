using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models
{
    public class Result
    {

        #region Singleton
        private static Result instance = null;
        public static Result Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Result();
                }
                return instance;
            }
        }
        #endregion

        public bool MESSAGE_STS { get; set; }
        public string MESSAGE_ID { get; set; }
        public string MESSAGE_TEXT { get; set; }
        public string MESSAGE_TYPE { get; set; }

        public dynamic MESSAGE_OBJ { get; set; }
        public int COUNTING { get; set; }
        //public List<dynamic> List { get; set; } 

    }
}