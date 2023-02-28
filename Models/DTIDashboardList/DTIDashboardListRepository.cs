﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;
using Toyota.Common.Credential;
using AI070.Models;

namespace AI070.Models.DTIDashboardListRepository
{
    public class DTIDashboardListRepository
    {
        #region get label jam
        public List<ad_dis_rtjn_master_dashboard_chart_parameter> bind_Master_Dashboard_Chart_Parameter()
        {
            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ad_dis_rtjn_master_dashboard_chart_parameter>("DTIDashboardList/DTIDashboardList_bind_parameter", new
            {
                ID = 1
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region ad_dis_rtjn_master_dashboard_target
        public List<ad_dis_rtjn_master_dashboard_target> bind_ad_dis_rtjn_dashboard_master_target(int tahun, int bulan, int halte_initial)
        {
            int parm_halte = 0;
            switch (halte_initial)
            {
                case 41:
                case 42:
                    parm_halte = 4;
                    break;
                default:
                    parm_halte = halte_initial;
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("TxDTIPRD_10");
            var d = db.Fetch<ad_dis_rtjn_master_dashboard_target>("DTIDashboardList/DTIDashboardList_bind_ad_dis_rtjn_master_dashboard_target", new
            {
                parm_tahun = tahun,
                parm_bulan = bulan,
                parm_halte_initial = parm_halte
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual1
        public List<Master_Dashboard_Chart_Output_Aktual1> bind_Master_Dashboard_Chart_Output_Aktual1(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    //filter_output_halte = " and A.id_kotei in (1823,5405,3050,3052,5125,1490) ";
                    filter_output_halte = " and A.id_kotei in (1490) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    //filter_output_halte = " and A.id_kotei in (3020, 321) ";
                    filter_output_halte = " and A.id_kotei in (3020) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5017) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5070) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5190) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5220) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5230) ";
                    break;
            }


            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual1>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()
            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual2
        public List<Master_Dashboard_Chart_Output_Aktual2> bind_Master_Dashboard_Chart_Output_Aktual2(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (1823) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5020) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5072) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5195) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5232) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual2>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual3
        public List<Master_Dashboard_Chart_Output_Aktual3> bind_Master_Dashboard_Chart_Output_Aktual3(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (3050) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5025) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5074) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5200) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual3>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual4
        public List<Master_Dashboard_Chart_Output_Aktual4> bind_Master_Dashboard_Chart_Output_Aktual4(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (3052) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5155) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5080) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5209) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual4>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual5
        public List<Master_Dashboard_Chart_Output_Aktual5> bind_Master_Dashboard_Chart_Output_Aktual5(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (5125) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5157) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5085) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5211) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual5>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual6
        public List<Master_Dashboard_Chart_Output_Aktual6> bind_Master_Dashboard_Chart_Output_Aktual6(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (5405) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5165) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5087) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5212) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual6>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual7
        public List<Master_Dashboard_Chart_Output_Aktual7> bind_Master_Dashboard_Chart_Output_Aktual7(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (1823,5405,3050,3052,5125,1490) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5300) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5088) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5213) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual7>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual8
        public List<Master_Dashboard_Chart_Output_Aktual8> bind_Master_Dashboard_Chart_Output_Aktual8(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (1823,5405,3050,3052,5125,1490) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5390) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5089) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5213) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual8>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Aktual9
        public List<Master_Dashboard_Chart_Output_Aktual9> bind_Master_Dashboard_Chart_Output_Aktual9(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (1823,5405,3050,3052,5125,1490) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    filter_output_halte = " and A.id_kotei in (5430) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    //filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    filter_output_halte = " and A.id_kotei in (5435) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5213) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5222) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Aktual9>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Chart_Output_Akumulasi
        public List<Master_Dashboard_Chart_Output_Akumulasi> bind_Master_Dashboard_Chart_Output_Akumulasi(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";

            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) ";
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') "; //from Pak Eko
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (1823,5405,3050,3052,5125,1490) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) ";
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5190,5195,5200,5213) ";
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5220) ";
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5230, 5232, 5236) ";
                    break;
            }

            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Chart_Output_Akumulasi>("DTIDashboardList/DTIDashboardList_bind_output_aktual_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion

        #region Master_Dashboard_Man_Power
        public List<Master_Dashboard_Man_Power> bind_Master_Dashboard_Man_Power(DateTime periode_hari, int halte_initial)
        {
            var tgl_shift_date = "";
            var tgl_shift_1_2 = "";
            var tgl_shift_3 = "";
            TimeSpan start = new TimeSpan(0, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(7, 29, 59);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                tgl_shift_date = periode_hari.AddDays(-1).ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.AddDays(-1).ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.ToString("yyyy-MM-dd");
            }
            else
            {
                tgl_shift_date = periode_hari.ToString("yyyyMMdd");
                tgl_shift_1_2 = periode_hari.ToString("yyyy-MM-dd");
                tgl_shift_3 = periode_hari.AddDays(1).ToString("yyyy-MM-dd");
            }

            string filter_output_halte = "";
            switch (halte_initial)
            {
                case 123:
                    //1. Lam Akhir Film, 2. Lam Akhir Glass, 3. Lam Akhir Overlay,
                    //4. Print Ihouse Blkng, 5. Print Ihousei
                    //filter_output_halte = " and A.id_kotei in (1150,1280,1146,1420,1400) "; //from Pak Eko
                    filter_output_halte = " and (LEFT(UPPER(B.name_kotei), 5) = 'PRINT') ";
                    break;
                case 41:
                    //1. Double Tape Overlay, 2. Nori Sheet+Kabu Film, 3. Scribe,
                    //4. Scribe Sheet, 5. Hokyoseal Tail B, 6. Hokyouban
                    filter_output_halte = " and A.id_kotei in (1823,5405,3050,3052,5125,1490) ";
                    break;
                case 42:
                    //1. Press, 2. Press Parts
                    filter_output_halte = " and A.id_kotei in (3020,3021) ";
                    break;
                case 5:
                    //1. Hariawase, 2. Hariawase Awal, 3. Hariawase Polycarbon,
                    //4. Laminating Double Sheet, 5. Pasang Cover Polycarbon, 6. Pasang EMI Shield, 
                    //7. Pasang Overlay 8. Pasang UV Cut Film, 9. Pasang Smoke Sheet
                    //filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5020,5017,5025,5430,5157,5300,5155,5390,5165) "; //1. Hariawase only (sama dengan output printing >> all printing)
                    break;
                case 7:
                    //1. FPC/Jogekan Heatseal, 2. Heatseal Jobu, 3. Heatseal Kabu
                    //4. Jogekan Heatseal Jobu+Kabu, 5. Jogekan Heatseal Kabu, 6. Jogekan Heatseal Matrix
                    filter_output_halte = " and A.id_kotei in (5085,5070,5080,5435,5088,5089,5087,5072,5074) ";
                    break;
                case 8:
                    //1. Denki 1x, 2. Denki 1x Ulang, 3. Denki 2x
                    //4. Denki Matrik 1x, 5. Denki Matrik 2x 6. Denki Matrik 1x Ulang
                    //7. Denki Matrik 2x Ulang
                    //filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5190,5195,5200,5209,5211,5212,5213) "; //1. denki1x,1x ulang, 2x, 2x ulang (sama dengan output assembly >> denki kensa 1x)
                    break;
                case 9:
                    //1. Gaikan 1x, 2. Gaikan 1x Ulang
                    //filter_output_halte = " and A.id_kotei in (5220,5222) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5220,5222) "; //1. gaikan 1x (sama dengan output assembly >> gaikan kensa 1x)
                    break;
                default:
                    //1. Gaikan 2x, 2. Gaikan 2x Ulang, 3. Gaikan 3x
                    //filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //from Pak Eko
                    filter_output_halte = " and A.id_kotei in (5230,5232,5236) "; //1. gaikan 2x (sama dengan output assembly >> gaikan kensa 2x)
                    break;
            }


            IDBContext db = DatabaseManager.Instance.GetContext("RTJN_PRD_3");
            var d = db.Fetch<Master_Dashboard_Man_Power>("DTIDashboardList/DTIDashboardList_bind_man_power_per_jam", new
            {
                parm_tgl_shift_date = tgl_shift_date.ToString(),
                parm_tgl_shift_1_2 = tgl_shift_1_2.ToString(),
                parm_tgl_shift_3 = tgl_shift_3.ToString(),
                

                //parm_tgl_shift_date = "20210529",
                //parm_tgl_shift_1_2 = "2021-05-29",
                //parm_tgl_shift_3 = "2021-05-30",
                parm_filter_output_halte = filter_output_halte.ToString()

            });
            db.Close();
            return d.ToList();
        }
        #endregion


    }

    public class ad_dis_rtjn_master_dashboard_chart
    {
        public string id { get; set; }
        public string sistem { get; set; }
        public string judul { get; set; }
        public string report { get; set; }
        public Double value_min { get; set; }
        public Double value_max { get; set; }
        public Double value_step { get; set; }
    }

    public class ad_dis_rtjn_master_dashboard_chart_parameter
    {
        public string id { get; set; }
        public string ad_dis_rtjn_master_dashboard_chart_id { get; set; }
        public string parameter1 { get; set; }
    }

    public class ad_dis_rtjn_master_dashboard_target
    {
        public Int32 id { get; set; }
        public Int32 tahun { get; set; }
        public Int32 bulan { get; set; }
        public String halte { get; set; }
        public int halte_initial { get; set; }
        public Double total_day { get; set; }
        public Double amount_day { get; set; }
        public Double average_price { get; set; }
        public Double setting_cokoritsu { get; set; }
        public Int32 target_daily { get; set; }
        public Int32 target_hourly { get; set; }
        public Int32 man_power { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual1
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual2  
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual3
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual4
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual5
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual6
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual7
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual8
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Aktual9
    {
        public string periode { get; set; }
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
        //public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Chart_Output_Akumulasi
    {
        public string periode { get; set; }        
        public Int32 akumulasi { get; set; }
    }

    public class Master_Dashboard_Man_Power
    {
        public Int32 jam_0730_sd_0830 { get; set; }
        public Int32 jam_0830_sd_0930 { get; set; }
        public Int32 jam_0930_sd_1040 { get; set; }
        public Int32 jam_1040_sd_1230 { get; set; }
        public Int32 jam_1230_sd_1330 { get; set; }
        public Int32 jam_1330_sd_1430 { get; set; }
        public Int32 jam_1430_sd_1600 { get; set; }
        public Int32 jam_1600_sd_1700 { get; set; }
        public Int32 jam_1700_sd_1830 { get; set; }
        public Int32 jam_1830_sd_1930 { get; set; }
        public Int32 jam_1930_sd_2030 { get; set; }
        public Int32 jam_2030_sd_2130 { get; set; }
        public Int32 jam_2130_sd_2230 { get; set; }
        public Int32 jam_2230_sd_2330 { get; set; }
        public Int32 jam_2330_sd_0030 { get; set; }
        public Int32 jam_0030_sd_0130 { get; set; }
        public Int32 jam_0130_sd_0230 { get; set; }
        public Int32 jam_0230_sd_0330 { get; set; }
        public Int32 jam_0330_sd_0530 { get; set; }
        public Int32 jam_0530_sd_0630 { get; set; }
        public Int32 jam_0630_sd_0730 { get; set; }
        
    }

}