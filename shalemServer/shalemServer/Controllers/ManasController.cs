using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shalemServer.Models;

namespace shalemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManasController : ControllerBase
    {
        private readonly ShalemDbDevContext _context;

        public ManasController(ShalemDbDevContext context)
        {
            _context = context;
        }

        // GET: api/Manas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManaDto>>> GetManasSkin(string? filter = null)
        {
            if (_context.Manas == null)
            {
                return NotFound();
            }

            IQueryable<Mana> query = _context.Manas;

            // Apply filtering if necessary
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(m => m.Name.Contains(filter));
            }

            var manas = await query
                .Select(m => new ManaDto
                {
                    Id = m.Id,
                    ManaNumber = m.ManaNumber,
                    Name = m.Name,
                    IsDeleted = m.IsDeleted,
                    PropCount = m.PropCount,
                    Status = m.Status
                })
                .ToListAsync();

            return Ok(manas);
        }

        [HttpGet("GetManas")]
        public async Task<ActionResult<IEnumerable<ManaDto>>> GetManas(int pageNumber = 1, int pageSize = 10, string? filter = null)
        {
            if (_context.Manas == null)
            {
                return NotFound();
            }

            IQueryable<Mana> query = _context.Manas;

            // Apply filtering if necessary
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(m => m.Name.Contains(filter));
            }

            // Apply pagination
            var totalItems = await query.CountAsync();
            var manas = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new ManaDto
                {
                    Id = m.Id,
                    ManaNumber = m.ManaNumber,
                    Name = m.Name,
                    IsDeleted = m.IsDeleted,
                    PropCount = m.PropCount,
                    Status = m.Status
                })
                .ToListAsync();

            // Optionally return a paged response
            var response = new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = manas
            };

            return Ok(response);
        }
        // GET: api/Manas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mana>> GetMana(int id)
        {
          if (_context.Manas == null)
          {
              return NotFound();
          }
            var mana = await _context.Manas.FindAsync(id);

            if (mana == null)
            {
                return NotFound();
            }

            return mana;
        }

        // PUT: api/Manas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMana(int id, Mana mana)
        {
            if (id != mana.Id)
            {
                return BadRequest();
            }

            _context.Entry(mana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManaExists(id))
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

        // POST: api/Manas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mana>> PostMana(Mana mana)
        {
          if (_context.Manas == null)
          {
              return Problem("Entity set 'ShalemDbDevContext.Manas'  is null.");
          }
            _context.Manas.Add(mana);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMana", new { id = mana.Id }, mana);
        }

        // DELETE: api/Manas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMana(int id)
        {
            if (_context.Manas == null)
            {
                return NotFound();
            }
            var mana = await _context.Manas.FindAsync(id);
            if (mana == null)
            {
                return NotFound();
            }

            _context.Manas.Remove(mana);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManaExists(int id)
        {
            return (_context.Manas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
