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
        private int _id = -1;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
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
                if(value != null) 
                    this._value =  value;
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
        private int _size = -1;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                this._size = value;
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
        private DateTime _time = DateTime.Now;
        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                this._time = value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _seq = -1;
        public int Seq
        {
            get
            {
                return _seq;
            }
            set
            {
                this._seq = value;
            }
        }
    }
}
