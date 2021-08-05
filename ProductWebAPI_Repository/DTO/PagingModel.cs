using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class PagingModel
    {
        public int pageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
