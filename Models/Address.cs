using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Address
    {
        [Key]
        private int address_id { get; set; }

        [ForeignKey("user_id")]
        private int user_id { get; set; }


        [Column(TypeName ="nvarchar(64)")]
        private String street_line_1 { get; set; }


        [Column(TypeName = "nvarchar(64)")]
        private String street_line_2 { get; set; }


        [Column(TypeName = "nvarchar(64)")]
        private String city { get; set; }


        [Column(TypeName = "nvarchar(64)")]
        private String county { get; set; }


        [Column(TypeName = "nvarchar(64)")]
        private String country { get; set; }


        [Column(TypeName = "nvarchar(64)")]
        private String post_code { get; set; }
    }
}
