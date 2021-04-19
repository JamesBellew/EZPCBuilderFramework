using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Hdd
    {
        [Key]
        private int hdd_id { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String hdd_name { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String hdd_type { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String hdd_form_factor { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String hdd_interface { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int hdd_rotation_speed { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private Double hdd_price { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int hdd_stock { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int hdd_img { get; set; }


    }
}
