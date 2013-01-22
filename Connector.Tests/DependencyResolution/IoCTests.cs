using Connector.DependencyResolution;
using Connector.Services.Interfaces;

namespace Connector.Tests.DependencyResolution
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Raven.Client;

    using StructureMap;

    using Xunit;

    public class IoCTests
    {
        [Fact(Skip = "Skip for time being - need to figure out structure map build errors")]
        public void CanGetRavenCategoryService()
        {
            using (var container = IoC.Initialize())
            {
                Assert.NotNull(container.GetInstance<ITagService>());
            }
        }

        [Fact(Skip = "Skip for time being - need to figure out structure map build errors")]
        public void DocSessionIsHybridScope()
        {
            using (var container = IoC.Initialize())
            {
                var store1 = container.GetInstance<IDocumentSession>();
                var store2 = container.GetInstance<IDocumentSession>();
                IDocumentSession store3 = null;

                // Spin up new thread to get another session from the container
                var task = new Task(() => { store3 = container.GetInstance<IDocumentSession>(); });
                task.Start();
                task.Wait();

                // Hybrid (same thread, session is equal)
                Assert.Equal(store1, store2);

                // Different thread, session is not equal
                Assert.NotNull(store3);
                Assert.NotEqual(store1, store3);
            }
        }

        [Fact(Skip = "Skip for time being - need to figure out structure map build errors")]
        public void DocStoreIsSingleton()
        {
            using (var container = IoC.Initialize())
            {
                var store1 = container.GetInstance<IDocumentStore>();
                var store2 = container.GetInstance<IDocumentStore>();

                Assert.Equal(store1, store2);
            }
        }

        [Fact(Skip = "Skip for time being - need to figure out structure map build errors")]
        public void RavenDBRegistyClassIsValid()
        {
            using (var container = new Container(cfg => cfg.AddRegistry(new RavenDbRegistry("RavenDB"))))
            {
                container.AssertConfigurationIsValid();
            }
        }

        [Fact]
        public void WhatDoIHave()
        {
            using (var container = IoC.Initialize())
            {
                Debug.Write(container.WhatDoIHave());
            }
        }
    }
}
