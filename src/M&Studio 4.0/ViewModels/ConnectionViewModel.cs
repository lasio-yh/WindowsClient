using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using MnStudio.Constants;
using System.Windows.Input;
using MnStudio.Core.Models.MiddleWare;
using MnStudio.Core.Models.Server;

namespace MnStudio.ViewModels
{
    class ConnectionViewModel : DisplayViewModel
    {
        private bool _StartReceive = false;
        private DispatcherTimer _requestTimer = new DispatcherTimer();

         /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ConnectionViewModel()
        {
            _requestTimer.Interval = TimeSpan.FromMilliseconds(5000);
            _requestTimer.Tick += OnRequestMessage;
        }

        private void OnRequestMessage(object sender, EventArgs e)
        {
            try
            {
                //if (!_StartReceive)
                //{
                //    var paramMessageSetting = new RequestMessageSettingModel
                //    {
                //        BEFORE = App.Current.Properties["FindDate"].ToString(),
                //        CHN = App.Current.Properties["Channel"].ToString(),
                //        COUNT = App.Current.Properties["FindSize"].ToString(),
                //        IP = AppController.LocalIpAddress,
                //        MAC = AppController.LocalMacAddress,
                //        PGM = App.Current.Properties["Program"].ToString(),
                //        UID = ""
                //    };
                //    ServerController.Send(paramMessageSetting);
                //    _StartReceive = true;
                //}
                //var paramMessageData = new RequestMessageDataModel
                //{
                //    SEQ = "", //Setting 에서 받아오는 값으로 세팅
                //    CHN = "",
                //    COUNT = "",
                //    IP = "",
                //    MAC = "",
                //    PGM = "",
                //    UID = ""
                //};
                //ServerController.Send(paramMessageData);
                NotifyPush.Notify(NOTIFYCODE.RESMESSAGEDATA, null);
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandConnectServer;
        public ICommand CommandConnectServer
        {
            get { return (this._commandConnectServer) ?? (this._commandConnectServer = new DelegateCommand(OnConnectServer)); }
        }
        private void OnConnectServer()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "메시지 서버와 연결하였습니다.");
                ServerController.Open();
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandDisconnectServer;
        public ICommand CommandDisconnectServer
        {
            get { return (this._commandDisconnectServer) ?? (this._commandDisconnectServer = new DelegateCommand(OnDisconnectServer)); }
        }
        private void OnDisconnectServer()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "메시지 서버 연결을 종료하였습니다.");
                ServerController.Close();
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandStartServer;
        public ICommand CommandStartServer
        {
            get { return (this._commandStartServer) ?? (this._commandStartServer = new DelegateCommand(OnCommandStartServer)); }
        }
        private void OnCommandStartServer()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "메시지 데이터 수신을 시작하였습니다.");
                _requestTimer.Start();
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandStopServer;
        public ICommand CommandStopServer
        {
            get { return (this._commandStopServer) ?? (this._commandStopServer = new DelegateCommand(OnCommandStopServer)); }
        }
        private void OnCommandStopServer()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "메시지 데이터 수신을 종료하였습니다.");
                _requestTimer.Stop();
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandInitialize;
        public ICommand CommandInitialize
        {
            get { return (this._commandInitialize) ?? (this._commandInitialize = new DelegateCommand(OnInitialize)); }
        }
        private void OnInitialize()
        {
            try
            {
                LogCommand.WriteCommunication(LOGLEVEL.INFO, "미들웨어를 초기화 하였습니다.");
                var obj = new RequestRenderInitModel 
                {
                        command = 1
                    ,   filename = App.Current.Properties["FileName"].ToString()
                    ,   filepath = App.Current.Properties["FilePath"].ToString()
                    ,   fileindex = 0 
                };
                MiddleWareController.Send<RequestRenderInitModel>(obj);
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandDispose;
        public ICommand CommandDispose
        {
            get { return (this._commandDispose) ?? (this._commandDispose = new DelegateCommand(OnDispose)); }
        }
        private void OnDispose()
        {
            try
            {
                LogCommand.WriteCommunication(LOGLEVEL.INFO, "미들웨어 리소스를 해제하였습니다.");
                var obj = new RequestRenderModel { command = 2 };
                MiddleWareController.Send<RequestRenderModel>(obj);
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }
    }
}
