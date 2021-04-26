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
        private int ID;

        [Column(TypeName = "nvarchar(64)")]
        private String Name { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int FormFactor { get; set; }

        [Column(TypeName = "money")]
        private double Price { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int Stock { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
