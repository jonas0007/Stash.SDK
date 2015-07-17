using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK.Domain
{
    public class Repository
    {
        private Stash _stash { get; set; }
        public Stash GetStash()
        {
            return _stash;
        }

        public void SetStash(Stash stash)
        {
            _stash = stash;
        }

        public String Slug { get; set; }
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
        public String StatusMessage { get; set; }
        public Boolean Forkable { get; set; }
        public Project Project { get; set; }

        public Boolean Public { get; set; }

        public List<PullRequest> GetOpenPullRequests()
        {
            return GetPullRequestsWithStatus(PullRequest.PullRequestStateEnum.OPEN);
        }

        public List<PullRequest> GetMergedPullRequests()
        {
            return GetPullRequestsWithStatus(PullRequest.PullRequestStateEnum.MERGED);
        }
        public List<PullRequest> GetDeclinedPullRequests()
        {
            return GetPullRequestsWithStatus(PullRequest.PullRequestStateEnum.DECLINED);
        }

        private List<PullRequest> GetPullRequestsWithStatus(PullRequest.PullRequestStateEnum state)
        {
            List<PullRequest> pullRequests = GetStash().Client.GetPullRequestsFromRepository(Project.Key, this.Slug, state.ToString());

            return pullRequests;
        }
    }
}
