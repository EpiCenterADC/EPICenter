using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class StandardPageController : BasePageController<StandardPage>, IController
    {

        public ActionResult Index(StandardPage currentPage)
        {
            var model = CreateModel(new StandardPageViewModel
            {
                StandardPage = currentPage
            });
            return View(model);
        }


    }
}
