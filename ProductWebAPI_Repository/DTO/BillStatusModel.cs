using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class BillStatusModel
    {
        public int OrderMstID { get; set; }
        public Nullable<int> POCode { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public string Type { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> BranchCode { get; set; }
        public int SubTypeCode { get; set; }
    }
}
