using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DMS.API.Models;

namespace DMS.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // API Documentation 
        public ActionResult Help()
        {
            var explorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return View(new APIDocModel(explorer));
        }

    }
}
