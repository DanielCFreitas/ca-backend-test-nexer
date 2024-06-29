using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.DTO.Request
{
    public record AddProductRequest
    {

        [Required(ErrorMessage = "The {0} field must be informed")]
        [MaxLength(100, ErrorMessage = "Field {0} must have a maximum of {0} digits")]
        public string Name { get; set; }
    }
}
