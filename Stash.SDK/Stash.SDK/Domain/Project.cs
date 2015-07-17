using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK.Domain
{
    public class Project
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

        public String Key { get; set; }
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean Public { get; set; }
        public String Type { get; set; }
        public Boolean IsPersonal { get; set; }

        public List<Repository> GetRepositories()
        {
            List<Repository> repositories = GetStash().Client.GetRepositoriesFromProject(this.Key);
            repositories.ForEach(repo => repo.SetStash(GetStash()));

            return repositories;
        }
    }
}
