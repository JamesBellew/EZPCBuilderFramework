using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZPCBuilder.Data;
using EZPCBuilder.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EZPCBuilder.Controllers
{
    public class MemoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MemoriesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Memories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Memory.ToListAsync());
        }

        // GET: Memories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memory = await _context.Memory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (memory == null)
            {
                return NotFound();
            }

            return View(memory);
        }

        // GET: Memories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ModelNum,Size,Speed,Type,Latency,Price,Stock,ImageFile")] Memory model)
        {
            if (ModelState.IsValid)
            {

                // Save Image to wwwroot/images/cases folder
                string wwwRootPath = _hostEnvironment.WebRootPath;
                // Getting the name of the file
                string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                // Get extension of the image
                string extension = Path.GetExtension(model.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("ddmmyy") + extension;
                model.ImageName = filename;
                string path = Path.Combine(wwwRootPath + "/Images/Memory/", filename);
                using (var FileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(FileStream);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Memories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memory = await _context.Memory.FindAsync(id);
            if (memory == null)
            {
                return NotFound();
            }
            return View(memory);
        }

        // POST: Memories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ModelNum,Size,Speed,Type,Latency,Price,Stock,ImageName")] Memory memory)
        {
            if (id != memory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoryExists(memory.ID))
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
            return View(memory);
        }

        // GET: Memories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memory = await _context.Memory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (memory == null)
            {
                return NotFound();
            }

            return View(memory);
        }

        // POST: Memories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memory = await _context.Memory.FindAsync(id);
            _context.Memory.Remove(memory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemoryExists(int id)
        {
            return _context.Memory.Any(e => e.ID == id);
        }
    }
}
