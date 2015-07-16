using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace EPiCenterBaseProject.Models.Pages
{
    [ContentType(DisplayName = "ProfilePage", GUID = "656cc9a1-5d2f-4e0a-830d-99b4e71cff8f", Description = "")]
    public class ProfilePage : BasePage
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Project Worked On",
            Description = "Project Worked On",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual CategoryList ProjectsCategories { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "User Name",
            Description = "User Name",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual String UserName { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Role",
            Description = "Role",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual String Role { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Designation",
            Description = "Designation",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual String Designation { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "About",
            Description = "About",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [UIHint(UIHint.Textarea)]
        public virtual String About { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Certifications",
            Description = "Certifications",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        [UIHint(UIHint.Textarea)]
        public virtual String Certifications { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Hobbies",
            Description = "Hobbies",
            GroupName = SystemTabNames.Content,
            Order = 9)]
        public virtual String Hobbies { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Experience",
            Description = "Experience",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual String Experience { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Skills",
            Description = "Skills",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        public virtual String Skills { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "User Photo",
            Description = "User Photo",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference UserPhoto { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Email",
            Description = "Email",
            GroupName = SystemTabNames.Content,
            Order = 13)]
        public virtual String Email { get; set; }

        [Required]
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Phone",
            Description = "Phone",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual String Phone { get; set; }
    }
}