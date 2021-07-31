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
            string returnData = "";
            try
            {
                if (filter.SubTypeCode == 1 && filter.BranchTypeCode == 1)
                {
                    JilResponse<MarginModel> marginResponse = new JilResponse<MarginModel>();
                    List<MarginModel> marginList = new List<MarginModel>();
                    marginList = _IMargin_Repository.GetAllMargin(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse.status = status;
                    marginResponse.Message = message;
                    marginResponse.data = marginList;

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
                    JilResponse<Margin_2_2_Model> marginResponse24 = new JilResponse<Margin_2_2_Model>();
                    List<Margin_2_2_Model> marginList = new List<Margin_2_2_Model>();
                    marginList = _IMargin_Repository.GetMargin_2_2(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.data = marginList;

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

                    JilResponse<Margin_2_4_Model> marginResponse24 = new JilResponse<Margin_2_4_Model>();
                    List<Margin_2_4_Model> marginList = new List<Margin_2_4_Model>();
                    marginList = _IMargin_Repository.GetMargin_2_4(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.data = marginList;

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
                    JilResponse<Margin_2_6_Model> marginResponse24 = new JilResponse<Margin_2_6_Model>();
                    List<Margin_2_6_Model> marginList = new List<Margin_2_6_Model>();
                    marginList = _IMargin_Repository.GetMargin_2_6(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.data = marginList;

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
                    JilResponse<Margin_3_3_Model> marginResponse24 = new JilResponse<Margin_3_3_Model>();
                    List<Margin_3_3_Model> marginList = new List<Margin_3_3_Model>();
                    marginList = _IMargin_Repository.GetMargin_3_3(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.data = marginList;

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
                    JilResponse<Margin_3_5_Model> marginResponse24 = new JilResponse<Margin_3_5_Model>();
                    List<Margin_3_5_Model> marginList = new List<Margin_3_5_Model>();
                    marginList = _IMargin_Repository.GetMargin_3_5(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.data = marginList;

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
                    JilResponse<Margin_3_7_Model> marginResponse24 = new JilResponse<Margin_3_7_Model>();
                    List<Margin_3_7_Model> marginList = new List<Margin_3_7_Model>();
                    marginList = _IMargin_Repository.GetMargin_3_7(filter);
                    message = "Margin Record Fetched!";
                    status = true;

                    marginResponse24.status = status;
                    marginResponse24.Message = message;
                    marginResponse24.data = marginList;

                    using (var output = new StringWriter())
                    {
                        Jil.JSON.Serialize(marginResponse24, output);
                        returnData = output.ToString();
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                    return response;
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetAllProducts", "Product/GetAllProducts");
            }
            #region Get empty margin list
            JilResponse<MarginModel> blankResponse = new JilResponse<MarginModel>();
            List<MarginModel> EmptymarginList = new List<MarginModel>();
            message = "Margin Record Fetched!";
            status = true;

            blankResponse.status = status;
            blankResponse.Message = message;
            blankResponse.data = EmptymarginList;

            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(blankResponse, output);
                returnData = output.ToString();
            }
            var Emptyresponse = Request.CreateResponse(HttpStatusCode.OK);
            Emptyresponse.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return Emptyresponse;
            #endregion
        }
    }
}
