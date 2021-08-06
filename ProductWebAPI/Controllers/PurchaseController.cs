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
    public class PurchaseController : ApiController
    {
        private readonly APIResponse _api;
        private IProduct_Repository _IProduct_Repository;
        private IUser_Repository _IUser_Repository;
        private IError_Repository _IError_Repository;
        public PurchaseController()
        {
            _api = new APIResponse();
            this._IProduct_Repository = new Product_Repository();
            this._IUser_Repository = new User_Repository();
            this._IError_Repository = new Error_Repository();
        }

        bool status = true;
        string message = string.Empty;
        [HttpPost]
        public HttpResponseMessage GetPurchaseOrders(PurchaseOrderFilterModel filter)
        {
            string returnData = "";
            //List<ProductPagingModel> productList = new List<ProductPagingModel>();
            PurchaseOrderPagingModel pModel = new PurchaseOrderPagingModel();
            JilResponse<PurchaseOrderPagingModel> Response = new JilResponse<PurchaseOrderPagingModel>();
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    pModel = _IProduct_Repository.PurchaseOrderList(filter);
                    message = "Purchase Order List Fetched!";
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetPurchaseOrders", "Product/GetPurchaseOrders");
            }

            Response.status = status;
            Response.Message = message;
            Response.Result = pModel;

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

