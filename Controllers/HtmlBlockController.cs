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
    public class HtmlBlockController : BlockController<HtmlBlock>
    {
        //
        // GET: /HtmlBlock/

        public override ActionResult Index(HtmlBlock currentBlock)
        {
            var model = new HtmlBlockViewModel() { };
            model.HtmlBlock = currentBlock;
            return PartialView(model);
        }

    }
}
