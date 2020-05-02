using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetPlaygroundV1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(4)]
        public string Number { get; set; }
    }
}
