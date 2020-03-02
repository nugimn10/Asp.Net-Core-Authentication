
using System;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_core_auth_task.Models
{
    public class TokoKokoContext : DbContext
    {
        public TokoKokoContext(DbContextOptions<TokoKokoContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}