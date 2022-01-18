using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Assignment.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult PastEvents()
        {
            return View();
        }

        public ViewResult FutureEvents()
        {
            return View();
        }
    }
}
