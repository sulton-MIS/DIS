using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using AI070.Models.DISR140001;
using System.Runtime.CompilerServices;

namespace AI070.Models.DISR140001Master
{
    public class DISR140001Repository
    {
        #region Identitas User
        public List<IdentitasUser_Model> getUserIdentity(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<IdentitasUser_Model>("DISR140001/DISR140001_UserIdentity", new
            {
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Cek User Akses
        public List<LIST_CHECK_USER> getcheck_User(string USERNAME, string NAMA_FORM)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<LIST_CHECK_USER>("DISR140001/DISR140001_CheckUser", new
            {
                USERNAME,
                NAMA_FORM
            });
            db.Close();
            return d.ToList();
        }

        #endregion

        #region Get Pilih Dmc Type From Item Master
        public List<ItemMaster> getDmcTypeItemMaster()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<ItemMaster>("DISR140001/DISR140001_GetListDmcType");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_Detail
        public List<DISR140001Master> getData_Detail(int Start, int Display, string ID_BUNDLE, string ID_PRODUKSI, string DMC_CODE, string LOT_NO, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR140001Master>("DISR140001/Adm_Page/DISR140001_SearchData_Detail", new
            {
                START = Start,
                DISPLAY = Display,
                ID_BUNDLE,
                DMC_CODE,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_Detail
        public int getCount_Detail(string DATA_ID, string ID_BUNDLE, string ID_PRODUKSI, string DMC_CODE, string LOT_NO, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR140001/Adm_Page/DISR140001_SearchCount_Detail", new
            {
                DATA_ID = DATA_ID,
                ID_BUNDLE,
                DMC_CODE,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            });
            db.Close();
            return result;
        }
        #endregion

        #region Download Data Excel List Detail
        public List<Download_List_Detail> DownloadExcel_List_Detail(
            int PageNumber, int Display, string ID_BUNDLE, string ID_PRODUKSI, string DMC_CODE, string LOT_NO, 
            string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Download_List_Detail>("DISR140001/Adm_Page/DISR140001_Download_Excel_Detail", new
            {
                PageNumber,
                Display,
                ID_BUNDLE,
                DMC_CODE,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

        #region Get_Data_Grid_Summary
        public List<DISR140001Master> getData_Summary(int Start, int Display, string ID_BUNDLE, string DMC_CODE, /*string LOT_NO,*/ string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISR140001Master>("DISR140001/Adm_Page/DISR140001_SearchData_Summary", new
            {
                START = Start,
                DISPLAY = Display,
                ID_BUNDLE,
                DMC_CODE,
                //LOT_NO,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_Summary
        public int getCount_Summary(string DATA_ID, string ID_BUNDLE, string DMC_CODE, /*string LOT_NO,*/ string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            int result = db.SingleOrDefault<int>("DISR140001/Adm_Page/DISR140001_SearchCount_Summary", new
            {
                DATA_ID = DATA_ID,
                ID_BUNDLE,
                DMC_CODE,
                //LOT_NO,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            });
            db.Close();
            return result;
        }
        #endregion

        #region Download Data Excel List Summary
        public List<Download_List_Summary> DownloadExcel_List_Summary(int PageNumber, int Display, string ID_BUNDLE, string DMC_CODE, string TRANS_DATE, string TRANS_DATETO, string NIK_GAIKAN, string OPR_GAIKAN)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Download_List_Summary>("DISR140001/Adm_Page/DISR140001_Download_Excel_Summary", new
            {
                PageNumber,
                Display,
                ID_BUNDLE,
                DMC_CODE,
                TRANS_DATE,
                TRANS_DATETO,
                NIK_GAIKAN,
                OPR_GAIKAN
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

        #region Get Nama Operator
        public List<ListNik> get_Data_Operator(string id_sagyosha)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListNik>("DISR140001/DISR140001_getDataOperator", new
            {
                id_sagyosha
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Seihin
        public List<ListSeihin> get_Data_Seihin(string id_seisan)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListSeihin>("DISR140001/DISR140001_getDataIDSeihin", new
            {
                id_seisan
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Proses
        public List<ListProses> get_Data_Proses(string id_kotei)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<ListProses>("DISR140001/DISR140001_getDataProses", new
            {
                id_kotei
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Shift
        public string getShift()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            string result;

            string get_shift_result = db.SingleOrDefault<string>("DISR140001/DISR140001_GetShift", new { });
            result = get_shift_result;

            db.Close();
            return result;
        }
        #endregion

        #region Get Convertion Table
        public List<ListConvertionTable> get_Data_ConvertionTable(string id_seihin)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<ListConvertionTable>("DISR140001/DISR140001_getDataConvertionTable", new
            {
                id_seihin
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Check Serial No
        public string get_check_Serial_DB(string SERIAL_NO, string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            string checkData = db.SingleOrDefault<string>("DISR140001/DISR140001_CheckSerial", new { SERIAL_NO, DMC_CODE });

            string result;
            if (checkData == "" || checkData is null || checkData == "0")
            {
                result = "false";
            }
            else
            {
                result = "true";
            }

            db.Close();
            return result;
        }
        #endregion

        #region Get Kode Bundel
        public string GetBundleCode(Sequence_model items, string username)
        {
            int SORT_NO = 1;

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            var hdr = db.Fetch<Sequence_model>("DISR140001/DISR140001_GetSeqNumber", new
            {
                items.TYPE_TRX,
                items.YEAR_TRX,
                items.MONTH_TRX,
                items.DAY_TRX,
                username
            });

            if (hdr.Count > 0)
            {
                int SEQ = hdr.ToList()[0].SEQ_NUMBER;
                SORT_NO = SEQ + 1;
            }

            string ZERO = "";
            int NUM = SORT_NO.ToString().Length;
            if (NUM == 1)
            {
                ZERO = "0000";
            }
            else if (NUM == 2)
            {
                ZERO = "000";
            }
            else if (NUM == 3)
            {
                ZERO = "00";
            }
            else if (NUM == 4)
            {
                ZERO = "0";
            }

            var BundleCode = "B" + items.YEAR_TRX.Substring(2, 2) + items.MONTH_TRX.PadLeft(2, '0') + items.DAY_TRX.PadLeft(2, '0') + ZERO + SORT_NO;

            db.Close();
            return BundleCode;
        }
        #endregion

        #region Update Jumlah Print
        public List<list_detail_gaikan_model> Update_Jml_Print(string ID_BUNDLE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<list_detail_gaikan_model>("DISR140001/Adm_Page/DISR140001_Update_Jml_Print", new
            {
                ID_BUNDLE
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        //==============================================================================================================
        //============================================== CREATE DATA ===================================================
        //==============================================================================================================
        #region Create Data
        public static List<DISR140001InputForm> Create(
            DISR140001InputForm items, string BUNDLE_CODE, string SHIFT, 
            string username, string NIK_ADM, string INPUT_ADM_DATE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            if (items.data_detail.Count > 0)
            {
                foreach (var _detailItem in items.data_detail)
                {
                    var jobdata = db.Fetch<DISR140001InputForm>("DISR140001/Opt_Page/DISR140001_CreateFGdetail", new
                    {
                        BUNDLE_CODE,
                        _detailItem.ID_PRODUKSI,
                        _detailItem.DMC_CODE,
                        _detailItem.ID_PROSES,
                        _detailItem.NAMA_PROSES,
                        _detailItem.SERIAL,
                        _detailItem.LOTNO,
                        //_detailItem.BERAT_PCS_ACT,
                        items.BERAT_PCS_ACT,
                        items.KETERANGAN,
                        _detailItem.NAMA,
                        SHIFT,
                        username
                    });
                }
            }

            var hdr = db.Fetch<DISR140001InputForm>("DISR140001/Opt_Page/DISR140001_CreateFGnew", new
            {
                BUNDLE_CODE,
                items.DMC_CODE,
                items.JENIS_LOTTO,
                items.STATUS_LOTTO,
                items.JUMLAH_BDL_STD,
                items.JUMLAH_BDL_ACT,
                items.BERAT_BDL_STD,
                items.BERAT_BDL_ACT,
                items.BERAT_PCS_STD,
                items.BERAT_PCS_ACT,
                items.NIK,
                items.NAMA,
                SHIFT,
                items.KETERANGAN,
                username,
                NIK_ADM,
                INPUT_ADM_DATE
            });
            db.Close();
            return hdr.ToList();
        }
        #endregion

        //==============================================================================================================
        //============================================== UPDATE DATA ===================================================
        //==============================================================================================================
        #region Get Data Detail Gaikan
        public List<list_detail_gaikan_model> getBindDataDetailGaikan(string ID_BUNDLE)
        {
            var Message = "";
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<list_detail_gaikan_model>("DISR140001/Adm_Page/DISR140001_getBindDataDetailGaikan", new
            {
                ID_BUNDLE = ID_BUNDLE
            });

            //if(d.Count > 0)
            //{
            //    try
            //    {
            //        var Exec = Update_Jml_Print(ID_BUNDLE);
            //    }
            //    catch(Exception M)
            //    {
            //        M.Message.ToString();
            //    }
            //}

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data       
        public static List<DISR140001InputForm> Update(DISR140001InputForm items, string BUNDLE_CODE, string SHIFT, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            if (items.data_detail.Count > 0)
            {
                foreach (var _detailItem in items.data_detail)
                {
                    var jobdata = db.Fetch<DISR140001InputForm>("DISR140001/Opt_Page/DISR140001_CreateFGdetail", new
                    {
                        BUNDLE_CODE,
                        _detailItem.ID_PRODUKSI,
                        _detailItem.DMC_CODE,
                        _detailItem.ID_PROSES,
                        _detailItem.NAMA_PROSES,
                        _detailItem.SERIAL,
                        _detailItem.LOTNO,
                        //_detailItem.BERAT_PCS_ACT,
                        items.BERAT_PCS_ACT,
                        _detailItem.NAMA,
                        SHIFT,
                        username
                    });
                }
            }

            var hdr = db.Fetch<DISR140001InputForm>("DISR140001/Adm_Page/DISR140001_Update", new
            {
                BUNDLE_CODE,
                items.DMC_CODE,
                items.JENIS_LOTTO,
                items.STATUS_LOTTO,
                items.JUMLAH_BDL_STD,
                items.JUMLAH_BDL_ACT,
                items.BERAT_BDL_STD,
                items.BERAT_BDL_ACT,
                items.BERAT_PCS_ACT,
                items.KETERANGAN,
                username
            });

            db.Close();
            return hdr.ToList();
        }

        #endregion

        //==============================================================================================================
        //============================================== DELETE DATA ===================================================
        //==============================================================================================================
        #region Delete Data       
        public static List<list_detail_gaikan_model> Delete(list_detail_gaikan_model item, string username, string typeFunction)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");

            string BUNDLE_CODE = item.ID;
            string SERIAL = item.SERIAL;

            var hdr = db.Fetch<list_detail_gaikan_model>("DISR140001/Adm_Page/DISR140001_Delete", new
            {
                BUNDLE_CODE,
                SERIAL,
                username,
                typeFunction
            });

            db.Close();
            return hdr.ToList();
        }

        #endregion

        //==============================================================================================================
        //============================================== VALIDASI DATA =================================================
        //==============================================================================================================
        #region Validasi Data Gaikan
        public List<list_detail_gaikan_model> Validasi_Data(string NIK, string BUNDLE_CODE, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<list_detail_gaikan_model>("DISR140001/Checker_Page/DISR140001_Validasi_Data", new
            {
                NIK,
                BUNDLE_CODE,
                username
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        
    }

    public class ItemMaster
    {
        public string DMC_CODE { get; set; }
    }

    public class PagingModel_DISR140001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISR140001(int countdata, int positionpage, int dataperpage)
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