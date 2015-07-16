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
    public class NewsListBlockController : BlockController<NewsListBlock>
    {
        private readonly INewsService _newsService = ServiceLocator.Current.GetInstance<INewsService>();
        //
        // GET: /NewsListBlock/

        public override ActionResult Index(NewsListBlock currentBlock)
        {
            var model = new NewsListBlockViewModel() { };
            model.NewsListBlock = currentBlock;
            model.newsPages = _newsService.GetNewsList();
            return PartialView(model);
        }

    }
}
