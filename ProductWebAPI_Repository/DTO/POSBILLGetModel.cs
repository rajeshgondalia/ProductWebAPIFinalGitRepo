using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class POSBILLGetModel
    {
        // POSMst
        public int POSMstID { get; set; }
        public int BranchCode { get; set; }
        public int BillNo { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<byte> PaymentTypeCode { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public string Type { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public string PatientMobNo { get; set; }
        public string DiseaseName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorAddress { get; set; }
        public string DoctorMobNo { get; set; }
        public string DegreeName { get; set; }
        public Nullable<int> RemDays { get; set; }
        public Nullable<System.DateTime> RemDate { get; set; }
        public string Offer { get; set; }
        public string ChatID { get; set; }
        public Nullable<decimal> TotAmt { get; set; }
        public Nullable<decimal> PaidAmt { get; set; }
        public Nullable<decimal> PendAmt { get; set; }
        public Nullable<int> EditCount { get; set; }
        public string GST { get; set; }

        // POSDET
        public int POSDetID { get; set; } 
        public Nullable<byte> Srno { get; set; }
        public Nullable<int> BCode { get; set; }
        public Nullable<int> ProductCode { get; set; }
        public string BatchNo { get; set; }
        public string Expiry { get; set; }
        public string Packing { get; set; }
        public Nullable<decimal> QtyInUnit { get; set; }
        public Nullable<decimal> QtyInStrip { get; set; }
        public Nullable<decimal> QtyInBox { get; set; }
        public Nullable<decimal> QtyInCartoon { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalRate { get; set; }
        public Nullable<decimal> SalAmt { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> DiscAmt { get; set; }
        public Nullable<byte> TaxCode { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> GstAmt { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> CAMT { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> SAMT { get; set; }
        public Nullable<bool> FreeProduct { get; set; }
        public Nullable<decimal> TotalAmt { get; set; }
        public Nullable<int> MarginMstID { get; set; }
        public Nullable<bool> Ret { get; set; }
        public int DBranchCode { get; set; }
        public int DBillNo { get; set; }
        public Nullable<decimal> ProfitRate { get; set; }
        public Nullable<decimal> ProfitAmt { get; set; }

        // POSRETDET

        public int POSRetDetID { get; set; } 
        public Nullable<int> RetBillNo { get; set; }
        public Nullable<byte> RSrno { get; set; }
        public Nullable<int> RBCode { get; set; }
        public Nullable<int> RProductCode { get; set; }
        public string RBatchNo { get; set; }
        public string Expr10 { get; set; }
        public string RExpiry { get; set; }
        public Nullable<decimal> RQtyInUnit { get; set; }
        public Nullable<decimal> RQtyInStrip { get; set; }
        public Nullable<decimal> RQtyInBox { get; set; }
        public Nullable<decimal> RQtyInCartoon { get; set; }
        public Nullable<decimal> RMRP { get; set; }
        public Nullable<decimal> RSalRate { get; set; }
        public Nullable<decimal> RSalAmt { get; set; }
        public Nullable<decimal> RDisc { get; set; }
        public Nullable<decimal> RDiscAmt { get; set; }
        public Nullable<byte> RTaxCode { get; set; }
        public Nullable<decimal> RGst { get; set; }
        public Nullable<decimal> RGstAmt { get; set; }
        public Nullable<decimal> RCGST { get; set; }
        public Nullable<decimal> RCAMT { get; set; }
        public Nullable<decimal> RSGST { get; set; }
        public Nullable<decimal> RSAMT { get; set; }
        public Nullable<bool> RFreeProduct { get; set; }
        public Nullable<decimal> RTotalAmt { get; set; }
        public Nullable<int> RMarginMstID { get; set; }
        public int RBranchCode { get; set; }
        public int RBillNo { get; set; }
        public Nullable<decimal> RProfitRate { get; set; }
        public Nullable<decimal> RProfitAmt { get; set; }
    }
}
