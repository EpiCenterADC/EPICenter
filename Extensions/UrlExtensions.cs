using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using EPiServer.ServiceLocation;
using System.Web.Routing;
using EPiServer.Web.Routing;
using EPiServer.Globalization;

namespace EPiCenterBaseProject.Extensions
{
    public static class UrlExtensions
    {
        public static string GetFriendlyUrl(this HtmlHelper helper, LinkItem linkItem)
        {
            EPiServer.UrlBuilder url = new EPiServer.UrlBuilder(linkItem.GetMappedHref());
            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(url, linkItem.GetMappedHref(), System.Text.UTF8Encoding.UTF8);
            return url.ToString();
        }
        public static string PageUrl(this UrlHelper urlHelper, PageReference pageLink)
        {
            return UrlExtensions.PageUrl(urlHelper, pageLink, (object)null, (IContentRepository)null);
        }

        public static string PageUrl(this UrlHelper urlHelper, PageReference pageLink, object routeValues)
        {
            return UrlExtensions.PageUrl(urlHelper, pageLink, routeValues, (IContentRepository)null);
        }

        public static string PageUrl(this UrlHelper urlHelper, PageData page)
        {
            return UrlExtensions.PageUrl(urlHelper, page, (object)null);
        }

        public static string PageUrl(this UrlHelper urlHelper, PageData page, object routeValues)
        {
            if (!PageDataExtensions.HasTemplate(page))
                return string.Empty;

            switch (page.LinkType)
            {
                case PageShortcutType.Normal:
                case PageShortcutType.Shortcut:
                case PageShortcutType.FetchData:
                    return UrlExtensions.PageUrl(urlHelper, page.PageLink, routeValues, (IContentLoader)null, (IPermanentLinkMapper)null, (LanguageSelectorFactory)null);

                case PageShortcutType.External:
                    return page.LinkURL;

                case PageShortcutType.Inactive:
                    return string.Empty;

                default:
                    return string.Empty;
            }
        }

        private static string PageUrl(this UrlHelper urlHelper, PageReference pageLink, object routeValues, IContentRepository contentRepository)
        {
            if (contentRepository == null)
                contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            if (PageReference.IsNullOrEmpty(pageLink))
                return string.Empty;
            PageData page = contentRepository.Get<PageData>((ContentReference)pageLink);
            return UrlExtensions.PageUrl(urlHelper, page, routeValues);
        }

        private static string PageUrl(this UrlHelper urlHelper, PageReference pageLink, object routeValues, IContentLoader contentQueryable, IPermanentLinkMapper permanentLinkMapper, LanguageSelectorFactory languageSelectorFactory)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary(routeValues);
            if (!routeValueDictionary.ContainsKey(RoutingConstants.LanguageKey))
                routeValueDictionary[RoutingConstants.LanguageKey] = (object)ContentLanguage.PreferredCulture.Name;
            if (!routeValueDictionary.ContainsKey(RoutingConstants.ActionKey))
                routeValueDictionary[RoutingConstants.ActionKey] = (object)"index";
            routeValueDictionary[RoutingConstants.NodeKey] = (object)pageLink;
            UrlExtensions.SetAdditionalContextValuesForContent(urlHelper, pageLink, routeValueDictionary, contentQueryable, permanentLinkMapper, languageSelectorFactory);
            return urlHelper.Action(null, routeValueDictionary);
        }

        private static void SetAdditionalContextValuesForContent(this UrlHelper urlHelper, PageReference pageLink, RouteValueDictionary values, IContentLoader contentQueryable, IPermanentLinkMapper permanentLinkMapper, LanguageSelectorFactory languageSelectorFactory)
        {
            bool IdKeep = HttpContext.Current.Request.QueryString["idkeep"] != null;
            contentQueryable = contentQueryable ?? ServiceLocator.Current.GetInstance<IContentLoader>();
            permanentLinkMapper = permanentLinkMapper ?? ServiceLocator.Current.GetInstance<IPermanentLinkMapper>();
            languageSelectorFactory = languageSelectorFactory ?? ServiceLocator.Current.GetInstance<LanguageSelectorFactory>();
            IContent content = contentQueryable.Get<IContent>(pageLink, languageSelectorFactory.Fallback(values[RoutingConstants.LanguageKey] as string ?? ContentLanguage.PreferredCulture.Name, true));
            if (content == null)
                return;
            if (IdKeep)
                values["id"] = (object)content.ContentLink.ToString();
            UrlExtensions.SetAdditionalContextValuesForPage(values, IdKeep, content);
        }

        private static void SetAdditionalContextValuesForPage(RouteValueDictionary values, bool IdKeep, IContent content)
        {
            PageData pageData = content as PageData;
            if (pageData == null)
                return;
            if (pageData.LinkType == PageShortcutType.Shortcut)
            {
                PropertyPageReference propertyPageReference = pageData.Property["PageShortcutLink"] as PropertyPageReference;
                if (propertyPageReference != null && !PageReference.IsNullOrEmpty(propertyPageReference.PageLink))
                {
                    values[RoutingConstants.NodeKey] = (object)propertyPageReference.PageLink;
                    if (IdKeep)
                        values["id"] = (object)((object)propertyPageReference).ToString();
                }
            }
        }

    }
}