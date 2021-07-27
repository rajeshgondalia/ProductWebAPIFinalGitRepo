using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductWebAPI.Common
{
    public class APIResponse
    {
        public IActionResult GenerateAPIResult(HttpStatusCode statusCode, bool status, string message = null, object data = null)
        {
            return new JsonResult(new JsonResponseHelper
            {
                Statuscode = statusCode,
                Status = status,
                Data = data,
                Message = message
            });
        }
    }

    public class DatatableResponseHelper
    {
        public int TotalElements { get; set; }
        public object Data { get; set; }
    }

    public class JsonResponseHelper
    {
        public HttpStatusCode Statuscode;
        public bool Status;
        public string Message;
        public object Data;
    }
}