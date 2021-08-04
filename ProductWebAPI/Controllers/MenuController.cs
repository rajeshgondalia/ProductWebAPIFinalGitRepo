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

namespace ProductWebAPI.Controllers
{
    [Authorize]
    public class MenuController : ApiController
    {
        private readonly APIResponse _api;
        private IMenu_Repository _IMenu_Repository;
        private IError_Repository _IError_Repository;
        private IUser_Repository _IUser_Repository;

        public MenuController()
        {
            _api = new APIResponse();
            this._IMenu_Repository = new Menu_Repository();
            this._IError_Repository = new Error_Repository();
            this._IUser_Repository = new User_Repository();
        }

        bool status = true;
        string message = string.Empty;

        [HttpGet]
        public HttpResponseMessage GetMenuSubMenuListById()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
            int CrId = Convert.ToInt32(UserId);
            string returnData = "";
            List<MainMenuModel> menulist = new List<MainMenuModel>();
            JilResponse<MainMenuModel> Response = new JilResponse<MainMenuModel>();
            try
            {
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    menulist = this._IMenu_Repository.MenuList(CrId);
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetMenuSubMenuListById", "User/GetMenuSubMenuListById");
            }
            Response.status = status;
            Response.Message = message;
            Response.data = menulist;

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
