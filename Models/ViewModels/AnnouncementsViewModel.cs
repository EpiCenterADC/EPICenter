using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class AnnouncementsViewModel
    {
        public bool ShowHide { get; set; }
        public IEnumerable<NewsPage> AnnouncementItems { get; set; }
    }
}