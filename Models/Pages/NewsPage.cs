using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "NewsPage", GUID = "700ce388-a93b-4622-b324-9dd2f8a4c755", Description = "")]
    public class NewsPage : BasePage
    {
                [Required]
                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "News Summary",
                    Description = "News Summary",
                    GroupName = SystemTabNames.Content,
                    Order = 2)]
                [UIHint(UIHint.Textarea)]
                public virtual String NewsSummary { get; set; }

                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "News Body",
                    Description = "News Body",
                    GroupName = SystemTabNames.Content,
                    Order = 3)]
                public virtual XhtmlString NewsBody { get; set; }

                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "News Image",
                    Description = "News Image",
                    GroupName = SystemTabNames.Content,
                    Order = 3)]
                [UIHint(UIHint.Image)]
                public virtual ContentReference NewsImage { get; set; }

                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "Show As Announcement",
                    Description = "Show As Announcement",
                    GroupName = SystemTabNames.Content,
                    Order = 6)]
                public virtual bool ShowAsAnnouncement { get; set; }

            
         
    }
}