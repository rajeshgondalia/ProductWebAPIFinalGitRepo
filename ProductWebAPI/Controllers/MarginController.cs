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
    }
}
