﻿using Core.Model;
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
        ResultMapModel Create();
        Task<string> SendAsync();
    }
}
