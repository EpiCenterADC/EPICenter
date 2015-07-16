using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Data.Dynamic;
using EPiServer.Data;

namespace EPiCenterBaseProject.Business.QuickPoll
{
    [EPiServerDataTable(TableName = "tblBigTableQuickPollResult")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "QuickPollResultStore")]
    public class QuickPollResult
    {
        public Identity Id { get; set; }
        public string MainPollID { get; set; }
        public string UserName { get; set; }
        public string OptionID { get; set; }
     
    }
}