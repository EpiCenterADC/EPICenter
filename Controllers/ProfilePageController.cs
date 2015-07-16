using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;

namespace EPiCenterBaseProject.Controllers
{
    public class ProfilePageController : BasePageController<ProfilePage>, IController
    {
        //
        // GET: /ProfilePage/
        private readonly IProfilePageService _profilePageService = ServiceLocator.Current.GetInstance<IProfilePageService>();

        public ActionResult Index(ProfilePage currentPage)
        {
            var model = CreateModel(new ProfilePageViewModel
            {
                ProfilePage = currentPage,
                profilePhoto = _profilePageService.GetProfilePhoto(currentPage),
                ProjectsWorkedOn = _profilePageService.GetProjectsWorkedOn(currentPage)
            });
            return View(model);
        }

    }
}
