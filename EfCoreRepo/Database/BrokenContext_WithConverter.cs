using System;
using System.Linq;
using EfCoreRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreRepo.Database
{
    public class BrokenContext_WithConverter : DbContext
    {
        
        public DbSet<BrokenModel> PeopleC { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrokenModel>()
                .Property(m => m.FavouriteColours)
                .HasConversion(before => before.Cast<int>().ToList(),
                    after => after.Cast<Colours>().ToList());
            base.OnModelCreating(modelBuilder);
        }

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