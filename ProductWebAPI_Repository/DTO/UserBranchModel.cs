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
        public string CrPass { get; set; }
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
    }
}
