namespace NexerTest.SharedKernel.Data
{
    /// <summary>
    /// IUnitOfWork to perform database operations
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Persists the necessary changes
        /// </summary>
        Task CommitAsync();
    }
}
