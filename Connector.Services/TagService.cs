using System.Collections.Generic;
using System.Linq;
using Connector.Common.Model;
using Connector.Services.Interfaces;
using Raven.Client;

namespace Connector.Services
{
    public class TagService : ITagService
    {
        private readonly IDocumentSession session;
        
        public TagService(IDocumentSession documentSession)
        {
            session = documentSession;
        }

        public IEnumerable<Tags> GetAllTags()
        {
            return session.Query<Tags>().ToList();
        }
    }
}