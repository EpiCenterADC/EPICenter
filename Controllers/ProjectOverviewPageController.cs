using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class ProjectOverviewPageController : BasePageController<ProjectOverviewPage>, IController
    {
        public ActionResult Index(ProjectOverviewPage currentPage)
        {
            var model = CreateModel(new ProjectOverviewPageViewModel
            {
                ProjectOverviewPage = currentPage
            });
            return View(model);
        }

    }
}
