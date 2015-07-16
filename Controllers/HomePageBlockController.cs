using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Blocks;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class HomePageBlockController : BlockController<HomePageBlock>
    {
        //
        // GET: /HomePageBlock/

        public override ActionResult Index(HomePageBlock currentBlock)
        {
            var model = new HomePageBlockViewModel() { };
            model.HomePageBlock = currentBlock;
            return PartialView(model);
        }

    }
}
