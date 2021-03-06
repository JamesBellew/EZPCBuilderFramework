using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Storage
    {
        [Key]
        public int ID { get; set;}

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Speed { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)"), Display(Name="Size")]
        public string Size { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)"), Display(Name="Connection")]
        public string Connection { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }

        [Column(TypeName = "nvarchar(64)"), Display(Name="ImageName")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name="Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
