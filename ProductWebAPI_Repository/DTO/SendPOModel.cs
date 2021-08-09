using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class SendPOModel
    {
        public int PurchaseOrderMstID { get; set; }
        public Nullable<int> POCode { get; set; }
        public Nullable<System.DateTime> PODate { get; set; } = DateTime.Now;
        public Nullable<int> BranchCode { get; set; }
        public Nullable<int> BranchTypeCode { get; set; }
        public Nullable<byte> Rec { get; set; } = 1;
        public string Sflag { get; set; } = "I";
        public Nullable<System.DateTime> Sdate { get; set; } = DateTime.Now;
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; } = 1;
        public Nullable<bool> SendMail { get; set; }
        public int SubTypeCode { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }

    public class PurchaseOrder
    {
        public int PurchaseOrderDetID { get; set; }
        public int PurchaseOrderMstID { get; set; }
        public Nullable<int> Srno { get; set; }
        public Nullable<int> ProductCode { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> Margin { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<int> Rec { get; set; }
        public Nullable<decimal> OrderAmt { get; set; }
    }

    public class ReturnPOData
    {
        public int PurchaseOrderMstID { get; set; }
        public Nullable<int> POCode { get; set; }
    }
}
