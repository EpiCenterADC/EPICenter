using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "BasePage", GUID = "5375fcc6-e749-404d-98e3-d3e39725bc74", Description = "")]
    public class BasePage : PageData
    {
        [Required]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Title { get; set; }
    }
}