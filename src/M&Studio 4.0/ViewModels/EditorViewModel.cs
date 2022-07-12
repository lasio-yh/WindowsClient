using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MnStudio.Constants;

namespace MnStudio.ViewModels
{
    public class EditorViewModel : BaseViewModel
    {
         /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EditorViewModel()
        {
            Autho = string.Empty;
            Desc = string.Empty;
        }

        public void Clear()
        {
            _autho = string.Empty;
            _desc = string.Empty;
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _autho = string.Empty;
        public string Autho
        {
            get
            {
                return _autho;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._autho = value;
                    OnPropertyChanged("Autho");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        public string[] Mediaes
        {
            get { return new string[] { "매체" }; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _selectedMedia = "매체";
        public string SelectedMedia
        {
            get
            {
                return _selectedMedia;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._selectedMedia = value;
                    OnPropertyChanged("SelectedMedia");
                }
            }
        }
       
        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _desc = string.Empty;
        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._desc = value;
                    OnPropertyChanged("Desc");
                }
            }
        }
    }
}
