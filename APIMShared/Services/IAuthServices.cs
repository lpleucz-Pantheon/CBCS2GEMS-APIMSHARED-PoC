using APIMShared.Models;
using System.Threading.Tasks;
using System;

namespace APIMShared.Services
{
    public interface IAuthServices
    {
        Task<JWTTokenModel> GetAuthenticationTokenJWT(httpRequestParametersModel model);
        string GetSAPTokenSAML();
    }
}