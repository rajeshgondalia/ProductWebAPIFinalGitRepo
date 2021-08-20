using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class StockModel
    {
        public decimal PendQTY { get; set; }
        public string ProductName { get; set; }
        public string MktCompanyName { get; set; }
    }
    public class StockPostModal
    {
        public int productCode { get; set; }
    }
}
