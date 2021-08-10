using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class POSBillFilter
    {
        public int BranchCode { get; set; }

        public Nullable<System.DateTime> FromDate { get; set; }

        public Nullable<System.DateTime> ToDate { get; set; }
    }
}
