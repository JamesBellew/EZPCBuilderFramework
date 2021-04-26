using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Processor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Socket { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseSpeed { get; set; }
        public double BoostSpeed { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
