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

        public async Task<string> RequestToGEMS(string query, RestRequest httpAuthHeader)
        {
            //Get return from a query From gems
            var client = new RestClient(_config["BaseUrlSap"] + query);
            var request = await _authServices.BuildHttpRequestToSAPBasicAuth(new Models.httpRequestParametersModel()); //ToDo
            var response = await client.ExecuteAsync(request);

            return response.IsSuccessStatusCode ? response.Content.ToString() : null;

        }
    }
}
