using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EZPCBuilder.Data;
using EZPCBuilder.Models;
using Microsoft.AspNetCore.Authorization;

namespace EZPCBuilder.Controllers
{

   
    [Route("api/[controller]")]
    [ApiController]
   
    public class PCs1APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PCs1APIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        // GET: api/PCs1API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PC>>> GetPC()
        {
            return await _context.PC.ToListAsync();
        }

        [Authorize(Roles = "Administrator")]
        // GET: api/PCs1API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PC>> GetPC(int id)
        {
            var pC = await _context.PC.FindAsync(id);

            if (pC == null)
            {
                return NotFound();
            }

            return pC;
        }

        [Authorize(Roles = "Administrator")]
        // PUT: api/PCs1API/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPC(int id, PC pC)
        {
            if (id != pC.ID)
            {
                return BadRequest();
            }

            _context.Entry(pC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PCs1API
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PC>> PostPC(PC pC)
        {
            _context.PC.Add(pC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPC", new { id = pC.ID }, pC);
        }

        // DELETE: api/PCs1API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PC>> DeletePC(int id)
        {
            var pC = await _context.PC.FindAsync(id);
            if (pC == null)
            {
                return NotFound();
            }

            _context.PC.Remove(pC);
            await _context.SaveChangesAsync();

            return pC;
        }

        private bool PCExists(int id)
        {
            return _context.PC.Any(e => e.ID == id);
        }
    }
}
