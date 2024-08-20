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
    public class PropertiesController : ControllerBase
    {
        private readonly ShalemDbDevContext _context;

        public PropertiesController(ShalemDbDevContext context)
        {
            _context = context;
        }

        [HttpGet("GetPropertyList")]
        public async Task<ActionResult<Property>> GetPropertyList()
        {
            var departmentList = _context.Departments
                .Select(d => new ListSkinny
                {
                    Name = d.Name,
                    Id = d.Id
                })
                .ToList();
            var propertyStatusesList = _context.PropertyStatuses
               .Select(d => new ListSkinny
               {
                   Name = d.Name,
                   Id = d.Id
               })
               .ToList();

            var propertyTypesList = _context.PropertyTypes
            .Select(d => new ListSkinny
            {
                Name = d.Name,
                Id = d.Id
            })
            .ToList();
            var usersList = _context.AspNetUsers
                 .Select(d => new UsersListShort
                 {
                     Id = d.Id,
                     UserName = d.UserName,
                     NormalizedUserName = d.NormalizedUserName,
                     Email = d.Email,
                     NormalizedEmail = d.NormalizedEmail,
                     PhoneNumber = d.PhoneNumber,
                     PhoneNumberConfirmed = d.PhoneNumberConfirmed,
                     LockoutEnd = d.LockoutEnd,
                     LockoutEnabled = d.LockoutEnabled,
                     FirstName = d.FirstName,
                     LastName = d.LastName,
                     IsActive = d.IsActive
                 })
                 .ToList();

            var combinedData = new
            {
                DepartmentList = departmentList,
                PropertyStatusesList = propertyStatusesList,
                PropertyTypesList = propertyTypesList,
                usersList = usersList
            };

            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Data retrieved successfully",
                Data = combinedData

            };

            return Ok(response);
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
          if (_context.Properties == null)
          {
              return NotFound();
          }
            return await _context.Properties.ToListAsync();
        }
        [HttpPut("UpdateProperty")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _context.Entry(property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        [HttpPost("CreateProperty")]
        public async Task<ActionResult<Property>> CreateProperty(Property property)
        {
            if (_context.Properties == null)
            {
                return Problem("Entity set 'YourDbContext.Properties'  is null.");
            }

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            // Return the created property, with a 201 status code and a route to the created entity
            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }
        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
          if (_context.Properties == null)
          {
              return NotFound();
          }
            var @property = await _context.Properties.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }
        [HttpGet("listProperties")]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties(
            int pageNumber = 1,
            int pageSize = 10,
            string? sortColumn = "Id",
            string? sortDirection = "asc",
            string? filterPropertySite = null,
            string? filterNeighborhood = null)
            {
            if (_context.Properties == null)
            {
                return NotFound();
            }

            // Build the query
            var query = _context.Properties.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(filterPropertySite))
            {
                query = query.Where(p => p.PropertySite.Contains(filterPropertySite));
            }
            if (!string.IsNullOrEmpty(filterNeighborhood))
            {
                query = query.Where(p => p.Neighborhood.Contains(filterNeighborhood));
            }

            // Apply sorting
            query = sortDirection?.ToLower() == "desc"
                ? query.OrderByDescending(p => EF.Property<object>(p, sortColumn ?? "Id"))
                : query.OrderBy(p => EF.Property<object>(p, sortColumn ?? "Id"));

            // Apply pagination
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paginated result
            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = items
            });
        }


        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, Property @property)
        {
            if (id != @property.Id)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
          if (_context.Properties == null)
          {
              return Problem("Entity set 'ShalemDbDevContext.Properties'  is null.");
          }
            _context.Properties.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = @property.Id }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(int id)
        {
            return (_context.Properties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
