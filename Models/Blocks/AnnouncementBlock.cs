using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "AnnouncementBlock", GUID = "a96bacf2-50d9-400d-87c8-167a52ec0210", Description = "")]
    public class AnnouncementBlock : BlockData
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "No of Announcements",
            Description = "No of Announcements",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual Int32 NoOfAnnouncements { get; set; }
    }
}