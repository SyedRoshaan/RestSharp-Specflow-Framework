using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpSpecflowFramework.Drivers
{
    internal class RestSharpManager
    {
        static RestRequest request = null;
        static RestClient client = null;

        public static string base_url = "";

        public static void InitializeEndpoint(string api_url)
        {
            base_url = api_url;
            client = new RestClient(base_url);
        }

        public static void SetQueryParam(string queryParam, string queryParamValue)
        {
            request.AddQueryParameter(queryParam, queryParamValue);
        }

        public static void MakeRequest(string method)
        {
            if (request == null)
            {
                switch (method.ToLower())
                {
                    case "get":
                        request = new RestRequest(APIHelper.endpoint, Method.Get);
                        break;
                    case "post":
                        request = new RestRequest(APIHelper.endpoint, Method.Post);
                        request.AddParameter("Application/Json", APIHelper.body, ParameterType.RequestBody);
                        break;
                    case "delete":
                        request = new RestRequest(APIHelper.endpoint, Method.Delete);
                        break;
                    case "put":
                        request = new RestRequest(APIHelper.endpoint, Method.Put);
                        request.AddParameter("Application/Json", APIHelper.body, ParameterType.RequestBody);
                        break;
                    default:
                        throw new Exception("Method is not supported.");
                }
            }
        }

        public static void ExecuteRequest()
        {
            APIHelper.response = client.Execute<RestResponse>(request);
        }

        public static void ClearRequest()
        {
            request = null;
        }
    }
}
