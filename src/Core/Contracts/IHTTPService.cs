using Core.Model;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IHTTPService
    {
        Task<ResultMapModel> GetRequest(string uri, string token);
        Task<ResultMapModel> PostRequest(string uri, string body, string token);
    }
}
