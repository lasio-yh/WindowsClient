using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IHTTPService
    {
        Task<ResultMapModel> GetRequest(string uri, string token);
        Task<ResultMapModel> PostRequest(string uri, string body, string token);
    }
}
