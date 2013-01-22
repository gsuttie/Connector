using System.Web.Mvc;
using Connector.DependencyResolution;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Connector.App_Start.StructuremapMvc), "Start")]

namespace Connector.App_Start {
    public static class StructuremapMvc 
    {
        public static void Start() 
        {
            var container = (IContainer) IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}