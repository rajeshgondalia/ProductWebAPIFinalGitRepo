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
    public class MarginController : ApiController
    {
        private readonly APIResponse _api;
        private IMargin_Repository _IMargin_Repository;
        private IError_Repository _IError_Repository;

        public MarginController()
        {
            _api = new APIResponse();
            this._IMargin_Repository = new Margin_Repository();
            this._IError_Repository = new Error_Repository();
        }

        bool status = true;
        string message = string.Empty;

        [HttpPost]
        public HttpResponseMessage GetMargin(MarginFilter filter)
        {
            JilResponse<MarginModel> blankResponse = new JilResponse<MarginModel>();
            string returnData = "";
            try
            {
                if (filter.SubTypeCode == 1 && filter.BranchTypeCode == 1)
                {
                    JilResponse<MarginPagingModel> marginResponse = new JilResponse<MarginPagingModel>();
                    MarginPagingModel marginList = new MarginPagingModel();
                    marginList = _IMargin_Repository.GetAllMargin(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse.status = status;
                    marginResponse.Message = message;
                    marginResponse.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
                else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 2)
                {
                    JilResponse<Margin_2_2PagingModel> marginResponse24 = new JilResponse<Margin_2_2PagingModel>();
                    Margin_2_2PagingModel marginList = new Margin_2_2PagingModel();
                    marginList = _IMargin_Repository.GetMargin_2_2(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;

                }
                else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 4)
                {

                    JilResponse<Margin_2_4PagingModel> marginResponse24 = new JilResponse<Margin_2_4PagingModel>();
                    Margin_2_4PagingModel marginList = new Margin_2_4PagingModel();
                    marginList = _IMargin_Repository.GetMargin_2_4(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
                else if (filter.SubTypeCode == 2 && filter.BranchTypeCode == 6)
                {
                    JilResponse<Margin_2_6PagingModel> marginResponse24 = new JilResponse<Margin_2_6PagingModel>();
                    Margin_2_6PagingModel marginList = new Margin_2_6PagingModel();
                    marginList = _IMargin_Repository.GetMargin_2_6(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
                else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 3)
                {
                    JilResponse<Margin_3_3PagingModel> marginResponse24 = new JilResponse<Margin_3_3PagingModel>();
                    Margin_3_3PagingModel marginList = new Margin_3_3PagingModel();
                    marginList = _IMargin_Repository.GetMargin_3_3(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
                else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 5)
                {
                    JilResponse<Margin_3_5PagingModel> marginResponse24 = new JilResponse<Margin_3_5PagingModel>();
                    Margin_3_5PagingModel marginList = new Margin_3_5PagingModel();
                    marginList = _IMargin_Repository.GetMargin_3_5(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
                else if (filter.SubTypeCode == 3 && filter.BranchTypeCode == 7)
                {
                    JilResponse<Margin_3_7PagingModel> marginResponse24 = new JilResponse<Margin_3_7PagingModel>();
                    Margin_3_7PagingModel marginList = new Margin_3_7PagingModel();
                    marginList = _IMargin_Repository.GetMargin_3_7(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                } 
                message = "Invalid Parameter!";
                status = true; 
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetAllProducts", "Product/GetAllProducts");
            }
            blankResponse.status = status;
            blankResponse.Message = message;

            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(blankResponse, output);
                returnData = output.ToString();
            }
            var Emptyresponse = Request.CreateResponse(HttpStatusCode.OK);
            Emptyresponse.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return Emptyresponse;
        }
    }
}
