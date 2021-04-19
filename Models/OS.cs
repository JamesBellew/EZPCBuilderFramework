using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class OS
    {
        [Key]
        private int os_id;

        [Column(TypeName ="nvarchar(64)")]
        private String os_name;

        [Column(TypeName ="nvarchar(64)")]
        private double os_price;


    }
}
