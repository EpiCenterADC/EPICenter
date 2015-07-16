using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Business.Interfaces;
using EPiCenterBaseProject.Models.Blocks;
using EPiCenterBaseProject.Business.QuickPoll;
using EPiServer.Data.Dynamic;
using EPiServer.Data;
using EPiServer.Core;

namespace EPiCenterBaseProject.Business
{
    public class QuickPollService : IQuickPollService
    {
        public void SaveQuickPoll(QuickPollBlock currentBlock)
        {
            if (!IsPollExists((currentBlock as IContent).ContentLink.ID))
            {
                SaveQuickPollObjects(currentBlock);
            }
            else
            {
                UpdateQuickPollObjects(currentBlock);
            }

        }

        private void SaveQuickPollObjects(QuickPollBlock currentBlock)
        {
            var quickPoll = new QuickPollObjects()
            {
                Id = Identity.NewIdentity(Guid.NewGuid()),
                PollID = (currentBlock as IContent).ContentLink.ID,
                Title = currentBlock.QuickPollHeading,
                Question = currentBlock.Question,
                CreatedBy = System.Web.HttpContext.Current.User.Identity.Name,
                IsActive = true
            };

            var quickPollStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollObjects));
            quickPollStore.Save(quickPoll);

            var quickPollOptions = new QuickPollOptions()
            {
                Id = Identity.NewIdentity(Guid.NewGuid()),
                PollID = Convert.ToString((currentBlock as IContent).ContentLink.ID),
                Option1 = currentBlock.Alternative1,
                Option2 = currentBlock.Alternative2,
                Option3 = currentBlock.Alternative3,
                Option4 = currentBlock.Alternative4,
                Option5 = currentBlock.Alternative5,
                Option6 = currentBlock.Alternative6,
                Option7 = currentBlock.Alternative7,
                Option8 = currentBlock.Alternative8,
                Option9 = currentBlock.Alternative9,
                Option10 = currentBlock.Alternative10
            };

