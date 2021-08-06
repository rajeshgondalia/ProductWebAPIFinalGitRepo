using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class PurchaseOrderModel
    {
        public int ProductCode { get; set; }
        public string Product { get; set; }
        public string Company { get; set; }
        public Nullable<int> GenericCode { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalRate { get; set; }
        public decimal Margin { get; set; }
        public decimal PurchaseRs { get; set; }
        public string Packing { get; set; }
    }
    public class PurchaseOrderPagingModel
    {
        public List<PurchaseOrderModel> PurchaseOrderList { get; set; }
        public PagingModel PagingDetails { get; set; }
    }
}
