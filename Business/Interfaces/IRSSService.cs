using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiCenterBaseProject.Entities;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface IRSSService
    {
        IEnumerable<RSSEntity> GetRSSData(string RSSUrl);
    }
}
