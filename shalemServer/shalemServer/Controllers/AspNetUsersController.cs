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
    public class AspNetUsersController : ControllerBase
    {
        private readonly ShalemDbDevContext _context;

        public AspNetUsersController(ShalemDbDevContext context)
        {
            _context = context;
        }

        // GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers(
      string? search = null,            // Filter by search term (optional)
      string? sortBy = "FirstName",      // Column to sort by (default: FirstName)
      string? sortDirection = "asc",     // Sort direction: asc or desc (default: asc)
      int pageNumber = 1,                      // Page number (default: 1)
      int pageSize = 10)                 // Page size (default: 10)
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }

            // Base query
            var usersQuery = _context.AspNetUsers.AsQueryable();

            // Filtering by search term (e.g., searching by first name or last name)
            if (!string.IsNullOrEmpty(search))
            {
                usersQuery = usersQuery.Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search));
            }

            // Sorting
            switch (sortBy?.ToLower())
            {
                //case "firstname":
                //    usersQuery = sortDirection.ToLower() == "desc"
                //        ? usersQuery.OrderByDescending(u => u.FirstName)
                //        : usersQuery.OrderBy(u => u.FirstName);
                //    break;
                //case "lastname":
                //    usersQuery = sortDirection.ToLower() == "desc"
                //        ? usersQuery.OrderByDescending(u => u.LastName)
                //        : usersQuery.OrderBy(u => u.LastName);
                //    break;
                //case "email":
                //    usersQuery = sortDirection.ToLower() == "desc"
                //        ? usersQuery.OrderByDescending(u => u.Email)
                //        : usersQuery.OrderBy(u => u.Email);
                //    break;
                //default:
                //    usersQuery = sortDirection.ToLower() == "desc"
                //        ? usersQuery.OrderByDescending(u => u.FirstName)
                //        : usersQuery.OrderBy(u => u.FirstName);
                //    break;
            }

            // Pagination
            var totalItems = await usersQuery.CountAsync();
            var users = await usersQuery
                .Skip((pageNumber) * pageSize)   // Skip the previous pages
                .Take(pageSize)                // Take the current page's data
                .ToListAsync();

            // Return paginated response
            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = users
            });
        }
        // GET: api/AspNetUsers/5
        [HttpGet("{id}")] 



        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
          if (_context.AspNetUsers == null)
          {
              return NotFound();
          }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return aspNetUser;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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

        // POST: api/AspNetUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(AspNetUser aspNetUser)
        {
          if (_context.AspNetUsers == null)
          {
              return Problem("Entity set 'ShalemDbDevContext.AspNetUsers'  is null.");
          }
            _context.AspNetUsers.Add(aspNetUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspNetUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUser", new { id = aspNetUser.Id }, aspNetUser);
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUser(string id)
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserExists(string id)
        {
            return (_context.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
