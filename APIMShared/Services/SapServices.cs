using APIMShared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Threading.Tasks;

namespace APIMShared.Services
{
    public class SapServices : ISapServices
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthServices> _logger;
        private readonly IAuthServices _authServices;

        public SapServices(
            IConfiguration config,
            ILogger<AuthServices> logger,
            IAuthServices authServices)
        {
            _config = config;
            _logger = logger;
            _authServices = authServices;
        }

        public async Task<string> RequestToGEMS(string service, string task, SapMessageModel body)
        {
            //Create the base url to use SAP Service Call     
            string baseurl = _config["BaseUrlSap"] + $"{service}/{task}";
            
            //Build the Request structure to use the SAP Service Call
            var request = await _authServices.BuildHttpRequestToSAPBasicAuth(baseurl, body);

            //Execute the SAP Service Call
            var client = new RestClient(baseurl);
            var response = await client.ExecuteAsync(request);

            return response.Content.ToString();
        }
    }
}       