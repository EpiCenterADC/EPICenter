using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;
using EPiServer.Core;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class BlogPageViewModel : BasePageViewModel
    {
        public XhtmlString Body { get; set; }
        public string BlogTitle { get; set; }
        public BlogPage BlogPage { get; set; }
        public string ViewAllBlogPage { get; set; }
    }
}