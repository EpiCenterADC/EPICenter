using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using EPiServer.ServiceLocation;
using EPiCenterBaseProject.Business.Interfaces;

namespace EPiCenterBaseProject.Controllers
{
    public class ViewBlogListController : BasePageController<ViewBlogList>, IController
    {
        //
        // GET: /ViewBlogList/
        private readonly IBlogPageService _blogPageService = ServiceLocator.Current.GetInstance<IBlogPageService>();
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();

        public ActionResult Index(ViewBlogList currentPage)
        {
            var model = CreateModel(new ViewBlogListViewModel
            {
                ViewBlogList = currentPage,
                BlogListing = _blogPageService.GetAllBlogs(),
                CreateBlogLink = _pageService.GetCreateBlogPageRef()
            });
            return View(model);
        }

    }
}
