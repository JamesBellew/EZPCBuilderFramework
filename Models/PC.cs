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
        public String pc_name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public String pc_desc { get; set; }

        [Key]
        [ForeignKey("Processor")]
        public int ProcessorID { get; set; }

        [Key]
        [ForeignKey("Graphics")]
        public int GraphicsID { get; set; }

        [Key]
        [ForeignKey("Case")]
        public int CaseID { get; set; }

        [Key]
        [ForeignKey("Memory")]
        public int MemoryID { get; set; }

        [Key]
        [ForeignKey("Storage")]
        public int StorageID { get; set; }
        public virtual Processor Processor { get; set; }
        public virtual Graphics Graphics { get; set; }
        public virtual Case Case { get; set; }
        public virtual Memory Memory { get; set; }
        public virtual Storage Storage { get; set; }


    }
}
