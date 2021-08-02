using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class UserBranchModel
    {
        public int CrId { get; set; }
        public string LogInName { get; set; }
        public string CrName { get; set; }
        public string CrEdit { get; set; }
        public string CrDel { get; set; }
        public int? BranchTypeCode { get; set; }
        public int? BranchCode { get; set; }
        public int? MBranchCode { get; set; }
        public bool? PrintPreview { get; set; }

        public List<BranchTypeModel> BranchTypeList { get; set; }

        public List<BranchModel> BranchList { get; set; }
    }

    public class BranchTypeModel
    {
        public int? SubTypeCode { get; set; }
        public string BranchTypeName { get; set; }
    }

    public class BranchModel
    {
        public string BranchName { get; set; }
        public string TaxType { get; set; }
        public bool? Pharma { get; set; }
        public bool? Wellness { get; set; }
        public bool? Online { get; set; }
        public bool? Other { get; set; }
        public string Address { get; set; }
        public string ShopAddress { get; set; }
        public string Mob1 { get; set; }
        public string GstNo { get; set; }
        public string LanType { get; set; }
        public string ContactPerson { get; set; }
        public int? BranchTypeCode { get; set; }
        public int? AreaCode { get; set; }
        public string Mob2 { get; set; }
        public string EmailID { get; set; }
        public string Pwd { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string PanNo { get; set; }
        public int? BankCode { get; set; }
        public string BankAddress { get; set; }
        public string IFSCCode { get; set; }
        public string BankAcNo { get; set; }
        public decimal? OpeningBalance { get; set; }
        public string DrugLicNo1 { get; set; }
        public string DrugLicNo2 { get; set; }
        public string DrugLicNo3 { get; set; }
        public string DrugLicNo4 { get; set; }
        public DateTime? ShopEstablishment { get; set; }
        public decimal? Discount { get; set; }
        public decimal? CreditLimit { get; set; }
        public string FirmType { get; set; }
        public int? SortID { get; set; }
        public bool? Active { get; set; }
        public string BRCODE { get; set; }
        public string Dist { get; set; }
        public int? ChatID { get; set; }
        public string SERVER { get; set; }
    }
}
