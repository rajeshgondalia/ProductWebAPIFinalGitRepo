using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.Service;
using ProductWebAPI_Repository.ServiceContract; 
using ProductWebAPI_Repository.DataServices;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using ProductWebAPI.Common;
using Microsoft.Owin.Security.Cookies;

namespace ProductWebAPI.Provider
{
    public class OauthProvider : OAuthAuthorizationServerProvider
    {
        private IUser_Repository _IUser_Repository;

        public OauthProvider()
        {
            this._IUser_Repository = new User_Repository();
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        } 

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            CommonMethods cm = new CommonMethods();
            var claims = new List<Claim>();
            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var user = _IUser_Repository.UserLogin(context.UserName, context.Password);
            if (user != null)
            {
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(user.CrId);
                if (isAlreadyLogged)
                    context.SetError("Already Logged", "User is already logged in another device");
                else
                { 
                    // Insert LoginInfo record
                    LogInInfo info = new LogInInfo();
                    info.PcIPAddress = cm.GetIpValue();
                    info.PcID = "1";
                    info.Pcname = "1";
                    info.SDate = DateTime.UtcNow;
                    DateTime startTime = DateTime.Now;  
                    TimeSpan span = DateTime.Now.TimeOfDay; 
                    info.STime = span;
                    info.UserID = user.CrId;
                    info.UserName = user.LogInName;
                    info.Ever = 0;
                    _IUser_Repository.InsertLoginInfo(info); 

                    claims.Add(new Claim("LoginName", user.LogInName));
                    claims.Add(new Claim("CrName", user.CrName));
                    claims.Add(new Claim("CounterMstID", user.CounterMstID.ToString()));
                    claims.Add(new Claim("CrId", user.CrId.ToString()));
                    claims.Add(new Claim("LogID", user.LogID.ToString()));
                    claims.Add(new Claim("LoggedOn", DateTime.Now.ToString()));

                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie); 

                    await Task.Run(() => context.Validated(identity)); 
                }                
            }
            else
            {
                context.SetError("Wrong Crendtials", "Provided username and password is incorrect");
            }
        }         
    }
}