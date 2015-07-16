using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Entities;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class RSSFeedBlockViewModel 
    {
        public RSSFeedBlock RSSFeedBlock { get; set; }
        public IEnumerable<RSSEntity> RssFeed { get; set; }
    }

}