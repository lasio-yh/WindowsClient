using FirstFloor.ModernUI.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MnStudio.Constants;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Text;
using System.Drawing;
using System.Management;
using System.Windows.Media;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Windows.Forms;
using MnStudio.Core.Models.MiddleWare;
using MnStudio.Core.Services;
using MnStudio.Core.Models;

namespace MnStudio.ViewModels
{
    class DisplayViewModel : DocumentViewModel
    {
        DRAWRULES _ruleType = DRAWRULES.NONE;
        string _autho = string.Empty;
        string _content = string.Empty;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DisplayViewModel()
        {
            NotifyPush.ApplyStanBy += OnApplyStanBy;
        }

        private void OnApplyStanBy(object sender)
        {
            var obj = sender as MessageModel;
            if (obj == null)
                return;

            _ruleType = DRAWRULES.CRAW;
            _autho = obj.Name;
            _content = obj.Desc;
        }

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandInitialize;
        public ICommand CommandInitialize
        {
            get { return (this._commandInitialize) ?? (this._commandInitialize = new DelegateCommand(OnInitialize)); }
        }
        private void OnInitialize()
        {
            try
            {
                var obj = new RequestRenderInitModel
                {
                    command = 1,
                    filename = App.Current.Properties["FileName"].ToString(),
                    filepath = @App.Current.Properties["FilePath"].ToString(),
                    fileindex = 0,
                    displaymode = 0
                };
                MiddleWareController.Send<RequestRenderInitModel>(obj);
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
        private ICommand _commandDispose;
        public ICommand CommandDispose
        {
            get { return (this._commandDispose) ?? (this._commandDispose = new DelegateCommand(OnDispose)); }
        }
        private void OnDispose()
        {
            try
            {
                var obj = new RequestRenderModel { command = 2 };
                MiddleWareController.Send<RequestRenderModel>(obj);
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
        private ICommand _commandDisplay;
        public ICommand CommandDisplay
        {
            get { return (this._commandDisplay) ?? (this._commandDisplay = new DelegateCommand(OnDisplay)); }
        }
        private void OnDisplay()
        {
            try
            {
                LogCommand.WriteCommunication(LOGLEVEL.INFO, "송출을 시작 하였습니다.");
                switch(_ruleType)
                {
                    case DRAWRULES.NONE: break;
                    case DRAWRULES.CUT: 
                        {
                            var obj = new RequestRenderCutModel();
                            obj.command = 3;
                            obj.action = 1;
                            obj.content = _content;
                            MiddleWareController.Send<RequestRenderDisplayModel>(obj);
                            break;
                        }
                    case DRAWRULES.TYPEWRITE:
                        {
                            var obj = new RequestRenderTypeWriteModel();
                            obj.command = 3;
                            obj.action = 2;
                            obj.content = _content;
                            MiddleWareController.Send<RequestRenderDisplayModel>(obj);
                            break;
                        }
                    case DRAWRULES.CRAW: 
                        {
                            var obj = new RequestRenderCrawModel();
                            obj.command = 3;
                            obj.action = 3;
                            obj.speed = 10;
                            obj.margin = 10;
                            obj.width = 1920;
                            obj.isshow = 0;
                            obj.content = _content;
                            MiddleWareController.Send<RequestRenderDisplayModel>(obj);
                            break;
                        }
                    case DRAWRULES.TICKER:
                        {
                            var obj = new RequestRenderTickerModel();
                            obj.command = 3;
                            obj.action = 4;
                            obj.speed = 10;
                            obj.linespeed = 10;
                            obj.content = _content;
                            MiddleWareController.Send<RequestRenderDisplayModel>(obj);
                            break;
                        }
                    case DRAWRULES.TEXTURE: 
                        {
                            var obj = new RequestRenderTextureModel();
                            obj.command = 3;
                            obj.action = 5;
                            obj.content = _content;
                            MiddleWareController.Send<RequestRenderDisplayModel>(obj);
                            break;
                        }
                    default: break;
                }
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
        private ICommand _commandClear;
        public ICommand CommandClear
        {
            get { return (this._commandClear) ?? (this._commandClear = new DelegateCommand(OnClear)); }
        }
        private void OnClear()
        {
            try
            {
                LogCommand.WriteCommunication(LOGLEVEL.INFO, "화면 지우기를 요청하였습니다.");
                var obj = new RequestRenderModel { command = 5 };
                MiddleWareController.Send<RequestRenderModel>(obj);
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
        private ICommand _commandReplay;
        public ICommand CommandReplay
        {
            get { return (this._commandReplay) ?? (this._commandReplay = new DelegateCommand(OnReplay)); }
        }
        private void OnReplay()
        {
            try
            {
                LogCommand.WriteCommunication(LOGLEVEL.INFO, "송출을 재시작 하였습니다.");
                var obj = new RequestRenderDisplayModel { command = 3, action = 1, content = "Sample Text" };
                MiddleWareController.Send<RequestRenderDisplayModel>(obj);
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