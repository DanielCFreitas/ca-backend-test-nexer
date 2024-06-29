using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexerTest.Domain.Entities;

namespace NexerTest.Infraestructure.Data.Mappings
{
    public class BillingMapping : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.HasKey(billing => billing.Id);

            builder.Property(billing => billing.InvoiceNumber)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(billing => billing.Date)
                .IsRequired();

            builder.Property(billing => billing.DueDate)
                .IsRequired();

            builder.Property(billing => billing.Currency)
                .IsRequired()
                .HasColumnType("VARCHAR(10)");

            builder.Property(billing => billing.CustomerId)
                .IsRequired();

            builder.HasOne(billing => billing.Customer)
                .WithMany(customer => customer.Billings)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Billing");
        }
    }
}
