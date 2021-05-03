using EZPCBuilder.Data;
using EZPCBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Services
{
    public class BasketService
    {
        private readonly ApplicationDbContext _context;

        public BasketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BasketService()
        {
        }

        // Gets the data from 
        [HttpGet]
        public IEnumerable<Basket> GetBasket(string user)
        {
            var basket = _context.Basket
                    .Include(b => b.PC)
                    .Include(b => b.User)
                    .AsEnumerable().Where(b => b.UserID == user);
            IEnumerable<Basket> baskets = basket;

            return baskets;
        }

        // DELETE: Basket
        public void DeleteBasket(IEnumerable<Basket> basket)
        {
            // Emptying Basket
            foreach (Basket b in basket)
            {
                _context.Basket.Remove(b);
            }
             _context.SaveChanges();
        }
    }
}
