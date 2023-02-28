using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISR140001Master
{
    public class ListNik
    {
        public string id_sagyosha { get; set; }
        public string name_sagyosha { get; set; }
    }

    public class ListSeihin
    {
        public string id_seisan { get; set; }
        public string id_seihin { get; set; }
    }
    public class ListProses
    {
        public string id_kotei { get; set; }
        public string name_kotei { get; set; }
    }
    public class ListConvertionTable
    {
        public string id_seihin { get; set; }
        public string BundleWeight { get; set; }
        public string BundleQty { get; set; }
        public string PcsWeight { get; set; }
    }
    public class DISR140001Master
    {
        // untuk combobox Time 
        public string ID { get; set; }
        public string BUNDLE_CODE { get; set; }
        public string ID_BUNDLE { get; set; }
        public string ID_PRODUKSI { get; set; }
        public string ID_PROSES { get; set; }
        public string NAMA_PROSES { get; set; }
        public string DMC_CODE { get; set; }
        public string SERIAL { get; set; }
        public string LOT_NO { get; set; }
        public int QTY_BUNDLE_STD { get; set; }
        public int QTY_BUNDLE_ACT { get; set; }
        public int BERAT_BUNDLE_STD { get; set; }
        public int BERAT_BUNDLE_ACT { get; set; }
        public int BERAT_PCS_STD { get; set; }
        public int AVG_BERAT_PCS { get; set; }
        public int BERAT_PER_PCS { get; set; }

        public string JENIS_LOTTO { get; set; }
        public string STATUS_LOTTO { get; set; }
        public string NIK_GAIKAN { get; set; }
        public string OPR_GAIKAN { get; set; }
        public string KETERANGAN { get; set; }
        public string SHIFT { get; set; }
        public string JML_PRINT { get; set; }
        public string INPUT_ADM { get; set; }
        public string INPUT_DATE { get; set; }
        public string UPDATE_ADM { get; set; }
        public string UPDATE_DATE { get; set; }
        public string STATUS_CHECKER { get; set; }
        public string CHECKER { get; set; }
        public string CHECKER_DATE { get; set; }
        public string TRANS_DATE { get; set; }
        public string TRANS_DATETO { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DT { get; set; }
        public string CHANGED_BY { get; set; }
        public string CHANGED_DT { get; set; }
        public string STATUS { get; set; }
        public string STATUS_ID { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string UPLOADED_BY { get; set; }
        public string UPLOADED_DT { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    //----------------------------------------------------- DOWNLOAD LIST DETAIL ------------------------------------------------
    public class Download_List_Detail
    {
        public string ROW_NUM { get; set; }
        public string ID_BUNDLE { get; set; }
        public string TRANS_DATE { get; set; }
        public string ID_PRODUKSI { get; set; }
        public string ID_PROSES { get; set; }
        public string NAMA_PROSES { get; set; }
        public string DMC_CODE { get; set; }
        public string LOT_NO { get; set; }
        public string SERIAL_NO { get; set; }
        public string BERAT_PER_PCS { get; set; }
        public string JML_PRINT { get; set; }
        public string NIK_GAIKAN { get; set; }
        public string OPR_GAIKAN { get; set; }
        public string SHIFT { get; set; }
        public string STATUS_CHECKER { get; set; }
        public string CHECKER { get; set; }
        public string CHECKER_DATE { get; set; }
        public string KETERANGAN { get; set; }
    }



    //----------------------------------------------------- DOWNLOAD LIST SUMMARY ------------------------------------------------
    public class Download_List_Summary
    {
        public string ROW_NUM { get; set; }
        public string ID_BUNDLE { get; set; }
        public string TRANS_DATE { get; set; }
        public string DMC_CODE { get; set; }
        public string QTY_BUNDLE_STD { get; set; }
        public string QTY_BUNDLE_ACT { get; set; }
        public string BERAT_BUNDLE_STD { get; set; }
        public string BERAT_BUNDLE_ACT { get; set; }
        public string BERAT_PCS_STD { get; set; }
        public string AVG_BERAT_PCS { get; set; }
        public string JENIS_LOTTO { get; set; }
        public string STATUS_LOTTO { get; set; }
        public string KALI_PRINT { get; set; }
        public string NIK_GAIKAN { get; set; }
        public string OPR_GAIKAN { get; set; }
        public string SHF { get; set; }
        public string STATUS_CHECKER { get; set; }
        public string CHECKER { get; set; }
        public string CHECKER_DATE { get; set; }
        public string INPUT_ADM { get; set; }
        public string INPUT_DATE { get; set; }
        public string UPDATE_ADM { get; set; }
        public string UPDATE_DATE { get; set; }
        public string KETERANGAN { get; set; }
    }


    //------------------------------------------------------ VALIDASI USER --------------------------------------------------
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

    public class LIST_CHECK_USER //--- Hak Akses User ---
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

}