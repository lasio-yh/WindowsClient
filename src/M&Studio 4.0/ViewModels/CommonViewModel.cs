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
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] Channel
        {
            get { return new string[] { "1", "2","3", "4", "5" }; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] FindDate
        {
            get { return new string[] { "1", "6", "12", "24", "45" }; }
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
        private string _ipAddress = AppController.LocalIpAddress;
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._ipAddress = value;
                    OnPropertyChanged("IpAddress");
                    App.Current.Properties["IpAddress"] = _selectedFindSize;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _macAddress = AppController.LocalMacAddress;
        public string MacAddress
        {
            get
            {
                return _macAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._macAddress = value;
                    OnPropertyChanged("MacAddress");
                    App.Current.Properties["MacAddress"] = _selectedFindSize;
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
                    App.Current.Properties["Channel"] = _selectedFindSize;
                }
            }
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
    }
}