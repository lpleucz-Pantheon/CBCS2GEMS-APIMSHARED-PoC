using APIMShared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace APIMShared.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthServices> _logger;

        public AuthServices(
            IConfiguration config,
            ILogger<AuthServices> logger
            )
        {
            _config = config;
            _logger = logger;
        }
        public async Task<JWTTokenModel> GetSAPAuthAzureToken()
        {                       
            var client = new RestClient(_config["BaseUrlAzure"]);
            var response = await client.ExecuteAsync(BuildHttpRequestToGetSAPAuthAzureToken());

            return JsonConvert.DeserializeObject<JWTTokenModel>(response.Content);
        }

        public async Task<RestRequest> BuildHttpRequestToSAPBasicAuth(string baseurl, SapMessageModel body)
        {
            //Build HttpRequest to run the calls to GEMS
            //Get Authorization TOKEN + SAP Basic Authentication
            var authorization = await GetSAPAuthAzureToken();

            var request = new RestRequest(baseurl, Method.Post);
            //Content Settings
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            
            //Authorization Headers
            request.AddHeader("Authorization", $"Bearer {authorization.access_token}");            
            request.AddHeader("SAPAuthorization", $"Basic {_config["encriptedBase64"]}");

            //Sap Parameters
            request.AddHeader("SAPEncrypted", "X");
            request.AddHeader("x-csrf-token", "Fetch");            
            request.AddHeader("X-Requested-With", "X");

            //Add Serialized Body to Request, removing the null values from the request message        
            request.AddBody(JsonConvert.SerializeObject(body, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            
            return request;
        }

        public RestRequest BuildHttpRequestToGetSAPAuthAzureToken()
        {            
            var request = new RestRequest(_config["BaseUrlAzure"], Method.Post);
            //Content Header
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //Parameters
            request.AddParameter("client_id", _config["AzureClientId"]);
            request.AddParameter("client_secret", _config["AzureClientSecret"]);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", _config["SAPScope"]);

            return request;
        }

    }
}