using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MnStudio.Core.Models.File
{
    public class ItemModel
    {
        public Item2 Item { get; protected set; }

        public ItemModel(int id, Item2 item)
        {
            this.Item = item;
        }

        public string Name
        {
            get { return string.Format("Name : {0}", Item.Name); }
        }

        public string Type
        {
            get { return string.Format("Type : {0}", Item.Type); }
        }

        public string Target
        {
            get { return string.Format("Target : {0}", Item.Target); }
        }

        public string Origin
        {
            get { return string.Format("Origin : {0}", Item.Origin); }
        }

        public string Effect
        {
            get { return string.Format("Effect : {0}", Item.Effect); }
        }

        public string X
        {
            get { return string.Format("X : {0}", Item.X); }
        }

        public string Y
        {
            get { return string.Format("Y : {0}", Item.Y); }
        }

        public string Width
        {
            get { return string.Format("Width : {0}", Item.Width); }
        }

        public string Height
        {
            get { return string.Format("Height : {0}", Item.Height); }
        }

        public string Alpha
        {
            get { return string.Format("Alpha : {0}", Item.Alpha); }
        }

        public string Group
        {
            get { return string.Format("Group : {0}", Item.Group); }
        }

        //public Text Text
        //{
        //    get { return string.Format("Name : {0}", Item.Name); }
        //}

        //public File File
        //{
        //    get { return string.Format("Name : {0}", Item.Name); }
        //}
    }
}
