using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface IPageService
    {
        StartPage GetStartPage();
        string GetFriendlyUrl(PageData page);
        string GetFriendlyUrl(ContentReference reference, string language = null);
        PageReference GetNewsListPageRef();
        string GetFriendlyUrlByPageId(int pageId);
        bool IsUserLoggedIn();
        PageReference GetLoginPageRef();
        PageReference GetProfilePageContainerPageRef();
        PageReference GetBlogPageRef();
        string GetCreateBlogPageRef();
        string GetViewBlogListPageRef();
        string GetLoginPageLink();
    }
}
