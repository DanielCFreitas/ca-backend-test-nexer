using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexerTest.Domain.Entities;

namespace NexerTest.Infraestructure.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(customer => customer.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(customer => customer.Address)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.HasMany(customer => customer.Billings)
                .WithOne(billing => billing.Customer)
                .HasForeignKey(billing => billing.CustomerId);

            builder.ToTable("Customer");
        }
    }
}
