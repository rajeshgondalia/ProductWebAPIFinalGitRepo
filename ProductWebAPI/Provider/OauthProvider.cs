using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.Service;
using ProductWebAPI_Repository.ServiceContract; 
using ProductWebAPI_Repository.DataServices;

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
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var user = _IUser_Repository.UserLogin(context.UserName, context.Password);
            if (user != null)
            {
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(user.CrId);
                if (isAlreadyLogged)
                    context.SetError("Already Logged", "User is already logged in another device");
                else
                {
                    identity.AddClaim(new Claim("LoginName", user.LogInName));
                    identity.AddClaim(new Claim("CrName", user.CrName));
                    identity.AddClaim(new Claim("CounterMstID", user.CounterMstID.ToString()));
                    identity.AddClaim(new Claim("CrId", user.CrId.ToString()));
                    identity.AddClaim(new Claim("LogID", user.LogID.ToString()));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
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