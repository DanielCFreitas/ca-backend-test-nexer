namespace NexerTest.SharedKernel.Data
{
    /// <summary>
    /// Base class for repositories
    /// </summary>
    /// <typeparam name="T">BaseEntity type required for implementation</typeparam>
    public interface IRepositoryBase<T> : IDisposable where T : BaseEntity
    {
        IUnitOfWork unitOfWork { get; }
    }
}
