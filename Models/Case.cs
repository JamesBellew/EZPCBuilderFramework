using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Case
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string FormFactor { get; set; }

        [Column(TypeName = "money")]
        public double Price { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public int Stock { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
