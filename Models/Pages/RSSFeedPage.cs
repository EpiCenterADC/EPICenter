using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "RSSFeedPage", GUID = "0c2bed57-7afe-4305-b170-b44af12bd819", Description = "")]
    public class RSSFeedPage : BasePage
    {
        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "RSS Link",
            Description = "RSS Link",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual String RSSLink { get; set; }
    }
}