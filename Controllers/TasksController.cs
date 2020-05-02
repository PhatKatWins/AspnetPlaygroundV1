using AspnetPlaygroundV1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetPlaygroundV1.Controllers
{
    public class TasksController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var project = new Project
            {
                ID = 1,
                Name = "Test"
            };

            return Content(project.ToString());
        }
    }
}
