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
        public StockController()
        {
            _api = new APIResponse();
            this._IError_Repository = new Error_Repository();
            this._IStock_Repository = new Stock_Repository();
        }
        bool status = true;
        string message = string.Empty;

        [HttpGet]
        public HttpResponseMessage GetStockiestStock(int productCode)
        {
            string returnData = "";
            JilResponse<StockModel> Response = new JilResponse<StockModel>();
            StockModel stock = new StockModel();

            try
            {
                stock = _IStock_Repository.GetStockStockist(productCode);
                message = "Stockiest Stock Record Fetched!";

                status = true;
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
        [HttpGet]
        public HttpResponseMessage GetGenmedStock(int productCode)
        {
            string returnData = "";
            JilResponse<StockModel> Response = new JilResponse<StockModel>();
            StockModel stock = new StockModel();
            try
            {
                stock = _IStock_Repository.GetStockGenmed(productCode);
                message = "Genmed Stock Record Fetched!";

                status = true;
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
