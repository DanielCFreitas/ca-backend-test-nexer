using NexusTest.SharedKernel.Data;
using NexusTest.SharedKernel.Validations;

namespace NexusTest.Domain.Entities
{
    /// <summary>
    /// Classe que representa um Produto
    /// </summary>
    public class Product : BaseEntity
    {
        public Product(string name) : base(Guid.NewGuid())
        {
            Name = name;
        }

        public string Name { get; set; }

        public void ChangeName(string name)
        {
            Validacoes.CampoEstaVazioOuNulo(Name, "O campo Name não pode estar vazio ou nulo");
            Name = name;
        }

        public override void ValidarEntidade()
        {
            Validacoes.CampoEstaVazio(Id, "O campo Id não pode estar vazio");
            Validacoes.CampoEstaVazioOuNulo(Name, "O campo Name não pode estar vazio ou nulo");
        }
    }
}
