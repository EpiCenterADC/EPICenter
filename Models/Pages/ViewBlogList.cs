using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "ViewBlogList", GUID = "30351a34-4f68-4c95-b523-b0f495c85915", Description = "")]
    public class ViewBlogList : BasePage
    {
        /*
                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
    }
}