            var quickPollOptionsStores = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollOptions));
            quickPollOptionsStores.Save(quickPollOptions);
        }

        private void UpdateQuickPollObjects(QuickPollBlock currentBlock)
        {
            int quickPollID = (currentBlock as IContent).ContentLink.ID;

            var quickPollObjectStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollObjects));
            var pollObjects = quickPollObjectStore.Find<QuickPollObjects>("PollID", quickPollID).FirstOrDefault();
            pollObjects.Title = currentBlock.QuickPollHeading;
            pollObjects.Question = currentBlock.Question;
            pollObjects.IsActive = true;
            pollObjects.CreatedBy = System.Web.HttpContext.Current.User.Identity.Name;
            quickPollObjectStore.Save(pollObjects);

            var pollOptionsStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollOptions));
            var pollOptionObjects = pollOptionsStore.Find<QuickPollOptions>("PollID", quickPollID).FirstOrDefault();
            if (pollOptionObjects != null)
            {
                pollOptionObjects.PollID = Convert.ToString(quickPollID);
                pollOptionObjects.Option1 = currentBlock.Alternative1;
                pollOptionObjects.Option2 = currentBlock.Alternative2;
                pollOptionObjects.Option3 = currentBlock.Alternative3;
                pollOptionObjects.Option4 = currentBlock.Alternative4;
                pollOptionObjects.Option5 = currentBlock.Alternative5;
                pollOptionObjects.Option6 = currentBlock.Alternative6;
                pollOptionObjects.Option7 = currentBlock.Alternative7;
                pollOptionObjects.Option8 = currentBlock.Alternative8;
                pollOptionObjects.Option9 = currentBlock.Alternative9;
                pollOptionObjects.Option10 = currentBlock.Alternative10;
            }

            pollOptionsStore.Save(pollOptionObjects);

        }

        public bool IsPollExists(int pollID)
        {
            bool IsPollExists = false;

            using (var quickPollObjectStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollObjects)))
            {
                var pollObjects = quickPollObjectStore.Find<QuickPollObjects>("PollID", pollID).FirstOrDefault();
                if (pollObjects != null)
                {
                    IsPollExists = true;
                }
            }

            return IsPollExists;
        }

        public void UpdatePoll()
        {
        }

        public void SaveVoting()
        {
        }

        public QuickPollCollection GetPoll(int pollID)
        {
            QuickPollCollection quickPollCollection = new QuickPollCollection();
            quickPollCollection.QuickPollObjects = new QuickPollObjects();
            quickPollCollection.QuickPollOptions = new QuickPollOptions();

            using (var quickPollObjectStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollObjects)))
            {
                var pollObjects = quickPollObjectStore.Find<QuickPollObjects>("PollID", pollID).FirstOrDefault();
                if (pollObjects != null)
                {
                    quickPollCollection.QuickPollObjects.PollID = pollObjects.PollID;
                    quickPollCollection.QuickPollObjects.Title = pollObjects.Title;
                    quickPollCollection.QuickPollObjects.Question = pollObjects.Question;
                    quickPollCollection.QuickPollObjects.IsActive = pollObjects.IsActive;
                    quickPollCollection.QuickPollObjects.CreatedBy = pollObjects.CreatedBy;
                }
            }


            using (var pollOptions = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollOptions)))
            {
                var pollOptionObjects = pollOptions.Find<QuickPollOptions>("PollID", pollID).FirstOrDefault();
                if (pollOptionObjects != null)
                {
                    quickPollCollection.QuickPollOptions.PollID = pollOptionObjects.PollID;
                    quickPollCollection.QuickPollOptions.Option1 = pollOptionObjects.Option1;
                    quickPollCollection.QuickPollOptions.Option2 = pollOptionObjects.Option2;
                    quickPollCollection.QuickPollOptions.Option3 = pollOptionObjects.Option3;
                    quickPollCollection.QuickPollOptions.Option4 = pollOptionObjects.Option4;
                    quickPollCollection.QuickPollOptions.Option5 = pollOptionObjects.Option5;
                    quickPollCollection.QuickPollOptions.Option6 = pollOptionObjects.Option6;
                    quickPollCollection.QuickPollOptions.Option7 = pollOptionObjects.Option7;
                    quickPollCollection.QuickPollOptions.Option8 = pollOptionObjects.Option8;
                    quickPollCollection.QuickPollOptions.Option9 = pollOptionObjects.Option9;
                    quickPollCollection.QuickPollOptions.Option10 = pollOptionObjects.Option10;
                }
            }

            return quickPollCollection;

        }

        public void SavePollVotes(int pollID, string voteOption)
        {
            var currentPoll = GetPoll(pollID);

            var quickPoll = new QuickPollResult()
            {
                Id = Identity.NewIdentity(Guid.NewGuid()),
                MainPollID = Convert.ToString(pollID),
                UserName = System.Web.HttpContext.Current.User.Identity.Name,
                OptionID = voteOption
            };

            var quickPollResultStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollResult));
            quickPollResultStore.Save(quickPoll);
        }

        public List<QuickPollVotes> PollStatistic(int pollID)
        {
            var pollStatistic = GetPollResult(pollID);
            return pollStatistic;
        }

        public List<QuickPollVotes> GetPollResult(int pollID)
        {
            QuickPollResult quickPollResult = new QuickPollResult();
            QuickPollOptions quickPollOption = new QuickPollOptions();
            List<QuickPollVotes> voteCollection = new List<QuickPollVotes>();

            using (var pollOptions = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollOptions)))
            {
                quickPollOption = pollOptions.Find<QuickPollOptions>("PollID", pollID).FirstOrDefault();
            }

            using (var pollResults = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollResult)))
            {
                var pollResultObjects = pollResults.Find<QuickPollResult>("MainPollID", pollID);
                if (pollResultObjects != null)
                {

                    var totalCount = pollResultObjects.Count();

                    if (quickPollOption.Option1 != null)
                    {
                        var vote1 = GetQuickPollVote(quickPollOption.Option1, pollResultObjects);
                        voteCollection.Add(vote1);
                    }

                    if (quickPollOption.Option2 != null)
                    {
                        var vote2 = GetQuickPollVote(quickPollOption.Option2, pollResultObjects);
                        voteCollection.Add(vote2);
                    }

                    if (quickPollOption.Option3 != null)
                    {
                        var vote3 = GetQuickPollVote(quickPollOption.Option3, pollResultObjects);
                        voteCollection.Add(vote3);
                    }

                    if (quickPollOption.Option4 != null)
                    {
                        var vote4 = GetQuickPollVote(quickPollOption.Option4, pollResultObjects);
                        voteCollection.Add(vote4);
                    }

                    if (quickPollOption.Option5 != null)
                    {
                        var vote5 = GetQuickPollVote(quickPollOption.Option5, pollResultObjects);
                        voteCollection.Add(vote5);
                    }

                    if (quickPollOption.Option6 != null)
                    {
                        var vote6 = GetQuickPollVote(quickPollOption.Option6, pollResultObjects);
                        voteCollection.Add(vote6);
                    }

                    if (quickPollOption.Option7 != null)
                    {
                        var vote7 = GetQuickPollVote(quickPollOption.Option7, pollResultObjects);
                        voteCollection.Add(vote7);
                    }

                    if (quickPollOption.Option8 != null)
                    {
                        var vote8 = GetQuickPollVote(quickPollOption.Option8, pollResultObjects);
                        voteCollection.Add(vote8);
                    }

                    if (quickPollOption.Option9 != null)
                    {
                        var vote9 = GetQuickPollVote(quickPollOption.Option9, pollResultObjects);
                        voteCollection.Add(vote9);
                    }

                    if (quickPollOption.Option10 != null)
                    {
                        var vote10 = GetQuickPollVote(quickPollOption.Option10, pollResultObjects);
                        voteCollection.Add(vote10);
                    }

                }
            }

            return voteCollection;
        }

        private QuickPollVotes GetQuickPollVote(string optionID, IEnumerable<QuickPollResult> pollResultObjects)
        {

            QuickPollVotes votes = new QuickPollVotes();
            votes.answer = optionID;
            votes.votes = pollResultObjects.Where(x => x.OptionID == optionID).Count();
            return votes;
        }

        public int GetTotalVotes(int pollID)
        {
            int totalVotes = 0;
            using (var pollResults = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollResult)))
            {
                var pollResultObjects = pollResults.Find<QuickPollResult>("MainPollID", pollID);
                if (pollResultObjects != null)
                {

                    totalVotes = pollResultObjects.Count();
                }


            }
            return totalVotes;
        }

        public bool IsUserVoted(int pollID)
        {
            bool IsUserVoted = false;

            using (var quickPollObjectStore = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollResult)))
            {
                var pollObjects = quickPollObjectStore.Find<QuickPollResult>("MainPollID", pollID);
                if (pollObjects != null)
                {
                    IsUserVoted = pollObjects.Where(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name).Any();
                }
            }
            return IsUserVoted;
        }

        public void ResetPollVoting(int pollID)
        {
            IEnumerable<QuickPollResult> pollResultObjects;

            var pollResults = DynamicDataStoreFactory.Instance.GetStore(typeof(QuickPollResult));
            pollResultObjects = pollResults.Find<QuickPollResult>("MainPollID", pollID);

            foreach (var result in pollResultObjects)
            {
                pollResults.Delete(result.Id);
            }
        }
    }
}