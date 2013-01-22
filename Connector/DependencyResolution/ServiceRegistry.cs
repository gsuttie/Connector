using Connector.Services;
using Connector.Services.Interfaces;
using StructureMap.Configuration.DSL;

namespace Connector.DependencyResolution
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            this.For<ITagService>().Use<TagService>();
        }
    }
}