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
    public class User_Repository : IUser_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public User_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public User_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public IQueryable<CounterMst> GetAllUsers()
        {
            try
            {
                return context.CounterMsts.AsQueryable();
            }
            catch (Exception ex)
            {
                ex.SetLog("GetAllUsers,User_Repository");
                throw;
            }
        }

        public CounterMst UserLogin(string Username, string Password)
        {
            try
            {
                return context.CounterMsts.Where(x => x.LogInName.Trim() == Username.Trim() && x.CrPass.Trim() == Password.Trim() && x.Active == true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.SetLog("GetAllUsers,Repository");
                throw;
            }
        }
        public UserBranchModel GetUserBranchDetailsById(int CrId)
        {
            try
            {
                UserBranchModel UBModel = new UserBranchModel();
                // User Details
                var UserDetatils = GetAllUsers().Where(x => x.CrId == CrId).FirstOrDefault();
                UBModel.CrId = UserDetatils.CrId;
                UBModel.BranchCode = UserDetatils.BranchCode;
                UBModel.BranchTypeCode = UserDetatils.BranchTypeCode;
                UBModel.CrDel = UserDetatils.CrDel;
                UBModel.CrEdit = UserDetatils.CrEdit;
                UBModel.CrName = UserDetatils.CrName;
               // UBModel.CrPass = UserDetatils.CrPass;
                UBModel.LogInName = UserDetatils.LogInName;
                UBModel.MBranchCode = UserDetatils.MBranchCode;
                UBModel.PrintPreview = UserDetatils.PrintPreview;
                // Branch Type Master Details
                UBModel.BranchTypeList = (from b in context.BranchTypeMsts.Where(x => x.BranchTypeCode == UserDetatils.BranchTypeCode)
                                          select new BranchTypeModel
                                          {
                                              SubTypeCode = b.SubTypeCode,
                                              BranchTypeName = b.BranchTypeName
                                          }).ToList();
                //// Branch Master Details
                //UBModel.BranchList = (from b in context.BranchMsts.Where(x => x.BranchCode == UserDetatils.BranchCode)
                //                      select new BranchModel
                //                      {
                //                          BranchName = b.BranchName,
                //                          TaxType = b.TaxType,
                //                          Pharma = b.Pharma,
                //                          Wellness = b.Wellness,
                //                          Online = b.Online,
                //                          Other = b.Other,
                //                          Address = b.Address,
                //                          ShopAddress = b.ShopAddress,
                //                          Mob1 = b.Mob1,
                //                          GstNo = b.GstNo,
                //                          LanType = b.LanType
                //                      }).ToList();
                if (UBModel.BranchTypeList[0].SubTypeCode == 2)
                {
                    UBModel.BranchList = (from b in context.BranchMsts.Where(x => x.BranchCode == UserDetatils.BranchCode)
                                          select new BranchModel
                                          {
                                              BranchName = b.BranchName,
                                              ContactPerson = b.ContactPerson,
                                              Address = b.Address,
                                              BranchTypeCode = b.BranchTypeCode,
                                              AreaCode = b.AreaCode,
                                              Mob1 = b.Mob1,
                                              Mob2 = b.Mob2,
                                              EmailID = b.EmailID,
                                              Pwd = b.Pwd,
                                              DOB = b.DOB,
                                              AnniversaryDate = b.AnniversaryDate,
                                              GstNo = b.GstNo,
                                              PanNo = b.PanNo,
                                              TaxType = b.TaxType,
                                              LanType = b.LanType,
                                              BankCode = b.BankCode,
                                              BankAddress = b.BankAddress,
                                              IFSCCode = b.IFSCCode,
                                              BankAcNo = b.BankAcNo,
                                              OpeningBalance = b.OpeningBalance,
                                              DrugLicNo1 = b.DrugLicNo1,
                                              DrugLicNo2 = b.DrugLicNo2,
                                              DrugLicNo3 = b.DrugLicNo3,
                                              DrugLicNo4 = b.DrugLicNo4,
                                              ShopEstablishment = b.ShopEstablishment,
                                              Discount = b.Discount,
                                              CreditLimit = b.CreditLimit,
                                              FirmType = b.FirmType,
                                              Pharma = b.Pharma,
                                              Wellness = b.Wellness,
                                              Online = b.Online,
                                              Other = b.Other,
                                              Active = b.Active,
                                              BRCODE = b.BRCODE,
                                              Dist = b.Dist,
                                              ChatID = b.ChatID,
                                              ShopAddress = b.ShopAddress
                                          }).ToList();
                }
                if (UBModel.BranchTypeList[0].SubTypeCode == 3)
                {
                    UBModel.BranchList = (from b in context.BranchMsts.Where(x => x.BranchCode == UserDetatils.MBranchCode)
                                          select new BranchModel
                                          {
                                              BranchName = b.BranchName,
                                              ContactPerson = b.ContactPerson,
                                              Address = b.Address,
                                              BranchTypeCode = b.BranchTypeCode,
                                              AreaCode = b.AreaCode,
                                              Mob1 = b.Mob1,
                                              Mob2 = b.Mob2,
                                              EmailID = b.EmailID,
                                              Pwd = b.Pwd,
                                              DOB = b.DOB,
                                              AnniversaryDate = b.AnniversaryDate,
                                              GstNo = b.GstNo,
                                              PanNo = b.PanNo,
                                              TaxType = b.TaxType,
                                              LanType = b.LanType,
                                              BankCode = b.BankCode,
                                              BankAddress = b.BankAddress,
                                              IFSCCode = b.IFSCCode,
                                              BankAcNo = b.BankAcNo,
                                              OpeningBalance = b.OpeningBalance,
                                              DrugLicNo1 = b.DrugLicNo1,
                                              DrugLicNo2 = b.DrugLicNo2,
                                              DrugLicNo3 = b.DrugLicNo3,
                                              DrugLicNo4 = b.DrugLicNo4,
                                              ShopEstablishment = b.ShopEstablishment,
                                              Discount = b.Discount,
                                              CreditLimit = b.CreditLimit,
                                              FirmType = b.FirmType,
                                              Pharma = b.Pharma,
                                              Wellness = b.Wellness,
                                              Online = b.Online,
                                              Other = b.Other,
                                              Active = b.Active,
                                              BRCODE = b.BRCODE,
                                              Dist = b.Dist,
                                              ChatID = b.ChatID,
                                              ShopAddress = b.ShopAddress
                                          }).ToList();
                }
                return UBModel;
            }
            catch(Exception ex)
            {
                ex.SetLog("GetUserBranchDetails,Repository");
                throw;
            }
        }

        public IQueryable<LogInInfo> GetAllLogInfo()
        {
            try
            {
                return context.LogInInfoes.AsNoTracking().AsQueryable();
            }
            catch (Exception ex)
            {
                ex.SetLog("GetAllLogInfo,Repository");
                throw;
            }
        }
        public bool CheckUserAvailableInLoginInfo(int UserId)
        {
            return context.LogInInfoes.Any(x => x.UserID == UserId);
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
