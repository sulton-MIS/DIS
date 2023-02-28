using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;

namespace AI070.Models.DISA100001Master
{

    public class DISA100001Repository
    {
        #region Page DATA UTAMA

        #region Get No_Asset
        public List<ListAssetModel> getListAsset(string NAMA_DEPT)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ListAssetModel>("DISA100001/DISA100001_getListAsset", new
            {
                NAMA_DEPT
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Lokasi
        public List<LokasiModel> getLokasi()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<LokasiModel>("DISA100001/DISA100001_getLokasi");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Identitas User
        public List<IdentitasUser_Model> getUserIdentity(string USERNAME)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<IdentitasUser_Model>("DISA100001/DISA100001_UserIdentity", new
            {
                USERNAME
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Cek User Akses
        public List<DISA10001_LIST_CHECK_USER> getcheck_User(string USERNAME, string NAMA_FORM)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LIST_CHECK_USER>("DISA100001/DISA100001_CheckUser", new
            {
                USERNAME,
                NAMA_FORM
            });
            db.Close();
            return d.ToList();
        }

        #endregion

        #region Get ID Image
        public string getImageName(string NAMA_FOTO, string FITUR)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string Image = db.SingleOrDefault<string>("DISA100001/DISA100001_getImageName", new { NAMA_FOTO, FITUR });

            var result = "";

            if (Image == "" && Image is null)
            {
                result = "Nothing";
            }
            else
            {
                result = Image;
            }

            db.Close();
            return result;
        }
        #endregion


        #endregion

        //--------------------------------------------------PAGE INVENTARISASI ASSET--------------------------------------------------
        #region Page Inventarisasi DATA ASSET REPOSITORY

        #region Search Data List Asset
        public List<DISA100001Master> getDataAsset(
            int Start, int Display, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET, string DEPARTMENT, string ITEM_CODE,
            string STATUS_KONDISI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001Master>("DISA100001/Master_Asset/DISA100001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER,
                FLG_DISPOSE_ASSET,
                DEPARTMENT,
                ITEM_CODE,
                STATUS_KONDISI
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count Data List Asset
        public int getCountDISA100001(
            string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET, string DEPARTMENT, string ITEM_CODE,
            string STATUS_KONDISI)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100001/Master_Asset/DISA100001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER,
                FLG_DISPOSE_ASSET,
                DEPARTMENT,
                ITEM_CODE,
                STATUS_KONDISI
            });
            db.Close();
            return result;
        }
        #endregion

        #region Get Qty_Amount_Asset
        public List<DISA100001Master> Qty_Amount_Asset(
            string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET, string JENIS_ASSET, string DEPARTMENT,
            string ITEM_CODE, string STATUS_KONDISI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var result = db.Fetch<DISA100001Master>("DISA100001/Master_Asset/DISA100001_get_Qty_Amount", new
            {
                DATA_ID,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER,
                FLG_DISPOSE_ASSET,
                JENIS_ASSET,
                DEPARTMENT,
                ITEM_CODE,
                STATUS_KONDISI
            });

            db.Close();
            return result.ToList();
        }
        #endregion

        #region Get Qty_Amount_Asset_OK
        public List<DISA100001Master> Qty_Amount_Asset_OK(
            string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET, string JENIS_ASSET, string DEPARTMENT,
            string ITEM_CODE, string STATUS_KONDISI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var result = db.Fetch<DISA100001Master>("DISA100001/Master_Asset/DISA100001_get_Qty_Amount", new
            {
                DATA_ID,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER,
                FLG_DISPOSE_ASSET,
                JENIS_ASSET,
                DEPARTMENT,
                ITEM_CODE,
                STATUS_KONDISI
            });

            db.Close();
            return result.ToList();
        }
        #endregion
        
        #region Get Qty_Amount_Asset_NG
        public List<DISA100001Master> Qty_Amount_Asset_NG(
            string DATA_ID, string NO_ASSET, string NAMA_ASSET, string NAMA_FOTO, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET, string JENIS_ASSET, string DEPARTMENT,
            string ITEM_CODE, string STATUS_KONDISI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var result = db.Fetch<DISA100001Master>("DISA100001/Master_Asset/DISA100001_get_Qty_Amount", new
            {
                DATA_ID,
                NO_ASSET,
                NAMA_ASSET,
                NAMA_FOTO,
                MEREK,
                SUPPLIER,
                FLG_DISPOSE_ASSET,
                JENIS_ASSET,
                DEPARTMENT,
                ITEM_CODE,
                STATUS_KONDISI
            });

            db.Close();
            return result.ToList();
        }
        #endregion

        #region Get No_Urut_Asset
        public string getUrutan_No_Asset()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string get_last_ID = db.SingleOrDefault<string>("DISA100001/Request_Asset/DISA100001_getUrutan_No_Asset", new { });

            string result;
            int kode_request;
            int last_ID;

            if (get_last_ID == null)
            {
                last_ID = 0;
            }
            else
            {
                last_ID = Int32.Parse(get_last_ID);
            }


            if (last_ID != 0)
            {
                kode_request = last_ID + 1;

                if (kode_request < 10)
                {
                    result = "0000" + kode_request.ToString();
                }
                else if (kode_request < 100)
                {
                    result = "000" + kode_request.ToString();
                }
                else if (kode_request < 1000)
                {
                    result = "00" + kode_request.ToString();
                }
                else
                {
                    result = "0" + kode_request.ToString();
                }

            }
            else
            {
                result = "00001";
            }

            db.Close();
            return result;
        }
        #endregion

