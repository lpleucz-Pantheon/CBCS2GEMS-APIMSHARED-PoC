using APIMShared.Models;
using APIMShared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace APIMShared.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIMSharedController : IAPIMSharedController
    {
        private readonly ILogger<APIMSharedController> _logger;
        private readonly IAuthServices _authServices;

        public APIMSharedController(ILogger<APIMSharedController> logger, IAuthServices authServices)
        {
            _logger = logger;
            _authServices = authServices;
        }

        [HttpGet ("/GetAuth")]
        public Task<string> GetAuthenticationTokenJWT()
        {
            var result = _authServices.BuildHttpRequestToSAPBasicAuth();

            _authServices.RequestToGEMS

            return result;
        }

    }
}