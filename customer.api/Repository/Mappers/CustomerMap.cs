using customer.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace customer.api.Repository.Mappers
{
    public sealed class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(entity => entity.Id).HasColumnName("Id");
            builder.Property(entity => entity.FirstName).HasColumnName("FirstName");
            builder.Property(entity => entity.LastName).HasColumnName("LastName");
            builder.Property(entity => entity.Phone).HasColumnName("Phone");
            builder.Property(entity => entity.LastPurchase).HasColumnName("LastPurchase");
            builder.Property(entity => entity.GenderId).HasColumnName("GenderId");
            builder.Property(entity => entity.ClassificationId).HasColumnName("ClassificationId");
            builder.Property(entity => entity.RegionId).HasColumnName("RegionId");
            builder.Property(entity => entity.StateId).HasColumnName("StateId");
            builder.Property(entity => entity.CityId).HasColumnName("CityId");

            builder.ToTable(nameof(Customer), "dbo");
        }
    }
}
