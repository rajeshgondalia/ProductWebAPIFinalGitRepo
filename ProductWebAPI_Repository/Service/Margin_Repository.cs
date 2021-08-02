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

namespace ProductWebAPI_Repository.Service
{
    public class Margin_Repository : IMargin_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Margin_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Margin_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public MarginPagingModel GetAllMargin(MarginFilter filter)
        {
            try
            {
                MarginPagingModel mModel = new MarginPagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<MarginModel> margin = new MarginModel[] { }.AsQueryable();
                margin = context.Database.SqlQuery<MarginModel>("SELECT * FROM dbo.MarginMst").AsQueryable();
                if (filter.ProductCode > 0)
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
                mModel.PagingDetails = pModel;
                return mModel;

            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
                throw;
            }
        }
        public Margin_2_2PagingModel GetMargin_2_2(MarginFilter filter)
        {
            try
            {
                Margin_2_2PagingModel mModel = new Margin_2_2PagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<Margin_2_2_Model> margin = new Margin_2_2_Model[] { }.AsQueryable();
                margin = context.Database.SqlQuery<Margin_2_2_Model>("SELECT MarginMstID, P.ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, MSMarginRs, MSMarginPer, MSPurRate FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode").AsQueryable();
                if (filter.ProductCode > 0)
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

                mModel.Margin_2_2_List = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
                mModel.PagingDetails = pModel;
                return mModel; 
            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
                throw;
            }
        }

        public Margin_2_4PagingModel GetMargin_2_4(MarginFilter filter)
        {
            try
            {
                Margin_2_4PagingModel mModel = new Margin_2_4PagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<Margin_2_4_Model> margin = new Margin_2_4_Model[] { }.AsQueryable();
                margin = context.Database.SqlQuery<Margin_2_4_Model>("SELECT MarginMstID, P.ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, WSMarginRs, WSMarginPer, MSPurRate FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode").AsQueryable();
                if (filter.ProductCode > 0)
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
                mModel.Margin_2_4_List = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
                mModel.PagingDetails = pModel;
                return mModel;
            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
                throw;
            }
        }

        public Margin_2_6PagingModel GetMargin_2_6(MarginFilter filter)
        {
            try
            {
                Margin_2_6PagingModel mModel = new Margin_2_6PagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<Margin_2_6_Model> margin = new Margin_2_6_Model[] { }.AsQueryable();
                margin = context.Database.SqlQuery<Margin_2_6_Model>("SELECT MarginMstID, P.ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, OSMarginRs, OSMarginPer, MSPurRate FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode").AsQueryable();
                if (filter.ProductCode > 0)
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
                mModel.Margin_2_6_List = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
                mModel.PagingDetails = pModel;
                return mModel;
            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
                throw;
            }
        }

        public Margin_3_3PagingModel GetMargin_3_3(MarginFilter filter)
        {
            try
            {
                Margin_3_3PagingModel mModel = new Margin_3_3PagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<Margin_3_3_Model> margin = new Margin_3_3_Model[] { }.AsQueryable();
                margin = context.Database.SqlQuery<Margin_3_3_Model>("SELECT MarginMstID, P.ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, MFMarginRs, MFMarginPer, MSPurRs FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode").AsQueryable();
                if (filter.ProductCode > 0)
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
                mModel.Margin_3_3_List = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
                mModel.PagingDetails = pModel;
                return mModel;
            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
                throw;
            }
        }

        public Margin_3_5PagingModel GetMargin_3_5(MarginFilter filter)
        {
            try
            {
                Margin_3_5PagingModel mModel = new Margin_3_5PagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<Margin_3_5_Model> margin = new Margin_3_5_Model[] { }.AsQueryable();
                margin = context.Database.SqlQuery<Margin_3_5_Model>("SELECT MarginMstID, ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, WFMarginRs, WFMarginPer, MSPurRs FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode").AsQueryable();
                if (filter.ProductCode > 0)
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
                mModel.Margin_3_5_List = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
                mModel.PagingDetails = pModel;
                return mModel;
            }
            catch (Exception ex)
            {
                ex.SetLog(ex.Message);
                throw;
            }
        }

        public Margin_3_7PagingModel GetMargin_3_7(MarginFilter filter)
        {
            try
            {
                Margin_3_7PagingModel mModel = new Margin_3_7PagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<Margin_3_7_Model> margin = new Margin_3_7_Model[] { }.AsQueryable();
                margin = context.Database.SqlQuery<Margin_3_7_Model>("SELECT MarginMstID, ProductCode, P.ProductName, MKT.MktCompanyName, BatchNo, BatchNo, Expiry, MRP, SalRate, PurRate, GSTPer, GST, WithOutGST, CustSaveRs, CustSavePer, WFMarginRs, WFMarginPer, MSPurRs FROM dbo.MarginMst AS M INNER JOIN dbo.ProductMst AS P ON M.ProductCode = P.ProductCode INNER JOIN dbo.MktCompanyMst AS MKT ON P.MktCompanyCode = MKT.MktCompanyCode").AsQueryable();
                if (filter.ProductCode > 0)
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
                mModel.Margin_3_7_List = items;
                pModel.pageNumber = CurrentPage;
                pModel.TotalCount = TotalCount;
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
