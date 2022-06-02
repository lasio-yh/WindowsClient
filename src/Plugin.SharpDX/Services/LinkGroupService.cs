using System;
using FirstFloor.ModernUI.Presentation;
using Core.Contracts;
using Plugin.SharpDX.Views;

namespace Plugin.SharpDX.Services
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
                DisplayName = "SharpDX"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "SharpDX1",
                Source = new Uri($"/Plugin.SharpDX;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "SharpDX2",
                Source = new Uri($"/Plugin.SharpDX;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "SharpDX3",
                Source = new Uri($"/Plugin.SharpDX;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
