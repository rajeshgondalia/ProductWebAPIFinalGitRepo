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
    
    public partial class TabletTypeMst
    {
        public int TabletTypeMstID { get; set; }
        public int TabletTypeCode { get; set; }
        public string TabletTypeName { get; set; }
        public Nullable<int> SortID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
    }
}
