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
    
    public partial class BranchMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BranchMst()
        {
            this.Med_PurchaseReturnMst = new HashSet<Med_PurchaseReturnMst>();
            this.Stockist_SaleInvoiceMst = new HashSet<Stockist_SaleInvoiceMst>();
            this.Stockist_SaleReturnMst = new HashSet<Stockist_SaleReturnMst>();
        }
    
        public int BranchMstID { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public Nullable<int> BranchTypeCode { get; set; }
        public Nullable<int> AreaCode { get; set; }
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public string EmailID { get; set; }
        public string Pwd { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> AnniversaryDate { get; set; }
        public string GstNo { get; set; }
        public string PanNo { get; set; }
        public string TaxType { get; set; }
        public string LanType { get; set; }
        public Nullable<int> BankCode { get; set; }
        public string BankAddress { get; set; }
        public string IFSCCode { get; set; }
        public string BankAcNo { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public string DrugLicNo1 { get; set; }
        public string DrugLicNo2 { get; set; }
        public string DrugLicNo3 { get; set; }
        public string DrugLicNo4 { get; set; }
        public Nullable<System.DateTime> ShopEstablishment { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public string FirmType { get; set; }
        public Nullable<bool> Pharma { get; set; }
        public Nullable<bool> Wellness { get; set; }
        public Nullable<bool> Online { get; set; }
        public Nullable<bool> Other { get; set; }
        public Nullable<int> SortID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public string BRCODE { get; set; }
        public string Dist { get; set; }
        public Nullable<int> ChatID { get; set; }
        public string ShopAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Med_PurchaseReturnMst> Med_PurchaseReturnMst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stockist_SaleInvoiceMst> Stockist_SaleInvoiceMst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stockist_SaleReturnMst> Stockist_SaleReturnMst { get; set; }
    }
}
