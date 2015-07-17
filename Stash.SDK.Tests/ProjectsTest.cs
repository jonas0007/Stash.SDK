using System;
using System.Linq;

using Xunit;
using FakeItEasy;
using RestSharp;
using System.Collections.Generic;
using Stash.SDK.Domain;

namespace Stash.SDK.Tests
{
    public class ProjectsTest
    {
        private StashClient FakeJiraClient
        {
            get
            {
                return new StashClient(A.Fake<RestClient>());
            }
        }

        [Fact]
        public void TestGetProjectsRestCall()
        {
            RestRequest request = FakeJiraClient.GetRequest(StashClient.StashObjectEnum.Projects, new Dictionary<String, String>(), new Dictionary<String, String>());
            Assert.Equal("/rest/api/latest/projects/", request.Resource);
        }
    }
}
