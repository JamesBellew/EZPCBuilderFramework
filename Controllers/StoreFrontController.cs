using EZPCBuilder.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Controllers
{
    public class StoreFrontController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreFrontController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: StoreFrontController
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PC.Include(p => p.Case).Include(p => p.Graphics).Include(p => p.Memory).Include(p => p.Processor).Include(p => p.Storage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StoreFrontController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pC = await _context.PC
                .Include(p => p.Case)
                .Include(p => p.Graphics)
                .Include(p => p.Memory)
                .Include(p => p.Processor)
                .Include(p => p.Storage)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pC == null)
            {
                return NotFound();
            }

            return View(pC);
        }

        // GET: StoreFrontController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreFrontController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: StoreFrontController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreFrontController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: StoreFrontController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreFrontController/Delete/5
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
    }
}
