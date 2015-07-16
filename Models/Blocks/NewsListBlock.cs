using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "NewsListBlock", GUID = "64b46a4b-8758-4564-ae82-ffd562412805", Description = "")]
    public class NewsListBlock : BlockData
    {
        [Required]
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
            Name = "No of News",
            Description = "No of News",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual Int32 NoOfNews { get; set; }
    }
}