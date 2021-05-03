using EZPCBuilder.Data;
using EZPCBuilder.Models;
using EZPCBuilder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly UserManager<IdentityUser> _userManager;
        private OrderService _orderService;
        private BasketService _basketService;

        public OrdersController(IMongoClient client, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            var database = client.GetDatabase("ezpcbuilderdotnet");
            _orderCollection = database.GetCollection<Order>("orders");
            _userManager = userManager;
            _context = context;
        }

        // GET: OrdersController

        public ActionResult Index()
        {
            string user = _userManager.GetUserId(HttpContext.User);
            List<Order> orders = _orderCollection.Find(s => s.UserID == user).ToList();
            return View(orders);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            Order order = _orderCollection.Find(o => o.ID == oid).FirstOrDefault();
            return View(order);
        }

        // POST: OrdersController/Create
    
        public async Task<ActionResult> Create()
        {
            try
            {
                decimal orderTotal = 0;
                List<PC> basketItems = new List<PC>();
                string user = _userManager.GetUserId(HttpContext.User);

                var basket = _context.Basket
                    .Include(b => b.PC)
                    .Include(b => b.User)
                    .AsEnumerable().Where(b => b.UserID == user);

                foreach (Basket b in basket)
                {
                    var pc = _context.PC
                    .Include(p => p.Case)
                    .Include(p => p.Graphics)
                    .Include(p => p.Memory)
                    .Include(p => p.Processor)
                    .Include(p => p.Storage)
                    .FirstOrDefaultAsync(m => m.ID == b.PCID);
                    PC pC = await pc;
                    pC.Quantity = b.Quantity;
                    basketItems.Add(pC);

                    orderTotal += pC.Price;
                }

                Order order = new Order();
                order.ItemsOrdered = basketItems;
                order.UserID = user;
                order.OrderDate = DateTime.Now;
                order.TotalCost = (double)orderTotal;

                // Insert created order
                _orderCollection.InsertOne(order);

                // Delete users basket after creating the order
                _basketService.DeleteBasket(basket);

                // Redirect to show all orders
               return RedirectToAction(nameof(Index));
            } catch
            {
               return RedirectToAction(nameof(Index));
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Checkout()
        {
            decimal orderTotal = 0;
            List<PC> basketItems = new List<PC>();
            string user = _userManager.GetUserId(HttpContext.User);

            var basket = _context.Basket
                .Include(b => b.PC)
                .Include(b => b.User)
                .AsEnumerable().Where(b => b.UserID == user);

            foreach (Basket b in basket)
            {
                var pc = _context.PC
                .Include(p => p.Case)
                .Include(p => p.Graphics)
                .Include(p => p.Memory)
                .Include(p => p.Processor)
                .Include(p => p.Storage)
                .FirstOrDefaultAsync(m => m.ID == b.PCID);
                PC pC = await pc;
                pC.Quantity = b.Quantity;
                basketItems.Add(pC);

                orderTotal += pC.Price;
            }

            Order order = new Order();
            order.ItemsOrdered = basketItems;
            order.UserID = user;
            order.OrderDate = DateTime.Now;
            order.TotalCost = (double)orderTotal;

            return View(order);
        }

        public IActionResult Payment()
        {
            return View();
        }
    }
}
