using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// added by ark.deden
namespace AI070.Models.Shared
{
    public class PagingSafe
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingSafe(int countdata, int positionpage, int dataperpage)
        {
            if (countdata > 0 && positionpage > 0 && dataperpage > 0)
            {
                List<int> list = new List<int>();
                EndData = positionpage * dataperpage;
                CountData = countdata;
                PositionPage = positionpage;
                StartData = (positionpage - 1) * dataperpage + 1;
                Double jml = countdata / dataperpage;
                if (countdata % dataperpage > 0)
                {
                    jml = jml + 1;
                }

                for (int i = 0; i < jml; i++)
                {
                    list.Add(i);
                }
                ListIndex = list;
            }
            else
            {
                ListIndex = new List<int>();
            }

        }
    }
}