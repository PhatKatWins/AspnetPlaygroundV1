using AspnetPlaygroundV1.Models;
using AspnetPlaygroundV1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetPlaygroundV1.Controllers
{
    public class UsersController : Controller
    {
        private JsonUsersService JsonUsersService;

        public UsersController(JsonUsersService jsonUsersService)
        {
            JsonUsersService = jsonUsersService;
        }

        public IActionResult Index()
        {
            return View(JsonUsersService.GetUsers());
        }

        public IActionResult Populate()
        {
            JsonUsersService.PopulateFile();

            return Content("List should be populated!");
        }

        [HttpPost("")]
        public IActionResult Get(string name, string number)
        {
            return RedirectToAction("Index", "Projects");
        }
    }
}
