//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductWebAPI_Repository.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleInvoiceMst
    {
        public int SaleInvoiceMstID { get; set; }
        public Nullable<int> PurchaseOrderMstID { get; set; }
        public Nullable<System.DateTime> SaleInvoiceDate { get; set; }
        public string Type { get; set; }
        public Nullable<int> BranchCode { get; set; }
        public Nullable<int> BillNo { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<int> ChallanNo { get; set; }
        public Nullable<System.DateTime> ChallanDate { get; set; }
        public Nullable<int> DueDay { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Remarks { get; set; }
        public string Message { get; set; }
        public string TransportName { get; set; }
        public string LRNO { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public Nullable<byte> Rec { get; set; }
        public string PayRec { get; set; }
        public Nullable<decimal> TotAmt { get; set; }
        public Nullable<decimal> TotRetAmt { get; set; }
        public Nullable<decimal> PayAmt { get; set; }
        public Nullable<decimal> PaidAmt { get; set; }
        public Nullable<decimal> PendAmt { get; set; }
    }
}
