using AspnetPlaygroundV1.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetPlaygroundV1.Services
{
    public class JsonProjectsService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonProjectsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public string JsonFile
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json"); }
        }

        public void PopulateFile()
        {
            var projectList = new List<Project>()
            {
                new Project
                {
                    ID = 0,
                    Name = "Project One",
                    Description = "Description of Project One",
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    ID = 1,
                    Name = "Project Two",
                    Description = "Description of Project Two",
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    ID = 2,
                    Name = "Project Three",
                    Description = "Description of Project Three",
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    ID = 3,
                    Name = "Project Four",
                    Description = "Description of Project Four",
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    ID = 4,
                    Name = "Project Five",
                    Description = "Description of Project Five",
                    CreatedOn = DateTime.Now
                }
            };

            File.WriteAllText(JsonFile, JsonConvert.SerializeObject(projectList));
        }

        public IEnumerable<Project> GetProjects()
        {
            using (var fileReader = File.OpenText(JsonFile))
            {
                return System.Text.Json.JsonSerializer.Deserialize<Project[]>(fileReader.ReadToEnd());
            }
        }
    }
}
