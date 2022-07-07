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
            AppearanceManager.Current.ThemeSource = new Uri(ThemesPath.DarkBingImage, UriKind.Relative);
        }

        public void AddLinkGroups(LinkGroupCollection linkGroupCollection)
        {
            CreateMenuLinkGroup();
            foreach (LinkGroup linkGroup in linkGroupCollection)
            {
                MenuLinkGroups.Add(linkGroup);
            }
        }

        private void CreateMenuLinkGroup()
        {
            MenuLinkGroups.Clear();
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

            MenuLinkGroups.Add(linkGroup);
            linkGroup = new LinkGroup
            {
                DisplayName = Properties.Resources.GRP_NAME1
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "MainView",
                Source = GetUri(typeof(MainView))
            });

            //linkGroup.Links.Add(new Link
            //{
            //    DisplayName = "MasterDetail",
            //    Source = GetUri(typeof(MasterDetailPage))
            //});

            //linkGroup.Links.Add(new Link
            //{
            //    DisplayName = "Editor",
            //    Source = GetUri(typeof(EditorPage))
            //});

            //linkGroup.Links.Add(new Link
            //{
            //    DisplayName = "Chart",
            //    Source = GetUri(typeof(ChartPage))
            //});

            MenuLinkGroups.Add(linkGroup);
        }

        private Uri GetUri(Type viewType)
        {
            return new Uri($"/Views/{viewType.Name}.xaml", UriKind.Relative);
        }
    }
}