using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shalemServer.Models;
using shalemServer.Models.Dto;

namespace shalemServer.Controllers
{
    [ApiController]
    [Route("api/oldProperty")]
    public class OldPropertyController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly ShalemDbDevContext _context;
        public OldPropertyController(ShalemDbDevContext context)
        {
            _context = context;
        }

        [HttpGet("listOldProperty")] 
        public async Task<ActionResult<IEnumerable<OldPropertyDto>>> GetOldProperties(int manaId, int pageNumber = 1,
        int pageSize = 10,
        string? filter = null,
        string? sortColumn = "Id",
        string? sortDirection = "asc")
        {
            var query = _context.PropertyOlds.AsQueryable();

            // Sorting
           
                query = query.Where(p => p.ManaId == manaId);
            

            // Pagination
            var totalItems = query.Count();
            var items =  query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new OldPropertyDto
                {
                    Id = p.Id,
                    ManaName = p.ManaName,
                    ManaId = p.ManaId,
                    SiteId = p.SiteId,
                    Department = p.Department,
                    Mana = p.Mana

                })
                .ToList();

            return Ok(new 
            {
                Items = items,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            });
        }
    }
}
