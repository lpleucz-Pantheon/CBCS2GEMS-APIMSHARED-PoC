using APIMShared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using APIMShared.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace APIMShared.Controllers
{
    [ApiController]    
    [Route("[controller]")]
    public class APIMSharedController : IAPIMSharedController
    {
        private readonly ILogger<APIMSharedController> _logger;
        private readonly IAuthServices _authServices;
        private readonly ISapServices _sapServices;

        public APIMSharedController(ILogger<APIMSharedController> logger, IAuthServices authServices, ISapServices sapServices)
        {
            _logger = logger;
            _authServices = authServices;
            _sapServices = sapServices;
        }        

        [Route("/GetAuth/{service}/{task}")]
        [HttpPost]
        public async Task<SapMessageModel> GetInfoFromGEMs([FromBody] SapMessageModel model, string service, string task)
        {                        
            var result = await _sapServices.RequestToGEMS(service, task, model);
            return JsonConvert.DeserializeObject<SapMessageModel>(result);
        }
    }
}