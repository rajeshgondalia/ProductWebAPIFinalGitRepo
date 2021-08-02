using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class Bill_3_Model
    {
        public int ID { get; set; }
        public int Med_PurchaseOrderMstID { get; set; }
        public DateTime BillDate { get; set; }
        public int BillNo { get; set; }
        public string Type { get; set; }
    }

    public class BillPaging_3_Model
    {
        public List<Bill_3_Model> Bill_3List { get; set; }
        public PagingModel PagingDetails { get; set; }
    }
}
