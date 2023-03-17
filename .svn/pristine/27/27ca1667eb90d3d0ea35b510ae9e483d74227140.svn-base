using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models
{
    public class PagingModel
    {
        public int CountData { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Length { get; set; }
        public List<int> IndexList { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentPageSize { get; set; }
        public int NextPage { get; set; }
        public int PrevPage { get; set; }
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int MaxPageShow { get; set; }

        /* Method to set default pages size item */
        public List<Int32> DefaultPageSizeItem()
        {
            return new List<Int32>() { 1, 10, 25, 50, 100 };
        }
    }
}