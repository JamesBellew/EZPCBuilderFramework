using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Memory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string ModelNum { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Size { get; set; }

        [Required]
        [Column(TypeName ="int")]
        public int Speed { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        public string Latency { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        public double Price { get; set; }

        [Required]
        [Column(TypeName ="int")]
        public int Stock { get; set; }

        
        [Column(TypeName ="nvarchar(64)")]
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
