using customer.api.Entities;
using customer.api.Repository.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace customer.api.Repository
{
    public sealed class DefaultDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DefaultDbContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
