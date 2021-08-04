using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.Service;
using ProductWebAPI_Repository.ServiceContract;
using ProductWebAPI_Repository.DataServices;
using ProductWebAPI.Common;
using Microsoft.Ajax.Utilities;
using static ProductWebAPI.Common.JilFormatter;
using System.IO;
using System.Text;
using Jil;
using System.Security.Claims;
using ProductWebAPI_Repository.DTO;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;

namespace ProductWebAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly APIResponse _api;
        private IUser_Repository _IUser_Repository;
        private IOther_Repository _IOther_Repository;
        private IError_Repository _IError_Repository;

        public UserController()
        {
            _api = new APIResponse();
            this._IUser_Repository = new User_Repository();
            this._IOther_Repository = new Other_Repository();
            this._IError_Repository = new Error_Repository();
        }

        bool status = true;
        string message = string.Empty; 

        [HttpGet]       
        public HttpResponseMessage GetUserBranchDetails()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();

            string returnData = "";
            UserBranchModel userMaster = new UserBranchModel();
            JilResponse<UserBranchModel> Response = new JilResponse<UserBranchModel>();
            try
            {
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    userMaster = _IUser_Repository.GetUserBranchDetailsById(CrId);
                    status = true;
                    message = "Users Record Fetched!";
                }
                else
                {
                    status = false;
                    message = "UnAuthorized";
                } 
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetUserBranchDetails", "User/GetUserBranchDetails");
            }

            Response.status = status;
            Response.Message = message;
            Response.Result = userMaster;

            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(Response, output);
                returnData = output.ToString();
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        //[Route("contain")]
        public HttpResponseMessage GetContain()
        {
            string returnData = "";
            List<ContainModel> containMaster = new List<ContainModel>();
            JilResponse<ContainModel> Response = new JilResponse<ContainModel>();
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    containMaster = _IOther_Repository.GetAllContain();
                    status = true;
                    message = "Contain Record Fetched!";
                }
                else
                {
                    status = false;
                    message = "UnAuthorized";
                } 
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetContain", "contain");
            }
            Response.status = status;
            Response.Message = message;
            Response.data = containMaster;
            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(Response, output);
                returnData = output.ToString();
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet] 
        public HttpResponseMessage GetDisease()
        {
            string returnData = "";
            List<DiseaseModel> diseaseMaster = new List<DiseaseModel>();
            JilResponse<DiseaseModel> Response = new JilResponse<DiseaseModel>();
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    diseaseMaster = _IOther_Repository.GetAllDisease();
                    status = true;
                    message = "Disease Record Fetched!";
                }
                else
                {
                    status = false;
                    message = "UnAuthorized";
                } 
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetDisease", "disease");
            }
            Response.status = status;
            Response.Message = message;
            Response.data = diseaseMaster;
            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(Response, output);
                returnData = output.ToString();
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
            int CrId = Convert.ToInt32(UserId);

            _IUser_Repository.DeleteLoginInfo(CrId); 

            string returnData = string.Empty;
            JilResponse<string> Response = new JilResponse<string>();
            Response.status = true;
            Response.Message = "Logout Successfully!"; 
            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(Response, output);
                returnData = output.ToString();
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
