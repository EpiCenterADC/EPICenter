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
    public class BannerBlockController : BlockController<BannerBlock>
    {

        public override ActionResult Index(BannerBlock currentBlock)
        {
            var model = new BannerBlockViewModel() { };
            model.BannerBlock = currentBlock;
            return PartialView(model);
        }

    }
}
