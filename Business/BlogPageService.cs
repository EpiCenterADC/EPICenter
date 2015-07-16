using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;
using EPiServer;
using EPiServer.DataAbstraction;
using EPiCenterBaseProject.Models.Pages;
using EPiServer.Web;
using EPiServer.DataAccess;
using EPiServer.Security;

namespace EPiCenterBaseProject.Business
{
    public class BlogPageService : IBlogPageService
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        private readonly IContentTypeRepository _contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public string CreateBlogPage(string headline, XhtmlString body)
        {
            var parentPageContainer = _pageService.GetBlogPageRef();
            var contentTypeId = _contentTypeRepository.Load(typeof(ViewBlogPage)).ID;
            var parentPage = _contentRepository.GetDefault<ViewBlogPage>(parentPageContainer, contentTypeId);

            if (!PageReference.IsNullOrEmpty(parentPageContainer))
            {
                parentPage.Name = headline;
                parentPage.Title = headline;
                parentPage.BlogBody = body;
                parentPage.Author = System.Web.HttpContext.Current.User.Identity.Name;
                // Set the URL segment (page name in address)
                parentPage.URLSegment = UrlSegment.CreateUrlSegment(parentPage);

                // Publish the page regardless of current user's permissions
                var newPageRef = _contentRepository.Save(parentPage, SaveAction.Publish, AccessLevel.NoAccess);
            }
            return parentPage.LinkURL.ToString();
        }

        public string UpdateBlogPage(string headline, XhtmlString body, int pageId)
        {
            var parentRef = _pageService.GetBlogPageRef();
            var blogPage = _contentRepository.Get<ViewBlogPage>(new PageReference(pageId));

            var writableClone = blogPage.CreateWritableClone() as ViewBlogPage;

            writableClone.Title = headline;
            writableClone.BlogBody = body;
            writableClone.Author = System.Web.HttpContext.Current.User.Identity.Name;
            var pageref = _contentRepository.Save(writableClone, SaveAction.Publish, AccessLevel.NoAccess);
            return writableClone.LinkURL.ToString();
        }

        public IEnumerable<ViewBlogPage> GetAllBlogs()
        {
            var blogContainer = _pageService.GetBlogPageRef();
            var blogListing = _contentRepository.GetChildren<ViewBlogPage>(blogContainer);

            return blogListing;

        }
    }
}