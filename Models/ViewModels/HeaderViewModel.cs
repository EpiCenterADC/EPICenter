using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class HeaderViewModel
    {
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public PageData StartPage { get; set; }
        public bool IsUserLoggedIn { get; set; }
        public IEnumerable<PageData> MenuLinks { get; set; }

        public PageData CurrentPage
        {
            get
            {
                PageRouteHelper pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<PageRouteHelper>();
                PageData currentPage = pageRouteHelper.Page;
                return currentPage;


            }
        }

        public bool IsCurrentPageActive(PageData page)
        {
            bool IsInActive = false;

            PageReference pageReference = PageReference.ParseUrl(page.LinkURL);

            PageData pageName = _contentRepository.Get<PageData>(pageReference);

            if (CurrentPage != null)
            {
                IsInActive = CurrentPage.ContentLink.ID == pageName.ContentLink.ID ? true : false;
            }

            return IsInActive;
        }

        public bool IsChildPageExists(PageData page)
        {
            bool blnIsChildExists = false;

            if (page != null)
            {
                blnIsChildExists = _contentRepository.GetChildren<PageData>(page.ContentLink).Any();
            }

            return blnIsChildExists;

        }

        public IEnumerable<PageData> GetChildPages(PageData page)
        {
            var childPages = new List<PageData>();

            if (page != null)
            {
                childPages = _contentRepository.GetChildren<PageData>(page.ContentLink).ToList();
            }

            return childPages;

        }
    }
}