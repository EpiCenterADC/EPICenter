using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiCenterBaseProject.Business.QuickPoll
{
    public class QuickPollViewModel
    {
        public List<QuickPollVotes> pollAnswer { get; set; }
        public string totalVotes { get; set; }
    }
}