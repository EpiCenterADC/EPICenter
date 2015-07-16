using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Business.QuickPoll;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class QuickPollBlockViewModel
    {
        public string Response { get; set; }
        public string QuickPollHeading { get; set; }
        public string Question { get; set; }
        public string Alternative1 { get; set; }
        public string Alternative2 { get; set; }
        public string Alternative3 { get; set; }
        public string Alternative4 { get; set; }
        public string Alternative5 { get; set; }
        public string Alternative6 { get; set; }
        public string Alternative7 { get; set; }
        public string Alternative8 { get; set; }
        public string Alternative9 { get; set; }
        public string Alternative10 { get; set; }
        public string ResultHeading { get; set; }
        public string PollID {get;set;}
        public string TotalVotes { get; set; }
        public List<QuickPollVotes> pollStatistic { get; set; }
        public bool IsUserVoted { get; set; }
        public bool ResetPoll { get; set; }
    }
}