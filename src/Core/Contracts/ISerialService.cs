using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface ISerialService
    {
        SerialPort Client { get; }
        string PortName { get; set; }
        int BaudRate { get; set; }
        int DataBits { get; set; }
        Parity Parity { get; set; }
        StopBits StopBits { get; set; }
        bool CDHolding { get;  }
        bool CtsHolding { get; }
        bool DsrHolding { get; }
        bool DtrEnable { get; }
        bool IsOpen { get; }

        void Create(string portName);
        void Open();
        void Pause();
        void Resume();
        void Close();
        void WriteLine(string text);
        void Write(byte[] buffer, int offset, int count);
        void ReadLine();
    }
}
