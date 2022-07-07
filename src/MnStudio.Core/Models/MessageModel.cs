using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models
{
    public class MessageModel
    {
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
                this._id = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private object _value = null;
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if(value != null) this._value =  value;
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
                this._desc = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _size = string.Empty;
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                this._size = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private bool _isChecked = false;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                this._isChecked = value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _status = string.Empty;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                this._status = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _time = string.Empty;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                this._time = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _seq = string.Empty;
        public string Seq
        {
            get
            {
                return _seq;
            }
            set
            {
                this._seq = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }
    }
}
