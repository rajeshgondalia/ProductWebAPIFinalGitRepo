using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IError_Repository : IDisposable
    {
        void InsertErrorLog(string ErrorInfo,string MethodName,string ErrorURL);
    }
}