        #region Tambah Data Master Asset
        public static List<DISA100001_REGISTER_ASSET> Create(
                string DATA_ID,
                string ID,
                string NO_REQUEST,
                string ID_PR,
                string NAMA_ASSET,
                string NAMA_ASSET_INVOICE,
                string ITEM_CODE,
                string MEREK,
                string TIPE,
                string JENIS_DOKUMEN,
                string NO_AJU,
                string TGL_DOKUMEN,
                string TGL_REGISTER,
                string TAHUN,
                string UMUR,
                string BULAN,
                string SUPPLIER,
                string KETERANGAN,
                string SPESIFIKASI,
                string HARGA_SATUAN,
                string JENIS_ASSET,
                string KATEGORI_ASSET,
                string PIC_REQUEST,
                string DEPT_REQUEST,
                string FOTO_NAME,
                string NAMA_USER,
                string DEPT_USER,
                string STATUS_KONDISI,
                string KD_LOKASI,
                string HALTE,
                string STATUS,
                string FLG_REGISTER_ASSET,
                string USERNAME,
                DateTime TGL_REQUEST,
                string NO_ASSET,
                string NOMOR_URUT_REGISTER
                )
            {
                IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
                var d = db.Fetch<DISA100001_REGISTER_ASSET>("DISA100001/Request_Asset/DISA100001_Register_Asset", new
                {
                    DATA_ID,
                    ID,
                    NO_REQUEST,
                    ID_PR,
                    NAMA_ASSET,
                    NAMA_ASSET_INVOICE,
                    ITEM_CODE,
                    MEREK,
                    TIPE,
                    JENIS_DOKUMEN,
                    NO_AJU,
                    TGL_DOKUMEN,
                    TGL_REGISTER,
                    TAHUN,
                    UMUR,
                    BULAN,
                    SUPPLIER,
                    KETERANGAN,
                    SPESIFIKASI,
                    HARGA_SATUAN,
                    JENIS_ASSET,
                    KATEGORI_ASSET,
                    PIC_REQUEST,
                    DEPT_REQUEST,
                    FOTO_NAME,
                    NAMA_USER,
                    DEPT_USER,
                    STATUS_KONDISI,
                    KD_LOKASI,
                    HALTE,
                    STATUS,
                    FLG_REGISTER_ASSET,
                    USERNAME,
                    TGL_REQUEST,
                    NO_ASSET,
                    NOMOR_URUT_REGISTER
                });
                db.Close();
                return d.ToList();
            }
        #endregion

