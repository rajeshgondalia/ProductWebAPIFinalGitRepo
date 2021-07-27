using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.DTO;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IUser_Repository : IDisposable
    {
        IQueryable<CounterMst> GetAllUsers();
        CounterMst UserLogin(string Username, string Password);
        UserBranchModel GetUserBranchDetailsById(int CrId); 
        IQueryable<LogInInfo> GetAllLogInfo();
        bool CheckUserAvailableInLoginInfo(int UserId);
    }
}
