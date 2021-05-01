using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String address { get; set; }
    }
}
