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
    public class BillController : ApiController
    {
        private readonly APIResponse _api;
        private IBill_Repository _IBill_Repository;
        private IError_Repository _IError_Repository;
        private IUser_Repository _IUser_Repository;
        private IPOSBill_Repository _IPOSBill_Repository;

        public BillController()
        {
            _api = new APIResponse();
            this._IBill_Repository = new Bill_Repository();
            this._IError_Repository = new Error_Repository();
            this._IUser_Repository = new User_Repository();
            this._IPOSBill_Repository = new POSBill_Repository();
        }

        bool status = true;
        string message = string.Empty;

        [HttpPost]
        public HttpResponseMessage GetMyBillAPI(GetBillFilterModel filter)
        {
            JilResponse<Bill_2_Model> blankResponse = new JilResponse<Bill_2_Model>();
            string returnData = "";
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    if (filter.SubTypeCode == 2)
                    {
                        JilResponse<BillPaging_2_Model> marginResponse = new JilResponse<BillPaging_2_Model>();
                        BillPaging_2_Model BillReturnList = new BillPaging_2_Model();
                        BillReturnList = _IBill_Repository.GetReturnBillList(filter);
                        message = "Bill Return Record Fetched!";
                        status = true;

                        marginResponse.status = status;
                        marginResponse.Message = message;
                        marginResponse.Result = BillReturnList;

                        using (var output = new StringWriter())
                        {
                            Jil.JSON.Serialize(marginResponse, output);
                            returnData = output.ToString();
                        }
                        var response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                        return response;
                    }
                    else if (filter.SubTypeCode == 3)
                    {
                        JilResponse<BillPaging_3_Model> marginResponse = new JilResponse<BillPaging_3_Model>();
                        BillPaging_3_Model BillOrderList = new BillPaging_3_Model();
                        BillOrderList = _IBill_Repository.GetOrderBillList(filter);
                        message = "Bill Order Record Fetched!";
                        status = true;

                        marginResponse.status = status;
                        marginResponse.Message = message;
                        marginResponse.Result = BillOrderList;

                        using (var output = new StringWriter())
                        {
                            Jil.JSON.Serialize(marginResponse, output);
                            returnData = output.ToString();
                        }
                        var response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                        return response;
                    }
                    message = "Invalid Parameter!";
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetMyBillAPI", "Bill/GetMyBillAPI");
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

        [HttpPost]
        public HttpResponseMessage UpdateBillStatus(BillStatusModel model)
        {
            JilResponse<int> blankResponse = new JilResponse<int>();
            string returnData = "";
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    JilResponse<int> marginResponse = new JilResponse<int>();
                    int insertedId = _IBill_Repository.UpdateBillStatus(model);
                    if (insertedId > 0)
                    {
                        message = "Bill status has been updated.";
                        status = true;

                        marginResponse.status = status;
                        marginResponse.Message = message;
                        marginResponse.Result = insertedId;

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
                        message = "Invalid Parameter!";
                        status = true;
                    }                    
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "UpdateBillStatus", "Bill/UpdateBillStatus");
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

        [HttpPost]
        public HttpResponseMessage GetBillProducts(BillProductsFilterModel model)
        {
            JilResponse<MarginByBranchModel> blankResponse = new JilResponse<MarginByBranchModel>();
            string returnData = "";
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    if (model.SubTypeCode > 0 && !string.IsNullOrEmpty(model.OrderType))
                    {
                        JilResponse<BillProductPagingModel> marginResponse = new JilResponse<BillProductPagingModel>();
                        BillProductPagingModel BillProductsList = new BillProductPagingModel();
                        BillProductsList = _IBill_Repository.GetBillProducts(model);
                        message = "Bill Products Record Fetched!";
                        status = true;

                        marginResponse.status = status;
                        marginResponse.Message = message;
                        marginResponse.Result = BillProductsList;

                        using (var output = new StringWriter())
                        {
                            Jil.JSON.Serialize(marginResponse, output);
                            returnData = output.ToString();
                        }
                        var response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
                        return response;
                    }                   
                    message = "Invalid Parameter!";
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetBillProducts", "Bill/GetBillProducts");
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

        [HttpPost]
        public HttpResponseMessage AddUpdatePOSBillAPI(List<POSMstModel> model)
        {
            JilResponse<POSBillResponseModel> blankResponse = new JilResponse<POSBillResponseModel>();
            List<POSBillResponseModel> responselist = new List<POSBillResponseModel>();
            string returnData = "";
            try
            {
                responselist = _IPOSBill_Repository.InsertUpdatePOSBill(model);
                if (responselist.Count > 0)
                {
                    status = true;
                    message = "Insert Successfully!";
                }
                else
                {
                    status = true;
                    message = "Please enter valid parameter!";
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "AddUpdatePOSBillAPI", "Bill/AddUpdatePOSBillAPI");
            }
            blankResponse.status = status;
            blankResponse.Message = message;
            blankResponse.data = responselist;
            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(blankResponse, output);
                returnData = output.ToString();
            }
            var Emptyresponse = Request.CreateResponse(HttpStatusCode.OK);
            Emptyresponse.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return Emptyresponse;
        }

        [HttpPost]
        public HttpResponseMessage GetAllPOSBillAPI(POSBillFilter model)
        {
            JilResponse<POSBILLGetModel> blankResponse = new JilResponse<POSBILLGetModel>();
            List<POSBILLGetModel> responselist = new List<POSBILLGetModel>();
            string returnData = "";
            try
            {
                responselist = _IPOSBill_Repository.GetAllPOSBill(model);
                if (responselist.Count > 0)
                {
                    status = true;
                    message = "Insert Successfully!";
                }
                else
                {
                    status = true;
                    message = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Bad Request!" + " - " + ex.ToString();
                this._IError_Repository.InsertErrorLog(ex.ToString(), "GetAllPOSBillAPI", "Bill/GetAllPOSBillAPI");
            }
            blankResponse.status = status;
            blankResponse.Message = message;
            blankResponse.data = responselist;
            using (var output = new StringWriter())
            {
                Jil.JSON.Serialize(blankResponse, output);
                returnData = output.ToString();
            }
            var Emptyresponse = Request.CreateResponse(HttpStatusCode.OK);
            Emptyresponse.Content = new StringContent(returnData, Encoding.UTF8, "application/json");
            return Emptyresponse;
        }

        [HttpPost]
        public HttpResponseMessage DeletePOSBillAPI(List<POSBillResponseModel> model)
        {
            JilResponse<string> blankResponse = new JilResponse<string>();
            string returnData = "";
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var UserId = identity.Claims.Where(c => c.Type == "CrId").Select(c => c.Value).FirstOrDefault();
                int CrId = Convert.ToInt32(UserId);
                bool isAlreadyLogged = _IUser_Repository.CheckUserAvailableInLoginInfo(CrId);
                if (isAlreadyLogged)
                {
                    if (model.Count > 0)
                    {
                        _IPOSBill_Repository.DeletePOSBill(model);
                        status = true;
                        message = "Deleted Successfully!";
                    }
                    else
                    {
                        status = true;
                        message = "Please pass the parameter!";
                    }
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
                this._IError_Repository.InsertErrorLog(ex.ToString(), "DeletePOSBillAPI", "Bill/DeletePOSBillAPI");
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
