using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.DTO.Request
{
    public record AddBillingRequest
    {
        [Required(ErrorMessage = "The {0} field must be informed")]
        [MaxLength(100, ErrorMessage = "Field {0} must have a maximum of {0} digits")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        [Range(1, int.MaxValue, ErrorMessage = "The field must have at least {0}")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The {0} field must be informed")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field must have at least {0}")]
        public decimal UnitPrice { get; set; }
    }
}
