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
    
    public partial class Stockist_SaleInvoiceDet
    {
        public int Stockist_SaleInvoiceDetID { get; set; }
        public Nullable<int> Stockist_SaleInvoiceMstID { get; set; }
        public Nullable<int> SaleInvoiceDetID { get; set; }
        public Nullable<int> Med_PurchaseOrderDetID { get; set; }
        public Nullable<byte> Srno { get; set; }
        public Nullable<int> ProductCode { get; set; }
        public string BatchNo { get; set; }
        public string Expiry { get; set; }
        public Nullable<byte> GodownCode { get; set; }
        public Nullable<byte> RackCode { get; set; }
        public string Box { get; set; }
        public Nullable<byte> UnitCode { get; set; }
        public string Packing { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> StripQty { get; set; }
        public Nullable<decimal> BoxQty { get; set; }
        public Nullable<decimal> CartoonQty { get; set; }
        public Nullable<decimal> FreeQtyInUnit { get; set; }
        public Nullable<decimal> FreeQtyInStrip { get; set; }
        public Nullable<decimal> FreeQtyInBox { get; set; }
        public Nullable<decimal> FreeQtyInCartoon { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalRate { get; set; }
        public Nullable<decimal> SalAmount { get; set; }
        public Nullable<decimal> DiscPer { get; set; }
        public Nullable<decimal> DiscAmt { get; set; }
        public Nullable<decimal> NetRate { get; set; }
        public Nullable<int> MarginMstID { get; set; }
        public Nullable<byte> TaxCode { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> GstAmt { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> CAMT { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> SAMT { get; set; }
        public Nullable<decimal> TotalAmt { get; set; }
        public Nullable<bool> FreeProduct { get; set; }
        public string Description { get; set; }
        public Nullable<int> BCode { get; set; }
    
        public virtual Stockist_SaleInvoiceDet Stockist_SaleInvoiceDet1 { get; set; }
        public virtual Stockist_SaleInvoiceDet Stockist_SaleInvoiceDet2 { get; set; }
        public virtual TaxMst TaxMst { get; set; }
        public virtual UnitMst UnitMst { get; set; }
    }
}
