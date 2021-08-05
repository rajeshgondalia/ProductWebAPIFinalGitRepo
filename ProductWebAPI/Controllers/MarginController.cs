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
        private IUser_Repository _IUser_Repository;

        public MarginController()
        {
            _api = new APIResponse();
            this._IMargin_Repository = new Margin_Repository();
            this._IError_Repository = new Error_Repository();
            this._IUser_Repository = new User_Repository();
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
                else
                {
                    JilResponse<MarginByBranchPagingModel> marginResponseByBranch = new JilResponse<MarginByBranchPagingModel>();
                    MarginByBranchPagingModel marginList = new MarginByBranchPagingModel();
                    marginList = _IMargin_Repository.GetMarginByBranch(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponseByBranch.status = status;
                    marginResponseByBranch.Message = message;
                    marginResponseByBranch.Result = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponseByBranch, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
                message = "Check parameter, Some parameter is not passed.";
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
