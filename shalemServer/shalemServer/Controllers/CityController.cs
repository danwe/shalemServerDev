using Microsoft.AspNetCore.Mvc;
using shalemServer.Models.custom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly string _connectionString;

    public CitiesController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // GET: api/cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<City>>> GetCities()
    {
        var cities = new List<City>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // SQL command to select top 1000 records from the City table
            using (var command = new SqlCommand("SELECT TOP (1000) [name], [id], [active] FROM [ShalemDbDev].[dbo].[City]", connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var city = new City
                    {
                        Name = reader["name"].ToString(),
                        Id = (int)reader["id"],
                        Active = (bool)reader["active"]
                    };
                    cities.Add(city);
                }
            }
        }

        return Ok(cities);
    }
}