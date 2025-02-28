using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shalemServer.Models;

namespace shalemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly ShalemDbDevContext _context;
        public EventsController(ShalemDbDevContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents(string? search = "", int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            var query = _context.Events.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    EF.Functions.Like(e.Title, $"%{search}%") || // Replace 'Title' with actual column names
                    EF.Functions.Like(e.Description, $"%{search}%") ||
                    EF.Functions.Like(e.PropertyId.ToString(), $"%{search}%")
                );
            }

            var totalRecords = await query.CountAsync();

            var events = await query
                .OrderByDescending(e => e.DateCreated)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                Data = events
            };

            return Ok(response);
        }
    }
}

