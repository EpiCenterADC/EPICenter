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


        private IEnumerable<SelectListItem> da;

        public List<String> Dateforselectedweek(int year,int weeknumber)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
                int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

                DateTime firstThursday = jan1.AddDays(daysOffset);
                var cal = CultureInfo.CurrentCulture.Calendar;
                int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                var weekNum = weeknumber;
                if (firstWeek <= 1)
                {
                   weekNum -= 1;
                }
                var result = firstThursday.AddDays(weekNum * 7);
                var SelectedWeekStartDate = result.AddDays(-3);

                var Dates = new List<DateTime>();
                DateTime d = new DateTime();
                Dates.Add(SelectedWeekStartDate);
                d = SelectedWeekStartDate.Date;
                for (int i = 1; i <= 6; i++)
                {

                    var e = d.AddDays(i);
                    Dates.Add(e.Date);
                }

                List<string> DateString = new List<string>();

                foreach (DateTime dt in Dates)
                {
                    DateString.Add(dt.ToString("dd/MMM/yy"));
                }


                return DateString;
        }

        public IEnumerable<SelectListItem> Date
        {


            set
            {
                DateTime baseDate = DateTime.Today;

                var today = baseDate;
                //var yesterday = baseDate.AddDays(-1);
                var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek + 1);
                var Dates = new List<DateTime>();
                DateTime d = new DateTime();
                Dates.Add(thisWeekStart);
                d = thisWeekStart.Date;
                for (int i = 1; i <= 6; i++)
                {

                    var e = d.AddDays(i);
                    Dates.Add(e.Date);
                }

                List<string> DateString = new List<string>();

                foreach (DateTime dt in Dates)
                {
                    DateString.Add(dt.ToString("dd/MMM/yy"));
                }

                da = new SelectList(DateString);
            }
            get
            {
                Date = da;
                return da;
            }

        }

    }
}