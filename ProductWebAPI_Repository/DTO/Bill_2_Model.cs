using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class Bill_2_Model
    {
        public int ID { get; set; }
        public int PurchaseOrderMstID { get; set; }
        public DateTime BillDate { get; set; }
        public int BillNo { get; set; }
        public string Type { get; set; }
    }

    public class BillPaging_2_Model
    {
        public List<Bill_2_Model> Bill_2List { get; set; }
        public PagingModel PagingDetails { get; set; }
    } 
}
