using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IUDPService
    {
        void StartServer(int port);
        void StopServer();
        void Send(byte[] buffer, int length);
    }
}
