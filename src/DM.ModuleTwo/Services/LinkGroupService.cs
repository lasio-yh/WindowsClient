using System;
using FirstFloor.ModernUI.Presentation;
using Core.Contracts;
using Plugin.Naudio.Views;

namespace Plugin.Naudio.Services
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
                DisplayName = "Naudio"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Naudio",
                Source = new Uri($"/Plugin.Naudio;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
