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
        public string DMC_CODE { get; set; }
        public int QTY_BUNDLE_STD { get; set; }
        public int QTY_BUNDLE_ACT { get; set; }
        public int BERAT_BUNDLE_STD { get; set; }
        public int BERAT_BUNDLE_ACT { get; set; }

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


        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
        public string AREA_NAME { get; set; }
        public string LOC_NAME { get; set; }
        public string ID_TB_M_LOCATION { get; set; }
        public string ID_TB_M_AREA { get; set; }
        public string IMPLEMENT_DATE_FROM { get; set; }
        public string IMPLEMENT_DATE_TO { get; set; }
        public string IMPLEMENT_DATE_FROM_DISP { get; set; }
        public string IMPLEMENT_DATE_TO_DISP { get; set; }
        public string DEP_OR_DIV_CODE { get; set; }
        public string DIV { get; set; }
        public string WORKING_STATUS_DESC { get; set; }
        public string WORKING_STATUS { get; set; }
        public string WORKING_NOTES { get; set; }
        public string PROJECT_STATUS { get; set; }
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

}