using ProductWebAPI_Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IMargin_Repository : IDisposable
    {
        MarginPagingModel GetAllMargin(MarginFilter filter);
        Margin_2_2PagingModel GetMargin_2_2(MarginFilter filter);
        Margin_2_4PagingModel GetMargin_2_4(MarginFilter filter);
        Margin_2_6PagingModel GetMargin_2_6(MarginFilter filter);
        Margin_3_3PagingModel GetMargin_3_3(MarginFilter filter);
        Margin_3_5PagingModel GetMargin_3_5(MarginFilter filter);
        Margin_3_7PagingModel GetMargin_3_7(MarginFilter filter);
    }
}
