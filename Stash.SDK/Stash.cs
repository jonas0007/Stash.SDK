using Stash.SDK.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK
{
    public class Stash
    {
        private IStashClient _client;
        internal IStashClient Client { get { return _client; } }

        public void Connect(IStashClient client)
        {
            _client = client;
        }

        public void Connect(String url)
        {
            Connect(new StashClient(url));
        }

        public void Connect(String url, String username, String password)
        {
            Connect(new StashClient(url, username, password));
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = Client.GetProjects();
            projects.ForEach(project => project.SetStash(this));

            return projects;
        }
    }
}
