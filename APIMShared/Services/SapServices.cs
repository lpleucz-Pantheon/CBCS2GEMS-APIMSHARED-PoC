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
            //Get return from a Gems service            
            string baseurl = _config.GetValue<string>("Auth:BaseUrlSap") + $"{service}/{task}";
            var client = new RestClient(baseurl);
            var request = await _authServices.BuildHttpRequestToSAPBasicAuth(baseurl, body);
            var response = await client.ExecuteAsync(request);

            return response.Content.ToString();

        }
    }
}       