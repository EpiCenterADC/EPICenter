using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework.Initialization;
using EPiServer.Framework;
using EPiServer;
using EPiCenterBaseProject.Models.Blocks;
using EPiServer.ServiceLocation;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.Core;

namespace EPiCenterBaseProject.Business.QuickPoll
{
    [InitializableModule]
    public class QuickPollBlockInitializer : IInitializableModule
    {
        private bool _eventsAttached = false;

        public void Initialize(InitializationEngine context)
        {
            if (!_eventsAttached)
            {
                //TODO: Cant find out how to do this using the repo
                DataFactory.Instance.PublishingContent += this.OnPublishingContent;
                _eventsAttached = true;
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            // Detach event handlers
            DataFactory.Instance.PublishingPage -= this.OnPublishingContent;
        }

        public void Preload(string[] parameters) { }

        public void OnPublishingContent(object sender, ContentEventArgs e)
        {
            QuickPollBlock quickPollBlockData = e.Content as QuickPollBlock;
            var quickPoll = ServiceLocator.Current.GetInstance<IQuickPollService>();

            if (quickPollBlockData != null)
            {
                int blockID = (quickPollBlockData as IContent).ContentLink.ID;

                if (quickPollBlockData.ResetPoll)
                {
                    quickPoll.ResetPollVoting(blockID);
                }
                quickPoll.SaveQuickPoll(quickPollBlockData);
            }

        }
    }
}