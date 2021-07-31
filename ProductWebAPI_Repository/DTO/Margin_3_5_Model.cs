﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class Margin_3_5_Model
    {
        public int MarginMstID { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string MktCompanyName { get; set; }
        public string BatchNo { get; set; }
        public string Expiry { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalRate { get; set; }
        public Nullable<decimal> PurRate { get; set; }
        public Nullable<decimal> GSTPer { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> WithOutGST { get; set; }
        public Nullable<decimal> CustSaveRs { get; set; }
        public Nullable<decimal> CustSavePer { get; set; }
        public Nullable<decimal> WFMarginRs { get; set; }
        public Nullable<decimal> WFMarginPer { get; set; }
        public Nullable<decimal> MSPurRs { get; set; }
    }
}
