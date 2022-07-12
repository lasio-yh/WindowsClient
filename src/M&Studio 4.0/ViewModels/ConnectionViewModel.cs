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
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ConnectionViewModel()
        {
        
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
                if (AppController.StartReceive)
                    return;

                NotifyPush.Notify(NOTIFYCODE.RECEIVESTART, null);
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
                if (!AppController.StartReceive)
                    return;

                NotifyPush.Notify(NOTIFYCODE.RECEIVESTOP, null);
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
