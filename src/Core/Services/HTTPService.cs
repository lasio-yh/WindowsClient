using Core.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using System.Net.Http.Headers;

namespace Core.Services
{
    public class HTTPService : IHTTPService
    {
        public async Task<ResultMapModel> GetRequest(string uri, string token)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                var stream = await client.GetStringAsync(new Uri(uri));
                return new ResultMapModel { ResultId = "0x00", ResultMessage = stream };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }
        public async Task<ResultMapModel> PostRequest(string uri, string body, string token)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
                var stream = await client.PostAsync(new Uri(uri), httpContent);
                return new ResultMapModel { ResultId = "0x00", ResultMessage = stream.Content.ToString() };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }
    }
}
