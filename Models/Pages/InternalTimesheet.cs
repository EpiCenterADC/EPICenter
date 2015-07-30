using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using EPiServer.Data.Dynamic;
using EPiServer.Data;

namespace EPiCenterBaseProject.Models.Pages
{
    [EPiServerDataTable(TableName = "tblBigTableInternalTimesheet")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "InternalTimesheetStore")]    
    public class InternalTimesheet : BasePage
    {
        public Identity Username { get; set; }
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
       
    }
}

