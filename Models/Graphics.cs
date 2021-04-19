using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Graphics
    {
        [Key]
        private int graphics_id { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String graphics_name { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String graphics_manufacturer { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int graphics_vram { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int graphics_cores { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int graphic_base_speed { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int graphics_boost_speed { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private double graphics_price { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int graphics_stock { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int graphics_img { get; set; }


    }
}
