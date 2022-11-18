using RestSharp;
using System;

namespace APIMShared.Models
{
    public class httpRequestParametersModel
    {
        public Uri baseUrl { get; set; }            // null;
        public Method method { get; set; }      // Method.Post;
        public string contentType { get; set; }     // "application/x-www-form-urlencoded";
        public string cookie { get; set; }          // null
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string grantType { get; set; }       // client_credentials    
        public string scope { get; set; }           // scope/.default
        public string authorization { get; set; }
        public string sapAuthorization { get; set; } 
        public string xCsrfToken { get; set; }
    }
}