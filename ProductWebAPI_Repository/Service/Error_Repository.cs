using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.ServiceContract;
using System.Data.Entity;
using ProductWebAPI_Repository.Data;
using System.Data;
using System.Data.SqlClient;
using ProductWebAPI_Repository.DataServices;

namespace ProductWebAPI_Repository.Service
{
    public class Error_Repository : IError_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Error_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Error_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public void InsertErrorLog(string ErrorInfo, string MethodName, string ErrorURL)
        {
            try
            {
                ErrorLogMaster e = new ErrorLogMaster();
                e.ErrorInfo = ErrorInfo;
                e.ErrorURL = ErrorURL;
                e.MethodName = MethodName;
                e.CreatedDate = DateTime.Now;
                context.ErrorLogMasters.Add(e);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                ex.SetLog("InsertErrorLog,Error_Repository");
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
