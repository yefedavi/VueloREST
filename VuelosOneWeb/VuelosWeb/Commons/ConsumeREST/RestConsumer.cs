using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace VuelosWeb.Commons.ConsumeREST
{
    public class RestConsumer
    {
        public static readonly RestConsumer InstanceRest = new RestConsumer();

        private string ulrRest = WebConfigurationManager.AppSettings["UrlRest"];

        private RestConsumer()
        {
            ulrRest += "/api/";
        }

        public static RestConsumer Instance
        {
            get
            {
                return InstanceRest;
            }
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(ulrRest);
            request.Timeout = 900000;
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string Message = "Error retrieving response.  Check inner details for more info.";
                var RestException = new ApplicationException(Message, response.ErrorException);
                throw RestException;
            }
            return response.Data;
        }
    }
}
