using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AI070.Models.DISA100001Master
{
    public class DISA100001Master
    {
        public string ID { get; set; }
        public string ID_TB_M_REQ_ASSET { get; set; }
        public string ID_PR { get; set; }
        public string NO_LAPOR { get; set; }
        public string NO_ASSET { get; set; }
        public string NO_REGISTER { get; set; }
        public string NO_REQUEST_ASSET { get; set; }
        public string ITEM_CODE { get; set; }
        public string NAMA_ASSET { get; set; }
        public string NAMA_ASSET_INVOICE { get; set; }
        public string NAMA_FOTO { get; set; }
        public string SOURCE_FOTO { get; set; }
        public string MEREK { get; set; }
        public string TIPE { get; set; }
        public string SUPPLIER { get; set; }
        public string TAHUN { get; set; }
        public string BULAN { get; set; }
        public string HARGA_SATUAN { get; set; }
        public string COST_UPGRADE { get; set; }
        public string UMUR { get; set; }
        public string TOTAL { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string NAMA_USER { get; set; }
        public string DEPT_USER { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string JENIS_DOKUMEN { get; set; }
        public string NO_AJU { get; set; }
        public string TGL_DOKUMEN { get; set; }
        public string TGL_REGISTER { get; set; }
        public string STATUS { get; set; }
        public string STATUS_KONDISI { get; set; }
        public string STATUS_PENGGUNAAN { get; set; }
        public string STATUS_PENGADAAN { get; set; }
        public string FLG_LABEL_ASSET { get; set; }
        public string FLG_DISPOSE_ASSET { get; set; }
        public string FLG_APPROVAL_LAPOR { get; set; }
        public string TGL_DISPOSE { get; set; }
        public string DEPRESIASI { get; set; }
        public string UMUR_AKTUAL { get; set; }
        public string TOTAL_DEPRESIASI { get; set; }
        public string VALUE_OF_ASSET { get; set; }
        public string KETERANGAN { get; set; }
        public string SPESIFIKASI { get; set; }


        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

        //-------------Amount & Qty-----------------
        public string AMOUNT { get; set; }
        public string QTY { get; set; }

    }

    //------------------------------------------------------ PAGE INVENTARISASI ASSET ----------------------------------------
    public class DISA10001_LIST_ASSET_DOWNLOAD
    {
        public Int32 ROW_NUM { get; set; }
        public string NO_ASSET { get; set; }
        public string NAMA_ASSET { get; set; }
        public string NAMA_ASSET_INVOICE { get; set; }
        public string ITEM_CODE { get; set; }
        //public string KETERANGAN { get; set; }
        public string MEREK { get; set; }
        public string TIPE { get; set; }
        public string SUPPLIER { get; set; }
        public string TGL_REGISTER { get; set; }
        public string JENIS_DOKUMEN { get; set; }
        public string NO_AJU { get; set; }
        public string TGL_DOKUMEN { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string HARGA_SATUAN { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string NAMA_USER { get; set; }
        public string DEPT_USER { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string UMUR { get; set; }
        public string UMUR_AKTUAL { get; set; }
        public string DEPRESIASI { get; set; }
        public string TOTAL_DEPRESIASI { get; set; }
        public string VALUE_OF_ASSET { get; set; }
        public string STATUS { get; set; }
        public string STATUS_PENGGUNAAN { get; set; }
        public string LABEL_ASSET { get; set; }
        public string DISPOSE_ASSET { get; set; }
        public string TGL_DISPOSE { get; set; }

    }

    //-------------------------------------------------------PAGE REQUEST ASSET------------------------------------------------
    public class DISA10001_REQUEST_ASSET
    {
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
        public string ITEM_CODE { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    //---------------------INSERT MULTIPLE DATA-------------------
    public class DISA10001_REQUEST_ASSET_INPUT_FORM
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        
        [JsonProperty("KETERANGAN")]
        public string KETERANGAN { get; set; }
        
        [JsonProperty("TGL_REQUEST")]
        public string TGL_REQUEST { get; set; }

        [JsonProperty("NAMA_ASSET")]
        public string NAMA_ASSET { get; set; }
        
        [JsonProperty("PIC_REQUEST")]
        public string PIC_REQUEST { get; set; } 
        
        [JsonProperty("DEPT_REQUEST")]
        public string DEPT_REQUEST { get; set; }

        [JsonProperty("list_detail_create")]
        public List<list_detail_create_model> list_detail_create { get; set; } //list multiple data

        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }
    public class list_detail_create_model
    {
        public string ID { get; set; }
        public string NAMA_ASSET { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string STATUS { get; set; }
        public string KETERANGAN { get; set; }
    }

    //----------------------- REGISTER TO MASTER ASSET -----------------------
    public class DISA100001_REGISTER_ASSET
    {
        public string ID { get; set; }
        public string NAMA_ASSET { get; set; }
        public string NAMA_ASSET_INVOICE { get; set; }
        public string ITEM_CODE { get; set; }
        public string MEREK { get; set; }
        public string TIPE { get; set; }
        public string JENIS_DOKUMEN { get; set; }
        public string NO_AJU { get; set; }
        public string TGL_DOKUMEN { get; set; }
        public string TGL_REGISTER { get; set; }
        public string TAHUN { get; set; }
        public string SUPPLIER { get; set; }
        public string HARGA_SATUAN { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string FOTO_NAME { get; set; }
        public string NAMA_USER { get; set; }
        public string DEPT_USER { get; set; }
        public string STATUS_KONDISI { get; set; }
        public string KD_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string STATUS { get; set; }
        public string FLG_REGISTER_ASSET { get; set; }


        //Jika diperlukan
        public string NAMA_LOKASI { get; set; }
        public string TOTAL { get; set; }

        //User Session Login
        string USERNAME { get; set; }


        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    //--------- DOWNLOAD LIST REQUEST ASSET---------
    public class DISA10001_REQUEST_ASSET_DOWNLOAD
    {
        public Int32 ROW_NUM { get; set; }
        public string NO_REQUEST_ASSET { get; set; }
        public string TGL_REQUEST { get; set; }
        public string ID_PR { get; set; }
        public string TGL_PR { get; set; }
        public string NAMA_ASSET { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string STATUS_ASSET { get; set; }
        
    }

    //-------------------------------------------- PAGE LAPOR DATA ASSET -------------------------------------
    public class DISA10001_LAPOR_ASSET
    {
        public string ID { get; set; }
        public string ID_TB_M_LAPOR { get; set; }
        public string NO_LAPOR { get; set; }
        public string NO_ASSET { get; set; }
        public string KETERANGAN { get; set; }
        public string STATUS { get; set; }
        public string PIC_LAPOR { get; set; }
        public string TGL_LAPOR { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string NAMA_USER { get; set; }
        public string DEPT_USER { get; set; }
        public string FLG_APPROVAL { get; set; }
        public string APPROVAL_BY { get; set; }
        public string APPROVAL_DATE { get; set; }
        public string REJECT_BY { get; set; }
        public string REJECT_DATE { get; set; }

        //TAMBAHAN
        public string NAMA_FOTO_LAPORAN { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string TGL_REQUEST { get; set; }
        public string ID_PR { get; set; }
        public string TGL_PR { get; set; }
        public string STATUS_ASSET { get; set; }
        public string ITEM_CODE { get; set; }


        //LAPOR PINDAH
        public string KD_LOKASI_BARU { get; set; }
        public string SUB_LOKASI_BARU { get; set; }
        public string NAMA_USER_BARU { get; set; }
        public string DEPT_USER_BARU { get; set; }
        public string HALTE_BARU { get; set; }

        //LAPOR MODIFIKASI
        public string HARGA_BARU { get; set; }
        public string COST_UPGRADE_BARU { get; set; }
        public string SPESIFIKASI_BARU { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
        public string CEK_NOASSET { get; set; }
    }
    public class DISA10001_LIST_LAPOR_DOWNLOAD
    {
        public Int32 ROW_NUM { get; set; }
        public string NO_LAPOR { get; set; }
        public string NO_ASSET { get; set; }
        public string STATUS { get; set; }
        public string KETERANGAN { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string STATUS_APPROVAL{ get; set; }
        

    }

    //-------------------------------------------------------- PAGE DISPOSE ASSET ---------------------------------------------
    public class DISA10001_DISPOSE_ASSET
    {
        public string ID { get; set; }
        public string id_tb_m_dispose { get; set; }
        public string NO_DISPOSE { get; set; }
        public string NO_ASSET { get; set; }
        public string STATUS_KONDISI { get; set; }
        public string STATUS_APPROVAL { get; set; }
        public string NAMA_FOTO_LAPORAN { get; set; }
        public string KETERANGAN_DISPOSE { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string CREATED_BY_SIGN { get; set; } 
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
        public string UPDATED_BY_SIGN { get; set; }
        public string dept_head_user_created { get; set; }
        public string dept_head_user_created_date { get; set; }
        public string dept_head_user_created_sign { get; set; }
        public string ams_created { get; set; }
        public string ams_created_date { get; set; }
        public string ams_created_sign { get; set; }
        public string dept_head_ams_created { get; set; }
        public string dept_head_ams_created_date { get; set; }
        public string dept_head_ams_created_sign { get; set; }
        public string acknowledge_created { get; set; }
        public string acknowledge_created_date { get; set; }
        public string acknowledge_created_sign { get; set; }
        public string reject_created_by { get; set; }
        public string reject_created_date { get; set; }
        public string reject_created_sign { get; set; }


        //----------------DATA ASSET--------------------
        public string NAMA_ASSET { get; set; }
        public string NAMA_ASSET_INVOICE { get; set; }
        public string ITEM_CODE { get; set; }
        public string KETERANGAN { get; set; }
        public string MEREK { get; set; }
        public string TIPE { get; set; }
        public string SUPPLIER { get; set; }
        public string SPESIFIKASI { get; set; }
        public string TAHUN { get; set; }
        public string BULAN { get; set; }
        public string TGL_REGISTER { get; set; }
        public string JENIS_DOKUMEN { get; set; }
        public string NO_AJU { get; set; }
        public string TGL_DOKUMEN { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string HARGA_SATUAN { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string NAMA_USER { get; set; }
        public string DEPT_USER { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string UMUR { get; set; }
        public string UMUR_AKTUAL { get; set; }
        public string DEPRESIASI { get; set; }
        public string TOTAL_DEPRESIASI { get; set; }
        public string VALUE_OF_ASSET { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }
    public class DISA10001_LIST_DISPOSE_DOWNLOAD
    {
        public Int32 ROW_NUM { get; set; }
        public string NO_DISPOSE { get; set; }
        public string NO_ASSET { get; set; }
        public string STATUS_APPROVAL { get; set; }
        public string KETERANGAN { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
        public string DEPT_HEAD_USER_CREATED { get; set; }
        public string DEPT_HEAD_USER_CREATED_DATE { get; set; }
        public string AMS_CREATED { get; set; }
        public string AMS_CREATED_DATE { get; set; }
        public string DEPT_HEAD_AMS_CREATED { get; set; }
        public string DEPT_HEAD_AMS_CREATED_DATE { get; set; }
        public string ACKNOWLEDGE_CREATED { get; set; }
        public string ACKNOWLEDGE_CREATED_DATE { get; set; }
        public string REJECT_CREATED { get; set; }
        public string REJECT_CREATED_DATE { get; set; }
        


    }
    
    //------------------------------------------------------------- PAGE AUDIT ASSET --------------------------------------------------
    public class DISA10001_AUDIT_ASSET
    {
        public Int32 ROW_NUM { get; set; }
        public string ID { get; set; }
        public string ID_TB_M_AUDIT { get; set; }
        public string NO_AUDIT { get; set; }
        public string NO_ASSET { get; set; }
        public string JENIS_AUDIT { get; set; }
        public string PERIODE_BULAN { get; set; }
        public string PERIODE_SEMESTER { get; set; }
        public string TAHUN { get; set; }
        public string STATUS_KONDISI { get; set; }
        public string KETERANGAN { get; set; }
        public string NAMA_FOTO_AUDIT { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }

        //----------------DATA ASSET--------------------
        public string NAMA_ASSET { get; set; }
        public string NAMA_ASSET_INVOICE { get; set; }
        public string ITEM_CODE { get; set; }
        public string KETERANGAN_ASSET { get; set; }
        public string MEREK { get; set; }
        public string TIPE { get; set; }
        public string SUPPLIER { get; set; }
        public string SPESIFIKASI { get; set; }
        public string TAHUN_MASUK { get; set; }
        public string BULAN { get; set; }
        public string TGL_REGISTER { get; set; }
        public string JENIS_DOKUMEN { get; set; }
        public string NO_AJU { get; set; }
        public string TGL_DOKUMEN { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string HARGA_SATUAN { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string NAMA_USER { get; set; }
        public string DEPT_USER { get; set; }
        public string KD_LOKASI { get; set; }
        public string NAMA_LOKASI { get; set; }
        public string HALTE { get; set; }
        public string UMUR { get; set; }
        public string UMUR_AKTUAL { get; set; }
        public string DEPRESIASI { get; set; }
        public string TOTAL_DEPRESIASI { get; set; }
        public string VALUE_OF_ASSET { get; set; }


        //-------------Amount & Qty-----------------
        public string AMOUNT { get; set; }
        public string QTY { get; set; }

    }
    public class DISA10001_LIST_AUDIT_DOWNLOAD
    {
        public Int32 ROW_NUM { get; set; }
        public string NO_AUDIT { get; set; }
        public string JENIS_AUDIT { get; set; }
        public string PERIODE { get; set; }
        public string NO_ASSET { get; set; }
        public string NAMA_ASSET { get; set; }
        public string JENIS_ASSET { get; set; }
        public string KATEGORI_ASSET { get; set; }
        public string NAMA_LOKASI{ get; set; }
        public string AREA{ get; set; }
        public string TAHUN  { get; set; }
        public string STATUS  { get; set; }
        public string KETERANGAN { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }

    }

}