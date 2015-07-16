using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsPage> GetNewsList();
        IEnumerable<NewsPage> GetAnnouncementList();
    }
}