        #region Update Image Asset
        public static List<DISA100001> Update_Img(
                string DATA_ID,
                string ID,
                string NAMA_FOTO,
                string KETERANGAN,
                string USERNAME,
                DateTime DATE_UPDATED
                )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Master_asset/DISA100001_Update_Image_Asset", new
            {
                DATA_ID,
                ID,
                NAMA_FOTO,
                KETERANGAN,
                USERNAME,
                DATE_UPDATED
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data Asset
        public List<DISA100001> 
            //Update_Data(string ID, string ID_TB_M_REQ_ASSET, string NO_ASSET, string NAMA_ASSET, string NAMA_ASSET_INVOICE, string ITEM_CODE, string NAMA_FOTO, string MEREK, string TIPE, string SUPPLIER, string HARGA_SATUAN, string DEPT_USER, string NAMA_USER, string KD_LOKASI, string HALTE, string STATUS_KONDISI, string STATUS_PENGADAAN, string STATUS_PENGGUNAAN, string FLG_LABEL_ASSET, string USERNAME, DateTime DATE_UPDATED)
            Update_Data(string ID, string ID_TB_M_REQ_ASSET, string NO_ASSET, string NAMA_ASSET, string NAMA_ASSET_INVOICE, string ITEM_CODE, string MEREK, string TIPE, string SUPPLIER, string HARGA_SATUAN, string COST_UPGRADE, string NOTE_KETERANGAN, string SPESIFIKASI, string UMUR_EKONOMIS, string DEPT_USER, string NAMA_USER, string KD_LOKASI, string HALTE, string STATUS_KONDISI, string STATUS_PENGADAAN, string STATUS_PENGGUNAAN, string FLG_LABEL_ASSET, string USERNAME, DateTime DATE_UPDATED, string KETERANGAN)
            {
                IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
                var d = db.Fetch<DISA100001>("DISA100001/Master_Asset/DISA100001_Update", new
                {
                    ID,
                    ID_TB_M_REQ_ASSET,
                    NO_ASSET,
                    NAMA_ASSET,
                    NAMA_ASSET_INVOICE,
                    ITEM_CODE,
                    //NAMA_FOTO,
                    MEREK,
                    TIPE,
                    SUPPLIER,
                    HARGA_SATUAN,
                    COST_UPGRADE,
                    NOTE_KETERANGAN,
                    SPESIFIKASI,
                    UMUR_EKONOMIS,
                    DEPT_USER,
                    NAMA_USER,
                    KD_LOKASI,
                    HALTE,
                    STATUS_KONDISI,
                    STATUS_PENGADAAN,
                    STATUS_PENGGUNAAN,
                    FLG_LABEL_ASSET,
                    USERNAME,
                    DATE_UPDATED,
                    KETERANGAN
                });
                db.Close();
                return d.ToList();
            }
        #endregion

        #region Download Data Excel
        public List<DISA10001_LIST_ASSET_DOWNLOAD> DownloadExcel_Asset(int PageNumber, int Display, string NO_ASSET, string NAMA_ASSET, 
            string MEREK, string SUPPLIER, string FLG_DISPOSE_ASSET,
            string DEPARTMENT_USER, string ITEM_CODE, string STATUS_KONDISI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LIST_ASSET_DOWNLOAD>("DISA100001/Master_Asset/DISA100001_Download_Excel", new
            {
                PageNumber,
                Display,
                NO_ASSET,
                NAMA_ASSET,
                MEREK,
                SUPPLIER,
                FLG_DISPOSE_ASSET,
                DEPARTMENT_USER,
                ITEM_CODE,
                STATUS_KONDISI
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

        #region Delete Data
        public string Delete_Data(string NO_ASSET)
            {
                IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
                var d = db.SingleOrDefault<string>("DISA100001/Master_Asset/DISA100001_Delete", new
                {
                    NO_ASSET
                });
                db.Close();
                return d;
            }
        #endregion

        #region Detail Data Asset
            public List<DISA100001DetailAsset> GetDataAsset_Detail_ByNoAsset(string ID)
            {
                IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
                var d = db.Fetch<DISA100001DetailAsset>("DISA100001/Master_Asset/DISA100001_DetailData", new
                {
                    ID
                }).ToList();
                db.Close();
                return d;
            }
        #endregion
        
        #region History Data Asset
            public List<History_Data_Asset> GetDataHistory(string ID)
            {
                IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
                var d = db.Fetch<History_Data_Asset>("DISA100001/Master_Asset/DISA100001_HistoryData", new
                {
                    ID
                }).ToList();
                db.Close();
                return d;
            }
        #endregion


        #endregion //END DATA ASSET 

        //------------------------------------------------------PAGE REQUEST DATA ASSET--------------------------------------------------
        #region Page DATA REQUEST ASSET REPOSITORY

        #region Search Data Request Asset
        public List<DISA10001_REQUEST_ASSET> getData_Request_Asset(int Start, int Display, string NO_REQUEST_ASSET, string NAMA_ASSET, string PIC_REQUEST, string DEPT_REQUEST, string ID_PR, string TGL_REQUEST, string TGL_PR, string STATUS_REQUEST)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_REQUEST_ASSET>("DISA100001/Request_Asset/DISA100001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_REQUEST_ASSET,
                NAMA_ASSET,
                PIC_REQUEST,
                DEPT_REQUEST,
                TGL_REQUEST,
                ID_PR,
                TGL_PR,
                STATUS_REQUEST
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count Data Request Asset
        public int getCount_Request_Asset(string DATA_ID, string NO_REQUEST_ASSET, string NAMA_ASSET, string PIC_REQUEST, string DEPT_REQUEST, string ID_PR, string TGL_REQUEST, string TGL_PR, string STATUS_REQUEST)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100001/Request_Asset/DISA100001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_REQUEST_ASSET,
                NAMA_ASSET,
                PIC_REQUEST, 
                DEPT_REQUEST,
                TGL_REQUEST,
                ID_PR,
                TGL_PR,
                STATUS_REQUEST
            });
            db.Close();
            return result;
        }
    #endregion

        #region Get No_Urut Request Asset
        public string getNo_Urutan_Request()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string get_last_ID = db.SingleOrDefault<string>("DISA100001/Request_Asset/DISA100001_getUrutan_Request", new{});

            string result;
            int kode_request;
            int last_ID;

            if (get_last_ID == null)
            {
                last_ID = 0;
            }
            else
            {
                last_ID= Int32.Parse(get_last_ID);
            }
             

            if (last_ID != 0)
            {
                kode_request = last_ID + 1;

                if (kode_request < 10)
                {
                    result = "REQ-0000" + kode_request.ToString();
                }
                else if (kode_request < 100)
                {
                    result = "REQ-000" + kode_request.ToString();
                }
                else if (kode_request < 1000)
                {
                    result = "REQ-00" + kode_request.ToString();
                }
                else if (kode_request < 10000)
                {
                    result = "REQ-0" + kode_request.ToString();
                }
                else
                {
                    result = "REQ-" + kode_request.ToString();
                }

            }
            else
            {
                result = "REQ-00001";
            }


            db.Close();
            return result;
        }
        #endregion
        
        #region Tambah Data Request Asset (Single Insert Data)
        //public static List<DISA100001> Create_New_Request_Asset(
        //    //string DATA_ID,
        //    string NOMOR_URUT_REQUEST,
        //    string NAMA_ASSET,
        //    string QTY,
        //    string PIC_REQUEST,
        //    string DEPARTMENT,
        //    string TGL_REQUEST
        //    )
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
        //    var d = db.Fetch<DISA100001>("DISA100001/Request_Asset/DISA100001_Create", new
        //    {
        //        //DATA_ID,
        //        NOMOR_URUT_REQUEST,
        //        NAMA_ASSET,
        //        QTY,
        //        PIC_REQUEST,
        //        DEPARTMENT,
        //        TGL_REQUEST

        //    });
        //    db.Close();
        //    return d.ToList();
        //}
        #endregion

        #region Tambah Request Asset (Multiple Insert Data)
        public static List<DISA10001_REQUEST_ASSET_INPUT_FORM> Create_Detail_Request(
            DISA10001_REQUEST_ASSET_INPUT_FORM items, string NOMOR_URUT_REQUEST, 
            string username, DateTime CREATED_DATE, string STATUS_REQUEST)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");

            if (items.list_detail_create.Count > 0)
            {
                foreach (var _detailItem in items.list_detail_create)
                {
                    string TGL_REQUEST = items.TGL_REQUEST;

                    for (var i = 0; i < Int32.Parse(_detailItem.QTY); i++)
                    {
                        var result = db.Fetch<DISA10001_REQUEST_ASSET_INPUT_FORM>("DISA100001/Request_Asset/DISA100001_Create_Detail", new
                        {
                            items.ID,
                            items.PIC_REQUEST,
                            items.DEPT_REQUEST,
                            items.KETERANGAN,
                            TGL_REQUEST,
                            _detailItem.NAMA_ASSET,
                            //_detailItem.PIC_REQUEST,
                            //_detailItem.DEPT_REQUEST,
                            NOMOR_URUT_REQUEST,
                            username,
                            CREATED_DATE,
                            STATUS_REQUEST
                        });
                    }
                }
            }

            var hdr = db.Fetch<DISA10001_REQUEST_ASSET_INPUT_FORM>("DISA100001/Request_Asset/DISA100001_Cek_Data_Request", new
            {
                NOMOR_URUT_REQUEST
            });


            db.Close();
            return hdr.ToList();
        }
        #endregion
        
