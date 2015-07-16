using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Pages;
using System.Globalization;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
//using System.Web.WebPages.Html;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class InternalTimesheetViewModel : BasePageViewModel
    {
        public InternalTimesheet InternalTimesheet { get; set; }
        public string SelectedWeekNumber { get; set; }
        public IEnumerable<SelectListItem> WeekNumber { get; set; }
        public IEnumerable<SelectListItem> Month
        {
            get
            {
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Select((monthName, index) => new SelectListItem
                       {
                           Value = (index + 1).ToString(),
                           Text = monthName
                       });
                
            }
        }

        private int year;

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[1-9]{4}\d*$", ErrorMessage = "Use Numbers only")]
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
            }
        }

        public IEnumerable<ProfilePage> UserList { get; set; }

        //public IEnumerable<SelectListItem> Date
        //{
        //    get
        //    {
        //        int thisWeekNumber = 
        //    }
        //}

    }
}