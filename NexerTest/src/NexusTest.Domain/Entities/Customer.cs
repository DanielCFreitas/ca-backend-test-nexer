using NexusTest.SharedKernel.Data;
using NexusTest.SharedKernel.Validations;

namespace NexusTest.Domain.Entities
{
    /// <summary>
    /// Classe que representa um cliente na aplicacao
    /// </summary>
    public class Customer : BaseEntity
    {
        public Customer(string name, string email, string address) : base(Guid.NewGuid())
        {
            Name = name;
            Email = email;
            Address = address;

            ValidarEntidade();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        public void ChangeName(string name)
        {
            Validacoes.CampoEstaVazioOuNulo(name, "O campo Name não pode estar vazio ou nulo");
            Name = name;
        }

        public void ChangeEmail(string email)
        {
            Validacoes.CampoEstaVazioOuNulo(email, "O campo Email não pode estar vazio ou nulo");
            Email = email;
        }


        public void ChangeAddress(string address)
        {
            Validacoes.CampoEstaVazioOuNulo(address, "O campo Address não pode estar vazio ou nulo");
            Address = address;
        }


        public override void ValidarEntidade()
        {
            Validacoes.CampoEstaVazioOuNulo(Name, "O campo Name não pode estar vazio ou nulo");
            Validacoes.CampoEstaVazioOuNulo(Address, "O campo Address não pode estar vazio ou nulo");
            Validacoes.CampoEstaVazioOuNulo(Email, "O campo Email não pode estar vazio ou nulo");
        }
    }
}
