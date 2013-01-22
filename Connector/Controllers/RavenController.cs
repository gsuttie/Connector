using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client;
using Raven.Imports.Newtonsoft.Json;

namespace Connector.Controllers
{

    public abstract partial class RavenController : Controller
    {
        protected RavenController(IDocumentSession documentSession)
        {
            DocumentSession = documentSession;
            JsonSettings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
        }

        public const int DefaultPage = 1;
        public const int PageSize = 10;

        public static JsonSerializerSettings JsonSettings { get; set; }

        public static IDocumentSession DocumentSession { get; private set; }

        protected int CurrentPage
        {
            get
            {
                var s = Request.QueryString["page"];
                int result;
                if (int.TryParse(s, out result))
                    return Math.Max(DefaultPage, result);
                return DefaultPage;
            }
        }
    }
}
