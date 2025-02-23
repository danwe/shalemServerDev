using shalemServer.Controllers;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Models.custom;
using shalemServer.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace shalemServer.Repository
{


    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _httpContextAccessor = httpContextAccessor;
        }

        public bool ChangePassword(PasswordChangeRequest passwordChange)
        {
            throw new NotImplementedException();
        }

        public List<UserRoleDto> GetRoles(string userId)
        {
            List<UserRoleDto> usersRole = new List<UserRoleDto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT dbo.AspNetRoles.Name, 
                           dbo.AspNetUserRoles.UserId, 
                           dbo.AspNetUserRoles.RoleId
                    FROM dbo.AspNetRoles
                    INNER JOIN dbo.AspNetUserRoles 
                        ON dbo.AspNetRoles.Id = dbo.AspNetUserRoles.RoleId
                    WHERE dbo.AspNetUserRoles.UserId = @UserId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId); // Parameterize the query
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usersRole.Add(new UserRoleDto
                            {

                                RoleName = reader.GetString(0),  // The 'Name' column from AspNetRoles
                                UserId = reader.GetString(1),    // The 'UserId' column from AspNetUserRoles
                                RoleId = reader.GetString(2)     // The 'RoleId' column from AspNetUserRoles
                                //,
                                //Pass = reader.IsDBNull(18) ? null : reader.GetString(18),
                            });
                        }
                    }
                }
            }
            return usersRole;

        }

        public List<PositionDto> GetPosition(string userId, int? cityId = null)
        {
            var roles = new List<PositionDto>();

            string query = @"
                SELECT r.roleId, r.nameRole
                FROM UserRoles ur
                INNER JOIN Role r ON ur.RoleId = r.roleId
                WHERE ur.UserId = @UserId AND r.active = 1";

            if (cityId.HasValue)
            {
                query += " AND r.cityId = @CityId";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                if (cityId.HasValue)
                {
                    command.Parameters.AddWithValue("@CityId", cityId.Value);
                }

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var role = new PositionDto
                        {
                            RoleId = (int)reader["roleId"],
                            RoleName = reader["nameRole"].ToString(),
                        };
                        roles.Add(role);
                    }
                }
            }

            return roles;
        }

        public async Task<IEnumerable<AspNetUserDto>> GetTopUsersAsync(
         string userName = null,
         string email = null,
         bool? isActive = null,
         bool? emailConfirmed = null,
         bool? phoneNumberConfirmed = null,
         bool? twoFactorEnabled = null,
         DateTime? dateCreatedFrom = null,
         DateTime? dateCreatedTo = null)
            {
            var users = new List<AspNetUserDto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PhoneNumber,
                       PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount,
                       FirstName, LastName, IsActive, DateCreated, DateUpdated, PasswordHash, Password, DateUpdatedPassword
                FROM AspNetUsers";

                using (var command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            users.Add(new AspNetUserDto
                            {
                                Id = reader.GetString(0),
                                UserName = reader.GetString(1),
                                NormalizedUserName = reader.GetString(2),
                                Email = reader.GetString(3),
                                NormalizedEmail = reader.GetString(4),
                                EmailConfirmed = reader.GetBoolean(5),
                                PhoneNumber = reader.IsDBNull(6) ? null : reader.GetString(6),
                                PhoneNumberConfirmed = reader.GetBoolean(7),
                                TwoFactorEnabled = reader.GetBoolean(8),
                                LockoutEnd = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9),
                                LockoutEnabled = reader.GetBoolean(10),
                                AccessFailedCount = reader.GetInt32(11),
                                FirstName = reader.IsDBNull(12) ? null : reader.GetString(12),
                                LastName = reader.IsDBNull(13) ? null : reader.GetString(13),
                                IsActive = reader.GetBoolean(14),
                                DateCreated = reader.GetDateTime(15),
                                DateUpdated = reader.GetDateTime(16),
                                PasswordHash = reader.IsDBNull(17) ? null : reader.GetString(17),
                                Password = reader.IsDBNull(18) ? "" : reader.GetString(18),
                                DateUpdatedPassword = reader.IsDBNull(19) ? (DateTime?)null : reader.GetDateTime(19)

                                //,
                                //Pass = reader.IsDBNull(18) ? null : reader.GetString(18),
                            });
                        }
                    }
                }
            }

            return users;
        }
        public bool UpdatePassword(string userId, string newPassword)
        {
            // Ensure the input is valid
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentException("User ID and new password cannot be null or empty.");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL query to update the password
                string query = @"
                    UPDATE AspNetUsers
                    SET Password = @Password, DateUpdatedPassword = GETDATE()
                    WHERE Id = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    // Hash the password (ensure you have a hashing mechanism, e.g., BCrypt or other)
                  

                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.OpenAsync();

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public List<UserCityDto> GetUserCities(string userId)
        {
            List<UserCityDto> userCityDtoList = new List<UserCityDto>();

            var query = @"
        SELECT 
            uc.UserId, 
            uc.CityId, 
            c.Name AS CityName
        FROM 
            UserCity uc
        JOIN 
            City c ON uc.CityId = c.Id
        WHERE 
            uc.UserId = @UserId   
        ORDER BY 
            uc.UserId";  // Optional ordering by UserId

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);  // Add UserId as parameter

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userCity = new UserCityDto
                        {
                            UserId = reader["UserId"].ToString(),  // Correct field mapping for UserId
                            CityId = (int)reader["CityId"],        // Correct field mapping for CityId
                            CityName = reader["CityName"].ToString() // Correct field mapping for CityName
                        };
                        userCityDtoList.Add(userCity);
                    }
                }
            }

            return userCityDtoList;
        }
    }
    

}

