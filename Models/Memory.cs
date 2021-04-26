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
        private int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private string ModelNum { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private string Size { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        private int Speed { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        private string Type { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        private string Latency { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        private double Price { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        private int Stock { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(64)")]
        private string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
