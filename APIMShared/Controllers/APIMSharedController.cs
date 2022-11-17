using APIMShared.Models;
using APIMShared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public Task<JWTTokenModel> GetAuthenticationTokenJWT()
        {
            httpRequestParametersModel model = new httpRequestParametersModel();
            var result = _authServices.GetAuthenticationTokenJWT(model);

            return result;
        }

    }
}