using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class ContainModel
    {
        public int ContainMstID { get; set; }
        public string ContainName { get; set; }
        public Nullable<byte> ScheduleCode { get; set; }
        public Nullable<bool> DPCO { get; set; }
    }
}
