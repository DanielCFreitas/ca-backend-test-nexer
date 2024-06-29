using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.DTO.Request
{
    public record AddBillingRequest(string invoiceNumber, DateTime date, DateTime dueDate, string currency, Guid customerId, Guid productId, int quantity, decimal unitPrice)
    {
        [Required(ErrorMessage = "The {0} field must be informed")]
        [MaxLength(100, ErrorMessage = "Field {0} must have a maximum of {0} digits")]
        public string InvoiceNumber { get; } = invoiceNumber;

        [Required(ErrorMessage = "The {0} field must be informed")]
        public DateTime Date { get; } = date;

        [Required(ErrorMessage = "The {0} field must be informed")]
        public DateTime DueDate { get; } = dueDate;

        [Required(ErrorMessage = "The {0} field must be informed")]
        public string Currency { get; } = currency;

        [Required(ErrorMessage = "The {0} field must be informed")]
        public Guid CustomerId { get; } = customerId;

        [Required(ErrorMessage = "The {0} field must be informed")]
        public Guid ProductId { get; } = productId;

        [Required(ErrorMessage = "The {0} field must be informed")]
        [Range(1, int.MaxValue, ErrorMessage = "The field must have at least {0}")]
        public int Quantity { get; } = quantity;

        [Required(ErrorMessage = "The {0} field must be informed")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field must have at least {0}")]
        public decimal UnitPrice { get; } = unitPrice;
    }
}
