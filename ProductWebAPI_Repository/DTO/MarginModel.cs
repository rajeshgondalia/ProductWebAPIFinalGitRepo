using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class MarginModel
    {
        public int MarginMstID { get; set; }
        public int ProductCode { get; set; }
        public string BatchNo { get; set; }
        public string Expiry { get; set; }
        public Nullable<int> PurchaseDetID { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalRate { get; set; }
        public Nullable<decimal> PurRate { get; set; }
        public Nullable<decimal> GSTPer { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> WithOutGST { get; set; }
        public Nullable<decimal> CustSaveRs { get; set; }
        public Nullable<decimal> CustSavePer { get; set; }
        public Nullable<decimal> MFMarginRs { get; set; }
        public Nullable<decimal> MFMarginPer { get; set; }
        public Nullable<decimal> MSPurRate { get; set; }
        public Nullable<decimal> MSPurRs { get; set; }
        public Nullable<decimal> MSMarginRs { get; set; }
        public Nullable<decimal> MSMarginPer { get; set; }
        public Nullable<decimal> MGMarginRs { get; set; }
        public Nullable<decimal> MGMarginPer { get; set; }
        public Nullable<decimal> WFMarginRs { get; set; }
        public Nullable<decimal> WFMarginPer { get; set; }
        public Nullable<decimal> WSPurRate { get; set; }
        public Nullable<decimal> WSPurRs { get; set; }
        public Nullable<decimal> WSMarginRs { get; set; }
        public Nullable<decimal> WSMarginPer { get; set; }
        public Nullable<decimal> WGMarginRs { get; set; }
        public Nullable<decimal> WGMarginPer { get; set; }
        public Nullable<decimal> OFMarginRs { get; set; }
        public Nullable<decimal> OFMarginPer { get; set; }
        public Nullable<decimal> OSPurRate { get; set; }
        public Nullable<decimal> OSPurRs { get; set; }
        public Nullable<decimal> OSMarginRs { get; set; }
        public Nullable<decimal> OSMarginPer { get; set; }
        public Nullable<decimal> OGMarginRs { get; set; }
        public Nullable<decimal> OGMarginPer { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
    }

    public class MarginPagingModel
    {
        public List<MarginModel> MarginList { get; set; }
        public PagingModel PagingDetails { get; set; }
    }
}
