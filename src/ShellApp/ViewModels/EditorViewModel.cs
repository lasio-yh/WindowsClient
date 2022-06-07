using Core.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShellApp.ViewModels
{
    public class EditorViewModel : BindableBase
    {
        public EditorViewModel()
        {

        }

        private ICommand _button1Command;
        public ICommand CommonDialog_Click => _button1Command ?? (_button1Command = new DelegateCommand<Customer>(OnButton1Command));
        private void OnButton1Command(Customer param)
        {

        }

        private ICommand _button2Command;
        public ICommand MessageDialog_Click => _button2Command ?? (_button2Command = new DelegateCommand<Customer>(OnButton2Command));
        private void OnButton2Command(Customer param)
        {

        }
    }
}
