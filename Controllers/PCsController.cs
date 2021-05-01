using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZPCBuilder.Data;
using EZPCBuilder.Models;
using Microsoft.AspNetCore.Authorization;

namespace EZPCBuilder.Controllers
{
    public class PCsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PCsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PCs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PC.Include(p => p.Case).Include(p => p.Graphics).Include(p => p.Memory).Include(p => p.Processor).Include(p => p.Storage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PCs/Details/5
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

        [Authorize(Roles = "Administrator")]
        // GET: PCs/Create
        public IActionResult Create()
        {
            ViewData["CaseID"] = new SelectList(_context.Case, "ID", "Name");
            ViewData["GraphicsID"] = new SelectList(_context.Graphics, "ID", "Name");
            ViewData["MemoryID"] = new SelectList(_context.Memory, "ID", "Name");
            ViewData["ProcessorID"] = new SelectList(_context.Processor, "ID", "Name");
            ViewData["StorageID"] = new SelectList(_context.Storage, "ID", "Name");
            return View();
        }

        // POST: PCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,pc_name,pc_desc,ProcessorID,GraphicsID,CaseID,MemoryID,StorageID")] PC pC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseID"] = new SelectList(_context.Case, "ID", "Name", pC.CaseID);
            ViewData["GraphicsID"] = new SelectList(_context.Graphics, "ID", "Name", pC.GraphicsID);
            ViewData["MemoryID"] = new SelectList(_context.Memory, "ID", "Name", pC.MemoryID);
            ViewData["ProcessorID"] = new SelectList(_context.Processor, "ID", "Name", pC.ProcessorID);
            ViewData["StorageID"] = new SelectList(_context.Storage, "ID", "Name", pC.StorageID);
            return View(pC);
        }

        // GET: PCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pC = await _context.PC.FindAsync(id);
            if (pC == null)
            {
                return NotFound();
            }
            ViewData["CaseID"] = new SelectList(_context.Case, "ID", "ID", pC.CaseID);
            ViewData["GraphicsID"] = new SelectList(_context.Graphics, "ID", "BaseSpeed", pC.GraphicsID);
            ViewData["MemoryID"] = new SelectList(_context.Memory, "ID", "Latency", pC.MemoryID);
            ViewData["ProcessorID"] = new SelectList(_context.Processor, "ID", "BaseSpeed", pC.ProcessorID);
            ViewData["StorageID"] = new SelectList(_context.Storage, "ID", "Connection", pC.StorageID);
            return View(pC);
        }

        // POST: PCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,pc_name,pc_desc,ProcessorID,GraphicsID,CaseID,MemoryID,StorageID")] PC pC)
        {
            if (id != pC.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PCExists(pC.ID))
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
            ViewData["CaseID"] = new SelectList(_context.Case, "ID", "ID", pC.CaseID);
            ViewData["GraphicsID"] = new SelectList(_context.Graphics, "ID", "BaseSpeed", pC.GraphicsID);
            ViewData["MemoryID"] = new SelectList(_context.Memory, "ID", "Latency", pC.MemoryID);
            ViewData["ProcessorID"] = new SelectList(_context.Processor, "ID", "BaseSpeed", pC.ProcessorID);
            ViewData["StorageID"] = new SelectList(_context.Storage, "ID", "Connection", pC.StorageID);
            return View(pC);
        }

        // GET: PCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: PCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pC = await _context.PC.FindAsync(id);
            _context.PC.Remove(pC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PCExists(int id)
        {
            return _context.PC.Any(e => e.ID == id);
        }
    }
}
