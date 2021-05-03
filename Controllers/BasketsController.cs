using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZPCBuilder.Data;
using EZPCBuilder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EZPCBuilder.Controllers
{
    // [Authorize(Roles = "User")]
    [Authorize(Roles = "Administrator")]
    public class BasketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BasketsController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Baskets
        public async Task<IActionResult> Index()
        {
            List<PC> basketItems = new List<PC>();
            string user = _userManager.GetUserId(HttpContext.User);

            var basket = _context.Basket
                .Include(b => b.PC)
                .Include(b => b.User)
                .AsEnumerable().Where(b => b.UserID == user);

            foreach(Basket b in basket)
            {
                var pc = _context.PC
                .Include(p => p.Case)
                .Include(p => p.Graphics)
                .Include(p => p.Memory)
                .Include(p => p.Processor)
                .Include(p => p.Storage)
                .FirstOrDefaultAsync(m => m.ID == b.PCID);
                basketItems.Add(await pc);

                PC pC = await pc;
                b.PC = pC;
            }

            return View(basket);
        }

        // GET: Baskets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket
                .Include(b => b.PC)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Baskets/Create
        public IActionResult Create()
        {
            ViewData["PCID"] = new SelectList(_context.PC, "ID", "pc_desc");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,PCID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PCID"] = new SelectList(_context.PC, "ID", "pc_desc", basket.PCID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", basket.UserID);
            return View(basket);
        }

        // GET: Baskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            ViewData["PCID"] = new SelectList(_context.PC, "ID", "pc_desc", basket.PCID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", basket.UserID);
            return View(basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,PCID")] Basket basket)
        {
            if (id != basket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketExists(basket.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PCID"] = new SelectList(_context.PC, "ID", "pc_desc", basket.PCID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", basket.UserID);
            return View(basket);
        }

        // GET: Baskets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket
                .Include(b => b.PC)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basket = await _context.Basket.FindAsync(id);
            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketExists(int id)
        {
            return _context.Basket.Any(e => e.ID == id);
        }

        public IActionResult AddToBasket(int id)
        {
            // Getting the current users Id
            string userId = _userManager.GetUserId(HttpContext.User);

            // Create Basket Model
            Basket basket = new Basket();

            var checkIfExists = _context.Basket.FirstOrDefault(m => m.PCID == id && m.UserID == userId );
            if(checkIfExists == null)
            {
                // Assign Values to Basket Items
                basket.PCID = id;
                basket.UserID = userId;
                basket.Quantity = 1;

                // Add basket to Database
                _context.Basket.Add(basket);
            } else
            {
                // Add one to the quantity in the Basket
                checkIfExists.Quantity += 1;
                _context.Entry(checkIfExists).State = EntityState.Modified;
            }
            
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Checkout()
        {
            
            return View("Summary");
        }
    }
}
