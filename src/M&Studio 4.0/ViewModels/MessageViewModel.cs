using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MnStudio.Core.Models;
using MnStudio.Constants;
using System.Windows.Input;

namespace MnStudio.ViewModels
{
    class MessageViewModel : ConnectionViewModel
    {
        public MessageViewModel()
        {
            NotifyPush.ReceiveMessageData += OnReceiveMessage;
            _model = new ObservableCollection<MessageModel>();
        }

        public void OnReceiveMessage(object sender)
        {
            var entity = new MessageModel { ID = "1", Name = "1234", Seq = "1", Time = "2022-04-01 16:00:21", Value = null, Desc = "KT Test Message.", IsChecked = false, Size = "10" };
            Model.Add(entity);
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<MessageModel> _model;
        public ObservableCollection<MessageModel> Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (value != null)
                {
                    this._model = value;
                    OnPropertyChanged("Model");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private MessageModel _selectedMessage;
        public MessageModel SelectedMessage
        {
            get
            {
                return _selectedMessage;
            }
            set
            {
                if (value != null)
                {
                    this._selectedMessage = value;
                    OnPropertyChanged("SelectedMessage");
                }
            }
        }


        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private string _keyword = string.Empty;
        public string Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    this._keyword = value;
                    OnPropertyChanged("Keyword");
                }
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandFind;
        public ICommand CommandFind
        {
            get { return (this._commandFind) ?? (this._commandFind = new DelegateCommand(OnFind)); }
        }
        private void OnFind()
        {
            try
            {

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
    }
}