        #region Delete Data Request Asset
        public string Delete_Data_Request_Asset(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100001/Request_Asset/DISA100001_Delete_Request_Asset", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion
        
        #region Cancel Data Request Asset
        public string Cancel_Data_Request_Asset(string ID, string STATUS)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100001/Request_Asset/DISA100001_Cancel_Request_Asset", new
            {
                ID
                ,STATUS
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA100001> Update_Data_Request_Asset(string ID, string NO_REQUEST_ASSET, string TGL_REQUEST_ASSET, string NAMA_ASSET, /*string QTY_ASSET,*/ string PIC_REQUEST, string DEPT_REQUEST)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Request_Asset/DISA100001_Update_Request_Asset", new
            {
                ID,
                NO_REQUEST_ASSET,
                TGL_REQUEST_ASSET,
                NAMA_ASSET,
                //QTY_ASSET,
                PIC_REQUEST,
                DEPT_REQUEST
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Detail Data Asset
        public List<Request_Detail_Asset> GetDataReqAsset_Detail(string ID, string NO_REQUEST_ASSET, string ID_PR)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<Request_Detail_Asset>("DISA100001/Request_Asset/DISA100001_DetailData_Request_Asset", new
            {
                ID
                ,NO_REQUEST_ASSET
                ,ID_PR
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #region Download Data Excel
        public List<DISA10001_REQUEST_ASSET_DOWNLOAD> DownloadExcel_Request_Asset(int PageNumber, int Display, string NO_REQUEST_ASSET, string NAMA_ASSET, string PIC_REQUEST, string DEPT_REQUEST, string ID_PR)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_REQUEST_ASSET_DOWNLOAD>("DISA100001/Request_Asset/DISA100001_Download_Excel", new
            {
                PageNumber,
                Display,
                NO_REQUEST_ASSET,
                NAMA_ASSET,
                PIC_REQUEST,
                DEPT_REQUEST,
                ID_PR
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

    #endregion

        //----------------------------------------------------PAGE LAPOR DATA ASSET-------------------------------------------
        #region Page Lapor Asset

        #region Search Data Lapor Asset
        public List<DISA10001_LAPOR_ASSET> getDataLaporAsset(int Start, int Display, string NO_LAPOR, string NO_ASSET, string KONDISI_ASSET,
            string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LAPOR_ASSET>("DISA100001/Lapor_Asset/DISA100001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_LAPOR,
                NO_ASSET,
                KONDISI_ASSET,
                NAMA_USER,
                DEPARTMENT_USER
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count Data List Asset
        public int getCount_LaporAsset(string DATA_ID, string NO_LAPOR, string NO_ASSET, string KONDISI_ASSET,
            string NAMA_USER, string DEPARTMENT_USER)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100001/Lapor_Asset/DISA100001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_LAPOR,
                NO_ASSET,
                KONDISI_ASSET,
                NAMA_USER,
                DEPARTMENT_USER
            });
            db.Close();
            return result;
        }
        #endregion

        #region Approve Lapor Asset
        public static List<DISA100001> approveLapor(
                string DATA_ID,
                string ID,
                string ID_TB_M_LAPOR,
                string NO_ASSET,
                string STATUS_KONDISI,
                string KETERANGAN,
                string USERNAME,
                DateTime DATE_APPROVAL
                )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Lapor_asset/DISA100001_Approve_Lapor_Asset", new
            {
                DATA_ID,
                ID,
                ID_TB_M_LAPOR,
                NO_ASSET,
                STATUS_KONDISI,
                KETERANGAN,
                USERNAME,
                DATE_APPROVAL
            });
            db.Close();
            return d.ToList();
        }
        #endregion
        
        #region Reject Lapor Asset
        public static List<DISA100001> rejectLapor(
                string DATA_ID,
                string ID,
                string ID_TB_M_LAPOR,
                string NO_ASSET,
                string STATUS_KONDISI,
                string KETERANGAN,
                string USERNAME,
                DateTime DATE_REJECT
                )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Lapor_asset/DISA100001_Reject_Lapor_Asset", new
            {
                DATA_ID,
                ID,
                ID_TB_M_LAPOR,
                NO_ASSET,
                STATUS_KONDISI,
                KETERANGAN,
                USERNAME,
                DATE_REJECT
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get No_Urut_Lapor_Asset
        public string getUrutanLapor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string get_last_ID = db.SingleOrDefault<string>("DISA100001/Lapor_Asset/DISA100001_getUrutan_Lapor", new { });

            string result;
            int kode_lapor;
            int last_ID;

            if (get_last_ID == null)
            {
                last_ID = 0;
            }
            else
            {
                last_ID = Int32.Parse(get_last_ID);
            }


            if (last_ID != 0)
            {
                kode_lapor = last_ID + 1;

                if (kode_lapor < 10)
                {
                    result = "LAP-0000" + kode_lapor.ToString();
                }
                else if (kode_lapor < 100)
                {
                    result = "LAP-000" + kode_lapor.ToString();
                }
                else if (kode_lapor < 1000)
                {
                    result = "LAP-00" + kode_lapor.ToString();
                }
                else
                {
                    result = "LAP-0" + kode_lapor.ToString();
                }

            }
            else
            {
                result = "LAP-00001";
            }

            db.Close();
            return result;
        }
        #endregion

        #region Tambah Data Lapor Asset
        public static List<DISA100001_REGISTER_ASSET> Tambah_Lapor(
            string DATA_ID,
            string NO_LAPOR,
            string NO_ASSET,
            string FOTO_NAME,
            string STATUS_KONDISI,
            string HARGA,
            string COST_UPGRADE,
            string SPESIFIKASI,
            string LOKASI,
            string SUB_LOKASI,
            string HALTE,
            string NAMA_USER,
            string DEPT_USER,
            string KETERANGAN,
            DateTime TGL_LAPOR,
            string USERNAME,
            DateTime CREATED_DATE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001_REGISTER_ASSET>("DISA100001/Lapor_Asset/DISA100001_Create", new
            {
                DATA_ID,
                NO_LAPOR,
                NO_ASSET,
                FOTO_NAME,
                STATUS_KONDISI,
                HARGA,
                COST_UPGRADE,
                SPESIFIKASI,
                LOKASI,
                SUB_LOKASI,
                HALTE,
                NAMA_USER,
                DEPT_USER,
                KETERANGAN,
                TGL_LAPOR,
                USERNAME,
                CREATED_DATE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data
        public List<DISA10001_LAPOR_ASSET> Update_Data_Lapor_Asset(
            string ID,
            string NO_LAPOR, 
            string NO_ASSET, 
            string KETERANGAN, 
            string STATUS_KONDISI, 
            string PIC_LAPOR, 
            string KD_LOKASI_BARU, 
            string SUB_LOKASI_BARU, 
            string NAMA_USER_BARU, 
            string DEPT_USER_BARU, 
            string HALTE_BARU, 
            string HARGA_BARU, 
            string COST_UPGRADE_BARU, 
            string SPESIFIKASI_BARU, 
            string USERNAME, 
            DateTime UPDATED_DATE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LAPOR_ASSET>("DISA100001/Lapor_Asset/DISA100001_Update", new
            {
                ID,
                NO_LAPOR,
                NO_ASSET,
                KETERANGAN,
                STATUS_KONDISI,
                PIC_LAPOR,
                KD_LOKASI_BARU,
                SUB_LOKASI_BARU,
                NAMA_USER_BARU,
                DEPT_USER_BARU,
                HALTE_BARU,
                HARGA_BARU,
                COST_UPGRADE_BARU,
                SPESIFIKASI_BARU,
                USERNAME,
                UPDATED_DATE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Image Asset
        public static List<DISA100001> Update_Img_Lapor_Asset(
                string DATA_ID,
                string ID,
                string NO_ASSET,
                string NAMA_FOTO,
                string KETERANGAN,
                string USERNAME,
                DateTime DATE_UPDATED
                )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Lapor_asset/DISA100001_Update_Image_Asset", new
            {
                DATA_ID,
                ID,
                NO_ASSET,
                NAMA_FOTO,
                KETERANGAN,
                USERNAME,
                DATE_UPDATED
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Lapor Asset
        public string Delete_Lapor_Asset(
            string ID
            , string USERNAME
            //, string STATUS
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100001/Lapor_Asset/DISA100001_Delete", new
            {
                ID
                ,USERNAME
                //,STATUS
            });
            db.Close();
            return d;
        }
        #endregion

        #region Download Data Excel
        public List<DISA10001_LIST_LAPOR_DOWNLOAD> DownloadExcel_LaporAsset(int PageNumber, int Display, string NO_LAPOR, string NO_ASSET, string KONDISI_ASSET,
            string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LIST_LAPOR_DOWNLOAD>("DISA100001/Lapor_Asset/DISA100001_Download_Excel", new
            {
                PageNumber,
                Display,
                NO_LAPOR,
                NO_ASSET,
                KONDISI_ASSET,
                NAMA_USER,
                DEPARTMENT_USER
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

        #endregion


        //----------------------------------------------------------- PAGE DISPOSE ASSET ------------------------------------------------------
        #region Page Dispose Asset

        #region Search Data Dispose Asset
        public List<DISA10001_DISPOSE_ASSET> getDataDisposeAsset(int Start, int Display, string NO_DISPOSE, string NO_ASSET, string STATUS_APPROVAL)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_DISPOSE_ASSET>("DISA100001/Dispose_Asset/DISA100001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_DISPOSE,
                NO_ASSET,
                STATUS_APPROVAL
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Detail Data Dispose Asset
        public List<DISA10001_DISPOSE_ASSET> GetDataDetailDispose(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_DISPOSE_ASSET>("DISA100001/Dispose_Asset/DISA100001_Show_Detail", new
            {
                ID
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #region Count Data List Asset
        public int getCount_DisposeAsset(string DATA_ID, string NO_DISPOSE, string NO_ASSET, string STATUS_APPROVAL)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100001/Dispose_Asset/DISA100001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_DISPOSE,
                NO_ASSET,
                STATUS_APPROVAL
            });
            db.Close();
            return result;
        }
        #endregion

        #region
        public string getDeptUser(string NO_ASSET)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string getDept = db.SingleOrDefault<string>("DISA100001/Dispose_Asset/DISA100001_getDeptUser", new { 
                NO_ASSET 
            });

            string result;
            
            if(getDept == null)
            {
                result = "";
            }
            else
            {
                result = getDept;
            }

            db.Close();
            return result;
        }
        #endregion

        #region Get No_Urut_Dispose_Asset
        public string getUrutanDispose(string DEPT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string get_last_ID = db.SingleOrDefault<string>("DISA100001/Dispose_Asset/DISA100001_getUrutan_Dispose", new { });

            string result;
            int kode_dispose;
            int last_ID;

            if (get_last_ID == null)
            {
                last_ID = 0;
            }
            else
            {
                last_ID = Int32.Parse(get_last_ID);
            }


            if (last_ID != 0)
            {
                kode_dispose = last_ID + 1;

                if (kode_dispose < 10)
                {
                    result = "DSP-" + DEPT_USER + "-0000" + kode_dispose.ToString();
                }
                else if (kode_dispose < 100)
                {
                    result = "DSP-" + DEPT_USER + "-000" + kode_dispose.ToString();
                }
                else if (kode_dispose < 1000)
                {
                    result = "DSP-" + DEPT_USER + "-00" + kode_dispose.ToString();
                }
                else
                {
                    result = "DSP-" + DEPT_USER + "-0" + kode_dispose.ToString();
                }

            }
            else
            {
                result = "DSP-" + DEPT_USER + "-00001";
            }

            db.Close();
            return result;
        }
        #endregion

        #region Tambah Data Dispose Asset (old)
        public static List<DISA10001_DISPOSE_ASSET> Tambah_Dispose(
            string DATA_ID,
            string NO_DISPOSE,
            string NO_ASSET,
            string FOTO_NAME,
            string STATUS_KONDISI,
            string STATUS_APPROVAL,
            string NAMA_FITUR,
            string KETERANGAN,
            string USERNAME,
            DateTime CREATED_DATE,
            string CREATED_BY_SIGN
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_DISPOSE_ASSET>("DISA100001/Dispose_Asset/DISA100001_Create", new
            {
                DATA_ID,
                NO_DISPOSE,
                NO_ASSET,
                FOTO_NAME,
                STATUS_KONDISI,
                STATUS_APPROVAL,
                NAMA_FITUR,
                KETERANGAN,
                USERNAME,
                CREATED_DATE,
                CREATED_BY_SIGN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Tambah Dispose Asset (Insert Summary Data Dispose)
        public static List<DISA10001_DISPOSE_ASSET_INPUT_FORM> Create_Summary_Dispose(
                DISA10001_DISPOSE_ASSET_INPUT_FORM items, string NO_DISPOSE, 
                string USERNAME, DateTime CREATED_DATE, string CREATED_BY_SIGN, string NAMA_FITUR
            )
        {
            string STATUS_APPROVAL = "";
            string NAMA_FILE_LAMPIRAN = "";

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");

            NAMA_FILE_LAMPIRAN = NO_DISPOSE + "." + items.DATAFILE;
            STATUS_APPROVAL = items.STATUS_APPROVAL + USERNAME;
            //string TGL_REQUEST = items.TGL_REQUEST;

            var result = db.Fetch<DISA10001_DISPOSE_ASSET_INPUT_FORM>("DISA100001/Dispose_Asset/DISA100001_Create_Summary", new
            {
                NO_DISPOSE,
                NAMA_FILE_LAMPIRAN,
                STATUS_APPROVAL,
                USERNAME,
                CREATED_DATE,
                CREATED_BY_SIGN,
                NAMA_FITUR
            });

            var hdr = db.Fetch<DISA10001_DISPOSE_ASSET_INPUT_FORM>("DISA100001/Dispose_Asset/DISA100001_Cek_Result_Input", new
            {
                NO_DISPOSE
            });


            db.Close();
            return hdr.ToList();
        }
        #endregion
        
        #region Tambah Dispose Asset (Multiple Insert Data)
        public static List<DISA10001_DISPOSE_ASSET_INPUT_FORM> Create_Detail_Dispose(
                DISA10001_DISPOSE_ASSET_INPUT_FORM items, string NO_DISPOSE, 
                string USERNAME, DateTime CREATED_DATE, string CREATED_BY_SIGN, string NAMA_FITUR
            )
        {
            string STATUS_APPROVAL = "";
            string NAMA_FILE_LAMPIRAN = "";

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");

            if (items.list_detail_create.Count > 0)
            {
                foreach (var _detailItem in items.list_detail_create)
                {
                    NAMA_FILE_LAMPIRAN = NO_DISPOSE + "." + items.DATAFILE;
                    STATUS_APPROVAL = items.STATUS_APPROVAL + USERNAME;
                    //string TGL_REQUEST = items.TGL_REQUEST;

                    var result = db.Fetch<DISA10001_DISPOSE_ASSET_INPUT_FORM>("DISA100001/Dispose_Asset/DISA100001_Create_Detail", new
                    {
                        items.ID,
                        _detailItem.NO_ASSET,
                        _detailItem.STATUS_KONDISI,
                        _detailItem.KETERANGAN,
                        NAMA_FILE_LAMPIRAN,
                        items.STATUS_APPROVAL,
                        NO_DISPOSE,
                        USERNAME,
                        CREATED_DATE,
                        CREATED_BY_SIGN,
                        NAMA_FITUR
                    });

                }

            }

            var hdr = db.Fetch<DISA10001_DISPOSE_ASSET_INPUT_FORM>("DISA100001/Dispose_Asset/DISA100001_Cek_Result_Input", new
            {
                NO_DISPOSE
            });


            db.Close();
            return hdr.ToList();
        }
        #endregion

        #region Get project job
        public List<list_detail_dispose_create_model> getBindDataDispose(string NO_DISPOSE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<list_detail_dispose_create_model>("DISA100001/Dispose_Asset/DISA100001_getBindDataDispose", new
            {
                NO_DISPOSE = NO_DISPOSE
            });

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data Dispose Asset
        public static List<DISA10001_DISPOSE_ASSET> Update_Dispose_Asset(
            string ID,
            string NO_DISPOSE,
            string NO_ASSET,
            string STATUS_KONDISI_ASSET,
            string STATUS_APPROVAL,
            string NAMA_FITUR,
            string KETERANGAN,
            string FOTO_NAME,
            string USERNAME,
            DateTime UPDATED_DATE,
            string UPDATED_SIGN
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_DISPOSE_ASSET>("DISA100001/Dispose_Asset/DISA100001_Update", new
            {
                ID,
                NO_DISPOSE,
                NO_ASSET,
                STATUS_KONDISI_ASSET,
                STATUS_APPROVAL,
                NAMA_FITUR,
                FOTO_NAME,
                KETERANGAN,
                USERNAME,
                UPDATED_DATE,
                UPDATED_SIGN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Dispose Asset
        public string Delete_Dispose_Asset(
            string NO_DISPOSE
            , string NO_ASSET
            , string USERNAME
            , string typeFunction
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100001/Dispose_Asset/DISA100001_Delete", new
            {
                NO_DISPOSE
                , NO_ASSET
                ,USERNAME
                ,typeFunction
            });
            db.Close();
            return d;
        }
        #endregion

        #region Approve Dispose Asset
        public static List<DISA100001> approveDisposeAsset(
                string ID,
                string ID_TB_M_DISPOSE,
                string NO_DISPOSE,
                string NO_ASSET,
                string STATUS_APPROVAL,
                string KETERANGAN,
                string USERNAME,
                DateTime DATE_APPROVAL,
                string NAMA_FITUR
                )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Dispose_asset/DISA100001_Approve_Dispose_Asset", new
            {
                ID,
                ID_TB_M_DISPOSE,
                NO_DISPOSE,
                NO_ASSET,
                STATUS_APPROVAL,
                KETERANGAN,
                USERNAME,
                DATE_APPROVAL,
                NAMA_FITUR
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Reject Dispose Asset
        public static List<DISA100001> rejectDispose(
                string ID,
                string ID_TB_M_DISPOSE,
                string NO_DISPOSE,
                string NO_ASSET,
                string STATUS_APPROVAL,
                string STATUS_KONDISI,
                string KETERANGAN,
                string USERNAME,
                DateTime DATE_REJECT
                )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001>("DISA100001/Dispose_asset/DISA100001_Reject_Dispose_Asset", new
            {
                ID,
                ID_TB_M_DISPOSE,
                NO_DISPOSE,
                NO_ASSET,
                STATUS_APPROVAL,
                STATUS_KONDISI,
                KETERANGAN,
                USERNAME,
                DATE_REJECT
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Download Data Excel
        public List<DISA10001_LIST_DISPOSE_DOWNLOAD> DownloadExcel_DisposeAsset(int PageNumber, int Display, string NO_DISPOSE, string NO_ASSET, string STATUS_APPROVAL)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LIST_DISPOSE_DOWNLOAD>("DISA100001/Dispose_Asset/DISA100001_Download_Excel", new
            {
                PageNumber,
                Display,
                NO_DISPOSE,
                NO_ASSET,
                STATUS_APPROVAL
            }).ToList();
            db.Close();
            return d;
        }

        #endregion
        
        #region Printout Data Dispose
        public List<DISA10001_LIST_DISPOSE_PRINTOUT> PrintOutExcel_DisposeAsset(
            int PageNumber, int Display, 
            string NO_DISPOSE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LIST_DISPOSE_PRINTOUT>("DISA100001/Dispose_Asset/DISA100001_Printout_Excel", new
            {
                PageNumber,
                Display,
                NO_DISPOSE
            }).ToList();
            db.Close();
            return d;
        }

        #endregion

        #endregion

        //------------------------------------------------------------- PAGE AUDIT ASSET -------------------------------------------------------------
        #region
        #region Search Data Audit Asset
        public List<DISA10001_AUDIT_ASSET> getDataAuditAsset(int Start, int Display, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, 
            string STATUS, string TAHUN, string PERIODE, string KETERANGAN,
            string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_AUDIT_ASSET>("DISA100001/Audit_Asset/DISA100001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                TAHUN,
                PERIODE,
                STATUS,
                KETERANGAN,
                NAMA_USER,
                DEPARTMENT_USER
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count Data List Asset
        public int getCount_AuditAsset(string DATA_ID, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, 
            string STATUS, string TAHUN, string PERIODE, string KETERANGAN,
            string NAMA_USER, string DEPARTMENT_USER)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA100001/Audit_Asset/DISA100001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                TAHUN,
                PERIODE,
                STATUS,
                KETERANGAN,
                NAMA_USER,
                DEPARTMENT_USER
            });
            db.Close();
            return result;
        }
        #endregion


        #region Get Detail Data Asset
        public List<DISA100001DetailAsset> get_Data_Asset(string NO_ASSET)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA100001DetailAsset>("DISA100001/DISA100001_getDataAsset", new
            {
                NO_ASSET
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get No_Urut_Audit_Asset
        public string getUrutanAudit()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            string get_last_ID = db.SingleOrDefault<string>("DISA100001/Audit_Asset/DISA100001_getUrutan_Audit", new { });

            string result;
            int kode_audit;
            int last_ID;

            if (get_last_ID == null)
            {
                last_ID = 0;
            }
            else
            {
                last_ID = Int32.Parse(get_last_ID);
            }


            if (last_ID != 0)
            {
                kode_audit = last_ID + 1;

                if (kode_audit < 10)
                {
                    result = "AUD-0000" + kode_audit.ToString();
                }
                else if (kode_audit < 100)
                {
                    result = "AUD-000" + kode_audit.ToString();
                }
                else if (kode_audit < 1000)
                {
                    result = "AUD-00" + kode_audit.ToString();
                }
                else
                {
                    result = "AUD-0" + kode_audit.ToString();
                }

            }
            else
            {
                result = "AUD-00001";
            }

            db.Close();
            return result;
        }
        #endregion

        #region Tambah Data Audit Asset
        public static List<DISA10001_DISPOSE_ASSET> Tambah_Audit(
            string NO_AUDIT,
            string NO_ASSET,
            string JENIS_AUDIT,
            string PERIODE_BULAN,
            string PERIODE_SEMESTER,
            string TAHUN,
            string STATUS_KONDISI,
            string KETERANGAN,
            string FOTO_NAME,
            string USERNAME,
            DateTime CREATED_DATE,
            string STATUS_AUDIT
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_DISPOSE_ASSET>("DISA100001/Audit_Asset/DISA100001_Create", new
            {
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                PERIODE_BULAN,
                PERIODE_SEMESTER,
                TAHUN,
                STATUS_KONDISI,
                KETERANGAN,
                FOTO_NAME,
                USERNAME,
                CREATED_DATE,
                STATUS_AUDIT
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Data Audit Asset
        public static List<DISA10001_DISPOSE_ASSET> Update_Audit_Asset(
            string ID,
            string NO_AUDIT,
            string JENIS_AUDIT,
            string NO_ASSET,
            string KETERANGAN,
            string PERIODE,
            string TAHUN,
            string STATUS_KONDISI,
            string FOTO_NAME,
            string USERNAME,
            DateTime UPDATED_DATE,
            string NAMA_FITUR,
            string STATUS_AUDIT
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_DISPOSE_ASSET>("DISA100001/Audit_Asset/DISA100001_Update", new
            {
                ID,
                NO_AUDIT,
                JENIS_AUDIT,
                NO_ASSET,
                KETERANGAN,
                PERIODE,
                TAHUN,
                STATUS_KONDISI,
                FOTO_NAME,
                USERNAME,
                UPDATED_DATE,
                NAMA_FITUR,
                STATUS_AUDIT
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Audit Asset
        public string Delete_Audit_Asset(
            string ID
            , string USERNAME
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100001/Audit_Asset/DISA100001_Delete", new
            {
                ID
                ,USERNAME
            });
            db.Close();
            return d;
        }
        #endregion

        #region Download Data Excel
        public List<DISA10001_LIST_AUDIT_DOWNLOAD> DownloadExcel_AuditAsset(int PageNumber, int Display, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, string STATUS, string TAHUN, string PERIODE,
            string KETERANGAN, string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA10001_LIST_AUDIT_DOWNLOAD>("DISA100001/Audit_Asset/DISA100001_Download_Excel", new
            {
                PageNumber,
                Display,
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                STATUS,
                TAHUN,
                PERIODE,
                KETERANGAN,
                NAMA_USER,
                DEPARTMENT_USER
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #region Get Qty_Amount_Audit
        public List<DISA10001_AUDIT_ASSET> Qty_Amount_Audit(
            string DATA_ID, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, 
            string STATUS, string TAHUN, string PERIODE, string JENIS_ASSET,
            string KETERANGAN, string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var result = db.Fetch<DISA10001_AUDIT_ASSET>("DISA100001/Audit_Asset/DISA100001_get_Qty_Amount_Audit", new {
                DATA_ID,
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                STATUS,
                TAHUN,
                PERIODE,
                JENIS_ASSET,
                KETERANGAN,
                NAMA_USER,
                DEPARTMENT_USER
            });

            db.Close();
            return result.ToList();
        }
        #endregion
        
        #region Get Qty_Amount_Audit_OK
        public List<DISA10001_AUDIT_ASSET> Qty_Amount_Audit_OK(
            string DATA_ID, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, 
            string STATUS, string TAHUN, string PERIODE, string JENIS_ASSET,
            string KETERANGAN, string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var result = db.Fetch<DISA10001_AUDIT_ASSET>("DISA100001/Audit_Asset/DISA100001_get_Qty_Amount_Audit", new {
                DATA_ID,
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                STATUS,
                TAHUN,
                PERIODE,
                JENIS_ASSET,
                KETERANGAN,
                NAMA_USER,
                DEPARTMENT_USER
            });

            db.Close();
            return result.ToList();
        }
        #endregion
        
        #region Get Qty_Amount_Audit_NG
        public List<DISA10001_AUDIT_ASSET> Qty_Amount_Audit_NG(
            string DATA_ID, string NO_AUDIT, string NO_ASSET, string JENIS_AUDIT, 
            string STATUS, string TAHUN, string PERIODE, string JENIS_ASSET,
            string KETERANGAN, string NAMA_USER, string DEPARTMENT_USER)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var result = db.Fetch<DISA10001_AUDIT_ASSET>("DISA100001/Audit_Asset/DISA100001_get_Qty_Amount_Audit", new {
                DATA_ID,
                NO_AUDIT,
                NO_ASSET,
                JENIS_AUDIT,
                STATUS,
                TAHUN,
                PERIODE,
                JENIS_ASSET,
                KETERANGAN,
                NAMA_USER,
                DEPARTMENT_USER
            });

            db.Close();
            return result.ToList();
        }
        #endregion

        #endregion



        //------------------------------------------DEFINE CLASS--------------------------------------------



        #region Dispose Data
        public string Dispose_Data(string NO_ASSET)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA100001/DISA100001_Dispose", new
            {
                NO_ASSET
            });
            db.Close();
            return d;
        }
        #endregion

        
        //#region Get Urutan
        //public List<UrutanModel> getUrutan()
        //{
        //    IDBContext db = DatabaseManager.Instance.GetContext();
        //    var d = db.Fetch<UrutanModel>("DISA100001/DISA100001_getUrutan");

        //    db.Close();
        //    return d.ToList();
        //}
        //#endregion


        #region Get Executor
        public List<ExecutorModel> getExecutor()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("");
            var d = db.Fetch<ExecutorModel>("DISA100001/DISA100001_getExecutor");

            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class IdentitasUser_Model
    {
        public string NIK { get; set; }
        public string NAMA_USER { get; set; }
        public string NAMA_USER_ALIAS { get; set; }
        public string KODE_SECTION { get; set; }
        public string NAMA_SECTION { get; set; }
        public string NAMA_SECTION_ALIAS { get; set; }
        public string KODE_DEPT { get; set; }
        public string NAMA_DEPT { get; set; }
        public string NAMA_DEPT_ALIAS { get; set; }

    }

    public class History_Data_Asset
    {
        public string ID { get; set; }
        public string NO_ASSET { get; set; }
        public string NAMA_ASSET { get; set; }
        public string ID_PR { get; set; }
        public string KETERANGAN { get; set; }
        public string STATUS { get; set; }
        public string NAMA_FITUR { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }

    }

    public class DISA100001DetailAsset
    {
        public int ROWNUM { get; set; }
        public string ID { get; set; }
        public string NO_ASSET { get; set; }
        public string NAMA_ASSET { get; set; }
        public string NAMA_ASSET_INVOICE { get; set; }
        public string NAMA_FOTO { get; set; }
        public string SOURCE_FOTO { get; set; }
        public string MEREK { get; set; }
        public string TIPE { get; set; }
        public string SUPPLIER { get; set; }
        public string TAHUN { get; set; }
        public string QTY { get; set; }
        public string HARGA_SATUAN { get; set; }
        public string TOTAL { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string PIC_BELI { get; set; }
        public string DEPT_USER { get; set; }
        public string NAMA_USER { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string JENIS_DOC { get; set; }
        public string NO_BC { get; set; }
        public string TGL_BC { get; set; }
        public string TGL_REGIST { get; set; }
        public string STATUS { get; set; }
        public string FLG_LABEL_ASSET { get; set; }
        public string FLG_DISPOSE_ASSET { get; set; }
        public string TGL_DISPOSE { get; set; }

    }

    public class Request_Detail_Asset
    {
        public int ROWNUM { get; set; }
        public string ID { get; set; }
        public string NO_REQUEST_ASSET { get; set; }
        public string NAMA_ASSET { get; set; }
        public string QTY_ASSET { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string TGL_REQUEST { get; set; }
        public string ID_PR { get; set; }
        public string TGL_PR { get; set; }
        public string STATUS_ASSET { get; set; }
        public string NAME { get; set; }
        public string SPEC { get; set; }
        public string TUJUAN { get; set; }
        public string EFFECT { get; set; }
        public string KETERANGAN { get; set; }

    }

    public class LokasiModel
    {
        public string id_tb_m_lokasi { get; set; }
        public string kd_lokasi { get; set; }
        public string nama_lokasi { get; set; }
    }
    public class ListAssetModel
    {
        public string id_tb_m_asset { get; set; }
        public string no_asset { get; set; }
        public string nama_asset { get; set; }
    }
    public class UrutanModel
    {
        public string no_urut { get; set; }
    }

    public class DeleteModel
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    } 
    public class DisposeModel
    {
        public string DISPOSE_NAME { get; set; }
        public string DISPOSE_MSG { get; set; }
    }

    public class ExecutorModel
    {
        public string ID { get; set; }
        public string EXECUTOR_TEXT { get; set; }
    }

    public class PagingModel_DISA100001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA100001(int countdata, int positionpage, int dataperpage)
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