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

            var manaList = _context.Manas
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
                usersList = usersList,
                manaList = manaList
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
            var usersList = _context.AspNetUsers
               .Select(d => new UsersListShort
               {
                   Id = d.Id,
                   UserName = d.UserName,
                   LastName = d.LastName,
                   FirstName = d.FirstName,
                   IsActive = d.IsActive
                  
               })
               .ToList();
            var manaList = _context.Manas
               .Select(d => new Mana
               {
                   Name = d.Name,
                   Id = d.Id
               })
               .ToList();
            var departmentList = _context.Departments
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
            });
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
            var propertyStatusesList = _context.PropertyStatuses
               .Select(d => new ListSkinny
               {
                   Name = d.Name,
                   Id = d.Id
               })
               .ToList();

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
           
            foreach (Property person in items)
            {
                if (person != null && person.CreatedById != null)
                {
                    UsersListShort aspNetUser = usersList.Where(id => (id.Id != null) && (id.Id == person.CreatedById)).ToList()[0];
                    person.CreatedBy = new AspNetUser();
                    person.CreatedBy.Id = aspNetUser.Id;
                    person.CreatedBy.LastName = aspNetUser.LastName;
                    person.CreatedBy.FirstName = aspNetUser.FirstName;
                    person.CreatedBy.IsActive = aspNetUser.IsActive;

                    UsersListShort aspNetUserUpdate = usersList.Where(id => (id.Id != null) && (id.Id == person.UpdatedById)).ToList()[0];

                    person.UpdatedBy = new AspNetUser();
                    person.UpdatedBy.Id = aspNetUserUpdate.Id;
                    person.UpdatedBy.LastName = aspNetUserUpdate.LastName;
                    person.UpdatedBy.FirstName = aspNetUserUpdate.FirstName;
                    person.UpdatedBy.IsActive = aspNetUserUpdate.IsActive;

                }
                if (person != null && person.ManaId != null)
                {
                    person.Mana = new Mana();
                    var matchingMana = manaList.FirstOrDefault(id => id.Id != null && id.Id == person.ManaId);

                    if (matchingMana != null)
                    {
                        person.Mana = matchingMana;
                    }
                }
                if (person != null && person.DepartmentId != null)
                {
                    person.Department = new Department();
                    var matchingDepartment = departmentList.FirstOrDefault(id => id.Id != null && id.Id == person.DepartmentId);

                    if (matchingDepartment != null)
                    {
                        person.Department.Id = matchingDepartment.Id;
                        person.Department.Name = matchingDepartment.Name;
                    }
                }
                if (person != null && person.PropertyTypeId != null)
                {
                    person.PropertyType = new PropertyType();
                    var matchingpropertyTypet = propertyTypesList.FirstOrDefault(id => id.Id != null && id.Id == person.PropertyTypeId);

                    if (matchingpropertyTypet != null)
                    {
                        person.PropertyType.Id = matchingpropertyTypet.Id;
                        person.PropertyType.Name = matchingpropertyTypet.Name;
                    }
                }

                if (person != null && person.PropertyStatusId != null)
                {
                    person.PropertyStatus = new PropertyStatus();
                    var matchingPropertyStatus = propertyStatusesList.FirstOrDefault(id => id.Id != null && id.Id == person.PropertyStatusId);

                    if (matchingPropertyStatus != null)
                    {
                        person.PropertyStatus.Id = matchingPropertyStatus.Id;
                        person.PropertyStatus.Name = matchingPropertyStatus.Name;
                    }
                }
                if (person != null && person.PropertyTypeId != null)
                {
                    person.Moded = new AspNetUser();
                    var matchingModed = usersList.FirstOrDefault(id => id.Id != null && id.Id == person.ModedId);

                    if (matchingModed != null)
                    {
                        person.Moded.Id = matchingModed.Id;
                        person.Moded.Id = matchingModed.Id;
                        person.Moded.LastName = matchingModed.LastName;
                        person.Moded.FirstName = matchingModed.FirstName;
                        person.Moded.IsActive = matchingModed.IsActive;
                    }
                }

                // You can perform other operations here
            }
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
