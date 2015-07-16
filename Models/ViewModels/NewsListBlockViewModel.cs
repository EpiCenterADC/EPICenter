using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class NewsListBlockViewModel
    {
        public NewsListBlock NewsListBlock { get; set; }
        public IEnumerable<NewsPage> newsPages { get; set; }
    }
}