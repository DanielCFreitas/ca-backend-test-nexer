using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexerTest.Domain.Entities;

namespace NexerTest.Infraestructure.Data.Mappings
{
    public class BillingLineMapping : IEntityTypeConfiguration<BillingLine>
    {
        public void Configure(EntityTypeBuilder<BillingLine> builder)
        {
            builder.HasKey(billingLine => billingLine.Id);

            builder.Property(billingLine => billingLine.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(billingLine => billingLine.Quantity)
                .IsRequired();

            builder.Property(billingLine => billingLine.UnitPrice)
                .IsRequired();

            builder.Property(billingLine => billingLine.BillingId)
                .IsRequired();

            builder.Property(billingLine => billingLine.ProductId)
                .IsRequired();

            builder.HasOne(billingLine => billingLine.Product)
                .WithMany()
                .HasForeignKey(billingLine => billingLine.ProductId);

            builder.HasOne(billingLine => billingLine.Billing)
                .WithMany(billing => billing.BillingLines)
                .HasForeignKey(billingLine => billingLine.BillingId);
        }
    }
}
