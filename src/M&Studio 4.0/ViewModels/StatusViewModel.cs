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
            NotifyPush.OpenFile += OnOpenDocument;
            NotifyPush.ClearFile += OnClearDocument;
            NotifyPush.UndoSlide += OnUndoFile;
            NotifyPush.RedoSlide += OnRedoFile;
            NotifyPush.ApplyStanBy += OnApplyStanBy;
            NotifyPush.ConnectServer += OnConnectServer;
            NotifyPush.DisconnectServer += OnDisconnectServer;
            NotifyPush.ReceiveStart += OnReceiveStart;
            NotifyPush.ReceiveStop += OnReceiveStop;
            NotifyPush.ReceiveLogin += OnReceiveLogin;
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
        private string _connectTime = string.Format(" {0}", TimeSpan.Zero);
        public string ConnectTime
        {
            get
            {
                return _connectTime;
            }
            set
            {
                _connectTime = value;
                OnPropertyChanged("ConnectTime");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _disconnectTime = string.Format(" {0}", TimeSpan.Zero);
        public string DisconnectTime
        {
            get
            {
                return _disconnectTime;
            }
            set
            {
                _disconnectTime = value;
                OnPropertyChanged("DisconnectTime");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _startReceiveTime = string.Format(" {0}", TimeSpan.Zero);
        public string StartReceiveTime
        {
            get
            {
                return _startReceiveTime;
            }
            set
            {
                _startReceiveTime = value;
                OnPropertyChanged("StartReceiveTime");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _stopReceiveTime = string.Format(" {0}", TimeSpan.Zero);
        public string StopReceiveTime
        {
            get
            {
                return _stopReceiveTime;
            }
            set
            {
                _stopReceiveTime = value;
                OnPropertyChanged("StopReceiveTime");
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
        private bool _isUsedLogin = false;
        public bool IsUsedLogin
        {
            get
            {
                return _isUsedLogin;
            }
            set
            {
                _isUsedLogin = value;
                OnPropertyChanged("IsUsedLogin");
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
        private bool _isConnectMiddleWare = AppController.UsedMiddleWare;
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
        private bool _isReceiveMessage = false;
        public bool IsReceiveMessage
        {
            get
            {
                return _isReceiveMessage;
            }
            set
            {
                _isReceiveMessage = value;
                OnPropertyChanged("IsReceiveMessage");
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

        private void OnOpenDocument(object sender)
        {
            if (sender == null)
                return;

            _document = sender as Document;
            TotalCount = _document.Value.Count;
            CurrentCount = 0;
            IsOpenFile = true;
            StatusMessage = "자막파일 불러오기를 성공하였습니다.";
        }

        private void OnClearDocument(object sender)
        {
            _document = null;
            TotalCount = 0;
            CurrentCount = 0;
            IsOpenFile = false;
            StatusMessage = "자막파일 초기화를 성공하였습니다.";
        }

        private void OnUndoFile(object sender)
        {
            if (_document == null)
                return;

            if (_currentCount < 1)
                return;

            CurrentCount--;
        }

        private void OnRedoFile(object sender)
        {
            if (_document == null)
                return;

            if (_currentCount >= _totalCount)
                return;

            CurrentCount++;
        }

        private void OnApplyStanBy(object sender)
        {
            StatusMessage = "송출 대기상태 입니다.";
        }

        private void OnConnectServer(object sender)
        {
            IsConnectServer = ServerController.Status;
            StatusMessage = "서버와 연결되었습니다.";
            ConnectTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        }

        private void OnDisconnectServer(object sender)
        {
            IsConnectServer = ServerController.Status;
            StatusMessage = "서버와 연결이 해제되었습니다.";
            DisconnectTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        }

        private void CallBackSendMessageServer(object sender)
        {
            StatusMessage = "메시지가 정상적으로 전송되었습니다.";
        }

        private void OnReceiveLogin(object sender)
        {
            IsConnectServer = AppController.UsedLogin;
            StatusMessage = "정상적으로 로그인 하였습니다.";
        }

        private void OnReceiveStart(object sender)
        {
            IsReceiveMessage = true;
            StatusMessage = "메시지 수신을 시작하였습니다.";
            StartReceiveTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        }

        private void OnReceiveStop(object sender)
        {
            IsReceiveMessage = false;
            StatusMessage = "메시지 수신을 종료하였습니다.";
            StopReceiveTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
