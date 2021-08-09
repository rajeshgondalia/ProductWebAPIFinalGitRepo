using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class POSBillResponseModel
    {
        public int POSMstID { get; set; }
        public int BranchCode { get; set; }
        public int BillNo { get; set; }
    }
}
