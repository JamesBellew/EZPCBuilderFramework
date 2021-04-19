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
        private int memory_id { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String memory_name { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String memory_model_number { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String memory_size { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int memory_speed { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private String memory_type { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private String memory_latency { get; set; }
        
        [Column(TypeName ="nvarchar(64)")]
        private double memory_price { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int memory_stock { get; set; }

        [Column(TypeName ="nvarchar(64)")]
        private int memory_img { get; set; }


    }
}
