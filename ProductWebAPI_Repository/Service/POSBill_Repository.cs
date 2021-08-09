﻿using System;
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
