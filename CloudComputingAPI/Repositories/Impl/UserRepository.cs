﻿using CloudComputingAPI.Models;
using Dapper;
using System.Threading.Tasks;

namespace CloudComputingAPI.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _context;

        public UserRepository(DapperDbContext context)
        {
            _context = context;
        }

        public async Task<UserLogin> GetUserLogin(string username)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"SELECT user_id, password
                              FROM [dbo].[user]
                              WHERE username = @username";
                var result = await connection.QuerySingleOrDefaultAsync<UserLogin>(query, new {username = username}).ConfigureAwait(false);
                return result;
            }
        }

        public async Task CreateUser(string username, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[user] (username, password)
                                VALUES (@username, @password)";
                await connection.ExecuteAsync(query, new { username = username, password = password }).ConfigureAwait(false);
            }
        }

        public async Task<string> CheckUsername(string username)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"SELECT user_id 
                                FROM [dbo].[users]
                                WHERE username = @username";
                var result = await connection.QuerySingleOrDefaultAsync<int>(query, new { username = username }).ConfigureAwait(false);
                if (result == null)
                {
                    return "Username available";
                }
                else
                {
                    return "Username already exists";
                }
            }
        }
    }
}
