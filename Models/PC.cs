using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class PC
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string pc_name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string pc_desc { get; set; }

        
        [ForeignKey("Processor")]
        public int ProcessorID { get; set; }

       
        [ForeignKey("Graphics")]
        public int GraphicsID { get; set; }

       
        [ForeignKey("Case")]
        public int CaseID { get; set; }

       
        [ForeignKey("Memory")]
        public int MemoryID { get; set; }

       
        [ForeignKey("Storage")]
        public int StorageID { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [NotMapped]
        public int Quantity { get; set; }


        public virtual Processor Processor { get; set; }
        public virtual Graphics Graphics { get; set; }
        public virtual Case Case { get; set; }
        public virtual Memory Memory { get; set; }
        public virtual Storage Storage { get; set; }


    }
}
