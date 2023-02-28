﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AI070.Models.DTIDashboardListRepository;
using System.Threading.Tasks;

namespace AI070.Controllers.DTIDashboardList
{
    public class DTIDashboardListController : Controller
    {

        DTIDashboardListRepository R = new DTIDashboardListRepository();

        // GET: DTIDashboardList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult rtjn_dashboard_output_produksi(Int32 halte = 10)
        {
            List<ad_dis_rtjn_master_dashboard_chart_parameter> bind_parameter = R.bind_Master_Dashboard_Chart_Parameter().ToList();
            ViewData["bind_parameter"] = bind_parameter;

            List<ad_dis_rtjn_master_dashboard_target> bind_target = R.bind_ad_dis_rtjn_dashboard_master_target(
                                                                                    DateTime.Today.Year,
                                                                                    DateTime.Today.Month,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_target"] = bind_target;

            List<Master_Dashboard_Chart_Output_Aktual1> bind_aktual1 = R.bind_Master_Dashboard_Chart_Output_Aktual1(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();            
            ViewData["bind_aktual1"] = bind_aktual1;

            List<Master_Dashboard_Chart_Output_Aktual2> bind_aktual2 = R.bind_Master_Dashboard_Chart_Output_Aktual2(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual2"] = bind_aktual2;
            
         
            List<Master_Dashboard_Chart_Output_Aktual3> bind_aktual3 = R.bind_Master_Dashboard_Chart_Output_Aktual3(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual3"] = bind_aktual3;

            List<Master_Dashboard_Chart_Output_Aktual4> bind_aktual4 = R.bind_Master_Dashboard_Chart_Output_Aktual4(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual4"] = bind_aktual4;

            List<Master_Dashboard_Chart_Output_Aktual5> bind_aktual5 = R.bind_Master_Dashboard_Chart_Output_Aktual5(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual5"] = bind_aktual5;

            List<Master_Dashboard_Chart_Output_Aktual6> bind_aktual6 = R.bind_Master_Dashboard_Chart_Output_Aktual6(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual6"] = bind_aktual6;

            List<Master_Dashboard_Chart_Output_Aktual7> bind_aktual7 = R.bind_Master_Dashboard_Chart_Output_Aktual7(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual7"] = bind_aktual7;

            List<Master_Dashboard_Chart_Output_Aktual8> bind_aktual8 = R.bind_Master_Dashboard_Chart_Output_Aktual8(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual8"] = bind_aktual8;

            List<Master_Dashboard_Chart_Output_Aktual9> bind_aktual9 = R.bind_Master_Dashboard_Chart_Output_Aktual9(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_aktual9"] = bind_aktual9;

            List<Master_Dashboard_Chart_Output_Akumulasi> bind_akumulasi = R.bind_Master_Dashboard_Chart_Output_Akumulasi(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_akumulasi"] = bind_akumulasi;

            List<Master_Dashboard_Man_Power> List5 = R.bind_Master_Dashboard_Man_Power(
                                                                                    DateTime.Today,
                                                                                    halte
                                                                                    ).ToList();
            ViewData["bind_Master_Dashboard_Man_Power"] = List5;


            switch (halte.ToString())
            {
                case "123":
                    ViewData["Title"] = "HALTE 1_2_3";
                    break;
                case "41":
                    ViewData["Title"] = "HALTE 4 DALAM";
                    break;
                case "42":
                    ViewData["Title"] = "HALTE 4 LUAR";
                    break;
                default:
                    ViewData["Title"] = "HALTE " + halte.ToString();
                    break;
            }

            switch (halte.ToString())
            {
                case "123":
                    ViewBag.Proses_List = "All Printing";
                    break;
                case "41":
                    ViewBag.Proses_List = "Double Tape Overlay, Nori Sheet+Kabu Film, Scribe, Scribe Sheet, Hokyoseal Tail B, Hokyouban";
                    break;
                case "42":
                    ViewBag.Proses_List = "Press, Press Parts";
                    break;
                case "5":
                    ViewBag.Proses_List = "Hariawase, Hariawase Awal, Hariawase Polycarbon, Laminating Double Sheet, Pasang Cover Polycarbon, Pasang EMI Shield, Pasang Overlay, Pasang UV Cut Film, Pasang Smoke Sheet";
                    break;
                case "7":
                    ViewBag.Proses_List = "FPC/Jogekan Heatseal, Heatseal Jobu, Heatseal Jobu Kanan, Heatseal Jobu Kiri, Heatseal Kabu, Jogekan Heatseal Jobu+Kabu, Jogekan Heatseal Jobu, Jogekan Heatseal Kabu, Jogekan Heatseal Matrix";
                    break;
                case "8":
                    ViewBag.Proses_List = "Denki 1x, Denki 1x Ulang, Denki 2x, Denki Matrik 1x, Denki Matrik 2x, Denki Matrik 1x Ulang, Denki Matrik 2x Ulang";
                    break;
                case "9":
                    ViewBag.Proses_List = "Gaikan 1x, Gaikan 1x Ulang";
                    break;
                default:
                    ViewBag.Proses_List = "Gaikan 2x, Gaikan 2x Ulang, Gaikan 3x";
                    break;
            }



            return View();
        }
    }
}