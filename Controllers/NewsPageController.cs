using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class NewsPageController : BasePageController<NewsPage>, IController
    {
        //
        // GET: /NewsPage/

        public ActionResult Index(NewsPage currentPage)
        {
            var model = CreateModel(new NewsPageViewModel
            {
                NewsPage = currentPage
            });
            return View(model);
        }

    }
}
