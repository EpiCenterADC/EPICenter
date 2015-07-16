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
    public class ViewBlogPageController : BasePageController<ViewBlogPage>
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        //
        // GET: /ViewBlogPage/

        public ActionResult Index(ViewBlogPage currentPage)
        {
            var model = CreateModel(new ViewBlogPageViewModel
            {
                ViewBlogPage = currentPage,
                EditBlogLink = _pageService.GetCreateBlogPageRef() + "?p=" + currentPage.ContentLink.ID
            });
            return View(model);
        }

    }
}
