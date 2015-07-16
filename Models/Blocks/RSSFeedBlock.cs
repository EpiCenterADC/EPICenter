using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "RSSFeedBlock", GUID = "217c1b52-017b-41f5-a9f2-b2cc144e5725", Description = "")]
    public class RSSFeedBlock : BlockData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Title { get; set; }


        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "RSS Link",
            Description = "RSS Link",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual String RSSLink { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "No Of Feeds",
            Description = "No Of Feeds",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual Int32 NoOfFeeds { get; set; }


        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "View All RSSFeeds",
            Description = "View All RSSFeeds",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual PageReference ViewAllRSSFeeds { get; set; }

    }
}