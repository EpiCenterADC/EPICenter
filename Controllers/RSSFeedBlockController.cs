using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Models.ViewModels;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;

namespace EPiCenterBaseProject.Controllers
{
    public class RSSFeedBlockController : BlockController<RSSFeedBlock>
    {
        private readonly IRSSService _rssFeedService = ServiceLocator.Current.GetInstance<IRSSService>();

        public override ActionResult Index(RSSFeedBlock currentBlock)
        {
            var model = new RSSFeedBlockViewModel() { };
            model.RSSFeedBlock = currentBlock;
            model.RssFeed = _rssFeedService.GetRSSData(currentBlock.RSSLink).Take(currentBlock.NoOfFeeds);
            return PartialView(model);
        }

    }
}
