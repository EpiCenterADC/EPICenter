using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Data.Dynamic;
using EPiServer.Data;

namespace EPiCenterBaseProject.Business.QuickPoll
{
    [EPiServerDataTable(TableName = "tblBigTableQuickPollOptions")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "QuickPollOptionStore")]
    public class QuickPollOptions
    {
        public Identity Id { get; set; }
        public string PollID { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public string Option6 { get; set; }
        public string Option7 { get; set; }
        public string Option8 { get; set; }
        public string Option9 { get; set; }
        public string Option10 { get; set; }
    }
}