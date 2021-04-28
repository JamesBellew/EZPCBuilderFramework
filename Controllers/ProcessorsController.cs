using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZPCBuilder.Data;
using EZPCBuilder.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EZPCBuilder.Controllers
{
    public class ProcessorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProcessorsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Processors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Processor.ToListAsync());
        }

        // GET: Processors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor = await _context.Processor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (processor == null)
            {
                return NotFound();
            }

            return View(processor);
        }

        // GET: Processors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Socket,Cores,Threads,BaseSpeed,BoostSpeed,Price,Stock,ImageFile")] Processor model)
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
                string path = Path.Combine(wwwRootPath + "/Images/Processors/", filename);
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

        // GET: Processors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor = await _context.Processor.FindAsync(id);
            if (processor == null)
            {
                return NotFound();
            }
            return View(processor);
        }

        // POST: Processors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Socket,Cores,Threads,BaseSpeed,BoostSpeed,Price,Stock,ImageName")] Processor processor)
        {
            if (id != processor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessorExists(processor.ID))
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
            return View(processor);
        }

        // GET: Processors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor = await _context.Processor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (processor == null)
            {
                return NotFound();
            }

            return View(processor);
        }

        // POST: Processors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processor = await _context.Processor.FindAsync(id);
            _context.Processor.Remove(processor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessorExists(int id)
        {
            return _context.Processor.Any(e => e.ID == id);
        }
    }
}
