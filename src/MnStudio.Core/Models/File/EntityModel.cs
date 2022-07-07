using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.File
{
    public class EntityModel
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
        private string _value = string.Empty;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                this._value = string.IsNullOrEmpty(value) ? string.Empty : value;
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
    }
}
