using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using MnStudio.Core.Contracts;
using MnStudio.Core.Models;

namespace MnStudio.Core.Services
{
    public class SocketService : ISocketService
    {
        TcpClient _client;
        NetworkStream _stream;
        Action<string> _callBack;
        int _bufSize;
        bool ConnectStatus
        {
            get
            {
                return _client.Connected;
            }
        }

        public SocketService()
        {

        }

        public SocketService(Action<string> callBack)
        {
            _callBack = callBack;
        }

        public void Open(string ip, int port, int size)
        {
            try
            {
                _client = new TcpClient(ip, port);
                _stream = _client.GetStream();
                _bufSize = size;
                StartListener();
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void Open(string ip, int port, byte size)
        {
            try
            {
                _client = new TcpClient(ip, port);
                _stream = _client.GetStream();
                _bufSize = size;
                StartListener();
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void Send(byte[] data)
        {
            try
            {
                if (_client.Connected)
                    _stream.Write(data, 0, data.Length);
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void Close()
        {
            try
            {
                if (!_client.Connected)
                    return;

                _stream.Close();
                _client.Close();
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void StartListener()
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    while (_client.Connected)
                    {
                        var buffer = new byte[_bufSize];
                        var size = _stream.Read(buffer, 0, buffer.Length);
                        var data = Encoding.ASCII.GetString(buffer, 0, size);
                        _callBack(data);
                    }
                });
            }
            catch (IOException ex)
            {

            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}