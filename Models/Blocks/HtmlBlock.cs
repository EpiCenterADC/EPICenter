using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "HtmlBlock", GUID = "f6411178-759a-4e63-9807-2f55a18b770d", Description = "")]
    public class HtmlBlock : BlockData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual String Title { get; set; }

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