using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "QuickPollBlock", GUID = "2a7835b0-4aff-4f2c-8d82-912703f7b34f", Description = "")]
    public class QuickPollBlock : BlockData
    {
        [Display(
          GroupName = SystemTabNames.Content,
          Order = 3)]
        public virtual bool ResetPoll { get; set; }

        [Display(
          GroupName = SystemTabNames.Content,
          Order = 4)]
        [Required]
        public virtual string QuickPollHeading { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [Required]
        public virtual string Question { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 7)]
        public virtual string Alternative1 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 8)]
        public virtual string Alternative2 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 9)]
        public virtual string Alternative3 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10)]
        public virtual string Alternative4 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 11)]
        public virtual string Alternative5 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 12)]
        public virtual string Alternative6 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 13)]
        public virtual string Alternative7 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 14)]
        public virtual string Alternative8 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 15)]
        public virtual string Alternative9 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 16)]
        public virtual string Alternative10 { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 18)]
        public virtual string ResultHeading { get; set; }
    }
}