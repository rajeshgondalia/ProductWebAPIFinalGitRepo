using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class ProductFilterModel
    {
        public int ProductCode { get; set; }
        public int MfgCompanyCode { get; set; }
        public int MktCompanyCode { get; set; }
        public int TabletTypeCode { get; set; }
        public decimal Tax { get; set; }
        public string HSNCode { get; set; }
        public bool Active { get; set; }
        public string Contain { get; set; }
        public bool Pharma { get; set; }
        public bool Wellness { get; set; }
        public bool Online { get; set; }
        public DateTime ProductDate { get; set; }
        public int ScheduleCode { get; set; } 
    }
}
