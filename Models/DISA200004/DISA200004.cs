using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA200004Master
{
    public class DISA200004
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
        public string tarif_masa_penyusutan { get; set; }
        public string satuan_penyusutan { get; set; }
        public string harga_perolehan { get; set; }
        public string akum_penyusutan_awal_tahun { get; set; }
        public string nilai_penyusutan_perbulan { get; set; }
        public string nilai_buku_nbv_berjalan { get; set; }

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
        public string okt { get; set; }
        public string nov { get; set; }
        public string dec { get; set; }

        public string TIME_CD { get; set; }
        public string TIME_VAL { get; set; }

        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

}