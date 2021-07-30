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

        public List<ProductModel> ProductListCompanyWise(ProductFilterModel filter)
        {
            try
            { 
                var prod = context.Database.SqlQuery<ProductModel>("SELECT  P.ProductMstID, P.ProductCode, P.ProductName, P.SubProductCode, SP.SubProductName, SP.MainProductCode, MP.MainProductName, P.GenericCode, P.MfgCompanyCode, MFG.MfgCompanyName, " +
                         "P.MktCompanyCode, MKT.MktCompanyName, MKT.DivisionCode, DIV.DivisionName, P.DiseaseCode, DI.DiseaseName, DI.Alert AS DAlert, P.StorageCode, ST.StorageName, P.TabletTypeCode, TT.TabletTypeName, P.Tax, " +
                         "P.HSNCode, P.Qty, P.NoOfQty, P.TotQty, P.UnitCode, UN.UnitName, P.Packing, P.QtyBox, P.QtyCartoon, P.MaxStock, P.MinStock, P.OpeningStock, P.SortID, P.Active, P.Contain, P.Pharma, P.Wellness, " +
                         "P.Online, P.ScheduleCode, SCH.ScheduleName, SCH.Alert, P.DPCO, P.ProductDate, (select CONVERT(VARCHAR(10), P.ProductDate, 103)) as ProductDate1, P.FrontImage, P.BackImage, P.RightImage, P.LeftImage, P.DescImage " +
                         "FROM            dbo.ProductMst AS P INNER JOIN " +
                         "dbo.SubProductMst AS SP ON P.SubProductCode = SP.SubProductCode INNER JOIN " +
                         "dbo.MainProductMst AS MP ON SP.MainProductCode = MP.MainProductCode INNER JOIN " +
                         "dbo.MfgCompanyMst AS MFG ON P.MfgCompanyCode = MFG.MfgCompanyCode INNER JOIN " +
                         "dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode INNER JOIN " +
                         "dbo.DivisionMst AS DIV ON MKT.DivisionCode = DIV.DivisionCode INNER JOIN " +
                         "dbo.StorageMst AS ST ON P.StorageCode = ST.StorageCode INNER JOIN " +
                         "dbo.DiseaseMst AS DI ON P.DiseaseCode = DI.DiseaseCode INNER JOIN " +
                         "dbo.TabletTypeMst AS TT ON P.TabletTypeCode = TT.TabletTypeCode INNER JOIN " +
                         "dbo.UnitMst AS UN ON P.UnitCode = UN.UnitCode INNER JOIN " +
                         "dbo.ScheduleMst AS SCH ON P.ScheduleCode = SCH.ScheduleCode WHERE(P.Active = 1) " +
                         "ORDER BY P.ProductName").AsQueryable();
                if (!string.IsNullOrEmpty(filter.Contain))
                {
                    prod = prod.Where(x => x.Contain.Trim() == filter.Contain.Trim()).AsQueryable();
                }
                if (!string.IsNullOrEmpty(filter.HSNCode))
                {
                    prod = prod.Where(x => x.HSNCode.Trim() == filter.HSNCode.Trim()).AsQueryable();
                }
                if (filter.MfgCompanyCode != null && filter.MfgCompanyCode > 0)
                {
                    prod = prod.Where(x => x.MfgCompanyCode == filter.MfgCompanyCode).AsQueryable();
                }
                if (filter.MktCompanyCode != null && filter.MktCompanyCode > 0)
                {
                    prod = prod.Where(x => x.MktCompanyCode == filter.MktCompanyCode).AsQueryable();
                }
                if (filter.ProductCode != null && filter.ProductCode > 0)
                {
                    prod = prod.Where(x => x.ProductCode == filter.ProductCode).AsQueryable();
                }
                if (filter.ProductDate != null)
                {
                    prod = prod.Where(x => x.ProductDate == filter.ProductDate).AsQueryable();
                }
                if (filter.ScheduleCode != null && filter.ScheduleCode > 0)
                {
                    prod = prod.Where(x => x.ScheduleCode == filter.ScheduleCode).AsQueryable();
                }
                if (filter.TabletTypeCode != null && filter.TabletTypeCode > 0)
                {
                    prod = prod.Where(x => x.TabletTypeCode == filter.TabletTypeCode).AsQueryable();
                }
                if (filter.Tax != null && filter.Tax > 0)
                {
                    prod = prod.Where(x => x.Tax == filter.Tax).AsQueryable();
                }
                if (filter.Active != null)
                {
                    prod = prod.Where(x => x.Active == filter.Active).AsQueryable();
                }
                if (filter.Online != null)
                {
                    prod = prod.Where(x => x.Online == filter.Online).AsQueryable();
                }
                if (filter.Wellness != null)
                {
                    prod = prod.Where(x => x.Wellness == filter.Wellness).AsQueryable();
                }
                if (filter.Pharma != null)
                {
                    prod = prod.Where(x => x.Pharma == filter.Pharma).AsQueryable();
                }  

                // Get's No of Rows Count   
                int count = prod.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = filter.pageNumber;

                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int PageSize = filter.pageSize;

                // Display TotalCount to Records to User  
                int TotalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                // Returns List of Customer after applying Paging   
                var items = prod.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                return items;
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
