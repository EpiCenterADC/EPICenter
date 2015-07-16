using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using System.Globalization;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;
using System.Web.Security;

namespace EPiCenterBaseProject.Controllers
{
    public class InternalTimesheetController : BasePageController<InternalTimesheet>, IController
    {
        //
        // GET: /Test/      
        //   private readonly IInternalTimesheetService _internalTimesheetService = ServiceLocator.Current.GetInstance<IInternalTimesheetService>();
        private readonly IProfilePageService _profilePageService = ServiceLocator.Current.GetInstance<IProfilePageService>();

        public ActionResult Index(InternalTimesheet currentPage, ProfileListingPage currentPagec)
        {
            InternalTimesheetViewModel v = new InternalTimesheetViewModel();
            var model = CreateModel(new InternalTimesheetViewModel
            {
                InternalTimesheet = currentPage,
                UserList = _profilePageService.GetAllProfiles(currentPagec)
                ////UserList = _internalTimesheetService.GetUsers(currentPage)
            });
            SelectWeek();
            SelectMonth();
            yeartextbox(v);
            return View("Index", model);
            var abc = Request[model.Month.ToString()];
        }


        public ActionResult SelectWeek()
        {
            List<int> weeks = new List<int>();
            DateTime date = DateTime.Now;
            int No_of_Weeks = 0;
            int dayOfweek = 0;
            //  int month = date.Month;
            int year = date.Year;

            // Get selected month from month dropdown
            InternalTimesheetViewModel internalViewModel = new InternalTimesheetViewModel();
            //var res=internalViewModel.Month.FirstOrDefault(s=>s.Value=);
            //if (=="January")
            //{
            //    int selectedMonth = 1;
            //}
            //   int selectedMonth = SelectMonth().ExecuteResult(
            int selectedMonth = int.Parse(Convert.ToString(internalViewModel.Month.ToString()));
            // int monthInDigit = DateTime.ParseExact(Convert.ToString(internalViewModel.Month.ToString()), "MMM", CultureInfo.InvariantCulture).Month;
            //int selectedMonth = 2;
            DateTime beginingOfThisMonth = new DateTime(year, selectedMonth, 1);
            int daysThisMonth = DateTime.DaysInMonth(year, selectedMonth);
            for (int i = 0; i < daysThisMonth; i++)
            {
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == beginingOfThisMonth.DayOfWeek)
                    No_of_Weeks = ++dayOfweek;
            }

            for (var i = 1; i <= No_of_Weeks; i++)
            {
                //"09/07/2015"
                DateTime test_date = DateTime.ParseExact(beginingOfThisMonth.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                int week_of_year = (int)Math.Ceiling(Convert.ToDouble(test_date.DayOfYear) / 7);
                weeks.Add(week_of_year);
                int count = 0, incWeek = 7;
                for (int k = 1; k < incWeek; k++)
                {
                    if (beginingOfThisMonth.AddDays(k).DayOfWeek != DayOfWeek.Saturday)
                    {
                        if (beginingOfThisMonth.AddDays(k).DayOfWeek != DayOfWeek.Sunday)
                        { count++; }
                        else { incWeek++; }
                    }
                    else { incWeek++; }
                }
                beginingOfThisMonth = beginingOfThisMonth.AddDays(count);
            }

            ViewData["WeekNumber"] = new SelectList((List<int>)weeks);
            return View();
        }

        public ActionResult SelectMonth()
        {
            //  List<string> months = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            // ViewData["Month"] = months;
            // ViewData["currentmonth"]= DateTime.Today.Date.Month;
            InternalTimesheetViewModel i = new InternalTimesheetViewModel();
            ViewData["Month"] = i.Month;
            return View();
        }

        public ActionResult yeartextbox(InternalTimesheetViewModel v)
        {
            //do something

            return View(); //return "Search" view to the user
        }

        //public ActionResult selectDate()
        //{
        //    InternalTimesheetViewModel i = new InternalTimesheetViewModel();
        //    ViewData["Date"] = i.Date;
        //    return View();
        //}


    }
}
