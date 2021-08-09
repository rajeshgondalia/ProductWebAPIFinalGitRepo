﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class POSDETModel
    {
        public int POSDetID { get; set; }
        public Nullable<int> POSMstID { get; set; }
        public Nullable<byte> Srno { get; set; }
        public Nullable<int> BCode { get; set; }
        public Nullable<int> ProductCode { get; set; }
        public string BatchNo { get; set; }
        public string Expiry { get; set; }
        public string Packing { get; set; }
        public Nullable<decimal> QtyInUnit { get; set; }
        public Nullable<decimal> QtyInStrip { get; set; }
        public Nullable<decimal> QtyInBox { get; set; }
        public Nullable<decimal> QtyInCartoon { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalRate { get; set; }
        public Nullable<decimal> SalAmt { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> DiscAmt { get; set; }
        public Nullable<byte> TaxCode { get; set; }
        public Nullable<decimal> Gst { get; set; }
        public Nullable<decimal> GstAmt { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> CAMT { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> SAMT { get; set; }
        public Nullable<bool> FreeProduct { get; set; }
        public Nullable<decimal> TotalAmt { get; set; }
        public Nullable<int> MarginMstID { get; set; }
        public Nullable<bool> Ret { get; set; }
        public int BranchCode { get; set; }
        public int BillNo { get; set; }
        public Nullable<decimal> ProfitRate { get; set; }
        public Nullable<decimal> ProfitAmt { get; set; }
    }
}