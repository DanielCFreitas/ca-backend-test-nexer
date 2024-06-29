using NexerTest.SharedKernel.Data;
using NexerTest.SharedKernel.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexerTest.Domain.Entities
{
    /// <summary>
    /// Class that represents a Billing Line
    /// </summary>
    public class BillingLine : BaseEntity
    {
        public BillingLine(Guid id, Guid productId, string description, int quantity, decimal unitPrice) : base(id)
        {
            ProductId = productId;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        [ForeignKey("Billing")]
        public Guid BillingId { get; private set; }
        public Billing Billing { get; private set; }

        [ForeignKey("Produto")]
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        /// <summary>
        /// The total of this billing line
        /// </summary>
        /// <returns></returns>
        public decimal Total()
        {
            return UnitPrice * Quantity;
        }

        /// <summary>
        /// Set the Billing this billing line belongs
        /// </summary>
        /// <param name="billing"></param>
        public void SetBilling(Billing billing)
        {
            ArgumentNullException.ThrowIfNull(billing);

            Billing = billing;
            BillingId = billing.Id;
        }

        public override void ValidateEntity()
        {
            Validations.FieldIsEmpty(ProductId, "Product ID needs to be provided");
            Validations.FieldIsNullOrEmpty(Description, "Description field is empty");
            Validations.FieldMustBeGratherThan(Quantity, 0, "The field must be greater than 0");
            Validations.FieldMustBeGratherThan(UnitPrice, 0.0m, "The field must be greater than 0");
        }
    }
}
