using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "ViewBlogPage", GUID = "e7586deb-3237-42be-86c8-4b11731bd1ee", Description = "")]
    public class ViewBlogPage : BasePage
    {
        [Required]
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