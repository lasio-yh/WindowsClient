using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MnStudio.Core.Models;
using MnStudio.Constants;
using System.Windows.Input;
using System.Windows.Threading;
using MnStudio.Core.Models.Server;
using MnStudio.Views;
using System.Windows.Controls;
using System.Windows;

namespace MnStudio.ViewModels
{
    class MessageViewModel : ConnectionViewModel
    {
        private DispatcherTimer _requestTimer;
      
        public MessageViewModel()
        {
            NotifyPush.ReceiveStart += OnReceiveStart;
            NotifyPush.ReceiveStop += OnReceiveStop;
            NotifyPush.ReceiveMessageSetting += OnReceiveMessageSetting;
            NotifyPush.ReceiveMessageData += OnReceiveMessageData;
            NotifyPush.ReceiveDisplay += OnReceiveDisplay;
            _requestTimer = new DispatcherTimer();
            _requestTimer.Interval = TimeSpan.FromMilliseconds(5000);
            _requestTimer.Tick += OnRequestMessage;
            _originModel = new ObservableCollection<MessageModel>();
            _boardModel = new ObservableCollection<MessageModel>();
            _archiveModel = new ObservableCollection<MessageModel>();
            _stanbyModel = new ObservableCollection<MessageModel>();
            _compleateModel = new ObservableCollection<MessageModel>();
        }

