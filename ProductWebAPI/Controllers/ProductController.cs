﻿using System;
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
    public class ProductController : ApiController
    {
        private readonly APIResponse _api;
        private IProduct_Repository _IProduct_Repository;
        private IUser_Repository _IUser_Repository;
        private IError_Repository _IError_Repository; 
        public ProductController()
        {
            _api = new APIResponse();
            this._IProduct_Repository = new Product_Repository();
            this._IUser_Repository = new User_Repository();
            this._IError_Repository = new Error_Repository();
        }

        bool status = true;
        string message = string.Empty;

        ////This resource is For all types of role
        //[Authorize]
        //[HttpGet]
        //[Route("api/Product/getvalues")]
        //public IHttpActionResult GetValues()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims
        //                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        //    var LogTime = identity.Claims
        //              .FirstOrDefault(c => c.Type == "LoggedOn").Value;
        //    return Ok("Hello: " + identity.Name + ", " +
        //        "Your Role(s) are: " + string.Join(",", roles.ToList()) +
        //        "Your Login time is :" + LogTime);
        //}

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="type">Admin</param>
        /// <param name="type">User</param>
        /// <returns></returns>
        [HttpGet] 
        public HttpResponseMessage GetProducts()
        { 
            string returnData = "";
            List<ProductModel> productList = new List<ProductModel>();
            JilResponse<ProductModel> Response = new JilResponse<ProductModel>();
            try
            { 
                productList = _IProduct_Repository.ProductListCompanyWise();
                message = "Product Record Fetched!";
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetAllProducts", "Product/GetAllProducts");
            }

            Response.status = status;
            Response.Message = message;
            Response.data = productList;

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