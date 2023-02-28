using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.DISA150001Master
{
    public class DISA150001Master
    {
        public string ID { get; set; }
        public string KATEGORI_MATERIAL { get; set; }
        public string DMC_TYPE { get; set; }
        public string CUSTOMER { get; set; }
        public string LOT_SIZE { get; set; }
        public string MassProAirCifJpn { get; set; }
        public string MassProSeaCifJpn { get; set; }
        public string MassProAirCifSha { get; set; }
        public string MassProSeaCifSha { get; set; }
        public string MassProAirCifHkg { get; set; }
        public string MassProSeaCifHkg { get; set; }
        public string MassProFob { get; set; }
        public string EngineeringSample { get; set; }
        public string WIS { get; set; }
        public string CAVITY_FILM { get; set; }
        public string CAVITY_GLASS { get; set; }
        public string CAVITY_TAIL { get; set; }
        public string TYPE { get; set; }
        public string RANK { get; set; }
        public string INCH { get; set; }
        public string MATERIAL_COST { get; set; }
        public string COST_PRINTING { get; set; }
        public string COST_ETCHING { get; set; }
        public string COST_PRESS { get; set; }
        public string COST_ASSY { get; set; }
        public string COST_KONPO { get; set; }
        public string TOTAL_LABOUR { get; set; }
        public string INDIRECT_LABOUR { get; set; }
        public string SGA { get; set; }
        public string Trans_AirCifJpn { get; set; }
        public string Trans_SeaCifTokyo { get; set; }
        public string Trans_AirCifSha { get; set; }
        public string Trans_SeaCifSha { get; set; }
        public string Trans_AirCifHkg { get; set; }
        public string Trans_SeaCifHkg { get; set; }
        public string Total_Cost_AirCifJpn { get; set; }
        public string Total_Cost_SeaCifTokyo { get; set; }
        public string Total_Cost_AirCifSha { get; set; }
        public string Total_Cost_SeaCifSha { get; set; }
        public string Total_Cost_AirCifHkg { get; set; }
        public string Total_Cost_SeaCifHkg { get; set; }
        public string Total_Cost_FOB { get; set; }
        public string Prod_Yield_Film { get; set; }
        public string CT_Printing { get; set; }
        public string CT_NonPrinting { get; set; }
        public string CT_Etching{ get; set; }
        public string CT_Press{ get; set; }
        public string CT_Assembly{ get; set; }
        public string CT_Konpo{ get; set; }
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class DISA150001_ConvTable_Master
    {
        public string ID { get; set; }
        public string ItemCode { get; set; }
        public string Parts { get; set; }
        public string SizeProduct { get; set; }
        public string type { get; set; }
        public string BundleQty { get; set; }
        public string InnerQty { get; set; }
        public string MasterQty { get; set; }
        public string InnerType { get; set; }
        public string InnerL { get; set; }
        public string InnerW { get; set; }
        public string InnerH { get; set; }
        public string InnerWeight { get; set; }
        public string MasterType { get; set; }
        public string MasterL { get; set; }
        public string MasterW { get; set; }
        public string MasterH { get; set; }
        public string MasterWeight { get; set; }
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class DISA150001_Chokoritsu_Master
    {
        public string ID { get; set; }
        public string DMC_TYPE { get; set; }
        public string YIELD_PRINTING_FILM { get; set; }
        public string YIELD_PRINTING_GLASS { get; set; }
        public string YIELD_PRINTING_TAIL { get; set; }
        public string YIELD_PRINTING_OVERLAY { get; set; }
        public string YIELD_SCRIBE { get; set; }
        public string YIELD_FILM_MIDLE_INSPECTION { get; set; }
        public string YIELD_FILM_KABU_MIDLE_INSPECTION { get; set; }
        public string YIELD_GLASS_MIDLE_INSPECTION { get; set; }
        public string YIELD_OVERLAY_MIDLE_INSPECTION { get; set; }
        public string YIELD_TAIL_ELECTRICAL { get; set; }
        public string YIELD_TAIL_COSMETIC { get; set; }
        public string YIELD_ASSEMBLY { get; set; }
        public string YIELD_FINAL_ASSEMBLY { get; set; }
        public string YIELD_ELECTRICAL_INSPECTION { get; set; }
        public string YIELD_FINAL_INSPECTION { get; set; }
        public string YIELD_DENKI_FILM { get; set; }
        public string YIELD_DENKI_GLASS { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class DISA150001_TypeCust_Master
    {
        public string ID { get; set; }
        public string Dmc_Type { get; set; }
        public string Customer { get; set; }
        public string Touch_Panel_Size { get; set; }
        public string Wis_Version { get; set; }
        public int Lot_Size { get; set; }
        public double In_Direct { get; set; }
        public double Sga { get; set; }       
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

    }

    public class DISA150001_Chinritsu_Master
    {
        public string ID { get; set; }
        public string PART { get; set; }
        public string ID_KOTEI { get; set; }
        public string NAME_KOTEI { get; set; }
        public string FACTORY { get; set; }
        public string CHINRITSU { get; set; }        
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }  
    }

    public class DISA150001_UnitPrice_Master
    {
        public string ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string NAME_ITEM { get; set; }
        public double UNIT_PRICE { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    public class DISA150001_ListKonpo_Master
    {
        public string ID { get; set; }
        public string item_code { get; set; }
        public string jenis_packing { get; set; }
        public string qty_pcs { get; set; }
        public string factory_size { get; set; }
        public string indirect { get; set; }
        public string berat { get; set; }
        public string panjang { get; set; }
        public string lebar { get; set; }
        public string tinggi { get; set; }
        public string harga { get; set; }
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    public class DISA150001_Transport_Master
    {
        public string ID { get; set; }
        public string item_code { get; set; }
        public string lot_size { get; set; }
        public string master_qty { get; set; }
        public string box_qty { get; set; }
        public string weight { get; set; }
        public string total_weight { get; set; }
        public string jenis_transportation { get; set; }
        public string transportation_cost { get; set; }
        public string awb_free_jpn { get; set; }
        public string edi_free_air_jpn { get; set; }
        public string ams_free_jpn { get; set; }
        public string trucking_0_250_kg_jpn { get; set; }
        public string handling_air_under_50_kg_jpn { get; set; }
        public string handling_air_upto_50_kg { get; set; }
        public string total_cost { get; set; }
        public string EXECUTOR { get; set; }
        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }
    } 