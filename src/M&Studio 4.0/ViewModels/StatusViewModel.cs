using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using FirstFloor.ModernUI.Presentation;
using MnStudio.Constants;
using MnStudio.Core.Models;
using MnStudio.Core.Models.File;
using MnStudio.Core.Contracts;

namespace MnStudio.ViewModels
{
    class StatusViewModel : ConnectionViewModel
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public StatusViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Start();
            _timer.Tick += OnTimer;
            NotifyPush.OpenFile += CallBackOpenFile;
            NotifyPush.ClearFile += CallBackClearFile;
            NotifyPush.UndoSlide += CallBackUndoFile;
            NotifyPush.RedoSlide += CallBackRedoFile;
            NotifyPush.ChangedPlayType += CallBackChangedPlayType;
            NotifyPush.ConnectServer += CallBackConnectServer;
            NotifyPush.DisconnectServer += CallBackDisconnectServer;
            NotifyPush.Send += CallBackSendMessageServer;
            NotifyPush.ReceiveLogin += CallBackReceiveMessageServer;
            NotifyPush.ApplyDisplay += CallBackReceiveMessageMiddleWare;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            NowTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _nowTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        public string NowTime
        {
            get
            {
                return _nowTime;
            }
            set
            {
                _nowTime = value;
                OnPropertyChanged("NowTime");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isOpenFile = false;
        public bool IsOpenFile
        {
            get
            {
                return _isOpenFile;
            }
            set
            {
                _isOpenFile = value;
                OnPropertyChanged("IsOpenFile");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isConnectMiddleWare = false;
        public bool IsConnectMiddleWare
        {
            get
            {
                return _isConnectMiddleWare;
            }
            set
            {
                _isConnectMiddleWare = value;

                OnPropertyChanged("IsConnectMiddleWare");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isConnectServer = false;
        public bool IsConnectServer
        {
            get
            {
                return _isConnectServer;
            }
            set
            {
                _isConnectServer = value;
                OnPropertyChanged("IsConnectServer");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isDrawRender = false;
        public bool IsDrawRender
        {
            get
            {
                return _isDrawRender;
            }
            set
            {
                _isDrawRender = value;
                OnPropertyChanged("IsDrawRender");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        private Document _document;

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _totalCount = 0;
        public int TotalCount
        {
            get
            {
                return _totalCount;
            }
            set
            {
                _totalCount = value;
                OnPropertyChanged("TotalCount");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _currentCount = 0;
        public int CurrentCount
        {
            get
            {
                return _currentCount;
            }
            set
            {
                _currentCount = value;
                OnPropertyChanged("CurrentCount");
            }
        }

        private void CallBackOpenFile(object sender)
        {
            if (sender == null)
                return;

            _document = sender as Document;
            TotalCount = _document.Value.Count;
            CurrentCount = 0;
            IsOpenFile = true;
            StatusMessage = "자막파일을 열었습니다.";
        }

        private void CallBackClearFile(object sender)
        {
            _document = null;
            TotalCount = 0;
            CurrentCount = 0;
            IsOpenFile = false;
            StatusMessage = "자막파일을 초기화 하였습니다.";
        }

        private void CallBackUndoFile(object sender)
        {
            if (_document == null)
                return;

            if (_currentCount < 1)
                return;

            CurrentCount--;
        }

        private void CallBackRedoFile(object sender)
        {
            if (_document == null)
                return;

            if (_currentCount >= _totalCount)
                return;

            CurrentCount++;
        }

        private void CallBackChangedPlayType(object sender)
        {
            var type = (DRAWRULES)sender;
            StatusMessage = string.Format("효과 {0} 가 적용되었습니다.", type.ToString());
        }

        private void CallBackConnectServer(object sender)
        {
            IsConnectServer = ServerController.Status;
            StatusMessage = "서버와 연결되었습니다.";
        }

        private void CallBackDisconnectServer(object sender)
        {
            IsConnectServer = ServerController.Status;
            StatusMessage = "서버와 연결이 해제되었습니다.";
        }

        private void CallBackSendMessageServer(object sender)
        {
            StatusMessage = "메시지가 정상적으로 전송되었습니다.";
        }

        private void CallBackReceiveMessageServer(object sender)
        {
            var message = (string)sender;
            StatusMessage = message;
        }

        private void CallBackConnectMiddleWare(object sender)
        {
            IsConnectMiddleWare = MiddleWareController.Status;
            StatusMessage = "미들웨어와 연결되었습니다.";
        }

        private void CallBackDisconnectMiddleWare(object sender)
        {
            IsConnectMiddleWare = MiddleWareController.Status;
            StatusMessage = "미들웨어와 연결이 해제되었습니다.";
        }

        private void CallBackSendMessageMiddleWare(object sender)
        {
            StatusMessage = "미들웨어에 정상적으로 요청되었습니다.";
        }

        private void CallBackReceiveMessageMiddleWare(object sender)
        {
            StatusMessage = "미들웨어에 정상적으로 수신되었습니다.";
        }
    }
}
