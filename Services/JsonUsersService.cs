using AspnetPlaygroundV1.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetPlaygroundV1.Services
{
    public class JsonUsersService
    {
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public JsonUsersService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public string JsonFile 
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json"); }
        }

        public void PopulateFile()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 0,
                    Name = "User One",
                    Number = "1111"
                },
                new User
                {
                    Id = 1,
                    Name = "User Two",
                    Number = "2222"
                },
                new User
                {
                    Id = 2,
                    Name = "User Three",
                    Number = "3333"
                }
            };

            File.WriteAllText(JsonFile, JsonConvert.SerializeObject(users));
        }

        public IEnumerable<User> GetUsers()
        {
            return JsonConvert.DeserializeObject<IEnumerable<User>>(File.ReadAllText(JsonFile));
        }
    }
}
