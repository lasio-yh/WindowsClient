using System;
namespace Core.Model
{
    class SampleModel
    {
        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _effect = string.Empty;
        public string Effect
        {
            get
            {
                return _effect;
            }
            set
            {
                this._effect = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        private SlideModel _value = new SlideModel();
        public SlideModel Value
        {
            get
            {
                return _value;
            }
            set
            {
                this._value = value == null ? null : value;
            }
        }

        public SampleModel(Item1 source)
        {
            this.Effect = source.Effect;
            this.Value.Name = source.Value[0].Name;
            this.Value.Type = source.Value[0].Type;
            this.Value.Target = source.Value[0].Target;
            this.Value.Origin = source.Value[0].Origin;
            this.Value.Effect = source.Value[0].Effect;
            this.Value.X = source.Value[0].X;
            this.Value.Y = source.Value[0].Y;
            this.Value.Width = source.Value[0].Width;
            this.Value.Height = source.Value[0].Height;
            this.Value.Group = source.Value[0].Group;
            this.Value.Alpha = source.Value[0].Alpha;
        }
    }
    class SlideModel
    {
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
        private string _type = string.Empty;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                this._type = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _target = string.Empty;
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                this._target = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _origin = string.Empty;
        public string Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                this._origin = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _effect = string.Empty;
        public string Effect
        {
            get
            {
                return _effect;
            }
            set
            {
                this._effect = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _x = string.Empty;
        public string X
        {
            get
            {
                return _x;
            }
            set
            {
                this._x = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _y = string.Empty;
        public string Y
        {
            get
            {
                return _y;
            }
            set
            {
                this._y = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _width = string.Empty;
        public string Width
        {
            get
            {
                return _width;
            }
            set
            {
                this._width = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _height = string.Empty;
        public string Height
        {
            get
            {
                return _height;
            }
            set
            {
                this._height = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _alpha = string.Empty;
        public string Alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                this._alpha = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _group = string.Empty;
        public string Group
        {
            get
            {
                return _group;
            }
            set
            {
                this._group = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _text = string.Empty;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                this._text = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _metaData = string.Empty;
        public string MetaData
        {
            get
            {
                return _metaData;
            }
            set
            {
                this._metaData = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }
    }
}
