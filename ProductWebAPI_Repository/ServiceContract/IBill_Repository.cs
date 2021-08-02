using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.DTO;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IBill_Repository : IDisposable
    {
        BillPaging_2_Model GetReturnBillList(GetBillFilterModel filter);
        BillPaging_3_Model GetOrderBillList(GetBillFilterModel filter);
    }
}
