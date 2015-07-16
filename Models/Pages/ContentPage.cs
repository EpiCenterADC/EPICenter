using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "ContentPage", GUID = "96edddc0-60c4-44e0-a4a0-5dc88d97ee47", Description = "")]
    public class ContentPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Content Area",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual ContentArea ContentArea { get; set; }
    }
}