using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWebAPI.Common
{
    public class CommonMethods
    {
        public string GetIpValue()
        {
            string ipAdd = string.Empty;
            ipAdd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ipAdd;
        }
    }
}