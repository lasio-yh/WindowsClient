using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Contracts
{
    public interface ISoapService
    {
        void Bind();
        Task<string> SendAsync();
    }
}