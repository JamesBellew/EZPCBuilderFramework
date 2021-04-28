using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZPCBuilder.Models
{
    public class Graphics
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string VRAM { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string BaseSpeed { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string BoostSpeed { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

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
