﻿using AlkemyUmsa.DataAccess.DatabaseSeeding;
using AlkemyUmsa.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder()
            };

            foreach (var seeder in seeders) {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        

    }
}
