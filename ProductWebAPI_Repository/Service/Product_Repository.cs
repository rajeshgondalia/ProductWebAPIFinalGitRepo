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
        public static string MarginPer = string.Empty;
        public static string PurRate = string.Empty;
        public static string WHERE = string.Empty;
        public Product_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Product_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public ProductPagingModel ProductListCompanyWise(ProductFilterModel filter)
        {
            try
            {
                ProductPagingModel pModel = new ProductPagingModel();
                PagingModel pageModel = new PagingModel();
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

                pModel.ProductList = items;
                pageModel.pageNumber = CurrentPage;
                pageModel.TotalCount = TotalCount;
                pModel.PagingDetails = pageModel;

                return pModel;
            }
            catch (Exception ex)
            {
                ex.SetLog("ProductListCompanyWise,Repository");
                throw;
            }
        }
        public static void ChkStr() { if (WHERE == null) { WHERE = WHERE + " WHERE ("; } else if (WHERE != null) { WHERE = WHERE + " OR "; } }

        public static void FINDCONDITION(PurchaseOrderFilterModel filter)
        {
            WHERE = null;
            if (filter.Pharma == true) { ChkStr(); WHERE = WHERE + "P.Pharma = 1 "; }
            if (filter.Wellness == true) { ChkStr(); WHERE = WHERE + "P.Wellness = 1 "; }
            if (filter.Online == true) { ChkStr(); WHERE = WHERE + "P.Online = 1 "; }
            if (WHERE == null) { WHERE = "WHERE P.Pharma = 0 AND P.Wellness = 0 AND P.Online = 0 "; }
            else { WHERE = WHERE + ")"; }
        }
        public static void FINDCOLUMN(PurchaseOrderFilterModel filter)
        {
            MarginPer = null; PurRate = null;
            if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 2) { MarginPer = "ISNULL(MP.MSMarginPer, 0)"; PurRate = "MP.MSPurRate"; }
            else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 4) { MarginPer = "ISNULL(MP.WSMarginPer, 0)"; PurRate = "MP.WSPurRate"; }
            else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 6) { MarginPer = "ISNULL(MP.OSMarginPer, 0)"; PurRate = "MP.OSPurRate"; }
            else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 3) { MarginPer = "ISNULL(MP.MFMarginPer, 0)"; PurRate = "MP.MSPurRs"; }
            else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 5) { MarginPer = "ISNULL(MP.WFMarginPer, 0)"; PurRate = "MP.WSPurRs"; }
            else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 7) { MarginPer = "ISNULL(MP.OFMarginPer, 0)"; PurRate = "MP.OSPurRs"; }
        }
        public PurchaseOrderPagingModel PurchaseOrderList(PurchaseOrderFilterModel filter)
        {
            try
            {
                PurchaseOrderPagingModel mModel = new PurchaseOrderPagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<PurchaseOrderModel> purchaseOrder = new PurchaseOrderModel[] { }.AsQueryable();
                FINDCONDITION(filter);
                FINDCOLUMN(filter);
                purchaseOrder = context.Database.SqlQuery<PurchaseOrderModel>("SELECT MP.ProductCode, P.ProductName As Product, MK.MktCompanyName As Company, P.GenericCode, MP.MRP, MP.SalRate, " + MarginPer + " AS Margin, " + PurRate + " AS PurchaseRs, P.Packing FROM dbo.MktCompanyMst AS MK INNER JOIN dbo.ProductMst AS P ON MK.MktCompanyCode = P.MktCompanyCode INNER JOIN(SELECT TOP(100) PERCENT ProductCode, MAX(MarginMstID) AS MarginMstID FROM dbo.MarginMst GROUP BY ProductCode ORDER BY ProductCode) AS MID ON P.ProductCode = MID.ProductCode INNER JOIN dbo.MarginMst AS MP ON MID.ProductCode = MP.ProductCode AND MID.MarginMstID = MP.MarginMstID " + WHERE + " GROUP BY MP.MRP, MP.SalRate, MP.ProductCode," + MarginPer + ", P.ProductName, MK.MktCompanyName, P.GenericCode, " + PurRate + ", P.Packing ORDER BY MP.ProductCode").AsQueryable();

                // Get's No of Rows Count   
                int count = purchaseOrder.Count();
                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = filter.pageNumber;
                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int PageSize = filter.pageSize;
                // Display TotalCount to Records to User  
                int TotalCount = count;
                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                // Returns List of Customer after applying Paging   
                var items = purchaseOrder.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                mModel.PurchaseOrderList = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
                pModel.TotalPages = TotalPages;
                mModel.PagingDetails = pModel;
                return mModel;
            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
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
