﻿using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CloudComputingAPI.Repositories
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("BestMoviesDB");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
