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
            _datasource = new ObservableCollection<EntityModel>();
            NotifyPush.OpenFile += CallBackOpen;
            NotifyPush.ClearFile += CallBackClear;
            NotifyPush.UndoSlide += CallBackPrev;
            NotifyPush.RedoSlide += CallBackNext;
        }

        private Document _entity;

        /// <summary>
        /// implement of property
        /// </summary>
        /// <returns>value in property</returns>
        private ObservableCollection<EntityModel> _datasource;
        public ObservableCollection<EntityModel> DataSource
        {
            get
            {
                return _datasource;
            }
            set
            {
                if (value != null)
                {
                    this._datasource = value;
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

        private void AddDataSource(int param)
        {
            var index = param - 1;
            DataSource.Clear();
            DataSource.Add(new EntityModel { ID = "MainEffect", Value = _entity.Value[index].Effect });
            DataSource.Add(new EntityModel { ID = "Name", Value = _entity.Value[index].Value[0].Name });
            DataSource.Add(new EntityModel { ID = "Type", Value = _entity.Value[index].Value[0].Type });
            DataSource.Add(new EntityModel { ID = "Target", Value = _entity.Value[index].Value[0].Target });
            DataSource.Add(new EntityModel { ID = "Origin", Value = _entity.Value[index].Value[0].Origin });
            DataSource.Add(new EntityModel { ID = "SubEffect", Value = _entity.Value[index].Value[0].Effect });
            DataSource.Add(new EntityModel { ID = "X", Value = _entity.Value[index].Value[0].X });
            DataSource.Add(new EntityModel { ID = "Y", Value = _entity.Value[index].Value[0].Y });
            DataSource.Add(new EntityModel { ID = "Width", Value = _entity.Value[index].Value[0].Width });
            DataSource.Add(new EntityModel { ID = "Height", Value = _entity.Value[index].Value[0].Height });
            DataSource.Add(new EntityModel { ID = "Group", Value = _entity.Value[index].Value[0].Group });
            DataSource.Add(new EntityModel { ID = "Alpha", Value = _entity.Value[index].Value[0].Alpha });
            DataSource.Add(new EntityModel { ID = "Align", Value = _entity.Value[index].Value[0].Text.Align });
            DataSource.Add(new EntityModel { ID = "Blur", Value = _entity.Value[index].Value[0].Text.Blur });
            DataSource.Add(new EntityModel { ID = "Edge", Value = _entity.Value[index].Value[0].Text.Edge });
            DataSource.Add(new EntityModel { ID = "Face", Value = _entity.Value[index].Value[0].Text.Face });
            DataSource.Add(new EntityModel { ID = "FontType", Value = _entity.Value[index].Value[0].Text.FontType });
            DataSource.Add(new EntityModel { ID = "TextHeight", Value = _entity.Value[index].Value[0].Text.Height });
            DataSource.Add(new EntityModel { ID = "Interval", Value = _entity.Value[index].Value[0].Text.Interval });
            DataSource.Add(new EntityModel { ID = "Italic", Value = _entity.Value[index].Value[0].Text.Italic });
            DataSource.Add(new EntityModel { ID = "LineInterval", Value = _entity.Value[index].Value[0].Text.LineInterval });
            DataSource.Add(new EntityModel { ID = "TextName", Value = _entity.Value[index].Value[0].Text.Name });
            DataSource.Add(new EntityModel { ID = "Shadow", Value = _entity.Value[index].Value[0].Text.Shadow });
            DataSource.Add(new EntityModel { ID = "ShadowAlpha", Value = _entity.Value[index].Value[0].Text.ShadowAlpha });
            DataSource.Add(new EntityModel { ID = "ShadowBlur", Value = _entity.Value[index].Value[0].Text.ShadowBlur });
            DataSource.Add(new EntityModel { ID = "ShadowX", Value = _entity.Value[index].Value[0].Text.ShadowX });
            DataSource.Add(new EntityModel { ID = "ShadowY", Value = _entity.Value[index].Value[0].Text.ShadowY });
            DataSource.Add(new EntityModel { ID = "TextType", Value = _entity.Value[index].Value[0].Text.TextType });
            DataSource.Add(new EntityModel { ID = "Value", Value = _entity.Value[index].Value[0].Text.Value });
            DataSource.Add(new EntityModel { ID = "Weight", Value = _entity.Value[index].Value[0].Text.Weight });
            DataSource.Add(new EntityModel { ID = "TextWidth", Value = _entity.Value[index].Value[0].Text.Width });
        }

        private void CallBackOpen(object sender)
        {
            if (sender == null)
                return;

            _entity = sender as Document;
            TotalIndex = _entity.Value.Count;
            CurrentIndex = 1;
            AddDataSource(_currentIndex);
        }


        private void CallBackClear(object sender)
        {
            _entity = null;
            TotalIndex = 0;
            CurrentIndex = 0;
            DataSource.Clear();
        }

        private void CallBackPrev(object sender)
        {
            if (_entity == null)
                return;

            if (_currentIndex < 2)
                return;

            CurrentIndex--;
            AddDataSource(_currentIndex);
        }

        private void CallBackNext(object sender)
        {
            if (_entity == null)
                return;

            if (_currentIndex >= _totalIndex)
                return;

            CurrentIndex++;
            AddDataSource(_currentIndex);
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