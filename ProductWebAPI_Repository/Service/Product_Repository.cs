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
    public class Product_Repository : IProduct_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Product_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Product_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public List<ProductModel> ProductListCompanyWise()
        {
            try
            { 
                var prod = context.Database.SqlQuery<ProductModel>("select P.*, (select CONVERT(VARCHAR(10), P.Sdate, 103)) as Sdate1, " +
  "(select CONVERT(VARCHAR(10), P.ProductDate, 103)) as ProductDate1 " +
  "from ProductMst as P " +
"inner join MfgCompanyMst as MF on P.MfgCompanyCode = MF.MfgCompanyCode " +
"inner join MktCompanyMst as MK on P.MktCompanyCode = MK.MktCompanyCode " +
"inner join DiseaseMst as D on P.DiseaseCode = D.DiseaseCode " +
"inner join SubProductMst as S on P.SubProductCode = S.SubProductCode " +
"inner join TabletTypeMst as T on P.TabletTypeCode = T.TabletTypeCode " +
"inner join StorageMst as ST on P.StorageCode = ST.StorageCode " +
"inner join UnitMst as U on P.UnitCode = U.UnitCode " +
"inner join GenericMst as G on P.GenericCode = G.GenericCode " +
"inner join GenericGroupMst as GG on G.GenericGroupCode = GG.GenericGroupCode " +
"Where P.Active = 1").ToList();
                return prod;
            }
            catch (Exception ex)
            {
                ex.SetLog("ProductListCompanyWise,Repository");
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
