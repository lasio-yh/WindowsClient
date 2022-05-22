using Core.Contracts;
using System.IO.Ports;

namespace Core.Services
{
    public class SerialService : ISerialService
    {
        SerialPort _client;
        public SerialPort Client
        {
            get => _client;
        }

        string _portName = string.Empty;
        public string PortName
        {
            get => _portName;
            set => _portName = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        int _baudRate = 9600;
        public int BaudRate
        {
            get => _baudRate;
            set => _baudRate = value;
        }

        int _dataBits = 8;
        public int DataBits
        {
            get => _dataBits;
            set => _dataBits = value;
        }

        Parity _parity = Parity.None;
        public Parity Parity
        {
            get => _parity;
            set => _parity = value;
        }

        StopBits _stopBits = StopBits.One;
        public StopBits StopBits
        {
            get => _stopBits;
            set => _stopBits = value;
        }

        public bool CDHolding
        {
            get => _client.CDHolding;
        }

        public bool CtsHolding
        {
            get => _client.CDHolding;
        }

        public bool DsrHolding
        {
            get => _client.DsrHolding;
        }

        public bool DtrEnable
        {
            get => _client.DtrEnable;
        }

        public bool IsOpen
        {
            get => _client.IsOpen;
        }

        bool _isRead = false;

        public void Create(string portName)
        {
            _portName = portName;
            _client = new SerialPort();
            _client.PortName = _portName;
            _client.BaudRate = 9600;
            _client.DataBits = 8;
            _client.Parity = Parity.None;
            _client.StopBits = StopBits.One;
        }

        public void Open()
        {
            _client.Open();
        }

        public void Pause()
        {
            _isRead = false;
        }

        public void Resume()
        {
            _isRead = true;
        }

        public void Close()
        {
            _client.Close();
        }

        public void WriteLine(string text)
        {
            _client.WriteLine(text);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _client.Write(buffer, offset, count);
        }

        public void ReadLine()
        {
            //Convert Object to Byte Array
            //Convert Byte Array to Object
            while (_client.IsOpen && _isRead)
            {

            }
        }
    }
}
