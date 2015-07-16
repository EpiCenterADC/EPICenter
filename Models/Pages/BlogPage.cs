using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "BlogPage", GUID = "dcd3292c-c303-4c00-9638-6dce79a897b7", Description = "")]
    public class BlogPage : BasePage
    {
        [Required]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string BlogTitle { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Blog Body",
            Description = "Blog Body",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString BlogBody { get; set; }

        [Required]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string Author { get; set; }

    }
}