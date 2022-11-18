using APIMShared.Models;
using System.Threading.Tasks;
using System;
using RestSharp;

namespace APIMShared.Services
{
    public interface IAuthServices
    {
        Task<JWTTokenModel> GetSAPAuthAzureToken(httpRequestParametersModel model);
        Task<RestRequest> BuildHttpRequestToSAPBasicAuth(httpRequestParametersModel model);
        public RestRequest BuildHttpRequestToGetSAPAuthAzureToken(httpRequestParametersModel model);
    }
}