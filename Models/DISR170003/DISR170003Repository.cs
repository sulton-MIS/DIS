using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.DISR170003Master
{
    public class DISR170003Repository
    {
        #region Get Contractor
        public List<DISR170003Master> GetLossTimePerHalte(
            string MDATE,
            string HALTE,           
            string HARI_01,
            string HARI_02,
            string HARI_03,
            string HARI_04,
            string HARI_05,
            string HARI_06,
            string HARI_07,
            string HARI_08,
            string HARI_09,
            string HARI_10,
            string HARI_11,
            string HARI_12,
            string HARI_13,
            string HARI_14,
            string HARI_15,
            string HARI_16,
            string HARI_17,
            string HARI_18,
            string HARI_19,
            string HARI_20,
            string HARI_21,
            string HARI_22,
            string HARI_23,
            string HARI_24,
            string HARI_25,
            string HARI_26,
            string HARI_27,
            string HARI_28,
            string HARI_29,
            string HARI_30,
            string HARI_31
            )
        {
            //DateTime parm_mdate = DateTime.Today;
            //parm_mdate = INITIAL_MDATE;


            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR170003Master>("DISR170003/DISR170003_SearchOpmj", new
            {
                MDATE,
                HALTE,             
                HARI_01,
                HARI_02,
                HARI_03,
                HARI_04,
                HARI_05,
                HARI_06,
                HARI_07,
                HARI_08,
                HARI_09,
                HARI_10,
                HARI_11,
                HARI_12,
                HARI_13,
                HARI_14,
                HARI_15,
                HARI_16,
                HARI_17,
                HARI_18,
                HARI_19,
                HARI_20,
                HARI_21,
                HARI_22,
                HARI_23,
                HARI_24,
                HARI_25,
                HARI_26,
                HARI_27,
                HARI_28,
                HARI_29,
                HARI_30,
                HARI_31

            });

            db.Close();
            return d.ToList();
        }
        #endregion       
        

    }
}