using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.DTO
{
    public record AtualizarClienteRequest
    {
        [Required(ErrorMessage = "O campo {0} deve ser informado")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {0} digitos")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser informado")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {0} digitos")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser informado")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {0} digitos")]
        public string Address { get; set; }
    }
}
