using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class ViewBlogPageViewModel : BasePageViewModel
    {
        public ViewBlogPage ViewBlogPage { get; set; }
        public string EditBlogLink { get; set; }
    }
}