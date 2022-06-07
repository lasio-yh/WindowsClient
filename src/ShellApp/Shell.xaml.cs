using System;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using ShellApp.Constants;
using ShellApp.Views;

namespace ShellApp
{
    public partial class Shell : ModernWindow
    {
        public Shell()
        {
            InitializeComponent();
            AppearanceManager.Current.ThemeSource = new Uri(ThemesPath.DarkCustom2ImageTheme, UriKind.Relative);
        }

        public void AddLinkGroups(LinkGroupCollection linkGroupCollection)
        {
            CreateMenuLinkGroup();

            foreach (LinkGroup linkGroup in linkGroupCollection)
            {
                this.MenuLinkGroups.Add(linkGroup);
            }
        }

        private void CreateMenuLinkGroup()
        {
            this.MenuLinkGroups.Clear();

            LinkGroup linkGroup = new LinkGroup
            {
                DisplayName = "Settings",
                GroupKey = "settings"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Settings options",
                Source = GetUri(typeof(SettingsView))
            });

            this.MenuLinkGroups.Add(linkGroup);

            linkGroup = new LinkGroup
            {
                DisplayName = "Common"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Layout Page",
                Source = GetUri(typeof(LayoutPage))
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Split Page",
                Source = GetUri(typeof(SplitPage))
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "List Page",
                Source = GetUri(typeof(ListPage))
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Tab Page",
                Source = GetUri(typeof(TabPage))
            });

            this.MenuLinkGroups.Add(linkGroup);
        }

        private Uri GetUri(Type viewType)
        {
            return new Uri($"/Views/{viewType.Name}.xaml", UriKind.Relative);
        }
    }
}