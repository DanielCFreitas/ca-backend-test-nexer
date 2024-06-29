using NexerTest.SharedKernel.Data;
using NexerTest.SharedKernel.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexerTest.Domain.Entities
{
    /// <summary>
    /// Class representing a billing line
    /// </summary>
    public class Billing : BaseEntity
    {
        private IList<BillingLine> _billingLines;

        public Billing(Guid id, string invoiceNumber, Customer customer, DateTime date, DateTime dueDate, string currency) : base(id)
        {
            InvoiceNumber = invoiceNumber;
            Customer = customer;
            CustomerId = customer.Id;
            Date = date;
            DueDate = dueDate;
            Currency = currency;

            _billingLines = new List<BillingLine>();

            ValidateEntity();
        }

        public Billing()
        {
            _billingLines = new List<BillingLine>();
        }

        public string InvoiceNumber { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Currency { get; private set; }
        public IReadOnlyCollection<BillingLine> BillingLines => _billingLines.ToArray();


        [ForeignKey("Customer")]
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        /// <summary>
        /// Returns the total amount of the billing
        /// </summary>
        /// <returns>The total aount of the billing</returns>
        public decimal TotalAmount()
        {
            return _billingLines.Sum(billingLine => billingLine.Quantity * billingLine.UnitPrice);
        }

        /// <summary>
        /// Add new billing line
        /// </summary>
        /// <param name="billingLine">Billing line to be added</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddBillingLine(BillingLine billingLine)
        {
            ArgumentNullException.ThrowIfNull(nameof(billingLine));

            _billingLines.Add(billingLine);
            billingLine.SetBilling(this);
        }

        /// <summary>
        /// Set the customer Id
        /// </summary>
        public void SetCustomerId(Guid customerId)
        {
            Validations.FieldIsEmpty(customerId, "The customer ID needs to be provided");

            CustomerId = customerId;
        }

        public override void ValidateEntity()
        {
            Validations.FieldIsNullOrEmpty(InvoiceNumber, "InvoiceNumber field is empty");
            Validations.FieldMustBeLessThan(InvoiceNumber.Length, 101, "The field must have a maximum of 100 characters");
            Validations.FieldIsNullOrEmpty(Date, "The field needs to be provided");
            Validations.FieldIsNullOrEmpty(DueDate, "The field needs to be provided");
            Validations.FieldIsNullOrEmpty(Currency, "The field needs to be provided");
            Validations.FieldIsEmpty(CustomerId, "The customer ID needs to be provided");
            Validations.FieldMustBeLessThan(Date, DueDate, "The expiration date field must be before the purchase date");
        }
    }
}
