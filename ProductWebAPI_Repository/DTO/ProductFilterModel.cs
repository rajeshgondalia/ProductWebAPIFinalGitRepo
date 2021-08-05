using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class ProductFilterModel
    {
        public Nullable<int> ProductCode { get; set; }
        public Nullable<int> MfgCompanyCode { get; set; }
        public Nullable<int> MktCompanyCode { get; set; }
        public Nullable<int> TabletTypeCode { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string HSNCode { get; set; }
        public  Nullable<bool> Active { get; set; }
        public string Contain { get; set; }
        public  Nullable<bool> Pharma { get; set; }
        public  Nullable<bool> Wellness { get; set; }
        public  Nullable<bool> Online { get; set; }
        public DateTime? ProductDate { get; set; }
        public Nullable<int> ScheduleCode { get; set; }

        const int maxPageSize = 500;

        public int pageNumber { get; set; } = 1;

        public int _pageSize { get; set; } = 300;

        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    } 
}
