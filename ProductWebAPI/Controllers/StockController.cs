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
    public class StockController : ApiController
    {
        private readonly APIResponse _api;
        private IError_Repository _IError_Repository;
        private IStock_Repository _IStock_Repository;
        private IUser_Repository _IUser_Repository;
        public StockController()
        {
            _api = new APIResponse();
            this._IError_Repository = new Error_Repository();
            this._IStock_Repository = new Stock_Repository();
            this._IUser_Repository = new User_Repository();
        }
        bool status = true;
        string message = string.Empty;

        [HttpPost]
        public HttpResponseMessage GetStockiestStock(StockPostModal model)
        {
            string returnData = "";
            JilResponse<StockModel> Response = new JilResponse<StockModel>();
            StockModel stock = new StockModel();

            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    stock = _IStock_Repository.GetStockStockist(model.productCode);
                    message = "Stockiest Stock Record Fetched!";
                    status = true;
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetStockiestStock", "Stock/GetStockiestStock");
            }

            Response.status = status;
            Response.Message = message;
            Response.Result = stock;

            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(Response, output);
                returnData = output.ToString();
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        public HttpResponseMessage GetGenmedStock(StockPostModal model)
        {
            string returnData = "";
            JilResponse<StockModel> Response = new JilResponse<StockModel>();
            StockModel stock = new StockModel();
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    stock = _IStock_Repository.GetStockGenmed(model.productCode);
                    message = "Genmed Stock Record Fetched!";
                    status = true;
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetGenmedStock", "Stock/GetGenmedStock");
            }
            Response.status = status;
            Response.Message = message;
            Response.Result = stock;
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
