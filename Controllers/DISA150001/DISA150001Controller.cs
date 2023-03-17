using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.DISA150001Master;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using NPOI.OpenXmlFormats.Drawing;
using NPOI.OpenXmlFormats.Spreadsheet;
using OfficeOpenXml.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
//using AI070.Util;

namespace AI070.Controllers
{
    public class DISA150001Controller : PageController
    {
        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        DISA150001Repository R = new DISA150001Repository();
        DISA150001_ConvTable_Repository R_ConvTable = new DISA150001_ConvTable_Repository();
        DISA150001_TypeCust_Repository R_TypeCust = new DISA150001_TypeCust_Repository();
        DISA150001_Chinritsu_Repository R_Chinritsu = new DISA150001_Chinritsu_Repository();
        DISA150001_Chokoritsu_Repository R_Chokoritsu = new DISA150001_Chokoritsu_Repository();
        DISA150001_ListKonpo_Repository R_ListKonpo = new DISA150001_ListKonpo_Repository();
        DISA150001_Transport_Repository R_Transport = new DISA150001_Transport_Repository();
        DISA150001_UnitPrice_Repository R_UnitPrice = new DISA150001_UnitPrice_Repository();
        User U = new User();
        string username;

        string sts = null;
        string message = null;

        //Variable ProdCost
        int INDEX_PART;
        string DMC_CODE_PARTS;
        string DMC_CODE;

        double LABOUR_CHARGE_PRINTING;
        double LABOUR_CHARGE_ASSEMBLY;
        double LABOUR_CHARGE_ETCHING;
        double LABOUR_CHARGE_PRESS;
        double LABOUR_CHARGE_NON_PRINTING;  
        double LABOUR_CHARGE_KOMPO;

        double LOT_SIZE_AFTER_HA;
        double PROD_YIELD_AFTER_HA;

        System.Data.DataTable NodeItems = new DataTable();

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Summary Cost";
                ViewData["Title"] = Settings.Title;
                ViewData["dmc_type"] = R.getDmcType();                
                //GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {
                username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
                ViewData["UserInfo"] = UserInfoRepository.Instance.GetUserInfo(username);
                ViewData["Code_Trans"] = R_Transport.getCodeTrans();
            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START PRODUCTION COST
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region PRODUCTION COST

