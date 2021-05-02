using EZPCBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class BasketRepo
    {
        private readonly ApplicationDbContext _DbContext;

        public BasketRepo(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

    }
}
