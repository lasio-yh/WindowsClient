using Core.Contracts;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Core.Services
{
    public class UDPService : IUDPService
    {
        public delegate void ReceiveEventHandler(object args);
        public event ReceiveEventHandler ReceiveEvent;
        private UdpClient _udpClient;
        int _port;
        bool _startFalg;
        Thread _worker;

        public void StartServer(int port)
        {
            _startFalg = true;
            _worker = new Thread(new ThreadStart(Receive));
            _port = port;
            _worker.Start();
        }

        public void StopServer()
        {
            _startFalg = false;
            if (_worker != null)
            {
                _worker.Abort();
                _worker = null;
            }
            if (_udpClient != null)
            {
                _udpClient.Close();
                _udpClient = null;
            }
        }

        protected void OnReceiveEvent(object e)
        {
            if (ReceiveEvent != null)
                ReceiveEvent.Invoke(e);
        }

        private void Initialize()
        {
            var endPoint = new IPEndPoint(IPAddress.Any, _port);
            _udpClient = new UdpClient(endPoint);
        }

        private void Receive()
        {
            var remoteEndPoint = new IPEndPoint(IPAddress.Any, _port);
            while (_startFalg)
            {
                try
                {
                    if (_udpClient == null) Initialize();
                    var data = _udpClient.Receive(ref remoteEndPoint);
                    OnReceiveEvent(new object());
                }
                catch (Exception ex)
                {
                    Thread.Sleep(5000);
                }
            }
        }

        public void Send(byte[] buffer, int length)
        {
            _udpClient.Send(buffer, length);
        }
    }
}