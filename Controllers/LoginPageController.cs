using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using System.Web.Security;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;

namespace EPiCenterBaseProject.Controllers
{
    public class LoginPageController : BasePageController<LoginPage>
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();

        public ActionResult Index(LoginPage currentPage)
        {
            var model = CreateModel(new LoginPageViewModel
            {
            });
            return View(model);
        }

       

        [HttpPost]//Run action method on form submission
        public ActionResult Index(string username, string password, string pageURL, string buttonAction)
        {
            if (buttonAction == "login")
            {
                var validated = Membership.ValidateUser(username, password);
                if (validated)
                {
                    FormsAuthentication.SetAuthCookie(username, true);
                    return Redirect(_pageService.GetStartPage().LinkURL);
                }
            }
            else
            {

            }

            return Redirect(pageURL);
        }

        

    }
}
