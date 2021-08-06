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

        public static string DetID = string.Empty;
        public static string MstID = string.Empty;
        public static string OrderDetID = string.Empty;
        public static string WHERE = string.Empty;
        public static string BranchCode = string.Empty;
        public static string TableNameA = string.Empty;
        public static string TableNameB = string.Empty;

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

        public int UpdateBillStatus(BillStatusModel model)
        {
            if (model.SubTypeCode == 2)
            {
                var obj = new GOrderConfirmMst()
                {
                    Type = model.Type,
                    PurchaseOrderMstID = model.OrderMstID,
                    POCode = model.POCode,
                    GOrderConfirmDate = DateTime.Now,
                    Sflag = "I",
                    Sdate = DateTime.Now,
                    LogID = model.LogID,
                    PcID = model.PcID,
                    Ever = model.Ever,
                    BranchCode = model.BranchCode,
                    CompanyCode = 1,
                    Rec = 0
                };
                context.GOrderConfirmMsts.Add(obj);
                context.SaveChanges();
                return obj.GOrderConfirmMstID;
            }
            else if (model.SubTypeCode == 2)
            {
                var obj = new Med_GOrderConfirmMst()
                {
                    Type = model.Type,
                    Med_PurchaseOrderMstID = model.OrderMstID,
                    POCode = model.POCode,
                    Med_GOrderConfirmDate = DateTime.Now,
                    Sflag = "I",
                    Sdate = DateTime.Now,
                    LogID = model.LogID,
                    PcID = model.PcID,
                    Ever = model.Ever,
                    BranchCode = model.BranchCode,
                    CompanyCode = 1,
                    Rec = 0
                };
                context.Med_GOrderConfirmMst.Add(obj);
                context.SaveChanges();
                return obj.Med_GOrderConfirmMstID;
            }
            return 0;
        }

        public BillProductPagingModel GetBillProducts(BillProductsFilterModel filter)
        {
            try
            {
                BillProductPagingModel mModel = new BillProductPagingModel();
                PagingModel pModel = new PagingModel();
                IQueryable<BillProductModel> bill = new BillProductModel[] { }.AsQueryable();
                FINDCONDITION(filter);
                FINDCOLUMN(filter);
                bill = context.Database.SqlQuery<BillProductModel>("SELECT D." + DetID + " AS DetID, D." + MstID + " AS MstID, D." + OrderDetID + " AS OrderDetID, D.Srno, D.ProductCode, D.BatchNo, D.Expiry, D.GodownCode, D.RackCode, D.Box, D.UnitCode, D.Packing, D.Qty, D.StripQty, D.BoxQty, D.CartoonQty, D.FreeQtyInUnit, D.FreeQtyInStrip, D.FreeQtyInBox, D.FreeQtyInCartoon, D.MRP, D.SalRate, D.SalAmount, D.DiscPer, D.DiscAmt, D.NetRate, D.MarginMstID, D.TaxCode, D.GST, D.GstAmt, D.CGST, D.CAMT, D.SGST, D.SAMT, D.TotalAmt, D.FreeProduct, D.Description, D.BCode FROM dbo." + TableNameB + "Sale" + TableNameA + "Det AS D INNER JOIN dbo.ProductMst AS P ON D.ProductCode = P.ProductCode INNER JOIN dbo." + TableNameB + "Sale" + TableNameA + "Mst AS M ON D.SaleInvoiceMstID = M.SaleInvoiceMstID INNER JOIN dbo.MktCompanyMst AS C ON P.MktCompanyCode = C.MktCompanyCode " + WHERE + " ORDER BY D.Srno").AsQueryable();
                // Get's No of Rows Count   
                int count = bill.Count();
                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = filter.pageNumber;
                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int PageSize = filter.pageSize;
                // Display TotalCount to Records to User  
                int TotalCount = count;
                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                // Returns List of Customer after applying Paging   
                var items = bill.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                mModel.BillProductList = items;
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
        public static void FINDCOLUMN(BillProductsFilterModel filter)
        {
            DetID = string.Empty; MstID = string.Empty; OrderDetID = string.Empty; TableNameA = string.Empty; TableNameB = string.Empty;
            if (filter.SubTypeCode == 2 && filter.OrderType.ToUpper() == @"ORDER") { DetID = "SaleInvoiceDetID"; MstID = "SaleInvoiceMstID"; OrderDetID = "PurchaseOrderDetID"; TableNameA = "Invoice"; }
            else if (filter.SubTypeCode == 2 && filter.OrderType.ToUpper() == @"RETURN") { DetID = "SaleReturnDetID"; MstID = "SaleReturnMstID"; OrderDetID = "PurchaseOrderDetID"; TableNameA = "Return"; }
            else if (filter.SubTypeCode == 3 && filter.OrderType.ToUpper() == @"ORDER") { DetID = "Stockist_SaleInvoiceDetID"; MstID = "Stockist_SaleInvoiceMstID"; OrderDetID = "Med_PurchaseOrderDetID"; TableNameA = "Invoice"; TableNameB = "Stockist_"; }
            else if (filter.SubTypeCode == 3 && filter.OrderType.ToUpper() == @"RETURN") { DetID = "Stockist_SaleReturnDetID"; MstID = "Stockist_SaleReturnMstID"; OrderDetID = "Med_PurchaseOrderDetID"; TableNameA = "Return"; TableNameB = "Stockist_"; }
        }
        public static void ChkStr()
        {
            if (WHERE == null)
            {
                WHERE = WHERE + " WHERE (";
            }
            else if (WHERE != null)
            {
                WHERE = WHERE + " OR ";
            }
        }
        public static void FINDCONDITION(BillProductsFilterModel filter)
        {
            WHERE = null;
            if (filter.BranchCode > 0) { ChkStr(); WHERE = WHERE + (filter.SubTypeCode == 2 ? ("M.BranchCode = " + filter.BranchCode) : ("M.MBranchCode = " + filter.BranchCode)); }
            if (filter.BillNo > 0) { ChkStr(); WHERE = WHERE + "M.BillNo = " + filter.BillNo; }
            if (filter.MstID > 0) { ChkStr(); WHERE = WHERE + "D." + TableNameB + "Sale" + TableNameA + "MstID = " + filter.MstID; }
            if (WHERE == null) { WHERE = "WHERE " + (filter.SubTypeCode == 2 ? ("M.BranchCode = " + filter.BranchCode) : ("M.MBranchCode = " + filter.BranchCode)) + " AND M.BillNo = 0 AND D." + TableNameB + "Sale" + TableNameA + "MstID = 0 "; }
            else { WHERE = WHERE + ")"; }
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
