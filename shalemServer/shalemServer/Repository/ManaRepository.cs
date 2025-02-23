using shalemServer.Interfaces;
using shalemServer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class ManaRepository : IManaRepository
{
    private readonly string _connectionString;

    public ManaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<ListSkinny>> GetAllManaAsync()
    {
        var manaList = new List<ListSkinny>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand("SELECT Id, Name FROM [ShalemDbDev].[dbo].[Mana]", connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var mana = new ListSkinny
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString()
                    };

                    manaList.Add(mana);

                }
            }
        }

        return manaList;
    }
}
