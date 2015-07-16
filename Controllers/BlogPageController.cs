using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;
using EPiServer.Core;
using EPiServer;

namespace EPiCenterBaseProject.Controllers
{
    public class BlogPageController : BasePageController<BlogPage>
    {
        //
        // GET: /BlogPage/

        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        private readonly IBlogPageService _blogPageService = ServiceLocator.Current.GetInstance<IBlogPageService>();
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public ActionResult Index(BlogPage currentPage)
        {
            if (!_pageService.IsUserLoggedIn())
                _pageService.GetLoginPageLink();

            var model = CreateModel(new BlogPageViewModel
            {
                BlogPage = currentPage,
                ViewAllBlogPage = _pageService.GetViewBlogListPageRef()
            });

            if (Request.QueryString["p"] != null)
            {
                var viewBlogPage = _contentRepository.Get<ViewBlogPage>(new PageReference(Convert.ToInt32(Request.QueryString["p"])));

                //EditViewBlogPageIndex(Convert.ToInt32(Request.QueryString["p"]));
                model.BlogTitle = viewBlogPage.Title;
                model.Body = viewBlogPage.BlogBody;
            }

            return View(model);
        }

        [HttpPost, ValidateInput(false)]//Run action method on form submission
        public ActionResult ManageBlogIndex(string BlogTitle, string BlogBody, string pageURL, string buttonAction, string pageId)
        {
            var blogPageContainer = _pageService.GetBlogPageRef();

            if (!PageReference.IsNullOrEmpty(blogPageContainer))
            {
                if (!string.IsNullOrEmpty(pageId))
                {
                    XhtmlString body = new XhtmlString(BlogBody);
                    pageURL = _blogPageService.UpdateBlogPage(BlogTitle, body, Convert.ToInt32(pageId));
                }
                else
                {
                    XhtmlString body = new XhtmlString(BlogBody);
                    pageURL = _blogPageService.CreateBlogPage(BlogTitle, body);
                }
            }

            return Redirect(pageURL);
        }

        public ActionResult EditViewBlogPageIndex(int p)
        {
            var viewBlogPage = _contentRepository.Get<ViewBlogPage>(new PageReference(p));
            var model = CreateModel(new BlogPageViewModel()
            {
                BlogTitle = viewBlogPage.Title,
                Body = viewBlogPage.BlogBody,
                ViewAllBlogPage = _pageService.GetViewBlogListPageRef()
            });


            return View("Index", model);
        }

        public ActionResult SpecificScripts()
        {
            return PartialView("_TinyMCEScripts");
        }

    }
}
