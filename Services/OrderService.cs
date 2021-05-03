using EZPCBuilder.Data;
using EZPCBuilder.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderService(ApplicationDbContext context, IMongoCollection<Order> orderCollection)
        {
            _context = context;
            _orderCollection = orderCollection;
        }

        public OrderService()
        {
        }


        // GET: PC from basket
        private PC GetPCDetails(Basket basket)
        {
                var pc = _context.PC
                .Include(p => p.Case)
                .Include(p => p.Graphics)
                .Include(p => p.Memory)
                .Include(p => p.Processor)
                .Include(p => p.Storage)
                .FirstOrDefault(m => m.ID == basket.PCID);
                PC PC = pc;
                PC.Quantity = basket.Quantity;

            return PC;
        }

        // CREATE: Order object
        public static Order CreateOrder(IEnumerable<Basket> basket, string user)
        {
            OrderService os = new OrderService();
            decimal orderTotal = 0;
            List<PC> basketItems = new List<PC>();

            foreach (Basket b in basket)
            {
                PC pc = os.GetPCDetails(b);
                basketItems.Add(pc);

                orderTotal += pc.Price * pc.Quantity;
            }

            Order order = new Order();
            order.ItemsOrdered = basketItems;
            order.UserID = user;
            order.OrderDate = DateTime.Now;
            order.TotalCost = (double)orderTotal;

            return order;
        }
    }
}
