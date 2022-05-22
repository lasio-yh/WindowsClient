using Core.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SoapService : ISOAPService
    {
        private HttpClient _client;
        private HttpRequestMessage _request;
        private HttpResponseMessage _response;
        private StringContent _content;

        private string _data = string.Empty;
        public string Data
        {
            get => _data;
            set => _data = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        private string _token = string.Empty;
        public string Token
        {
            get => _token;
            set => _token = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        private string _uri = string.Empty;
        public string Uri
        {
            get => _uri;
            set => _uri = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        private string _header = "text/xml; charset=utf-8";
        public string Header
        {
            get => _header;
            set => _header = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        private string _action = string.Empty;
        public string Action
        {
            get => _action;
            set => _action = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        public SoapService()
        {

        }

        public bool Bind()
        {
            if (string.IsNullOrEmpty(_data)) return false;
            if (string.IsNullOrEmpty(_token)) return false;
            if (string.IsNullOrEmpty(_uri)) return false;
            if (string.IsNullOrEmpty(_header)) return false;
            if (string.IsNullOrEmpty(_action)) return false;
            _content = new StringContent(_data);
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            _request = new HttpRequestMessage(HttpMethod.Post, _uri);
            _request.Headers.Add("SOAPAction", _action);
            _request.Method = HttpMethod.Post;
            _request.Content = _content;
            _request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(_header);
            return true;
        }

        public async Task<string> SendAsync()
        {
            _response = await _client.SendAsync(_request);
            var result = await _response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
