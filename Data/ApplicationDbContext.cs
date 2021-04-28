using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EZPCBuilder.Models;

namespace EZPCBuilder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EZPCBuilder.Models.Case> Case { get; set; }
        public DbSet<EZPCBuilder.Models.Graphics> Graphics { get; set; }
        public DbSet<EZPCBuilder.Models.Memory> Memory { get; set; }
        public DbSet<EZPCBuilder.Models.Processor> Processor { get; set; }
        public DbSet<EZPCBuilder.Models.Storage> Storage { get; set; }
        public DbSet<EZPCBuilder.Models.PC> PC { get; set; }
    }
}
