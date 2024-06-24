using NexusTest.Api.DTO;
using NexusTest.Domain.Entities;

namespace NexusTest.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <returns></returns>
        Task CadastrarCliente(CadastrarClienteRequest request);

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> ListarClientes();

        /// <summary>
        /// Busca cliente por id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        Task<Customer?> BuscarClientePorId(Guid id);

        /// <summary>
        /// Atualiza um cliente no banco
        /// </summary>
        /// <param name="customer">Cliente para ser atualizado</param>
        /// <returns></returns>
        Task AtualizarCliente(Customer customer);

        /// <summary>
        /// Exclui um cliente atraves do id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        Task ExcluirCliente(Guid id);
    }
}
