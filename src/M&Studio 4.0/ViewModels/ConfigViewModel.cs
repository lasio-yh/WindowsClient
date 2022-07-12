using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ConfigViewModel()
        {

        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private const string _title = "ABOUT";
        public string Title 
        {
            get { return _title; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private const string _vision = "Controller Version 0.0.0.0";
        public string Vision
        {
            get { return _vision; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private const string _desc = "Copyright(C) 2022";
        public string Desc
        {
            get { return _desc; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private const string _macAddress = "Mac Address 00:26:18:9F:90:F9";
        public string MacAddress
        {
            get { return _macAddress; }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private const string _productName = "ProductName Controller";
        public string ProductName
        {
            get { return _productName; }
        }
    }
}