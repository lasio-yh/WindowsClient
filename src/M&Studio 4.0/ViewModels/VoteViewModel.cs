using MnStudio.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MnStudio.Core.Models;
using System.Windows.Input;

namespace MnStudio.ViewModels
{
    class VoteViewModel : ConnectionViewModel
    {
        public VoteViewModel()
        {
            _model = new ObservableCollection<MessageModel>
            {
                new MessageModel{ID = "1", Name = "1234", Seq="1", Time="2022-04-01 16:00:21", Value = null, Desc = "KT Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "2", Name = "5678", Seq="2", Time="2022-04-02 05:00:34",Value = null, Desc = "SKT Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "3", Name = "9123", Seq="3", Time="2022-04-03 07:12:24",Value = null, Desc = "LG Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "4", Name = "3435", Seq="4", Time="2022-04-03 08:43:12",Value = null, Desc = "SKT Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "5", Name = "6565", Seq="5", Time="2022-04-03 12:21:43",Value = null, Desc = "LG Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "6", Name = "9833", Seq="6", Time="2022-04-03 15:00:45",Value = null, Desc = "SKT Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "7", Name = "6444", Seq="7", Time="2022-04-03 18:23:13",Value = null, Desc = "LG Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "8", Name = "1218", Seq="8", Time="2022-04-03 06:45:23",Value = null, Desc = "SKT Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "9", Name = "8785", Seq="9", Time="2022-04-03 07:23:21",Value = null, Desc = "KT Test Message.", IsChecked = false, Size = "10"}
                , new MessageModel{ID = "10", Name = "3434", Seq="10", Time="2022-04-03 16:12:21",Value = null, Desc = "LG Test Message.", IsChecked = false, Size = "10"}
            };
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
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandAddCandidate;
        public ICommand CommandAddCandidate
        {
            get { return (this._commandAddCandidate) ?? (this._commandAddCandidate = new DelegateCommand(OnAddCandidate)); }
        }
        private void OnAddCandidate()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "후보 등록 버튼을 선택하였습니다.");
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
        private ICommand _commandEditCandidate;
        public ICommand CommandEditCandidate
        {
            get { return (this._commandEditCandidate) ?? (this._commandEditCandidate = new DelegateCommand(OnEditCandidate)); }
        }
        private void OnEditCandidate()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "후보 수정 버튼을 선택하였습니다.");
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
        private ICommand _commandRemoveCandidate;
        public ICommand CommandRemoveCandidate
        {
            get { return (this._commandRemoveCandidate) ?? (this._commandRemoveCandidate = new DelegateCommand(OnRemoveCandidate)); }
        }
        private void OnRemoveCandidate()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "후보 삭제 버튼을 선택하였습니다.");
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
        private ICommand _commandFindVote;
        public ICommand CommandFindVote
        {
            get { return (this._commandFindVote) ?? (this._commandFindVote = new DelegateCommand(OnFindVote)); }
        }
        private void OnFindVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 조회 버튼을 선택하였습니다.");
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
        private ICommand _commandAddVote;
        public ICommand CommandAddVote
        {
            get { return (this._commandAddVote) ?? (this._commandAddVote = new DelegateCommand(OnAddVote)); }
        }
        private void OnAddVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 추가 버튼을 선택하였습니다.");
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
        private ICommand _commandEditVote;
        public ICommand CommandEditVote
        {
            get { return (this._commandEditVote) ?? (this._commandEditVote = new DelegateCommand(OnEditVote)); }
        }
        private void OnEditVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 수정 버튼을 선택하였습니다.");
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
        private ICommand _commandRemoveVote;
        public ICommand CommandRemoveVote
        {
            get { return (this._commandRemoveVote) ?? (this._commandRemoveVote = new DelegateCommand(OnRemoveVote)); }
        }
        private void OnRemoveVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 삭제 버튼을 선택하였습니다.");
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
        private ICommand _commandStartVote;
        public ICommand CommandStartVote
        {
            get { return (this._commandStartVote) ?? (this._commandStartVote = new DelegateCommand(OnStartVote)); }
        }
        private void OnStartVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 시작 버튼을 선택하였습니다.");
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
        private ICommand _commandEndVote;
        public ICommand CommandEndVote
        {
            get { return (this._commandEndVote) ?? (this._commandEndVote = new DelegateCommand(OnEndVote)); }
        }
        private void OnEndVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 종료 버튼을 선택하였습니다.");
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
        private ICommand _commandActiveVote;
        public ICommand CommandActiveVote
        {
            get { return (this._commandActiveVote) ?? (this._commandActiveVote = new DelegateCommand(OnActiveVote)); }
        }
        private void OnActiveVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 송출 시작버튼을 선택하였습니다.");
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
        private ICommand _commandStanByVote;
        public ICommand CommandStanyByVote
        {
            get { return (this._commandStanByVote) ?? (this._commandStanByVote = new DelegateCommand(OnStanyByVote)); }
        }
        private void OnStanyByVote()
        {
            try
            {
                LogCommand.WriteAction(LOGLEVEL.INFO, "투표 송출 중지버튼을 선택하였습니다.");
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
