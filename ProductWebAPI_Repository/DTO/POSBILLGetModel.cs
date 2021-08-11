using ProductWebAPI_Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class POSBILLGetModel
    {
        // POSMst
        public int POSMstID { get; set; }
        public int BranchCode { get; set; }
        public int BillNo { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<byte> PaymentTypeCode { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public string Type { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public string PatientMobNo { get; set; }
        public string DiseaseName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorAddress { get; set; }
        public string DoctorMobNo { get; set; }
        public string DegreeName { get; set; }
        public Nullable<int> RemDays { get; set; }
        public Nullable<System.DateTime> RemDate { get; set; }
        public string Offer { get; set; }
        public string ChatID { get; set; }
        public Nullable<decimal> TotAmt { get; set; }
        public Nullable<decimal> PaidAmt { get; set; }
        public Nullable<decimal> PendAmt { get; set; }
        public Nullable<int> EditCount { get; set; }
        public string GST { get; set; }

        public List<POSDet> POSDELData { get; set; }

        public List<POSRetDet> POSRETDETData { get; set; }
       
    }
}
