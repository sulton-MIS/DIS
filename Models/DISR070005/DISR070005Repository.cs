using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;
using Newtonsoft.Json;

namespace AI070.Models.DISR070005Master
{
    public class DISR070005Repository
    {
        #region Get Pilih Dmc Type From Item Master
        public List<DISR070005Master> getDmcTypeItemMaster()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISR070005Master>("DISR070005/DISR070005_GetListDmcType");

            db.Close();
            return d.ToList();
        }
        #endregion       
        #region Get_Data_Grid_DISR070005
        public List<DISR070005Master> getDataDISR070005(int Start, int Display, string ID_TOOL, string NAME_TOOL, string FACTORY)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070005Master>("DISR070005/DISR070005_SearchData", new
            {
                START = Start,
                DISPLAY = Display,                
                ID_TOOL,
                NAME_TOOL,
                FACTORY
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Nama Tools
        public List<DISR070005Master> getNameToolDISR070005(string ID_TOOL)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070005Master>("DISR070005/DISR070005_GetNameTool", new
            {
                ID_TOOL
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISR070005
        public int getCountDISR070005(string DATA_ID, string ID_TOOL, string NAME_TOOL, string FACTORY)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR070005/DISR070005_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ID_TOOL,
                NAME_TOOL,
                FACTORY
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISR070005> Create(string ID_TOOL, string NAME_TOOL, string FACTORY, string LIFETIME, string LIMIT, string STATUS, string TIME_KOSHIN, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070005>("DISR070005/DISR070005_Create", new
            {
                ID_TOOL,
                NAME_TOOL,
                FACTORY,                
                LIFETIME,             
                LIMIT,
                STATUS,
                TIME_KOSHIN,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Tambah Request Asset (Multiple Insert Data)
        public static List<DISA10001_TOOL_INPUT_FORM> Create_Detail_Request(DISA10001_TOOL_INPUT_FORM items)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            if (items.list_detail_create.Count > 0)
            {
                foreach (var _detailItem in items.list_detail_create)
                {

                    var result = db.Fetch<DISA10001_TOOL_INPUT_FORM>("DISR070005/DISR070005_Create_Detail", new
                    {                        
                        items.ID_TOOL,
                        _detailItem.DMC_CODE
                    });

                }
            }

            var hdr = db.Fetch<DISA10001_TOOL_INPUT_FORM>("DISR070005/DISR070005_Create", new
            {
                items.ID_TOOL,
                items.NAME_TOOL,
                items.FACTORY,
                items.LIFETIME,
                items.LIMIT,
                items.STATUS
            });


            db.Close();
            return hdr.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.SingleOrDefault<string>("DISR070005/DISR070005_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISR070005> Update_Data(string ID, string ID_TOOL, string NAME_TOOL, string FACTORY, string LIFETIME, string LIMIT, string STATUS, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR070005>("DISR070005/DISR070005_Update", new
            {
                ID,
                ID_TOOL,
                NAME_TOOL,
                FACTORY,
                LIFETIME,
                LIMIT,
                STATUS,                
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion      

    }
    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    public class PagingModel_DISR070005
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR070005(int countdata, int positionpage, int dataperpage)
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
    }
}