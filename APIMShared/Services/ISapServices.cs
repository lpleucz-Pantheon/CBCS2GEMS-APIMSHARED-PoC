using APIMShared.Models;
using RestSharp;
using System.Threading.Tasks;

namespace APIMShared.Services
{
    public interface ISapServices
    {
        Task<string> RequestToGEMS(string service, string task, SapMessageModel body);       
    }
}