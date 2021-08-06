using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class PurchaseOrderFilterModel
    {
        public int SubTypeCode { get; set; }
        public int BranchTypeCode { get; set; }
        public bool Pharma { get; set; }
        public bool Wellness { get; set; }
        public bool Online { get; set; }

        #region PAGINATION
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
        #endregion
    }
}
