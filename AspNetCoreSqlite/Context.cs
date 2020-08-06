using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspNetCoreSqlite
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Test Customer 1" },
                new Customer { Id = 2, Name = "Test Customer 2" }
            };

            modelBuilder.Entity<Customer>().HasData(customers);
        }
    }
}