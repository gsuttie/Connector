using Raven.Imports.Newtonsoft.Json.Serialization;

namespace Connector.Controllers
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}