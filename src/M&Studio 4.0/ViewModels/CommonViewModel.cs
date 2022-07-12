using FirstFloor.ModernUI.Presentation;
using MnStudio.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MnStudio.ViewModels
{
    public class CommonViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public CommonViewModel()
        {

        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandSave;
        public ICommand CommandSave
        {
            get { return (this._commandSave) ?? (this._commandSave = new DelegateCommand(OnSave)); }
        }
        private void OnSave()
        {
            try
            {
                AppController.SaveConfiguration();
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

        #region Document Setting
        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _fileName = App.Current.Properties["FileName"].ToString();
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._fileName = value;
                    OnPropertyChanged("FileName");
                    App.Current.Properties["FileName"] = _fileName;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _filePath = App.Current.Properties["FilePath"].ToString();
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._filePath = value;
                    OnPropertyChanged("FilePath");
                    App.Current.Properties["FilePath"] = _fileName;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _fileEncoding = App.Current.Properties["Encoding"].ToString();
        public string FileEncoding
        {
            get
            {
                return _fileEncoding;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._fileEncoding = value;
                    OnPropertyChanged("FileEncoding");
                    App.Current.Properties["Encoding"] = _fileEncoding;
                }
            }
        }
        #endregion

        #region Local Setting
        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _localIpAddress = AppController.LocalIpAddress;
        public string LocalIpAddress
        {
            get
            {
                return _localIpAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._localIpAddress = value;
                    OnPropertyChanged("LocalIpAddress");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _localMacAddress = AppController.LocalMacAddress;
        public string LocalMacAddress
        {
            get
            {
                return _localMacAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._localMacAddress = value;
                    OnPropertyChanged("LocalMacAddress");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _id = App.Current.Properties["Id"].ToString();
        public string Id
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
                    OnPropertyChanged("Id");
                    App.Current.Properties["Id"] = _id;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _password = App.Current.Properties["Password"].ToString();
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
                    App.Current.Properties["Password"] = _password;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _applicationName = App.Current.Properties["Caption"].ToString();
        public string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._applicationName = value;
                    OnPropertyChanged("ApplicationName");
                    App.Current.Properties["Caption"] = _applicationName;
                }
            }
        }
        #endregion

        #region Server Setting
        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _serverIp = App.Current.Properties["ServerIp"].ToString();
        public string ServerIp
        {
            get
            {
                return _serverIp;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    _serverIp = value;
                    OnPropertyChanged("ServerIp");
                    App.Current.Properties["ServerIp"] = _serverIp;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _serverPort = App.Current.Properties["ServerPort"].ToString();
        public string ServerPort
        {
            get
            {
                return _serverPort;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    _serverPort = value;
                    OnPropertyChanged("ServerPort");
                    App.Current.Properties["ServerPort"] = _serverPort;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _programKey = App.Current.Properties["ProgramKey"].ToString();
        public string ProgramKey
        {
            get
            {
                return _programKey;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    _programKey = value;
                    OnPropertyChanged("ProgramKey");
                    App.Current.Properties["ProgramKey"] = _selectedFindSize;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] Channel
        {
            get { return new string[] { "1", "2", "3", "4", "5" }; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _selectedChannel = App.Current.Properties["ChannelKey"].ToString();
        public string SelectedChannel
        {
            get { return this._selectedChannel; }
            set
            {
                if (this._selectedChannel != value)
                {
                    _selectedChannel = value;
                    OnPropertyChanged("SelectedChannel");
                    App.Current.Properties["ChannelKey"] = _selectedChannel;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] FindDate
        {
            get { return new string[] { "1", "6", "12", "24", "45", "72" }; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _selectedFindDate = App.Current.Properties["FindDate"].ToString();
        public string SelectedFindDate
        {
            get { return this._selectedFindDate; }
            set
            {
                if (this._selectedFindDate != value)
                {
                    _selectedFindDate = value;
                    OnPropertyChanged("SelectedFindDate");
                    App.Current.Properties["FindDate"] = _selectedFindSize;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] FindSize
        {
            get { return new string[] { "10", "20", "30", "50", "100" }; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _selectedFindSize = App.Current.Properties["FindSize"].ToString();
        public string SelectedFindSize
        {
            get { return this._selectedFindSize; }
            set
            {
                if (this._selectedFindSize != value)
                {
                    _selectedFindSize = value;
                    OnPropertyChanged("SelectedFindSize");
                    App.Current.Properties["FindSize"] = _selectedFindSize;
                }
            }
        }
        #endregion

        #region MiddleWare Setting
        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _middleWareName = App.Current.Properties["MiddleWareName"].ToString();
        public string MIddleWareName
        {
            get
            {
                return _middleWareName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._middleWareName = value;
                    OnPropertyChanged("MIddleWareName");
                    App.Current.Properties["MiddleWareName"] = _middleWareName;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _middleWarePath = App.Current.Properties["MiddleWarePath"].ToString();
        public string MiddleWarePath
        {
            get
            {
                return _middleWarePath;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._middleWarePath = value;
                    OnPropertyChanged("MiddleWarePath");
                    App.Current.Properties["MiddleWarePath"] = _middleWarePath;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _middleWareUri = App.Current.Properties["MiddleWareUri"].ToString();
        public string MiddleWareUri
        {
            get
            {
                return _middleWareUri;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._middleWareUri = value;
                    OnPropertyChanged("MiddleWareUri");
                    App.Current.Properties["MiddleWareUri"] = _middleWareUri;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] DetectTime
        {
            get { return new string[] { "1000", "2000", "3000", "4000", "5000" }; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _selectedDetectTime = App.Current.Properties["DetectTime"].ToString();
        public string SelectedDetectTime
        {
            get
            {
                return _selectedDetectTime;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._selectedDetectTime = value;
                    OnPropertyChanged("SelectedDetectTime");
                    App.Current.Properties["DetectTime"] = _selectedDetectTime;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _selectedTypwWriteDelay = Convert.ToInt32(App.Current.Properties["TypwWriteDelay"]);
        public int SelectedTypwWriteDelay
        {
            get
            {
                return _selectedTypwWriteDelay;
            }
            set
            {
                this._selectedTypwWriteDelay = value;
                OnPropertyChanged("SelectedTypwWriteDelay");
                App.Current.Properties["TypwWriteDelay"] = _selectedTypwWriteDelay;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _selectedCrawSpeed = Convert.ToInt32(App.Current.Properties["CrawSpeed"]);
        public int SelectedCrawSpeed
        {
            get
            {
                return _selectedCrawSpeed;
            }
            set
            {
                this._selectedCrawSpeed = value;
                OnPropertyChanged("SelectedCrawSpeed");
                App.Current.Properties["CrawSpeed"] = _selectedCrawSpeed;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _selectedCrawMargin = Convert.ToInt32(App.Current.Properties["CrawMargin"]);
        public int SelectedCrawMargin
        {
            get
            {
                return _selectedCrawMargin;
            }
            set
            {
                this._selectedCrawMargin = value;
                OnPropertyChanged("SelectedCrawMargin");
                App.Current.Properties["CrawMargin"] = _selectedCrawMargin;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _selectedCrawWidth = Convert.ToInt32(App.Current.Properties["CrawWidth"]);
        public int SelectedCrawWidth
        {
            get
            {
                return _selectedCrawWidth;
            }
            set
            {
                this._selectedCrawWidth = value;
                OnPropertyChanged("SelectedCrawWidth");
                App.Current.Properties["CrawWidth"] = _selectedCrawWidth;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _selectedTickerSpeed = Convert.ToInt32(App.Current.Properties["TickerSpeed"]);
        public int SelectedTickerSpeed
        {
            get
            {
                return _selectedTickerSpeed;
            }
            set
            {
                this._selectedTickerSpeed = value;
                OnPropertyChanged("SelectedTickerSpeed");
                App.Current.Properties["TickerSpeed"] = _selectedTickerSpeed;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _selectedTickerLineSpeed = Convert.ToInt32(App.Current.Properties["TickerLineSpeed"]);
        public int SelectedTickerLineSpeed
        {
            get
            {
                return _selectedTickerLineSpeed;
            }
            set
            {
                this._selectedTickerLineSpeed = value;
                OnPropertyChanged("SelectedTickerLineSpeed");
                App.Current.Properties["TickerLineSpeed"] = _selectedTickerLineSpeed;
            }
        }
        #endregion
    }
}