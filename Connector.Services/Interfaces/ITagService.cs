using System.Collections.Generic;
using Connector.Common.Model;

namespace Connector.Services.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tags> GetAllTags();
    }
}