using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface ISOAPService
    {
        string Data { get; set; }
        string Uri { get; set; }
        string Token { get; set; }
        string Header { get; set; }
        string Action { get; set; }
        bool Bind();
        Task<string> SendAsync();
    }
}
