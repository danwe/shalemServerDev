using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shalemServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Xml.Linq;

[Route("api/[controller]")]
[ApiController]
public class ManaController : ControllerBase
{
    private readonly string _connectionString;
    private readonly ShalemDbDevContext _context;


    public ManaController(IConfiguration configuration, ShalemDbDevContext context)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _context = context;
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

        var departmentList = _context.Departments
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
                   Name  = d.FirstName + " " + d.LastName,
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
        foreach (Mana mana in manaList)
        {
            if (mana != null && mana.DepartmentId != null)
            {
                mana.Department = new Department();
                var matchingDepartment = departmentList.FirstOrDefault(id => id.Id != null && id.Id == mana.DepartmentId);

                if (matchingDepartment != null)
                {
                    mana.Department.Id = matchingDepartment.Id;
                    mana.Department.Name = matchingDepartment.Name;
                }
            }
            if (mana != null && mana.CreatedById != null)
            {
                UsersListShort aspNetUser = usersList.Where(id => (id.Id != null) && (id.Id == mana.CreatedById)).ToList()[0];
                mana.CreatedBy = new AspNetUser();
                mana.CreatedBy.Id = aspNetUser.Id;
                mana.CreatedBy.LastName = aspNetUser.LastName;
                mana.CreatedBy.FirstName = aspNetUser.FirstName;
                mana.CreatedBy.IsActive = aspNetUser.IsActive;

                UsersListShort aspNetUserUpdate = usersList.Where(id => (id.Id != null) && (id.Id == mana.UpdatedById)).ToList()[0];

                mana.UpdatedBy = new AspNetUser();
                mana.UpdatedBy.Id = aspNetUserUpdate.Id;
                mana.UpdatedBy.LastName = aspNetUserUpdate.LastName;
                mana.UpdatedBy.FirstName = aspNetUserUpdate.FirstName;
                mana.UpdatedBy.IsActive = aspNetUserUpdate.IsActive;

            }
        }


        return Ok(new
        {
            TotalItems = totalRecords,
            PageNumber = pageNumber,
            PageSize = pageSize,
            Items = manaList
        });
    }
}