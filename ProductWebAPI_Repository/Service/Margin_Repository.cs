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

        public List<MarginModel> GetAllMargin(MarginFilter filter)
        {
            try
            {
                IQueryable<MarginModel> margin = new MarginModel[] { }.AsQueryable();
                if (filter.SubTypeCode == 1 && filter.BranchTypeCode == 1)
                {
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
                    return items;
                }

                if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 2)
                {

                }

                if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 4)
                {

                }

                if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 6)
                {

                }

                if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 3)
                {

                }

                if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 5)
                {

                }

                if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 7)
                {

                }
                return margin.ToList();
            }
            catch (Exception ex)
            {
                ex.SetLog("GetAllMargin,Repository");
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
