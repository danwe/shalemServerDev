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
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                //TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                Items = events
            };
     
            return Ok(response);
        }
        [HttpGet("GetEventsTable")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Event>))]

        public IActionResult GetEventsTable(string? modedID, string? filterType)
        {
            IQueryable<Event> events = _context.Events
                .Include(e => e.CreatedBy)
                .Include(e => e.EventType)
                .Include(e => e.Property).ThenInclude(o => o.PropertyType)
                .Include(e => e.UserEvent)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(modedID))
            {
                events = events.Where(o => o.UserEventId != null && o.UserEventId == modedID);
            }

            // Apply filter based on filterType
            var now = DateTime.UtcNow;
            var startOfWeek = now.Date.AddDays(-(int)now.DayOfWeek + 1);
            var endOfWeek = startOfWeek.AddDays(6);
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            switch (filterType?.ToLower())
            {
                case "day":
                    events = events.Where(e => e.DateStart.Date == now.Date);
                    break;
                case "week":
                    events = events.Where(e => e.DateStart.Date >= startOfWeek && e.DateStart.Date <= endOfWeek);
                    break;
                case "month":
                    events = events.Where(e => e.DateStart.Date >= startOfMonth && e.DateStart.Date <= endOfMonth);
                    break;
            }

            // Now project to the desired shape
            var result = events.Select(d => new Event
            {
                Id = d.Id,
                CreatedById = d.CreatedById,
                UpdatedById = d.UpdatedById,
                DateCreated = d.DateCreated,
                DateUpdated = d.DateUpdated,
                PropertyId = d.PropertyId,
                UserEventId = d.UserEventId,
                EventTypeId = d.EventTypeId,
                Description = d.Description,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                Title = d.Title,
                HokerId = d.HokerId,

            }).ToList();

            return Ok(result);
        }

    }

}

