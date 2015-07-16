using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;

namespace EPiCenterBaseProject.Models.Pages
{
    /// <summary>
    /// Used for the site's start page and also acts as a container for site settings
    /// </summary>
    [ContentType(
        GUID = "19671657-B684-4D95-A61F-8DD4FE60D559",
        GroupName = Global.GroupNames.Specialized)]

    public class StartPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Content Area",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual ContentArea BannerContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "News List ContentArea",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual ContentArea NewsListContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "News List Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual PageReference NewsListContainer { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Overview ContentArea",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual ContentArea OverviewContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Login Page",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual PageReference LoginPageReference { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Announcement",
            Description = "Show Hide Announcement",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual bool Announcements { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Right Column ContentArea",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual ContentArea RightColumnContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Yammer Content Area",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual ContentArea YammerContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Menu Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual PageReference MenuContainer { get; set; }


        [CultureSpecific]
        [Display(
            Name = "TaskType Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        public virtual PageReference TaskTypeContainer { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Others Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        public virtual PageReference OthersContainer { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Profile Page Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        public virtual PageReference ProfilePageContainer { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Default Profile Pic",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference DefaultProfilePic { get; set; }


        [Display(
           Name = "Logo Image Folder",
           Description = "Logo Image Folder",
           GroupName = SystemTabNames.Content,
           Order = 13)]
        [UIHint(UIHint.MediaFolder)]
        public virtual ContentReference LogoImageFolder { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Blog Page Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual PageReference BlogPageContainer { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Create Blog PageReference",
            Description = "Create Blog PageReference",
            GroupName = SystemTabNames.Content,
            Order = 22)]
        public virtual PageReference CreateBlogPageReference { get; set; }

        [CultureSpecific]
        [Display(
            Name = "View BlogList PageReference",
            Description = "View BlogList PageReference",
            GroupName = SystemTabNames.Content,
            Order = 24)]
        public virtual PageReference ViewBlogListPageReference { get; set; }


    }
}