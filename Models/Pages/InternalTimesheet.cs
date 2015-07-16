using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace EPiCenterBaseProject.Models.Pages
{
    public class InternalTimesheet : BasePage
    {
        public int srno { get; set; }
        public int WeekNo { get; set; }
        public DateTime Date { get; set; }
        public string Project { get; set; }
        public string RFC { get; set; }
        public string Title { get; set; }
        public string Task { get; set; }
        public decimal ActualhrsBooked { get; set; }
        public decimal ClientBillablehrsBooked { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Action { get; set; }

        public List<int> GetListOfWeekNumbers()
        {
           
            ////    DateTime test_date = DateTime.Now.Month;
            ////    double week_of_year = Math.Ceiling(Convert.ToDouble(test_date.DayOfYear) / 7);

            List<int> weeks = new List<int>();
            ////for (int i = 1; i <= 5; i++)
            ////{
            ////    DateTime date1 = DateTime.Now.;
            ////    DateTimeFormatInfo dinfo = DateTimeFormatInfo.CurrentInfo;
            ////    int weekNo = dinfo.Calendar.GetWeekOfYear(date1, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            ////    weeks.Add(weekNo);
            ////}
            //DateTime dt = DateTime.ParseExact("09/07/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            //cal.GetWeekOfYear(dt, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Monday);

            DateTime date = DateTime.Now;
            int No_of_Weeks = 0;

            int mondays = 0;
            int month = date.Month;
            int year = date.Year;
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
            {
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                    No_of_Weeks = mondays++;
            }

            for (int i = 1; i <= No_of_Weeks; i++)
            {
                //"09/07/2015"
                DateTime test_date = DateTime.ParseExact(date.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int week_of_year = (int)Math.Ceiling(Convert.ToDouble(test_date.DayOfYear) / 7);
                weeks.Add(week_of_year);
                date.AddDays(7);
            }

            return weeks;
        }
    }
}

