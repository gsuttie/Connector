using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;

using StructureMap.Configuration.DSL;

namespace Connector.DependencyResolution
{
    public class RavenDbRegistry : Registry
    {
        public RavenDbRegistry(string connectionStringName)
        {
            For<IDocumentStore>().Singleton().Use(
                x =>
                {
                    var documentStore = Database.InitialiseDatabase(connectionStringName);
                    return documentStore;
                });

            For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(
                x =>
                {
                    var store = x.GetInstance<IDocumentStore>();
                    return store.OpenSession();
                }).Named("RavenDB Session (aka. Unit of Work).");
        }
    }
}