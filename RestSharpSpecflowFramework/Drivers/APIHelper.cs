using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpSpecflowFramework.Drivers
{
    internal class APIHelper
    {
        public static string body = "";
        public static string baseURL = "";
        public static string endpoint = "";
        public static RestResponse response = new RestResponse();
        public static string method = "";
    }
}
