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
    
    public partial class Med_OfferMst
    {
        public int Med_OfferMstID { get; set; }
        public Nullable<System.DateTime> OfferDate { get; set; }
        public Nullable<int> MBranchCode { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> NoOfProduct { get; set; }
        public Nullable<decimal> FromAmt { get; set; }
        public Nullable<decimal> ToAmt { get; set; }
        public string Message { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
