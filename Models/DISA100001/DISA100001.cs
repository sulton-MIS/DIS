using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA100001Master
{
    public class DISA100001
    {
        #region Data Master Asset
        public string ID { get; set; }
        public string NO_ASSET { get; set; }
        public string NAMA_ASSET { get; set; }
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
        public string TGL_REGISTER { get; set; }
        public string STATUS { get; set; }
        public string FLG_LABEL_ASSET { get; set; }
        public string FLG_DISPOSE_ASSET { get; set; }
        public string TGL_DISPOSE { get; set; }
        #endregion

        #region DATA REQUEST ASSET
        public string NO_REQUEST_ASSET { get; set; }
        public string NAMA_BARANG { get; set; }
        public string QTY_BARANG { get; set; }
        public string PIC_REQUEST { get; set; }
        public string DEPT_REQUEST { get; set; }
        public string TGL_REQUEST { get; set; }
        public string ID_PR{ get; set; }
        public string TGL_PR{ get; set; }
        #endregion

        #region
        public string ID_TB_M_LAPOR { get; set; }
        public string DATE_APPROVAL { get; set; }
        #endregion

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

        //Untuk User Session
        public string username { get; set; }
        public string date_updated { get; set; }

    }

}