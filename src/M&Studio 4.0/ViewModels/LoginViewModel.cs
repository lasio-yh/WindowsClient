using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MnStudio.Constants;
using MnStudio.Core.Models.Server;

namespace MnStudio.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public LoginViewModel()
        {
            IsChecked = (bool)App.Current.Properties["isChecked"];
            ID = IsChecked ? (string)App.Current.Properties["Id"] : string.Empty;
            NotifyPush.ReceiveLogin += CallBackReceiveMessageServer;
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandSignIn;
        public ICommand CommandSignIn
        {
            get { return (this._commandSignIn) ?? (this._commandSignIn = new DelegateCommand(OnClickSignIn)); }
            set
            {
                if (_commandSignIn != value)
                {
                    _commandSignIn = value;
                    OnClickSignIn();
                }
            }
        }
        private void OnClickSignIn()
        {
            if (string.IsNullOrEmpty(_id))
            {
                ModernDialog.ShowMessage("Empty Id...", "Info", MessageBoxButton.OK);
                return;
            }
            IsActive = true;
            IsEnableID = false;
            IsEnablePassword = false;
            IsEnableLogin = false;
            IsEnableAutoLogin = false;
            var paramLogin = new RequestLoginModel
            {
                UID = App.Current.Properties["Id"].ToString(),
                IP = AppController.LocalIpAddress,
                MAC = AppController.LocalMacAddress,
                PW = App.Current.Properties["Password"].ToString(),
                COUNT = "0"
            };
            var data = ServerController.OnCreatePacket(paramLogin, App.Current.Properties["Uid"].ToString());
            //ServerController.OnSend(data);
            NotifyPush.Notify(NOTIFYCODE.RESLOGIN, null);
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _id = string.Empty;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _password = string.Empty;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isChecked = true;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                this._isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isActive = false;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                this._isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isEnableId = true;
        public bool IsEnableID
        {
            get
            {
                return _isEnableId;
            }
            set
            {
                this._isEnableId = value;
                OnPropertyChanged("IsEnableID");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isEnablePassword = true;
        public bool IsEnablePassword
        {
            get
            {
                return _isEnablePassword;
            }
            set
            {
                this._isEnablePassword = value;
                OnPropertyChanged("IsEnablePassword");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isEnableLogin = true;
        public bool IsEnableLogin
        {
            get
            {
                return _isEnableLogin;
            }
            set
            {
                this._isEnableLogin = value;
                OnPropertyChanged("IsEnableLogin");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isEnableAutoLogin = true;
        public bool IsEnableAutoLogin
        {
            get
            {
                return _isEnableAutoLogin;
            }
            set
            {
                this._isEnableAutoLogin = value;
                OnPropertyChanged("IsEnableAutoLogin");
            }
        }

        private void CallBackReceiveMessageServer(object sender)
        {
            //실패
            ModernDialog.ShowMessage("Fail Id...", "Info", MessageBoxButton.OK);
            IsEnableID = true;
            IsEnablePassword = true;
            IsEnableLogin = true;
            IsEnableAutoLogin = true;
            IsActive = false;
        }
    }
}