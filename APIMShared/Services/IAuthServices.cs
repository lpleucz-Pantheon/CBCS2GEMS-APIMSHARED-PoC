using APIMShared.Models;
using System.Threading.Tasks;
using System;
using RestSharp;

namespace APIMShared.Services
{
    public interface IAuthServices
    {
        Task<JWTTokenModel> GetSAPAuthAzureToken();
        Task<RestRequest> BuildHttpRequestToSAPBasicAuth(string baseurl, SapMessageModel body);
        public RestRequest BuildHttpRequestToGetSAPAuthAzureToken();
    }
}