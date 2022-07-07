using Core.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ShellApp.Constants;
using System.Windows;
using System.Windows.Input;

namespace ShellApp.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        public HomeViewModel(IEventAggregator ea)
        {
            OpenCommand = CompositeCommands.OpenCommand;
            SaveCommand = CompositeCommands.SaveCommand;
            ConnectCommand = CompositeCommands.ConnectCommand;
            DisconnectCommand = CompositeCommands.DisconnectCommand;
            FindCommand = CompositeCommands.FindCommand;
            AddCommand = CompositeCommands.AddCommand;
            EditCommand = CompositeCommands.EditCommand;
            RemoveCommand = CompositeCommands.RemoveCommand;
            RefreshCommand = CompositeCommands.RefreshCommand;
        }

        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get => _openCommand;
            set => _openCommand = value;
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get => _saveCommand;
            set => _saveCommand = value;

        }

        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get => _connectCommand;
            set => _connectCommand = value;

        }

        private ICommand _disconnectCommand;
        public ICommand DisconnectCommand
        {
            get => _disconnectCommand;
            set => _disconnectCommand = value;

        }

        private ICommand _findCommand;
        public ICommand FindCommand
        {
            get => _findCommand;
            set => _findCommand = value;
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get => _addCommand;
            set => _addCommand = value;

        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get => _editCommand;
            set => _editCommand = value;

        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get => _removeCommand;
            set => _removeCommand = value;

        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get => _refreshCommand;
            set => _refreshCommand = value;

        }
    }
}