using NexusTest.Domain.Entities;
using NexusTest.SharedKernel.Data;

namespace NexusTest.Domain.Repositories
{
    /// <summary>
    /// Repository que representa clientes dentro do sistem
    /// </summary>
    public interface ICustomerRepository : RepositoryBase<Customer>
    {
        /// <summary>
        /// Cadastra um novo cliente no banco de dados
        /// </summary>
        /// <param name="customer">Cliente que sera cadastrado</param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// Busca cliente por Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Retorna o cliente encontrado atraves do id</returns>
        Task<Customer?> SearchCustomerById(Guid id);

        /// <summary>
        /// Lista os clientes que estao salvos
        /// </summary>
        /// <returns>Lista de clientes encontrados</returns>
        Task<IEnumerable<Customer>> ListCustomers();

        /// <summary>
        /// Atualiza cliente
        /// </summary>
        /// <param name="customer">Cliente que sera atualizado</param>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// Exclui um cliente 
        /// </summary>
        /// <param name="customer">Cliente que sera excluido</param>
        void DeleteCustomer(Customer customer);
    }
}
