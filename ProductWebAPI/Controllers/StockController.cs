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
        public StockController()
        {
            _api = new APIResponse();
            this._IError_Repository = new Error_Repository();
        }
        bool status = true;
        string message = string.Empty;

        [HttpGet]
        public HttpResponseMessage GetStockiestStock()
        {
            string returnData = "";
            JilResponse<ProductModel> Response = new JilResponse<ProductModel>();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetGenmedStock()
        {
            string returnData = "";
            JilResponse<ProductModel> Response = new JilResponse<ProductModel>();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return response;
        }
    }   
}
