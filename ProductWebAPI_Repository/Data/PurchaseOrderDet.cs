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
    
    public partial class PurchaseOrderDet
    {
        public int PurchaseOrderDetID { get; set; }
        public Nullable<int> PurchaseOrderMstID { get; set; }
        public Nullable<int> Srno { get; set; }
        public Nullable<int> ProductCode { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> Margin { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<int> Rec { get; set; }
        public Nullable<decimal> OrderAmt { get; set; }
    }
}
