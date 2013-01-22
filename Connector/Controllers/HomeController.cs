﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client;

namespace Connector.Controllers
{
    public partial class HomeController : RavenController
    {
        public HomeController(IDocumentSession documentSession) : base(documentSession)
        {
        }

        public virtual ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
