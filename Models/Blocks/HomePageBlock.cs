using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "HomePageBlock", GUID = "7f673565-2544-4e18-87c3-fb761d9eedcf", Description = "")]
    public class HomePageBlock : BlockData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Overview Title",
            Description = "Overview Title",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual String OverviewTitle { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Overview Description",
            Description = "Overview Description",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual String OverviewDescription { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Overview PageLink",
            Description = "Overview PageLink",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual PageReference OverviewPageLink { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Methodology Title",
            Description = "Methodology Title",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual String MethodologyTitle { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Methodology Description",
            Description = "Methodology Description",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        public virtual String MethodologyDescription { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Methodology PageLink",
            Description = "OverMethodologyview PageLink",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual PageReference MethodologyPageLink { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Vision Title",
            Description = "Vision Title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual String VisionTitle { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Vision Description",
            Description = "Vision Description",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        public virtual String VisionDescription { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Vision PageLink",
            Description = "Vision PageLink",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        public virtual PageReference VisionPageLink { get; set; }
    }
}