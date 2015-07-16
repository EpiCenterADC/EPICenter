using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiCenterBaseProject.Controllers;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class BasePageViewModel
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public string Title { get; set; }
        public PageData StartPage { get; set;  }
        public HeaderViewModel HeaderViewModel { get; set; }
        public AnnouncementsViewModel AnnouncementsViewModel { get; set; }

        public PageData CurrentPage
        {
            get
            {
                PageRouteHelper pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<PageRouteHelper>();
                PageData currentPage = pageRouteHelper.Page;
                return currentPage;


            }
        }

        public IEnumerable<PageData> GetChildPages(PageData page)
        {
            var childPages = new List<PageData>();

            if (page != null)
            {
                childPages = _contentRepository.GetChildren<PageData>(page.ContentLink).ToList();
                if (childPages.Count == 0)
                {
                    childPages = _contentRepository.GetChildren<PageData>(page.ParentLink).ToList();
                }
            }

            return childPages;

        }

        public string GetProjectImage(PageData page)
        {
            return GetRandomPictureFromFolder(page);

        }

        private string GetRandomPictureFromFolder(PageData page)
        {
            string strLogo = string.Empty;

            var folderContentReference = _pageService.GetStartPage().LogoImageFolder;

            if (folderContentReference == null) return null;

            var files = _contentRepository.GetChildren<ImageData>(folderContentReference);
            var filesList = files as IList<ImageData> ?? files.ToList();
            if (files == null || !filesList.Any()) return null;

            try
            {
                var imagefile = filesList.Where(x => page.Category.Contains(x.Category.FirstOrDefault()));
                if (imagefile != null)
                    strLogo = UrlResolver.Current.GetUrl(imagefile.FirstOrDefault().ContentLink);
            }
            catch (Exception exception)
            {
                return strLogo;
            }

            return strLogo;
        }

        public string GetProjectImageFromCategory(string categoryID)
        {
            string strLogo = string.Empty;

            var folderContentReference = _pageService.GetStartPage().LogoImageFolder;

            if (folderContentReference == null) return null;

            var files = _contentRepository.GetChildren<ImageData>(folderContentReference);
            var filesList = files as IList<ImageData> ?? files.ToList();
            if (files == null || !filesList.Any()) return null;

            try
            {
                var imagefile = filesList.Where(x => Convert.ToInt32(x.Category.FirstOrDefault()) == Convert.ToInt32(categoryID));
                if (imagefile != null)
                    strLogo = UrlResolver.Current.GetUrl(imagefile.FirstOrDefault().ContentLink);
            }
            catch (Exception exception)
            {
                return strLogo;
            }

            return strLogo;
        }

        public bool IsCurrentPageActive(PageData page)
        {
            bool IsInActive = false;

            if (CurrentPage != null)
            {
                IsInActive = CurrentPage.ContentLink.ID == page.ContentLink.ID ? true : false;
            }

            return IsInActive;
        }

        public string GetLoggedInUserName()
        {
            if (_pageService.IsUserLoggedIn())
            {                 
                return System.Web.HttpContext.Current.User.Identity.Name;
            }
            else
            {
                return "Guest";
            }
        }

        public bool IsUserLoggedIn 
        { 
            get 
            {
                return _pageService.IsUserLoggedIn();
            } 
        }

    }
}