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
    public class GraphicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GraphicsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Graphics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Graphics.ToListAsync());
        }

        // GET: Graphics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphics = await _context.Graphics
                .FirstOrDefaultAsync(m => m.ID == id);
            if (graphics == null)
            {
                return NotFound();
            }

            return View(graphics);
        }

        // GET: Graphics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Graphics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Brand,VRAM,BaseSpeed,BoostSpeed,Price,Stock,ImageFile")] Graphics graphics)
        {
            if (ModelState.IsValid)
            {
                // Save Image to wwwroot/images/cases folder
                string wwwRootPath = _hostEnvironment.WebRootPath;
                // Getting the name of the file
                string filename = Path.GetFileNameWithoutExtension(graphics.ImageFile.FileName);
                // Get extension of the image
                string extension = Path.GetExtension(graphics.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("ddmmyy") + extension;
                graphics.ImageName = filename;
                string path = Path.Combine(wwwRootPath + "/Images/Graphics/", filename);
                using (var FileStream = new FileStream(path, FileMode.Create))
                {
                    await graphics.ImageFile.CopyToAsync(FileStream);
                }


                _context.Add(graphics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(graphics);
        }

        // GET: Graphics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphics = await _context.Graphics.FindAsync(id);
            if (graphics == null)
            {
                return NotFound();
            }
            return View(graphics);
        }

        // POST: Graphics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Brand,VRAM,BaseSpeed,BoostSpeed,Price,Stock,ImageName")] Graphics graphics)
        {
            if (id != graphics.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graphics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraphicsExists(graphics.ID))
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
            return View(graphics);
        }

        // GET: Graphics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphics = await _context.Graphics
                .FirstOrDefaultAsync(m => m.ID == id);
            if (graphics == null)
            {
                return NotFound();
            }

            return View(graphics);
        }

        // POST: Graphics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graphics = await _context.Graphics.FindAsync(id);
            _context.Graphics.Remove(graphics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraphicsExists(int id)
        {
            return _context.Graphics.Any(e => e.ID == id);
        }
    }
}
