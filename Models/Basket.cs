using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Basket
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }

        public int PCID { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual ICollection<PC> PCs { get; set; }
    }
}
