using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework;
using EPiServer.ServiceLocation;
using System.Web.Mvc;
using EPiServer.Framework.Initialization;
using EPiCenterBaseProject.Business.Interfaces;

namespace EPiCenterBaseProject.Business.AppStart
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    [InitializableModule]
    public class StructureMapConfiguration : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(
              component =>
              {
                  component.For<INewsService>().Use<NewsService>();
                  component.For<IPageService>().Use<PageService>();
                  component.For<IRSSService>().Use<RSSService>();
                  component.For<IMenuLinkService>().Use<MenuLinkService>();
                  component.For<IProfilePageService>().Use<ProfilePageService>();
                  component.For<IBlogPageService>().Use<BlogPageService>();
                  component.For<IQuickPollService>().Use<QuickPollService>();
              });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.Container));
        }

        public void Initialize(InitializationEngine context) { }
        public void Preload(string[] parameters) { }
        public void Uninitialize(InitializationEngine context) { }
    }
}