using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Connector.DependencyResolution
{
    public static class Database
    {
        public static IDocumentStore InitialiseDatabase(string connectionStringName = null)
        {
            if (string.IsNullOrEmpty(connectionStringName)) connectionStringName = "RavenDB";

            var store = new DocumentStore { ConnectionStringName = connectionStringName };

            // Register our custom listeners etc
            store.Initialize();
            store.JsonRequestFactory.ConfigureRequest += (sender, args) => args.Request.Timeout = 10 * 60 * 1000;

            // Register the indexes
            // Note:- We only need to call IndexCreation.CreateIndexes once for all the Indexes within the assembly,
            //IndexCreation.CreateIndexesAsync(typeof(CategoryIndex).Assembly, store);

            return store;
        }
    }
}