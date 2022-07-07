using Prism.Commands;

namespace ShellApp.Constants
{
    public static class CompositeCommands
    {
        public static CompositeCommand OpenCommand = new CompositeCommand();
        public static CompositeCommand SaveCommand = new CompositeCommand();
        public static CompositeCommand ConnectCommand = new CompositeCommand();
        public static CompositeCommand DisconnectCommand = new CompositeCommand();
        public static CompositeCommand FindCommand = new CompositeCommand();
        public static CompositeCommand AddCommand = new CompositeCommand();
        public static CompositeCommand EditCommand = new CompositeCommand();
        public static CompositeCommand RemoveCommand = new CompositeCommand();
        public static CompositeCommand RefreshCommand = new CompositeCommand();
    }
}
