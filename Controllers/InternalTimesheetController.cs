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
using EPiServer.Core;
using EPiCenterBaseProject.Business;
using EPiServer;
using Newtonsoft.Json;

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
            FormCollection f = new FormCollection();
            InternalTimesheetViewModel v = new InternalTimesheetViewModel();
            var model = CreateModel(new InternalTimesheetViewModel
            {
                InternalTimesheet = currentPage,
                UserList = _profilePageService.GetAllProfiles(currentPagec)
                ////UserList = _internalTimesheetService.GetUsers(currentPage)
            });
            //SaveInternalTimesheetData(f);
            SelectWeek();
            SelectMonth();
            selectDate();
            yeartextbox(v);
            return View("Index", model);
        }
        public ActionResult SelectWeek()
        {

            DateTime date = DateTime.Now;
            int No_of_Weeks = 0;
            int dayOfweek = 0;
            int month = 3;
            int year = date.Year;
            List<int> weeks = new List<int>();
            // Get selected month from month dropdown
            InternalTimesheetViewModel internalViewModel = new InternalTimesheetViewModel();
            //var res=internalViewModel.Month.FirstOrDefault(s=>s.Value=);
            //if (=="January")
            //{
            //    int selectedMonth = 1;
            //}
            //   int selectedMonth = SelectMonth().ExecuteResult(
            //int selectedMonth = int.Parse(Convert.ToString(internalViewModel.Month.ToString()));
            // int monthInDigit = DateTime.ParseExact(Convert.ToString(internalViewModel.Month.ToString()), "MMM", CultureInfo.InvariantCulture).Month;
            //int selectedMonth = 2;
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            int daysThisMonth = DateTime.DaysInMonth(year, month);
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
                //states.Add(new SelectListItem { Text = Convert.ToString(week_of_year), Value = Convert.ToString(week_of_year) });
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
        public ActionResult yeartextbox(InternalTimesheetViewModel v)
        {
            //do something

            return View(); //return "Search" view to the user
        }

        public ActionResult selectDate()
        {
            InternalTimesheetViewModel i = new InternalTimesheetViewModel();
            var x = i.Date;
            ViewData["Date"] = x;
            return View();
        }

        
        public JsonResult selectDateForSelectedWeek(int year,int weeknumber)
        {
            InternalTimesheetViewModel i = new InternalTimesheetViewModel();
            var x = i.Dateforselectedweek(year,weeknumber);
            //ViewData["Date"] = x;
            //return View();
            //return null;
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public JsonResult bindDropDownProject()
        {
            var projects= FindPages().Select(u => u.Name).DefaultIfEmpty();
            return Json(projects,JsonRequestBehavior.AllowGet);

            //return Json(projects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult bindDropDownTaskPages()
        {
            var TaskPages = FindPagesTaskParent().Select(u => u.Name).DefaultIfEmpty();
            return Json(TaskPages, JsonRequestBehavior.AllowGet);
        }


        public class getAllChildren
        {
            public string name { get; set; }
            public string URL { get; set; }


        }

        public IEnumerable<PageData> FindPagesTaskParent()
        {
            PageReference rootPage2 = DataFactory.Instance.GetPage(ContentReference.StartPage).GetPropertyValue<PageReference>("rootpage2");
            IEnumerable<PageData> childPages2 = DataFactory.Instance.GetChildren<PageData>(rootPage2);
            return childPages2;
        }

        public IEnumerable<PageData> FindPages()
        {
            List<PageData> childPagesAll = new List<PageData>();
            PageReference rootPage = DataFactory.Instance.GetPage(ContentReference.StartPage).GetPropertyValue<PageReference>("rootpage");
            PageReference rootPage1 = DataFactory.Instance.GetPage(ContentReference.StartPage).GetPropertyValue<PageReference>("rootpage1");

            getAllChildren child = new getAllChildren();
            IEnumerable<PageData> childPages = DataFactory.Instance.GetChildren<PageData>(rootPage);

            foreach (PageData p in childPages)
            {
                childPagesAll.Add(p);

            }
            IEnumerable<PageData> childPages1 = DataFactory.Instance.GetChildren<PageData>(rootPage1);
            foreach (PageData p in childPages1)
            {
                childPagesAll.Add(p);

            }
            return childPagesAll;
        }

        #region Priti
        List<SelectListItem> weeksno = new List<SelectListItem>();
        public ActionResult SelectMonth()
        {
            List<SelectListItem> li = new List<SelectListItem>();

            li.Add(new SelectListItem { Text = DateTime.Now.ToString("MMMM"), Value = "0" });

            li.Add(new SelectListItem { Text = "January", Value = "1" });

            li.Add(new SelectListItem { Text = "February", Value = "2" });

            li.Add(new SelectListItem { Text = "March", Value = "3" });

            li.Add(new SelectListItem { Text = "April", Value = "4" });

            li.Add(new SelectListItem { Text = "May", Value = "5" });

            li.Add(new SelectListItem { Text = "June", Value = "6" });
            li.Add(new SelectListItem { Text = "July", Value = "7" });
            li.Add(new SelectListItem { Text = "August", Value = "8" });
            li.Add(new SelectListItem { Text = "September", Value = "9" });
            li.Add(new SelectListItem { Text = "October", Value = "10" });
            li.Add(new SelectListItem { Text = "November", Value = "11" });
            li.Add(new SelectListItem { Text = "December", Value = "12" });
            ViewData["month"] = li;
            return View();
        }

        public JsonResult GetStates(string id)
        {

            // List<SelectListItem> states = new List<SelectListItem>();

            switch (id)
            {
                case "0":
                    getdata(DateTime.Now.Month);
                    break;

                case "1":
                    getdata(1);
                    break;
                case "2":
                    getdata(2);
                    break;

                case "3":
                    getdata(3);
                    break;
                case "4":
                    getdata(4);
                    break;
                case "5":
                    getdata(5);
                    break;
                case "6":
                    getdata(6);
                    break;
                case "7":
                    getdata(7);
                    break;
                case "8":
                    getdata(8);
                    break;
                case "9":
                    getdata(9);
                    break;
                case "10":
                    getdata(10);
                    break;
                case "11":
                    getdata(11);
                    break;
                case "12":
                    getdata(12);
                    break;

            }

            return Json(new SelectList(weeksno, "Value", "Text"));
        }

        public void getdata(int month1)
        {
            DateTime date = DateTime.Now;
            int No_of_Weeks = 0;
            int dayOfweek = 0;
            int month = month1;
            int year = date.Year;
            List<int> weeks = new List<int>();
            // Get selected month from month dropdown
            InternalTimesheetViewModel internalViewModel = new InternalTimesheetViewModel();

            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            //  string EndOftheweekday = new DateTime(year, month, 7);
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime dt = new DateTime(year, month, daysThisMonth);
            for (int i = 0; i < daysThisMonth; i++)
            {
                if (i == 0)
                {
                    if (beginingOfThisMonth.AddDays(i).DayOfWeek == beginingOfThisMonth.DayOfWeek)

                        No_of_Weeks = ++dayOfweek;
                }
                else
                {
                    if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)

                        No_of_Weeks = ++dayOfweek;
                }
            }

            for (var i = 1; i <= No_of_Weeks; i++)
            {
                //"09/07/2015"
                DateTime test_date = DateTime.ParseExact(beginingOfThisMonth.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                int week_of_year = (int)Math.Ceiling(Convert.ToDouble(test_date.DayOfYear) / 7);
                // weeks.Add(week_of_year);
                weeksno.Add(new SelectListItem { Text = Convert.ToString(week_of_year), Value = Convert.ToString(week_of_year) });
                int count = 0, incWeek = 7;
                for (int k = 1; k <= incWeek; k++)
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













        }
        #endregion

        #region Snehal
        public JsonResult TagSearch(string term, InternalTimesheet currentPage, ProfileListingPage currentPagec)
        {
            // Get Tags from database
            string[] tags = { "ASP.NET", "WebForms", 
                    "MVC", "jQuery", "ActionResult", 
                    "MangoDB", "Java", "Windows" };

            var model = CreateModel(new InternalTimesheetViewModel
            {
                InternalTimesheet = currentPage,
                UserList = _profilePageService.GetAllProfiles(currentPagec)
            });

            List<string> name = new List<string>();
            foreach (var a in model.UserList.Where(t => t.Name.StartsWith(term)))
            {
                name.Add(a.Name);
            }

            return this.Json(name, JsonRequestBehavior.AllowGet);
        }

        #endregion

        ////public ActionResult SaveInternalTimesheetData()
        ////{
        ////    return View();
        ////}

        //[HttpPost]
        //public ActionResult SaveInternalTimesheetData(FormCollection f)
        //{
        //    var savetimesheet = new InternalTimesheet()
        //    {
        //        Title = f.Get("title")
        //    };
        //    var store = DynamicDataStoreFactory.Instance.GetStore(typeof(InternalTimesheet));
        //    store.Save(savetimesheet);
        //    return View();
        //}
    }
}



