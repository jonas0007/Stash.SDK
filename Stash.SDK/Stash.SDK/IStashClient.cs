using Stash.SDK.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK
{
    public interface IStashClient
    {
        List<Project> GetProjects();
        List<Repository> GetRepositoriesFromProject(String projectKey);
        List<PullRequest> GetPullRequestsFromRepository(String projectKey, String repositorySlug, String pullRequestState);
    }
}
