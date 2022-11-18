using APIMShared.Models;
using AutoMapper;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIMShared.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthServices> _logger;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public AuthServices(
            IConfiguration config,
            ILogger<AuthServices> logger,
            IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _mapper = mapper;            
        }
        private async Task<JWTTokenModel> GetSAPAuthAzureToken(httpRequestParametersModel model)
        {
            //Get Token SAPAuth From Azure AD
            var client = new RestClient(model.baseUrl);

            var response = await client.ExecuteAsync(BuildHttpRequestToGetSAPAuthAzureToken(model));

            return JsonConvert.DeserializeObject<JWTTokenModel>(response.Content);
        }

        public async Task<RestRequest> BuildHttpRequestToSAPBasicAuth(httpRequestParametersModel model)
        {
            //Build HttpRequest to run the calls to GEMS
            //Get Authorization TOKEN + SAP Basic Authentication
            var authorization = await GetSAPAuthAzureToken(model); 
            
            var request = new RestRequest(_config.GetSection("Auth")["BaseUrlAzure"], model.method);
                request.AddParameter("Authorization", "Bearer " + authorization.accessToken);
                request.AddHeader("SAPAuthorization", _config["encriptedBase64"]);           
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-csrf-token", "Fetch"); 
            
            return request;
        }

        public RestRequest BuildHttpRequestToGetSAPAuthAzureToken(httpRequestParametersModel model)
        {
            var request = new RestRequest(model.baseUrl, model.method);
            //request.AddHeader("Accept", model.contentType);
            request.AddParameter("client_id", _config.GetSection("Auth")["ClientId"]);
            request.AddParameter("client_secret", _config.GetSection("Auth")["ClientSecret"]);
            request.AddParameter("grant_type", model.grantType);
            request.AddParameter("scope", model.scope);

            return request;
        }
        
    }
}