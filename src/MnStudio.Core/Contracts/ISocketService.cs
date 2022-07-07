using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Contracts
{
    public interface ISocketService
    {
        void Open(string ip, int port, int size);
        void Open(string ip, int port, byte size);
        void Close();
        void Send(byte[] data);
    }
}