        #region Search Data Production Cost
        public ActionResult Search_Data(int start, int display, string DATA_ID, string DMC_TYPE, string CUSTOMER, string TOUCH_PANEL_TYPE, string RANK)
        {
            //Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R.getCountDISA150001(DATA_ID, DMC_TYPE, CUSTOMER, TOUCH_PANEL_TYPE, RANK), start, display);

            //Munculin Data ke Grid//
            List<DISA150001Detail> List = R.getDataDISA150001(pg.StartData, pg.EndData, DMC_TYPE, CUSTOMER, TOUCH_PANEL_TYPE, RANK).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("ProdCost/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Detail Data
        public virtual ActionResult GetDataDetail(string ID)
        {
            List<DISA150001Detail> GetData_Detail = R.GetData_Detail_ByID(ID).ToList();
            ViewData["Title"] = "Detail Sales Price Calculation";
            if (GetData_Detail.Count == 0)
            {
                ViewData["Dmc_Type"] = "";
                ViewData["DataDetail"] = GetData_Detail;
            }
            else
            {
                ViewData["dmc_type"] = GetData_Detail.FirstOrDefault().DMC_TYPE.ToString();
                ViewData["customer"] = GetData_Detail.FirstOrDefault().CUSTOMER.ToString();
                ViewData["touch_panel_type"] = GetData_Detail.FirstOrDefault().TOUCH_PANEL_TYPE.ToString();
                ViewData["rank"] = GetData_Detail.FirstOrDefault().RANK.ToString();
                ViewData["touch_panel_dimension"] = GetData_Detail.FirstOrDefault().TOUCH_PANEL_DIMENSION.ToString();
                ViewData["touch_panel_size"] = GetData_Detail.FirstOrDefault().TOUCH_PANEL_SIZE.ToString();
                ViewData["versi_wis"] = GetData_Detail.FirstOrDefault().VERSI_WIS.ToString();
                ViewData["lot_size"] = GetData_Detail.FirstOrDefault().LOT_SIZE.ToString();
                ViewData["indirect"] = GetData_Detail.FirstOrDefault().INDIRECT.ToString();
                ViewData["sga"] = GetData_Detail.FirstOrDefault().SGA.ToString();
                ViewData["cavity_film"] = GetData_Detail.FirstOrDefault().CAVITY_FILM.ToString();
                ViewData["cavity_glass"] = GetData_Detail.FirstOrDefault().CAVITY_GLASS.ToString();
                ViewData["cavity_tail"] = GetData_Detail.FirstOrDefault().CAVITY_TAIL.ToString();
                ViewData["yield_printing_film"] = GetData_Detail.FirstOrDefault().YIELD_PRINTING_FILM.ToString();
                ViewData["yield_printing_glass"] = GetData_Detail.FirstOrDefault().YIELD_PRINTING_GLASS.ToString();
                ViewData["yield_printing_tail"] = GetData_Detail.FirstOrDefault().YIELD_PRINTING_TAIL.ToString();
                ViewData["yield_film_midle_inspection"] = GetData_Detail.FirstOrDefault().YIELD_FILM_MIDLE_INSPECTION.ToString();
                ViewData["yield_glass_midle_inspection"] = GetData_Detail.FirstOrDefault().YIELD_GLASS_MIDLE_INSPECTION.ToString();
                ViewData["yield_tail_electrical"] = GetData_Detail.FirstOrDefault().YIELD_TAIL_ELECTRICAL.ToString();
                ViewData["yield_tail_cosmetic"] = GetData_Detail.FirstOrDefault().YIELD_TAIL_COSMETIC.ToString();
                ViewData["yield_assembly"] = GetData_Detail.FirstOrDefault().YIELD_ASSEMBLY.ToString();
                ViewData["yield_final_assembly"] = GetData_Detail.FirstOrDefault().YIELD_FINAL_ASSEMBLY.ToString();
                ViewData["yield_electrical_inspection"] = GetData_Detail.FirstOrDefault().YIELD_ELECTRICAL_INSPECTION.ToString();
                ViewData["yield_final_inspection"] = GetData_Detail.FirstOrDefault().YIELD_FINAL_INSPECTION.ToString();
                ViewData["yield_total_film"] = GetData_Detail.FirstOrDefault().YIELD_TOTAL_FILM.ToString();
                ViewData["yield_total_glass"] = GetData_Detail.FirstOrDefault().YIELD_TOTAL_GLASS.ToString();
                ViewData["yield_total_tail"] = GetData_Detail.FirstOrDefault().YIELD_TOTAL_TAIL.ToString();
                ViewData["lot_size_film"] = GetData_Detail.FirstOrDefault().LOT_SIZE_FILM.ToString();
                ViewData["max_lot_size_film"] = GetData_Detail.FirstOrDefault().MAX_LOT_SIZE_FILM.ToString();
                ViewData["lot_size_glass"] = GetData_Detail.FirstOrDefault().LOT_SIZE_GLASS.ToString();
                ViewData["max_lot_size_glass"] = GetData_Detail.FirstOrDefault().MAX_LOT_SIZE_GLASS.ToString();
                ViewData["lot_size_tail"] = GetData_Detail.FirstOrDefault().LOT_SIZE_TAIL.ToString();
                ViewData["max_lot_size_tail"] = GetData_Detail.FirstOrDefault().MAX_LOT_SIZE_TAIL.ToString();
                ViewData["labour_charge_printing"] = GetData_Detail.FirstOrDefault().LABOUR_CHARGE_PRINTING.ToString();
                ViewData["labour_charge_assembly"] = GetData_Detail.FirstOrDefault().LABOUR_CHARGE_ASSEMBLY.ToString();
                ViewData["labour_charge_etching"] = GetData_Detail.FirstOrDefault().LABOUR_CHARGE_ETCHING.ToString();
                ViewData["labour_charge_press"] = GetData_Detail.FirstOrDefault().LABOUR_CHARGE_PRESS.ToString();
                ViewData["labour_charge_non_printing"] = GetData_Detail.FirstOrDefault().LABOUR_CHARGE_NON_PRINTING.ToString();
                ViewData["labour_charge_kompo"] = GetData_Detail.FirstOrDefault().LABOUR_CHARGE_KOMPO.ToString();

            }

            List<DISA150001MaterialCost> Material_Cost = R.getDataDISA150001_Material(ID).ToList();
            ViewData["DataMaterial"] = Material_Cost;

            List<DISA150001MaterialCostUsage> Material_Cost_Usage = R.getDataDISA150001_MaterialUsage(ID).ToList();
            ViewData["DataMaterialUsage"] = Material_Cost_Usage;

            List<DISA150001Detail> Sales_Price = R.getDataDISA150001_SalesPrice(ID).ToList();
            ViewData["SalesPrice"] = Sales_Price;

            return PartialView("ProdCost/Datagrid_Data_Detail");

        }
        #endregion

        #region Kalkulasi    
        public JsonResult LongRunningProcess(string DMC_TYPE)
        {
            List<DISA150001Detail> GetCodeCalc = R.getDmcCodeCalc(DMC_TYPE).ToList();
            int itemsCount = GetCodeCalc.Count();
            //THIS COULD BE SOME LIST OF DATA
            //int itemsCount = 10;

            for (int i = 0; i < itemsCount; i++)
            {
                //SIMULATING SOME TASK
                System.Threading.Thread.Sleep(500);

                Calculate_Data(DMC_TYPE);
                //CALLING A FUNCTION THAT CALCULATES PERCENTAGE AND SENDS THE DATA TO THE CLIENT
                //Functions.SendProgress("Process in progress...", i, itemsCount);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Calculate_Data(string DMC_TYPE)
        {            
            List<DISA150001Detail> GetCodeCalc = R.getDmcCodeCalc(DMC_TYPE).ToList();            

            foreach (DISA150001Detail CodeCalc in GetCodeCalc)
            {
                NodeItems = GetALLNodes();

                List<DISA150001Detail> DataDetail = R.getDataDetailDISA150001(CodeCalc.DMC_TYPE).ToList();

                ViewData["GetCalculate"] = DataDetail;

                if (DataDetail != null)
                {
                    if (DataDetail.Count > 0)
                    {
                        foreach (DISA150001Detail item in DataDetail)
                        {
                            //KALKULASI MATERIAL COST                       
                            Array.Clear(FGS, 1, 400);
                            INDEX_PART = 0;
                            DMC_CODE_PARTS = "";
                            DMC_CODE = item.DMC_TYPE;

                            BuildChildNodes(DMC_CODE, DMC_CODE);
                            MaterialCost(DMC_CODE);
                            // END MATERIAL COST

                            //HITUNG JUMLAH CHOKORITSU 
                            double YIELD_PRINTING_FILM = (item.YIELD_PRINTING_FILM == 0 ? 1 : item.YIELD_PRINTING_FILM);
                            double YIELD_PRINTING_GLASS = (item.YIELD_PRINTING_GLASS == 0 ? 1 : item.YIELD_PRINTING_GLASS);
                            double YIELD_PRINTING_TAIL = (item.YIELD_PRINTING_TAIL == 0 ? 1 : item.YIELD_PRINTING_TAIL);
                            double YIELD_FILM_MIDLE_INSPECTION = (item.YIELD_FILM_MIDLE_INSPECTION == 0 ? 1 : item.YIELD_FILM_MIDLE_INSPECTION);
                            double YIELD_GLASS_MIDLE_INSPECTION = (item.YIELD_GLASS_MIDLE_INSPECTION == 0 ? 1 : item.YIELD_GLASS_MIDLE_INSPECTION);
                            double YIELD_TAIL_ELECTRICAL = (item.YIELD_TAIL_ELECTRICAL == 0 ? 1 : item.YIELD_TAIL_ELECTRICAL);
                            double YIELD_TAIL_COSMETIC = (item.YIELD_TAIL_COSMETIC == 0 ? 1 : item.YIELD_TAIL_COSMETIC);
                            double YIELD_ASSEMBLY = (item.YIELD_ASSEMBLY == 0 ? 1 : item.YIELD_ASSEMBLY);
                            double YIELD_FINAL_ASSEMBLY = (item.YIELD_FINAL_ASSEMBLY == 0 ? 1 : item.YIELD_FINAL_ASSEMBLY);
                            double YIELD_ELECTRICAL_INSPECTION = (item.YIELD_ELECTRICAL_INSPECTION == 0 ? 1 : item.YIELD_ELECTRICAL_INSPECTION);
                            double YIELD_FINAL_INSPECTION = (item.YIELD_FINAL_INSPECTION == 0 ? 1 : item.YIELD_FINAL_INSPECTION);

                            double TOTAL_YIELD_FILM = Math.Round(YIELD_PRINTING_FILM * YIELD_FILM_MIDLE_INSPECTION * YIELD_ASSEMBLY * YIELD_FINAL_ASSEMBLY * YIELD_ELECTRICAL_INSPECTION * YIELD_FINAL_INSPECTION,2);
                            double TOTAL_YIELD_GLASS = Math.Round(YIELD_PRINTING_GLASS * YIELD_GLASS_MIDLE_INSPECTION * YIELD_ASSEMBLY * YIELD_FINAL_ASSEMBLY * YIELD_ELECTRICAL_INSPECTION * YIELD_FINAL_INSPECTION,2);
                            double TOTAL_YIELD_TAIL = Math.Round(YIELD_PRINTING_TAIL * YIELD_TAIL_ELECTRICAL * YIELD_TAIL_COSMETIC * YIELD_ASSEMBLY * YIELD_FINAL_ASSEMBLY * YIELD_ELECTRICAL_INSPECTION * YIELD_FINAL_INSPECTION,2);
                            //END HITUNG JUMLAH CHOKORITSU

                            //HITUNG LOT SIZE
                            double ORIGINAL_LOT_SIZE = item.LOT_SIZE;
                            double FILM_LOT_SIZE = Math.Ceiling(item.LOT_SIZE / item.CAVITY_FILM / TOTAL_YIELD_FILM); //ROUND UP
                            double GLASS_LOT_SIZE = Math.Ceiling(item.LOT_SIZE / item.CAVITY_GLASS / TOTAL_YIELD_GLASS); //ROUND UP
                            double TAIL_LOT_SIZE = Math.Ceiling(item.LOT_SIZE / item.CAVITY_TAIL / TOTAL_YIELD_TAIL); //ROUND UP


                            if (TAIL_LOT_SIZE == 0)
                            {
                                TAIL_LOT_SIZE = 1;
                            }

                            double MAX_LOT_SIZE_FILM = 392;
                            double MAX_LOT_SIZE_GLASS = 480;
                            double MAX_LOT_SIZE_TAIL = 200;
                            //END HITUNG LOT SIZE

                            //CARI MATERIAL USAGE COST & LABOR COST PER PROSES
                            MaterialUsage(
                                DMC_CODE,
                                item.CAVITY_FILM,
                                item.CAVITY_GLASS,
                                item.CAVITY_TAIL,
                                ORIGINAL_LOT_SIZE,
                                FILM_LOT_SIZE,
                                GLASS_LOT_SIZE,
                                TAIL_LOT_SIZE,
                                MAX_LOT_SIZE_FILM,
                                MAX_LOT_SIZE_GLASS,
                                MAX_LOT_SIZE_TAIL,
                                YIELD_PRINTING_FILM,
                                YIELD_PRINTING_GLASS,
                                YIELD_PRINTING_TAIL,
                                YIELD_FILM_MIDLE_INSPECTION,
                                YIELD_GLASS_MIDLE_INSPECTION,
                                YIELD_TAIL_ELECTRICAL,
                                YIELD_TAIL_COSMETIC,
                                YIELD_ASSEMBLY,
                                YIELD_ELECTRICAL_INSPECTION,
                                YIELD_FINAL_ASSEMBLY,
                                YIELD_FINAL_INSPECTION,
                                TOTAL_YIELD_FILM
                             );
                            //END MATERIAL USAGE COST & LABOR COST PER PROSES

                            //MENENTUKAN NILAI LABOR CHARGE 
                            LabourCharge();
                            //END MENENTUKAN NILAI LABOR CHARGE

                            //KALKULASI TRANSPORTATION COST
                            TransportationCost(DMC_CODE);
                            //END KALKULASI TRANSPORTATION COST

                            //HITUNG SALES PRICE AIR CIF & SALES PRICE FOB
                            TouchPanelSalesPrice(
                                DMC_CODE,
                                item.CUSTOMER,
                                item.TOUCH_PANEL_TYPE,
                                item.TOUCH_PANEL_SIZE,
                                item.VERSI_WIS,
                                TOTAL_YIELD_FILM,
                                ORIGINAL_LOT_SIZE,
                                YIELD_PRINTING_FILM,
                                YIELD_PRINTING_GLASS,
                                YIELD_PRINTING_TAIL,
                                YIELD_TAIL_ELECTRICAL,
                                YIELD_TAIL_COSMETIC,
                                YIELD_ASSEMBLY,
                                YIELD_ELECTRICAL_INSPECTION,
                                YIELD_FINAL_ASSEMBLY,
                                YIELD_FINAL_INSPECTION,
                                YIELD_FILM_MIDLE_INSPECTION,
                                YIELD_GLASS_MIDLE_INSPECTION,
                                item.INDIRECT,
                                item.SGA);
                            //END HITUNG SALES PRICE AIR CIF & SALES PRICE FOB

                            try
                            {
                                var Exec = DISA150001Repository.InsertCalculate(
                                    item.DMC_TYPE,
                                    item.CUSTOMER,
                                    item.TOUCH_PANEL_TYPE,
                                    item.RANK,
                                    item.TOUCH_PANEL_DIMENSION,
                                    item.TOUCH_PANEL_SIZE,
                                    item.VERSI_WIS,
                                    item.LOT_SIZE,
                                    item.INDIRECT,
                                    item.SGA,
                                    item.CAVITY_FILM,
                                    item.CAVITY_GLASS,
                                    item.CAVITY_TAIL,
                                    item.YIELD_PRINTING_FILM,
                                    item.YIELD_PRINTING_GLASS,
                                    item.YIELD_PRINTING_TAIL,
                                    item.YIELD_FILM_MIDLE_INSPECTION,
                                    item.YIELD_GLASS_MIDLE_INSPECTION,
                                    item.YIELD_TAIL_ELECTRICAL,
                                    item.YIELD_TAIL_COSMETIC,
                                    item.YIELD_ASSEMBLY,
                                    item.YIELD_FINAL_ASSEMBLY,
                                    item.YIELD_ELECTRICAL_INSPECTION,
                                    item.YIELD_FINAL_INSPECTION,
                                    TOTAL_YIELD_FILM,
                                    TOTAL_YIELD_GLASS,
                                    TOTAL_YIELD_TAIL,
                                    FILM_LOT_SIZE,
                                    MAX_LOT_SIZE_FILM,
                                    GLASS_LOT_SIZE,
                                    MAX_LOT_SIZE_GLASS,
                                    TAIL_LOT_SIZE,
                                    MAX_LOT_SIZE_TAIL,
                                    LABOUR_CHARGE_PRINTING,
                                    LABOUR_CHARGE_ASSEMBLY,
                                    LABOUR_CHARGE_ETCHING,
                                    LABOUR_CHARGE_PRESS,
                                    LABOUR_CHARGE_NON_PRINTING,
                                    LABOUR_CHARGE_KOMPO
                                    );
                                sts = Exec[0].STACK;

                                if (Exec[0].LINE_STS == "DUPLICATE")
                                {
                                    DISA150001Repository.UpdateCalculate(
                                    item.DMC_TYPE,
                                    item.CUSTOMER,
                                    item.TOUCH_PANEL_TYPE,
                                    item.RANK,
                                    item.TOUCH_PANEL_DIMENSION,
                                    item.TOUCH_PANEL_SIZE,
                                    item.VERSI_WIS,
                                    item.LOT_SIZE,
                                    item.INDIRECT,
                                    item.SGA,
                                    item.CAVITY_FILM,
                                    item.CAVITY_GLASS,
                                    item.CAVITY_TAIL,
                                    item.YIELD_PRINTING_FILM,
                                    item.YIELD_PRINTING_GLASS,
                                    item.YIELD_PRINTING_TAIL,
                                    item.YIELD_FILM_MIDLE_INSPECTION,
                                    item.YIELD_GLASS_MIDLE_INSPECTION,
                                    item.YIELD_TAIL_ELECTRICAL,
                                    item.YIELD_TAIL_COSMETIC,
                                    item.YIELD_ASSEMBLY,
                                    item.YIELD_FINAL_ASSEMBLY,
                                    item.YIELD_ELECTRICAL_INSPECTION,
                                    item.YIELD_FINAL_INSPECTION,
                                    TOTAL_YIELD_FILM,
                                    TOTAL_YIELD_GLASS,
                                    TOTAL_YIELD_TAIL,
                                    FILM_LOT_SIZE,
                                    MAX_LOT_SIZE_FILM,
                                    GLASS_LOT_SIZE,
                                    MAX_LOT_SIZE_GLASS,
                                    TAIL_LOT_SIZE,
                                    MAX_LOT_SIZE_TAIL,
                                    LABOUR_CHARGE_PRINTING,
                                    LABOUR_CHARGE_ASSEMBLY,
                                    LABOUR_CHARGE_ETCHING,
                                    LABOUR_CHARGE_PRESS,
                                    LABOUR_CHARGE_NON_PRINTING,
                                    LABOUR_CHARGE_KOMPO
                                    );

                                }
                                else if (Exec[0].STACK == "TRUE")
                                {
                                    var res = M.get_default_message("MWP001", "Insert Calculate", "", "");
                                    message = res[0].MSG_TEXT;
                                }
                                else
                                {
                                    message = Exec[0].LINE_STS;
                                }
                            }
                            catch (Exception M)
                            {
                                sts = "false";
                                message = M.Message.ToString();
                            }

                        }
                    }
                }
            }
            return PartialView("ProdCost/Datagrid_Data");
        }
        #endregion

        #region Kalkulasi Transportation Cost
        private void TransportationCost(string DMC_CODE)
        {
            try
            {
                List<DISA150001_Transport_Master> GetTranspCost = R.getCalcTranspCostDISA150001(DMC_CODE).ToList();

                if (GetTranspCost != null)
                {
                    if (GetTranspCost.Count > 0)
                    {
                        foreach (DISA150001_Transport_Master TranspCost in GetTranspCost)
                        {
                            try
                            {
                                var Exec = DISA150001Repository.InsertSumCalcTransportation(
                                    DMC_CODE,
                                    TranspCost.code_trans,
                                    TranspCost.lot_size,
                                    TranspCost.master_type,
                                    TranspCost.master_qty,
                                    TranspCost.qty_box,
                                    TranspCost.master_weight,
                                    TranspCost.total_cost
                                    );
                                sts = Exec[0].STACK;

                                if (Exec[0].LINE_STS == "DUPLICATE")
                                {
                                    DISA150001Repository.UpdateSumCalcTransportation(
                                    DMC_CODE,
                                    TranspCost.code_trans,
                                    TranspCost.lot_size,
                                    TranspCost.master_type,
                                    TranspCost.master_qty,
                                    TranspCost.qty_box,
                                    TranspCost.master_weight,
                                    TranspCost.total_cost
                                    );
                                }
                                else if (Exec[0].STACK == "TRUE")
                                {
                                    var res = M.get_default_message("MWP001", "Insert Calculate Transportation", "", "");
                                    message = res[0].MSG_TEXT;
                                }
                                else
                                {
                                    message = Exec[0].LINE_STS;
                                }
                            }
                            catch (Exception M)
                            {
                                sts = "false";
                                message = M.Message.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
        }
        #endregion

        #region Membentuk Struktur BOM
        struct FGS1
        {
            public string parent;
            public string parts;
            public int long_size;
            public int cut_size;
            public int material_size;
            public int wide_size;
            public int qty;
            public bool main_material;
            public int priority;
            public bool parts_acs;
        }
        private FGS1[] FGS = new FGS1[401];

        private bool IsNumeric(string child_code)
        {
            int number;
            return int.TryParse(child_code, out number);
        }

        private System.Data.DataTable GetALLNodes()
        {
            DataTable allItems = new DataTable();
            allItems.Columns.Add("CODE", typeof(String));
            allItems.Columns.Add("KCODE", typeof(String));
            allItems.Columns.Add("WIDE_SIZE", typeof(Int32));
            allItems.Columns.Add("LONG_SIZE", typeof(Int32));
            allItems.Columns.Add("MATERIAL_SIZE", typeof(Int32));
            allItems.Columns.Add("CUT_SIZE", typeof(Int32));
            allItems.Columns.Add("QTY", typeof(Int32));
            allItems.Columns.Add("EDATE", typeof(String));
            allItems.Columns.Add("SDATE", typeof(String));

            List<DISA150001GetAllNodes> getAllNodes = R.getAllNodesDISA150001().ToList();
            //ViewData["GetAllNodes"] = getAllNodes;

            foreach (DISA150001GetAllNodes allNodes in getAllNodes)
            {
                DataRow dtRow = allItems.NewRow();

                dtRow["CODE"] = allNodes.CODE;
                dtRow["KCODE"] = allNodes.KCODE;
                dtRow["WIDE_SIZE"] = allNodes.WIDE_SIZE;
                dtRow["LONG_SIZE"] = allNodes.LONG_SIZE;
                dtRow["MATERIAL_SIZE"] = allNodes.MATERIAL_SIZE;
                dtRow["CUT_SIZE"] = allNodes.CUT_SIZE;
                dtRow["QTY"] = allNodes.QTY;
                dtRow["EDATE"] = allNodes.EDATE;
                dtRow["SDATE"] = allNodes.SDATE;

                allItems.Rows.Add(dtRow);
            }

            return allItems;
        }

        private void BuildChildNodes(string strFGS, string Parent)
        {
            DataView ChildView = NodeItems.DefaultView;
            string child_code;
            int long_size;
            int cut_size;
            int wide_size;
            int material_size;
            int qty;
            int Priority = 0;
            ChildView.RowStateFilter = DataViewRowState.CurrentRows;
            ChildView.RowFilter = "CODE = '" + Parent + "'";
            DataTable temp = ChildView.ToTable();
            DataTableReader rdr = temp.CreateDataReader();
            while (rdr.Read())
            {
                child_code = rdr["KCODE"].ToString();
                wide_size = (int)rdr["WIDE_SIZE"];
                long_size = (int)rdr["LONG_SIZE"];
                material_size = (int)rdr["MATERIAL_SIZE"];
                cut_size = (int)rdr["CUT_SIZE"];
                qty = (int)rdr["QTY"];

                //if (child_code.Contains("ACS/HGO-JT") == true)
                //{
                //    child_code = child_code;
                //}

                if (IsNumeric(child_code)
                    || child_code.Substring(child_code.Length - 7) == "-FGT-GK"
                    || child_code.Substring(child_code.Length - 3) == "-FG"
                    || child_code.Substring(child_code.Length - 2) == "-F"
                    || child_code.Substring(child_code.Length - 2) == "-G"
                    || child_code.Substring(child_code.Length - 2) == "-T"
                    || child_code.Substring(child_code.Length - 3) == "-PC")
                {
                    INDEX_PART += 1;
                    FGS[INDEX_PART].parent = Parent;
                    FGS[INDEX_PART].parts = child_code;
                    FGS[INDEX_PART].wide_size = wide_size;
                    FGS[INDEX_PART].long_size = long_size;
                    FGS[INDEX_PART].material_size = material_size;
                    FGS[INDEX_PART].cut_size = cut_size;
                    FGS[INDEX_PART].qty = qty;
                    FGS[INDEX_PART].main_material = true;
                    if (rdr["EDATE"].ToString() == "999999999" || rdr["EDATE"].ToString() == "999999991" || rdr["EDATE"].ToString() == "")
                    {
                        FGS[INDEX_PART].priority = 0;
                    }                    
                    else
                    {
                        Priority += 1;
                        FGS[INDEX_PART].priority = Priority;
                    }
                }
                //MATERIAL ACCECORIS
                else if (child_code.Contains("ACS/HGO-JT") == true)
                {
                    INDEX_PART += 1;
                    FGS[INDEX_PART].parent = Parent;
                    FGS[INDEX_PART].parts = child_code;
                    FGS[INDEX_PART].wide_size = wide_size;
                    FGS[INDEX_PART].long_size = long_size;
                    FGS[INDEX_PART].material_size = material_size;
                    FGS[INDEX_PART].cut_size = cut_size;
                    FGS[INDEX_PART].qty = qty;
                    FGS[INDEX_PART].main_material = true;
                    if (rdr["EDATE"].ToString() == "999999999" || rdr["EDATE"].ToString() == "999999991" || rdr["EDATE"].ToString() == "")
                    {
                        FGS[INDEX_PART].priority = 0;
                        FGS[INDEX_PART].parts_acs = true;
                    }
                    else
                    {
                        Priority += 1;
                        FGS[INDEX_PART].priority = Priority;                        
                    }
                }
                string childID = rdr[1].ToString();
                BuildChildNodes(strFGS, childID);
            }
            rdr.Close();
        }
        #endregion

        #region Material Cost
        private void MaterialCost(string DMC_CODE)
        {
            string MaterialCode = "";
            bool MainMaterial;
            int Priority;
            string MaterialName = "";
            double UnitPrice = 0;
            string Unit = "";
            double Long_Size = 0;
            double Cut_Size = 0;
            int Cavity = 0;
            string Part = "";
            double MatSize = 0;
            double WideSize = 0;
            int Qty = 0;
            double PricePerSheet = 0;
            double PricePerPcs;

            int x = 1;

            while (!(FGS[x].parts == null))
            {
                string PARENT = FGS[x].parent;
                string PART = FGS[x].parts;

                if (PARENT == DMC_CODE)
                {
                    if ((PART.Substring(PART.Length - 7) == "-FGT-GK"))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parts;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "A";
                    }

                    if (((FGS[x].parts).Substring(0, 3) == "236" || (FGS[x].parts).Substring(0, 3) == "212" || (FGS[x].parts).Substring(0, 3) == "222") && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parent;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "P";
                    }
                }

                if (PARENT.Contains("-FGT") == true)
                {
                    if ((PART.Substring(PART.Length - 3) == "-FG"))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parts;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "A";
                    }
                    else if ((PART.Substring(PART.Length - 2) == "-T"))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parts;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "T";
                    }
                    else if ((FGS[x].main_material == true && (FGS[x].priority == 0)))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parent;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "A";
                    }
                }

                if ((PART.Substring(PART.Length - 3) == "-PC"))
                {
                    //int no = +1;
                    DMC_CODE_PARTS = FGS[x].parts;
                    MaterialCode = FGS[x].parts;
                    MainMaterial = FGS[x].main_material;
                    Priority = FGS[x].priority;
                    WideSize = FGS[x].wide_size;
                    Long_Size = FGS[x].long_size;
                    MatSize = FGS[x].material_size;
                    Cut_Size = FGS[x].cut_size;
                    Qty = FGS[x].qty;
                    Part = "T";
                }

                if (PARENT.Substring(PARENT.Length - 3) == "-FG")
                {
                    if ((PART.Substring(PART.Length - 2) == "-F"))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parts;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "F";
                    }
                    else if ((PART.Substring(PART.Length - 2) == "-G"))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parts;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "G";
                    }
                }

                if (PARENT.Substring(PARENT.Length - 4) == "-F-S")
                {
                    if (((FGS[x].parts).Substring(0, 3) == "110") && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parent;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "F";
                    }
                }

                if (PARENT.Substring(PARENT.Length - 4) == "-G-S")
                {
                    if ((((FGS[x].parts).Substring(0, 3) == "110") || ((FGS[x].parts).Substring(0, 3) == "210")) && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parent;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "G";
                    }
                }

                if (PARENT.Contains("-T-S") == true)
                {
                    if (((FGS[x].parts).Substring(0, 4) == "1107" || (FGS[x].parts).Substring(0, 4) == "1109") && (FGS[x].main_material == true && (FGS[x].priority == 0)) && FGS[x].parts_acs != true)
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parent;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "T";
                    }
                }

                if (PARENT.Contains("-B-PARTS") == true)
                {
                    if ((PART.Contains("ACS/HGO-JT") == true) && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                    {
                        //int no = +1;
                        DMC_CODE_PARTS = FGS[x].parent;
                        MaterialCode = FGS[x].parts;
                        MainMaterial = FGS[x].main_material;
                        Priority = FGS[x].priority;
                        WideSize = FGS[x].wide_size;
                        Long_Size = FGS[x].long_size;
                        MatSize = FGS[x].material_size;
                        Cut_Size = FGS[x].cut_size;
                        Qty = FGS[x].qty;
                        Part = "T";
                    }
                }

                #region GET (Nama Material, Satuan)
                List<DISA150001MaterialCost> GetMaterialDetail = R.getDetailMaterialDISA150001(MaterialCode).ToList();
                if (GetMaterialDetail.Count > 0)
                {
                    foreach (DISA150001MaterialCost M in GetMaterialDetail)
                    {
                        MaterialName = M.MATERIAL_NAME;
                        Unit = M.UNIT;
                    }
                }
                else
                {
                    MaterialName = "-";
                    Unit = "-";
                }
                #endregion

                #region GET (Harga)
                List<DISA150001MaterialCost> GetMaterialCost = R.getCostMaterialDISA150001(MaterialCode).ToList();
                if (GetMaterialDetail.Count > 0)
                {
                    foreach (DISA150001MaterialCost MC in GetMaterialCost)
                    {
                        UnitPrice = MC.UNIT_PRICE;
                    }
                }
                else
                {
                    UnitPrice = 0;
                }
                #endregion

                #region GET Cavity BOM KCODE

                if ((Part.Contains("P") == true) || (Part.Contains("A") == true))
                {
                    List<DISA150001MaterialCost> GetCavityPackingAssembly = R.getCavityPackingAssyDISA150001(DMC_CODE_PARTS, MaterialCode).ToList();
                    if (GetMaterialDetail.Count > 0)
                    {
                        foreach (DISA150001MaterialCost C in GetCavityPackingAssembly)
                        {
                            Cavity = C.CAVITY;
                        }
                    }
                    else
                    {
                        Cavity = 0;
                    }
                }
                else
                {
                    List<DISA150001MaterialCost> GetCavityFGT = R.getCavityFGTDISA150001(DMC_CODE, Part).ToList();
                    if (GetMaterialDetail.Count > 0)
                    {
                        foreach (DISA150001MaterialCost C in GetCavityFGT)
                        {
                            Cavity = C.CAVITY;
                        }
                    }
                    else
                    {
                        Cavity = 0;
                    }
                }
                #endregion

                #region GET Harga Per Sheet
                if ((Part.Contains("G") == true && MaterialCode.Substring(0, 4) == "1103")
                    || (Part.Contains("A") == true && MaterialCode.Substring(0, 4) == "2160")
                    || (Part.Contains("T") == true && (MaterialName.Contains("FPC") == true)))
                //G (Glass) dan ITO GLASS,
                //A (Assy) dan BARCODE 188AET OFA60                
                //T (Tail) hanya ambil Unit Price
                {
                    PricePerSheet = UnitPrice;
                }

                else if (Part.Contains("A") == true && MaterialCode.Substring(0, 4) == "2160")
                //A (Assy) dan BARCODE SEMIGLOWHITE                
                {
                    PricePerSheet = UnitPrice * Qty;
                }

                else if ((Part.Contains("T") == true && (MaterialCode.Substring(0, 4) == "1109" || (MaterialCode.Contains("ACS") == true)))
                    || (Part.Contains("A") == true && (MaterialCode.Substring(0, 4) == "1109")))
                //untuk part T material TL-85-25SP-11LL atau PET250S P1069
                ////untuk part A material TL-85-25SP-11LL     
                {
                    double nilai_1 = (Math.Truncate(WideSize / MatSize)) * (Math.Truncate(Long_Size / Cut_Size));
                    double nilai_2 = (Math.Truncate(WideSize / Cut_Size)) * (Math.Truncate(Long_Size / MatSize));
                    double max_nilai = (Math.Max(nilai_1, nilai_2));

                    PricePerSheet = (UnitPrice / max_nilai) * Qty;
                }
                else
                {
                    PricePerSheet = (UnitPrice / Long_Size) * Cut_Size * Qty;
                }

                if (DMC_CODE_PARTS != "")
                {
                    if (Part.Contains("P") == true
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 3) == "-FG")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 7) == "-FGT-GK")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-F")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-G")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-T")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 3) == "-PC"))
                    {
                        PricePerSheet = 0;
                    }
                }
                #endregion

                #region GET Harga per PCS
                if (Part.Contains("P") == true)
                //untuk part P (Packing) tidak ada harga per sheet
                {
                    PricePerPcs = (UnitPrice * Qty) / Cavity;
                }
                else
                {
                    PricePerPcs = PricePerSheet / Cavity;
                }

                if (DMC_CODE_PARTS != "")
                {
                    if ((DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 3) == "-FG")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 7) == "-FGT-GK")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-F")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-G")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-T")
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 3) == "-PC"))
                    {
                        PricePerPcs = 0;
                    }
                }
                #endregion

                #region GET PricePerSheet atau PricePerPcs (NAN / Kosong)
                if (double.IsNaN(PricePerSheet) || double.IsInfinity(PricePerSheet) ||
                    double.IsNaN(PricePerPcs) || double.IsInfinity(PricePerPcs))
                {
                    PricePerSheet = 0;
                    PricePerPcs = 0;
                }
                #endregion

                #region Input / Update Data
                //MATERIAL COST INPUT & UPDATE
                if (DMC_CODE_PARTS != "")
                {
                    if (((DMC_CODE_PARTS.Contains("-F-S") == true || DMC_CODE_PARTS.Contains("-G-S") == true) && (MaterialCode.Substring(0, 3) == "110" || MaterialCode.Substring(0, 3) == "210") && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                        || (DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 3) == "-FG" || DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-F" || DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-G")
                        || (DMC_CODE_PARTS.Contains("-T-S") == true && (MaterialCode.Substring(0, 4) == "1107" || MaterialCode.Substring(0, 4) == "1109") && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                        || (DMC_CODE_PARTS.Contains("-FGT") == true && (FGS[x].main_material == true && (FGS[x].priority == 0)) || DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 2) == "-T" || DMC_CODE_PARTS.Substring(DMC_CODE_PARTS.Length - 3) == "-PC")
                        || (DMC_CODE_PARTS == DMC_CODE && (MaterialCode.Substring(0, 3) == "236" || MaterialCode.Substring(0, 3) == "212" || (MaterialCode.Substring(0, 3) == "222" && MaterialName.Contains("Air Bubble") != true && MaterialName.Contains("Silica") != true)) && (FGS[x].main_material == true && (FGS[x].priority == 0)))
                        || (DMC_CODE_PARTS.Contains("-PARTS") == true && (FGS[x].main_material == true && (FGS[x].priority == 0)) && MaterialCode.Substring(0, 7) == "ACS/HGO"))
                    {
                        try
                        {
                            var Exec = DISA150001Repository.InsertMaterialCost(
                                DMC_CODE,
                                Part,
                                DMC_CODE_PARTS,
                                MaterialCode,
                                MaterialName,
                                UnitPrice, Unit,
                                WideSize,
                                Long_Size,
                                MatSize,
                                Cut_Size,
                                Cavity,
                                Qty,
                                Math.Round(PricePerSheet,0),
                                Math.Round(PricePerPcs,0));
                            sts = Exec[0].STACK;
                            if (Exec[0].LINE_STS == "DUPLICATE")
                            {
                                DISA150001Repository.UpdateMaterialCost(
                                    DMC_CODE,
                                    Part,
                                    DMC_CODE_PARTS,
                                    MaterialCode,
                                    MaterialName,
                                    UnitPrice,
                                    Unit,
                                    WideSize,
                                    Long_Size,
                                    MatSize,
                                    Cut_Size,
                                    Cavity,
                                    Qty,
                                    Math.Round(PricePerSheet, 0),
                                    Math.Round(PricePerPcs, 0));
                            }
                            else if (Exec[0].STACK == "TRUE")
                            {
                                var res = M.get_default_message("MWP001", "Insert Material Cost", "", "");
                                message = res[0].MSG_TEXT;
                            }
                            else
                            {
                                message = Exec[0].LINE_STS;
                            }
                        }
                        catch (Exception M)
                        {
                            sts = "false";
                            message = M.Message.ToString();
                        }
                    }
                }
                //MATERIAL COST INPUT & UPDATE
                #endregion

                x += 1;
            }
        }
        #endregion 

        #region Material Usage
        private void MaterialUsage(
            string DMC_CODE,
            double CAVITY_FILM,
            double CAVITY_GLASS,
            double CAVITY_TAIL,
            double ORIGINAL_LOT_SIZE,
            double FILM_LOT_SIZE,
            double GLASS_LOT_SIZE,
            double TAIL_LOT_SIZE,
            double MAX_LOT_SIZE_FILM,
            double MAX_LOT_SIZE_GLASS,
            double MAX_LOT_SIZE_TAIL,
            double YIELD_PRINTING_FILM,
            double YIELD_PRINTING_GLASS,
            double YIELD_PRINTING_TAIL,
            double YIELD_FILM_MIDLE_INSPECTION,
            double YIELD_GLASS_MIDLE_INSPECTION,
            double YIELD_TAIL_ELECTRICAL,
            double YIELD_TAIL_COSMETIC,
            double YIELD_ASSEMBLY,
            double YIELD_ELECTRICAL_INSPECTION,
            double YIELD_FINAL_ASSEMBLY,
            double YIELD_FINAL_INSPECTION,
            double TOTAL_YIELD_FILM)
        {
            List<DISA150001MaterialCost> MaterialUsage = R.getMaterialUsageDISA150001(DMC_CODE).ToList();
            foreach (DISA150001MaterialCost MU in MaterialUsage)
            {
                string PART = "";
                double LOT_SIZE = 0;
                double MAX_LOT_SIZE = 0;
                double PROD_YIELD = 0;

                //if (MU.DMC_CODE_PARTS == "TP-4750S1F0-FG")
                //{
                //    MU.DMC_CODE_PARTS = MU.DMC_CODE_PARTS;
                //}

                if (MU.PART == "P")
                {
                    PART = "PACKING";
                    LOT_SIZE = ORIGINAL_LOT_SIZE;
                    PROD_YIELD = 1;
                }
                else if (MU.PART == "A")
                {
                    PART = "ASSEMBLY";
                    LOT_SIZE = ORIGINAL_LOT_SIZE;
                    PROD_YIELD = 1;
                }
                else if (MU.PART == "G")
                {
                    PART = "GLASS";
                    LOT_SIZE = GLASS_LOT_SIZE;
                    MAX_LOT_SIZE = MAX_LOT_SIZE_GLASS;
                    PROD_YIELD = YIELD_PRINTING_FILM;
                }
                else if (MU.PART == "F")
                {
                    PART = "FILM";
                    LOT_SIZE = FILM_LOT_SIZE;
                    MAX_LOT_SIZE = MAX_LOT_SIZE_FILM;
                    PROD_YIELD = YIELD_PRINTING_GLASS;
                }
                else if (MU.PART == "T")
                {
                    PART = "TAIL";
                    LOT_SIZE = TAIL_LOT_SIZE;
                    MAX_LOT_SIZE = MAX_LOT_SIZE_TAIL;
                    PROD_YIELD = YIELD_PRINTING_TAIL;
                }



                MaterialCostUsage(
                    DMC_CODE,
                    MU.DMC_CODE_PARTS,
                    CAVITY_FILM,
                    CAVITY_GLASS,
                    CAVITY_TAIL,
                    PART,
                    LOT_SIZE,
                    MAX_LOT_SIZE,
                    PROD_YIELD,
                    ORIGINAL_LOT_SIZE,
                    YIELD_FILM_MIDLE_INSPECTION,
                    YIELD_GLASS_MIDLE_INSPECTION,
                    YIELD_TAIL_ELECTRICAL,
                    YIELD_TAIL_COSMETIC,
                    YIELD_ASSEMBLY,
                    YIELD_ELECTRICAL_INSPECTION,
                    YIELD_FINAL_ASSEMBLY,
                    YIELD_FINAL_INSPECTION,
                    TOTAL_YIELD_FILM);
            }
        }
        #endregion 

        #region Material Cost Usage
        private void MaterialCostUsage(
            string DMC_CODE,
            string DMC_CODE_PARTS,
            double CAVITY_FILM,
            double CAVITY_GLASS,
            double CAVITY_TAIL,
            string PART,
            double LOT_SIZE,
            double MAX_LOT_SIZE,
            double PROD_YIELD,
            double ORIGINAL_LOT_SIZE,
            double YIELD_FILM_MIDLE_INSPECTION,
            double YIELD_GLASS_MIDLE_INSPECTION,
            double YIELD_TAIL_ELECTRICAL,
            double YIELD_TAIL_COSMETIC,
            double YIELD_ASSEMBLY,
            double YIELD_ELECTRICAL_INSPECTION,
            double YIELD_FINAL_ASSEMBLY,
            double YIELD_FINAL_INSPECTION,
            double TOTAL_YIELD_FILM)
        {            
            List<DISA150001MaterialCostUsage> ProcessMaster = R.getProcessMasterDISA150001(DMC_CODE_PARTS).ToList();

            if (ProcessMaster != null)
            {
                if (ProcessMaster.Count > 0)
                {
                    foreach (DISA150001MaterialCostUsage PM in ProcessMaster)
                    {
                        double TOTAL_TIME = 0;
                        double PRICE_PER_SHEET = 0;
                        double PRICE_PER_PCS = 0;
                        int CAVITY = PM.CAVITY;                     

                        if (PM.PART == "H")
                        {
                            PART = "OTHERS";
                        }

                        /*================================================================
                                             CHOKORITSU & LOT SIZE SPESIAL CASE
                        ================================================================*/
                        //CARI LOT SIZE PROSES F,G,T dan OTHER
                        if (PART == "FILM" && PM.NAMA_PROSES == "Chukan Film")  
                        {
                            LOT_SIZE = Math.Floor((LOT_SIZE * PROD_YIELD * CAVITY_FILM));

                        }
                        else if (PART == "GLASS" && PM.NAMA_PROSES == "Chukan Glass")
                        {
                            LOT_SIZE = Math.Ceiling((LOT_SIZE * PROD_YIELD * CAVITY_GLASS));

                        }
                        else if (PART == "TAIL")
                        {

                            if (PM.NAMA_PROSES == "Denki Tail")
                            {
                                LOT_SIZE = Math.Floor((LOT_SIZE * PROD_YIELD * CAVITY_TAIL));
                            }
                            else if (PM.NAMA_PROSES == "Gaikan Tail")
                            {
                                LOT_SIZE = Math.Floor((LOT_SIZE * YIELD_TAIL_ELECTRICAL));
                            }
                            else if (PM.NAMA_PROSES == "Cek Kelengkapan Tail")
                            {
                                LOT_SIZE = Math.Floor((LOT_SIZE * YIELD_TAIL_COSMETIC));
                            }

                        }
                        else if (PART == "OTHERS")
                        {
                            LOT_SIZE = Math.Floor((ORIGINAL_LOT_SIZE / 0.99));
                        }

                        //if (LOT_SIZE >= MAX_LOT_SIZE)
                        //{
                        //    LOT_SIZE = MAX_LOT_SIZE;
                        //}
                        //END CARI LOT SIZE PROSES FGT

                        //CARI CHOKORITSU PROSES F,G,T dan OTHER
                        if (PART == "FILM" && PM.NAMA_PROSES == "Chukan Film")
                        {
                            PROD_YIELD = YIELD_FILM_MIDLE_INSPECTION;
                        }
                        else if (PART == "GLASS" && PM.NAMA_PROSES == "Chukan Glass")
                        {
                            PROD_YIELD = YIELD_GLASS_MIDLE_INSPECTION;
                        }
                        else if (PART == "TAIL")
                        {
                            if (PM.NAMA_PROSES == "Denki Tail")
                            {
                                PROD_YIELD = YIELD_TAIL_ELECTRICAL;
                            }
                            else if (PM.NAMA_PROSES == "Gaikan Tail")
                            {
                                PROD_YIELD = YIELD_TAIL_COSMETIC;
                            }
                            else if (PM.NAMA_PROSES == "Cek Kelengkapan Tail")
                            {
                                PROD_YIELD = 1;
                            }
                        }
                        else if (PART == "OTHERS")
                        {
                            PROD_YIELD = 0.99;
                        }
                        //END CARI CHOKORITSU PROSES FGT

                        //CARI CHOKORITSU PROSES ASSEMBLY
                        if (PART == "ASSEMBLY")
                        {
                            if (PM.NAMA_PROSES == "Hariawase")
                            {
                                PROD_YIELD = YIELD_ASSEMBLY;
                            }           
                            else if (PM.NAMA_PROSES == "Denki 1x")
                            {
                                PROD_YIELD = YIELD_ELECTRICAL_INSPECTION;
                            }
                            else if (PM.NAMA_PROSES == "Chukan Anti Spy Film" || PM.NAMA_PROSES == "Pasang Anti Spy Film")
                            {
                                PROD_YIELD = YIELD_FINAL_ASSEMBLY;
                            }
                            else if (PM.NAMA_PROSES == "Gaikan 2x")
                            {
                                PROD_YIELD = YIELD_FINAL_INSPECTION;
                            }
                            else if (PM.NAMA_PROSES == "Gaikan 1x"
                                || PM.NAMA_PROSES == "Oven 120C 60Mnt")
                            {
                                PROD_YIELD = 1;
                            }                            
                        }
                        //END CARI CHOKORITSU ASSEMBLY

                        //CARI LOT SIZE ASSEMBLY                        
                        if (PART == "ASSEMBLY")
                        {                            
                            if (PM.NAMA_PROSES == "Hariawase")
                            {
                                LOT_SIZE = Math.Floor((ORIGINAL_LOT_SIZE / TOTAL_YIELD_FILM));
                                //PROD_YIELD_AFTER_HA = YIELD_ASSEMBLY;
                                PROD_YIELD_AFTER_HA = YIELD_ASSEMBLY;
                                LOT_SIZE_AFTER_HA = LOT_SIZE;
                            }                     
                            else
                            {                                
                                LOT_SIZE = Math.Floor((LOT_SIZE_AFTER_HA * PROD_YIELD_AFTER_HA));
                                LOT_SIZE_AFTER_HA = LOT_SIZE;
                                PROD_YIELD_AFTER_HA = PROD_YIELD;
                            }
                        }

                        //END CARI LOT SIZE ASSEMBLY
                         

                        /*================================================================
                                       END CHOKORITSU & LOT SIZE SPESIAL CASE
                        ================================================================*/

                        TOTAL_TIME = PM.SETTING_TIME / LOT_SIZE + PM.CYCLE_TIME;
                        PRICE_PER_SHEET = TOTAL_TIME / 3600 * PM.CHINRITSU / PROD_YIELD;

                        if (PM.NAMA_PROSES == "Chukan Film")
                        {
                            PRICE_PER_PCS = TOTAL_TIME / 3600 * PM.CHINRITSU / YIELD_FILM_MIDLE_INSPECTION;
                        }
                        else if (PM.NAMA_PROSES == "Chukan Glass")
                        {
                            PRICE_PER_PCS = TOTAL_TIME / 3600 * PM.CHINRITSU / YIELD_GLASS_MIDLE_INSPECTION;
                        }
                        else if (PM.NAMA_PROSES == "Denki Tail")
                        {
                            PRICE_PER_SHEET = 0;
                            PRICE_PER_PCS = TOTAL_TIME / 3600 * PM.CHINRITSU / YIELD_TAIL_ELECTRICAL;
                        }
                        else if (PM.NAMA_PROSES == "Gaikan Tail")
                        {
                            PRICE_PER_SHEET = 0;
                            PRICE_PER_PCS = TOTAL_TIME / 3600 * PM.CHINRITSU / YIELD_TAIL_COSMETIC;
                        }
                        else if (PM.NAMA_PROSES == "Cek Kelengkapan Tail")
                        {
                            PRICE_PER_SHEET = 0;
                            PRICE_PER_PCS = TOTAL_TIME / 3600 * PM.CHINRITSU / 1;
                        }
                        else if (PART == "ASSEMBLY")
                        {
                            PRICE_PER_SHEET = 0;
                            PRICE_PER_PCS = TOTAL_TIME * PM.CHINRITSU / 3600 / PROD_YIELD;
                        }
                        else if (PART == "OTHERS")
                        {
                            PRICE_PER_SHEET = 0;
                            PRICE_PER_PCS = TOTAL_TIME * PM.CHINRITSU / 3600 / PROD_YIELD;
                        }
                        else if (PART == "PACKING")
                        {

                                    List<DISA150001MaterialCost> GetCavityPacking = R.getCavityPackingDISA150001(DMC_CODE).ToList();
                                    if (ProcessMaster.Count > 0)
                                    {
                                        foreach (DISA150001MaterialCost C in GetCavityPacking)
                                        {
                                            if (PM.NAMA_PROSES == "Inner")
                                            {
                                                CAVITY = C.C_INNER;
                                            }
                                            else if (PM.NAMA_PROSES == "Foam Pad")
                                            {
                                                CAVITY = C.C_FOAM;
                                            }
                                            else if (PM.NAMA_PROSES == "Master Box")
                                            {
                                                CAVITY = C.C_MASTER;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        CAVITY = 0;
                                    }

                                    TOTAL_TIME = (PM.SETTING_TIME / LOT_SIZE) + (PM.CYCLE_TIME / CAVITY);
                                    PRICE_PER_SHEET = 0;
                                    PRICE_PER_PCS = TOTAL_TIME * PM.CHINRITSU / 3600;
                        }
                        else
                        {
                            PRICE_PER_PCS = PRICE_PER_SHEET / CAVITY;
                        }

                        //if (PART == "TAIL" && PM.NAMA_PROSES == "Pet Cut")
                        //{

                        //}

                        try
                        {
                            var Exec = DISA150001Repository.InsertMaterialCostUsage(
                                DMC_CODE,
                                PART,
                                PM.DMC_CODE_PARTS,
                                PM.KODE_PROSES,
                                PM.NAMA_PROSES,
                                PM.SETTING_TIME,
                                PM.CYCLE_TIME,
                                LOT_SIZE,
                                TOTAL_TIME,
                                PROD_YIELD,
                                PM.CHINRITSU,
                                CAVITY,
                                PM.URUTAN_PROSES,
                                PRICE_PER_SHEET,
                                PRICE_PER_PCS
                                );
                            sts = Exec[0].STACK;

                            if (Exec[0].LINE_STS == "DUPLICATE")
                            {
                                DISA150001Repository.UpdateMaterialCostUsage(
                                DMC_CODE,
                                PART,
                                PM.DMC_CODE_PARTS,
                                PM.KODE_PROSES,
                                PM.NAMA_PROSES,
                                PM.SETTING_TIME,
                                PM.CYCLE_TIME,
                                LOT_SIZE,
                                TOTAL_TIME,
                                PROD_YIELD,
                                PM.CHINRITSU,
                                CAVITY,
                                PM.URUTAN_PROSES,
                                PRICE_PER_PCS,
                                PRICE_PER_PCS
                                );
                            }
                            else if (Exec[0].STACK == "TRUE")
                            {
                                var res = M.get_default_message("MWP001", "Insert Calculate", "", "");
                                message = res[0].MSG_TEXT;
                            }
                            else
                            {
                                message = Exec[0].LINE_STS;
                            }
                        }
                        catch (Exception M)
                        {
                            sts = "false";
                            message = M.Message.ToString();
                        }
                    }
                }
            }
        }
        #endregion 

        #region Labour Charge
        private void LabourCharge()
        {
            List<DISA150001Detail> LabourCharge = R.getLabourCharge().ToList();
            foreach (DISA150001Detail LC in LabourCharge)
            {
                LABOUR_CHARGE_PRINTING = LC.LABOUR_CHARGE_PRINTING;
                LABOUR_CHARGE_ASSEMBLY = LC.LABOUR_CHARGE_ASSEMBLY;
                LABOUR_CHARGE_ETCHING = LC.LABOUR_CHARGE_ETCHING;
                LABOUR_CHARGE_PRESS = LC.LABOUR_CHARGE_PRESS;
                LABOUR_CHARGE_NON_PRINTING = LC.LABOUR_CHARGE_NON_PRINTING;
                LABOUR_CHARGE_KOMPO = LC.LABOUR_CHARGE_KOMPO;
            }
        }
        #endregion

        #region TouchPanel SalesPrice
        private void TouchPanelSalesPrice(
            string DMC_CODE,
            string CUSTOMER,            
            string TOUCH_PANEL_TYPE,
            string TOUCH_PANEL_SIZE,
            string VERSI_WIS,
            double TOTAL_YIELD_FILM,
            double ORIGINAL_LOT_SIZE,
            double YIELD_PRINTING_FILM,
            double YIELD_PRINTING_GLASS,
            double YIELD_PRINTING_TAIL,
            double YIELD_TAIL_ELECTRICAL,
            double YIELD_TAIL_COSMETIC,
            double YIELD_ASSEMBLY,
            double YIELD_ELECTRICAL_INSPECTION,
            double YIELD_FINAL_ASSEMBLY,
            double YIELD_FINAL_INSPECTION,
            double YIELD_FILM_MIDLE_INSPECTION,
            double YIELD_GLASS_MIDLE_INSPECTION,
            double INDIRECT,
            double SGA
            )
        {
            List<DISA150001Detail> SalesPrice = R.getSalesPriceDISA150001(DMC_CODE).ToList();

            if (SalesPrice != null)
            {
                if (SalesPrice.Count > 0)
                {
                    foreach (DISA150001Detail SP in SalesPrice)
                    {
                        //Hitung MaterialCost COST
                        double SUB_TOTAL_MATERIAL_COST_F = SP.AKUMULASI_PRICE_MATERIAL_PER_PCS_F / YIELD_PRINTING_FILM / YIELD_FILM_MIDLE_INSPECTION;
                        double SUB_TOTAL_MATERIAL_COST_G = SP.AKUMULASI_PRICE_MATERIAL_PER_PCS_G / YIELD_PRINTING_GLASS / YIELD_GLASS_MIDLE_INSPECTION;
                        double SUB_TOTAL_MATERIAL_COST_T = (SP.AKUMULASI_PRICE_MATERIAL_PER_PCS_T) / YIELD_PRINTING_TAIL / YIELD_TAIL_ELECTRICAL / YIELD_TAIL_COSMETIC;
                        double SUB_TOTAL_MATERIAL_COST_ASSEMBLY = ((SUB_TOTAL_MATERIAL_COST_F + SUB_TOTAL_MATERIAL_COST_G + SUB_TOTAL_MATERIAL_COST_T) / YIELD_ASSEMBLY + SP.AKUMULASI_PRICE_MATERIAL_PER_PCS_A) / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION;
                        double SUB_TOTAL_MATERIAL_COST_PACKING = SP.AKUMULASI_PRICE_MATERIAL_PER_PCS_P;
                        //End Hitung MaterialCost COST

                        //Hitung Material Cost Usage
                        double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F = SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_F / YIELD_FILM_MIDLE_INSPECTION + SP.TOTAL_LABOR_COST_CHUKAN_FILM;
                        double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G = SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_G / YIELD_GLASS_MIDLE_INSPECTION + SP.TOTAL_LABOR_COST_CHUKAN_GLASS;
                        double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T = SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_T / YIELD_TAIL_ELECTRICAL / YIELD_TAIL_COSMETIC + SP.TOTAL_LABOR_COST_DENKI_TAIL / YIELD_TAIL_COSMETIC + SP.TOTAL_LABOR_COST_GAIKAN_TAIL + SP.TOTAL_LABOR_COST_CEK_KELENGKAPAN_TAIL;
                        double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_ASSEMBLY =
                            (SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_A) / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_INSPECTION +
                            (SP.TOTAL_LABOR_COST_DENKI + SP.TOTAL_LABOR_COST_GAIKAN_1X) / YIELD_FINAL_INSPECTION + SP.TOTAL_LABOR_COST_GAIKAN_2X
                            ;
                        double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING = SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_P;
                        //End Hitung Material Cost Usage

                        //Hitung 

                        //============================================================================================
                        //[AIR CIF SALES PRICE]
                        //============================================================================================

                        //AIR CIF MATERIAL COST
                        double AIR_CIF_MATERIAL_COST = Math.Floor(SUB_TOTAL_MATERIAL_COST_ASSEMBLY + SUB_TOTAL_MATERIAL_COST_PACKING);

                        //AIR CIF LABOUR COST
                        double AIR_CIF_LABOUR_COST = Math.Ceiling((SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_ASSEMBLY + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING);

                        //INDIRECT
                        double AIR_CIF_INDIRECT = Math.Floor(AIR_CIF_LABOUR_COST * INDIRECT);

                        //SGA
                        double AIR_CIF_SGA = Math.Floor((AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT) * SGA);

                        //AIR CIF TRANSPORTATION COST
                        double AIR_CIF_TRANSPORTATION = Math.Ceiling(SP.AIR_JPN);

                        //AIR CIF GRAND TOTAL
                        double AIR_CIF_GRAND_TOTAL = Math.Ceiling(AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT + AIR_CIF_SGA + AIR_CIF_TRANSPORTATION) + 1;

                        //AIR CIF PROFIT RATIO
                        double AIR_CIF_PROFIT_RATIO = 0.05;

                        //AIR CIF SALES PRICE
                        double AIR_CIF_SALES_PRICE = Math.Ceiling(AIR_CIF_GRAND_TOTAL / (1 - AIR_CIF_PROFIT_RATIO)); //ROUND UP

                        //AIR CIF MARGINAL PROFIT RATIO
                        double AIR_CIF_MARGINAL_PROFIT_RATIO = (1 - AIR_CIF_MATERIAL_COST / AIR_CIF_SALES_PRICE);

                        //============================================================================================
                        //[SALES PRICE MASS PRO]
                        //============================================================================================

                        //MASS PRO SEA CIF JPN
                        double SEA_JPN_GRAND_TOTAL = AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT + AIR_CIF_SGA + SP.SEA_TOKYO;
                        double SEA_JPN_SALES_PRICE = Math.Ceiling(SEA_JPN_GRAND_TOTAL / (1 - AIR_CIF_PROFIT_RATIO)) + 1; //ROUND UP

                        //MASS PRO AIR CIF SHA
                        double AIR_SHA_GRAND_TOTAL = AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT + AIR_CIF_SGA + SP.AIR_SHA;
                        double AIR_SHA_SALES_PRICE = Math.Ceiling(AIR_SHA_GRAND_TOTAL / (1 - AIR_CIF_PROFIT_RATIO)); //ROUND UP

                        //MASS PRO SEA CIF SHA
                        double SEA_SHA_GRAND_TOTAL = AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT + AIR_CIF_SGA + SP.SEA_SHA;
                        double SEA_SHA_SALES_PRICE = Math.Ceiling(SEA_SHA_GRAND_TOTAL / (1 - AIR_CIF_PROFIT_RATIO)) + 1; //ROUND UP

                        //MASS PRO AIR CIF HKG
                        double AIR_HKG_GRAND_TOTAL = AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT + AIR_CIF_SGA + SP.AIR_HKG;
                        double AIR_HKG_SALES_PRICE = Math.Ceiling(AIR_HKG_GRAND_TOTAL / (1 - AIR_CIF_PROFIT_RATIO)) + 2; //ROUND UP

                        //MASS PRO SEA CIF HKG
                        double SEA_HKG_GRAND_TOTAL = AIR_CIF_MATERIAL_COST + AIR_CIF_LABOUR_COST + AIR_CIF_INDIRECT + AIR_CIF_SGA + SP.SEA_HKG;
                        double SEA_HKG_SALES_PRICE = Math.Ceiling(SEA_HKG_GRAND_TOTAL / (1 - AIR_CIF_PROFIT_RATIO)) + 1; //ROUND UP

                        //============================================================================================
                        //[FOB SALES PRICE]
                        //============================================================================================

                        //FOB MATERIAL COST
                        double FOB_MATERIAL_COST = Math.Floor(SUB_TOTAL_MATERIAL_COST_ASSEMBLY + SUB_TOTAL_MATERIAL_COST_PACKING);

                        //FOB LABOUR COST
                        double FOB_LABOUR_COST = Math.Ceiling((SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_ASSEMBLY + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING);

                        //INDIRECT
                        double FOB_INDIRECT = Math.Floor(FOB_LABOUR_COST * INDIRECT);

                        //SGA
                        double FOB_SGA = Math.Floor((FOB_MATERIAL_COST + FOB_LABOUR_COST + FOB_INDIRECT) * SGA);

                        //FOB TRANSPORTATION COST
                        double FOB_TRANSPORTATION = 0;

                        //FOB GRAND TOTAL
                        double FOB_GRAND_TOTAL = Math.Ceiling(FOB_MATERIAL_COST + FOB_LABOUR_COST + FOB_INDIRECT + FOB_SGA + FOB_TRANSPORTATION) + 1;

                        //FOB PROFIT RATIO
                        double FOB_PROFIT_RATIO = 0.05;

                        //FOB SALES PRICE
                        double FOB_SALES_PRICE = Math.Ceiling(FOB_GRAND_TOTAL / (1 - FOB_PROFIT_RATIO)); //ROUND UP

                        //FOB MARGINAL PROFIT RATIO
                        double FOB_MARGINAL_PROFIT_RATIO = 1 - FOB_MATERIAL_COST / FOB_SALES_PRICE;

                        //============================================================================================
                        //[LABOUR COST PER PROCESS]
                        //============================================================================================
                        double LABOUR_COST_PRINTING = Math.Round((SP.LABOR_COST_PRINTING_F / YIELD_FILM_MIDLE_INSPECTION + SP.LABOR_COST_PRINTING_G / YIELD_GLASS_MIDLE_INSPECTION + SP.LABOR_COST_PRINTING_T / YIELD_TAIL_ELECTRICAL / YIELD_TAIL_COSMETIC) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION,0);
                        double LABOUR_COST_ASSEMBLY = Math.Round((SP.TOTAL_LABOR_COST_CHUKAN_FILM + SP.TOTAL_LABOR_COST_CHUKAN_GLASS + SP.TOTAL_LABOR_COST_DENKI_TAIL / YIELD_TAIL_COSMETIC + SP.TOTAL_LABOR_COST_GAIKAN_TAIL + SP.TOTAL_LABOR_COST_CEK_KELENGKAPAN_TAIL) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_ASSEMBLY,0);
                        double LABOUR_COST_ETCHING = Math.Round((SP.LABOR_COST_ETCHING_F / YIELD_FILM_MIDLE_INSPECTION + SP.LABOR_COST_ETCHING_G / YIELD_GLASS_MIDLE_INSPECTION) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION,0);
                        double LABOUR_COST_PRESS = Math.Round((SP.LABOR_COST_PRESS_F / YIELD_FILM_MIDLE_INSPECTION + SP.LABOR_COST_PRESS_T / YIELD_TAIL_ELECTRICAL / YIELD_TAIL_COSMETIC + SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION,0);
                        double LABOUR_COST_NON_PRINTING = Math.Round(((SP.LABOR_COST_NON_PRINTING_F - SP.LABOR_COST_ETCHING_F) / YIELD_FILM_MIDLE_INSPECTION + (SP.LABOR_COST_NON_PRINTING_G - SP.LABOR_COST_ETCHING_G) / YIELD_GLASS_MIDLE_INSPECTION + SP.LABOR_COST_NON_PRINTING_T / YIELD_TAIL_ELECTRICAL / YIELD_TAIL_COSMETIC) / YIELD_ASSEMBLY / YIELD_ELECTRICAL_INSPECTION / YIELD_FINAL_ASSEMBLY / YIELD_FINAL_INSPECTION,0);
                        double LABOUR_COST_KOMPO = Math.Round(SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_P,0);

                        //============================================================================================
                        //[MATERIAL COST AFTER GAIKAN]
                        //============================================================================================
                        double MATERIAL_COST_AFTER_GAIKAN = AIR_CIF_MATERIAL_COST - SUB_TOTAL_MATERIAL_COST_PACKING;
                        double LABOUR_COST_PRINTING_AFTER_GAIKAN = LABOUR_COST_PRINTING;
                        double LABOUR_COST_ASSEMBLY_AFTER_GAIKAN = LABOUR_COST_ASSEMBLY;
                        double LABOUR_COST_ETCHING_AFTER_GAIKAN = LABOUR_COST_ETCHING;
                        double LABOUR_COST_PRESS_AFTER_GAIKAN = LABOUR_COST_PRESS;
                        double LABOUR_COST_NON_PRINTING_AFTER_GAIKAN = LABOUR_COST_NON_PRINTING;

                        //============================================================================================
                        //TOTAL COST TRANSPORTATION
                        //============================================================================================
                        double TOTAL_DIRECT_LABOUR = Math.Floor(LABOUR_COST_PRINTING + LABOUR_COST_NON_PRINTING + LABOUR_COST_ETCHING + LABOUR_COST_PRESS + LABOUR_COST_ASSEMBLY + LABOUR_COST_KOMPO) - 1;
                        double INDIRECT_LABOUR = Math.Floor(TOTAL_DIRECT_LABOUR * INDIRECT);
                        double LABOUR_SGA = Math.Floor((AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR)) * SGA);
                        double TOTAL_COST_AIR_JPN = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + SP.AIR_JPN + 1;
                        double TOTAL_COST_SEA_TOKYO = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + SP.SEA_TOKYO + 1;
                        double TOTAL_COST_AIR_SHA = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + SP.AIR_SHA + 1;
                        double TOTAL_COST_SEA_SHA = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + SP.SEA_SHA + 1;
                        double TOTAL_COST_AIR_HKG = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + SP.AIR_HKG + 1;
                        double TOTAL_COST_SEA_HKG = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + SP.SEA_HKG + 1;
                        double TOTAL_COST_FOB = AIR_CIF_MATERIAL_COST + (TOTAL_DIRECT_LABOUR + INDIRECT_LABOUR + LABOUR_SGA) + 1;

                        try
                        {
                            var Exec = DISA150001Repository.InsertSalesPrice(
                                DMC_CODE,
                                SP.AIR_JPN,
                                SP.SEA_TOKYO,
                                SP.AIR_SHA,
                                SP.SEA_SHA,
                                SP.AIR_HKG,
                                SP.SEA_HKG,
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
                                );
                            sts = Exec[0].STACK;

                            if (Exec[0].LINE_STS == "DUPLICATE")
                            {
                                DISA150001Repository.UpdateSalesPrice(
                                DMC_CODE,                                
                                SP.AIR_JPN,
                                SP.SEA_TOKYO,
                                SP.AIR_SHA,
                                SP.SEA_SHA,
                                SP.AIR_HKG,
                                SP.SEA_HKG,
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
                                );
                            }
                            else if (Exec[0].STACK == "TRUE")
                            {
                                var res = M.get_default_message("MWP001", "Insert Calculate", "", "");
                                message = res[0].MSG_TEXT;
                            }
                            else
                            {
                                message = Exec[0].LINE_STS;
                            }
                        }
                        catch (Exception M)
                        {
                            sts = "false";
                            message = M.Message.ToString();
                        }

                        Wip_Cost(                            
                           DMC_CODE,
                           SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_A,
                           SP.AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H,
                           AIR_CIF_MATERIAL_COST,
                           AIR_CIF_LABOUR_COST,
                           SUB_TOTAL_MATERIAL_COST_F,
                           SUB_TOTAL_MATERIAL_COST_G,
                           SUB_TOTAL_MATERIAL_COST_T,
                           SUB_TOTAL_MATERIAL_COST_ASSEMBLY,
                           SUB_TOTAL_MATERIAL_COST_PACKING,
                           SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F,
                           SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G,
                           SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T,
                           SUB_TOTAL_MATERIAL_DAN_LABOR_COST_ASSEMBLY,
                           SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING,
                           SP.LABOR_COST_PRINTING_F,
                           SP.LABOR_COST_NON_PRINTING_F,
                           SP.LABOR_COST_PRESS_F,
                           SP.LABOR_COST_PRINTING_G,
                           SP.LABOR_COST_NON_PRINTING_G,
                           SP.LABOR_COST_PRINTING_T,
                           SP.LABOR_COST_NON_PRINTING_T,
                           SP.LABOR_COST_PRESS_T,
                           SP.TOTAL_LABOR_COST_CHUKAN_FILM,
                           SP.TOTAL_LABOR_COST_CHUKAN_GLASS,
                           SP.TOTAL_LABOR_COST_HARIAWASE,
                           SP.TOTAL_LABOR_COST_OVEN,
                           SP.TOTAL_LABOR_COST_HEATSEAL,
                           SP.TOTAL_LABOR_COST_HOKYOTAPE,
                           SP.TOTAL_LABOR_COST_DENKI,
                           SP.TOTAL_LABOR_COST_GAIKAN_1X,
                           SP.TOTAL_LABOR_COST_GAIKAN_2X,
                           YIELD_FILM_MIDLE_INSPECTION,
                           YIELD_GLASS_MIDLE_INSPECTION,
                           INDIRECT,
                           SGA
                           );

                        CalcPriceList(
                            DMC_CODE,
                            CUSTOMER,
                            TOUCH_PANEL_TYPE,
                            TOUCH_PANEL_SIZE,
                            VERSI_WIS,
                            TOTAL_YIELD_FILM,
                            ORIGINAL_LOT_SIZE,
                            AIR_CIF_SALES_PRICE,
                            SEA_JPN_SALES_PRICE,
                            FOB_SALES_PRICE
                            );
                    }
                }
            }
        }
        #endregion

        #region Downlaod Production Cost

        //public virtual ActionResult DownloadExcelProdCost(string DMC_TYPE)
        //{
        //    List<DISA150001Detail> GetCodeCalc = R.getDmcCodeCalc(DMC_TYPE).ToList();
        //    foreach (DISA150001Detail CodeCalc in GetCodeCalc)
        //    {
        //        DownloadExcel(CodeCalc.DMC_TYPE);
        //    }
        //    return PartialView("ProdCost/Datagrid_Data");
        //}

        [HttpGet]
        public virtual ActionResult DownloadExcelProdCost(string DMC_CODE)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/ProductionCost/Production_Cost.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);

            //Start Create Data Table Material Cost
            DataTable dataTable_MC = new DataTable();
            dataTable_MC.Columns.Add("PART", typeof(String));
            dataTable_MC.Columns.Add("DMC_CODE_PARTS", typeof(String));
            dataTable_MC.Columns.Add("MATERIAL_KODE", typeof(Int32));
            dataTable_MC.Columns.Add("MATERIAL_NAME", typeof(String));
            dataTable_MC.Columns.Add("UNIT_PRICE", typeof(Int32));
            dataTable_MC.Columns.Add("UNIT", typeof(String));
            dataTable_MC.Columns.Add("WIDE_SIZE", typeof(Int32));
            dataTable_MC.Columns.Add("LONG_SIZE", typeof(Int32));
            dataTable_MC.Columns.Add("MATERIAL_SIZE", typeof(Int32));
            dataTable_MC.Columns.Add("CUT_SIZE", typeof(Int32));
            dataTable_MC.Columns.Add("QTY", typeof(Int32));
            dataTable_MC.Columns.Add("CAVITY", typeof(Int32));
            dataTable_MC.Columns.Add("PRICE_SHEET", typeof(Int32));
            dataTable_MC.Columns.Add("PRICE_PCS", typeof(Int32));

            List<DISA150001MaterialCost> Material_Cost = R.getDataDISA150001_Material(DMC_CODE).ToList();

            foreach (DISA150001MaterialCost DT_MC in Material_Cost)
            {
                DataRow dtRow = dataTable_MC.NewRow();

                dtRow["PART"] = DT_MC.PART;
                dtRow["DMC_CODE_PARTS"] = DT_MC.DMC_CODE_PARTS;
                dtRow["MATERIAL_KODE"] = DT_MC.MATERIAL_KODE;
                dtRow["MATERIAL_NAME"] = DT_MC.MATERIAL_NAME;
                dtRow["UNIT_PRICE"] = DT_MC.UNIT_PRICE;
                dtRow["UNIT"] = DT_MC.UNIT;
                dtRow["WIDE_SIZE"] = DT_MC.WIDE_SIZE;
                dtRow["LONG_SIZE"] = DT_MC.LONG_SIZE;
                dtRow["MATERIAL_SIZE"] = DT_MC.MATERIAL_SIZE;
                dtRow["CUT_SIZE"] = DT_MC.CUT_SIZE;
                dtRow["QTY"] = DT_MC.QTY;
                dtRow["CAVITY"] = DT_MC.CAVITY;
                dtRow["PRICE_SHEET"] = DT_MC.PRICE_PER_SHEET;
                dtRow["PRICE_PCS"] = DT_MC.PRICE_PER_PCS;

                dataTable_MC.Rows.Add(dtRow);
            }
            //End Create Data Table Material Cost

            //Start Create Data Table Material Cost Usage
            DataTable dataTable_MCU = new DataTable();
            dataTable_MCU.Columns.Add("PART", typeof(String));
            dataTable_MCU.Columns.Add("DMC_CODE_PARTS", typeof(String));
            dataTable_MCU.Columns.Add("KODE_PROSES", typeof(Int32));
            dataTable_MCU.Columns.Add("NAMA_PROSES", typeof(String));
            dataTable_MCU.Columns.Add("SETTING_TIME", typeof(Int32));
            dataTable_MCU.Columns.Add("CYCLE_TIME", typeof(Int32));
            dataTable_MCU.Columns.Add("LOT_SIZE", typeof(Int32));
            dataTable_MCU.Columns.Add("TOTAL_TIME", typeof(Int32));
            dataTable_MCU.Columns.Add("PROD_YIELD", typeof(Int32));
            dataTable_MCU.Columns.Add("CHINRITSU", typeof(Int32));            
            dataTable_MCU.Columns.Add("CAVITY", typeof(Int32));
            dataTable_MCU.Columns.Add("PRICE_SHEET", typeof(Int32));
            dataTable_MCU.Columns.Add("PRICE_PCS", typeof(Int32));

            List<DISA150001MaterialCostUsage> Material_Cost_Usage = R.getDataDISA150001_MaterialUsage(DMC_CODE).ToList();

            foreach (DISA150001MaterialCostUsage DT_MCU in Material_Cost_Usage)
            {
                DataRow dtRow = dataTable_MCU.NewRow();

                dtRow["PART"] = DT_MCU.PART;
                dtRow["DMC_CODE_PARTS"] = DT_MCU.DMC_CODE_PARTS;
                dtRow["KODE_PROSES"] = DT_MCU.KODE_PROSES;
                dtRow["NAMA_PROSES"] = DT_MCU.NAMA_PROSES;
                dtRow["SETTING_TIME"] = DT_MCU.SETTING_TIME;
                dtRow["CYCLE_TIME"] = DT_MCU.CYCLE_TIME;
                dtRow["LOT_SIZE"] = DT_MCU.LOT_SIZE;
                dtRow["TOTAL_TIME"] = DT_MCU.TOTAL_TIME;
                dtRow["PROD_YIELD"] = DT_MCU.PROD_YIELD;
                dtRow["CHINRITSU"] = DT_MCU.CHINRITSU;
                dtRow["CAVITY"] = DT_MCU.CAVITY;                
                dtRow["PRICE_SHEET"] = DT_MCU.PRICE_PER_SHEET;
                dtRow["PRICE_PCS"] = DT_MCU.PRICE_PER_PCS;

                dataTable_MCU.Rows.Add(dtRow);
            }
            //End Create Data Table Material Cost Usage

            List<DISA150001Detail> DataDetail = R.getDataDetailDownloadDISA150001(DMC_CODE).ToList();
            List<DISA150001Detail> LabourCharge = R.getLabourCharge().ToList();
            List<DISA150001Detail> Sales_Price = R.getDataDISA150001_SalesPrice(DMC_CODE).ToList();
            //List<DISA150001MaterialCost> Material_Cost = R.getDataDISA150001_Material(DMC_CODE).ToList();
            //List<DISA150001MaterialCostUsage> Material_Cost_Usage = R.getDataDISA150001_MaterialUsage(DMC_CODE).ToList();            

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                //===============================================================
                //PRINT TOUCH PANEL DETAIL
                //===============================================================                

                foreach (DISA150001Detail DT in DataDetail)
                {
                    worksheet.Cells["C13"].Value = DT.DMC_TYPE;
                    worksheet.Cells["C14"].Value = DT.CUSTOMER;
                    worksheet.Cells["C15"].Value = DT.TOUCH_PANEL_TYPE;
                    worksheet.Cells["C16"].Value = DT.RANK;
                    worksheet.Cells["C17"].Value = DT.TOUCH_PANEL_DIMENSION;
                    worksheet.Cells["C18"].Value = DT.TOUCH_PANEL_SIZE;
                    worksheet.Cells["C19"].Value = DT.VERSI_WIS;
                    worksheet.Cells["C20"].Value = DT.LOT_SIZE;
                    worksheet.Cells["C21"].Value = DT.INDIRECT;
                    worksheet.Cells["C22"].Value = DT.SGA;

                    worksheet.Cells["C24"].Value = DT.CAVITY_FILM;
                    worksheet.Cells["C25"].Value = DT.CAVITY_GLASS;
                    worksheet.Cells["C26"].Value = DT.CAVITY_TAIL;

                    worksheet.Cells["C29"].Value = DT.YIELD_PRINTING_FILM;
                    worksheet.Cells["C30"].Value = DT.YIELD_PRINTING_GLASS;
                    worksheet.Cells["C31"].Value = DT.YIELD_PRINTING_TAIL;
                    worksheet.Cells["C32"].Value = DT.YIELD_FILM_MIDLE_INSPECTION;
                    worksheet.Cells["C33"].Value = DT.YIELD_GLASS_MIDLE_INSPECTION;
                    worksheet.Cells["C34"].Value = DT.YIELD_TAIL_ELECTRICAL;
                    worksheet.Cells["C35"].Value = DT.YIELD_TAIL_COSMETIC;
                    worksheet.Cells["C36"].Value = DT.YIELD_ASSEMBLY;
                    worksheet.Cells["C37"].Value = DT.YIELD_FINAL_ASSEMBLY;
                    worksheet.Cells["C38"].Value = DT.YIELD_ELECTRICAL_INSPECTION;
                    worksheet.Cells["C39"].Value = DT.YIELD_FINAL_INSPECTION;
                    worksheet.Cells["C40"].Value = DT.YIELD_TOTAL_FILM;
                    worksheet.Cells["C41"].Value = DT.YIELD_TOTAL_GLASS;
                    worksheet.Cells["C42"].Value = DT.YIELD_TOTAL_TAIL;

                    worksheet.Cells["C46"].Value = DT.LOT_SIZE_FILM;
                    worksheet.Cells["C47"].Value = DT.LOT_SIZE_GLASS;
                    worksheet.Cells["C48"].Value = DT.LOT_SIZE_TAIL;

                    worksheet.Cells["D46"].Value = DT.MAX_LOT_SIZE_FILM;
                    worksheet.Cells["D47"].Value = DT.MAX_LOT_SIZE_GLASS;
                    worksheet.Cells["D48"].Value = DT.MAX_LOT_SIZE_TAIL;
                }

                //===============================================================
                //PRINT LABOR CHARGE
                //===============================================================

                foreach (DISA150001Detail LC in LabourCharge)
                {
                    worksheet.Cells["G13"].Value = LC.LABOUR_CHARGE_PRINTING;
                    worksheet.Cells["G14"].Value = LC.LABOUR_CHARGE_ASSEMBLY;
                    worksheet.Cells["G15"].Value = LC.LABOUR_CHARGE_ETCHING;
                    worksheet.Cells["G16"].Value = LC.LABOUR_CHARGE_PRESS;
                    worksheet.Cells["G17"].Value = LC.LABOUR_CHARGE_NON_PRINTING;
                    worksheet.Cells["G18"].Value = LC.LABOUR_CHARGE_KOMPO;
                }

                //===============================================================
                //PRINT SALES PRICE
                //===============================================================

                foreach (DISA150001Detail SP in Sales_Price)
                {
                    worksheet.Cells["F23"].Value = SP.AIR_CIF_SALES_PRICE;
                    worksheet.Cells["F24"].Value = SP.AIR_CIF_MATERIAL_COST;
                    worksheet.Cells["F25"].Value = SP.AIR_CIF_LABOUR_COST;
                    worksheet.Cells["F26"].Value = SP.AIR_CIF_INDIRECT;
                    worksheet.Cells["F27"].Value = SP.AIR_CIF_SGA;
                    worksheet.Cells["F28"].Value = SP.AIR_CIF_TRANSPORTATION_COST;
                    worksheet.Cells["F29"].Value = SP.AIR_CIF_GRAND_TOTAL;
                    worksheet.Cells["F30"].Value = SP.AIR_CIF_MARGINAL_PROFIT_RATIO;
                    worksheet.Cells["F31"].Value = SP.AIR_CIF_PROFIT_RATIO;
                    worksheet.Cells["I23"].Value = SP.FOB_SALES_PRICE;
                    worksheet.Cells["I24"].Value = SP.FOB_MATERIAL_COST;
                    worksheet.Cells["I25"].Value = SP.FOB_LABOUR_COST;
                    worksheet.Cells["I26"].Value = SP.FOB_INDIRECT;
                    worksheet.Cells["I27"].Value = SP.FOB_SGA;
                    worksheet.Cells["I28"].Value = SP.FOB_TRANSPORTATION_COST;
                    worksheet.Cells["I29"].Value = SP.FOB_GRAND_TOTAL;
                    worksheet.Cells["I30"].Value = SP.FOB_MARGINAL_PROFIT_RATIO;
                    worksheet.Cells["I31"].Value = SP.FOB_PROFIT_RATIO;

                    worksheet.Cells["F36"].Value = SP.LABOUR_COST_PRINTING;
                    worksheet.Cells["F37"].Value = SP.LABOUR_COST_ASSEMBLY;
                    worksheet.Cells["F38"].Value = SP.LABOUR_COST_ETCHING;
                    worksheet.Cells["F39"].Value = SP.LABOUR_COST_PRESS;
                    worksheet.Cells["F40"].Value = SP.LABOUR_COST_NON_PRINTING;
                    worksheet.Cells["F41"].Value = SP.LABOUR_COST_KOMPO;

                    worksheet.Cells["I36"].Value = SP.MATERIAL_COST_AFTER_GAIKAN;
                    worksheet.Cells["I37"].Value = SP.LABOUR_COST_PRINTING_AFTER_GAIKAN;
                    worksheet.Cells["I38"].Value = SP.LABOUR_COST_ASSEMBLY_AFTER_GAIKAN;
                    worksheet.Cells["I39"].Value = SP.LABOUR_COST_ETCHING_AFTER_GAIKAN;
                    worksheet.Cells["I40"].Value = SP.LABOUR_COST_PRESS_AFTER_GAIKAN;
                    worksheet.Cells["I41"].Value = SP.LABOUR_COST_NON_PRINTING_AFTER_GAIKAN;
                }
                //===============================================================
                //PRINT MATERIAL COST
                //===============================================================                                

                int rowCountMC = 53;

                //Make Border Material Cost
                worksheet.Cells["A" + (rowCountMC) + ":N" + (Material_Cost.Count + rowCountMC)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":N" + (Material_Cost.Count + rowCountMC)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":N" + (Material_Cost.Count + rowCountMC)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":N" + (Material_Cost.Count + rowCountMC)].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                foreach (DataRow row in dataTable_MC.Rows)
                {
                    worksheet.Cells["A" + (rowCountMC)].Value = row[0].ToString();
                    worksheet.Cells["B" + (rowCountMC)].Value = row[1].ToString();
                    worksheet.Cells["C" + (rowCountMC)].Value = row[2].ToString();
                    worksheet.Cells["D" + (rowCountMC)].Value = row[3].ToString();
                    worksheet.Cells["E" + (rowCountMC)].Value = row[4].ToString();
                    worksheet.Cells["F" + (rowCountMC)].Value = row[5].ToString();
                    worksheet.Cells["G" + (rowCountMC)].Value = row[6].ToString();
                    worksheet.Cells["H" + (rowCountMC)].Value = row[7].ToString();
                    worksheet.Cells["I" + (rowCountMC)].Value = row[8].ToString();
                    worksheet.Cells["J" + (rowCountMC)].Value = row[9].ToString();
                    worksheet.Cells["K" + (rowCountMC)].Value = row[10].ToString();
                    worksheet.Cells["L" + (rowCountMC)].Value = row[11].ToString();
                    worksheet.Cells["M" + (rowCountMC)].Value = row[12].ToString();
                    worksheet.Cells["N" + (rowCountMC)].Value = row[13].ToString();
                    rowCountMC++;
                }

                

                //===============================================================
                //PRINT MATERIAL COST USAGE
                //===============================================================

                //Total data Material Cost                
                int TotalRowMC = rowCountMC + 4;


                //HEADER COLUMN MATERIAL COST USAGE
                worksheet.Cells["A" + (TotalRowMC - 1)].Value = "PART";
                worksheet.Cells["B" + (TotalRowMC - 1)].Value = "DMC CODE PART";
                worksheet.Cells["C" + (TotalRowMC - 1)].Value = "KODE PROSES";
                worksheet.Cells["D" + (TotalRowMC - 1)].Value = "NAMA PROSES";
                worksheet.Cells["E" + (TotalRowMC - 1)].Value = "SETTING TIME";
                worksheet.Cells["F" + (TotalRowMC - 1)].Value = "CYCLE TIME";
                worksheet.Cells["G" + (TotalRowMC - 1)].Value = "LOT SIZE";
                worksheet.Cells["H" + (TotalRowMC - 1)].Value = "TOTAL TIME";
                worksheet.Cells["I" + (TotalRowMC - 1)].Value = "PROD YIELD";
                worksheet.Cells["J" + (TotalRowMC - 1)].Value = "CHINRITSU";
                worksheet.Cells["K" + (TotalRowMC - 1)].Value = "CAVITY";
                worksheet.Cells["L" + (TotalRowMC - 1)].Value = "PRICE / SHEET";
                worksheet.Cells["M" + (TotalRowMC - 1)].Value = "PRICE / PCS";

                

                int rowCountMCU = TotalRowMC;
                                
                //Make Border Material Cost Usage
                worksheet.Cells["A" + (rowCountMCU - 1) + ":M" + (Material_Cost_Usage.Count + (rowCountMCU))].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMCU - 1) + ":M" + (Material_Cost_Usage.Count + (rowCountMCU))].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMCU - 1) + ":M" + (Material_Cost_Usage.Count + (rowCountMCU))].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMCU - 1) + ":M" + (Material_Cost_Usage.Count + (rowCountMCU))].Style.Border.Right.Style = ExcelBorderStyle.Thin;                

                foreach (DataRow row in dataTable_MCU.Rows)
                {
                    worksheet.Cells["A" + (rowCountMCU)].Value = row[0].ToString();
                    worksheet.Cells["B" + (rowCountMCU)].Value = row[1].ToString();
                    worksheet.Cells["C" + (rowCountMCU)].Value = row[2].ToString();
                    worksheet.Cells["D" + (rowCountMCU)].Value = row[3].ToString();
                    worksheet.Cells["E" + (rowCountMCU)].Value = row[4].ToString();
                    worksheet.Cells["F" + (rowCountMCU)].Value = row[5].ToString();
                    worksheet.Cells["G" + (rowCountMCU)].Value = row[6].ToString();
                    worksheet.Cells["H" + (rowCountMCU)].Value = row[7].ToString();
                    worksheet.Cells["I" + (rowCountMCU)].Value = row[8].ToString();
                    worksheet.Cells["J" + (rowCountMCU)].Value = row[9].ToString();
                    worksheet.Cells["K" + (rowCountMCU)].Value = row[10].ToString();
                    worksheet.Cells["L" + (rowCountMCU)].Value = row[11].ToString();
                    worksheet.Cells["M" + (rowCountMCU)].Value = row[12].ToString();                    
                    rowCountMCU++;
                }                              

                //worksheet.DeleteRow(2, 2);
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            //var filename = "ProductioCost_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            var filename = "PC" + "_" + DMC_CODE + "_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #region Delete 
        public virtual ActionResult DeleteProdCost(string DMC_TYPE)
        {
            List<DISA150001Detail> GetCodeCalc = R.getDmcCodeCalc(DMC_TYPE).ToList();
            foreach (DISA150001Detail CodeCalc in GetCodeCalc)
            {
                List<DISA150001Detail> DataDetail = R.DeleteCalc(CodeCalc.DMC_TYPE).ToList();
            }
            return PartialView("ProdCost/Datagrid_Data");
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END PRODUCTION COST
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START WIP COST
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region WIP COST
        public ActionResult WipCost()
        {
            GetDataHeader();
            return View("WipCost/WipCost");
        }

        #region Kalkulasi Wip Cost
        private void Wip_Cost(
            string DMC_CODE,
            double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_A,
            double AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H,
            double AIR_CIF_MATERIAL_COST,
            double AIR_CIF_LABOUR_COST,
            double SUB_TOTAL_MATERIAL_COST_F,
            double SUB_TOTAL_MATERIAL_COST_G,
            double SUB_TOTAL_MATERIAL_COST_T,
            double SUB_TOTAL_MATERIAL_COST_ASSEMBLY,
            double SUB_TOTAL_MATERIAL_COST_PACKING,
            double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F,
            double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G,
            double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T,    
            double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_ASSEMBLY,
            double SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING,
            double LABOUR_COST_PRINTING_F,
            double LABOUR_COST_NON_PRINTING_F,
            double LABOR_COST_PRESS_F,
            double LABOUR_COST_PRINTING_G,
            double LABOUR_COST_NON_PRINTING_G,
            double LABOUR_COST_PRINTING_T,
            double LABOUR_COST_NON_PRINTING_T,
            double LABOR_COST_PRESS_T,
            double TOTAL_LABOR_COST_CHUKAN_FILM,
            double TOTAL_LABOR_COST_CHUKAN_GLASS,
            double TOTAL_LABOR_COST_HARIAWASE,
            double TOTAL_LABOR_COST_OVEN,
            double TOTAL_LABOR_COST_HEATSEAL,
            double TOTAL_LABOR_COST_HOKYOTAPE,
            double TOTAL_LABOR_COST_DENKI,
            double TOTAL_LABOR_COST_GAIKAN_1X,
            double TOTAL_LABOR_COST_GAIKAN_2X,
            double YIELD_FILM_MIDLE_INSPECTION,
            double YIELD_GLASS_MIDLE_INSPECTION,
            double INDIRECT,
            double SGA
            )
        {
            //==============================================================================================
            //WIP COST TANAOROSHI 
            //==============================================================================================
            double MATERIAL_COST_P = SUB_TOTAL_MATERIAL_COST_ASSEMBLY + SUB_TOTAL_MATERIAL_COST_PACKING;
            double MATERIAL_COST_F = SUB_TOTAL_MATERIAL_COST_F;
            double MATERIAL_COST_G = SUB_TOTAL_MATERIAL_COST_G;
            double MATERIAL_COST_FG = SUB_TOTAL_MATERIAL_COST_F + SUB_TOTAL_MATERIAL_COST_G;
            double MATERIAL_COST_FGT = SUB_TOTAL_MATERIAL_COST_ASSEMBLY;
            double MATERIAL_COST_FGT_GK = SUB_TOTAL_MATERIAL_COST_ASSEMBLY;
            double PRINTING_F = LABOUR_COST_PRINTING_F + LABOUR_COST_NON_PRINTING_F * 0.5;
            double PRINTING_G = LABOUR_COST_PRINTING_G + LABOUR_COST_NON_PRINTING_G * 0.5;
            double SCRIBE_G = (LABOUR_COST_PRINTING_G + LABOUR_COST_NON_PRINTING_G) / YIELD_GLASS_MIDLE_INSPECTION;
            double PUNCHING_F = LABOUR_COST_PRINTING_F + LABOUR_COST_NON_PRINTING_F + LABOR_COST_PRESS_F * 0.5;
            double SUDAH_PRESS_F = LABOUR_COST_PRINTING_F + LABOUR_COST_NON_PRINTING_F + LABOR_COST_PRESS_F;
            double SUB_TOTAL_LABOR_COST = AIR_CIF_LABOUR_COST;
            double PROSES_ASSEMBLY = AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_A - (TOTAL_LABOR_COST_HEATSEAL + TOTAL_LABOR_COST_HOKYOTAPE);
            double PROSES_TAIL = (TOTAL_LABOR_COST_HEATSEAL + TOTAL_LABOR_COST_HOKYOTAPE);

            List<DISA150001WipCost> DmcCodePart = R.getDmcCodeParttDISA150001(DMC_CODE).ToList();

            if (DmcCodePart != null)
            {
                if (DmcCodePart.Count > 0)
                {
                    foreach (DISA150001WipCost DCP in DmcCodePart)
                    {
                        double MATERIAL_COST = 0;
                        double FINISH_GOODS = 0;
                        double PRINTING = 0;
                        double LAMINATING_AKHIR = 0;
                        double WASHING_GLASS = 0;
                        double SCRIBE = 0;
                        double HOGOSIRU = 0;
                        double PUNCHING = 0;                       
                        double SUDAH_PRESS = 0;
                        double SUDAH_KAPTONTAPE = 0;
                        double SUDAH_CHUKAN = 0;
                        double SUDAH_FPC = 0;
                        double SUDAH_HEATSEAL = 0;
                        double SUDAH_HARIAWASE = 0;
                        double SUDAH_AGING = 0;
                        double SUDAH_OVEN = 0;
                        double SUDAH_HOKYOTAPE = 0;
                        double SUDAH_DOUBLETAPE = 0;
                        double SUDAH_FUREKENSA = 0;
                        double SUDAH_CEK_KELENGKAPAN = 0;
                        double SUDAH_DENKI = 0;
                        double SUDAH_GAIKAN = 0;

                        if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 2) == "-F")
                        {
                            MATERIAL_COST = MATERIAL_COST_F;
                            PRINTING = (PRINTING_F + (PRINTING_F * INDIRECT) + ((((MATERIAL_COST + PRINTING_F + (PRINTING_F * INDIRECT))) * SGA)));
                            LAMINATING_AKHIR = PRINTING;
                            PUNCHING = (PUNCHING_F + (PUNCHING_F * INDIRECT) + ((((MATERIAL_COST + PUNCHING_F + (PUNCHING_F * INDIRECT))) * SGA)));
                            SUDAH_PRESS = SUDAH_PRESS_F + TOTAL_LABOR_COST_CHUKAN_FILM * 0.5;
                            SUDAH_PRESS = (SUDAH_PRESS + (SUDAH_PRESS * INDIRECT) + ((((MATERIAL_COST + SUDAH_PRESS + (SUDAH_PRESS * INDIRECT))) * SGA)));
                            SUDAH_CHUKAN = (SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + (SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F * INDIRECT) + ((((MATERIAL_COST + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + (SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F * INDIRECT))) * SGA)));  
                        }
                        else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 2) == "-G")
                        {
                            MATERIAL_COST = MATERIAL_COST_G;
                            PRINTING = (PRINTING_G + (PRINTING_G * INDIRECT) + ((((MATERIAL_COST + PRINTING_G + (PRINTING_G * INDIRECT))) * SGA)));
                            LAMINATING_AKHIR = PRINTING;
                            WASHING_GLASS = PRINTING;
                            SCRIBE = SCRIBE_G + TOTAL_LABOR_COST_CHUKAN_GLASS * 0.5;
                            SCRIBE = (SCRIBE + (SCRIBE * INDIRECT) + ((((MATERIAL_COST + SCRIBE + (SCRIBE * INDIRECT))) * SGA)));
                            SUDAH_CHUKAN = (SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + (SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G * INDIRECT) + ((((MATERIAL_COST + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + (SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G * INDIRECT))) * SGA)));
                        }
                        else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 3) == "-FG")
                        {
                            MATERIAL_COST = MATERIAL_COST_FG;
                            SUDAH_HARIAWASE = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + PROSES_ASSEMBLY * 0.5;
                            SUDAH_HARIAWASE = (SUDAH_HARIAWASE + (SUDAH_HARIAWASE * INDIRECT) + ((((MATERIAL_COST + SUDAH_HARIAWASE + (SUDAH_HARIAWASE * INDIRECT))) * SGA)));
                            SUDAH_OVEN = SUDAH_HARIAWASE;
                            SUDAH_AGING = SUDAH_OVEN;
                        }
                        else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 4) == "-FGT")
                        {
                            MATERIAL_COST = MATERIAL_COST_FGT;
                            SUDAH_FPC = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H + PROSES_ASSEMBLY + PROSES_TAIL * 0.5;
                            SUDAH_FPC = (SUDAH_FPC + (SUDAH_FPC * INDIRECT) + ((((MATERIAL_COST + SUDAH_FPC + (SUDAH_FPC * INDIRECT))) * SGA)));
                            SUDAH_HEATSEAL = SUDAH_FPC;
                            SUDAH_HOKYOTAPE = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H + PROSES_ASSEMBLY + PROSES_TAIL + TOTAL_LABOR_COST_DENKI * 0.5;
                            SUDAH_HOKYOTAPE = (SUDAH_HOKYOTAPE + (SUDAH_HOKYOTAPE * INDIRECT) + ((((MATERIAL_COST + SUDAH_HOKYOTAPE + (SUDAH_HOKYOTAPE * INDIRECT))) * SGA)));
                            SUDAH_DENKI = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H + PROSES_ASSEMBLY + PROSES_TAIL + TOTAL_LABOR_COST_DENKI + (TOTAL_LABOR_COST_GAIKAN_1X + TOTAL_LABOR_COST_GAIKAN_2X) * 0.5;
                            SUDAH_DENKI = (SUDAH_DENKI + (SUDAH_DENKI * INDIRECT) + ((((MATERIAL_COST + SUDAH_DENKI + (SUDAH_DENKI * INDIRECT))) * SGA)));
                            SUDAH_GAIKAN = AIR_CIF_LABOUR_COST - SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING;
                            SUDAH_GAIKAN = (SUDAH_GAIKAN + (SUDAH_GAIKAN * INDIRECT) + ((((MATERIAL_COST + SUDAH_GAIKAN + (SUDAH_GAIKAN * INDIRECT))) * SGA)));
                        }
                        else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 7) == "-FGT-GK")
                        {
                            MATERIAL_COST = MATERIAL_COST_FGT_GK;
                            SUDAH_GAIKAN = AIR_CIF_LABOUR_COST - SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING;
                            SUDAH_GAIKAN = (SUDAH_GAIKAN + (SUDAH_GAIKAN * INDIRECT) + ((((MATERIAL_COST + SUDAH_GAIKAN + (SUDAH_GAIKAN * INDIRECT))) * SGA)));
                        }
                        else
                        {
                            MATERIAL_COST = Math.Round(MATERIAL_COST_P, 2);
                            FINISH_GOODS = AIR_CIF_LABOUR_COST;
                            FINISH_GOODS = (FINISH_GOODS + (FINISH_GOODS * INDIRECT) + ((((MATERIAL_COST + FINISH_GOODS + (FINISH_GOODS * INDIRECT))) * SGA)));
                        }

                        #region COMMAND TANAOROSHI
                        //if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 2) == "-F")
                        //{
                        //    MATERIAL_COST = MATERIAL_COST_F;
                        //    PRINTING = PRINTING_F;
                        //    LAMINATING_AKHIR = PRINTING_F;
                        //    PUNCHING = PUNCHING_F;
                        //    SUDAH_PRESS = SUDAH_PRESS_F + TOTAL_LABOR_COST_CHUKAN_FILM * 0.5;
                        //    SUDAH_CHUKAN = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F;
                        //}
                        //else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 2) == "-G")
                        //{
                        //    MATERIAL_COST = MATERIAL_COST_G;
                        //    PRINTING = PRINTING_G;
                        //    LAMINATING_AKHIR = PRINTING_G;
                        //    WASHING_GLASS = PRINTING_G;
                        //    SCRIBE = SCRIBE_G + TOTAL_LABOR_COST_CHUKAN_GLASS * 0.5;
                        //    SUDAH_CHUKAN = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G;
                        //}
                        //else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 3) == "-FG")
                        //{
                        //    MATERIAL_COST = MATERIAL_COST_FG;
                        //    SUDAH_HARIAWASE = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + PROSES_ASSEMBLY * 0.5;
                        //    SUDAH_OVEN = SUDAH_HARIAWASE;
                        //    SUDAH_AGING = SUDAH_OVEN;
                        //}                        
                        //else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 4) == "-FGT")
                        //{
                        //    MATERIAL_COST = MATERIAL_COST_FGT;
                        //    SUDAH_FPC = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H + PROSES_ASSEMBLY + PROSES_TAIL * 0.5;
                        //    SUDAH_HEATSEAL = SUDAH_FPC;
                        //    SUDAH_HOKYOTAPE = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H + PROSES_ASSEMBLY + PROSES_TAIL + TOTAL_LABOR_COST_DENKI * 0.5;
                        //    SUDAH_DENKI = SUB_TOTAL_MATERIAL_DAN_LABOR_COST_F + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_G + SUB_TOTAL_MATERIAL_DAN_LABOR_COST_T + AKUMULASI_PRICE_MATERIAL_USAGE_PER_PCS_H + PROSES_ASSEMBLY + PROSES_TAIL + TOTAL_LABOR_COST_DENKI + (TOTAL_LABOR_COST_GAIKAN_1X + TOTAL_LABOR_COST_GAIKAN_2X) * 0.5;
                        //    SUDAH_GAIKAN = AIR_CIF_LABOUR_COST - SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING;
                        //}
                        //else if (DCP.DMC_CODE_PARTS.Substring(DCP.DMC_CODE_PARTS.Length - 7) == "-FGT-GK")
                        //{
                        //    MATERIAL_COST = MATERIAL_COST_FGT_GK;
                        //    SUDAH_GAIKAN = AIR_CIF_LABOUR_COST - SUB_TOTAL_MATERIAL_DAN_LABOR_COST_PACKING;
                        //}
                        //else
                        //{
                        //    MATERIAL_COST = MATERIAL_COST_P;
                        //    FINISH_GOODS = AIR_CIF_LABOUR_COST;
                        //}
                        #endregion COMMAND TANAOROSHI



                        try
                        {
                            var Exec = DISA150001Repository.InsertWipCost(
                                DCP.DMC_CODE_PARTS,
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
                                SUDAH_GAIKAN);

                            //sts = Exec[0].STACK;

                            if (Exec[0].LINE_STS == "DUPLICATE")
                            {
                                DISA150001Repository.UpdateWipCost(
                                    DCP.DMC_CODE_PARTS,
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
                                    SUDAH_GAIKAN);
                            }
                            else if (Exec[0].STACK == "TRUE")
                            {
                                var res = M.get_default_message("MWP001", "Insert WIP Cost", "", "");
                                message = res[0].MSG_TEXT;
                            }
                            else
                            {
                                message = Exec[0].LINE_STS;
                            }
                        }
                        catch (Exception M)
                        {
                            sts = "false";
                            message = M.Message.ToString();
                        }
                    }
                }
            }
        }
        #endregion
       
        #region Search Data WipCost
        public ActionResult Search_Data_WipCost(int start, int display, string DATA_ID, string DMC_CODE_PARTS)
        {
            //Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R.getCountWipCostDISA150001(DATA_ID, DMC_CODE_PARTS), start, display);

            //Munculin Data ke Grid//
            List<DISA150001WipCost> List = R.getDataWipCostDISA150001(pg.StartData, pg.EndData, DMC_CODE_PARTS).ToList();
            ViewData["DataTanaoroshiDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("WipCost/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Downlaod Wip Cost

        [HttpGet]
        public virtual ActionResult DownloadExcelWipCost(string DMC_CODE)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/ProductionCost/Wip_Cost.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);


            //Start Create Data Table Material Cost
            DataTable dataTable_MC = new DataTable();
            dataTable_MC.Columns.Add("DMC_CODE", typeof(String));
            dataTable_MC.Columns.Add("MATERIAL_COST", typeof(Double));
            dataTable_MC.Columns.Add("FINISH_GOODS", typeof(Double));
            dataTable_MC.Columns.Add("PRINTING", typeof(Double));
            dataTable_MC.Columns.Add("LAMINATING_AKHIR", typeof(Double));
            dataTable_MC.Columns.Add("WASHING_GLASS", typeof(Double));
            dataTable_MC.Columns.Add("SCRIBE", typeof(Double));
            dataTable_MC.Columns.Add("HOGOSIRU", typeof(Double));
            dataTable_MC.Columns.Add("PUNCHING", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_PRESS", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_KAPTONTAPE", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_CHUKAN", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_FPC", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_HEATSEAL", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_HARIAWASE", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_AGING", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_OVEN", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_HOKYOTAPE", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_DOUBLETAPE", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_FUREKENSA", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_CEK_KELENGKAPAN", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_DENKI", typeof(Double));
            dataTable_MC.Columns.Add("SUDAH_GAIKAN", typeof(Double));


            //List<DISA150001WipCost> Wip_Cost = R.getDataDISA150001_WiCost(DMC_CODE).ToList();
            List<DISA150001WipCost> Wip_Cost = R.DownloadWipCostDISA150001(DMC_CODE).ToList();

            foreach (DISA150001WipCost WIP in Wip_Cost)
            {
                DataRow dtRow = dataTable_MC.NewRow();
                
                dtRow["DMC_CODE"] = WIP.DMC_CODE;
                dtRow["MATERIAL_COST"] = WIP.MATERIAL_COST;
                dtRow["FINISH_GOODS"] = WIP.FINISH_GOODS;
                dtRow["PRINTING"] = WIP.PRINTING;
                dtRow["LAMINATING_AKHIR"] = WIP.LAMINATING_AKHIR;
                dtRow["WASHING_GLASS"] = WIP.WASHING_GLASS;
                dtRow["SCRIBE"] = WIP.SCRIBE;
                dtRow["HOGOSIRU"] = WIP.HOGOSIRU;
                dtRow["PUNCHING"] = WIP.PUNCHING;
                dtRow["SUDAH_PRESS"] = WIP.SUDAH_PRESS;
                dtRow["SUDAH_KAPTONTAPE"] = WIP.SUDAH_KAPTONTAPE;
                dtRow["SUDAH_CHUKAN"] = WIP.SUDAH_CHUKAN;
                dtRow["SUDAH_FPC"] = WIP.SUDAH_FPC;
                dtRow["SUDAH_HEATSEAL"] = WIP.SUDAH_HEATSEAL;
                dtRow["SUDAH_HARIAWASE"] = WIP.SUDAH_HARIAWASE;
                dtRow["SUDAH_AGING"] = WIP.SUDAH_AGING;
                dtRow["SUDAH_OVEN"] = WIP.SUDAH_OVEN;
                dtRow["SUDAH_HOKYOTAPE"] = WIP.SUDAH_HOKYOTAPE;
                dtRow["SUDAH_DOUBLETAPE"] = WIP.SUDAH_DOUBLETAPE;
                dtRow["SUDAH_FUREKENSA"] = WIP.SUDAH_FUREKENSA;
                dtRow["SUDAH_CEK_KELENGKAPAN"] = WIP.SUDAH_CEK_KELENGKAPAN;
                dtRow["SUDAH_DENKI"] = WIP.SUDAH_DENKI;
                dtRow["SUDAH_GAIKAN"] = WIP.SUDAH_GAIKAN;



                dataTable_MC.Rows.Add(dtRow);
            }
            //End Create Data Table Material Cost                   

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
           
                int rowCountMC = 3;

                //Make Border Material Cost
                worksheet.Cells["A" + (rowCountMC) + ":X" + (Wip_Cost.Count + rowCountMC)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":X" + (Wip_Cost.Count + rowCountMC)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":X" + (Wip_Cost.Count + rowCountMC)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":X" + (Wip_Cost.Count + rowCountMC)].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                foreach (DataRow row in dataTable_MC.Rows)
                {
                    worksheet.Cells["A" + (rowCountMC)].Value = "-";
                    worksheet.Cells["B" + (rowCountMC)].Value = row[0].ToString();
                    worksheet.Cells["C" + (rowCountMC)].Value = row[1].ToString();
                    worksheet.Cells["D" + (rowCountMC)].Value = row[2].ToString();
                    worksheet.Cells["E" + (rowCountMC)].Value = row[3].ToString();
                    worksheet.Cells["F" + (rowCountMC)].Value = row[4].ToString();
                    worksheet.Cells["G" + (rowCountMC)].Value = row[5].ToString();
                    worksheet.Cells["H" + (rowCountMC)].Value = row[6].ToString();
                    worksheet.Cells["I" + (rowCountMC)].Value = row[7].ToString();
                    worksheet.Cells["J" + (rowCountMC)].Value = row[8].ToString();
                    worksheet.Cells["K" + (rowCountMC)].Value = row[9].ToString();
                    worksheet.Cells["L" + (rowCountMC)].Value = row[10].ToString();
                    worksheet.Cells["M" + (rowCountMC)].Value = row[11].ToString();
                    worksheet.Cells["N" + (rowCountMC)].Value = row[12].ToString();
                    worksheet.Cells["O" + (rowCountMC)].Value = row[13].ToString();
                    worksheet.Cells["P" + (rowCountMC)].Value = row[14].ToString();
                    worksheet.Cells["Q" + (rowCountMC)].Value = row[15].ToString();
                    worksheet.Cells["R" + (rowCountMC)].Value = row[16].ToString();
                    worksheet.Cells["S" + (rowCountMC)].Value = row[17].ToString();
                    worksheet.Cells["T" + (rowCountMC)].Value = row[18].ToString();
                    worksheet.Cells["U" + (rowCountMC)].Value = row[19].ToString();
                    worksheet.Cells["V" + (rowCountMC)].Value = row[20].ToString();
                    worksheet.Cells["W" + (rowCountMC)].Value = row[21].ToString();
                    worksheet.Cells["X" + (rowCountMC)].Value = row[22].ToString();
                   
                    rowCountMC++;
                }
               
                //worksheet.DeleteRow(2, 2);
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            //var filename = "ProductioCost_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            var filename = "WC" + "_" + DMC_CODE + "_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #endregion

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END WIP COST
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START PRICE LIST
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Price List
        public ActionResult PriceList()
        {
            GetDataHeader();
            return View("PriceList/PriceList");
        }

        
        #region Search Data 
        public ActionResult Search_Data_PriceList(int start, int display, string DATA_ID, string DMC_TYPE, string CUSTOMER)
        {
            //Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R.getCountPriceListDISA150001(DATA_ID, DMC_TYPE, CUSTOMER), start, display);

            //Munculin Data ke Grid//
            List<DISA150001PriceList> List = R.getDataPriceListDISA150001(pg.StartData, pg.EndData, DMC_TYPE, CUSTOMER).ToList();
            ViewData["DataPriceListDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("PriceList/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Kalkulasi Price List
        private void CalcPriceList(
            string DMC_CODE,
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
            
            try
            {
                var Exec = DISA150001Repository.InsertTempCalcPriceList(
                    DMC_CODE,
                    CUSTOMER,
                    TOUCH_PANEL_TYPE,
                    TOUCH_PANEL_SIZE,
                    VERSI_WIS,
                    TOTAL_YIELD_FILM,
                    ORIGINAL_LOT_SIZE,
                    AIR_CIF_SALES_PRICE,
                    SEA_JPN_SALES_PRICE,
                    FOB_SALES_PRICE

                    );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    DISA150001Repository.UpdateTempCalcPriceList(
                     DMC_CODE,
                    CUSTOMER,
                    TOUCH_PANEL_TYPE,
                    TOUCH_PANEL_SIZE,
                    VERSI_WIS,
                    TOTAL_YIELD_FILM,
                    ORIGINAL_LOT_SIZE,
                    AIR_CIF_SALES_PRICE,
                    SEA_JPN_SALES_PRICE,
                    FOB_SALES_PRICE
                    );
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Insert Calculate Price List", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }

            List<DISA150001PriceList> PriceList = R.getCalcPriceListDISA150001(DMC_CODE).ToList();

            if (PriceList != null)
            {
                if (PriceList.Count > 0)
                {
                    foreach (DISA150001PriceList PL in PriceList)
                    {
                        try
                        {
                            var Exec = DISA150001Repository.InsertCalcPriceList(
                                DMC_CODE,
                                PL.CUSTOMER,
                                PL.TOUCH_PANEL_TYPE,
                                PL.TOUCH_PANEL_SIZE,
                                PL.VERSI_WIS,
                                PL.TOTAL_YIELD_FILM,
                                PL.JENIS_TRANSPORTATION,
                                PL.LOT_10,
                                PL.LOT_20,
                                PL.LOT_50,
                                PL.LOT_100,
                                PL.LOT_200,
                                PL.LOT_300,
                                PL.LOT_400,
                                PL.LOT_500,
                                PL.LOT_1000,
                                PL.LOT_5000
                                );
                            sts = Exec[0].STACK;

                            if (Exec[0].LINE_STS == "DUPLICATE")
                            {
                                DISA150001Repository.UpdateCalcPriceList(
                                DMC_CODE,
                                PL.CUSTOMER,
                                PL.TOUCH_PANEL_TYPE,
                                PL.TOUCH_PANEL_SIZE,
                                PL.VERSI_WIS,
                                PL.TOTAL_YIELD_FILM,
                                PL.JENIS_TRANSPORTATION,
                                PL.LOT_10,
                                PL.LOT_20,
                                PL.LOT_50,
                                PL.LOT_100,
                                PL.LOT_200,
                                PL.LOT_300,
                                PL.LOT_400,
                                PL.LOT_500,
                                PL.LOT_1000,
                                PL.LOT_5000
                                );
                            }
                            else if (Exec[0].STACK == "TRUE")
                            {
                                var res = M.get_default_message("MWP001", "Insert Calculate Price List", "", "");
                                message = res[0].MSG_TEXT;
                            }
                            else
                            {
                                message = Exec[0].LINE_STS;
                            }
                        }
                        catch (Exception M)
                        {
                            sts = "false";
                            message = M.Message.ToString();
                        }
                    }
                }
            }
        }
        #endregion 

        #region Downlaod Wip Cost

        [HttpGet]
        public virtual ActionResult DownloadExcelPriceList(string DMC_CODE)
        {
            //or if you use asp.net, get the relative path
            string filePath = Server.MapPath("~/Content/TemplateReport/ProductionCost/Price_List.xlsx");

            //create a fileinfo object of an excel file on the disk
            FileInfo file = new FileInfo(filePath);


            //Start Create Data Table Material Cost
            DataTable dataTable_MC = new DataTable();
            dataTable_MC.Columns.Add("DMC_CODE", typeof(String));
            dataTable_MC.Columns.Add("CUSTOMER", typeof(String));
            dataTable_MC.Columns.Add("TYPE", typeof(String));
            dataTable_MC.Columns.Add("SIZE", typeof(String));
            dataTable_MC.Columns.Add("WIS", typeof(Double));
            dataTable_MC.Columns.Add("YIELD", typeof(Double));            
            dataTable_MC.Columns.Add("TRANSPORTATION", typeof(String));
            dataTable_MC.Columns.Add("LOT_10", typeof(Double));
            dataTable_MC.Columns.Add("LOT_20", typeof(Double));            
            dataTable_MC.Columns.Add("LOT_50", typeof(Double));
            dataTable_MC.Columns.Add("LOT_100", typeof(Double));
            dataTable_MC.Columns.Add("LOT_200", typeof(Double));
            dataTable_MC.Columns.Add("LOT_300", typeof(Double));
            dataTable_MC.Columns.Add("LOT_400", typeof(Double));
            dataTable_MC.Columns.Add("LOT_500", typeof(Double));
            dataTable_MC.Columns.Add("LOT_1000", typeof(Double));
            dataTable_MC.Columns.Add("LOT_5000", typeof(Double));
            
            List<DISA150001PriceList> Price_List = R.DownloadPriceListDISA150001(DMC_CODE).ToList();

            foreach (DISA150001PriceList PL in Price_List)
            {
                DataRow dtRow = dataTable_MC.NewRow();

                dtRow["DMC_CODE"] = PL.DMC_TYPE;
                dtRow["CUSTOMER"] = PL.CUSTOMER;
                dtRow["TYPE"] = PL.TOUCH_PANEL_TYPE;
                dtRow["SIZE"] = PL.TOUCH_PANEL_SIZE;
                dtRow["WIS"] = PL.VERSI_WIS;
                dtRow["YIELD"] = PL.TOTAL_YIELD_FILM;
                dtRow["TRANSPORTATION"] = PL.JENIS_TRANSPORTATION;
                dtRow["LOT_10"] = PL.LOT_10; 
                dtRow["LOT_20"] = PL.LOT_20;
                dtRow["LOT_50"] = PL.LOT_50;
                dtRow["LOT_100"] = PL.LOT_100;
                dtRow["LOT_200"] = PL.LOT_200;
                dtRow["LOT_300"] = PL.LOT_300;
                dtRow["LOT_400"] = PL.LOT_400;
                dtRow["LOT_500"] = PL.LOT_500;
                dtRow["LOT_1000"] = PL.LOT_1000;
                dtRow["LOT_5000"] = PL.LOT_5000;

                dataTable_MC.Rows.Add(dtRow);
            }
            //End Create Data Table Material Cost                   

            byte[] FileBytesArray;
            //create a new Excel package from the file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //create an instance of the the first sheet in the loaded file
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                int rowCountMC = 5;

                //Make Border Material Cost
                worksheet.Cells["A" + (rowCountMC) + ":R" + (Price_List.Count + rowCountMC)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":R" + (Price_List.Count + rowCountMC)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":R" + (Price_List.Count + rowCountMC)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A" + (rowCountMC) + ":R" + (Price_List.Count + rowCountMC)].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                foreach (DataRow row in dataTable_MC.Rows)
                {
                    
                    worksheet.Cells["B" + (rowCountMC)].Value = row[0].ToString();
                    worksheet.Cells["C" + (rowCountMC)].Value = row[1].ToString();
                    worksheet.Cells["D" + (rowCountMC)].Value = row[2].ToString();
                    worksheet.Cells["E" + (rowCountMC)].Value = row[3].ToString();
                    worksheet.Cells["F" + (rowCountMC)].Value = row[4].ToString();
                    worksheet.Cells["G" + (rowCountMC)].Value = row[5].ToString();
                    worksheet.Cells["H" + (rowCountMC)].Value = row[6].ToString();
                    worksheet.Cells["I" + (rowCountMC)].Value = row[7].ToString();
                    worksheet.Cells["J" + (rowCountMC)].Value = row[8].ToString();
                    worksheet.Cells["K" + (rowCountMC)].Value = row[9].ToString();
                    worksheet.Cells["L" + (rowCountMC)].Value = row[10].ToString();
                    worksheet.Cells["M" + (rowCountMC)].Value = row[11].ToString();
                    worksheet.Cells["N" + (rowCountMC)].Value = row[12].ToString();
                    worksheet.Cells["O" + (rowCountMC)].Value = row[13].ToString();
                    worksheet.Cells["P" + (rowCountMC)].Value = row[14].ToString();
                    worksheet.Cells["Q" + (rowCountMC)].Value = row[15].ToString();
                    worksheet.Cells["R" + (rowCountMC)].Value = row[16].ToString();
                                  

                    rowCountMC++;
                }

                //worksheet.DeleteRow(2, 2);
                FileBytesArray = excelPackage.GetAsByteArray();
            }

            //var filename = "ProductioCost_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            var filename = "PriceList" + "_" + DMC_CODE + "_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

        #endregion

        #endregion

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END PRICE LIST
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER CONVENTION TABLE
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER CONVENTION TABLE

        public ActionResult ConventionTable()
        {
            GetDataHeader();
            return View("ConvTable/ConventionTable");            
        }

        #region Search Data ConvTable
        public ActionResult Search_Data_ConvTable(
            int start,
            int display,
            string DATA_ID,
            string ItemCode,
            string Parts,
            string type
            )
        {
            //Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R_ConvTable.getCountDISA150001(
                DATA_ID,
                ItemCode,
                Parts,
                type
                ), start, display);

            //Munculin Data ke Grid//
            List<DISA150001_ConvTable_Master> List = R_ConvTable.getDataDISA150001(pg.StartData, pg.EndData,
                ItemCode,
                Parts,
                type
                ).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("ConvTable/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW_ConvTable(
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
            string MasterWeight
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_ConvTable_Repository.Create(
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
                    username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Convention Table Packing", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Convention Table Packing", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_ConvTable(string DATA)
        {
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string ItemCode = Datas[1];
                string Parts = Datas[2];
                string SizeProduct = Datas[3];
                string type = Datas[4];
                string BundleQty = Datas[5];
                string InnerQty = Datas[6];
                string MasterQty = Datas[7];
                string InnerType = Datas[8];
                string InnerL = Datas[9];
                string InnerW = Datas[10];
                string InnerH = Datas[11];
                string InnerWeight = Datas[12];
                string MasterType = Datas[13];
                string MasterL = Datas[14];
                string MasterW = Datas[15];
                string MasterH = Datas[16];
                string MasterWeight = Datas[17];

                var EXEC = R_ConvTable.Update_Data_ConvTable(
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
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Convention Table Packing", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_ConvTable(string DATA)
        {
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_ConvTable> DELETE_MSG = new List<DeleteModel_ConvTable>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_ConvTable.Delete_Data_ConvTable(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_ConvTable { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Convention Table Packing", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END MASTER CONVENTION TABLE
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER TYPE CUSTOMER
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER TYPE CUSTOMER

        public ActionResult TypeCustomer()
        {
            GetDataHeader();
            ViewData["dmc_type"] = R_TypeCust.getDmcTypeItemMaster();
            ViewData["customer"] = R_TypeCust.getCustomer();
            ViewData["indirect_sga"] = R_TypeCust.getIndirectSga();
            return View("TypeCust/TypeCustomer");
        }


        #region Search Data Type Customer        
        public ActionResult Search_Data_TypeCust(
            int start,
            int display,
            string DATA_ID,
            string Dmc_Type,
            string Customer,
            string Lot_Size
            )
        {
            ////Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R_TypeCust.getCountDISA150001(
                DATA_ID,
                Dmc_Type,
                Customer,
                Lot_Size
                ), start, display);

            //Munculin Data ke Grid//
            List<DISA150001_TypeCust_Master> List = R_TypeCust.getDataDISA150001(pg.StartData, pg.EndData,
                Dmc_Type,
                Customer,
                Lot_Size
                ).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("TypeCust/Datagrid_Data");
        }
        #endregion


        #region Add New        
        public ActionResult ADD_NEW_TypeCust(
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
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_TypeCust_Repository.Create(
                    Dmc_Type,
                    Customer,
                    Touch_Panel_Size,
                    Wis_Version,
                    Lot_Size,
                    In_Direct,
                    Sga,
                    Username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Type Customer", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Type Customer", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_TypeCust(string DATA)
        {
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string Dmc_Type = Datas[1];
                string Customer = Datas[2];
                string Touch_Panel_Size = Datas[3];
                string Wis_Version = Datas[4];
                string Lot_Size = Datas[5];
                string In_Direct = Datas[6];
                string Sga = Datas[7];

                var EXEC = R_TypeCust.Update_Data_TypeCust(
                    ID,
                    Dmc_Type,
                    Customer,
                    Touch_Panel_Size,
                    Wis_Version,
                    Lot_Size,
                    In_Direct,
                    Sga,
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Type Customer", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_TypeCust(string DATA)
        {
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_TypeCust> DELETE_MSG = new List<DeleteModel_TypeCust>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_TypeCust.Delete_Data_TypeCust(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_TypeCust { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Type Customer", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END MASTER TYPE CUSTOMER
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER CHINRITSU
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER CHINRITSU

        public ActionResult Chinritsu()
        {
            GetDataHeader();
            ViewData["name_kotei"] = R_Chinritsu.getListProses();
            return View("Chinritsu/Chinritsu");
        }

        #region Get Data Proses 
        public ActionResult get_Data_Proses(string NAME_KOTEI)
        {
            var data = R_Chinritsu.get_Data_Proses(NAME_KOTEI);
            return Json(new { data, NAME_KOTEI }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Search Data Type Customer        
        public ActionResult Search_Data_Chinritsu(
            int start,
            int display,
            string DATA_ID,
            string PART,
            string ID_KOTEI,
            string NAME_KOTEI,
            string FACTORY,
            string CHINRITSU
            )
        {
            ////Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R_Chinritsu.getCountDISA150001(
                DATA_ID,
                PART,
                ID_KOTEI,
                NAME_KOTEI,
                FACTORY,
                CHINRITSU
                ), start, display);

            //Munculin Data ke Grid//
            List<DISA150001_Chinritsu_Master> List = R_Chinritsu.getDataDISA150001(pg.StartData, pg.EndData,
                PART,
                ID_KOTEI,
                NAME_KOTEI,
                FACTORY,
                CHINRITSU
                ).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("Chinritsu/Datagrid_Data");
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW_CHINRITSU(
            string PART,
            string ID_KOTEI,
            string FACTORY,
            string CHINRITSU,
            string Username
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_Chinritsu_Repository.Create(
                    PART,
                    ID_KOTEI,
                    FACTORY,
                    CHINRITSU,
                    Username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Chinritsu", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Chinritsu", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_Chinritsu(string DATA)
        {
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string PART = Datas[1];
                string NAME_KOTEI = Datas[2];
                string ID_KOTEI = Datas[3];
                string FACTORY = Datas[4];
                string CHINRITSU = Datas[5];

                var EXEC = R_Chinritsu.Update_Data_Chinritsu(
                    ID,
                    PART,
                    NAME_KOTEI,
                    ID_KOTEI,
                    FACTORY,
                    CHINRITSU,
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Chinritsu", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_Chinritsu(string DATA)
        {
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_Chinritsu> DELETE_MSG = new List<DeleteModel_Chinritsu>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_Chinritsu.Delete_Data_Chinritsu(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_Chinritsu { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Chinritsu", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END MASTER CHINRITSU
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER UNIT PIRCE
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER UNIT PRICE

        public ActionResult UnitPrice()
        {
            GetDataHeader();
            ViewData["name_item"] = R_UnitPrice.getListItem();
            return View("UnitPrice/UnitPrice");
        }

        #region Get Data Item 
        public ActionResult get_Data_Item(string NAME_ITEM)
        {
            var data = R_UnitPrice.get_Data_Item(NAME_ITEM);
            return Json(new { data, NAME_ITEM }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Search Data UNIT PRICE     
        public ActionResult Search_Data_UnitPrice(
            int start,
            int display,
            string DATA_ID,
            string ITEM_CODE,
            string NAME_ITEM,            
            string UNIT_PRICE
            )
        {
            ////Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R_UnitPrice.getCountDISA150001(
                DATA_ID,
                ITEM_CODE,
                NAME_ITEM,
                UNIT_PRICE
                ), start, display);

            //Munculin Data ke Grid//
            List<DISA150001_UnitPrice_Master> List = R_UnitPrice.getDataDISA150001(pg.StartData, pg.EndData,
                ITEM_CODE,
                NAME_ITEM,
                UNIT_PRICE
                ).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("UnitPrice/Datagrid_Data");
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW_UNITPRICE(
            string ITEM_CODE,            
            string UNIT_PRICE,
            string Username
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_UnitPrice_Repository.Create(
                    ITEM_CODE,
                    UNIT_PRICE,
                    Username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Unit Price", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Unit Price", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_UnitPrice(string DATA)
        {
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string NAME_ITEM = Datas[1];
                string ITEM_CODE = Datas[2];
                string UNIT_PRICE = Datas[3];                

                var EXEC = R_UnitPrice.Update_Data_UnitPrice(
                    ID,
                    NAME_ITEM,
                    ITEM_CODE,
                    UNIT_PRICE,
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Unit Price", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_UnitPrice(string DATA)
        {
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_UnitPrice> DELETE_MSG = new List<DeleteModel_UnitPrice>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_Chinritsu.Delete_Data_Chinritsu(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_UnitPrice { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Unit Price", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END MASTER TYPE CHINRITSU
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER CHOKORITSU
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER CHOKORITSU

        public ActionResult Chokoritsu()
        {
            GetDataHeader();
            ViewData["dmc_type"] = R_TypeCust.getDmcTypeItemMaster();
            return View("Chokoritsu/Chokoritsu");
        }

        #region Search Data Chokoritsu
        public ActionResult Search_Data_Chokoritsu(
            int start,
            int display,
            string DATA_ID,
            string DMC_TYPE
            )
        {
            //Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R_Chokoritsu.getCountDISA150001(
                DATA_ID,
                DMC_TYPE
                ), start, display);

            //Munculin Data ke Grid//
            List<DISA150001_Chokoritsu_Master> List = R_Chokoritsu.getDataDISA150001(pg.StartData, pg.EndData,
                DMC_TYPE
                ).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("Chokoritsu/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW_Chokoritsu(
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
            string YIELD_DENKI_GLASS
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_Chokoritsu_Repository.Create(
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
                    username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Chokoritsu", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Chokoritsu", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_Chokoritsu(string DATA)
        {
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string DMC_TYPE = Datas[1];
                string YIELD_PRINTING_FILM = Datas[2];
                string YIELD_PRINTING_GLASS = Datas[3];
                string YIELD_PRINTING_TAIL = Datas[4];
                string YIELD_PRINTING_OVERLAY = Datas[5];
                string YIELD_SCRIBE = Datas[6];
                string YIELD_FILM_MIDLE_INSPECTION = Datas[7];
                string YIELD_FILM_KABU_MIDLE_INSPECTION = Datas[8];
                string YIELD_GLASS_MIDLE_INSPECTION = Datas[9];
                string YIELD_OVERLAY_MIDLE_INSPECTION = Datas[10];
                string YIELD_TAIL_ELECTRICAL = Datas[11];
                string YIELD_TAIL_COSMETIC = Datas[12];
                string YIELD_ASSEMBLY = Datas[13];
                string YIELD_FINAL_ASSEMBLY = Datas[14];
                string YIELD_ELECTRICAL_INSPECTION = Datas[15];
                string YIELD_FINAL_INSPECTION = Datas[16];
                string YIELD_DENKI_FILM = Datas[17];
                string YIELD_DENKI_GLASS = Datas[18];

                var EXEC = R_Chokoritsu.Update_Data_Chokoritsu(
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
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Chokoritsu", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_Chokoritsu(string DATA)
        {
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_Chokoritsu> DELETE_MSG = new List<DeleteModel_Chokoritsu>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_Chokoritsu.Delete_Data_Chokoritsu(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_Chokoritsu { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Chokoritsu", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END MASTER CHOKORITSU
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER LIST KONPO
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER LIST KONPO

        public ActionResult ListKonpo()
        {
            GetDataHeader();
            return View("ListKonpo/ListKonpo");
        }

        #region Search Data
        public ActionResult Search_Data_ListKonpo(int start, int display, string DATA_ID, string ITEM_CODE, string JENIS_PACKING, string HARGA)
        {
            //Buat Paging//
            PagingModel_DISA150001 pg = new PagingModel_DISA150001(R_ListKonpo.getCountDISA150001(DATA_ID, ITEM_CODE, JENIS_PACKING, HARGA), start, display);

            //Munculin Data ke Grid//
            List<DISA150001_ListKonpo_Master> List = R_ListKonpo.getDataDISA150001(pg.StartData, pg.EndData, ITEM_CODE, JENIS_PACKING, HARGA).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;
            return PartialView("ListKonpo/Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add New        
        public ActionResult Add_New_ListKonpo(string item_code, string jenis_packing, string qty_pcs, string factory_size, string indirect, string berat, string panjang, string lebar, string tinggi, string harga)
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_ListKonpo_Repository.Create(item_code, jenis_packing, qty_pcs, factory_size, indirect, berat, panjang, lebar, tinggi, harga, username);
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master List Konpo", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master List Konpo", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_ListKonpo(string DATA)
        {            
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string item_code = Datas[1];
                string jenis_packing = Datas[2];
                string qty_pcs = Datas[3];
                string factory_size = Datas[4];
                string indirect = Datas[5];
                string berat = Datas[6];
                string panjang = Datas[7];
                string lebar = Datas[8];
                string tinggi = Datas[9];
                string harga = Datas[10];
                
                var EXEC = R_ListKonpo.Update_Data(ID, item_code, jenis_packing, qty_pcs, factory_size, indirect, berat, panjang, lebar, tinggi, harga, username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master List Konpo", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_ListKonpo(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_ListKonpo> DELETE_MSG = new List<DeleteModel_ListKonpo>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_ListKonpo.Delete_Data_ListKonpo(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_ListKonpo { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master List Konpo", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END MASTER LIST KONPO
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //START MASTER TRANSPORTATION
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region MASTER TRANSPORT

        public ActionResult Transport()
        {
            GetDataHeader();
            ViewData["dmc_type"] = R_TypeCust.getDmcTypeItemMaster();
            return View("Transport/Transport");
        }

        #region Search Datas
        public ActionResult Search_Data_Transport(int start, int display, string DATA_ID, string ITEM_CODE, string JENIS_TRANSPORTATION)
        {
            
            //Buat Paging//
            PagingModel_DISA150001 pg= new PagingModel_DISA150001(R_Transport.getCountDISA150001(DATA_ID, ITEM_CODE, JENIS_TRANSPORTATION), start, display);
            
            //Munculin Data ke Grid//
            List<DISA150001_Transport_Master> List = R_Transport.getDataDISA150001(pg.StartData, pg.EndData, ITEM_CODE, JENIS_TRANSPORTATION).ToList();
            ViewData["DataDISA150001"] = List;
            ViewData["PagingDISA150001"] = pg;

            return PartialView("Transport/Datagrid_Data", pg.CountData);
            
        }
        #endregion

        #region Add New        
        public ActionResult ADD_NEW_TRANSPORT(
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
            string total_cost
            )
        {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            //string pass = EncryptPassword(PASSWORD);
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Exec = DISA150001_Transport_Repository.Create(
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
                    );
                sts = Exec[0].STACK;

                if (Exec[0].LINE_STS == "DUPLICATE")
                {
                    var res = M.get_default_message("MWP004", "Master Transportation", "", "");
                    message = res[0].MSG_TEXT;
                }
                else if (Exec[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP001", "Master Transportation", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = Exec[0].LINE_STS;
                }
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update Data
        public ActionResult Update_Data_Transport(string DATA)
        {            
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;
                var Datas = DATA.Split(',');
                string ID = Datas[0];
                string item_code = Datas[1];
                string lot_size = Datas[2];
                string master_qty = Datas[3];
                string box_qty = Datas[4];
                string weight = Datas[5];
                string total_weight = Datas[6];
                string jenis_transportation = Datas[7];
                string transportation_cost = Datas[8];
                string awb_free_jpn = Datas[9];
                string edi_free_air_jpn = Datas[10];
                string ams_free_jpn = Datas[11];
                string trucking_0_250_kg_jpn = Datas[12];
                string handling_air_under_50_kg_jpn = Datas[13];
                string handling_air_upto_50_kg = Datas[14];
                string total_cost = Datas[15];
                
                var EXEC = R_Transport.Update_Data(
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
                    username);
                sts = EXEC[0].STACK;
                if (EXEC[0].STACK == "TRUE")
                {
                    var res = M.get_default_message("MWP003", "Master Transportation", "", "");
                    message = res[0].MSG_TEXT;
                }
                else
                {
                    message = EXEC[0].LINE_STS;
                }


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data_Transport(string DATA)
        {            
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();
            List<DeleteModel_Transportation> DELETE_MSG = new List<DeleteModel_Transportation>();
            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        string DELETE = R_Transport.Delete_Data_Transport(Datas[i]);
                        DELETE_MSG.Add(new DeleteModel_Transportation { DELETE_NAME = Datas[i], DELETE_MSG = DELETE });
                    }
                }

                sts = "TRUE";
                var res = M.get_default_message("MWP002", "Master Transportation", "", "");
                message = res[0].MSG_TEXT;
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message, DELETE_MSG }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END START MASTER TRANSPORTATION
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}