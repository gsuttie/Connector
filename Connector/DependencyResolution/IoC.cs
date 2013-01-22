using System.Configuration;
using StructureMap;

namespace Connector.DependencyResolution
{
    public static class IoC 
    {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.AssembliesFromApplicationBaseDirectory();
                                        scan.WithDefaultConventions();
                                    });
                            x.AddRegistry(new RavenDbRegistry(ConfigurationManager.ConnectionStrings["RavenDB"].Name));
                            x.AddRegistry(new ServiceRegistry());
                        });
            return ObjectFactory.Container;
        }
    }
}