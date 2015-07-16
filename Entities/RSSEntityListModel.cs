using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiCenterBaseProject.Entities
{
    public class RSSEntityListModel
    {
        public IEnumerable<RSSEntity> RSSFeedList { get; set; }
    }
}