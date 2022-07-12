using System;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;

namespace MnStudio.Core.Services
{
    public class HttpService
    {
        /// <summary>
        /// POST HTTP 메시지를 요청합니다.
        /// </summary>
        /// <param name="uri">요청 uri.</param>
        /// <param name="body">요청 메시지</param>
        /// <param name="token">인증 token.</param>
        /// <returns>ResultMapModel</returns>
        public Task<string> PostRequest(string uri, string body, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    var data = new StringContent(body, Encoding.Default, "application/json");
                    var response = client.PostAsync(uri, data);
                    if (response.Result.IsSuccessStatusCode)
                        return response.Result.Content.ReadAsStringAsync();

                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
