using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.ServiceContract;
using System.Data.Entity;
using ProductWebAPI_Repository.Data;
using System.Data;
using System.Data.SqlClient;
using ProductWebAPI_Repository.DataServices;
using ProductWebAPI_Repository.DTO;

namespace ProductWebAPI_Repository.Service
{
    public class Product_Repository : IProduct_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Product_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Product_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public IQueryable<ProductModel> ProductListCompanyWise()
        {
            try
            { 
                var prod = (from P in context.ProductMsts.AsNoTracking().Where(x => x.Active == true)
                        join MF in context.MfgCompanyMsts on P.MfgCompanyCode equals MF.MfgCompanyCode
                        join MK in context.MktCompanyMsts on P.MktCompanyCode equals MK.MktCompanyCode
                        join D in context.DiseaseMsts on P.DiseaseCode equals D.DiseaseCode
                        join S in context.SubProductMsts on P.SubProductCode equals S.SubProductCode
                        join T in context.TabletTypeMsts on P.TabletTypeCode equals T.TabletTypeCode
                        join ST in context.StorageMsts on P.StorageCode equals ST.StorageCode
                        join U in context.UnitMsts on P.UnitCode equals U.UnitCode
                        join G in context.GenericMsts on P.GenericCode equals G.GenericCode
                        join GG in context.GenericGroupMsts on G.GenericGroupCode equals GG.GenericGroupCode
                        select new ProductModel
                        {
                            ProductMstID = P.ProductMstID,
                            ProductCode = P.ProductCode,
                            ProductName = P.ProductName,
                            SubProductCode = P.SubProductCode,
                            GenericCode = P.GenericCode,
                            MfgCompanyCode = P.MfgCompanyCode,
                            MktCompanyCode = P.MktCompanyCode,
                            MfgCompanyCode1 = P.MfgCompanyCode1,
                            DiseaseCode = P.DiseaseCode,
                            StorageCode = P.StorageCode,
                            TabletTypeCode = P.TabletTypeCode,
                            Tax = P.Tax,
                            HSNCode = P.HSNCode,
                            Qty = P.Qty,
                            NoOfQty = P.NoOfQty,
                            TotQty = P.TotQty,
                            UnitCode = P.UnitCode,
                            Packing = P.Packing,
                            QtyBox = P.QtyBox,
                            QtyCartoon = P.QtyCartoon,
                            MaxStock = P.MaxStock,
                            MinStock = P.MinStock,
                            OpeningStock = P.OpeningStock,
                            SortID = P.SortID,
                            Active = P.Active,
                            Sflag = P.Sflag,
                            //Sdate = DateTime.ParseExact(Convert.ToString(P.Sdate), "dd/MM/yyyy", null),
                            Sdate = P.Sdate,
                            LogID = P.LogID,
                            PcID = P.PcID,
                            Ever = P.Ever,
                            CompanyCode = P.CompanyCode,
                            Contain = P.Contain,
                            Pharma = P.Pharma,
                            Wellness = P.Wellness,
                            Online = P.Online,
                            ScheduleCode = P.ScheduleCode,
                            DPCO = P.DPCO,
                            //ProductDate = DateTime.ParseExact(Convert.ToString(P.ProductDate), "dd/MM/yyyy", null), 
                            ProductDate = P.ProductDate,
                            FrontImage = P.FrontImage,
                            BackImage = P.BackImage,
                            RightImage = P.RightImage,
                            LeftImage = P.LeftImage,
                            DescImage = P.DescImage
                        }).AsQueryable();
                return prod;
            }
            catch (Exception ex)
            {
                ex.SetLog("ProductListCompanyWise,Repository");
                throw;
            } 
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
