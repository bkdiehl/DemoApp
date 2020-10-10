using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Web.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            var customers = new[]
            {
                new Customer
                {
                    FirstName = "Wolfgang",
                    LastName = "Ofner",
                    Birthday = new DateTime(1989, 11, 23),
                    Age = 30
                },
                new Customer
                {
                    FirstName = "Darth",
                    LastName = "Vader",
                    Birthday = new DateTime(1977, 05, 25),
                    Age = 42
                },
                new Customer
                {
                    FirstName = "Son",
                    LastName = "Goku",
                    Birthday = new DateTime(737, 04, 16),
                    Age = 1282,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Name = "Toothpaste"
                        },
                        new OrderItem
                        {
                            Name = "Toothbrush"
                        },
                        new OrderItem
                        {
                            Name = "Floss"
                        }
                    }
                }
            };

            Customers.AddRange(customers);
            SaveChanges();
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            builder.Entity<Customer>(entity =>
            {

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(x => x.Customer).WithMany(x => x.OrderItems);
            });
        }

    }
}
