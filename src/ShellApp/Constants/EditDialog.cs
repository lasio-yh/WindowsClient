using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

namespace ShellApp.Constants
{
    class EditDialog
    {
        /// <summary>
        /// Show MessageBox
        /// </summary>
        /// <param name="title">parameter by default of title</param>
        /// <param name="content">parameter by default of content</param>
        /// <param name="command">parameter by default of button style</param>
        public static void ShowMessage(string title, string content, MessageBoxButton command)
        {
            ModernDialog.ShowMessage(content, title, command);
        }
    }
}
