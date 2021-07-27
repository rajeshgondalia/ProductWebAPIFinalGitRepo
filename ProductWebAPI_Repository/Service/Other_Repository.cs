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
using ProductWebAPI_Repository.DTO;

namespace ProductWebAPI_Repository.Service
{
    public class Other_Repository : IOther_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Other_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Other_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public List<ContainModel> GetAllContain()
        {
            return context.ContainMsts.Select(x => new ContainModel()
            {
                ContainMstID = x.ContainMstID,
                ContainName = x.ContainName,
                DPCO = x.DPCO,
                ScheduleCode = x.ScheduleCode
            }).OrderBy(y => y.ContainName).ToList();
        }
        public List<DiseaseModel> GetAllDisease()
        {
            return context.DiseaseMsts.Select(x => new DiseaseModel()
            {
                DiseaseMstID = x.DiseaseMstID,
                DiseaseName = x.DiseaseName,
                Active = x.Active,
                Alert = x.Alert,
                CompanyCode = x.CompanyCode,
                DiseaseCode = x.DiseaseCode,
                Ever = x.Ever,
                LogID = x.LogID,
                PcID = x.PcID,
               Sdate = x.Sdate,
               Sflag = x.Sflag,
               SortID = x.SortID
            }).OrderBy(y => y.DiseaseName).ToList();
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
