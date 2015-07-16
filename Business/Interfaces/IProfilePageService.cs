using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiCenterBaseProject.Models.Pages;
using EPiServer.Core;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface IProfilePageService
    {
        IEnumerable<ProfilePage> GetAllProfiles(ProfileListingPage profileListPage);
        ContentReference GetProfilePhoto(ProfilePage profilePage);
        List<string> GetProjectsWorkedOn(ProfilePage profilePage);
    }
}
