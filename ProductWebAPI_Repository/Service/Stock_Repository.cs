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
    public class Stock_Repository : IStock_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Stock_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Stock_Repository()
        {
            context = new MED_GENMEDEntities();
        }
        public StockModel GetStockGenmed(int productCode)
        {
            return context.Database.SqlQuery<StockModel>("SELECT (SUM(ISNULL(dbo.Stock_Genmed.QtyInStrip, 0)) + " +
                                                                       "SUM(ISNULL(dbo.Stock_Genmed.FreeQtyInStrip, 0)) + " +
                                                                       "SUM(ISNULL(dbo.Stock_Genmed.SalRetQtyInStrip, 0))) - " +
                                                                       "(SUM(ISNULL(dbo.Stock_Genmed.SalQtyInStrip, 0)) + " +
                                                                       "SUM(ISNULL(dbo.Stock_Genmed.PurRetQtyInStrip, 0))) AS PendQTY, " +
                                                                       "dbo.ProductMst.ProductName, " +
                                                                       "dbo.MktCompanyMst.MktCompanyName " +
                                                               "FROM dbo.Stock_Genmed " +
                                                               "INNER JOIN dbo.ProductMst ON dbo.Stock_Genmed.ProductCode = dbo.ProductMst.ProductCode " +
                                                               "INNER JOIN dbo.MktCompanyMst ON dbo.ProductMst.MktCompanyCode = dbo.MktCompanyMst.MktCompanyCode " +
                                                               "WHERE (dbo.Stock_Genmed.ProductCode = " + productCode + ") " +
                                                               "GROUP BY dbo.ProductMst.ProductName, dbo.MktCompanyMst.MktCompanyName " +
                                                               "HAVING ((SUM(ISNULL(dbo.Stock_Genmed.QtyInStrip, 0)) + SUM(ISNULL(dbo.Stock_Genmed.FreeQtyInStrip, 0)) + SUM(ISNULL(dbo.Stock_Genmed.SalRetQtyInStrip, 0))) - (SUM(ISNULL(dbo.Stock_Genmed.SalQtyInStrip, 0)) + SUM(ISNULL(dbo.Stock_Genmed.PurRetQtyInStrip, 0))) > 0)").FirstOrDefault();
        }
        public StockModel GetStockStockist(int productCode)
        {
            string str = "SELECT (SUM(ISNULL(dbo.Stock_Stockist.QtyInStrip, 0)) + " +
                                                                                 "SUM(ISNULL(dbo.Stock_Stockist.FreeQtyInStrip, 0)) + " +
                                                                                 "SUM(ISNULL(dbo.Stock_Stockist.SalRetQtyInStrip, 0))) - " +
                                                                                 "(SUM(ISNULL(dbo.Stock_Stockist.SalQtyInStrip, 0)) + " +
                                                                                 "SUM(ISNULL(dbo.Stock_Stockist.PurRetQtyInStrip, 0))) AS PendQTY, " +
                                                                                 "dbo.ProductMst.ProductName, " +
                                                                                 "dbo.MktCompanyMst.MktCompanyName " +
                                                                         "FROM dbo.Stock_Stockist " +
                                                                         "INNER JOIN dbo.ProductMst ON dbo.Stock_Stockist.ProductCode = dbo.ProductMst.ProductCode " +
                                                                         "INNER JOIN dbo.MktCompanyMst ON dbo.ProductMst.MktCompanyCode = dbo.MktCompanyMst.MktCompanyCode " +
                                                                         "WHERE (dbo.Stock_Stockist.ProductCode = " + productCode + ") " +
                                                                         "GROUP BY dbo.ProductMst.ProductName, dbo.MktCompanyMst.MktCompanyName " +
                                                                         "HAVING ((SUM(ISNULL(dbo.Stock_Stockist.QtyInStrip, 0)) + SUM(ISNULL(dbo.Stock_Stockist.FreeQtyInStrip, 0)) + SUM(ISNULL(dbo.Stock_Stockist.SalRetQtyInStrip, 0))) - (SUM(ISNULL(dbo.Stock_Stockist.SalQtyInStrip, 0)) + SUM(ISNULL(dbo.Stock_Stockist.PurRetQtyInStrip, 0))) > 0) ";
            return context.Database.SqlQuery<StockModel>(str).FirstOrDefault();
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
