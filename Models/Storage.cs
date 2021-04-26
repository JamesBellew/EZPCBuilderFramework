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

        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        public int Speed { get; set; }

        [Column(TypeName ="int"), Display(Name="Size")]
        public string Size { get; set; }

        [Column(TypeName = "nvarchar"), Display(Name="Connection")]
        public string Connection { get; set; }

        [Column(TypeName = "nvarchar"), Display(Name="ImageName")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name="Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
