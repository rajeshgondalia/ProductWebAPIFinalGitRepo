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
    public class POSBill_Repository : IPOSBill_Repository, IDisposable
    {
        private MED_GENMEDEntities context; 

        public POSBill_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public POSBill_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public List<POSBillResponseModel> InsertUpdatePOSBill(List<POSMstModel> postlist)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    List<POSBillResponseModel> posbillresponse = new List<POSBillResponseModel>();
                    if (postlist.Count > 0)
                    { 
                        foreach (var pm in postlist)
                        {
                            POSMst psmodel = new POSMst();
                            if (pm.Sflag == "UPDATE")
                            {
                                psmodel = context.POSMsts.Where(x => x.POSMstID == pm.POSMstID).FirstOrDefault();
                            }
                            psmodel.BillDate= pm.BillDate;
                            psmodel.BillNo = pm.BillNo;
                            psmodel.BranchCode = pm.BranchCode;
                            psmodel.ChatID = pm.ChatID;
                            psmodel.CompanyCode = pm.CompanyCode;
                            psmodel.DegreeName = pm.DegreeName;
                            psmodel.DiseaseName = pm.DiseaseName;
                            psmodel.DoctorAddress = pm.DoctorAddress;
                            psmodel.DoctorMobNo = pm.DoctorMobNo;
                            psmodel.DoctorName = pm.DoctorName;
                            psmodel.EditCount = pm.EditCount;
                            psmodel.Ever = pm.Ever;
                            psmodel.GST = pm.GST;
                            psmodel.LogID = pm.LogID;
                            psmodel.Offer = pm.Offer;
                            psmodel.PaidAmt = pm.PaidAmt;
                            psmodel.PatientAddress = pm.PatientAddress;
                            psmodel.PatientMobNo = pm.PatientMobNo;
                            psmodel.PatientName = pm.PatientName;
                            psmodel.PaymentTypeCode = pm.PaymentTypeCode;
                            psmodel.PcID = pm.PcID;
                            psmodel.PendAmt = pm.PendAmt;
                            psmodel.POSMstID = pm.POSMstID;
                            psmodel.RemDate = pm.RemDate;
                            psmodel.RemDays = pm.RemDays;
                            psmodel.Sdate = pm.Sdate;
                            psmodel.Sflag = pm.Sflag;
                            psmodel.TotAmt = pm.TotAmt;
                            psmodel.Type = pm.Type;
                            if (pm.Sflag == "UPDATE")
                            {
                                context.Entry(psmodel).State = EntityState.Modified;
                            }
                            else if (pm.Sflag == "ADD")
                            {
                                context.POSMsts.Add(psmodel);
                            }
                            context.SaveChanges();

                            foreach (var x in pm.POSDETData)
                            {
                                POSDet posdet = new POSDet();
                                if (pm.Sflag == "UPDATE")
                                {
                                    posdet = context.POSDets.Where(y => y.POSDetID == x.POSDetID).FirstOrDefault();
                                }
                                posdet.BatchNo = x.BatchNo;
                                posdet.BCode = x.BCode;
                                posdet.BillNo = x.BillNo;
                                posdet.BranchCode = x.BranchCode;
                                posdet.CAMT = x.CAMT;
                                posdet.CGST = x.CGST;
                                posdet.Disc = x.Disc;
                                posdet.DiscAmt = x.DiscAmt;
                                posdet.Expiry = x.Expiry;
                                posdet.FreeProduct = x.FreeProduct;
                                posdet.Gst = x.Gst;
                                posdet.GstAmt = x.GstAmt;
                                posdet.MarginMstID = x.MarginMstID;
                                posdet.MRP = x.MRP;
                                posdet.Packing = x.Packing;
                                posdet.POSDetID = x.POSDetID;
                                posdet.POSMstID = x.POSMstID;
                                posdet.ProductCode = x.ProductCode;
                                posdet.ProfitAmt = x.ProfitAmt;
                                posdet.ProfitRate = x.ProfitRate;
                                posdet.QtyInBox = x.QtyInBox;
                                posdet.QtyInCartoon = x.QtyInCartoon;
                                posdet.QtyInStrip = x.QtyInStrip;
                                posdet.QtyInUnit = x.QtyInUnit;
                                posdet.Ret = x.Ret;
                                posdet.SalAmt = x.SalAmt;
                                posdet.SalRate = x.SalRate;
                                posdet.SAMT = x.SAMT;
                                posdet.SGST = x.SGST;
                                posdet.Srno = x.Srno;
                                posdet.TaxCode = x.TaxCode;
                                posdet.TotalAmt = x.TotalAmt;
                                if (pm.Sflag == "UPDATE")
                                {
                                    context.Entry(posdet).State = EntityState.Modified;
                                }
                                else if (pm.Sflag == "ADD")
                                {
                                    context.POSDets.Add(posdet);
                                }
                                context.SaveChanges();
                            }

                            foreach (var x in pm.POSRETDETData)
                            {
                                POSRetDet posrefdet = new POSRetDet();
                                if (pm.Sflag == "UPDATE")
                                {
                                    posrefdet = context.POSRetDets.Where(y => y.POSRetDetID == x.POSRetDetID).FirstOrDefault(); 
                                }
                                posrefdet.BatchNo = x.BatchNo;
                                posrefdet.BCode = x.BCode;
                                posrefdet.BillNo = x.BillNo;
                                posrefdet.BranchCode = x.BranchCode;
                                posrefdet.CAMT = x.CAMT;
                                posrefdet.CGST = x.CGST;
                                posrefdet.Disc = x.Disc;
                                posrefdet.DiscAmt = x.DiscAmt;
                                posrefdet.Expiry = x.Expiry;
                                posrefdet.FreeProduct = x.FreeProduct;
                                posrefdet.GstAmt = x.GstAmt;
                                posrefdet.Gst = x.Gst;
                                posrefdet.MarginMstID = x.MarginMstID;
                                posrefdet.MRP = x.MRP;
                                posrefdet.Packing = x.Packing;
                                posrefdet.POSMstID = x.POSMstID;
                                posrefdet.POSRetDetID = x.POSRetDetID;
                                posrefdet.ProductCode = x.ProductCode;
                                posrefdet.ProfitAmt = x.ProfitAmt;
                                posrefdet.ProfitRate = x.ProfitRate;
                                posrefdet.QtyInBox = x.QtyInBox;
                                posrefdet.QtyInCartoon = x.QtyInCartoon;
                                posrefdet.QtyInStrip = x.QtyInStrip;
                                posrefdet.QtyInUnit = x.QtyInUnit;
                                posrefdet.RetBillNo = x.RetBillNo;
                                posrefdet.SalAmt = x.SalAmt;
                                posrefdet.SalRate = x.SalRate;
                                posrefdet.SAMT = x.SAMT;
                                posrefdet.SGST = x.SGST;
                                posrefdet.Srno = x.Srno;
                                posrefdet.TaxCode = x.TaxCode;
                                posrefdet.TotalAmt = x.TotalAmt; 

                                if (pm.Sflag == "UPDATE")
                                {
                                    context.Entry(posrefdet).State = EntityState.Modified;
                                }
                                else if (pm.Sflag == "ADD")
                                {
                                    context.POSRetDets.Add(posrefdet);
                                }
                                context.SaveChanges();
                            }
                        }
                        dbContextTransaction.Commit();
                        posbillresponse = (from a in postlist
                                           select new POSBillResponseModel
                                           {
                                               BillNo = a.BillNo,
                                               BranchCode = a.BranchCode,
                                               POSMstID = a.POSMstID
                                           }).ToList();
                    }  
                    return posbillresponse;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    ex.SetLog(ex.Message);
                    throw;
                }
            } 
        }

        public List<POSBILLGetModel> GetAllPOSBill(POSBillFilter filter)
        {
            try
            {
                List<POSBILLGetModel> posbilllist = new List<POSBILLGetModel>();
                string str = "SELECT  TOP (100) PERCENT dbo.POSMst.POSMstID, dbo.POSMst.BranchCode, dbo.POSMst.BillNo, dbo.POSMst.BillDate, dbo.POSMst.PaymentTypeCode, dbo.POSMst.Sflag, dbo.POSMst.Sdate, dbo.POSMst.LogID, dbo.POSMst.PcID, " +
                         "dbo.POSMst.Ever, dbo.POSMst.CompanyCode, dbo.POSMst.Type, dbo.POSMst.PatientName, dbo.POSMst.PatientAddress, dbo.POSMst.PatientMobNo, dbo.POSMst.DiseaseName, dbo.POSMst.DoctorName, " +
                         "dbo.POSMst.DoctorAddress, dbo.POSMst.DoctorMobNo, dbo.POSMst.DegreeName, dbo.POSMst.RemDays, dbo.POSMst.RemDate, dbo.POSMst.Offer, dbo.POSMst.ChatID, dbo.POSMst.TotAmt, dbo.POSMst.PaidAmt, " +
                         "dbo.POSMst.PendAmt, dbo.POSMst.EditCount, dbo.POSMst.GST, dbo.POSDet.POSDetID, dbo.POSDet.POSMstID AS DPOSMstID, dbo.POSDet.Srno, dbo.POSDet.BCode, dbo.POSDet.ProductCode, dbo.POSDet.BatchNo, " +
                         "dbo.POSDet.Expiry, dbo.POSDet.Packing, dbo.POSDet.QtyInUnit, dbo.POSDet.QtyInStrip, dbo.POSDet.QtyInBox, dbo.POSDet.QtyInCartoon, dbo.POSDet.MRP, dbo.POSDet.SalRate, dbo.POSDet.SalAmt, dbo.POSDet.Disc, " +
                         "dbo.POSDet.DiscAmt, dbo.POSDet.TaxCode, dbo.POSDet.Gst AS IGST, dbo.POSDet.GstAmt, dbo.POSDet.CGST, dbo.POSDet.CAMT, dbo.POSDet.SGST, dbo.POSDet.SAMT, dbo.POSDet.FreeProduct, dbo.POSDet.TotalAmt, " +
                         "dbo.POSDet.MarginMstID, dbo.POSDet.Ret, dbo.POSDet.BranchCode AS DBranchCode, dbo.POSDet.BillNo AS DBillNo, dbo.POSDet.ProfitRate, dbo.POSDet.ProfitAmt, dbo.POSRetDet.POSRetDetID, " +
                         "dbo.POSRetDet.POSMstID AS RPOSMstID, dbo.POSRetDet.RetBillNo, dbo.POSRetDet.Srno AS RSrno, dbo.POSRetDet.BCode AS RBCode, dbo.POSRetDet.ProductCode AS RProductCode, dbo.POSRetDet.BatchNo AS RBatchNo, " +
                         "dbo.POSRetDet.Expiry AS Expr10, dbo.POSRetDet.Packing AS RExpiry, dbo.POSRetDet.QtyInUnit AS RQtyInUnit, dbo.POSRetDet.QtyInStrip AS RQtyInStrip, dbo.POSRetDet.QtyInBox AS RQtyInBox, " +
                         "dbo.POSRetDet.QtyInCartoon AS RQtyInCartoon, dbo.POSRetDet.MRP AS RMRP, dbo.POSRetDet.SalRate AS RSalRate, dbo.POSRetDet.SalAmt AS RSalAmt, dbo.POSRetDet.Disc AS RDisc, dbo.POSRetDet.DiscAmt AS RDiscAmt, " +
                         "dbo.POSRetDet.TaxCode AS RTaxCode, dbo.POSRetDet.Gst AS RGst, dbo.POSRetDet.GstAmt AS RGstAmt, dbo.POSRetDet.CGST AS RCGST, dbo.POSRetDet.CAMT AS RCAMT, dbo.POSRetDet.SGST AS RSGST, " +
                         "dbo.POSRetDet.SAMT AS RSAMT, dbo.POSRetDet.FreeProduct AS RFreeProduct, dbo.POSRetDet.TotalAmt AS RTotalAmt, dbo.POSRetDet.MarginMstID AS RMarginMstID, dbo.POSRetDet.BranchCode AS RBranchCode, " +
                         "dbo.POSRetDet.BillNo AS RBillNo, dbo.POSRetDet.ProfitRate AS RProfitRate, dbo.POSRetDet.ProfitAmt AS RProfitAmt " +
                         " FROM            dbo.POSMst LEFT OUTER JOIN " +
                         "dbo.POSRetDet ON dbo.POSMst.POSMstID = dbo.POSRetDet.POSMstID AND dbo.POSMst.BranchCode = dbo.POSRetDet.BranchCode AND dbo.POSMst.BillNo = dbo.POSRetDet.BillNo LEFT OUTER JOIN " +
                         "dbo.POSDet ON dbo.POSMst.POSMstID = dbo.POSDet.POSMstID AND dbo.POSMst.BranchCode = dbo.POSDet.BranchCode AND dbo.POSMst.BillNo = dbo.POSDet.BillNo " +
"WHERE  dbo.POSMst.BranchCode = " + filter.BranchCode + " or CONVERT(date, dbo.POSMst.BillDate) between CONVERT(date, '" + filter.FromDate + "') and CONVERT(date, '" + filter.ToDate + "') " +
"ORDER BY dbo.POSMst.BillDate, dbo.POSMst.BillNo";

                posbilllist = context.Database.SqlQuery<POSBILLGetModel>("SELECT  TOP (100) PERCENT dbo.POSMst.POSMstID, dbo.POSMst.BranchCode, dbo.POSMst.BillNo, dbo.POSMst.BillDate, dbo.POSMst.PaymentTypeCode, dbo.POSMst.Sflag, dbo.POSMst.Sdate, dbo.POSMst.LogID, dbo.POSMst.PcID, " +
                         "dbo.POSMst.Ever, dbo.POSMst.CompanyCode, dbo.POSMst.Type, dbo.POSMst.PatientName, dbo.POSMst.PatientAddress, dbo.POSMst.PatientMobNo, dbo.POSMst.DiseaseName, dbo.POSMst.DoctorName, " +
                         "dbo.POSMst.DoctorAddress, dbo.POSMst.DoctorMobNo, dbo.POSMst.DegreeName, dbo.POSMst.RemDays, dbo.POSMst.RemDate, dbo.POSMst.Offer, dbo.POSMst.ChatID, dbo.POSMst.TotAmt, dbo.POSMst.PaidAmt, " +
                         "dbo.POSMst.PendAmt, dbo.POSMst.EditCount, dbo.POSMst.GST, dbo.POSDet.POSDetID, dbo.POSDet.POSMstID AS DPOSMstID, dbo.POSDet.Srno, dbo.POSDet.BCode, dbo.POSDet.ProductCode, dbo.POSDet.BatchNo, " +
                         "dbo.POSDet.Expiry, dbo.POSDet.Packing, dbo.POSDet.QtyInUnit, dbo.POSDet.QtyInStrip, dbo.POSDet.QtyInBox, dbo.POSDet.QtyInCartoon, dbo.POSDet.MRP, dbo.POSDet.SalRate, dbo.POSDet.SalAmt, dbo.POSDet.Disc, " +
                         "dbo.POSDet.DiscAmt, dbo.POSDet.TaxCode, dbo.POSDet.Gst AS IGST, dbo.POSDet.GstAmt, dbo.POSDet.CGST, dbo.POSDet.CAMT, dbo.POSDet.SGST, dbo.POSDet.SAMT, dbo.POSDet.FreeProduct, dbo.POSDet.TotalAmt, " +
                         "dbo.POSDet.MarginMstID, dbo.POSDet.Ret, dbo.POSDet.BranchCode AS DBranchCode, dbo.POSDet.BillNo AS DBillNo, dbo.POSDet.ProfitRate, dbo.POSDet.ProfitAmt, dbo.POSRetDet.POSRetDetID, " +
                         "dbo.POSRetDet.POSMstID AS RPOSMstID, dbo.POSRetDet.RetBillNo, dbo.POSRetDet.Srno AS RSrno, dbo.POSRetDet.BCode AS RBCode, dbo.POSRetDet.ProductCode AS RProductCode, dbo.POSRetDet.BatchNo AS RBatchNo, " +
                         "dbo.POSRetDet.Expiry AS Expr10, dbo.POSRetDet.Packing AS RExpiry, dbo.POSRetDet.QtyInUnit AS RQtyInUnit, dbo.POSRetDet.QtyInStrip AS RQtyInStrip, dbo.POSRetDet.QtyInBox AS RQtyInBox, " +
                         "dbo.POSRetDet.QtyInCartoon AS RQtyInCartoon, dbo.POSRetDet.MRP AS RMRP, dbo.POSRetDet.SalRate AS RSalRate, dbo.POSRetDet.SalAmt AS RSalAmt, dbo.POSRetDet.Disc AS RDisc, dbo.POSRetDet.DiscAmt AS RDiscAmt, " +
                         "dbo.POSRetDet.TaxCode AS RTaxCode, dbo.POSRetDet.Gst AS RGst, dbo.POSRetDet.GstAmt AS RGstAmt, dbo.POSRetDet.CGST AS RCGST, dbo.POSRetDet.CAMT AS RCAMT, dbo.POSRetDet.SGST AS RSGST, " +
                         "dbo.POSRetDet.SAMT AS RSAMT, dbo.POSRetDet.FreeProduct AS RFreeProduct, dbo.POSRetDet.TotalAmt AS RTotalAmt, dbo.POSRetDet.MarginMstID AS RMarginMstID, dbo.POSRetDet.BranchCode AS RBranchCode, " +
                         "dbo.POSRetDet.BillNo AS RBillNo, dbo.POSRetDet.ProfitRate AS RProfitRate, dbo.POSRetDet.ProfitAmt AS RProfitAmt " +
                         " FROM            dbo.POSMst LEFT OUTER JOIN " +
                         "dbo.POSRetDet ON dbo.POSMst.POSMstID = dbo.POSRetDet.POSMstID AND dbo.POSMst.BranchCode = dbo.POSRetDet.BranchCode AND dbo.POSMst.BillNo = dbo.POSRetDet.BillNo LEFT OUTER JOIN " +
                         "dbo.POSDet ON dbo.POSMst.POSMstID = dbo.POSDet.POSMstID AND dbo.POSMst.BranchCode = dbo.POSDet.BranchCode AND dbo.POSMst.BillNo = dbo.POSDet.BillNo " +
"WHERE  dbo.POSMst.BranchCode = " + filter.BranchCode + " or CONVERT(date, dbo.POSMst.BillDate) between CONVERT(date, '" + filter.FromDate + "') and CONVERT(date, '" + filter.ToDate + "') " +
"ORDER BY dbo.POSMst.BillDate, dbo.POSMst.BillNo").ToList();
                return posbilllist;
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
