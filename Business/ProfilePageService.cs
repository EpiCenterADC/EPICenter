using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Business.Interfaces;
using EPiCenterBaseProject.Models.Pages;
using EPiServer.ServiceLocation;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace EPiCenterBaseProject.Business
{
    public class ProfilePageService : IProfilePageService
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public IEnumerable<ProfilePage> GetAllProfiles(ProfileListingPage profileListPage)
        {
            var profilePageContainer = _pageService.GetProfilePageContainerPageRef();

            var profilePageList = new List<ProfilePage>();

            if (profilePageContainer != null)
            {
                if (profileListPage != null)
                {
                    var profiles = _contentRepository.GetChildren<ProfilePage>(profilePageContainer).ToList();

                    foreach (var profile in profiles)
                    {
                        foreach (var category in profileListPage.Category)
                        {
                            if (profile.Category.Contains(category))
                                profilePageList.Add(profile);
                        }
                    }

                }
                else
                {
                    profilePageList = _contentRepository.GetChildren<ProfilePage>(profilePageContainer).ToList();
                }

                if(profilePageList.Count==0)
                    profilePageList = _contentRepository.GetChildren<ProfilePage>(profilePageContainer).ToList();
            }
            return profilePageList;
        }

        public ContentReference GetProfilePhoto(ProfilePage profilePage)
        {
            var photoImage = new ContentReference();
            if (!ContentReference.IsNullOrEmpty(profilePage.UserPhoto))
                photoImage = profilePage.UserPhoto;
            else
                photoImage = _pageService.GetStartPage().DefaultProfilePic;

            return photoImage;
        }

        public List<string> GetProjectsWorkedOn(ProfilePage profilePage)
        {
            List<string> projectsList = new List<string>();
            if (profilePage != null)
            {
                var profileCategories = profilePage.ProjectsCategories;

                if (profileCategories == null)
                    return projectsList;

                foreach (int profileCategory in profileCategories)
                {
                    var category = Category.Find(profileCategory).ID.ToString();
                    projectsList.Add(category);
                }
            }

            return projectsList;
        }
    }
}