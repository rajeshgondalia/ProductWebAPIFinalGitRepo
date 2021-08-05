using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class BillProductsFilterModel
    {
        public Nullable<int> BranchCode { get; set; }
        public Nullable<int> BillNo { get; set; }
        public int MstID { get; set; }
        public int SubTypeCode { get; set; }
        public string OrderType { get; set; }


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
