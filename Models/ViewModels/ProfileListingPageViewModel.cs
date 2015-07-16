using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Core;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.Web.Routing;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class ProfileListingPageViewModel : BasePageViewModel
    {
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();

        public ProfileListingPage ProfileListingPage { get; set; }
        public IEnumerable<ProfilePage> ProfileList { get; set; }
        public string GetProfilePic(int pageId)
        {
            string imageLink = string.Empty;
           
            var profilePage = _contentRepository.Get<ProfilePage>(new PageReference(pageId));

            if (pageId > 0)
            {
                if (!ContentReference.IsNullOrEmpty(profilePage.UserPhoto))
                {
                    imageLink = UrlResolver.Current.GetUrl(profilePage.UserPhoto);
                }
                else
                {
                    imageLink = UrlResolver.Current.GetUrl(_pageService.GetStartPage().DefaultProfilePic);
                }
            }
            return imageLink;
        }

    }
}