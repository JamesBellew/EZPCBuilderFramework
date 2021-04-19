using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Case
    {
        [Key]
        private int case_id;

        [Column(TypeName = "nvarchar(64)")]
        private String case_name { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int case_form_factor { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private String case_dimensions { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private double case_price { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int case_stock { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        private int case_img { get; set; }

        // Add field to store images
    }
}
