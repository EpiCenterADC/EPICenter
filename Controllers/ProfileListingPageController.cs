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
    public class ProfileListingPageController : BasePageController<ProfileListingPage>, IController
    {
        //
        // GET: /ProfileListingPage/
        private readonly IProfilePageService _profilePageService = ServiceLocator.Current.GetInstance<IProfilePageService>();

        public ActionResult Index(ProfileListingPage currentPage)
       {
            var model = CreateModel(new ProfileListingPageViewModel
            {
                ProfileListingPage = currentPage,
                ProfileList = _profilePageService.GetAllProfiles(currentPage)
            });
            return View(model);
        }

    }
}
