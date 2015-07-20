using Stash.SDK.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stash.SDK.Tests
{
    public class PullRequestTest
    {
        public PullRequestTest()
        {

        }

        [Fact]
        public void TestPullRequestCreatedDate()
        {
            //Enter the epoch timestamp for 2015-01-01
            PullRequest pullRequest = new PullRequest()
            {
                CreatedDate = 1420070400000
            };

            Assert.Equal(new DateTime(2015, 1, 1), pullRequest.Created);
        }

        [Fact]
        public void TestPullRequestUpdatedDate()
        {
            //Enter the epoch timestamp for 2015-01-01
            PullRequest pullRequest = new PullRequest()
            {
                UpdatedDate = 1420070400000
            };
            Assert.Equal(new DateTime(2015, 1, 1), pullRequest.Updated);
        }
    }
}
