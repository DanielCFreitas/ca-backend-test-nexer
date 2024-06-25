using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.DTO
{
    public class CadastrarProdutoRequest
    {
        [Required(ErrorMessage = "O campo {0} deve ser informado")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {0} digitos")]
        public string Name { get; set; }
    }
}
