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
    public class Bill_Repository : IBill_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Bill_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Bill_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public BillPaging_2_Model GetReturnBillList(GetBillFilterModel filter)
        {
            try
            {
                BillPaging_2_Model pModel = new BillPaging_2_Model();
                PagingModel pageModel = new PagingModel();
                IQueryable<Bill_2_Model> prod;
                if (filter.Rec == 1)
                { 
                    prod = context.Database.SqlQuery<Bill_2_Model>("SELECT SaleInvoiceMstID AS ID, PurchaseOrderMstID, BillDate, BillNo,'ORDER' As Type " +
"FROM dbo.SaleInvoiceMst WHERE(Rec = 1) AND(BranchCode = " + filter.BranchCode + ") AND " +
"CONVERT(date, BillDate) BETWEEN CONVERT(date, '" + filter.FromDate + "') and CONVERT(date, '" + filter.ToDate + "') " +
"union all SELECT SaleReturnMstID AS ID, PurchaseOrderMstID, BillDate, BillNo, 'RETURN' As Type " +
"FROM dbo.SaleReturnMst WHERE(Rec = 1) AND(BranchCode = " + filter.BranchCode + ") AND " +
"CONVERT(date, BillDate) BETWEEN CONVERT(date, '" + filter.FromDate + "') and CONVERT(date, '" + filter.ToDate + "')").AsQueryable();
                }
                else                
                {
                    prod = context.Database.SqlQuery<Bill_2_Model>("SELECT SaleInvoiceMstID AS ID, PurchaseOrderMstID, BillDate, BillNo,'ORDER' As Type " +
"FROM dbo.SaleInvoiceMst WHERE(Rec = " + filter.Rec + ") AND(BranchCode = " + filter.BranchCode + ") AND " +
"CONVERT(date, BillDate) BETWEEN CONVERT(date, GETDATE()) and CONVERT(date, GETDATE()) " +
"union all SELECT SaleReturnMstID AS ID, PurchaseOrderMstID, BillDate, BillNo, 'RETURN' As Type " +
"FROM dbo.SaleReturnMst WHERE(Rec = " + filter.Rec + ") AND(BranchCode = " + filter.BranchCode + ")").AsQueryable();
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

                pModel.Bill_2List = items;
                pageModel.pageNumber = CurrentPage;
                pageModel.TotalCount = TotalCount;
                pModel.PagingDetails = pageModel;

                return pModel;
            }
            catch (Exception ex)
            {
                ex.SetLog("GetReturnBillList,Repository");
                throw;
            }
        }

        public BillPaging_3_Model GetOrderBillList(GetBillFilterModel filter)
        {
            try
            {
                BillPaging_3_Model pModel = new BillPaging_3_Model();
                PagingModel pageModel = new PagingModel();
                IQueryable<Bill_3_Model> prod;
                if (filter.Rec == 1)
                {
                    prod = context.Database.SqlQuery<Bill_3_Model>("SELECT Stockist_SaleInvoiceMstID AS ID, Med_PurchaseOrderMstID, BillDate, BillNo,'ORDER' As Type " +
"FROM dbo.Stockist_SaleInvoiceMst WHERE(Rec = 1) AND(MBranchCode = " + filter.BranchCode + ") AND " +
"CONVERT(date, BillDate) BETWEEN CONVERT(date, '" + filter.FromDate + "') and CONVERT(date, '" + filter.ToDate + "') " +
"union all SELECT Stockist_SaleReturnMstID AS ID, Med_PurchaseOrderMstID, BillDate, BillNo, 'RETURN' As Type " +
"FROM dbo.Stockist_SaleReturnMst WHERE(Rec = 1) AND(MBranchCode = " + filter.BranchCode + ") AND " +
"CONVERT(date, BillDate) BETWEEN CONVERT(date, '" + filter.FromDate + "') and CONVERT(date, '" + filter.ToDate + "')").AsQueryable();
                }
                else
                {
                    prod = context.Database.SqlQuery<Bill_3_Model>("SELECT Stockist_SaleInvoiceMstID AS ID, Med_PurchaseOrderMstID, BillDate, BillNo,'ORDER' As Type " +
"FROM dbo.Stockist_SaleInvoiceMst WHERE(Rec = " + filter.Rec + ") AND(MBranchCode = " + filter.BranchCode + ") AND " +
"CONVERT(date, BillDate) BETWEEN CONVERT(date, GETDATE()) and CONVERT(date, GETDATE()) " +
"union all SELECT Stockist_SaleReturnMstID AS ID, Med_PurchaseOrderMstID, BillDate, BillNo, 'RETURN' As Type " +
"FROM dbo.Stockist_SaleReturnMst WHERE(Rec = " + filter.Rec + ") AND(MBranchCode = " + filter.BranchCode + ")").AsQueryable();
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

                pModel.Bill_3List = items;
                pageModel.pageNumber = CurrentPage;
                pageModel.TotalCount = TotalCount;
                pModel.PagingDetails = pageModel;

                return pModel;
            }
            catch (Exception ex)
            {
                ex.SetLog("GetOrderBillList,Repository");
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
