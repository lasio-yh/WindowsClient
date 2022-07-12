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
            _boardModel = new ObservableCollection<MessageModel>();
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
