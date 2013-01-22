using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Connector.Models;
using Connector.Extensions;
using AutoMapper;
using Connector.Services.Interfaces;
using Raven.Client;

namespace Connector.Controllers
{
    public partial class TagsController : RavenController
    {
        private readonly ITagService myITagService;

        public TagsController(ITagService iTagService, IDocumentSession documentSession) : base(documentSession)
        {
            this.myITagService = iTagService;
        }

        public virtual ActionResult Index()
        {
            var model = myITagService.GetAllTags();
            
            return View(model);
        }

        public virtual JsonResult Tags()
        {
            var model = myITagService.GetAllTags();

            return this.Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
