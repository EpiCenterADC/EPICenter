using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class ViewBlogListViewModel : BasePageViewModel
    {
        public ViewBlogList ViewBlogList { get; set; }
        public IEnumerable<ViewBlogPage> BlogListing { get; set; }
        public string CreateBlogLink { get; set; }
    }
}