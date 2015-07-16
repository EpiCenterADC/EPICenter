using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "78f47fab-bbdc-44b1-b30d-34019016fa33", Description = "")]
    public class StandardPage : BasePage
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Body",
            Description = "Body",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual XhtmlString Body { get; set; }

    }
}