using Core.Contracts;
using Core.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Core.Services
{
    public class UDPService : IUDPService
    {
        public delegate void CallBackHandler(object args);
        public CallBackHandler NotifyCallBack;
        private UdpClient _udpClient;
        int _port;
        bool _startFalg;
        Thread _worker;

        /// <summary>
        /// UDP Client 를 생성합니다.
        /// </summary>
        /// <returns>ResultMapModel</returns>
        public ResultMapModel Create()
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Any, _port);
                _udpClient = new UdpClient(endPoint);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 데이터 수신을 시작합니다.
        /// </summary>
        /// <param name="port"></param>
        /// <returns>ResultMapModel</returns>
        public ResultMapModel StartReceive(int port, CallBackHandler callBack)
        {
            try
            {
                _startFalg = true;
                _worker = new Thread(new ThreadStart(Receive));
                _port = port;
                _worker.Start();
                NotifyCallBack = callBack;

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 데이터 수신을 중지합니다.
        /// </summary>
        /// <returns>ResultMapModel</returns>
        public ResultMapModel StopReceive()
        {
            try
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

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 데이터를 전송합니다.
        /// </summary>
        /// <returns>ResultMapModel</returns>
        public ResultMapModel Send(byte[] buffer, int length)
        {
            try
            {
                _udpClient.Send(buffer, length);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        private void Receive()
        {
            try
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Any, _port);
                while (_startFalg)
                {
                    try
                    {
                        if (_udpClient == null)
                            Create();

                        var data = _udpClient.Receive(ref remoteEndPoint);

                        //data
                        NotifyCallBack(new object());
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
        }
    }
}