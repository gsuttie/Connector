using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connector.Controllers
{
    public partial class IdeasController : Controller
    {
        //
        // GET: /Ideas/

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
