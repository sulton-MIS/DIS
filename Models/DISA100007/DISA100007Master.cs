using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA100007Master
{
    public class DISA100007Master
    {
        public string ID { get; set; }
        public string ID_TB_M_LIST { get; set; }
        public string JENIS_TRANSAKSI { get; set; }
        public string NO_DOCUMENT { get; set; }
        public string NAMA_DOCUMENT { get; set; }
        public string DEPARTMENT { get; set; }
        public string BAGIAN { get; set; }
        public string RAK { get; set; }
        public string LABEL_RAK { get; set; }
        public string MASA_SIMPAN { get; set; }
        public string ESTIMASI_DISPOSE { get; set; }
        public string QTY_BUNDLE { get; set; }
        public string KETERANGAN { get; set; }
        public string TGL_REGISTER { get; set; }
        public string FLG_APPROVE { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }        
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
        public string DEPT_HEAD_CREATED_BY { get; set; }
        public string DEPT_HEAD_CREATED_DATE { get; set; }
        public string DEPT_HEAD_CREATED_SIGN { get; set; }
        public string ADM_CREATED_BY { get; set; }
        public string ADM_CREATED_DATE { get; set; }
        public string ADM_CREATED_SIGN { get; set; }
        public string FLG_DISPOSE { get; set; }
        public string DISPOSE_BY { get; set; }
        public string DISPOSE_DATE { get; set; }
        public string reject_created_by { get; set; }
        public string reject_created_date { get; set; }
        public string reject_created_sign { get; set; }

        //------------------ VARIABEL PINJAM DOKUMEN ------------------//
        public string NAMA_PEMINJAM { get; set; }
        public string DEPARTMENT_PEMINJAM { get; set; }
        public string BAGIAN_PEMINJAM { get; set; }
        public string MASA_PINJAM_DAYS { get; set; }
        public string TGL_PINJAM { get; set; }
        public string ESTIMASI_KEMBALI { get; set; }
        public string FLG_PINJAM { get; set; }
        public string NAMA_PENGEMBALI { get; set; }
        public string TGL_KEMBALI { get; set; }
        public string FLG_KEMBALI { get; set; }


        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }
    
    public class DISA100007_Download_Excel
    {
        public string ROW_NUM { get; set; }
        public string NO_DOCUMENT { get; set; }
        public string DEPARTMENT { get; set; }
        public string BAGIAN { get; set; }
        public string RAK { get; set; }
        public string LABEL_RAK { get; set; }
        public string NAMA_DOCUMENT { get; set; }
        public string TGL_REGISTER { get; set; }
        public string MASA_SIMPAN { get; set; }
        public string ESTIMASI_DISPOSE { get; set; }
        //public string SELISIH_HARI { get; set; }
        public string KETERANGAN { get; set; }
        public string FLG_DISPOSE { get; set; }
        public string DISPOSE_BY { get; set; }
        public string DISPOSE_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }        
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }

        //public string FLG_APPROVE { get; set; }

        //public string DEPT_HEAD_CREATED_BY { get; set; }
        //public string DEPT_HEAD_CREATED_DATE { get; set; }
        //public string DEPT_HEAD_CREATED_SIGN { get; set; }
        //public string ADM_CREATED_BY { get; set; }
        //public string ADM_CREATED_DATE { get; set; }
        //public string ADM_CREATED_SIGN { get; set; }

        //public string reject_created_by { get; set; }
        //public string reject_created_date { get; set; }
        //public string reject_created_sign { get; set; }
    }

    //------------------------------------------------------ VALIDASI USER --------------------------------------------------
    public class DISA10007_LIST_CHECK_USER
    {
        public string NIK { get; set; }
        public string KODE_FORM { get; set; }
        public string NAMA_FORM { get; set; }
        public string NAMA_MODUL { get; set; }
        public string save { get; set; }
        public string add { get; set; }
        public string edit { get; set; }
        public string edit_image { get; set; }
        public string edit_keterangan { get; set; }
        public string delete { get; set; }
        public string dispose { get; set; }
        public string register { get; set; }
        public string view { get; set; }
        public string download { get; set; }
        public string upload { get; set; }
        public string print { get; set; }
        public string approve1 { get; set; }
        public string approve2 { get; set; }
        public string approve3 { get; set; }
        public string approve4 { get; set; }
        public string acknowledge { get; set; }
        public string enable { get; set; }
        public string visible { get; set; }
        public string export { get; set; }
    }

    public class History_Data
    {
        public string ID { get; set; }
        public string no_document { get; set; }
        public string nama_document { get; set; }
        public string nm_menu { get; set; }
        public string nm_fitur { get; set; }
        public string keterangan_dokumen { get; set; }
        public string keterangan { get; set; }
        public string created_by { get; set; }
        public string created_date { get; set; }

    }

    public class DISA100007_History_Distribusi
    {
        public string ID { get; set; }
        public string ID_TB_HISTORY_DISTRIBUSI { get; set; }
        public string NAMA_MESIN { get; set; }
        public string STATUS { get; set; }
        public string KETERANGAN { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

}