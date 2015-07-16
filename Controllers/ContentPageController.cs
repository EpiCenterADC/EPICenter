using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class ContentPageController : BasePageController<ContentPage>
    {
        //
        // GET: /ContentPage/

        public ActionResult Index(ContentPage currentPage)
        {
            var model = CreateModel(new ContentPageViewModel
            {
                ContentPage = currentPage
            });
            return View(model);
        }

    }
}
