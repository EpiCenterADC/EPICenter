using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;
using EPiServer.Core;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class ProfilePageViewModel : BasePageViewModel
    {
        public ProfilePage ProfilePage { get; set; }
        public ContentReference profilePhoto { get; set; }
        public List<string> ProjectsWorkedOn { get; set; }
    }
}