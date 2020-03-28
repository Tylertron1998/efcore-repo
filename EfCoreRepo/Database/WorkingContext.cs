using System;
using EfCoreRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreRepo.Database
{
    public class WorkingContext : DbContext
    {
        public DbSet<WorkingModel> People { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var database = Environment.GetEnvironmentVariable("PG_DATABASE");
            var user = Environment.GetEnvironmentVariable("PG_USER");
            var password = Environment.GetEnvironmentVariable("PG_PASSWORD");
            optionsBuilder.UseNpgsql($"host=localhost;database={database};user id={user};password={password};");
            base.OnConfiguring(optionsBuilder);
        }
    }
}