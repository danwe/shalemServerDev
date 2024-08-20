using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shalemServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shalemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertySokerController : ControllerBase
    {
        private readonly ShalemDbDevContext _context;

        // GET: api/<PropertySokerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public PropertySokerController(ShalemDbDevContext context)
        {
            _context = context;
        }
        // GET api/<PropertySokerController>/5
        [HttpPost("GetPropertySoker")]
        public async Task<ActionResult<IEnumerable<PropertySoker>>> GetPropertySoker(int? id = 0)
        {
            if (_context.PropertySokers == null)
            {
                return NotFound();
            }

            IQueryable<PropertySoker> query = _context.PropertySokers;


            // Apply filtering if necessary
            if (id > 0)
            {
                query = query.Where(s => s.PropertyId == id);
            }

            var soker = await query.ToListAsync();
            
            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Data retrieved successfully",
                Data = soker

            };

            return Ok(response);
        }

        // POST api/<PropertySokerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PropertySokerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertySokerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
