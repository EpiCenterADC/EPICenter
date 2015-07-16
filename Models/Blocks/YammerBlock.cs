using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "YammerBlock", GUID = "4133428a-d49f-4eb9-b428-5171d03a67c6", Description = "")]
    public class YammerBlock : BlockData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Title { get; set; }
    }
}