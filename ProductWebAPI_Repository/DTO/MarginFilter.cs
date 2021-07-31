using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class MarginFilter
    {
        public int SubTypeCode { get; set; }
        public int BranchTypeCode { get; set; }
        public int ProductCode { get; set; }
        public string BatchNo { get; set; }
        public string Expiry { get; set; }

        #region PAGINATION
        const int maxPageSize = 20;
        public int pageNumber { get; set; } = 1;
        public int _pageSize { get; set; } = 10;
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
