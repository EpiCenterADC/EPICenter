using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Business.QuickPoll;

namespace EPiCenterBaseProject.Business.Interfaces
{
    public interface IQuickPollService
    {
        void SaveQuickPoll(QuickPollBlock currentBlock);
        QuickPollCollection GetPoll(int pollID);
        bool IsPollExists(int pollID);
        void SavePollVotes(int pollID, string voteOption);
        List<QuickPollVotes> PollStatistic(int pollID);
        int GetTotalVotes(int pollID);
        bool IsUserVoted(int pollID);
        void ResetPollVoting(int pollID);
    }
}
