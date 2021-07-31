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
        List<MarginModel> GetAllMargin(MarginFilter filter);
        List<Margin_2_2_Model> GetMargin_2_2(MarginFilter filter);
        List<Margin_2_4_Model> GetMargin_2_4(MarginFilter filter);
        List<Margin_2_6_Model> GetMargin_2_6(MarginFilter filter);
        List<Margin_3_3_Model> GetMargin_3_3(MarginFilter filter);
        List<Margin_3_5_Model> GetMargin_3_5(MarginFilter filter);
        List<Margin_3_7_Model> GetMargin_3_7(MarginFilter filter);
    }
}
