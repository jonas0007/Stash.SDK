using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stash.SDK.Domain
{
    public class PullRequest
    {
        public enum PullRequestStateEnum
        {
            OPEN,
            MERGED,
            DECLINED
        }

        public Int32 ID { get; set; }
        public Int32 Version { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
        public Boolean Open { get; set; }
        public Boolean Closed { get; set; }
        public Double CreatedDate { get; set; }
        public Double UpdatedDate { get; set; }
        public User Author { get; set; }
    }
}
