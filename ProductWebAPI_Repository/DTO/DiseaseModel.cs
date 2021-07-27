using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class DiseaseModel
    {
        public int DiseaseMstID { get; set; }
        public int DiseaseCode { get; set; }
        public string DiseaseName { get; set; }
        public Nullable<int> SortID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Alert { get; set; }
        public string Sflag { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> LogID { get; set; }
        public string PcID { get; set; }
        public Nullable<int> Ever { get; set; }
        public Nullable<int> CompanyCode { get; set; }
    }
}
