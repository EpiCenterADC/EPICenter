using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;
using EPiCenterBaseProject.Models.Pages;
using EPiServer;

namespace EPiCenterBaseProject.Business
{
    public class NewsService : INewsService
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
        private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public IEnumerable<NewsPage> GetNewsList()
        {
            var newsListContainer = _pageService.GetNewsListPageRef();

            var newsList = new List<NewsPage>();

            if (newsListContainer != null)
            {
                newsList = _contentRepository.GetChildren<NewsPage>(newsListContainer).ToList();
            }

            return newsList.ToList();
        }

        public IEnumerable<NewsPage> GetAnnouncementList()
        {
            var newsList = GetNewsList().Where(x => x.ShowAsAnnouncement ==true);
            return newsList.ToList();
        }
    }
}