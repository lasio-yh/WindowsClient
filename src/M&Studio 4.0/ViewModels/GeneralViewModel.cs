using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnStudio.Constants;
using MnStudio.Core.Models.File;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MnStudio.ViewModels
{
    class GeneralViewModel : ConfigViewModel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public GeneralViewModel()
        {
            DataSource = new ObservableCollection<EntityModel>
            {
                    new EntityModel{ID = "Find Date", Value = App.Current.Properties["FindDate"].ToString()}
               ,    new EntityModel{ID = "Channel", Value = App.Current.Properties["Channel"].ToString()}
               ,    new EntityModel{ID = "Find Size", Value = App.Current.Properties["FindSize"].ToString()}
               ,    new EntityModel{ID = "IP", Value = "127.0.0.1"}
               ,    new EntityModel{ID = "MAC Address", Value = ""}
               ,    new EntityModel{ID = "Program", Value = App.Current.Properties["Program"].ToString()}
               ,    new EntityModel{ID = "Uid", Value = ""}
            };
        }

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
        private EntityModel _selectedMessage;
        public EntityModel SelectedMessage
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
        /// implement of icommand can execute method
        /// </summary>
        /// <returns>can execute or not</returns>
        private ICommand _commandSave;
        public ICommand CommandSave
        {
            get { return (this._commandSave) ?? (this._commandSave = new DelegateCommand(OnSave)); }
        }
        private void OnSave()
        {
            try
            {
                App.Current.Properties["FindDate"] = DataSource.Where(item => item.ID.Equals("Find Date")).FirstOrDefault().Value;
                App.Current.Properties["Channel"] = DataSource.Where(item => item.ID.Equals("Channel")).FirstOrDefault().Value;
                App.Current.Properties["FindSize"] = DataSource.Where(item => item.ID.Equals("Find Size")).FirstOrDefault().Value;
                App.Current.Properties["Program"] = DataSource.Where(item => item.ID.Equals("Program")).FirstOrDefault().Value;
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
