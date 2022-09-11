using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestApplication.Models;

namespace TestApplication.Data
{
    public class GameDBContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        private readonly IConfiguration _configuration;

        public GameDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(_configuration.GetConnectionString("WebApiDatabase"));
    }
}
