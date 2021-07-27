using ProductWebAPI_Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IStock_Repository
    {
        StockModel GetStockGenmed(int productCode);
        StockModel GetStockStockist(int productCode);
    }
}
