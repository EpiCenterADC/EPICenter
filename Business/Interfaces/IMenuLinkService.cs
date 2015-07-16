using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiServer.Core;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface IMenuLinkService
    {
        IEnumerable<PageData> GetMainMenuLinks();
    }
}
