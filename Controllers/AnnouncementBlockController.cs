using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class AnnouncementBlockController : BlockController<AnnouncementBlock>
    {
        public override ActionResult Index(AnnouncementBlock currentBlock)
        {
            var model = new AnnouncementBlockViewModel() { };
            model.AnnouncementBlock = currentBlock;
            return PartialView(model);
        }

    }
}
