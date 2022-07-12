using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MnStudio.Core.Models.File
{
    public class DocumentModel
    {
        public Item1 Item { get; protected set; }

        public DocumentModel(int id, string name, Item1 item)
        {
            this.Item = item;
            this._documentID = id;
            this._documentName = name;
            ItemCollection = new ObservableCollection<ItemModel>();
            var index = 1;
            foreach (Item2 entity in Item.Value)
            {
                ItemCollection.Add(new ItemModel(index++, entity));
            }
        }

        private ObservableCollection<ItemModel> _itemCollection;
        public ObservableCollection<ItemModel> ItemCollection
        {
            get { return _itemCollection; }
            set {
                if (_itemCollection != value)
                {
                    _itemCollection = value;
                }
            }
        }

        private int _documentID = -1;
        public int DocumentID
        {
            get { return _documentID; }
            set
            {
                _documentID = value;
               
            }
        }

        private string _documentName = string.Empty;
        public string DocumentName
        {
            get { return _documentName; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _documentName = value;
                }
            }
        }

        public string Effect
        {
            get { return Item.Effect; }
        }
    }
}
