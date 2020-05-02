using AspnetPlaygroundV1.Models;
using AspnetPlaygroundV1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetPlaygroundV1.Controllers
{
    public class ProjectsController : Controller
    {
        private JsonProjectsService ProjectsService;

        public ProjectsController(JsonProjectsService projectsService)
        {
            ProjectsService = projectsService;
        }

        public IActionResult Index()
        {
            var projects = ProjectsService.GetProjects();

            return View(projects);
        }

        public IActionResult Test()
        {
            return Content("Success!");
        }

        public IActionResult Details(int id)
        {
            var project = ProjectsService.GetProjects().FirstOrDefault<Project>(project => project.ID == id);

            return View(project);
        }

        public IActionResult Populate()
        {
            ProjectsService.PopulateFile();

            return Content("Should be ok now!");
        }
    }
}
