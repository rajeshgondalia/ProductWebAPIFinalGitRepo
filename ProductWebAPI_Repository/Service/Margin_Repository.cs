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
using System.Security.Claims;
using Microsoft.VisualBasic;

namespace ProductWebAPI_Repository.Service
{
    public class Margin_Repository : IMargin_Repository, IDisposable
    {
        private MED_GENMEDEntities context; public static string WHERE = null;
        public static string MarginRs = null; public static string MarginPer = null; public static string PurchaseRs = null;
        public Margin_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Margin_Repository()
        {
            context = new MED_GENMEDEntities();
        }
        public static void ChkStr() { if (WHERE == null) { WHERE = WHERE + " WHERE ("; } else if (WHERE != null) { WHERE = WHERE + " OR "; } }
        public static void FINDCONDITION(MarginFilter filter)
        {
            WHERE = null;
            if (filter.Pharma == true) { ChkStr(); WHERE = WHERE + "P.Pharma = 1 "; }
            if (filter.Wellness == true) { ChkStr(); WHERE = WHERE + "P.Wellness = 1 "; }
            if (filter.Online == true) { ChkStr(); WHERE = WHERE + "P.Online = 1 "; }
            if (WHERE == null) { WHERE = "WHERE P.Pharma = 0 AND P.Wellness = 0 AND P.Online = 0 "; }
            else { WHERE = WHERE + ")"; }
        }
        public static void FINDCOLUMN(MarginFilter filter)
        {
            MarginRs = null; MarginPer = null; PurchaseRs = null;
            if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 2) { MarginRs = "MSMarginRs"; MarginPer = "MSMarginPer"; PurchaseRs = "MSPurRate"; }
            else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 4) { MarginRs = "WSMarginRs"; MarginPer = "WSMarginPer"; PurchaseRs = "MSPurRate"; }
            else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 6) { MarginRs = "OSMarginRs"; MarginPer = "OSMarginPer"; PurchaseRs = "MSPurRate"; }
            else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 3) { MarginRs = "MFMarginRs"; MarginPer = "MFMarginPer"; PurchaseRs = "MSPurRs"; }
            else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 5) { MarginRs = "WFMarginRs"; MarginPer = "WFMarginPer"; PurchaseRs = "MSPurRs"; }
            else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 7) { MarginRs = "OFMarginRs"; MarginPer = "OFMarginPer"; PurchaseRs = "MSPurRs"; }
        }
        public MarginPagingModel GetAllMargin(MarginFilter filter)
        {
            try
            {
                MarginPagingModel mModel = new MarginPagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<MarginModel> margin = new MarginModel[] { }.AsQueryable();
                margin = context.Database.SqlQuery<MarginModel>("SELECT * FROM dbo.MarginMst").AsQueryable();
                if (filter.ProductCode != null && filter.ProductCode > 0)
                    margin = margin.Where(x => x.ProductCode == filter.ProductCode).AsQueryable();
                if (!string.IsNullOrEmpty(filter.BatchNo))
                    margin = margin.Where(x => x.BatchNo == filter.BatchNo).AsQueryable();
                if (!string.IsNullOrEmpty(filter.Expiry))
                    margin = margin.Where(x => x.Expiry == filter.Expiry).AsQueryable();

                // Get's No of Rows Count   
                int count = margin.Count();
                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = filter.pageNumber;
                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int PageSize = filter.pageSize;
                // Display TotalCount to Records to User  
                int TotalCount = count;
                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                // Returns List of Customer after applying Paging   
                var items = margin.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                mModel.MarginList = items;
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
        public MarginByBranchPagingModel GetMarginByBranch(MarginFilter filter)
        {
            try
            {
                MarginByBranchPagingModel mModel = new MarginByBranchPagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<MarginByBranchModel> margin = new MarginByBranchModel[] { }.AsQueryable();
                FINDCONDITION(filter); 
                FINDCOLUMN(filter);
                margin = context.Database.SqlQuery<MarginByBranchModel>("SELECT MarginMstID, P.ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, " + MarginRs + "  AS MarginRs, " + MarginPer + " AS MarginPer, " + PurchaseRs + "  AS PurchaseRs FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode " + WHERE).AsQueryable();
                if (filter.ProductCode != null && filter.ProductCode > 0)
                    margin = margin.Where(x => x.ProductCode == filter.ProductCode).AsQueryable();
                if (!string.IsNullOrEmpty(filter.BatchNo))
                    margin = margin.Where(x => x.BatchNo == filter.BatchNo).AsQueryable();
                if (!string.IsNullOrEmpty(filter.Expiry))
                    margin = margin.Where(x => x.Expiry == filter.Expiry).AsQueryable();

                // Get's No of Rows Count   
                int count = margin.Count();
                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = filter.pageNumber;
                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int PageSize = filter.pageSize;
                // Display TotalCount to Records to User  
                int TotalCount = count;
                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                // Returns List of Customer after applying Paging   
                var items = margin.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                mModel.MarginByBranchList = items;
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
