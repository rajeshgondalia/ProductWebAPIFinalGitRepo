using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{
    public class ProductModel
    {
        public int ProductMstID { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SubProductCode { get; set; }
        public Nullable<int> GenericCode { get; set; }
        public Nullable<int> MfgCompanyCode { get; set; }
        public Nullable<int> MktCompanyCode { get; set; } 
        public Nullable<int> DiseaseCode { get; set; }
        public Nullable<byte> StorageCode { get; set; }
        public Nullable<int> TabletTypeCode { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string HSNCode { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> NoOfQty { get; set; }
        public Nullable<decimal> TotQty { get; set; }
        public Nullable<byte> UnitCode { get; set; }
        public string Packing { get; set; }
        public Nullable<decimal> QtyBox { get; set; }
        public Nullable<decimal> QtyCartoon { get; set; }
        public Nullable<decimal> MaxStock { get; set; }
        public Nullable<decimal> MinStock { get; set; }
        public Nullable<decimal> OpeningStock { get; set; }
        public Nullable<int> SortID { get; set; }
        public Nullable<bool> Active { get; set; }   
        public Nullable<int> CompanyCode { get; set; }
        public string Contain { get; set; }
        public Nullable<bool> Pharma { get; set; }
        public Nullable<bool> Wellness { get; set; }
        public Nullable<bool> Online { get; set; }
        public Nullable<byte> ScheduleCode { get; set; }
        public Nullable<bool> DPCO { get; set; }
        public Nullable<System.DateTime> ProductDate { get; set; }
        public string FrontImage { get; set; }
        public string BackImage { get; set; }
        public string RightImage { get; set; }
        public string LeftImage { get; set; }
        public string DescImage { get; set; }  
        public string ProductDate1 { get; set; }
        public string SubProductName { get; set; }
        public Nullable<int> MainProductCode { get; set; }
        public string MainProductName { get; set; }
        public string MfgCompanyName { get; set; }
        public string MktCompanyName { get; set; }
        public Nullable<byte> DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string DiseaseName { get; set; }
        public Nullable<bool> DAlert { get; set; }
        public string StorageName { get; set; }
        public string TabletTypeName { get; set; }
        public string UnitName { get; set; }
        public string ScheduleName { get; set; }
        public Nullable<bool> Alert { get; set; }
    } 

    public class ProductPagingModel
    {
        public List<ProductModel> ProductList { get; set; }
        public PagingModel PagingDetails { get; set; }
    }
}
