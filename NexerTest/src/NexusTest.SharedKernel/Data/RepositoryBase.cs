namespace NexusTest.SharedKernel.Data
{
    /// <summary>
    /// Classe base para os repositories
    /// </summary>
    /// <typeparam name="T">Tipo BaseEntity necessario para implementacao</typeparam>
    public interface RepositoryBase<T> : IDisposable where T : BaseEntity
    {
        IUnitOfWork unitOfWork { get; }
    }
}
