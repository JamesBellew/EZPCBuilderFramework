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
    public class Graphics
    {
        [Key]
        private int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private string Brand { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private int VRAM { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private int BaseSpeed { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private int BoostSpeed { get; set; }

        [Required]
        [Column(TypeName = "money")]
        private decimal Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private int Stock { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        private string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


    }
}
