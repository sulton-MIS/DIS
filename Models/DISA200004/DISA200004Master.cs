using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA200004Master
{
    public class DISA200004Master
    {
        public string ID { get; set; }
        public string jenis_jurnal { get; set; }
        public string tgl_register { get; set; }
        public string jenis_asset { get; set; }
        public string no_asset { get; set; }
        public string kode_barang { get; set; }
        public string nama_barang { get; set; }
        public string tgl_perolehan { get; set; }
        public string no_jurnal { get; set; }
        public string no_invoice { get; set; }
        public string qty { get; set; }
        public string satuan { get; set; }
        public string harga_satuan { get; set; }
        public string total { get; set; }
        public string tarif_masa_penyusutan { get; set; }
        public string satuan_penyusutan { get; set; }
        public string harga_perolehan { get; set; }
        public string akum_penyusutan_awal_tahun { get; set; }
        public string nilai_penyusutan_perbulan { get; set; }
        public string nilai_buku_awal_tahun { get; set; }
        public string nilai_buku_nbv_tahun_berjalan { get; set; }
        public string tahun { get; set; }
        
        //BULAN
        public string jan { get; set; }
        public string feb { get; set; }
        public string mar { get; set; }
        public string apr { get; set; }
        public string may { get; set; }
        public string jun { get; set; }
        public string jul { get; set; }
        public string aug { get; set; }
        public string sep { get; set; }
        public string oct { get; set; }
        public string nov { get; set; }
        public string dec { get; set; }

        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}