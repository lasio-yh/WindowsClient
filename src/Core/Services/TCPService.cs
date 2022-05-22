using Core.Contracts;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Core.Services
{
    public class TCPService : ITCPService
    {
        /// <summary>
        /// Default Constants.
        /// </summary>
        public static IPAddress DEFAULT_SERVER = IPAddress.Parse("127.0.0.1");
        public static int DEFAULT_PORT = 31001;
        public static IPEndPoint DEFAULT_IP_END_POINT = new IPEndPoint(DEFAULT_SERVER, DEFAULT_PORT);

        /// <summary>
        /// Local Variables Declaration.
        /// </summary>
        private TcpListener _server = null;
        private bool _stopServer = false;
        private bool _stopPurging = false;
        private Thread _serverThread = null;
        private Thread _purgingThread = null;
        private ArrayList _socketListenersList = null;

        /// <summary>
        /// Constructors.
        /// </summary>
        public TCPService()
        {
            Init(DEFAULT_IP_END_POINT);
        }
        public TCPService(IPAddress serverIP)
        {
            Init(new IPEndPoint(serverIP, DEFAULT_PORT));
        }

        public TCPService(int port)
        {
            Init(new IPEndPoint(DEFAULT_SERVER, port));
        }

        public TCPService(IPAddress serverIP, int port)
        {
            Init(new IPEndPoint(serverIP, port));
        }

        public TCPService(IPEndPoint ipNport)
        {
            Init(ipNport);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~TCPService()
        {
            StopServer();
        }

        /// <summary>
        /// Init method that create a server (TCP Listener) Object based on the
        /// IP Address and Port information that is passed in.
        /// </summary>
        /// <param name="ipNport"></param>
        private void Init(IPEndPoint ipNport)
        {
            try
            {
                _server = new TcpListener(ipNport);
            }
            catch (Exception ex)
            {
                _server = null;
            }
        }

        /// <summary>
        /// Method that starts TCP/IP Server.
        /// </summary>
        public void StartServer()
        {
            try
            {
                if (_server == null) return;
                _socketListenersList = new ArrayList();
                _server.Start();
                _serverThread = new Thread(new ThreadStart(ServerThreadStart));
                _serverThread.Start();
                _purgingThread = new Thread(new ThreadStart(PurgingThreadStart));
                _purgingThread.Priority = ThreadPriority.Lowest;
                _purgingThread.Start();
            }
            catch (SocketException se)
            {

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that stops the TCP/IP Server.
        /// </summary>
        public void StopServer()
        {
            try
            {
                if (_server == null) return;
                _stopServer = true;
                _server.Stop();
                _serverThread.Join(1000);
                if (_serverThread.IsAlive) _serverThread.Abort();
                _serverThread = null;
                _stopPurging = true;
                _purgingThread.Join(1000);
                if (_purgingThread.IsAlive) _purgingThread.Abort();
                _purgingThread = null;
                _server = null;
                StopAllSocketListers();
            }
            catch (SocketException se)
            {

            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Method that stops all clients and clears the list.
        /// </summary>
        private void StopAllSocketListers()
        {
            foreach (TCPSocketListener socketListener in _socketListenersList)
            {
                socketListener.StopSocketListener();
            }
            _socketListenersList.Clear();
            _socketListenersList = null;
        }

        /// <summary>
        /// TCP/IP Server Thread that is listening for clients.
        /// </summary>
        private void ServerThreadStart()
        {
            Socket clientSocket = null;
            TCPSocketListener socketListener = null;
            while (!_stopServer)
            {
                try
                {
                    clientSocket = _server.AcceptSocket();
                    socketListener = new TCPSocketListener(clientSocket);
                    lock (_socketListenersList)
                    {
                        _socketListenersList.Add(socketListener);
                    }
                    socketListener.StartSocketListener();
                }
                catch (SocketException se)
                {
                    _stopServer = true;
                }
                catch (Exception ex)
                {
                    _stopServer = true;
                }
            }
        }

        /// <summary>
        /// Thread method for purging Client Listeneres that are marked for
        /// deletion (i.e. clients with socket connection closed). This thead
        /// is a low priority thread and sleeps for 10 seconds and then check
        /// for any client SocketConnection obects which are obselete and 
        /// marked for deletion.
        /// </summary>
        private void PurgingThreadStart()
        {
            while (!_stopPurging)
            {
                var deleteList = new ArrayList();
                lock (_socketListenersList)
                {
                    foreach (TCPSocketListener socketListener in _socketListenersList)
                    {
                        if (socketListener.IsMarkedForDeletion())
                        {
                            deleteList.Add(socketListener);
                            socketListener.StopSocketListener();
                        }
                    }
                    for (int i = 0; i < deleteList.Count; ++i)
                    {
                        _socketListenersList.Remove(deleteList[i]);
                    }
                }
                deleteList = null;
                Thread.Sleep(10000);
            }
        }
    }


    /// <summary>
    /// Summary description for TCPSocketListener.
    /// </summary>
    public class TCPSocketListener
    {
        /// <summary>
        /// Variables that are accessed by other classes indirectly.
        /// </summary>
        private Socket _clientSocket = null;
        private bool _stopClient = false;
        private Thread _clientListenerThread = null;
        private bool _markedForDeletion = false;
        private DateTime _lastReceiveDateTime;
        private DateTime _currentReceiveDateTime;

        private enum COMMAND { PROCESS1 = 0x01, PROCESS2 = 0x02, PROCESS3 = 0x03, PROCESS4 = 0x04, PROCESS5 = 0x05 }

        /// <summary>
        /// Client Socket Listener Constructor.
        /// </summary>
        /// <param name="clientSocket"></param>
        public TCPSocketListener(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        /// <summary>
        /// Client SocketListener Destructor.
        /// </summary>
        ~TCPSocketListener()
        {
            StopSocketListener();
        }

        /// <summary>
        /// Method that starts SocketListener Thread.
        /// </summary>
        public void StartSocketListener()
        {
            if (_clientSocket == null) return;
            _clientListenerThread = new Thread(new ThreadStart(SocketListenerThreadStart));
            _clientListenerThread.Start();
        }

        /// <summary>
        /// Thread method that does the communication to the client. This 
        /// thread tries to receive from client and if client sends any data
        /// then parses it and again wait for the client data to come in a
        /// loop. The recieve is an indefinite time receive.
        /// </summary>
        private void SocketListenerThreadStart()
        {
            var size = 0;
            var buffer = new Byte[256];
            _lastReceiveDateTime = DateTime.Now;
            _currentReceiveDateTime = DateTime.Now;
            var timeOutTimer = new Timer(new TimerCallback(CheckedClientTimeOut), null, 15000, 15000);
            while (!_stopClient)
            {
                try
                {
                    size = _clientSocket.Receive(buffer);
                    if (size < 0) continue;
                    _currentReceiveDateTime = DateTime.Now;
                    //var data = (PacketDTO)PacketConvert.ByteToStructure(buffer, typeof(PacketDTO));
                    //ParseReceivePacket(data, size);
                }
                catch (SocketException se)
                {
                    _stopClient = true;
                    _markedForDeletion = true;
                }
                catch (Exception ex)
                {
                    _stopClient = true;
                    _markedForDeletion = true;
                }
            }
            timeOutTimer.Change(Timeout.Infinite, Timeout.Infinite);
            timeOutTimer = null;
        }

        /// <summary>
        /// Method that stops Client SocketListening Thread.
        /// </summary>
        public void StopSocketListener()
        {
            if (_clientSocket == null) return;
            _stopClient = true;
            _clientSocket.Close();
            _clientListenerThread.Join(1000);
            if (_clientListenerThread.IsAlive) _clientListenerThread.Abort();
            _clientListenerThread = null;
            _clientSocket = null;
            _markedForDeletion = true;
        }

        /// <summary>
        /// Method that returns the state of this object i.e. whether this
        /// object is marked for deletion or not.
        /// </summary>
        /// <returns></returns>
        public bool IsMarkedForDeletion()
        {
            return _markedForDeletion;
        }

        /// <summary>
        /// This method parses data that is sent by a client using TCP/IP.
        /// As per the "Protocol" between client and this Listener, client 
        /// sends each line of information by appending "CRLF" (Carriage Return
        /// and Line Feed). But since the data is transmitted from client to 
        /// here by TCP/IP protocol, it is not guarenteed that each line that
        /// arrives ends with a "CRLF". So the job of this method is to make a
        /// complete line of information that ends with "CRLF" from the data
        /// that comes from the client and get it processed.
        /// </summary>
        /// <param name="byteBuffer"></param>
        /// <param name="size"></param>
        private void ParseReceivePacket(object packetObj, int size)
        {
            try
            {
                //var headerObj = (HeaderPacket)PacketConvert.ByteToStructure(packetObj.HEADER, typeof(HeaderPacket));
                //switch (packetObj.COMMAND)
                //{
                //	case 0x01:
                //		{
                //			var loginDataObj = (LoginPacket)PacketConvert.ByteToStructure(packetObj.DATA, typeof(LoginPacket));
                //			Trace.TraceInformation(string.Format("{0}|{1}", DateTime.Now.ToString("hh:mm:ss"), "LoginPacket " + loginDataObj.ID + " | " + loginDataObj.PASSWORD + "|" + loginDataObj.AUTH));
                //			//dataPacket Process add in
                //			CreateResponsePacket(headerObj, COMMAND.PROCESS1);
                //			break;
                //		}
                //	case 0x02:
                //		{
                //			break;
                //		}
                //	case 0x03:
                //		{
                //			break;
                //		}
                //	case 0x04:
                //		{
                //			break;
                //		}
                //	case 0x05:
                //		{
                //			break;
                //		}
                //	default:
                //		break;
                //}
            }
            catch (SocketException se)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void CreateResponsePacket(object headerPacket, COMMAND dataType)
        {
            try
            {
                //switch (dataType)
                //{
                //	case COMMAND.PROCESS1:
                //		{
                //			var dataPacket = new LoginPacket("loginId", "loginPassword", "auth");
                //			var dataStream = PacketConvert.StructureToByte(dataPacket);
                //			headerPacket.LENGTH = dataStream.Length;
                //			var headerStream = PacketConvert.StructureToByte(headerPacket);
                //			SendResponse(headerStream, dataStream);
                //			dataStream = null;
                //			break;
                //		}
                //	case COMMAND.PROCESS2:
                //		{
                //			break;
                //		}
                //	case COMMAND.PROCESS3:
                //		{
                //			break;
                //		}
                //	case COMMAND.PROCESS4:
                //		{
                //			break;
                //		}
                //	case COMMAND.PROCESS5:
                //		{
                //			break;
                //		}
                //	default:
                //		break;
                //}
            }
            catch (SocketException se)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void SendResponse(byte[] header, byte[] data)
        {
            try
            {
                //var packet = new PacketDTO(0x01, 0x01, 0x01, header, data, 0x01);
                //var response = PacketConvert.StructureToByte(packet);
                //_clientSocket.Send(response);
            }
            catch (SocketException se)
            {

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that checks whether there are any client calls for the
        /// last 15 seconds or not. If not this client SocketListener will
        /// be closed.
        /// </summary>
        /// <param name="o"></param>
        private void CheckedClientTimeOut(object o)
        {
            if (_lastReceiveDateTime.Equals(_currentReceiveDateTime)) this.StopSocketListener();
            else _lastReceiveDateTime = _currentReceiveDateTime;
        }
    }
}