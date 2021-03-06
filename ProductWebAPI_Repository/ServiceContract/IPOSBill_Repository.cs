using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.DTO;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IPOSBill_Repository : IDisposable
    {
        List<POSBillResponseModel> InsertUpdatePOSBill(List<POSMstModel> postlist);

        List<POSBILLGetModel> GetAllPOSBill(POSBillFilter filter);

        void DeletePOSBill(List<POSBillResponseModel> model);
    }
}
