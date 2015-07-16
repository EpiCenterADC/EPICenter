using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;

namespace EPiCenterBaseProject.Controllers
{
    public class RSSFeedPageController : BasePageController<RSSFeedPage>, IController
    {
        private readonly IRSSService _rssFeedService = ServiceLocator.Current.GetInstance<IRSSService>();

        public ActionResult Index(RSSFeedPage currentPage)
        {
            var model = CreateModel(new RSSFeedPageViewModel
            {
                RSSFeedPage = currentPage,
                RssFeed = _rssFeedService.GetRSSData(currentPage.RSSLink)
            });
            return View(model);
        }


    }
}
