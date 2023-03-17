using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;
using NPOI.SS.UserModel;
using System.Data.SqlClient;

namespace AI070.Models.DISA150001Master
{

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START PRODUCTION COST
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region PRODUCTION COST

    public class DISA150001Repository
    {
        #region Get Pilih DMC TYPE
        public List<DISA150001Detail> getDmcType()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_GetListDmcType");

            db.Close();
            return d.ToList();
        }
        #endregion        

        #region Get_Data_Grid_DISA150001
        public List<DISA150001Detail> getDataDISA150001(
            int Start, 
            int Display, 
            string DMC_TYPE, 
            string CUSTOMER, 
            string TOUCH_PANEL_TYPE, 
            string RANK
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                RANK
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(
            string DATA_ID, 
            string DMC_TYPE, 
            string CUSTOMER, 
            string TOUCH_PANEL_TYPE, 
            string RANK)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/ProdCost/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                RANK
            });
            db.Close();
            return result;
        }
        #endregion     

        #region Get_Data_Grid_WipCost
        public List<DISA150001WipCost> getDataWipCostDISA150001(
            int Start,
            int Display,
            string DMC_CODE_PARTS
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001WipCost>("DISA150001/WipCost/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                DMC_CODE_PARTS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Download Wip Cost
        public List<DISA150001WipCost> DownloadWipCostDISA150001(            
            string DMC_CODE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001WipCost>("DISA150001/WipCost/DISA150001_DownloadWipCost", new
            {                
                DMC_CODE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Download Price List
        public List<DISA150001PriceList> DownloadPriceListDISA150001(
            string DMC_CODE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_DownloadPriceList", new
            {
                DMC_CODE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_WipCost
        public int getCountWipCostDISA150001(
            string DATA_ID,
            string DMC_CODE_PARTS)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/WipCost/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                DMC_CODE_PARTS
            });
            db.Close();
            return result;
        }
        #endregion   
        
        #region Get_Data_Grid_Price_List
        public List<DISA150001PriceList> getDataPriceListDISA150001(
            int Start,
            int Display,
            string DMC_TYPE,
            string CUSTOMER
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                DMC_TYPE,
                CUSTOMER
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountPriceListDISA150001(
            string DATA_ID,
            string DMC_TYPE,
            string CUSTOMER)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/PriceList/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                DMC_TYPE,
                CUSTOMER
            });
            db.Close();
            return result;
        }
        #endregion   

        #region Get_Data_Detail_DISA150001
        public List<DISA150001Detail> GetData_Detail_ByID(string DMC_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_DetailData", new
            {
                DMC_TYPE
            }).ToList();          

            db.Close();
            return d;
        }
        #endregion

        #region Get_Data_Grid_DISA150001_Material
        public List<DISA150001MaterialCost> getDataDISA150001_Material(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_SearchDataMaterial", new { ID });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISA150001_Material_Download
        public List<DISA150001MaterialCost> getDataDISA150001_Material_Download(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_DataMaterialDownload", new { DMC_CODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISA150001_Material_Usage
        public List<DISA150001MaterialCostUsage> getDataDISA150001_MaterialUsage(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCostUsage>("DISA150001/ProdCost/DISA150001_SearchDataMaterialUsage", new
            {

                ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISA150001_Sales_Price
        public List<DISA150001Detail> getDataDISA150001_SalesPrice(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_SearchDataSalesPrice", new
            {

                ID
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region GetAllNodes
        public List<DISA150001GetAllNodes> getAllNodesDISA150001()
        {            
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001GetAllNodes>("DISA150001/ProdCost/DISA150001_GetAllNodes", new { });           
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Detail
        public List<DISA150001Detail> getDataDetailDISA150001(string DMC_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_DataDetail", new{ DMC_TYPE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Detail Download
        public List<DISA150001Detail> getDataDetailDownloadDISA150001(string DMC_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_DetailData", new { DMC_TYPE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Dmc Calculate
        public List<DISA150001Detail> getDmcCodeCalc(string DMC_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_GetDmcCalc", new { DMC_TYPE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Calculate Transportation
        public List<DISA150001_Transport_Master> getCalcTranspCostDISA150001(string item_code)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_CalculateTransport", new { item_code });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Summary Calculate Transport
        public static List<DISA150001_Transport_Master> InsertSumCalcTransportation(
            string item_code,
            string code_trans,
            string lot_size,
            string master_type,
            string master_qty,
            string qty_box,
            string master_weight,
            string total_cost
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_InsertSumTransport", new
            {
                item_code,
                code_trans,
                lot_size,
                master_type,
                master_qty,
                qty_box,
                master_weight,
                total_cost
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Summary Calculate Transport
        public static List<DISA150001_Transport_Master> UpdateSumCalcTransportation(
            string item_code,
            string code_trans,
            string lot_size,
            string master_type,
            string master_qty,
            string qty_box,
            string master_weight,
            string total_cost
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_UpdateSumTransport", new
            {
                item_code,
                code_trans,
                lot_size,
                master_type,
                master_qty,
                qty_box,
                master_weight,
                total_cost
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Calculate Price List
        public List<DISA150001PriceList> getCalcPriceListDISA150001(string DMC_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_CalculatePriceList", new { });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Temp Calculate Price List
        public static List<DISA150001PriceList> InsertTempCalcPriceList(
            string DMC_TYPE,
            string CUSTOMER,
            string TOUCH_PANEL_TYPE,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double TOTAL_YIELD_FILM,
            double ORIGINAL_LOT_SIZE,
            double AIR_CIF_SALES_PRICE,
            double SEA_JPN_SALES_PRICE,
            double FOB_SALES_PRICE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_InsertTempCalcPriceList", new
            {
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                TOUCH_PANEL_SIZE,
                VERSI_WIS,
                TOTAL_YIELD_FILM,
                ORIGINAL_LOT_SIZE,
                AIR_CIF_SALES_PRICE,
                SEA_JPN_SALES_PRICE,
                FOB_SALES_PRICE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Calculate Price List
        public static List<DISA150001PriceList> InsertCalcPriceList(
            string DMC_TYPE,
            string CUSTOMER,
            string TOUCH_PANEL_TYPE,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double TOTAL_YIELD_FILM,
            string JENIS_TRANSPORTATION,
            double LOT_10,
            double LOT_20,
            double LOT_50,
            double LOT_100,
            double LOT_200,
            double LOT_300,
            double LOT_400,
            double LOT_500,
            double LOT_1000,
            double LOT_5000
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_InsertCalcPriceList", new
            {
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                TOUCH_PANEL_SIZE,
                VERSI_WIS,
                TOTAL_YIELD_FILM,
                JENIS_TRANSPORTATION,
                LOT_10,
                LOT_20,
                LOT_50,
                LOT_100,
                LOT_200,
                LOT_300,
                LOT_400,
                LOT_500,
                LOT_1000,
                LOT_5000
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Temp Calculate Price List
        public static List<DISA150001PriceList> UpdateTempCalcPriceList(
            string DMC_TYPE,
            string CUSTOMER,
            string TOUCH_PANEL_TYPE,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double TOTAL_YIELD_FILM,
            double ORIGINAL_LOT_SIZE,
            double AIR_CIF_SALES_PRICE,
            double SEA_JPN_SALES_PRICE,
            double FOB_SALES_PRICE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_UpdateTempCalcPriceList", new
            {
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                TOUCH_PANEL_SIZE,
                VERSI_WIS,
                TOTAL_YIELD_FILM,
                ORIGINAL_LOT_SIZE,
                AIR_CIF_SALES_PRICE,
                SEA_JPN_SALES_PRICE,
                FOB_SALES_PRICE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Calculate Price List
        public static List<DISA150001PriceList> UpdateCalcPriceList(
            string DMC_TYPE,
            string CUSTOMER,
            string TOUCH_PANEL_TYPE,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double TOTAL_YIELD_FILM,
            string JENIS_TRANSPORTATION,
            double LOT_10,
            double LOT_20,
            double LOT_50,
            double LOT_100,
            double LOT_200,
            double LOT_300,
            double LOT_400,
            double LOT_500,
            double LOT_1000,
            double LOT_5000
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001PriceList>("DISA150001/PriceList/DISA150001_UpdateCalcPriceList", new
            {
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                TOUCH_PANEL_SIZE,
                VERSI_WIS,
                TOTAL_YIELD_FILM,
                JENIS_TRANSPORTATION,
                LOT_10,
                LOT_20,
                LOT_50,
                LOT_100,
                LOT_200,
                LOT_300,
                LOT_400,
                LOT_500,
                LOT_1000,
                LOT_5000
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Labour Charge
        public List<DISA150001Detail> getLabourCharge()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_LabourCharge", new { });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data untuk di Sales Price
        public List<DISA150001Detail> getSalesPriceDISA150001(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_GetSalesPrice", new { DMC_CODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Data Dmc Code Part untuk di Wip Cost
        public List<DISA150001WipCost> getDmcCodeParttDISA150001(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001WipCost>("DISA150001/WipCost/DISA150001_GetDmcCodePart", new { DMC_CODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Calculate
        public static List<DISA150001Detail> InsertCalculate(
            string DMC_TYPE, 
            string CUSTOMER, 
            string TOUCH_PANEL_TYPE,
            string RANK,
            string TOUCH_PANEL_DIMENSION,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double LOT_SIZE,
            double INDIRECT,
            double SGA,
            double CAVITY_FILM,
            double CAVITY_GLASS,
            double CAVITY_TAIL,
            double YIELD_PRINTING_FILM,
            double YIELD_PRINTING_GLASS,
            double YIELD_PRINTING_TAIL,
            double YIELD_FILM_MIDLE_INSPECTION,
            double YIELD_GLASS_MIDLE_INSPECTION,
            double YIELD_TAIL_ELECTRICAL,
            double YIELD_TAIL_COSMETIC,
            double YIELD_ASSEMBLY,
            double YIELD_FINAL_ASSEMBLY,
            double YIELD_ELECTRICAL_INSPECTION,
            double YIELD_FINAL_INSPECTION,
            double YIELD_TOTAL_FILM,
            double YIELD_TOTAL_GLASS,
            double YIELD_TOTAL_TAIL,
            double LOT_SIZE_FILM,
            double MAX_LOT_SIZE_FILM,
            double LOT_SIZE_GLASS,
            double MAX_LOT_SIZE_GLASS,
            double LOT_SIZE_TAIL,
            double MAX_LOT_SIZE_TAIL,
            double LABOUR_CHARGE_PRINTING,
            double LABOUR_CHARGE_ASSEMBLY,
            double LABOUR_CHARGE_ETCHING,
            double LABOUR_CHARGE_PRESS,
            double LABOUR_CHARGE_NON_PRINTING,
            double LABOUR_CHARGE_KOMPO
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_InsertCalculate", new
            {
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                RANK,
                TOUCH_PANEL_DIMENSION,
                TOUCH_PANEL_SIZE,
                VERSI_WIS,
                LOT_SIZE,
                INDIRECT,
                SGA,
                CAVITY_FILM,
                CAVITY_GLASS,
                CAVITY_TAIL,
                YIELD_PRINTING_FILM,
                YIELD_PRINTING_GLASS,
                YIELD_PRINTING_TAIL,
                YIELD_FILM_MIDLE_INSPECTION,
                YIELD_GLASS_MIDLE_INSPECTION,
                YIELD_TAIL_ELECTRICAL,
                YIELD_TAIL_COSMETIC,
                YIELD_ASSEMBLY,
                YIELD_FINAL_ASSEMBLY,
                YIELD_ELECTRICAL_INSPECTION,
                YIELD_FINAL_INSPECTION,
                YIELD_TOTAL_FILM,
                YIELD_TOTAL_GLASS,
                YIELD_TOTAL_TAIL,
                LOT_SIZE_FILM,
                MAX_LOT_SIZE_FILM,
                LOT_SIZE_GLASS,
                MAX_LOT_SIZE_GLASS,
                LOT_SIZE_TAIL,
                MAX_LOT_SIZE_TAIL,
                LABOUR_CHARGE_PRINTING,
                LABOUR_CHARGE_ASSEMBLY,
                LABOUR_CHARGE_ETCHING,
                LABOUR_CHARGE_PRESS,
                LABOUR_CHARGE_NON_PRINTING,
                LABOUR_CHARGE_KOMPO
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Calculate
        public static List<DISA150001Detail> UpdateCalculate(
            string DMC_TYPE,
            string CUSTOMER,
            string TOUCH_PANEL_TYPE,
            string RANK,
            string TOUCH_PANEL_DIMENSION,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double LOT_SIZE,
            double INDIRECT,
            double SGA,
            double CAVITY_FILM,
            double CAVITY_GLASS,
            double CAVITY_TAIL,
            double YIELD_PRINTING_FILM,
            double YIELD_PRINTING_GLASS,
            double YIELD_PRINTING_TAIL,
            double YIELD_FILM_MIDLE_INSPECTION,
            double YIELD_GLASS_MIDLE_INSPECTION,
            double YIELD_TAIL_ELECTRICAL,
            double YIELD_TAIL_COSMETIC,
            double YIELD_ASSEMBLY,
            double YIELD_FINAL_ASSEMBLY,
            double YIELD_ELECTRICAL_INSPECTION,
            double YIELD_FINAL_INSPECTION,
            double YIELD_TOTAL_FILM,
            double YIELD_TOTAL_GLASS,
            double YIELD_TOTAL_TAIL,
            double LOT_SIZE_FILM,
            double MAX_LOT_SIZE_FILM,
            double LOT_SIZE_GLASS,
            double MAX_LOT_SIZE_GLASS,
            double LOT_SIZE_TAIL,
            double MAX_LOT_SIZE_TAIL,
            double LABOUR_CHARGE_PRINTING,
            double LABOUR_CHARGE_ASSEMBLY,
            double LABOUR_CHARGE_ETCHING,
            double LABOUR_CHARGE_PRESS,
            double LABOUR_CHARGE_NON_PRINTING,
            double LABOUR_CHARGE_KOMPO
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_UpdateCalculate", new
            {
                DMC_TYPE,
                CUSTOMER,
                TOUCH_PANEL_TYPE,
                RANK,
                TOUCH_PANEL_DIMENSION,
                TOUCH_PANEL_SIZE,
                VERSI_WIS,
                LOT_SIZE,
                INDIRECT,
                SGA,
                CAVITY_FILM,
                CAVITY_GLASS,
                CAVITY_TAIL,
                YIELD_PRINTING_FILM,
                YIELD_PRINTING_GLASS,
                YIELD_PRINTING_TAIL,
                YIELD_FILM_MIDLE_INSPECTION,
                YIELD_GLASS_MIDLE_INSPECTION,
                YIELD_TAIL_ELECTRICAL,
                YIELD_TAIL_COSMETIC,
                YIELD_ASSEMBLY,
                YIELD_FINAL_ASSEMBLY,
                YIELD_ELECTRICAL_INSPECTION,
                YIELD_FINAL_INSPECTION,
                YIELD_TOTAL_FILM,
                YIELD_TOTAL_GLASS,
                YIELD_TOTAL_TAIL,
                LOT_SIZE_FILM,
                MAX_LOT_SIZE_FILM,
                LOT_SIZE_GLASS,
                MAX_LOT_SIZE_GLASS,
                LOT_SIZE_TAIL,
                MAX_LOT_SIZE_TAIL,
                LABOUR_CHARGE_PRINTING,
                LABOUR_CHARGE_ASSEMBLY,
                LABOUR_CHARGE_ETCHING,
                LABOUR_CHARGE_PRESS,
                LABOUR_CHARGE_NON_PRINTING,
                LABOUR_CHARGE_KOMPO
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Detail Material
        public List<DISA150001MaterialCost> getDetailMaterialDISA150001(string MATERIAL_KODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_GetMaterialDetail", new { MATERIAL_KODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Cost Material
        public List<DISA150001MaterialCost> getCostMaterialDISA150001(string MATERIAL_KODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_GetCostMaterial", new { MATERIAL_KODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Cavity FILM GLASS TAIL
        public List<DISA150001MaterialCost> getCavityFGTDISA150001(string MATERIAL_KODE, string PART)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_GetCavityFGT", new { MATERIAL_KODE, PART });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Cavity PACKING DAN ASSEMBLY
        public List<DISA150001MaterialCost> getCavityPackingAssyDISA150001(string DMC_CODE_PARTS, string MATERIAL_KODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_GetCavityPA", new { DMC_CODE_PARTS, MATERIAL_KODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Cavity PACKING
        public List<DISA150001MaterialCost> getCavityPackingDISA150001(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_GetCavityPacking", new { DMC_CODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Material Cost
        public static List<DISA150001MaterialCost> InsertMaterialCost(
            string DMC_CODE,
            string PART,
            string DMC_CODE_PARTS,            
            string MATERIAL_KODE,
            string MATERIAL_NAME,
            double UNIT_PRICE,
            string UNIT,
            double WIDE_SIZE,
            double LONG_SIZE,
            double MATERIAL_SIZE,
            double CUT_SIZE,
            int CAVITY,
            int QTY,
            double PRICE_PER_SHEET,
            double PRICE_PER_PCS
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_InsertMaterialCost", new
            {
                DMC_CODE,
                PART,
                DMC_CODE_PARTS,
                MATERIAL_KODE,
                MATERIAL_NAME,
                UNIT_PRICE,
                UNIT,
                WIDE_SIZE,
                LONG_SIZE,
                MATERIAL_SIZE,
                CUT_SIZE,
                CAVITY,
                QTY,
                PRICE_PER_SHEET,
                PRICE_PER_PCS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Material Cost
        public static List<DISA150001MaterialCost> UpdateMaterialCost(
            string DMC_CODE,
            string PART,
            string DMC_CODE_PARTS,
            string MATERIAL_KODE,
            string MATERIAL_NAME,
            double UNIT_PRICE,
            string UNIT,
            double WIDE_SIZE,
            double LONG_SIZE,
            double MATERIAL_SIZE,
            double CUT_SIZE,
            int CAVITY,
            int QTY,
            double PRICE_PER_SHEET,
            double PRICE_PER_PCS
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_UpdateMaterialCost", new
            {
                DMC_CODE,
                PART,
                DMC_CODE_PARTS,
                MATERIAL_KODE,
                MATERIAL_NAME,
                UNIT_PRICE,
                UNIT,
                WIDE_SIZE,
                LONG_SIZE,
                MATERIAL_SIZE,
                CUT_SIZE,
                CAVITY,
                QTY,
                PRICE_PER_SHEET,
                PRICE_PER_PCS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Material Usage
        public List<DISA150001MaterialCost> getMaterialUsageDISA150001(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_GetMaterialUsage", new { DMC_CODE });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Working Hour Master
        public List<DISA150001MaterialCostUsage> getProcessMasterDISA150001(string DMC_CODE_PARTS)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISA150001MaterialCostUsage>("DISA150001/ProdCost/DISA150001_GetProcessMaster", new { DMC_CODE_PARTS });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Material Cost Usage
        public static List<DISA150001MaterialCostUsage> InsertMaterialCostUsage(            
            string DMC_CODE,
            string PART,
            string DMC_CODE_PARTS,       
            string KODE_PROSES,
            string NAMA_PROSES,
            double SETTING_TIME,
            double CYCLE_TIME,
            double LOT_SIZE,
            double TOTAL_TIME,
            double PROD_YIELD,
            double CHINRITSU,
            int CAVITY,
            string URUTAN_PROSES,
            double PRICE_PER_SHEET,
            double PRICE_PER_PCS

            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCostUsage>("DISA150001/ProdCost/DISA150001_InsertMaterialCostUsage", new
            {             
                DMC_CODE,
                PART,
                DMC_CODE_PARTS,                
                KODE_PROSES,
                NAMA_PROSES,
                SETTING_TIME,
                CYCLE_TIME,
                LOT_SIZE,
                TOTAL_TIME,
                PROD_YIELD,
                CHINRITSU,
                CAVITY,
                URUTAN_PROSES,
                PRICE_PER_SHEET,
                PRICE_PER_PCS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert Sales Price
        public static List<DISA150001Detail> InsertSalesPrice(
            string DMC_CODE,
            double AIR_JPN,
            double SEA_TOKYO,
            double AIR_SHA,
            double SEA_SHA,
            double AIR_HKG,
            double SEA_HKG,
            double TOTAL_DIRECT_LABOUR,
            double INDIRECT_LABOUR,
            double LABOUR_SGA,
            double TOTAL_COST_AIR_JPN,
            double TOTAL_COST_SEA_TOKYO,
            double TOTAL_COST_AIR_SHA,
            double TOTAL_COST_SEA_SHA,
            double TOTAL_COST_AIR_HKG,
            double TOTAL_COST_SEA_HKG,
            double TOTAL_COST_FOB,
            double SEA_JPN_SALES_PRICE,
            double AIR_SHA_SALES_PRICE,
            double SEA_SHA_SALES_PRICE,
            double AIR_HKG_SALES_PRICE,
            double SEA_HKG_SALES_PRICE,
            double AIR_CIF_SALES_PRICE,
            double AIR_CIF_MATERIAL_COST,
            double AIR_CIF_LABOUR_COST,
            double AIR_CIF_INDIRECT,
            double AIR_CIF_SGA,
            double AIR_CIF_TRANSPORTATION,
            double AIR_CIF_GRAND_TOTAL,
            double AIR_CIF_MARGINAL_PROFIT_RATIO,
            double AIR_CIF_PROFIT_RATIO,
            double FOB_SALES_PRICE,
            double FOB_MATERIAL_COST,
            double FOB_LABOUR_COST,
            double FOB_INDIRECT,
            double FOB_SGA,
            double FOB_TRANSPORTATION,
            double FOB_GRAND_TOTAL,
            double FOB_MARGINAL_PROFIT_RATIO,
            double FOB_PROFIT_RATIO,
            double LABOUR_COST_PRINTING,
            double LABOUR_COST_ASSEMBLY,
            double LABOUR_COST_ETCHING,
            double LABOUR_COST_PRESS,
            double LABOUR_COST_NON_PRINTING,
            double LABOUR_COST_KOMPO,
            double MATERIAL_COST_AFTER_GAIKAN,
            double LABOUR_COST_PRINTING_AFTER_GAIKAN,
            double LABOUR_COST_ASSEMBLY_AFTER_GAIKAN,
            double LABOUR_COST_ETCHING_AFTER_GAIKAN,
            double LABOUR_COST_PRESS_AFTER_GAIKAN,
            double LABOUR_COST_NON_PRINTING_AFTER_GAIKAN,
            double SUB_TOTAL_MATERIAL_COST_F,
            double SUB_TOTAL_MATERIAL_COST_G,
            double SUB_TOTAL_MATERIAL_COST_T,
            double SUB_TOTAL_MATERIAL_COST_ASSEMBLY,
            double SUB_TOTAL_MATERIAL_COST_PACKING
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_InsertSalesPrice", new
            {
                DMC_CODE,
                AIR_JPN,
                SEA_TOKYO,
                AIR_SHA,
                SEA_SHA,
                AIR_HKG,
                SEA_HKG,
                TOTAL_DIRECT_LABOUR,
                INDIRECT_LABOUR,
                LABOUR_SGA,
                TOTAL_COST_AIR_JPN,
                TOTAL_COST_SEA_TOKYO,
                TOTAL_COST_AIR_SHA,
                TOTAL_COST_SEA_SHA,
                TOTAL_COST_AIR_HKG,
                TOTAL_COST_SEA_HKG,
                TOTAL_COST_FOB,
                SEA_JPN_SALES_PRICE,
                AIR_SHA_SALES_PRICE,
                SEA_SHA_SALES_PRICE,
                AIR_HKG_SALES_PRICE,
                SEA_HKG_SALES_PRICE,
                AIR_CIF_SALES_PRICE,
                AIR_CIF_MATERIAL_COST,
                AIR_CIF_LABOUR_COST,
                AIR_CIF_INDIRECT,
                AIR_CIF_SGA,
                AIR_CIF_TRANSPORTATION,
                AIR_CIF_GRAND_TOTAL,
                AIR_CIF_MARGINAL_PROFIT_RATIO,
                AIR_CIF_PROFIT_RATIO,
                FOB_SALES_PRICE,
                FOB_MATERIAL_COST,
                FOB_LABOUR_COST,
                FOB_INDIRECT,
                FOB_SGA,
                FOB_TRANSPORTATION,
                FOB_GRAND_TOTAL,
                FOB_MARGINAL_PROFIT_RATIO,
                FOB_PROFIT_RATIO,
                LABOUR_COST_PRINTING,
                LABOUR_COST_ASSEMBLY,
                LABOUR_COST_ETCHING,
                LABOUR_COST_PRESS,
                LABOUR_COST_NON_PRINTING,
                LABOUR_COST_KOMPO,
                MATERIAL_COST_AFTER_GAIKAN,
                LABOUR_COST_PRINTING_AFTER_GAIKAN,
                LABOUR_COST_ASSEMBLY_AFTER_GAIKAN,
                LABOUR_COST_ETCHING_AFTER_GAIKAN,
                LABOUR_COST_PRESS_AFTER_GAIKAN,
                LABOUR_COST_NON_PRINTING_AFTER_GAIKAN,
                SUB_TOTAL_MATERIAL_COST_F,
                SUB_TOTAL_MATERIAL_COST_G,
                SUB_TOTAL_MATERIAL_COST_T,
                SUB_TOTAL_MATERIAL_COST_ASSEMBLY,
                SUB_TOTAL_MATERIAL_COST_PACKING
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Sales Price
        public static List<DISA150001Detail> UpdateSalesPrice(
            string DMC_CODE,
            double AIR_JPN,
            double SEA_TOKYO,
            double AIR_SHA,
            double SEA_SHA,
            double AIR_HKG,
            double SEA_HKG,
            double TOTAL_DIRECT_LABOUR,
            double INDIRECT_LABOUR,
            double LABOUR_SGA,
            double TOTAL_COST_AIR_JPN,
            double TOTAL_COST_SEA_TOKYO,
            double TOTAL_COST_AIR_SHA,
            double TOTAL_COST_SEA_SHA,
            double TOTAL_COST_AIR_HKG,
            double TOTAL_COST_SEA_HKG,
            double TOTAL_COST_FOB,
            double SEA_JPN_SALES_PRICE,
            double AIR_SHA_SALES_PRICE,
            double SEA_SHA_SALES_PRICE,
            double AIR_HKG_SALES_PRICE,
            double SEA_HKG_SALES_PRICE,
            double AIR_CIF_SALES_PRICE,
            double AIR_CIF_MATERIAL_COST,
            double AIR_CIF_LABOUR_COST,
            double AIR_CIF_INDIRECT,
            double AIR_CIF_SGA,
            double AIR_CIF_TRANSPORTATION,
            double AIR_CIF_GRAND_TOTAL,
            double AIR_CIF_MARGINAL_PROFIT_RATIO,
            double AIR_CIF_PROFIT_RATIO,
            double FOB_SALES_PRICE,
            double FOB_MATERIAL_COST,
            double FOB_LABOUR_COST,
            double FOB_INDIRECT,
            double FOB_SGA,
            double FOB_TRANSPORTATION,
            double FOB_GRAND_TOTAL,
            double FOB_MARGINAL_PROFIT_RATIO,
            double FOB_PROFIT_RATIO,
            double LABOUR_COST_PRINTING,
            double LABOUR_COST_ASSEMBLY,
            double LABOUR_COST_ETCHING,
            double LABOUR_COST_PRESS,
            double LABOUR_COST_NON_PRINTING,
            double LABOUR_COST_KOMPO,
            double MATERIAL_COST_AFTER_GAIKAN,
            double LABOUR_COST_PRINTING_AFTER_GAIKAN,
            double LABOUR_COST_ASSEMBLY_AFTER_GAIKAN,
            double LABOUR_COST_ETCHING_AFTER_GAIKAN,
            double LABOUR_COST_PRESS_AFTER_GAIKAN,
            double LABOUR_COST_NON_PRINTING_AFTER_GAIKAN,
            double SUB_TOTAL_MATERIAL_COST_F,
            double SUB_TOTAL_MATERIAL_COST_G,
            double SUB_TOTAL_MATERIAL_COST_T,
            double SUB_TOTAL_MATERIAL_COST_ASSEMBLY,
            double SUB_TOTAL_MATERIAL_COST_PACKING
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_UpdateSalesPrice", new
            {
                DMC_CODE,
                AIR_JPN,
                SEA_TOKYO,
                AIR_SHA,
                SEA_SHA,
                AIR_HKG,
                SEA_HKG,
                TOTAL_DIRECT_LABOUR,
                INDIRECT_LABOUR,
                LABOUR_SGA,
                TOTAL_COST_AIR_JPN,
                TOTAL_COST_SEA_TOKYO,
                TOTAL_COST_AIR_SHA,
                TOTAL_COST_SEA_SHA,
                TOTAL_COST_AIR_HKG,
                TOTAL_COST_SEA_HKG,
                TOTAL_COST_FOB,
                SEA_JPN_SALES_PRICE,
                AIR_SHA_SALES_PRICE,
                SEA_SHA_SALES_PRICE,
                AIR_HKG_SALES_PRICE,
                SEA_HKG_SALES_PRICE,
                AIR_CIF_SALES_PRICE,
                AIR_CIF_MATERIAL_COST,
                AIR_CIF_LABOUR_COST,
                AIR_CIF_INDIRECT,
                AIR_CIF_SGA,
                AIR_CIF_TRANSPORTATION,
                AIR_CIF_GRAND_TOTAL,
                AIR_CIF_MARGINAL_PROFIT_RATIO,
                AIR_CIF_PROFIT_RATIO,
                FOB_SALES_PRICE,
                FOB_MATERIAL_COST,
                FOB_LABOUR_COST,
                FOB_INDIRECT,
                FOB_SGA,
                FOB_TRANSPORTATION,
                FOB_GRAND_TOTAL,
                FOB_MARGINAL_PROFIT_RATIO,
                FOB_PROFIT_RATIO,
                LABOUR_COST_PRINTING,
                LABOUR_COST_ASSEMBLY,
                LABOUR_COST_ETCHING,
                LABOUR_COST_PRESS,
                LABOUR_COST_NON_PRINTING,
                LABOUR_COST_KOMPO,
                MATERIAL_COST_AFTER_GAIKAN,
                LABOUR_COST_PRINTING_AFTER_GAIKAN,
                LABOUR_COST_ASSEMBLY_AFTER_GAIKAN,
                LABOUR_COST_ETCHING_AFTER_GAIKAN,
                LABOUR_COST_PRESS_AFTER_GAIKAN,
                LABOUR_COST_NON_PRINTING_AFTER_GAIKAN,
                SUB_TOTAL_MATERIAL_COST_F,
                SUB_TOTAL_MATERIAL_COST_G,
                SUB_TOTAL_MATERIAL_COST_T,
                SUB_TOTAL_MATERIAL_COST_ASSEMBLY,
                SUB_TOTAL_MATERIAL_COST_PACKING

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update Material Cost Usage
        public static List<DISA150001MaterialCostUsage> UpdateMaterialCostUsage(
            string DMC_CODE,
            string PART,
            string DMC_CODE_PARTS,
            string KODE_PROSES,
            string NAMA_PROSES,
            double SETTING_TIME,
            double CYCLE_TIME,
            double LOT_SIZE,
            double TOTAL_TIME,
            double PROD_YIELD,
            double CHINRITSU,
            int CAVITY,
            string URUTAN_PROSES,
            double PRICE_PER_SHEET,
            double PRICE_PER_PCS
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCostUsage>("DISA150001/ProdCost/DISA150001_UpdateMaterialCostUsage", new
            {
                DMC_CODE,
                PART,
                DMC_CODE_PARTS,
                KODE_PROSES,
                NAMA_PROSES,
                SETTING_TIME,
                CYCLE_TIME,
                LOT_SIZE,
                TOTAL_TIME,
                PROD_YIELD,
                CHINRITSU,
                CAVITY,
                URUTAN_PROSES,
                PRICE_PER_SHEET,
                PRICE_PER_PCS
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Insert WIP Cost
        public static List<DISA150001WipCost> InsertWipCost(
            string DMC_CODE_PARTS,
            double MATERIAL_COST,
            double FINISH_GOODS,
            double PRINTING,
            double LAMINATING_AKHIR,
            double WASHING_GLASS,
            double SCRIBE,
            double HOGOSIRU,
            double PUNCHING,
            double SUDAH_PRESS,
            double SUDAH_KAPTONTAPE,
            double SUDAH_CHUKAN,
            double SUDAH_FPC,
            double SUDAH_HEATSEAL,
            double SUDAH_HARIAWASE,
            double SUDAH_AGING,
            double SUDAH_OVEN,
            double SUDAH_HOKYOTAPE,
            double SUDAH_DOUBLETAPE,
            double SUDAH_FUREKENSA,
            double SUDAH_CEK_KELENGKAPAN,
            double SUDAH_DENKI,
            double SUDAH_GAIKAN
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001WipCost>("DISA150001/WipCost/DISA150001_InsertWipCost", new
            {
                DMC_CODE_PARTS,
                MATERIAL_COST,
                FINISH_GOODS,
                PRINTING,
                LAMINATING_AKHIR,
                WASHING_GLASS,
                SCRIBE,
                HOGOSIRU,
                PUNCHING,
                SUDAH_PRESS,
                SUDAH_KAPTONTAPE,
                SUDAH_CHUKAN,
                SUDAH_FPC,
                SUDAH_HEATSEAL,
                SUDAH_HARIAWASE,
                SUDAH_AGING,
                SUDAH_OVEN,
                SUDAH_HOKYOTAPE,
                SUDAH_DOUBLETAPE,
                SUDAH_FUREKENSA,
                SUDAH_CEK_KELENGKAPAN,
                SUDAH_DENKI,
                SUDAH_GAIKAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Update WIP Cost
        public static List<DISA150001WipCost> UpdateWipCost(
            string DMC_CODE_PARTS,
            double MATERIAL_COST,
            double FINISH_GOODS,
            double PRINTING,
            double LAMINATING_AKHIR,
            double WASHING_GLASS,
            double SCRIBE,
            double HOGOSIRU,
            double PUNCHING,
            double SUDAH_PRESS,
            double SUDAH_KAPTONTAPE,
            double SUDAH_CHUKAN,
            double SUDAH_FPC,
            double SUDAH_HEATSEAL,
            double SUDAH_HARIAWASE,
            double SUDAH_AGING,
            double SUDAH_OVEN,
            double SUDAH_HOKYOTAPE,
            double SUDAH_DOUBLETAPE,
            double SUDAH_FUREKENSA,
            double SUDAH_CEK_KELENGKAPAN,
            double SUDAH_DENKI,
            double SUDAH_GAIKAN
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001WipCost>("DISA150001/WipCost/DISA150001_UpdateWipCost", new
            {
                DMC_CODE_PARTS,
                MATERIAL_COST,
                FINISH_GOODS,
                PRINTING,
                LAMINATING_AKHIR,
                WASHING_GLASS,
                SCRIBE,
                HOGOSIRU,
                PUNCHING,
                SUDAH_PRESS,
                SUDAH_KAPTONTAPE,
                SUDAH_CHUKAN,
                SUDAH_FPC,
                SUDAH_HEATSEAL,
                SUDAH_HARIAWASE,
                SUDAH_AGING,
                SUDAH_OVEN,
                SUDAH_HOKYOTAPE,
                SUDAH_DOUBLETAPE,
                SUDAH_FUREKENSA,
                SUDAH_CEK_KELENGKAPAN,
                SUDAH_DENKI,
                SUDAH_GAIKAN
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Download Data Excel Material Cost
        public List<DISA150001MaterialCost> DownloadExcelMaterialCost(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCost>("DISA150001/ProdCost/DISA150001_Download_Excel_MaterialCost", new
            {
                DMC_CODE
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #region Download Data Excel Material Cost Usage
        public List<DISA150001MaterialCostUsage> DownloadExcelMaterialCostUsage(string DMC_CODE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001MaterialCostUsage>("DISA150001/ProdCost/DISA150001_Download_Excel_MaterialCostUsage", new
            {
                DMC_CODE
            }).ToList();
            db.Close();
            return d;
        }
        #endregion

        #region Delete
        public List<DISA150001Detail> DeleteCalc(string DMC_TYPE)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001Detail>("DISA150001/ProdCost/DISA150001_DeleteCalc", new { DMC_TYPE });
            db.Close();
            return d.ToList();
        }
        #endregion
    }

    public class DISA150001GetAllNodes
    {
       public string CODE { get; set; }
       public string KCODE { get; set; }
       public string NAME { get; set; }
        public int CUT_SIZE { get; set; }
        public int LONG_SIZE { get; set; }
        public string SDATE { get; set; }
        public int WIDE_SIZE { get; set; }
        public int MATERIAL_SIZE { get; set; }
        public int QTY { get; set; }
        public string EDATE { get; set; }       
    }

    public class DISA150001MaterialCost
    {        
        public string ID { get; set; }
        public string DMC_CODE { get; set; }
        public string PART { get; set; }
        public string DMC_CODE_PARTS { get; set; }        
        public string MATERIAL_KODE { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string MATERIAL_TYPE { get; set; }
        public double UNIT_PRICE { get; set; }
        public string UNIT { get; set; }
        public double WIDE_SIZE { get; set; }
        public double LONG_SIZE { get; set; }
        public double MATERIAL_SIZE { get; set; }
        public double CUT_SIZE { get; set; }
        public int QTY { get; set; }
        public int CAVITY { get; set; }
        public int C_INNER { get; set; }
        public int C_FOAM { get; set; }
        public int C_MASTER { get; set; }
        public double PRICE_PER_SHEET { get; set; }
        public double PRICE_PER_PCS { get; set; }        

        public Int32 ROW_NUM { get; set; }
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    //public class DISA150001MasterFormula
    //{
    //    public string ID { get; set; }
    //    public string NO_FORMULA { get; set; }
    //    public string DMC_CODE { get; set; }
    //    public string DMC_CODE_PARTS { get; set; }
    //    public string PART { get; set; }
    //    public string MATERIAL { get; set; }
    //    public string IDENTIFY_1 { get; set; }
    //    public double VAR_1 { get; set; }
    //    public string IDENTIFY_2 { get; set; }
    //    public double VAR_2 { get; set; }
    //    public string IDENTIFY_3 { get; set; }
    //    public double VAR_3 { get; set; }
    //    public string IDENTIFY_4 { get; set; }
    //    public double VAR_4 { get; set; }
    //    public string IDENTIFY_5 { get; set; }
    //    public double VAR_5 { get; set; }
    //    public string IDENTIFY_6 { get; set; }
    //    public double VAR_6 { get; set; }
    //    public string IDENTIFY_7 { get; set; }
    //    public double VAR_7 { get; set; }
    //    public string IDENTIFY_8 { get; set; }
    //    public double VAR_8 { get; set; }


    //    public Int32 ROW_NUM { get; set; }
    //    public string STS_CD { get; set; }
    //    public string STS_VAL { get; set; }
    //    public string STACK { get; set; }
    //    public string LINE_STS { get; set; }
    //}

    public class DISA150001MaterialCostUsage
    {
        public string ID { get; set; }        
        public string PART { get; set; }
        public string DMC_CODE { get; set; }
        public string DMC_CODE_PARTS { get; set; }
        public string KODE_PROSES { get; set; }
        public string URUTAN_PROSES { get; set; }
        public string NAMA_PROSES { get; set; }                
        public double SETTING_TIME { get; set; }
        public double CYCLE_TIME { get; set; }
        public double LOT_SIZE { get; set; }
        public double TOTAL_TIME { get; set; }
        public double PROD_YIELD { get; set; }
        public double CHINRITSU { get; set; }
        public int CAVITY { get; set; }
        public double PRICE_PER_SHEET { get; set; }
        public double PRICE_PER_PCS { get; set; }
        public Int32 ROW_NUM { get; set; }
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }
    }

    public class DISA150001WipCost
    {
        public int ROWNUM { get; set; }
        public string ID { get; set; }
        public string DMC_CODE { get; set; }
        public string DMC_CODE_PARTS { get; set; }
        public double MATERIAL_COST { get; set; }
        public double FINISH_GOODS { get; set; }
        public double PRINTING { get; set; }
        public double LAMINATING_AKHIR { get; set; }
        public double WASHING_GLASS { get; set; }
        public double SCRIBE { get; set; }
        public double HOGOSIRU { get; set; }
        public double PUNCHING { get; set; }
        public double SUDAH_PRESS { get; set; }
        public double SUDAH_KAPTONTAPE { get; set; }
        public double SUDAH_CHUKAN { get; set; }
        public double SUDAH_FPC { get; set; }
        public double SUDAH_HEATSEAL { get; set; }
        public double SUDAH_HARIAWASE { get; set; }
        public double SUDAH_AGING { get; set; }
        public double SUDAH_OVEN { get; set; }
        public double SUDAH_HOKYOTAPE { get; set; }
        public double SUDAH_DOUBLETAPE { get; set; }
        public double SUDAH_FUREKENSA { get; set; }
        public double SUDAH_CEK_KELENGKAPAN { get; set; }
        public double SUDAH_DENKI { get; set; }
        public double SUDAH_GAIKAN { get; set; }
        public double LABOR_COST { get; set; }
        public double ORIGINAL_LABOR_COST { get; set; }
        public double INDIRECT { get; set; }
        public double MANUFACTURING_COST { get; set; }
        public string FLG_STATUS_PROD { get; set; }

        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
    }

    public class DISA150001PriceList
    {
        public int ROWNUM { get; set; }
        public string ID { get; set; }
        public string DMC_TYPE { get; set; }
        public string CUSTOMER { get; set; }
        public string TOUCH_PANEL_TYPE { get; set; }
        public string TOUCH_PANEL_SIZE { get; set; }
        public string VERSI_WIS { get; set; }
        public double TOTAL_YIELD_FILM { get; set; }
        public string JENIS_TRANSPORTATION { get; set; }
        public double ORIGINAL_LOT_SIZE { get; set; }
        public double AIR_CIF_SALES_PRICE { get; set; }
        public double SEA_JPN_SALES_PRICE { get; set; }
        public double FOB_SALES_PRICE { get; set; }
        public double LOT_10 { get; set; }
        public double LOT_20 { get; set; }
        public double LOT_50 { get; set; }
        public double LOT_100 { get; set; }
        public double LOT_200 { get; set; }
        public double LOT_300 { get; set; }
        public double LOT_400 { get; set; }
        public double LOT_500 { get; set; }
        public double LOT_1000 { get; set; }
        public double LOT_5000 { get; set; }
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }
    }


    public class DISA150001Detail
    {
        public int ROWNUM { get; set; }
        public string ID { get; set; }
        public string KATEGORI_MATERIAL { get; set; }
        public string DMC_TYPE { get; set; }
        public string DMC_CODE_PARTS { get; set; }
        public string CUSTOMER { get; set; }
        public string TOUCH_PANEL_TYPE { get; set; }
        public string RANK { get; set; }
        public string TOUCH_PANEL_DIMENSION { get; set; }
        public string TOUCH_PANEL_SIZE { get; set; }
        public string VERSI_WIS { get; set; }
        public double LOT_SIZE { get; set; }
        public double INDIRECT { get; set; }//*
        public double SGA { get; set; }
        public double CAVITY_FILM { get; set; }
        public double CAVITY_GLASS { get; set; }
        public double CAVITY_TAIL { get; set; }
        public double YIELD_PRINTING_FILM { get; set; }
        public double YIELD_PRINTING_GLASS { get; set; }
        public double YIELD_PRINTING_TAIL { get; set; }
        public double YIELD_FILM_MIDLE_INSPECTION { get; set; }
        public double YIELD_GLASS_MIDLE_INSPECTION { get; set; }
        public double YIELD_TAIL_ELECTRICAL { get; set; }
        public double YIELD_TAIL_COSMETIC { get; set; }
        public double YIELD_ASSEMBLY { get; set; }
        public double YIELD_FINAL_ASSEMBLY { get; set; }
        public double YIELD_ELECTRICAL_INSPECTION { get; set; }
        public double YIELD_FINAL_INSPECTION { get; set; }
        public double YIELD_TOTAL_FILM { get; set; }
        public double YIELD_TOTAL_GLASS { get; set; }
        public double YIELD_TOTAL_TAIL { get; set; }
        public double LOT_SIZE_FILM { get; set; }
        public double MAX_LOT_SIZE_FILM { get; set; }
        public double LOT_SIZE_GLASS { get; set; }
        public double MAX_LOT_SIZE_GLASS { get; set; }
        public double LOT_SIZE_TAIL { get; set; }
        public double MAX_LOT_SIZE_TAIL { get; set; }
        public double LABOUR_CHARGE_PRINTING { get; set; }
        public double LABOUR_CHARGE_ASSEMBLY { get; set; }
        public double LABOUR_CHARGE_ETCHING { get; set; }
        public double LABOUR_CHARGE_PRESS { get; set; }
        public double LABOUR_CHARGE_NON_PRINTING { get; set; }
        public double LABOUR_CHARGE_KOMPO { get; set; }
        public double AIR_CIF_SALES_PRICE { get; set; }
        public double AIR_CIF_MATERIAL_COST { get; set; }
        public double AIR_CIF_LABOUR_COST { get; set; }
        public double AIR_CIF_INDIRECT { get; set; }
        public double AIR_CIF_SGA { get; set; }
        public double AIR_CIF_TRANSPORTATION_COST { get; set; }
        public double AIR_CIF_GRAND_TOTAL { get; set; }
        public double AIR_CIF_MARGINAL_PROFIT_RATIO { get; set; }
        public double AIR_CIF_PROFIT_RATIO { get; set; }
        public double FOB_SALES_PRICE { get; set; }
        public double FOB_MATERIAL_COST { get; set; }
        public double FOB_LABOUR_COST { get; set; }
        public double FOB_INDIRECT { get; set; }
        public double FOB_SGA { get; set; }
        public double FOB_TRANSPORTATION_COST { get; set; }
        public double FOB_GRAND_TOTAL { get; set; }
        public double FOB_MARGINAL_PROFIT_RATIO { get; set; }
        public double FOB_PROFIT_RATIO { get; set; }
        public double LABOUR_COST_PRINTING { get; set; }
        public double LABOUR_COST_ASSEMBLY { get; set; }
        public double LABOUR_COST_ETCHING { get; set; }
        public double LABOUR_COST_PRESS { get; set; }
        public double LABOUR_COST_NON_PRINTING { get; set; }
        public double LABOUR_COST_KOMPO { get; set; }
        public double MATERIAL_COST_AFTER_GAIKAN { get; set; }
        public double LABOUR_COST_PRINTING_AFTER_GAIKAN { get; set; }
        public double LABOUR_COST_ASSEMBLY_AFTER_GAIKAN { get; set; }
        public double LABOUR_COST_ETCHING_AFTER_GAIKAN { get; set; }
        public double LABOUR_COST_PRESS_AFTER_GAIKAN { get; set; }
        public double LABOUR_COST_NON_PRINTING_AFTER_GAIKAN { get; set; }
        public double LABOR_COST_PRINTING_F { get; set; }
        public double LABOR_COST_PRINTING_G { get; set; }
        public double LABOR_COST_PRINTING_T { get; set; }                
        public double LABOR_COST_ETCHING_F { get; set; }
        public double LABOR_COST_ETCHING_G { get; set; }
        public double LABOR_COST_PRESS_F { get; set; }        
        public double LABOR_COST_PRESS_T { get; set; }
        public double LABOR_COST_NON_PRINTING_F { get; set; }
        public double LABOR_COST_NON_PRINTING_G { get; set; }
        public double LABOR_COST_NON_PRINTING_T { get; set; }        
        public double TOTAL_LABOR_COST_CHUKAN_FILM { get; set; }
        public double TOTAL_LABOR_COST_CHUKAN_GLASS { get; set; }
        public double TOTAL_LABOR_COST_DENKI_TAIL { get; set; }
        public double TOTAL_LABOR_COST_GAIKAN_TAIL { get; set; }
        public double TOTAL_LABOR_COST_CEK_KELENGKAPAN_TAIL { get; set; }
        public double TOTAL_LABOR_COST_TAIL_SASHI { get; set; }
        public double TOTAL_LABOR_COST_HARIAWASE { get; set; }
        public double TOTAL_LABOR_COST_OVEN { get; set; }
        public double TOTAL_LABOR_COST_ANNEALING { get; set; }
        public double TOTAL_LABOR_COST_HEATSEAL { get; set; }
        public double TOTAL_LABOR_COST_HOKYOTAPE { get; set; }
        public double TOTAL_LABOR_COST_FUREKENSA { get; set; }
        public double TOTAL_LABOR_COST_DENKI { get; set; }
        public double TOTAL_LABOR_COST_DOUBLE_TAPE { get; set; }
        public double TOTAL_LABOR_COST_BARCODE_LABEL { get; set; }
        public double TOTAL_LABOR_COST_GAIKAN_1X { get; set; }
        public double TOTAL_LABOR_COST_GAIKAN_2X { get; set; }       
        public double AKUMULASI_PRICE_MATERIAL_PER_PCS_F { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_PER_PCS_G { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_PER_PCS_T { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_PER_PCS_A { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_PER_PCS_P { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_F { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_G { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_T { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_A { get; set; }
        public double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_P { get; set; }
        public double SEA_JPN_SALES_PRICE { get; set; }
        public double AIR_SHA_SALES_PRICE { get; set; }
        public double SEA_SHA_SALES_PRICE { get; set; }
        public double AIR_HKG_SALES_PRICE { get; set; }
        public double SEA_HKG_SALES_PRICE { get; set; }
        public double TOTAL_COST_AIR_JPN { get; set; }
        public double TOTAL_COST_SEA_TOKYO { get; set; }
        public double TOTAL_COST_AIR_SHA { get; set; }
        public double TOTAL_COST_SEA_SHA { get; set; }
        public double TOTAL_COST_AIR_HKG { get; set; }
        public double TOTAL_COST_SEA_HKG { get; set; }
        public double TOTAL_COST_FOB { get; set; }
        public double TOTAL_DIRECT_LABOUR { get; set; }
        public double INDIRECT_LABOUR { get; set; }
        public double LABOUR_SGA { get; set; }

        public double PROD_YIELD { get; set; }
        public string PART { get; set; }

        public double AIR_JPN { get; set; }
        public double SEA_TOKYO { get; set; }
        public double AIR_SHA { get; set; }
        public double SEA_SHA { get; set; }
        public double AIR_HKG { get; set; }
        public double SEA_HKG { get; set; }
        


        // untuk combobox Status
        public string STS_CD { get; set; }
        public string STS_VAL { get; set; }
        public string STACK { get; set; }
        public string LINE_STS { get; set; }

        public Int32 ROW_NUM { get; set; }
        public Int32 Number { get; set; }
        public string DELETE_DATA { get; set; }        

    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END PRODUCTION COST
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER CONVENTION TABLE
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER CONVENTION TABLE
    public class DISA150001_ConvTable_Repository
    {
        #region Get_Data_Grid_DISA150001
        public List<DISA150001_ConvTable_Master> getDataDISA150001(
            int Start,
            int Display,
            string ItemCode,
            string Parts,
            string type
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_ConvTable_Master>("DISA150001/ConvTable/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ItemCode,
                Parts,
                type
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(
            string DATA_ID,
            string ItemCode,
            string Parts,
            string type
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            int result = db.SingleOrDefault<int>("DISA150001/ConvTable/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ItemCode,
                Parts,
                type
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_ConvTable_Master> Create(
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_ConvTable_Master>("DISA150001/ConvTable/DISA150001_Create", new
            {
                ItemCode,
                Parts,
                SizeProduct,
                type,
                BundleQty,
                InnerQty,
                MasterQty,
                InnerType,
                InnerL,
                InnerW,
                InnerH,
                InnerWeight,
                MasterType,
                MasterL,
                MasterW,
                MasterH,
                MasterWeight,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_ConvTable(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.SingleOrDefault<string>("DISA150001/ConvTable/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA150001_ConvTable_Master> Update_Data_ConvTable(
            string ID,
            string ItemCode,
            string Parts,
            string SizeProduct,
            string type,
            string BundleQty,
            string InnerQty,
            string MasterQty,
            string InnerType,
            string InnerL,
            string InnerW,
            string InnerH,
            string InnerWeight,
            string MasterType,
            string MasterL,
            string MasterW,
            string MasterH,
            string MasterWeight,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_ConvTable_Master>("DISA150001/ConvTable/DISA150001_Update", new
            {
                ID,
                ItemCode,
                Parts,
                SizeProduct,
                type,
                BundleQty,
                InnerQty,
                MasterQty,
                InnerType,
                InnerL,
                InnerW,
                InnerH,
                InnerWeight,
                MasterType,
                MasterL,
                MasterW,
                MasterH,
                MasterWeight,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class DeleteModel_ConvTable
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END MASTER CONVENTION TABLE
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER TYPE CUSTOMER
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER TYPE CUSTOMER
    public class DISA150001_TypeCust_Repository
    {
        #region Get Pilih Dmc Type From Item Master
        public List<DISA150001_TypeCust_Master> getDmcTypeItemMaster()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_TypeCust_Master>("DISA150001/TypeCust/DISA150001_GetListDmcType");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Pilih Customer
        public List<DISA150001_TypeCust_Master> getCustomer()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_TypeCust_Master>("DISA150001/TypeCust/DISA150001_GetCustomer");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Indirect Sga
        public List<DISA150001_TypeCust_Master> getIndirectSga()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_TypeCust_Master>("DISA150001/TypeCust/DISA150001_GetIndirectSga");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISA150001
        public List<DISA150001_TypeCust_Master> getDataDISA150001(
            int Start,
            int Display,
            string Dmc_Type,
            string Customer,
            string Lot_Size
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_TypeCust_Master>("DISA150001/TypeCust/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                Dmc_Type,
                Customer,
                Lot_Size
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(
            string DATA_ID,
            string Dmc_Type,
            string Customer,
            string Lot_Size
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/TypeCust/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                Dmc_Type,
                Customer,
                Lot_Size
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_TypeCust_Master> Create(
            string Dmc_Type,
            string Customer,
            string Touch_Panel_Size,
            string Wis_Version,
            int Lot_Size,
            double In_Direct,
            double Sga,
            string Username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_TypeCust_Master>("DISA150001/TypeCust/DISA150001_Create", new
            {
                Dmc_Type,
                Customer,
                Touch_Panel_Size,
                Wis_Version,
                Lot_Size,
                In_Direct,
                Sga,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_TypeCust(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA150001/TypeCust/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA150001_ConvTable_Master> Update_Data_TypeCust(
            string ID,
            string Dmc_Type,
            string Customer,
            string Touch_Panel_Size,
            string Wis_Version,
            string Lot_Size,
            string In_Direct,
            string Sga,
            string Username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_ConvTable_Master>("DISA150001/TypeCust/DISA150001_Update", new
            {
                ID,
                Dmc_Type,
                Customer,
                Touch_Panel_Size,
                Wis_Version,
                Lot_Size,
                In_Direct,
                Sga,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class DeleteModel_TypeCust
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END MASTER TYPE CUSTOMER
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER CHINRITSU
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER CHINRITSU
    public class DISA150001_Chinritsu_Repository
    {
        #region Get LIst Proses
        public List<DISA150001_Chinritsu_Master> getListProses()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISA150001_Chinritsu_Master>("DISA150001/Chinritsu/DISA150001_GetListProses");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Detail Data Proses
        public List<DISA150001_Chinritsu_Master> get_Data_Proses(string NAME_KOTEI)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<DISA150001_Chinritsu_Master>("DISA150001/Chinritsu/DISA150001_getDataProses", new
            {
                NAME_KOTEI
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISA150001
        public List<DISA150001_Chinritsu_Master> getDataDISA150001(
            int Start,
            int Display,
            string PART,
            string ID_KOTEI,
            string NAME_KOTEI,
            string FACTORY,
            string CHINRITSU
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Chinritsu_Master>("DISA150001/Chinritsu/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                PART,
                ID_KOTEI,
                NAME_KOTEI,
                FACTORY,
                CHINRITSU
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(
            string DATA_ID,
            string PART,
            string ID_KOTEI,
            string NAME_KOTEI,
            string FACTORY,
            string CHINRITSU
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/Chinritsu/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                PART,
                ID_KOTEI,
                NAME_KOTEI,
                FACTORY,
                CHINRITSU
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_Chinritsu_Master> Create(
            string PART,
            string ID_KOTEI,
            string FACTORY,
            string CHINRITSU,
            string Username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Chinritsu_Master>("DISA150001/Chinritsu/DISA150001_Create", new
            {
                PART,
                ID_KOTEI,
                FACTORY,
                CHINRITSU,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_Chinritsu(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA150001/Chinritsu/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA150001_Chinritsu_Master> Update_Data_Chinritsu(
            string ID,
            string PART,
            string NAME_KOTEI,
            string ID_KOTEI,
            string FACTORY,
            string CHINRITSU,
            string Username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Chinritsu_Master>("DISA150001/Chinritsu/DISA150001_Update", new
            {
                ID,
                PART,
                NAME_KOTEI,
                ID_KOTEI,
                FACTORY,
                CHINRITSU,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class DeleteModel_Chinritsu
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END MASTER CHINRITSU
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER UNIT PRICE
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER UNIT PRICE
    public class DISA150001_UnitPrice_Repository
    {
        #region Get LIst Item
        public List<DISA150001_UnitPrice_Master> getListItem()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_UnitPrice_Master>("DISA150001/UnitPrice/DISA150001_GetListItem");

            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get Detail Data Proses
        public List<DISA150001_UnitPrice_Master> get_Data_Item(string NAME_ITEM)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_4");
            var d = db.Fetch<DISA150001_UnitPrice_Master>("DISA150001/UnitPrice/DISA150001_getDataItem", new
            {
                NAME_ITEM
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Get_Data_Grid_DISA150001
        public List<DISA150001_UnitPrice_Master> getDataDISA150001(
            int Start,
            int Display,
            string ITEM_CODE,
            string NAME_ITEM,            
            string UNIT_PRICE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_UnitPrice_Master>("DISA150001/UnitPrice/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ITEM_CODE,
                NAME_ITEM,                
                UNIT_PRICE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(
            string DATA_ID,
            string ITEM_CODE,
            string NAME_ITEM,
            string UNIT_PRICE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/UnitPrice/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ITEM_CODE,
                NAME_ITEM,
                UNIT_PRICE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_UnitPrice_Master> Create(
            string ITEM_CODE,            
            string UNIT_PRICE,
            string Username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_UnitPrice_Master>("DISA150001/UnitPrice/DISA150001_Create", new
            {
                ITEM_CODE,                
                UNIT_PRICE,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_UnitPrice(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA150001/UnitPrice/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA150001_UnitPrice_Master> Update_Data_UnitPrice(
            string ID,
            string NAME_ITEM,
            string ITEM_CODE,
            string UNIT_PRICE,
            string Username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_UnitPrice_Master>("DISA150001/UnitPrice/DISA150001_Update", new
            {
                ID,
                NAME_ITEM,
                ITEM_CODE,
                UNIT_PRICE,
                Username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class DeleteModel_UnitPrice
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END MASTER UNIT PRICE
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER CONVENTION TABLE
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER CHOKORITSU
    public class DISA150001_Chokoritsu_Repository
    {
        #region Get_Data_Grid_DISA150001
        public List<DISA150001_Chokoritsu_Master> getDataDISA150001(
            int Start,
            int Display,
            string DMC_TYPE
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Chokoritsu_Master>("DISA150001/Chokoritsu/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                DMC_TYPE
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(
            string DATA_ID,
            string DMC_TYPE
            )
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/Chokoritsu/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                DMC_TYPE
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_Chokoritsu_Master> Create(
            string DMC_TYPE,
            string YIELD_PRINTING_FILM,
            string YIELD_PRINTING_GLASS,
            string YIELD_PRINTING_TAIL,
            string YIELD_PRINTING_OVERLAY,
            string YIELD_SCRIBE,
            string YIELD_FILM_MIDLE_INSPECTION,
            string YIELD_FILM_KABU_MIDLE_INSPECTION,
            string YIELD_GLASS_MIDLE_INSPECTION,
            string YIELD_OVERLAY_MIDLE_INSPECTION,
            string YIELD_TAIL_ELECTRICAL,
            string YIELD_TAIL_COSMETIC,
            string YIELD_ASSEMBLY,
            string YIELD_FINAL_ASSEMBLY,
            string YIELD_ELECTRICAL_INSPECTION,
            string YIELD_FINAL_INSPECTION,
            string YIELD_DENKI_FILM,
            string YIELD_DENKI_GLASS,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Chokoritsu_Master>("DISA150001/Chokoritsu/DISA150001_Create", new
            {
                DMC_TYPE,
                YIELD_PRINTING_FILM,
                YIELD_PRINTING_GLASS,
                YIELD_PRINTING_TAIL,
                YIELD_PRINTING_OVERLAY,
                YIELD_SCRIBE,
                YIELD_FILM_MIDLE_INSPECTION,
                YIELD_FILM_KABU_MIDLE_INSPECTION,
                YIELD_GLASS_MIDLE_INSPECTION,
                YIELD_OVERLAY_MIDLE_INSPECTION,
                YIELD_TAIL_ELECTRICAL,
                YIELD_TAIL_COSMETIC,
                YIELD_ASSEMBLY,
                YIELD_FINAL_ASSEMBLY,
                YIELD_ELECTRICAL_INSPECTION,
                YIELD_FINAL_INSPECTION,
                YIELD_DENKI_FILM,
                YIELD_DENKI_GLASS,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_Chokoritsu(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA150001/Chokoritsu/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA150001_Chokoritsu_Master> Update_Data_Chokoritsu(
            string ID,
            string DMC_TYPE,
            string YIELD_PRINTING_FILM,
            string YIELD_PRINTING_GLASS,
            string YIELD_PRINTING_TAIL,
            string YIELD_PRINTING_OVERLAY,
            string YIELD_SCRIBE,
            string YIELD_FILM_MIDLE_INSPECTION,
            string YIELD_FILM_KABU_MIDLE_INSPECTION,
            string YIELD_GLASS_MIDLE_INSPECTION,
            string YIELD_OVERLAY_MIDLE_INSPECTION,
            string YIELD_TAIL_ELECTRICAL,
            string YIELD_TAIL_COSMETIC,
            string YIELD_ASSEMBLY,
            string YIELD_FINAL_ASSEMBLY,
            string YIELD_ELECTRICAL_INSPECTION,
            string YIELD_FINAL_INSPECTION,
            string YIELD_DENKI_FILM,
            string YIELD_DENKI_GLASS,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Chokoritsu_Master>("DISA150001/Chokoritsu/DISA150001_Update", new
            {
                ID,
                DMC_TYPE,
                YIELD_PRINTING_FILM,
                YIELD_PRINTING_GLASS,
                YIELD_PRINTING_TAIL,
                YIELD_PRINTING_OVERLAY,
                YIELD_SCRIBE,
                YIELD_FILM_MIDLE_INSPECTION,
                YIELD_FILM_KABU_MIDLE_INSPECTION,
                YIELD_GLASS_MIDLE_INSPECTION,
                YIELD_OVERLAY_MIDLE_INSPECTION,
                YIELD_TAIL_ELECTRICAL,
                YIELD_TAIL_COSMETIC,
                YIELD_ASSEMBLY,
                YIELD_FINAL_ASSEMBLY,
                YIELD_ELECTRICAL_INSPECTION,
                YIELD_FINAL_INSPECTION,
                YIELD_DENKI_FILM,
                YIELD_DENKI_GLASS,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class DeleteModel_Chokoritsu
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END MASTER CHOKORITSU
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER LIST KONPO
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER LIST KONPO
    public class DISA150001_ListKonpo_Repository
    {
        #region Get_Data_Grid_DISA150001
        public List<DISA150001_ListKonpo_Master> getDataDISA150001(int Start, int Display, string ITEM_CODE, string JENIS_PACKING, string HARGA)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_ListKonpo_Master>("DISA150001/ListKonpo/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ITEM_CODE,
                JENIS_PACKING,
                HARGA
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(string DATA_ID, string ITEM_CODE, string JENIS_PACKING, string HARGA)
        {

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/ListKonpo/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ITEM_CODE,
                JENIS_PACKING,
                HARGA
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_ListKonpo_Master> Create(string item_code, string jenis_packing, string qty_pcs, string factory_size, string indirect, string berat, string panjang, string lebar, string tinggi, string harga, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_ListKonpo_Master>("DISA150001/ListKonpo/DISA150001_Create", new
            {
                item_code,
                jenis_packing,
                qty_pcs,
                factory_size,
                indirect,
                berat,
                panjang,
                lebar,
                tinggi,
                harga,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_ListKonpo(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA150001/ListKonpo/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }
        #endregion

        #region Update Data
        public List<DISA150001_ListKonpo_Master> Update_Data(string ID, string item_code, string jenis_packing, string qty_pcs, string factory_size, string indirect, string berat, string panjang, string lebar, string tinggi, string harga, string username)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_ListKonpo_Master>("DISA150001/DISA150001_Update", new
            {
                ID,
                item_code,
                jenis_packing,
                qty_pcs,
                factory_size,
                indirect,
                berat,
                panjang,
                lebar,
                tinggi,
                harga,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

    }

    public class DeleteModel_ListKonpo
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END MASTER LIST KONPO
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //START MASTER LIST TRANSPORTATION
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region MASTER Transportation
    public class DISA150001_Transport_Repository
    {
        #region Get Pilih Transportation Code
        public List<DISA150001_Transport_Master> getCodeTrans()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_GetListCodeTrans");

            db.Close();
            return d.ToList();
        }
        #endregion    

        #region Get_Data_Grid_DISA150001
        public List<DISA150001_Transport_Master> getDataDISA150001(int Start, int Display, string ITEM_CODE, string JENIS_TRANSPORTATION)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_SearchData", new
            {
                START = Start,
                DISPLAY = Display,
                ITEM_CODE,
                JENIS_TRANSPORTATION
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Count_Get_Data_Grid_DISA150001
        public int getCountDISA150001(string DATA_ID, string ITEM_CODE, string JENIS_TRANSPORTATION)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            int result = db.SingleOrDefault<int>("DISA150001/Transport/DISA150001_SearchCount", new
            {
                DATA_ID = DATA_ID,
                ITEM_CODE,
                JENIS_TRANSPORTATION
            });
            db.Close();
            return result;
        }
        #endregion

        #region Add Data
        public static List<DISA150001_Transport_Master> Create(
            string item_code,
            string lot_size,
            string master_qty,
            string box_qty,
            string weight,
            string total_weight,
            string jenis_transportation,
            string transportation_cost,
            string awb_free_jpn,
            string edi_free_air_jpn,
            string ams_free_jpn,
            string trucking_0_250_kg_jpn,
            string handling_air_under_50_kg_jpn,
            string handling_air_upto_50_kg,
            string total_cost,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_Create", new
            {
                item_code,
                lot_size,
                master_qty,
                box_qty,
                weight,
                total_weight,
                jenis_transportation,
                transportation_cost,
                awb_free_jpn,
                edi_free_air_jpn,
                ams_free_jpn,
                trucking_0_250_kg_jpn,
                handling_air_under_50_kg_jpn,
                handling_air_upto_50_kg,
                total_cost,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Delete Data
        public string Delete_Data_Transport(string ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.SingleOrDefault<string>("DISA150001/Transport/DISA150001_Delete", new
            {
                ID
            });
            db.Close();
            return d;
        }

        #endregion

        #region Update Data
        public List<DISA150001_Transport_Master> Update_Data(
            string ID,
            string item_code,
            string lot_size,
            string master_qty,
            string box_qty,
            string weight,
            string total_weight,
            string jenis_transportation,
            string transportation_cost,
            string awb_free_jpn,
            string edi_free_air_jpn,
            string ams_free_jpn,
            string trucking_0_250_kg_jpn,
            string handling_air_under_50_kg_jpn,
            string handling_air_upto_50_kg,
            string total_cost,
            string username
            )
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<DISA150001_Transport_Master>("DISA150001/Transport/DISA150001_Update", new
            {
                ID,
                item_code,
                lot_size,
                master_qty,
                box_qty,
                weight,
                total_weight,
                jenis_transportation,
                transportation_cost,
                awb_free_jpn,
                edi_free_air_jpn,
                ams_free_jpn,
                trucking_0_250_kg_jpn,
                handling_air_under_50_kg_jpn,
                handling_air_upto_50_kg,
                total_cost,
                username
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        
    }

    public class DeleteModel_Transportation
    {
        public string DELETE_NAME { get; set; }
        public string DELETE_MSG { get; set; }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //END START MASTER LIST TRANSPORTATION
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    public class PagingModel_DISA150001
    {
        public int CountData { get; set; }
        public int StartData { get; set; }
        public int EndData { get; set; }
        public int PositionPage { get; set; }
        public List<int> ListIndex { get; set; }
        public PagingModel_DISA150001(int countdata, int positionpage, int dataperpage)
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