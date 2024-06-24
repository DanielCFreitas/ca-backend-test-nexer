namespace NexusTest.SharedKernel.Data
{
    /// <summary>
    /// IUnitOfWork para realizar operacoes no banco de dados
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Persiste as alteracoes necessarias
        /// </summary>
        Task CommitAsync();
    }
}
