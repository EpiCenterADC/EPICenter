using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Models.ViewModels;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiCenterBaseProject.Business.Interfaces;
using EPiCenterBaseProject.Business;
using EPiCenterBaseProject.Business.QuickPoll;

namespace EPiCenterBaseProject.Controllers
{
    public class QuickPollBlockController : BlockController<QuickPollBlock>
    {
        //
        // GET: /QuickPollBlock/
        private readonly IQuickPollService _quickPollService = ServiceLocator.Current.GetInstance<IQuickPollService>();
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();

        public override ActionResult Index(QuickPollBlock currentBlock)
        {
            var model = new QuickPollBlockViewModel() { };
            model.Question = currentBlock.Question;
            model.QuickPollHeading = currentBlock.QuickPollHeading;
            model.Alternative1 = currentBlock.Alternative1;
            model.Alternative2 = currentBlock.Alternative2;
            model.Alternative3 = currentBlock.Alternative3;
            model.Alternative4 = currentBlock.Alternative4;
            model.Alternative5 = currentBlock.Alternative5;
            model.Alternative6 = currentBlock.Alternative6;
            model.Alternative7 = currentBlock.Alternative7;
            model.Alternative8 = currentBlock.Alternative8;
            model.Alternative9 = currentBlock.Alternative9;
            model.Alternative10 = currentBlock.Alternative10;
            model.ResultHeading = currentBlock.ResultHeading;
            model.PollID = Convert.ToString( (currentBlock as IContent).ContentLink.ID);
            model.IsUserVoted = _quickPollService.IsUserVoted((currentBlock as IContent).ContentLink.ID);
            model.ResetPoll = currentBlock.ResetPoll;
            return PartialView(model);
        }


        [HttpPost]//Run action method on form submission
        public ActionResult SaveQuickPollDataIndex(FormCollection form, QuickPollBlockViewModel quickPollBlockViewModel)
        {
            if (!_pageService.IsUserLoggedIn())
                _pageService.GetLoginPageLink();

            var selectedOption = form["Response"];
            var PageURL = form["PageURL"];
            var pollID = quickPollBlockViewModel.PollID;

            if (selectedOption != null)
            {
                _quickPollService.SavePollVotes(Convert.ToInt32(pollID), selectedOption);
            }

            var model = new QuickPollViewModel()
            {
                pollAnswer = _quickPollService.PollStatistic(Convert.ToInt32(pollID)),
                totalVotes = _quickPollService.GetTotalVotes(Convert.ToInt32(pollID)).ToString()
            };

            //var html = RenderPartialViewToString("~/Views/QuickPollBlock/_QuickPollChart.cshtml", model);
            //return Content(html);

            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public string RenderPartialViewToString(string viewName, object model)
        {
            var helper = new RenderHelper(this);
            return helper.RenderPartialViewToString(viewName, model);
        }


    }
}
