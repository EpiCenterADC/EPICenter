using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Data.Dynamic;
using EPiServer.Data;

namespace EPiCenterBaseProject.Business.QuickPoll
{
    [EPiServerDataTable(TableName = "tblBigTableQuickPoll")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "QuickPollStore")]
    public class QuickPollObjects
    {
        public Identity Id { get; set; }
        public int PollID { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}