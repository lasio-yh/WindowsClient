using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using FirstFloor.ModernUI.Presentation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MnStudio.Constants;
using System.Windows;
using System.Windows.Controls;
using MnStudio.Core.Models.File;
using MnStudio.Core.Models;
using MnStudio.Core.Services;

namespace MnStudio.ViewModels
{
    class DocumentViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DocumentViewModel()
        {
            NotifyPush.OpenFile += ReceiveOpen;
            NotifyPush.ClearFile += ReceiveClear;
            NotifyPush.UndoSlide += ReceiveUndo;
            NotifyPush.RedoSlide += ReceiveRedo;

            DocumentDataSource = new ObservableCollection<DocumentModel>();
        }

        private ObservableCollection<DocumentModel> _documentDataSource;
        public ObservableCollection<DocumentModel> DocumentDataSource
        {
            get { return _documentDataSource; }
            set
            {
                if (_documentDataSource != value)
                {
                    _documentDataSource = value;
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private Document _entity;
        public Document Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                if (value != null)
                {
                    this._entity = value;
                    OnPropertyChanged("Entity");
                }
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _totalIndex;
        public int TotalIndex
        {
            get
            {
                return _totalIndex;
            }
            set
            {
                this._totalIndex = value;
                OnPropertyChanged("TotalIndex");
            }
        }

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private int _currentIndex;
        public int CurrentIndex
        {
            get
            {
                return _currentIndex;
            }
            set
            {
                this._currentIndex = value;
                OnPropertyChanged("CurrentIndex");
            }
        }

        private void ReceiveOpen(object sender)
        {
            if (sender == null)
                return;

            _entity = sender as Document;
            TotalIndex = Entity.Value.Count;
            CurrentIndex = 1;
            var index = 1;
            foreach(Item1 item in Entity.Value)
            {
                DocumentDataSource.Add(new DocumentModel(index++, "Effect", item));
            }
        }

        private void ReceiveClear(object sender)
        {
            _entity = null;
            TotalIndex = 0;
            CurrentIndex = 0;
        }

        private void ReceiveUndo(object sender)
        {
            if (_entity == null)
                return;

            if (_currentIndex < 2)
                return;

            CurrentIndex--;
        }

        private void ReceiveRedo(object sender)
        {
            if (_entity == null)
                return;

            if (_currentIndex >= _totalIndex)
                return;

            CurrentIndex++;
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandOpenFile;
        public ICommand CommandOpenFile
        {
            get { return (this._commandOpenFile) ?? (this._commandOpenFile = new DelegateCommand(OnOpenFile)); }
        }
        public void OnOpenFile()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "자막파일을 열었습니다.");
                var fileService = new FileService();
                var result = fileService.OnOpenFile(App.Current.Properties["FilePath"].ToString(), App.Current.Properties["Encoding"].ToString());
                if (result == null)
                    return;

                NotifyPush.Notify(NOTIFYCODE.SUCCESSFILEOPEN, result);
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
        private ICommand _commandClearFile;
        public ICommand CommandClearFile
        {
            get { return (this._commandClearFile) ?? (this._commandClearFile = new DelegateCommand(OnClearFile)); }
        }
        public void OnClearFile()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "자막파일을 초기화 하였습니다.");
                NotifyPush.Notify(NOTIFYCODE.SUCCESSFILECLEAR, null);
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
        private ICommand _commandSaveFile;
        public ICommand CommandSaveFile
        {
            get { return (this._commandSaveFile) ?? (this._commandSaveFile = new DelegateCommand(OnSaveFile)); }
        }
        public void OnSaveFile()
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "자막파일을 저장하였습니다.");
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
        private ICommand _commandUndoFile;
        public ICommand CommandUndoFile
        {
            get { return (this._commandUndoFile) ?? (this._commandUndoFile = new DelegateCommand(OnUndoFile)); }
        }
        public void OnUndoFile()
        {
            try
            {
                NotifyPush.Notify(NOTIFYCODE.UNDOSLIDE, null);
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
        private ICommand _commandRedoFile;
        public ICommand CommandRedoFile
        {
            get { return (this._commandRedoFile) ?? (this._commandRedoFile = new DelegateCommand(OnRedoFile)); }
        }
        public void OnRedoFile()
        {
            try
            {
                NotifyPush.Notify(NOTIFYCODE.REDOSLIDE, null);
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