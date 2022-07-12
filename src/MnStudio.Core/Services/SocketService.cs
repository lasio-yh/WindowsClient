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
using MnStudio.Core.Models.Server;
using System.Web.Script.Serialization;

namespace MnStudio.Core.Services
{
    public class SocketService : ISocketService
    {
        Socket _client;
        Action<string> _callBack;
        int _bufSize;
        bool _ListenerStatus = false;
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
                Task.Factory.StartNew(() =>
                {
                    var endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                    _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _client.Connect(endPoint);
                    _bufSize = size;
                });
                StartListener();
            }
            catch (SocketException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (Exception ex)
            {
                NotifyCallBack("0", ex.Message);
            }
        }

        public void Send(string message)
        {
            try
            {
                if (_client == null)
                    return;

                if (!_client.Connected)
                    return;

                var data = Encoding.Default.GetBytes(message);
                _client.Send(data, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (Exception ex)
            {
                NotifyCallBack("0", ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                if (_client == null)
                    return;

                if (!_client.Connected)
                    return;

                Task.Factory.StartNew(() =>
                {
                    StopListener();

                    _client.Close();
                    _client = null;
                });
            }
            catch (SocketException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (Exception ex)
            {
                NotifyCallBack("0", ex.Message);
            }
        }

        private void StartListener()
        {
            try
            {
                var buffer = new byte[_bufSize];
                _ListenerStatus = true;
                Task.Factory.StartNew(() =>
                {
                    while (_ListenerStatus && _client.Connected)
                    {
                        var size = _client.Receive(buffer);
                        if (size <= 0) 
                            continue;

                        var data = Encoding.ASCII.GetString(buffer, 0, size);
                        NotifyCallBack(data);
                    }
                });
            }
            catch (ObjectDisposedException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (IOException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (SocketException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (Exception ex)
            {
                NotifyCallBack("0", ex.Message);
            }
        }

        private void StopListener()
        {
            try
            {
                _ListenerStatus = false;
            }
            catch (ObjectDisposedException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (IOException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (SocketException ex)
            {
                NotifyCallBack("0", ex.Message);
            }
            catch (Exception ex)
            {
                NotifyCallBack("0", ex.Message);
            }
        }

        private void NotifyCallBack(string message)
        {
            _callBack(message);
        }

        private void NotifyCallBack(string id, string message)
        {
            var obj = new ResponseModel { ID = id, RESPONSE = message };
            var jss = new JavaScriptSerializer();
            var param = jss.Serialize(obj);
            _callBack(param);
        }
    }
}