using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Motherboard
    {
        [Key]
        private int mobo_id { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private String mobo_name { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private String mobo_chipset { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private String mobo_socket { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int mobo_max_memory { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private String mobo_memory_type { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int mobo_form_factor { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private double mobo_price { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int mobo_stock { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int mobo_img { get; set; }


    }
}
