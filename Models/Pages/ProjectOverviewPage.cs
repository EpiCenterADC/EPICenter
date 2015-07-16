using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "ProjectOverviewPage", GUID = "4ce80260-5ddb-4efd-a7f8-bfde8087ca2e", Description = "")]
    public class ProjectOverviewPage : BasePage
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