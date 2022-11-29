using APIMShared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIMShared.Controllers
{
    public interface IAPIMSharedController
    {
        Task<SapMessageModel> GetInfoFromGEMs([FromBody] SapMessageModel model, string service, string task);
    }
}
