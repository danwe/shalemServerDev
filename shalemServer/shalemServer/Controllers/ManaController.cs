using Microsoft.AspNetCore.Mvc;
using shalemServer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ManaController : ControllerBase
{
    private readonly string _connectionString;

    public ManaController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    // GET: api/mana
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mana>>> GetMana(
        int pageNumber = 1,
        int pageSize = 10,
        string? filter = null)
    {
        var manaList = new List<Mana>();
        var totalRecords = 0;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // Get total count of records
            using (var countCommand = new SqlCommand("SELECT COUNT(*) FROM [ShalemDbDev].[dbo].[Mana]" +
                (string.IsNullOrEmpty(filter) ? "" : " WHERE Name LIKE @Filter"), connection))
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    countCommand.Parameters.AddWithValue("@Filter", "%" + filter + "%");
                }

                totalRecords = (int)await countCommand.ExecuteScalarAsync();
            }

            // Fetch paginated and filtered records
            using (var command = new SqlCommand(
                "SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY Id) AS RowNum FROM [ShalemDbDev].[dbo].[Mana]" +
                (string.IsNullOrEmpty(filter) ? "" : " WHERE Name LIKE @Filter") +
                ") AS RowConstrainedResult " +
                "WHERE RowNum >= @StartRow AND RowNum < @EndRow ORDER BY RowNum", connection))
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    command.Parameters.AddWithValue("@Filter", "%" + filter + "%");
                }

                command.Parameters.AddWithValue("@StartRow", (pageNumber - 1) * pageSize + 1);
                command.Parameters.AddWithValue("@EndRow", pageNumber * pageSize + 1);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var mana = new Mana
                        {
                            Id = (int)reader["Id"],
                            UpdatedById = reader["UpdatedById"].ToString(),
                            CreatedById = reader["CreatedById"].ToString(),
                            DateCreated = reader["DateCreated"] as DateTime?,
                            DateUpdated = reader["DateUpdated"] as DateTime?,
                            ManaNumber = (int)reader["ManaNumber"],
                            DepartmentId = (int)reader["DepartmentId"],
                            Name = reader["Name"].ToString(),
                            IsDeleted = reader["IsDeleted"] as bool?,
                            PropCount = (int)reader["PropCount"],
                            Status = reader["Status"].ToString()
                        };
                        manaList.Add(mana);
                    }
                }
            }
        }

        return Ok(new
        {
            TotalRecords = totalRecords,
            PageSize = pageSize,
            PageNumber = pageNumber,
            Mana = manaList
        });
    }
}