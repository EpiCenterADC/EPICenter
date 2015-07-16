using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;
using System.Web.Security;
using EPiServer;
using EPiServer.Core;
using EPiCenterBaseProject.Models.Media;
using EPiServer.Web.Routing;

namespace EPiCenterBaseProject.Controllers
{
    public class BasePageController<T> : PageController<T> where T : BasePage
    {
         private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();
         private readonly INewsService _newsService = ServiceLocator.Current.GetInstance<INewsService>();
         private readonly IMenuLinkService _menuLinkService = ServiceLocator.Current.GetInstance<IMenuLinkService>();
         private readonly IContentRepository _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

        public T CurrentPage
        {
            get
            {
                try
                {
                    return (T)PageContext.Page;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public virtual TModel CreateModel<TModel>(TModel model) where TModel : BasePageViewModel
        {
            return CreateModel(CurrentPage, model);
        }

        public virtual TModel CreateModel<TModel>(T currentPage, TModel model) where TModel : BasePageViewModel
        {
            if (String.IsNullOrEmpty(model.Title))
            {
                if (currentPage != null)
                {
                    model.Title = !string.IsNullOrEmpty(currentPage["Title"] as string)
                        ? currentPage["Title"] as string
                        : currentPage.Name;
                }
            }
            model.HeaderViewModel = CreateHeaderModel();
            model.AnnouncementsViewModel = CreateAnnouncementModel();           
            return model;
        }

        private HeaderViewModel CreateHeaderModel()
        {
            var model = new HeaderViewModel()
            {
                StartPage = _pageService.GetStartPage(),
                IsUserLoggedIn = _pageService.IsUserLoggedIn(),
                MenuLinks = _menuLinkService.GetMainMenuLinks()
            };
            return model;
        }

        private AnnouncementsViewModel CreateAnnouncementModel()
        {
            var model = new AnnouncementsViewModel()
            {
                ShowHide = _pageService.GetStartPage().Announcements,
                AnnouncementItems = _newsService.GetAnnouncementList()
            };
            return model;
        }

        public ActionResult SignOutUser()
        {
            FormsAuthentication.SignOut();
            return Redirect(_pageService.GetStartPage().LinkURL);
        }

        public ActionResult SignInUser()
        {
            var loginPage = _contentRepository.Get<LoginPage>(_pageService.GetLoginPageRef());
            return Redirect(loginPage.LinkURL);
        }

       

       

    }
}
