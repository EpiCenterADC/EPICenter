using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Entities;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class RSSFeedPageViewModel : BasePageViewModel
    {
        public RSSFeedPage RSSFeedPage { get; set; }
        public IEnumerable<RSSEntity> RssFeed { get; set; }
    }
}