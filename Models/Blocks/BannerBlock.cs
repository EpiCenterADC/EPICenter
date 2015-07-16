using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "BannerBlock", GUID = "e5bd3032-58e3-41cb-91d7-498ae3b94d7c", Description = "")]
    public class BannerBlock : BlockData
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Name",
            Description = "Banner Name",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String BannerName { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Info 1",
            Description = "Banner Info",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual String BannerInfo { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Image 1",
            Description = "Banner Image",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BannerImage { get; set; }


        [CultureSpecific]
        [Required]
        [Editable(true)]
        [Display(
            Name = "Banner Link 1",
            Description = "BannerLink",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual PageReference BannerLink { get; set; }


        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Info 2",
            Description = "Banner Info",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual String BannerInfo2 { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Image 2",
            Description = "Banner Image",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BannerImage2 { get; set; }


        [CultureSpecific]
        [Required]
        [Editable(true)]
        [Display(
            Name = "Banner Link 2",
            Description = "BannerLink",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        public virtual PageReference BannerLink2 { get; set; }


        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Info 3",
            Description = "Banner Info",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual String BannerInfo3 { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Image 3",
            Description = "Banner Image",
            GroupName = SystemTabNames.Content,
            Order = 9)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BannerImage3 { get; set; }


        [CultureSpecific]
        [Required]
        [Editable(true)]
        [Display(
            Name = "Banner Link 3",
            Description = "BannerLink",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual PageReference BannerLink3 { get; set; }

    }
}