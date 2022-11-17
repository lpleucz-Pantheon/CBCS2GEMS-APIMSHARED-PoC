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
    public class AuthServices: IAuthServices
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthServices> _logger;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        
        public AuthServices(
            IConfiguration config,
            ILogger<AuthServices> logger,
            IMapper mapper,
            HttpClient httpClient)
        {
            _config = config;
            _logger = logger;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<JWTTokenModel> GetAuthenticationTokenJWT(httpRequestParametersModel model)
        { 
            var client = new RestClient(model.baseUrl);
            var request = new RestRequest(model.baseUrl, model.method);

            //request.AddHeader("Accept", model.contentType); //
            //request.AddParameter("client_id", model.clientId);//
            //request.AddParameter("client_secret", model.clientSecret);//
            //request.AddParameter("grant_type", model.grantType);//
            //request.AddParameter("scope", model.scope);//

            request.AddHeader("Accept", "");
            request.AddParameter("client_id", "");
            request.AddParameter("client_secret", "");
            request.AddParameter("grant_type","");
            request.AddParameter("scope", "");

            var response = await client.ExecuteAsync(request);
 
            return JsonConvert.DeserializeObject<JWTTokenModel>(response.Content);
        }

        public string GetSAPTokenSAML()
        {            
            return null;
        }
    }
}