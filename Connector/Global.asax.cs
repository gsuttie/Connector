using Raven.Client;
using StructureMap;

namespace Connector
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDocumentStore Store { get; set; }

        protected void Application_Start()
        {
            // All other config is handled by AppActivator in App_Start
            Store = ObjectFactory.GetInstance<IDocumentStore>();
        }
    }
}