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
    public class YammerBlockController : BlockController<YammerBlock>
    {
        //
        // GET: /YammerBlock/

        public override ActionResult Index(YammerBlock currentBlock)
        {
            var model = new YammerBlockViewModel() 
            {
                YammerBlock = currentBlock
            };
            return PartialView(model);
        }

    }
}
