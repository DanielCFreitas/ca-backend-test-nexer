using NexerTest.SharedKernel.Data;

namespace NexerTest.SharedKernel.Api
{
    public abstract class BaseService
    {
        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <returns></returns>
        protected async Task SaveChanges(IUnitOfWork unitOfWork)
        {
            await unitOfWork.CommitAsync();
        }
    }
}
