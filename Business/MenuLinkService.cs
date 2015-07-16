using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer;

namespace EPiCenterBaseProject.Business
{
    public class MenuLinkService : IMenuLinkService
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public IEnumerable<PageData> GetMainMenuLinks()
        {
            var menuContainer = _pageService.GetStartPage().MenuContainer;
            var menuList = new List<PageData>();

            if (!PageReference.IsNullOrEmpty(menuContainer))
            {
                menuList = _contentRepository.GetChildren<PageData>(menuContainer).ToList();
            }

            return menuList;
        }
    }
}