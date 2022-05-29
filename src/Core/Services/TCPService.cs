using Core.Contracts;
using Core.Model;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Core.Services
{
    public class TCPService : ITCPService
    {
        public delegate void CallBackHandler(object args);
        public CallBackHandler NotifyCallBack;
        private TcpClient _tcpClient;
        bool _startFalg;
        Thread _worker;

        /// <summary>
        /// TCP Client 를 생성합니다.
        /// </summary>
        /// <param name="ipAddress">remote IPAddress</param>
        /// <param name="port">Port</param>
        /// <returns>ResultMapModel</returns>
        public ResultMapModel Create(string ipAddress, int port)
        {
            try
            {
                _tcpClient = new TcpClient(ipAddress, port);

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
        /// <returns>ResultMapModel</returns>
        public ResultMapModel StartReceive(CallBackHandler callBack)
        {
            try
            {
                _startFalg = true;
                _worker = new Thread(new ThreadStart(Receive));
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

                if (_tcpClient != null)
                {
                    _tcpClient.Close();
                    _tcpClient = null;
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
                var stream = _tcpClient.GetStream();
                stream.Write(buffer, 0, length);

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
                var outbuf = new byte[255];
                var nbytes = 0;
                var stream = _tcpClient.GetStream();
                var mem = new MemoryStream();
                while ((nbytes = stream.Read(outbuf, 0, outbuf.Length)) > 0)
                {
                    mem.Write(outbuf, 0, nbytes);
                }

                stream.Close();
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
}