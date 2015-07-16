using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiServer.Core;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface IBlogPageService
    {
        string CreateBlogPage(string headline, XhtmlString body);
        string UpdateBlogPage(string headline, XhtmlString body, int pageId);
        IEnumerable<ViewBlogPage> GetAllBlogs();
    }
}
