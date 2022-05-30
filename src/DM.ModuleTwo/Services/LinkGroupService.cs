using System;
using FirstFloor.ModernUI.Presentation;
using Core.Contracts;
using Plugin.AccordNet.Views;

namespace Plugin.AccordNet.Services
{
    /// <summary>
    /// Creates a LinkGroup
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// This is the entry point for the option menu.
    /// </remarks>
    public class LinkGroupService : ILinkGroupService
    {
        public LinkGroup GetLinkGroup()
        {
            LinkGroup linkGroup = new LinkGroup
            {
                DisplayName = "AccordNet"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "AccordNet1",
                Source = new Uri($"/Plugin.AccordNet;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "AccordNet2",
                Source = new Uri($"/Plugin.AccordNet;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "AccordNet3",
                Source = new Uri($"/Plugin.AccordNet;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