        private void OnReceiveStart(object sender)
        {
            try
            {
                var paramMessageSetting = new RequestMessageSettingModel
                {
                    BEFORE = App.Current.Properties["FindDate"].ToString(),
                    CHN = App.Current.Properties["ChannelKey"].ToString(),
                    COUNT = App.Current.Properties["FindSize"].ToString(),
                    IP = AppController.LocalIpAddress,
                    MAC = AppController.LocalMacAddress,
                    PGM = App.Current.Properties["ProgramKey"].ToString(),
                    UID = App.Current.Properties["Id"].ToString()
                };
                var data = ServerController.OnCreatePacket(paramMessageSetting, PACKETCOMMAND.MESSAGESETTING.ToString());
                //ServerController.OnSend(data);

                NotifyPush.Notify(NOTIFYCODE.RESMESSAGESETTING, null);
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

        private void OnReceiveStop(object sender)
        {
            try
            {
                _requestTimer.Stop();
                AppController.StartReceive = false;
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

        private void OnRequestMessage(object sender, EventArgs e)
        {
            try
            {
                if (!AppController.StartReceive)
                    return;

                var paramMessageData = new RequestMessageDataModel
                {
                    SEQ = "",
                    CHN = App.Current.Properties["ChannelKey"].ToString(),
                    COUNT = "0",
                    IP = AppController.LocalIpAddress,
                    MAC = AppController.LocalMacAddress,
                    PGM = App.Current.Properties["ProgramKey"].ToString(),
                    UID = App.Current.Properties["Id"].ToString()
                };
                var data = ServerController.OnCreatePacket(paramMessageData, PACKETCOMMAND.MESSAGEDATA.ToString());
                //ServerController.OnSend(data);

                NotifyPush.Notify(NOTIFYCODE.RESMESSAGEDATA, null);
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

        public void OnReceiveMessageSetting(object sender)
        {
            _requestTimer.Start();
            AppController.StartReceive = true;
        }

        public void OnReceiveMessageData(object sender)
        {
            var entity = new MessageModel { ID = BoardModel.Count, Name = "1234", Seq = BoardModel.Count, Time = DateTime.Now, Value = null, Desc = "KT Test Message.", IsChecked = false, Size = "KT Test Message".Length };
            if (BoardModel.Count > Convert.ToInt32(App.Current.Properties["BoardSize"]))
                BoardModel.RemoveAt(Convert.ToInt32(App.Current.Properties["BoardSize"]));

            BoardModel.Insert(0, entity);
            OriginModel.Insert(0, entity);
        }

        private void OnReceiveDisplay(object sender)
        {
            try
            {
                if (SelectedMessageStanBy == null)
                    return;

                CompleateModel.Add(SelectedMessageStanBy);
                StanByModel.Remove(SelectedMessageStanBy);
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

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<MessageModel> _originModel;
        public ObservableCollection<MessageModel> OriginModel
        {
            get
            {
                return _originModel;
            }
            set
            {
                if (value != null)
                {
                    this._originModel = value;
                    OnPropertyChanged("OriginModel");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<MessageModel> _boardModel;
        public ObservableCollection<MessageModel> BoardModel
        {
            get
            {
                return _boardModel;
            }
            set
            {
                if (value != null)
                {
                    this._boardModel = value;
                    OnPropertyChanged("BoardModel");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<MessageModel> _archiveModel;
        public ObservableCollection<MessageModel> ArchiveModel
        {
            get
            {
                return _archiveModel;
            }
            set
            {
                if (value != null)
                {
                    this._archiveModel = value;
                    OnPropertyChanged("ArchiveModel");
                }
            }
        }


        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<MessageModel> _stanbyModel;
        public ObservableCollection<MessageModel> StanByModel
        {
            get
            {
                return _stanbyModel;
            }
            set
            {
                if (value != null)
                {
                    this._stanbyModel = value;
                    OnPropertyChanged("StanByModel");
                }
            }
        }


        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<MessageModel> _compleateModel;
        public ObservableCollection<MessageModel> CompleateModel
        {
            get
            {
                return _compleateModel;
            }
            set
            {
                if (value != null)
                {
                    this._compleateModel = value;
                    OnPropertyChanged("CompleateModel");
                }
            }
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandDoubleClickBoard;
        public ICommand CommandDoubleClickBoard
        {
            get { return (this._commandDoubleClickBoard) ?? (this._commandDoubleClickBoard = new DelegateCommand(OnDoubleClickBoard)); }
        }
        private void OnDoubleClickBoard()
        {
            try
            {
                if (SelectedMessageBoard == null)
                    return;

                ArchiveModel.Add(SelectedMessageBoard);
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandDoubleClickArchive;
        public ICommand CommandDoubleClickArchive
        {
            get { return (this._commandDoubleClickArchive) ?? (this._commandDoubleClickArchive = new DelegateCommand(OnDoubleClickArchive)); }
        }
        private void OnDoubleClickArchive()
        {
            try
            {
                if (SelectedMessageArchive == null)
                    return;

                var content = new MessageEditor();
                var item = content.DataContext as EditorViewModel;
                if (item == null)
                    return;

                item.Autho = SelectedMessageArchive.Name;
                item.Desc = SelectedMessageArchive.Desc;
                var dlg = new ModernDialog
                {
                    Title = "메시지 편집",
                    Content = content
                };
                dlg.Buttons = new Button[] { dlg.OkButton, dlg.CancelButton };
                if (dlg.ShowDialog() != true)
                    return;
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandAddMessage;
        public ICommand CommandAddMessage
        {
            get { return (this._commandAddMessage) ?? (this._commandAddMessage = new DelegateCommand(OnAddMessage)); }
        }
        private void OnAddMessage()
        {
            try
            {
                var content = new MessageEditor();
                var redoItem = content.DataContext as EditorViewModel;
                if (redoItem == null)
                    return;

                redoItem.Clear();
                var dlg = new ModernDialog
                {
                    Title = "메시지 추가",
                    Content = content
                };
                dlg.Buttons = new Button[] { dlg.OkButton, dlg.CancelButton };
                if (dlg.ShowDialog() != true)
                    return;
                
                var undoItem = content.DataContext as EditorViewModel;
                if (undoItem == null)
                    return;

                var entity = new MessageModel { ID = BoardModel.Count, Name = undoItem.Autho, Seq = BoardModel.Count, Time = DateTime.Now, Value = null, Desc = undoItem.Desc, IsChecked = false, Size = "KT Test Message".Length };
                ArchiveModel.Add(entity);
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandEditMessage;
        public ICommand CommandEditMessage
        {
            get { return (this._commandEditMessage) ?? (this._commandEditMessage = new DelegateCommand(OnEditMessage)); }
        }
        private void OnEditMessage()
        {
            try
            {
                if (SelectedMessageArchive == null)
                    return;
                
                var content = new MessageEditor();
                var item = content.DataContext as EditorViewModel;
                if (item == null)
                    return;

                item.Autho = SelectedMessageArchive.Name;
                item.Desc = SelectedMessageArchive.Desc;
                var dlg = new ModernDialog
                {
                    Title = "메시지 편집",
                    Content = content
                };
                dlg.Buttons = new Button[] { dlg.OkButton, dlg.CancelButton };
                if (dlg.ShowDialog() != true)
                    return;

                var undoItem = content.DataContext as EditorViewModel;
                if (undoItem == null)
                    return;

                //기존데이터 삭제 후 수정데이터 추가
                var entity = new MessageModel { ID = BoardModel.Count, Name = undoItem.Autho, Seq = BoardModel.Count, Time = DateTime.Now, Value = null, Desc = undoItem.Desc, IsChecked = false, Size = "KT Test Message".Length };
                ArchiveModel.Add(entity);
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandRemoveMessage;
        public ICommand CommandRemoveMessage
        {
            get { return (this._commandRemoveMessage) ?? (this._commandRemoveMessage = new DelegateCommand(OnRemoveMessage)); }
        }
        private void OnRemoveMessage()
        {
            try
            {
                if (ModernDialog.ShowMessage("정말 삭제하시겠습니까?", "Info", MessageBoxButton.OK) == MessageBoxResult.OK)
                    ArchiveModel.Remove(SelectedMessageArchive);
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandImportMessage;
        public ICommand CommandImportMessage
        {
            get { return (this._commandImportMessage) ?? (this._commandImportMessage = new DelegateCommand(OnImportMessage)); }
        }
        private void OnImportMessage()
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandExportMessage;
        public ICommand CommandExportMessage
        {
            get { return (this._commandExportMessage) ?? (this._commandExportMessage = new DelegateCommand(OnExportMessage)); }
        }
        private void OnExportMessage()
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

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandStanByMessage;
        public ICommand CommandStanByMessage
        {
            get { return (this._commandStanByMessage) ?? (this._commandStanByMessage = new DelegateCommand(OnStanByMessage)); }
        }
        private void OnStanByMessage()
        {
            try
            {
                if (SelectedMessageArchive == null)
                    return;

                StanByModel.Add(SelectedMessageArchive);
                ArchiveModel.Remove(SelectedMessageArchive);
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

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private MessageModel _selectedMessageBoard;
        public MessageModel SelectedMessageBoard
        {
            get
            {
                return _selectedMessageBoard;
            }
            set
            {
                if (value != null)
                {
                    this._selectedMessageBoard = value;
                    OnPropertyChanged("SelectedMessageBoard");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private MessageModel _selectedMessageArchive;
        public MessageModel SelectedMessageArchive
        {
            get
            {
                return _selectedMessageArchive;
            }
            set
            {
                if (value != null)
                {
                    this._selectedMessageArchive = value;
                    OnPropertyChanged("SelectedMessageArchive");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private MessageModel _selectedMessageStanBy;
        public MessageModel SelectedMessageStanBy
        {
            get
            {
                return _selectedMessageStanBy;
            }
            set
            {
                if (value != null)
                {
                    this._selectedMessageStanBy = value;
                    OnPropertyChanged("SelectedMessageStanBy");
                    NotifyPush.Notify(NOTIFYCODE.APPLYSTANBY, SelectedMessageStanBy);
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private MessageModel _selectedMessageCompleate;
        public MessageModel SelectedMessageCompleate
        {
            get
            {
                return _selectedMessageCompleate;
            }
            set
            {
                if (value != null)
                {
                    this._selectedMessageCompleate = value;
                    OnPropertyChanged("SelectedMessageCompleate");
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
                if (string.IsNullOrEmpty(Keyword))
                    return;

                BoardModel.Clear();
                var data = OriginModel.Where(item => item.Desc.Equals(Keyword)).ToList();
                if (data.Count == 0)
                    return;

                data.ForEach(item => BoardModel.Add(item));
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