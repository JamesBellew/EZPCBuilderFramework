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
    public class Processor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Socket { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Cores { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Threads { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string BaseSpeed { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string BoostSpeed { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Stock { get; set; }


        [Column(TypeName = "nvarchar(64)")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
